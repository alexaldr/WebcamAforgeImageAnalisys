﻿namespace WebcamAforgeImageAnalisys
{
    partial class FrmScreenshot
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmScreenshot));
            this.pbScreenshot = new System.Windows.Forms.PictureBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLocalSaveImage = new System.Windows.Forms.RadioButton();
            this.rbMicrosoftAnalisys = new System.Windows.Forms.RadioButton();
            this.rbGoogleAnalisys = new System.Windows.Forms.RadioButton();
            this.pbSelectedOption = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtInformation = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedOption)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScreenshot
            // 
            this.pbScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScreenshot.Location = new System.Drawing.Point(16, 15);
            this.pbScreenshot.Margin = new System.Windows.Forms.Padding(4);
            this.pbScreenshot.Name = "pbScreenshot";
            this.pbScreenshot.Size = new System.Drawing.Size(853, 443);
            this.pbScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScreenshot.TabIndex = 0;
            this.pbScreenshot.TabStop = false;
            // 
            // btnExecute
            // 
            this.btnExecute.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExecute.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecute.Location = new System.Drawing.Point(722, 467);
            this.btnExecute.Margin = new System.Windows.Forms.Padding(4);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(147, 35);
            this.btnExecute.TabIndex = 1;
            this.btnExecute.Text = "Executar";
            this.btnExecute.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLocalSaveImage);
            this.groupBox1.Controls.Add(this.rbMicrosoftAnalisys);
            this.groupBox1.Controls.Add(this.rbGoogleAnalisys);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(17, 466);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(232, 115);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Opções de Captura";
            // 
            // rbLocalSaveImage
            // 
            this.rbLocalSaveImage.AutoSize = true;
            this.rbLocalSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLocalSaveImage.Location = new System.Drawing.Point(9, 83);
            this.rbLocalSaveImage.Margin = new System.Windows.Forms.Padding(4);
            this.rbLocalSaveImage.Name = "rbLocalSaveImage";
            this.rbLocalSaveImage.Size = new System.Drawing.Size(187, 21);
            this.rbLocalSaveImage.TabIndex = 2;
            this.rbLocalSaveImage.TabStop = true;
            this.rbLocalSaveImage.Text = "Salvar imagem capturada";
            this.rbLocalSaveImage.UseVisualStyleBackColor = true;
            this.rbLocalSaveImage.CheckedChanged += new System.EventHandler(this.rbLocalSaveImage_CheckedChanged);
            // 
            // rbMicrosoftAnalisys
            // 
            this.rbMicrosoftAnalisys.AutoSize = true;
            this.rbMicrosoftAnalisys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMicrosoftAnalisys.Location = new System.Drawing.Point(8, 54);
            this.rbMicrosoftAnalisys.Margin = new System.Windows.Forms.Padding(4);
            this.rbMicrosoftAnalisys.Name = "rbMicrosoftAnalisys";
            this.rbMicrosoftAnalisys.Size = new System.Drawing.Size(222, 21);
            this.rbMicrosoftAnalisys.TabIndex = 1;
            this.rbMicrosoftAnalisys.TabStop = true;
            this.rbMicrosoftAnalisys.Text = "Analisar imagem pela Microsoft";
            this.rbMicrosoftAnalisys.UseVisualStyleBackColor = true;
            this.rbMicrosoftAnalisys.CheckedChanged += new System.EventHandler(this.rbMicrosoftAnalisys_CheckedChanged);
            // 
            // rbGoogleAnalisys
            // 
            this.rbGoogleAnalisys.AutoSize = true;
            this.rbGoogleAnalisys.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbGoogleAnalisys.Location = new System.Drawing.Point(9, 25);
            this.rbGoogleAnalisys.Margin = new System.Windows.Forms.Padding(4);
            this.rbGoogleAnalisys.Name = "rbGoogleAnalisys";
            this.rbGoogleAnalisys.Size = new System.Drawing.Size(211, 21);
            this.rbGoogleAnalisys.TabIndex = 0;
            this.rbGoogleAnalisys.TabStop = true;
            this.rbGoogleAnalisys.Text = "Analisar imagem pelo Google";
            this.rbGoogleAnalisys.UseVisualStyleBackColor = true;
            this.rbGoogleAnalisys.CheckedChanged += new System.EventHandler(this.rbGoogleAnalisys_CheckedChanged);
            // 
            // pbSelectedOption
            // 
            this.pbSelectedOption.Location = new System.Drawing.Point(256, 467);
            this.pbSelectedOption.Name = "pbSelectedOption";
            this.pbSelectedOption.Size = new System.Drawing.Size(115, 115);
            this.pbSelectedOption.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSelectedOption.TabIndex = 3;
            this.pbSelectedOption.TabStop = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(722, 506);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Voltar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(722, 546);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(147, 35);
            this.button2.TabIndex = 5;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtInformation
            // 
            this.txtInformation.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtInformation.Location = new System.Drawing.Point(377, 467);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.ReadOnly = true;
            this.txtInformation.Size = new System.Drawing.Size(338, 115);
            this.txtInformation.TabIndex = 6;
            // 
            // FrmScreenshot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 594);
            this.Controls.Add(this.txtInformation);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pbSelectedOption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.pbScreenshot);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmScreenshot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webcam Aforge - Image Analisys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmScreenshot_FormClosing);
            this.Load += new System.EventHandler(this.FrmScreenshot_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelectedOption)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScreenshot;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbLocalSaveImage;
        private System.Windows.Forms.RadioButton rbMicrosoftAnalisys;
        private System.Windows.Forms.RadioButton rbGoogleAnalisys;
        private System.Windows.Forms.PictureBox pbSelectedOption;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtInformation;
    }
}