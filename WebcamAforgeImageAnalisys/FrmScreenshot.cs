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
        private Bitmap screenshot, bm;
        private SaveFileDialog saveFileDialog;
        private frmWebcam frmcam;
        private static string subscriptionKey;
        private static string uriBase = "https://brazilsouth.api.cognitive.microsoft.com/face/v1.0/analyze";
        static List<Response> retorno = new List<Response>();

        public FrmScreenshot(Bitmap img, object sender)
        {
            screenshot = img;
            frmcam = (frmWebcam)sender;
            InitializeComponent();
            bm = new Bitmap(pbScreenshot.ClientRectangle.Width, pbScreenshot.ClientRectangle.Height);
        }

        private void FrmScreenshot_Load(object sender, EventArgs e)
        {
            pbScreenshot.Image = screenshot;
            rbGoogleAnalisys.Checked = true;
        }



        //change mouse cursor
        private void mouse_busy(bool busy)
        {
            if (busy)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
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
                retorno.Clear();
                mouse_busy(true);
                rbMicrosoftAnalisys.Enabled = false;
                try
                {
                    lock (this)
                    {
                        //Variável setada no código devido erro ao reconhecer variável setada no ambiente
                        System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"C:\ApiKeys\WebcamAforgeGoogle.json");
                        string Pathsave = System.Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

                        //Cliente da requisição
                        var client = ImageAnnotatorClient.Create();
                        pbScreenshot.Image.Save(@".\detection.jpg", ImageFormat.Jpeg);
                        var image = Google.Cloud.Vision.V1.Image.FromFile(@".\detection.jpg");

                        //Executa a análise da imagem
                        var resposta = client.DetectFaces(image);

                        //individual strings for results
                        //string alegria, raiva, tristeza, surpresa, subexposição, borrado, chapeu, confianca,
                        //       retanguloOut, retanguloIn, anguloHorizontal, anguloVertical, anguloRotacao;
                        if (resposta.Count == 0)
                        {
                            MessageBox.Show("Nenhuma face encontrada!\n", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        int count = 0;
                        foreach (var face in resposta)
                        {
                            //draw lines over the face
                            Graphics g;
                            SolidBrush brush = new SolidBrush(System.Drawing.Color.Red);
                            Font font = new Font(FontFamily.GenericMonospace, pbScreenshot.Image.Width * 2 / 100, FontStyle.Bold);
                            g = Graphics.FromImage(screenshot);
                            Pen pen = new Pen(brush, 4.0f);
                            g.DrawLine(pen, face.FdBoundingPoly.Vertices[0].X, face.FdBoundingPoly.Vertices[0].Y,
                                              face.FdBoundingPoly.Vertices[1].X,
                                              face.FdBoundingPoly.Vertices[1].Y);
                            g.DrawLine(pen, face.FdBoundingPoly.Vertices[1].X, face.FdBoundingPoly.Vertices[1].Y,
                                              face.FdBoundingPoly.Vertices[2].X,
                                              face.FdBoundingPoly.Vertices[2].Y);
                            g.DrawLine(pen, face.FdBoundingPoly.Vertices[2].X, face.FdBoundingPoly.Vertices[2].Y,
                                              face.FdBoundingPoly.Vertices[3].X,
                                              face.FdBoundingPoly.Vertices[3].Y);
                            g.DrawLine(pen, face.FdBoundingPoly.Vertices[3].X, face.FdBoundingPoly.Vertices[3].Y,
                                              face.FdBoundingPoly.Vertices[0].X,
                                              face.FdBoundingPoly.Vertices[0].Y);
                            g.DrawString($"Face \"{count + 1}\"", font, brush,
                                                            face.FdBoundingPoly.Vertices[3].X,
                                                            face.FdBoundingPoly.Vertices[3].Y + 5);
                            pbScreenshot.Image = screenshot;
                            g.Dispose();
                            count++;

                            //MessageBox.Show("Imagem analisada com sucesso:\n\n\n"
                            //    + "Alegria: " + face.JoyLikelihood + "\n"
                            //    + "Raiva: " + face.AngerLikelihood + "\n"
                            //    + "Tristeza: " + face.SorrowLikelihood + "\n"
                            //    + "Surpresa: " + face.SurpriseLikelihood + "\n"
                            //    + "nudez: " + face.UnderExposedLikelihood + "\n"
                            //    + "Borrado: " + face.BlurredLikelihood + "\n"
                            //    + "Chapéu?: " + face.HeadwearLikelihood + "\n"
                            //    + "Confiança (Detecção): " + face.DetectionConfidence + "\n"
                            //    + "Retângulo IN: " + face.BoundingPoly + "\n"
                            //    + "Retângulo OUT: " + face.FdBoundingPoly + "\n"
                            //    //+ "Pontos na face: " + face.Landmarks + "\n"
                            //    //+ "Confiança (Marcas): " + face.LandmarkingConfidence + "\n"
                            //    + "Ângulo Horizontal: " + face.PanAngle + "\n"
                            //    + "Ângulo Vertical: " + face.RollAngle + "\n"
                            //    + "Ângulo de Rotação: " + face.TiltAngle + "\n"
                            //    + ".", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


                            //MessageBox.Show(face.Landmarks.ToString());


                            Response current = null;
                            current = new Response
                            {
                                face = count,
                                Confianca= face.DetectionConfidence,
                                DownRightPoint = new Point(face.FdBoundingPoly.Vertices[2].X, face.FdBoundingPoly.Vertices[2].Y),
                                UpLeftPoint = new Point(face.FdBoundingPoly.Vertices[0].X, face.FdBoundingPoly.Vertices[0].Y),
                                Alegria = StringResponseToInt(face.JoyLikelihood.ToString()),
                                Raiva = StringResponseToInt(face.AngerLikelihood.ToString()),
                                Surpresa = StringResponseToInt(face.SurpriseLikelihood.ToString()),
                                Tristeza = StringResponseToInt(face.SorrowLikelihood.ToString()),
                                Nudez = StringResponseToInt(face.UnderExposedLikelihood.ToString()),
                                Chapeu = StringResponseToInt(face.HeadwearLikelihood.ToString()),
                                AnguloHorizontal = face.PanAngle.ToString(),
                                AnguloRotacao = face.TiltAngle.ToString(),
                                AnguloVertical  = face.RollAngle.ToString()
                            };

                            //current.UserSetField1 = field1;

                            //add to global list
                            retorno.Add(current);
                            //MessageBox.Show("Alegria:"+ face.JoyLikelihood.ToString(), "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);





                        }
                        mouse_busy(false);
                        MessageBox.Show("Imagem analisada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                pbScreenshot.Image.Save(@".\detection.jpg", ImageFormat.Jpeg);
                //var image = System.Drawing.Image.FromFile(@".\detection.jpg");
                subscriptionKey = File.ReadAllText(@"C:\ApiKeys\WebcamAforgeAzure.txt");
                MakeAnalysisRequest(@".\detection.jpg").Wait();
            }
        }

        private int StringResponseToInt(string value)
        {
            switch (value)
            {
                case "VeryUnlikely":
                    {
                        return 0;
                        break;
                    }
                case "Unlikely":
                    {
                        return 1;
                        break;
                    }
                case "Possible":
                    {
                        return 2;
                        break;
                    }
                case "Likely":
                    {
                        return 3;
                        break;
                    }
                case "VeryLikely":
                    {
                        return 4;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("A mensagem de retorno não condiz com o esperado!\n", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

            }


            return 0;
        }

        ///Assinc Azure request
        private static async Task MakeAnalysisRequest(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();
                // Request headers.
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                // Request parameters. A third optional parameter is "details".
                string requestParameters = "visualFeatures=Categories,Description,Color";
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
                MessageBox.Show("\n" + e.Message);
            }
        }

        //returns The byte array of the image data
        private static byte[] GetImageAsByteArray(string imageFilePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
                {
                    BinaryReader binaryReader = new BinaryReader(fileStream);
                    return binaryReader.ReadBytes((int)fileStream.Length);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("\n" + e.Message);
                return null;
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

        private void pbScreenshot_MouseClick(object sender, MouseEventArgs e)
        {
            //Point mousePoint = new Point(MousePosition.X, MousePosition.Y);
            //853; 443;

            Point mousePoint = new Point(e.X, e.Y);

            //MessageBox.Show($"Coordenadas: X:{e.X}, Y:{e.Y}", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show($"HorizontalResolution:{pbScreenshot.Image.Width})", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);


            foreach (Response r in retorno)
            {
                if (mousePoint.X <= r.DownRightPoint.X && mousePoint.X >= r.UpLeftPoint.X)
                {
                    if (mousePoint.Y <= r.DownRightPoint.Y && mousePoint.Y >= r.UpLeftPoint.Y)
                    {
                        MessageBox.Show($"Alegria: {r.Alegria}\n" +
                            $"Raiva: {r.Raiva}\n" +
                            $"Tristeza: {r.Tristeza}\n" +
                            $"Surpresa: {r.Surpresa}\n" +
                            $"Nudez: {r.Nudez}\n" +
                            $"Acessório na cabeça: {r.Chapeu}\n" +
                            $"\n\"Ângulação da cabeça\"\n" +
                            $"          Horizontal: {r.AnguloHorizontal}\n" +
                            $"          Vertical: {r.AnguloVertical}\n" +
                            $"          Rotação: {r.AnguloRotacao}\n" +
                            $"\nConfiança da detecção: {r.Raiva * 100}%\n",
                            $"Face nº \"0{r.face}", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }


        }

        private void FrmScreenshot_Shown(object sender, EventArgs e)
        {
            pbScreenshot.Location = new Point((FrmScreenshot.ActiveForm.Width - pbScreenshot.Size.Width) / 2, pbScreenshot.Location.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose();
            frmcam.Show();
        }
    }

    internal class Response
    {
        public int face { get; set; }
        public Point DownRightPoint { get; set; }
        public Point UpLeftPoint { get; set; }
        public int Alegria { get; set; }
        public int Raiva { get; set; }
        public int Tristeza { get; set; }
        public int Surpresa { get; set; }
        public int Nudez { get; set; }
        //public int Borrado { get; set; }
        public int Chapeu { get; set; }
        public float Confianca { get; set; }
        //public int // retanguloOut = face.FdBoundingPoly.Toint() { get; set }
        //public int // retanguloIn = face.BoundingPoly.Toint() { get; set }
        //public int // "Pontos na face: " + face.Landmarks + "\n"
        //public int // "Confiança (Marcas): " + face.LandmarkingConfidence + "\n"
        public string AnguloHorizontal { get; set; }
        public string AnguloVertical { get; set; }
        public string AnguloRotacao { get; set; }
    }




}