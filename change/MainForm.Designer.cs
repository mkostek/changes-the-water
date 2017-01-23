/*
 * SharpDevelop tarafından düzenlendi.
 * Kullanıcı: massi
 * Tarih: 25.10.2016
 * Zaman: 14:12
 * 
 * Bu şablonu değiştirmek için Araçlar | Seçenekler | Kodlama | Standart Başlıkları Düzenle 'yi kullanın.
 */
namespace change
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Timer timer1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.button1 = new System.Windows.Forms.Button();
			this.chartBirinciDerece = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.button2 = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.chartBirinciDerece)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.White;
			this.button1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(470, 142);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(160, 184);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Down);
			this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move);
			this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Up);
			// 
			// chartBirinciDerece
			// 
			chartArea1.Name = "ChartArea1";
			this.chartBirinciDerece.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chartBirinciDerece.Legends.Add(legend1);
			this.chartBirinciDerece.Location = new System.Drawing.Point(12, 13);
			this.chartBirinciDerece.Name = "chartBirinciDerece";
			this.chartBirinciDerece.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			series1.BorderWidth = 3;
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series1.Color = System.Drawing.Color.Red;
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			series2.BorderWidth = 3;
			series2.ChartArea = "ChartArea1";
			series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			series2.Color = System.Drawing.Color.DarkBlue;
			series2.Legend = "Legend1";
			series2.Name = "Series2";
			this.chartBirinciDerece.Series.Add(series1);
			this.chartBirinciDerece.Series.Add(series2);
			this.chartBirinciDerece.Size = new System.Drawing.Size(357, 313);
			this.chartBirinciDerece.TabIndex = 0;
			this.chartBirinciDerece.Text = "chart1";
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.SystemColors.MenuHighlight;
			this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.button2.Location = new System.Drawing.Point(728, 207);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(71, 92);
			this.button2.TabIndex = 1;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Down);
			this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move);
			this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Up);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
			// 
			// comboBox1
			// 
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
									"katı",
									"sıvı",
									"gaz"});
			this.comboBox1.Location = new System.Drawing.Point(465, 40);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 22);
			this.comboBox1.TabIndex = 2;
			// 
			// comboBox2
			// 
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
									"beyaz",
									"mavi"});
			this.comboBox2.Location = new System.Drawing.Point(465, 9);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(121, 22);
			this.comboBox2.TabIndex = 3;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(465, 82);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 4;
			this.textBox1.Leave += new System.EventHandler(this.TextBox1Leave);
			this.textBox1.MouseLeave += new System.EventHandler(this.TextBox1MouseLeave);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(385, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 32);
			this.label1.TabIndex = 6;
			this.label1.Text = "fiziksel hal";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(385, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 25);
			this.label3.TabIndex = 8;
			this.label3.Text = "sıcaklık";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(386, 9);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 25);
			this.label5.TabIndex = 10;
			this.label5.Text = "renk";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(961, 430);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chartBirinciDerece);
			this.Name = "MainForm";
			this.Text = "change";
			this.Load += new System.EventHandler(this.MainFormLoad);
			((System.ComponentModel.ISupportInitialize)(this.chartBirinciDerece)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}private System.Windows.Forms.DataVisualization.Charting.Chart chartBirinciDerece;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.ComboBox comboBox1;
	}
	
}
