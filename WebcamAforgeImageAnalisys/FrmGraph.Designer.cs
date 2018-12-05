namespace WebcamAforgeImageAnalisys
{
    partial class FrmGraph
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGraph));
            this.tabGraph = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblDetails = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pbFace = new System.Windows.Forms.PictureBox();
            this.tabGraph.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).BeginInit();
            this.SuspendLayout();
            // 
            // tabGraph
            // 
            this.tabGraph.Controls.Add(this.tabPage1);
            this.tabGraph.Location = new System.Drawing.Point(12, 12);
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.SelectedIndex = 0;
            this.tabGraph.Size = new System.Drawing.Size(1178, 619);
            this.tabGraph.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblDetails);
            this.tabPage1.Controls.Add(this.chart1);
            this.tabPage1.Controls.Add(this.pbFace);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1170, 593);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gráfico";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(3, 429);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(51, 20);
            this.lblDetails.TabIndex = 4;
            this.lblDetails.Text = "label1";
            // 
            // chart1
            // 
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(359, 3);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(808, 587);
            this.chart1.TabIndex = 3;
            // 
            // pbFace
            // 
            this.pbFace.Location = new System.Drawing.Point(3, 3);
            this.pbFace.Name = "pbFace";
            this.pbFace.Size = new System.Drawing.Size(350, 423);
            this.pbFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFace.TabIndex = 2;
            this.pbFace.TabStop = false;
            // 
            // FrmGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 643);
            this.Controls.Add(this.tabGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGraph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Probabilidades: Expressão Facial (Emoção)";
            this.Load += new System.EventHandler(this.FrmGraph_Load);
            this.tabGraph.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFace)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGraph;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pbFace;
    }
}