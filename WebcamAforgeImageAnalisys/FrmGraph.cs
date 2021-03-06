﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WebcamAforgeImageAnalisys
{
    public partial class FrmGraph : Form
    {
        private static Bitmap face, croppedFace;
        private static List<ResponseMicrosoftAzure> responseMicrosoft;
        private static List<ResponseGoogle> responseGoogle;

        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }

        public FrmGraph(List<ResponseMicrosoftAzure> r, Bitmap f)
        {
            responseMicrosoft = r;
            face = f;

            InitializeComponent();
            MicrosoftAnalysis();

        }

        public FrmGraph(List<ResponseGoogle> r, Bitmap f)
        {
            face = f;
            responseGoogle = r;
            InitializeComponent();
            GoogleAnalysis();
        }






        private void MicrosoftAnalysis()
        {
            int count = 0;
            //for (int i = 0; i < responseMicrosoft.Count; i++)
            //{
            //    tabGraph.TabPages.RemoveAt(5 - i);
            //}
            foreach (ResponseMicrosoftAzure r in responseMicrosoft)
            {
                try
                {
                    croppedFace = CropBitmap(face, r.faceRectangle.left, r.faceRectangle.top, r.faceRectangle.width, r.faceRectangle.height);
                    pbFace.Image = croppedFace;

                    chart1.Series.Remove(chart1.Series["Series1"]);

                    string gender = r.faceAttributes.gender == "male" ? "Masculino" : "Feminino";
                    lblDetails.Text = "Gênero: " + gender +
                                      "\nIdade aproximada: " + Math.Round(r.faceAttributes.age);

                    string[] serie =
                    {
                        "Raiva",
                        "Desprezo",
                        "Desgosto",
                        "Medo",
                        "Felicidade",
                        "Neutralidade",
                        "Tristeza",
                        "Surpresa"
                    };
                    double[] pontos =
                    {
                        //Convert.ToInt32(Math.Floor(r.faceEmotion.anger*100)),
                        r.faceAttributes.emotion.anger*100,
                        r.faceAttributes.emotion.contempt*100,
                        r.faceAttributes.emotion.disgust*100,
                        r.faceAttributes.emotion.fear*100,
                        r.faceAttributes.emotion.happiness*100,
                        r.faceAttributes.emotion.neutral*100,
                        r.faceAttributes.emotion.sadness*100,
                        r.faceAttributes.emotion.surprise*100
                    };

                    
                    chart1.Series.Clear();
                    
                    
                    for (int i = 0; i < serie.Length; i++)
                    {
                        

                        chart1.Series.Add(serie[i]);
                        chart1.Series[serie[i]].Points.Clear();
                        chart1.Series[serie[i]].AxisLabel = (i + 1).ToString();
                        chart1.Series[serie[i]].Points.AddY(pontos[i]);
                        //chart1.Series[serie[i]].Points.AddY(pontos[i]);
                        //chart1.Series[serie[i]].Points.AddY(pontos[i]);
                        //chart1.Series[serie[i]].Points.AddY(pontos[i]);
                        //chart1.Series[serie[i]].Points.AddY(pontos[i]);


                        chart1.Series[serie[i].ToString()].IsXValueIndexed = true;
                        //chart1.Series[series[i]].ChartArea = "ChartArea1";


                        //chart1.Series[series[i]].ChartType = SeriesChartType.Column;

                        //chart1.Series[i].Points.AddY(pontos[i]);


                        //chart1.Series[series[i]].LabelAngle = 45;


                        //chart1.Series[i].Label = series[i];
                        //chart1.Series[series[i]].SetCustomProperty("PixelPointWidth", "10");
                        //chart1.Series[series[i]].SetCustomProperty("PointWidth", "10");

                       // chart1.AlignDataPointsByAxisLabel();
                        

                        //chart1.Series[i].Points[i].AxisLabel = series[i];
                        //chart1.Series[i].ChartArea = "ChartArea1";
                        //
                        chart1.Update();
                        //MessageBox.Show($"{chart1.Series.Count}", "Count!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }



                }
                catch (Exception e)
                {
                    MessageBox.Show("Falha na tarefa!" + e.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //nothing yet
                }




                /*
                anger": 0.0,
                "contempt": 0.0,
                "disgust": 0.0,
                "fear": 0.0,
                "happiness": 0.001,
                "neutral": 0.999,
                "sadness": 0.0,
                "surprise": 0.0
                */
            }

            //System.Windows.Forms.DataVisualization.Charting.Chart;
        }

        private void GoogleAnalysis()
        {

        }




        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void FrmGraph_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
