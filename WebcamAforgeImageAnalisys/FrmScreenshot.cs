using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows.Forms;
using Google.Cloud.Vision.V1;

namespace WebcamAforgeImageAnalisys
{
    public partial class FrmScreenshot : Form
    {
        private Bitmap screenshot;
        private SaveFileDialog saveFileDialog;
        private frmWebcam frmcam;
        private static string subscriptionKey;
        private static string uriBase = "https://brazilsouth.api.cognitive.microsoft.com/face/v1.0/analyze";

        public FrmScreenshot(Bitmap img, object sender)
        {
            screenshot = img;
            frmcam = (frmWebcam)sender;
            InitializeComponent();
        }

        private void FrmScreenshot_Load(object sender, EventArgs e)
        {
            pbScreenshot.Image = screenshot;
            rbGoogleAnalisys.Checked = true;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (rbLocalSaveImage.Checked)
            {
                using (saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Imagens (*.jpg)|*.jpg";
                    saveFileDialog.DefaultExt = "*.jpg";
                    //JPEG, PNG8, PNG24, GIF, GIF animado (primeiro quadro apenas), BMP, WEBP, RAW, ICO
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ImageFormat format = ImageFormat.Jpeg;

                        try
                        {
                            lock (this)
                            {
                                //Bitmap img = vspMainPlayer.GetCurrentVideoFrame();
                                //img.Save(saveFileDialog.FileName, format);
                                screenshot.Save(saveFileDialog.FileName, format);
                                //("1.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                                MessageBox.Show("Imagem salva com sucesso!", "Sucesso",
                                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Falha ao salvar a imagem!\n" + ex.Message, "Erro!",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            //Nothing yet
                        }
                    }
                    else
                    {
                        MessageBox.Show("Operação cancelada!", "Cancelado", MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                }
            }

            //Analisys by Google Cloud
            if (rbGoogleAnalisys.Checked)
            {
                try
                {
                    lock (this)
                    {
                        //Variável setada no código devido erro ao reconhecer variável setada no ambiente
                        System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\ApiKeys\googleKey.json");
                        string Pathsave = System.Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

                        //Cliente da requisição
                        var client = ImageAnnotatorClient.Create();
                        pbScreenshot.Image.Save(@".\detection.jpg", ImageFormat.Jpeg);
                        var image = Google.Cloud.Vision.V1.Image.FromFile(@".\detection.jpg");

                        //Executa a análise da imagem
                        var resposta = client.DetectFaces(image);

                        foreach (var face in resposta)
                        {
                            MessageBox.Show("Imagem analisada com sucesso:\n\n\n"
                                + "Alegria: " + face.JoyLikelihood + "\n"
                                + "Raiva: " + face.AngerLikelihood + "\n"
                                + "Tristeza: " + face.SorrowLikelihood + "\n"
                                + "Surpresa: " + face.SurpriseLikelihood + "\n"
                                + "Subexposição: " + face.UnderExposedLikelihood + "\n"
                                + "Borrado: " + face.BlurredLikelihood + "\n"
                                + "Chapéu?: " + face.HeadwearLikelihood + "\n"
                                + "Confiança (Detecção): " + face.DetectionConfidence + "\n"
                                + "Retângulo OUT: " + face.BoundingPoly + "\n"
                                + "Retângulo IN: " + face.FdBoundingPoly + "\n"
                                //+ "Pontos na face: " + face.Landmarks + "\n"
                                //+ "Confiança (Marcas): " + face.LandmarkingConfidence + "\n"
                                + "Ângulo Horizontal: " + face.PanAngle + "\n"
                                + "Ângulo Vertical: " + face.RollAngle + "\n"
                                + "Ângulo de Rotação: " + face.TiltAngle + "\n"
                                
                                + ".", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        //MessageBox.Show("Imagem analisada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falha ao analisar imagem!\n" + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                }
            }

            //Analisys by Microsoft Azure
            if (rbMicrosoftAnalisys.Checked)
            {
                string subscriptionKey = File.ReadAllText(@"C:\ApiKeys\WebcamAforge.txt");
                MakeAnalysisRequest(@".\detection.jpg").Wait();
            }
        }

        ///Assinc Azure request
        static async Task MakeAnalysisRequest(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();
                // Request headers.
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                // Request parameters. A third optional parameter is "details".
                string requestParameters ="visualFeatures=Categories,Description,Color";
                // Assemble the URI for the REST API Call.
                string uri = uriBase + "?" + requestParameters;

                HttpResponseMessage response;
                // Request body. Posts a locally stored JPEG image.
                byte[] byteData = GetImageAsByteArray(imageFilePath);

                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses content type "application/octet-stream".
                    // The other content types you can use are "application/json"
                    // and "multipart/form-data".
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                    // Make the REST API call.
                    response = await client.PostAsync(uri, content);
                }
                // Get the JSON response.
                string contentString = await response.Content.ReadAsStringAsync();
                // Display the JSON response.
                Console.WriteLine("\nResponse:\n\n{0}\n", JToken.Parse(contentString).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }

        //returns The byte array of the image data
        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }

        





        private void FrmScreenshot_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmcam.Show();
        }

        private void rbGoogleAnalisys_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGoogleAnalisys.Checked)
            {
                pbSelectedOption.Image = System.Drawing.Image.FromFile(@"..\..\Resources\google.png");
                txtInformation.BackColor = System.Drawing.Color.WhiteSmoke;
                txtInformation.ForeColor = System.Drawing.Color.DarkBlue;
                txtInformation.Text = "A imagem capturada será enviada para um servidor da Google Cloud," +
                                      " onde uma inteligência artificial fará a análise e retornará as informações" +
                                      " acerca da quantidade de pessoas na imagem e emoções demonstradas por cada " +
                                      "uma delas.";
            }
        }

        private void rbMicrosoftAnalisys_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMicrosoftAnalisys.Checked)
            {
                pbSelectedOption.Image = System.Drawing.Image.FromFile(@"..\..\Resources\microsoft.png");
                txtInformation.BackColor = System.Drawing.Color.WhiteSmoke;
                txtInformation.ForeColor = System.Drawing.Color.DarkGreen;
                txtInformation.Text = "A imagem capturada será enviada para um servidor da Microsoft Azure," +
                                      " onde uma inteligência artificial fará a análise e retornará as informações" +
                                      " acerca da quantidade de pessoas na imagem e emoções demonstradas por cada " +
                                      "uma delas.";
            }
        }

        private void rbLocalSaveImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLocalSaveImage.Checked)
            {
                pbSelectedOption.Image = System.Drawing.Image.FromFile(@"..\..\Resources\save.png");
                txtInformation.BackColor = System.Drawing.Color.WhiteSmoke;
                txtInformation.ForeColor = System.Drawing.Color.Black;
                txtInformation.Text = "A imagem capturada será salva localmente, em uma pasta à escolha do usuário.";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?\n\nToda a aplicação será encerrada!",
                                "Deseja sair?", MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning).ToString().ToUpper() == "YES")
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmcam.Show();
        }
    }
}
