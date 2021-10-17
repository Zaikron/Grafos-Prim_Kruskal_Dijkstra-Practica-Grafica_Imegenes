/*
 * Created by SharpDevelop.
 * User: AnthonySandoval
 * Date: 14/03/2021
 * Time: 01:42 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Actividad4_SemAlgoritmia
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
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
			this.imagen_PBox = new System.Windows.Forms.PictureBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_Analisis = new System.Windows.Forms.Button();
			this.cBox_Circulos = new System.Windows.Forms.ComboBox();
			this.btn_Burbuja = new System.Windows.Forms.Button();
			this.btn_Selection = new System.Windows.Forms.Button();
			this.btn_Insertion = new System.Windows.Forms.Button();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.brn_Imagen = new System.Windows.Forms.Button();
			this.btn_Closest = new System.Windows.Forms.Button();
			this.btn_Kruskal = new System.Windows.Forms.Button();
			this.btn_Prim = new System.Windows.Forms.Button();
			this.treeViewAdy = new System.Windows.Forms.TreeView();
			this.checkOrigen = new System.Windows.Forms.CheckBox();
			this.checkDestino = new System.Windows.Forms.CheckBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnDijkstra = new System.Windows.Forms.Button();
			this.btnAnimacion = new System.Windows.Forms.Button();
			this.checkBoxFast = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.imagen_PBox)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// imagen_PBox
			// 
			this.imagen_PBox.Location = new System.Drawing.Point(3, 3);
			this.imagen_PBox.Name = "imagen_PBox";
			this.imagen_PBox.Size = new System.Drawing.Size(391, 308);
			this.imagen_PBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imagen_PBox.TabIndex = 0;
			this.imagen_PBox.TabStop = false;
			this.imagen_PBox.DoubleClick += new System.EventHandler(this.PictureBox1DoubleClick);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.imagen_PBox);
			this.panel1.Location = new System.Drawing.Point(208, 39);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(401, 318);
			this.panel1.TabIndex = 1;
			// 
			// btn_Analisis
			// 
			this.btn_Analisis.Location = new System.Drawing.Point(7, 10);
			this.btn_Analisis.Name = "btn_Analisis";
			this.btn_Analisis.Size = new System.Drawing.Size(92, 23);
			this.btn_Analisis.TabIndex = 3;
			this.btn_Analisis.Text = "Analisis";
			this.btn_Analisis.UseVisualStyleBackColor = true;
			this.btn_Analisis.Click += new System.EventHandler(this.Btn_AnalisisClick);
			// 
			// cBox_Circulos
			// 
			this.cBox_Circulos.FormattingEnabled = true;
			this.cBox_Circulos.Location = new System.Drawing.Point(208, 12);
			this.cBox_Circulos.Name = "cBox_Circulos";
			this.cBox_Circulos.Size = new System.Drawing.Size(452, 21);
			this.cBox_Circulos.TabIndex = 4;
			this.cBox_Circulos.Text = "Circulos";
			this.cBox_Circulos.SelectedIndexChanged += new System.EventHandler(this.CBox_CirculosSelectedIndexChanged);
			// 
			// btn_Burbuja
			// 
			this.btn_Burbuja.Location = new System.Drawing.Point(102, 39);
			this.btn_Burbuja.Name = "btn_Burbuja";
			this.btn_Burbuja.Size = new System.Drawing.Size(100, 23);
			this.btn_Burbuja.TabIndex = 5;
			this.btn_Burbuja.Text = "Bubble: Area";
			this.btn_Burbuja.UseVisualStyleBackColor = true;
			this.btn_Burbuja.Click += new System.EventHandler(this.Btn_BurbujaClick);
			// 
			// btn_Selection
			// 
			this.btn_Selection.Location = new System.Drawing.Point(7, 39);
			this.btn_Selection.Name = "btn_Selection";
			this.btn_Selection.Size = new System.Drawing.Size(92, 23);
			this.btn_Selection.TabIndex = 6;
			this.btn_Selection.Text = "Selection: Eje X";
			this.btn_Selection.UseVisualStyleBackColor = true;
			this.btn_Selection.Click += new System.EventHandler(this.Btn_SelectionClick);
			// 
			// btn_Insertion
			// 
			this.btn_Insertion.Location = new System.Drawing.Point(7, 68);
			this.btn_Insertion.Name = "btn_Insertion";
			this.btn_Insertion.Size = new System.Drawing.Size(92, 23);
			this.btn_Insertion.TabIndex = 7;
			this.btn_Insertion.Text = "Insertion: Eje Y";
			this.btn_Insertion.UseVisualStyleBackColor = true;
			this.btn_Insertion.Click += new System.EventHandler(this.Btn_InsertionClick);
			// 
			// trackBar1
			// 
			this.trackBar1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.trackBar1.LargeChange = 1;
			this.trackBar1.Location = new System.Drawing.Point(615, 39);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size(45, 313);
			this.trackBar1.TabIndex = 10;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
			// 
			// brn_Imagen
			// 
			this.brn_Imagen.Location = new System.Drawing.Point(102, 68);
			this.brn_Imagen.Name = "brn_Imagen";
			this.brn_Imagen.Size = new System.Drawing.Size(100, 23);
			this.brn_Imagen.TabIndex = 11;
			this.brn_Imagen.Text = "Seleccionar Imagen";
			this.brn_Imagen.UseVisualStyleBackColor = true;
			this.brn_Imagen.Click += new System.EventHandler(this.Brn_ImagenClick);
			// 
			// btn_Closest
			// 
			this.btn_Closest.Location = new System.Drawing.Point(102, 10);
			this.btn_Closest.Name = "btn_Closest";
			this.btn_Closest.Size = new System.Drawing.Size(100, 23);
			this.btn_Closest.TabIndex = 12;
			this.btn_Closest.Text = "Closest";
			this.btn_Closest.UseVisualStyleBackColor = true;
			this.btn_Closest.Click += new System.EventHandler(this.Btn_ClosestClick);
			// 
			// btn_Kruskal
			// 
			this.btn_Kruskal.Location = new System.Drawing.Point(6, 97);
			this.btn_Kruskal.Name = "btn_Kruskal";
			this.btn_Kruskal.Size = new System.Drawing.Size(93, 23);
			this.btn_Kruskal.TabIndex = 14;
			this.btn_Kruskal.Text = "Kruskal";
			this.btn_Kruskal.UseVisualStyleBackColor = true;
			this.btn_Kruskal.Click += new System.EventHandler(this.Btn_KruskalClick);
			// 
			// btn_Prim
			// 
			this.btn_Prim.Location = new System.Drawing.Point(102, 97);
			this.btn_Prim.Name = "btn_Prim";
			this.btn_Prim.Size = new System.Drawing.Size(100, 23);
			this.btn_Prim.TabIndex = 15;
			this.btn_Prim.Text = "Prim";
			this.btn_Prim.UseVisualStyleBackColor = true;
			this.btn_Prim.Click += new System.EventHandler(this.Btn_PrimClick);
			// 
			// treeViewAdy
			// 
			this.treeViewAdy.Location = new System.Drawing.Point(5, 126);
			this.treeViewAdy.Name = "treeViewAdy";
			this.treeViewAdy.Size = new System.Drawing.Size(197, 254);
			this.treeViewAdy.TabIndex = 16;
			// 
			// checkOrigen
			// 
			this.checkOrigen.Location = new System.Drawing.Point(208, 363);
			this.checkOrigen.Name = "checkOrigen";
			this.checkOrigen.Size = new System.Drawing.Size(57, 24);
			this.checkOrigen.TabIndex = 17;
			this.checkOrigen.Text = "Origen";
			this.checkOrigen.UseVisualStyleBackColor = true;
			this.checkOrigen.CheckedChanged += new System.EventHandler(this.CheckOrigenCheckedChanged);
			// 
			// checkDestino
			// 
			this.checkDestino.Location = new System.Drawing.Point(271, 362);
			this.checkDestino.Name = "checkDestino";
			this.checkDestino.Size = new System.Drawing.Size(66, 24);
			this.checkDestino.TabIndex = 18;
			this.checkDestino.Text = "Destino";
			this.checkDestino.UseVisualStyleBackColor = true;
			this.checkDestino.CheckedChanged += new System.EventHandler(this.CheckDestinoCheckedChanged);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(495, 362);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 19;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
			// 
			// btnDijkstra
			// 
			this.btnDijkstra.Location = new System.Drawing.Point(333, 362);
			this.btnDijkstra.Name = "btnDijkstra";
			this.btnDijkstra.Size = new System.Drawing.Size(75, 23);
			this.btnDijkstra.TabIndex = 20;
			this.btnDijkstra.Text = "Dijkstra";
			this.btnDijkstra.UseVisualStyleBackColor = true;
			this.btnDijkstra.Click += new System.EventHandler(this.BtnDijkstraClick);
			// 
			// btnAnimacion
			// 
			this.btnAnimacion.Location = new System.Drawing.Point(414, 362);
			this.btnAnimacion.Name = "btnAnimacion";
			this.btnAnimacion.Size = new System.Drawing.Size(75, 23);
			this.btnAnimacion.TabIndex = 21;
			this.btnAnimacion.Text = "Animacion";
			this.btnAnimacion.UseVisualStyleBackColor = true;
			this.btnAnimacion.Click += new System.EventHandler(this.BtnAnimacionClick);
			// 
			// checkBoxFast
			// 
			this.checkBoxFast.Location = new System.Drawing.Point(605, 363);
			this.checkBoxFast.Name = "checkBoxFast";
			this.checkBoxFast.Size = new System.Drawing.Size(55, 24);
			this.checkBoxFast.TabIndex = 22;
			this.checkBoxFast.Text = "Fast";
			this.checkBoxFast.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 392);
			this.Controls.Add(this.checkBoxFast);
			this.Controls.Add(this.btnAnimacion);
			this.Controls.Add(this.btnDijkstra);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.checkDestino);
			this.Controls.Add(this.checkOrigen);
			this.Controls.Add(this.treeViewAdy);
			this.Controls.Add(this.btn_Prim);
			this.Controls.Add(this.btn_Kruskal);
			this.Controls.Add(this.btn_Closest);
			this.Controls.Add(this.brn_Imagen);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.btn_Insertion);
			this.Controls.Add(this.btn_Selection);
			this.Controls.Add(this.btn_Burbuja);
			this.Controls.Add(this.cBox_Circulos);
			this.Controls.Add(this.btn_Analisis);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.Text = "Actividad4_SemAlgoritmia";
			((System.ComponentModel.ISupportInitialize)(this.imagen_PBox)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.CheckBox checkBoxFast;
		private System.Windows.Forms.Button btnAnimacion;
		private System.Windows.Forms.Button btnDijkstra;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.CheckBox checkDestino;
		private System.Windows.Forms.CheckBox checkOrigen;
		private System.Windows.Forms.TreeView treeViewAdy;
		private System.Windows.Forms.Button btn_Prim;
		private System.Windows.Forms.Button btn_Kruskal;
		private System.Windows.Forms.Button btn_Closest;
		private System.Windows.Forms.Button brn_Imagen;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Button btn_Insertion;
		private System.Windows.Forms.Button btn_Selection;
		private System.Windows.Forms.Button btn_Burbuja;
		private System.Windows.Forms.ComboBox cBox_Circulos;
		private System.Windows.Forms.Button btn_Analisis;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox imagen_PBox;
	}
}
