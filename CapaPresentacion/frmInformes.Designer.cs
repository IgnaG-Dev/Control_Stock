namespace CapaPresentacion
{
    partial class frmInformes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMes;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartAnio;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProductos;
        private System.Windows.Forms.Panel scrollablePanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.scrollablePanel = new System.Windows.Forms.Panel();
            this.chartDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.scrollablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Controls.Add(this.chartDia);
            this.scrollablePanel.Controls.Add(this.chartMes);
            this.scrollablePanel.Controls.Add(this.chartAnio);
            this.scrollablePanel.Controls.Add(this.chartTopProductos);
            this.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollablePanel.Location = new System.Drawing.Point(0, 0);
            this.scrollablePanel.Name = "scrollablePanel";
            this.scrollablePanel.Size = new System.Drawing.Size(850, 650);
            this.scrollablePanel.TabIndex = 0;
            // 
            // chartDia
            // 
            chartArea1.Name = "ChartAreaDia";
            this.chartDia.ChartAreas.Add(chartArea1);
            legend1.Name = "LegendDia";
            this.chartDia.Legends.Add(legend1);
            this.chartDia.Location = new System.Drawing.Point(30, 30);
            this.chartDia.Name = "chartDia";
            series1.ChartArea = "ChartAreaDia";
            series1.Legend = "LegendDia";
            series1.Name = "SeriesDia";
            this.chartDia.Series.Add(series1);
            this.chartDia.Size = new System.Drawing.Size(250, 250);
            this.chartDia.TabIndex = 0;
            this.chartDia.Text = "chartDia";
            // 
            // chartMes
            // 
            chartArea2.Name = "ChartAreaMes";
            this.chartMes.ChartAreas.Add(chartArea2);
            legend2.Name = "LegendMes";
            this.chartMes.Legends.Add(legend2);
            this.chartMes.Location = new System.Drawing.Point(300, 30);
            this.chartMes.Name = "chartMes";
            series2.ChartArea = "ChartAreaMes";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series2.Legend = "LegendMes";
            series2.Name = "SeriesMes";
            this.chartMes.Series.Add(series2);
            this.chartMes.Size = new System.Drawing.Size(250, 250);
            this.chartMes.TabIndex = 1;
            this.chartMes.Text = "chartMes";
            // 
            // chartAnio
            // 
            chartArea3.Name = "ChartAreaAnio";
            this.chartAnio.ChartAreas.Add(chartArea3);
            legend3.Name = "LegendAnio";
            this.chartAnio.Legends.Add(legend3);
            this.chartAnio.Location = new System.Drawing.Point(570, 30);
            this.chartAnio.Name = "chartAnio";
            series3.ChartArea = "ChartAreaAnio";
            series3.Legend = "LegendAnio";
            series3.Name = "SeriesAnio";
            this.chartAnio.Series.Add(series3);
            this.chartAnio.Size = new System.Drawing.Size(250, 250);
            this.chartAnio.TabIndex = 2;
            this.chartAnio.Text = "chartAnio";
            // 
            // chartTopProductos
            // 
            chartArea4.Name = "ChartAreaTopProductos";
            this.chartTopProductos.ChartAreas.Add(chartArea4);
            legend4.Name = "LegendTopProductos";
            this.chartTopProductos.Legends.Add(legend4);
            this.chartTopProductos.Location = new System.Drawing.Point(30, 320);
            this.chartTopProductos.Name = "chartTopProductos";
            series4.ChartArea = "ChartAreaTopProductos";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series4.Legend = "LegendTopProductos";
            series4.Name = "SeriesTopProductos";
            this.chartTopProductos.Series.Add(series4);
            this.chartTopProductos.Size = new System.Drawing.Size(790, 250);
            this.chartTopProductos.TabIndex = 3;
            this.chartTopProductos.Text = "chartTopProductos";
            this.chartTopProductos.Click += new System.EventHandler(this.chartTopProductos_Click);
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Controls.Add(this.scrollablePanel);
            this.Name = "frmInformes";
            this.Text = "Informe de Ventas y Compras";
            this.scrollablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
