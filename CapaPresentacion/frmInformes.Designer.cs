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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartAreaDia = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legendDia = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series seriesDia = new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartAreaMes = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legendMes = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series seriesMes = new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartAreaAnio = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legendAnio = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series seriesAnio = new System.Windows.Forms.DataVisualization.Charting.Series();

            System.Windows.Forms.DataVisualization.Charting.ChartArea chartAreaTopProductos = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legendTopProductos = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series seriesTopProductos = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.scrollablePanel = new System.Windows.Forms.Panel();
            this.chartDia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartMes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartAnio = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTopProductos = new System.Windows.Forms.DataVisualization.Charting.Chart();

            // 
            // scrollablePanel
            // 
            this.scrollablePanel.AutoScroll = true;
            this.scrollablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollablePanel.Controls.Add(this.chartDia);
            this.scrollablePanel.Controls.Add(this.chartMes);
            this.scrollablePanel.Controls.Add(this.chartAnio);
            this.scrollablePanel.Controls.Add(this.chartTopProductos);
            this.Controls.Add(this.scrollablePanel);

            // 
            // chartDia
            // 
            chartAreaDia.Name = "ChartAreaDia";
            this.chartDia.ChartAreas.Add(chartAreaDia);
            legendDia.Name = "LegendDia";
            this.chartDia.Legends.Add(legendDia);
            this.chartDia.Location = new System.Drawing.Point(30, 30);
            this.chartDia.Name = "chartDia";
            seriesDia.ChartArea = "ChartAreaDia";
            seriesDia.Legend = "LegendDia";
            seriesDia.Name = "SeriesDia";
            seriesDia.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.chartDia.Series.Add(seriesDia);
            this.chartDia.Size = new System.Drawing.Size(250, 250);
            this.chartDia.TabIndex = 0;
            this.chartDia.Text = "chartDia";

            // 
            // chartMes
            // 
            chartAreaMes.Name = "ChartAreaMes";
            this.chartMes.ChartAreas.Add(chartAreaMes);
            legendMes.Name = "LegendMes";
            this.chartMes.Legends.Add(legendMes);
            this.chartMes.Location = new System.Drawing.Point(300, 30);
            this.chartMes.Name = "chartMes";
            seriesMes.ChartArea = "ChartAreaMes";
            seriesMes.Legend = "LegendMes";
            seriesMes.Name = "SeriesMes";
            seriesMes.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            this.chartMes.Series.Add(seriesMes);
            this.chartMes.Size = new System.Drawing.Size(250, 250);
            this.chartMes.TabIndex = 1;
            this.chartMes.Text = "chartMes";

            // 
            // chartAnio
            // 
            chartAreaAnio.Name = "ChartAreaAnio";
            this.chartAnio.ChartAreas.Add(chartAreaAnio);
            legendAnio.Name = "LegendAnio";
            this.chartAnio.Legends.Add(legendAnio);
            this.chartAnio.Location = new System.Drawing.Point(570, 30);
            this.chartAnio.Name = "chartAnio";
            seriesAnio.ChartArea = "ChartAreaAnio";
            seriesAnio.Legend = "LegendAnio";
            seriesAnio.Name = "SeriesAnio";
            seriesAnio.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            this.chartAnio.Series.Add(seriesAnio);
            this.chartAnio.Size = new System.Drawing.Size(250, 250);
            this.chartAnio.TabIndex = 2;
            this.chartAnio.Text = "chartAnio";

            // 
            // chartTopProductos
            // 
            chartAreaTopProductos.Name = "ChartAreaTopProductos";
            this.chartTopProductos.ChartAreas.Add(chartAreaTopProductos);
            legendTopProductos.Name = "LegendTopProductos";
            this.chartTopProductos.Legends.Add(legendTopProductos);
            this.chartTopProductos.Location = new System.Drawing.Point(30, 320);
            this.chartTopProductos.Name = "chartTopProductos";
            seriesTopProductos.ChartArea = "ChartAreaTopProductos";
            seriesTopProductos.Legend = "LegendTopProductos";
            seriesTopProductos.Name = "SeriesTopProductos";
            seriesTopProductos.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            this.chartTopProductos.Series.Add(seriesTopProductos);
            this.chartTopProductos.Size = new System.Drawing.Size(790, 250);
            this.chartTopProductos.TabIndex = 3;
            this.chartTopProductos.Text = "chartTopProductos";

            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 650);
            this.Controls.Add(this.scrollablePanel);
            this.Name = "frmInformes";
            this.Text = "Informe de Ventas y Compras";
            ((System.ComponentModel.ISupportInitialize)(this.chartDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProductos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
