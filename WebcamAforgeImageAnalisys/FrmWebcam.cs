using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using AForge.Imaging.Filters;

namespace WebcamAforgeImageAnalisys
{
    public partial class frmWebcam : Form
    {
        private Stopwatch stopWatch = null;
        private Bitmap imgsave;
        private float fps;
        private VideoCaptureDevice videoSource;
        private OpenFileDialog openFileDialog;

        public frmWebcam()
        {
            InitializeComponent();
        }

        private void btnCamChange_Click(object sender, EventArgs e)
        {
            VideoCaptureDeviceForm form = new VideoCaptureDeviceForm();

            if (form.ShowDialog(this) == DialogResult.OK)
            {
                // create video source
                videoSource = form.VideoDevice;
                // open it
                OpenVideoSource(videoSource);
                //discover selected device
                FilterInfoCollection allDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                VideoCaptureDevice currentDevice = form.VideoDevice;
                for (int i = 0; i <= allDevices.Count; i++)
                {
                    if (allDevices[i].MonikerString == form.VideoDeviceMoniker)
                    {
                        txtCam.Text = allDevices[i].Name; //.Substring(0, 25);
                        txtResolution.Text = videoSource.VideoResolution.FrameSize.Width + "x"
                                             + videoSource.VideoResolution.FrameSize.Height + " - "
                                             + videoSource.VideoResolution.AverageFrameRate + " fps";
                        break;
                    }
                }
            }
        }

        // Open video source
        private void OpenVideoSource(IVideoSource source)
        {
            // set busy cursor
            this.Cursor = Cursors.WaitCursor;
            // stop current video source
            CloseCurrentVideoSource();
            // start new video source
            vspMainPlayer.VideoSource = source;
            vspMainPlayer.Start();
            // reset stop watch
            stopWatch = null;
            // start timer
            timer.Start();
            this.Cursor = Cursors.Default;
        }

        // Close video source if it is running
        private void CloseCurrentVideoSource()
        {
            if (vspMainPlayer.VideoSource != null)
            {
                vspMainPlayer.SignalToStop();

                // wait ~ 3 seconds
                for (int i = 0; i < 30; i++)
                {
                    if (!vspMainPlayer.IsRunning)
                        break;
                    System.Threading.Thread.Sleep(100);
                }

                if (vspMainPlayer.IsRunning)
                {
                    vspMainPlayer.Stop();
                }

                vspMainPlayer.VideoSource = null;
            }
        }

        // On timer event - gather statistics
        private void timer_Tick(object sender, EventArgs e)
        {
            IVideoSource videoSource = vspMainPlayer.VideoSource;

            if (videoSource != null)
            {
                // get number of frames since the last timer tick
                int framesReceived = videoSource.FramesReceived;

                if (stopWatch == null)
                {
                    stopWatch = new Stopwatch();
                    stopWatch.Start();
                }
                else
                {
                    stopWatch.Stop();
                    //FPS in real time
                    fps = 1000.0f * framesReceived / stopWatch.ElapsedMilliseconds;
                    lblFps.Text = fps.ToString("F2") + " fps";

                    stopWatch.Reset();
                    stopWatch.Start();
                }
            }
        }

        private void frmWebcam_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseCurrentVideoSource();
        }

        //every new frame event on player
        private void vspMainPlayer_NewFrame(object sender, ref Bitmap image)
        {
            DateTime now = DateTime.Now;
            Graphics gDateTime = Graphics.FromImage(image);
            Graphics gFps = Graphics.FromImage(image);
            SolidBrush brush = new SolidBrush(System.Drawing.Color.LightGreen);
            // show date and time
            Font font = new Font(FontFamily.GenericMonospace, videoSource.VideoResolution.FrameSize.Width * 2 / 100, FontStyle.Bold);
            gDateTime.DrawString($"{now.ToString()} - {fps.ToString("F0")}", font, brush, new PointF(5, 5));
            //brush.Color = System.Drawing.Color.Green;
            //gFps.DrawString(fps.ToString("F0") + " fps",font, brush,
            //                new PointF(videoSource.VideoResolution.FrameSize.Width-100, 5));
            brush.Dispose();
            gDateTime.Dispose();
            gFps.Dispose();
        }

        private void btnScreenshot_Click(object sender, EventArgs e)
        {
            if (vspMainPlayer.IsRunning && vspMainPlayer.GetCurrentVideoFrame() != null)
            {
                imgsave = new Bitmap(vspMainPlayer.GetCurrentVideoFrame());
                this.Hide();
                FrmScreenshot frmScreenshot = new FrmScreenshot(imgsave, this);
                frmScreenshot.Show();
            }
            else
            {
                MessageBox.Show("Falha ao capturar a imagem!\n\nSelecione um dispositivo antes de capturar a imagem!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            using (openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imagens (*.jpg)|*.jpg";
                openFileDialog.DefaultExt = "*.jpg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //lock (this)
                        //{

                        imgsave = new Bitmap(Image.FromFile(openFileDialog.FileName));

                        //}
                        this.Hide();
                        FrmScreenshot frmScreenshot = new FrmScreenshot(imgsave, this);
                        frmScreenshot.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Falha ao carregar a imagem!\n" + ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Operação cancelada!", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }
    }
}

