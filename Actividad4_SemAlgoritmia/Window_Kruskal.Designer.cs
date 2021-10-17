/*
 * Created by SharpDevelop.
 * User: AnthonySandoval
 * Date: 30/05/2021
 * Time: 11:44 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Actividad4_SemAlgoritmia
{
	partial class Window_Kruskal
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
			this.pBox_Kruskal = new System.Windows.Forms.PictureBox();
			this.treeViewAdy = new System.Windows.Forms.TreeView();
			this.treeViewGrafo = new System.Windows.Forms.TreeView();
			this.peso = new System.Windows.Forms.Label();
			this.textBoxK = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pBox_Kruskal)).BeginInit();
			this.SuspendLayout();
			// 
			// pBox_Kruskal
			// 
			this.pBox_Kruskal.Location = new System.Drawing.Point(12, 12);
			this.pBox_Kruskal.Name = "pBox_Kruskal";
			this.pBox_Kruskal.Size = new System.Drawing.Size(403, 320);
			this.pBox_Kruskal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pBox_Kruskal.TabIndex = 0;
			this.pBox_Kruskal.TabStop = false;
			// 
			// treeViewAdy
			// 
			this.treeViewAdy.Location = new System.Drawing.Point(422, 182);
			this.treeViewAdy.Name = "treeViewAdy";
			this.treeViewAdy.Size = new System.Drawing.Size(189, 150);
			this.treeViewAdy.TabIndex = 5;
			// 
			// treeViewGrafo
			// 
			this.treeViewGrafo.Location = new System.Drawing.Point(421, 12);
			this.treeViewGrafo.Name = "treeViewGrafo";
			this.treeViewGrafo.Size = new System.Drawing.Size(191, 163);
			this.treeViewGrafo.TabIndex = 4;
			// 
			// peso
			// 
			this.peso.Location = new System.Drawing.Point(12, 336);
			this.peso.Name = "peso";
			this.peso.Size = new System.Drawing.Size(180, 23);
			this.peso.TabIndex = 6;
			this.peso.Text = "label1";
			// 
			// textBoxK
			// 
			this.textBoxK.Location = new System.Drawing.Point(12, 352);
			this.textBoxK.Multiline = true;
			this.textBoxK.Name = "textBoxK";
			this.textBoxK.Size = new System.Drawing.Size(600, 37);
			this.textBoxK.TabIndex = 7;
			// 
			// Window_Kruskal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 401);
			this.Controls.Add(this.textBoxK);
			this.Controls.Add(this.peso);
			this.Controls.Add(this.treeViewAdy);
			this.Controls.Add(this.treeViewGrafo);
			this.Controls.Add(this.pBox_Kruskal);
			this.Name = "Window_Kruskal";
			this.Text = "Window_Kruskal";
			((System.ComponentModel.ISupportInitialize)(this.pBox_Kruskal)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox textBoxK;
		private System.Windows.Forms.Label peso;
		private System.Windows.Forms.TreeView treeViewGrafo;
		private System.Windows.Forms.TreeView treeViewAdy;
		private System.Windows.Forms.PictureBox pBox_Kruskal;
	}
}
