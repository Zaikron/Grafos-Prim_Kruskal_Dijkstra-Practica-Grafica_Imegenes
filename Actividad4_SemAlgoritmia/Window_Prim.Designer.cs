/*
 * Created by SharpDevelop.
 * User: AnthonySandoval
 * Date: 30/05/2021
 * Time: 11:45 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Actividad4_SemAlgoritmia
{
	partial class Window_Prim
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
			this.pBox_Prim = new System.Windows.Forms.PictureBox();
			this.treeViewGrafo = new System.Windows.Forms.TreeView();
			this.treeViewAdy = new System.Windows.Forms.TreeView();
			this.peso = new System.Windows.Forms.Label();
			this.textBoxK = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pBox_Prim)).BeginInit();
			this.SuspendLayout();
			// 
			// pBox_Prim
			// 
			this.pBox_Prim.Location = new System.Drawing.Point(12, 12);
			this.pBox_Prim.Name = "pBox_Prim";
			this.pBox_Prim.Size = new System.Drawing.Size(403, 320);
			this.pBox_Prim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pBox_Prim.TabIndex = 0;
			this.pBox_Prim.TabStop = false;
			// 
			// treeViewGrafo
			// 
			this.treeViewGrafo.Location = new System.Drawing.Point(421, 12);
			this.treeViewGrafo.Name = "treeViewGrafo";
			this.treeViewGrafo.Size = new System.Drawing.Size(191, 163);
			this.treeViewGrafo.TabIndex = 1;
			// 
			// treeViewAdy
			// 
			this.treeViewAdy.Location = new System.Drawing.Point(422, 182);
			this.treeViewAdy.Name = "treeViewAdy";
			this.treeViewAdy.Size = new System.Drawing.Size(189, 150);
			this.treeViewAdy.TabIndex = 3;
			// 
			// peso
			// 
			this.peso.Location = new System.Drawing.Point(12, 335);
			this.peso.Name = "peso";
			this.peso.Size = new System.Drawing.Size(152, 23);
			this.peso.TabIndex = 4;
			this.peso.Text = "label1";
			// 
			// textBoxK
			// 
			this.textBoxK.Location = new System.Drawing.Point(11, 350);
			this.textBoxK.Multiline = true;
			this.textBoxK.Name = "textBoxK";
			this.textBoxK.Size = new System.Drawing.Size(600, 37);
			this.textBoxK.TabIndex = 8;
			// 
			// Window_Prim
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(624, 399);
			this.Controls.Add(this.textBoxK);
			this.Controls.Add(this.peso);
			this.Controls.Add(this.treeViewAdy);
			this.Controls.Add(this.treeViewGrafo);
			this.Controls.Add(this.pBox_Prim);
			this.Name = "Window_Prim";
			this.Text = "Window_Prim";
			((System.ComponentModel.ISupportInitialize)(this.pBox_Prim)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox textBoxK;
		private System.Windows.Forms.Label peso;
		private System.Windows.Forms.TreeView treeViewAdy;
		private System.Windows.Forms.TreeView treeViewGrafo;
		private System.Windows.Forms.PictureBox pBox_Prim;
	}
}
