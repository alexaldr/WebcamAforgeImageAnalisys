using System;
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
        private static Bitmap face;
        private static List<ResponseMicrosoftAzure> responseMicrosoft;
        private static List<ResponseGoogle> responseGoogle;

        public FrmGraph(List<ResponseMicrosoftAzure> r, Bitmap f)
        {
            face = f;
            responseMicrosoft = r;
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
                    chart1.Series.Remove(chart1.Series["Series1"]);

                    string gender = r.faceAttributes.gender == "male" ? "Masculino" : "Feminino";
                    lblDetails.Text = "Gênero: " + gender +
                                      "\nIdade aproximada: " + Math.Round(r.faceAttributes.age);

                    string[] series =
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
                    for (int i = 0; i < series.Length; i++)
                    {
                        //chart1.Series.Add(series[i]);
                        //chart1.Series[series[i]].Points.AddXY(series[i], pontos[i]);

                        chart1.Series.Add(series[i]);
                        chart1.Series[series[i]].ChartType = SeriesChartType.Column;
                        chart1.Series[series[i]].Points.AddY(pontos[i]);
                        chart1.Series[series[i]].ChartArea = "ChartArea1";



                        //titles
                        //Series serie = chart1.Series.Add(series[i]);
                        ////values
                        //serie.Label = pontos[i].ToString();
                        //serie.Points.Add(pontos[i]);
                        //chart1.Series.add
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
