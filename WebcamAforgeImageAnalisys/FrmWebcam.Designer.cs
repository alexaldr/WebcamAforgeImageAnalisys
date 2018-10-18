namespace WebcamAforgeImageAnalisys
{
    partial class frmWebcam
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebcam));
            this.vspMainPlayer = new AForge.Controls.VideoSourcePlayer();
            this.gbVideoSource = new System.Windows.Forms.GroupBox();
            this.btnScreenshot = new System.Windows.Forms.Button();
            this.lblFps = new System.Windows.Forms.Label();
            this.lblFpsPrefix = new System.Windows.Forms.Label();
            this.lblResolution = new System.Windows.Forms.Label();
            this.txtResolution = new System.Windows.Forms.TextBox();
            this.txtCam = new System.Windows.Forms.TextBox();
            this.lblCam = new System.Windows.Forms.Label();
            this.btnCamChange = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.gbVideoSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // vspMainPlayer
            // 
            this.vspMainPlayer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.vspMainPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vspMainPlayer.KeepAspectRatio = true;
            this.vspMainPlayer.Location = new System.Drawing.Point(12, 12);
            this.vspMainPlayer.Name = "vspMainPlayer";
            this.vspMainPlayer.Size = new System.Drawing.Size(854, 480);
            this.vspMainPlayer.TabIndex = 0;
            this.vspMainPlayer.Text = "vspMainPlayer";
            this.vspMainPlayer.VideoSource = null;
            this.vspMainPlayer.NewFrame += new AForge.Controls.VideoSourcePlayer.NewFrameHandler(this.vspMainPlayer_NewFrame);
            // 
            // gbVideoSource
            // 
            this.gbVideoSource.Controls.Add(this.btnScreenshot);
            this.gbVideoSource.Controls.Add(this.lblFps);
            this.gbVideoSource.Controls.Add(this.lblFpsPrefix);
            this.gbVideoSource.Controls.Add(this.lblResolution);
            this.gbVideoSource.Controls.Add(this.txtResolution);
            this.gbVideoSource.Controls.Add(this.txtCam);
            this.gbVideoSource.Controls.Add(this.lblCam);
            this.gbVideoSource.Controls.Add(this.btnCamChange);
            this.gbVideoSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbVideoSource.Location = new System.Drawing.Point(12, 498);
            this.gbVideoSource.Name = "gbVideoSource";
            this.gbVideoSource.Size = new System.Drawing.Size(854, 73);
            this.gbVideoSource.TabIndex = 1;
            this.gbVideoSource.TabStop = false;
            this.gbVideoSource.Text = "Fonte de Vídeo";
            // 
            // btnScreenshot
            // 
            this.btnScreenshot.Location = new System.Drawing.Point(657, 13);
            this.btnScreenshot.Name = "btnScreenshot";
            this.btnScreenshot.Size = new System.Drawing.Size(185, 51);
            this.btnScreenshot.TabIndex = 7;
            this.btnScreenshot.Text = "Tirar Screenshot";
            this.btnScreenshot.UseVisualStyleBackColor = true;
            this.btnScreenshot.Click += new System.EventHandler(this.btnScreenshot_Click);
            // 
            // lblFps
            // 
            this.lblFps.AutoSize = true;
            this.lblFps.Location = new System.Drawing.Point(502, 47);
            this.lblFps.Name = "lblFps";
            this.lblFps.Size = new System.Drawing.Size(43, 17);
            this.lblFps.TabIndex = 6;
            this.lblFps.Text = "0 Fps";
            // 
            // lblFpsPrefix
            // 
            this.lblFpsPrefix.AutoSize = true;
            this.lblFpsPrefix.Location = new System.Drawing.Point(425, 47);
            this.lblFpsPrefix.Name = "lblFpsPrefix";
            this.lblFpsPrefix.Size = new System.Drawing.Size(78, 17);
            this.lblFpsPrefix.TabIndex = 5;
            this.lblFpsPrefix.Text = "Rodando a";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(340, 19);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(79, 17);
            this.lblResolution.TabIndex = 3;
            this.lblResolution.Text = "Resolução:";
            // 
            // txtResolution
            // 
            this.txtResolution.Enabled = false;
            this.txtResolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResolution.Location = new System.Drawing.Point(425, 16);
            this.txtResolution.Name = "txtResolution";
            this.txtResolution.Size = new System.Drawing.Size(226, 23);
            this.txtResolution.TabIndex = 2;
            this.txtResolution.Text = "-";
            this.txtResolution.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCam
            // 
            this.txtCam.Enabled = false;
            this.txtCam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCam.Location = new System.Drawing.Point(108, 16);
            this.txtCam.MaxLength = 28;
            this.txtCam.Name = "txtCam";
            this.txtCam.Size = new System.Drawing.Size(226, 23);
            this.txtCam.TabIndex = 2;
            this.txtCam.Text = "-";
            this.txtCam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCam
            // 
            this.lblCam.AutoSize = true;
            this.lblCam.Location = new System.Drawing.Point(6, 19);
            this.lblCam.Name = "lblCam";
            this.lblCam.Size = new System.Drawing.Size(96, 17);
            this.lblCam.TabIndex = 1;
            this.lblCam.Text = "Câmera atual:";
            // 
            // btnCamChange
            // 
            this.btnCamChange.Location = new System.Drawing.Point(108, 45);
            this.btnCamChange.Name = "btnCamChange";
            this.btnCamChange.Size = new System.Drawing.Size(226, 23);
            this.btnCamChange.TabIndex = 0;
            this.btnCamChange.Text = "Selecionar Dispositivo";
            this.btnCamChange.UseVisualStyleBackColor = true;
            this.btnCamChange.Click += new System.EventHandler(this.btnCamChange_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmWebcam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 583);
            this.Controls.Add(this.gbVideoSource);
            this.Controls.Add(this.vspMainPlayer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWebcam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WebcamAforge - Image Analisys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWebcam_FormClosing);
            this.gbVideoSource.ResumeLayout(false);
            this.gbVideoSource.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer vspMainPlayer;
        private System.Windows.Forms.GroupBox gbVideoSource;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.TextBox txtCam;
        private System.Windows.Forms.Label lblCam;
        private System.Windows.Forms.Button btnCamChange;
        private System.Windows.Forms.Label lblFps;
        private System.Windows.Forms.Label lblFpsPrefix;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnScreenshot;
        private System.Windows.Forms.TextBox txtResolution;
    }
}

