/*
 * Created by SharpDevelop.
 * User: AnthonySandoval
 * Date: 30/05/2021
 * Time: 11:45 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace Actividad4_SemAlgoritmia
{

	public partial class Window_Prim : Form
	{
		Bitmap bmp_Kruskal_Prim;
		List<Circulo> circulos;
		Grafo grafoKruskal = new Grafo();
		
		public Window_Prim()
		{
			InitializeComponent();
			grafoKruskal.inicializar();
			textBoxK.Multiline = true;
			textBoxK.WordWrap = false;
			textBoxK.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
		}
		
		public void showInfo(List<List<Circulo>> subarboles, double pesoT){
			grafoKruskal.listaAdyacenciaTreeView(treeViewAdy);
			
			treeViewGrafo.BeginUpdate();
			for(int i = 0; i < subarboles.Count; i++){
				treeViewGrafo.Nodes.Add("Elementos del arbol " + (i+1));
				for(int j = 0; j < subarboles[i].Count; j++){
					treeViewGrafo.Nodes[i].Nodes.Add(subarboles[i][j].getId().ToString());
				}
				treeViewGrafo.Nodes[i].Expand();
			}
			treeViewGrafo.EndUpdate();
			peso.Text = "Peso total: " + (float)pesoT;
		}
		
		public void showGraph(string c1, List<Circulo> circulos, List<Aristas> prometedores){
			
			this.circulos = circulos;
		    
		    //Para mostrar el grafo
		    bmp_Kruskal_Prim = new Bitmap(c1);
			pBox_Prim.Image = bmp_Kruskal_Prim;
			etiquetasCirculos(70, 50, bmp_Kruskal_Prim, 30);
		    
		    //Cargo todos los circulos que hay
		    for(int i = 0; i < circulos.Count; i++){
		    	grafoKruskal.insertarVertice(circulos[i]);
		    }
		    //Cargo las conexiones, aristas respecto a krusgal
		    for(int j = 0; j < prometedores.Count; j++){
		 		
		    	//Ingreso dos veces la aristas en sentidos diferentes para que siga siendo un grafo no dirigido
		    	grafoKruskal.insertarArista(grafoKruskal.getVertice(prometedores[j].origen), 
		    	                            grafoKruskal.getVertice(prometedores[j].destino),
		    	                            calculeDistance(prometedores[j].origen, prometedores[j].destino));
		    	
		    	grafoKruskal.insertarArista(grafoKruskal.getVertice(prometedores[j].destino), 
		    	                            grafoKruskal.getVertice(prometedores[j].origen),
		    	                            calculeDistance(prometedores[j].destino, prometedores[j].origen));
		    	//Coloreado de las lineas
		    	drawLine(bmp_Kruskal_Prim, prometedores[j].origen.getCentroX(),
                                      prometedores[j].origen.getCentroY(), 
                                      prometedores[j].destino.getCentroX(),
                                      prometedores[j].destino.getCentroY()
                                     );
			}
		    
		    for(int i = 0; i < prometedores.Count; i++){
		    	textBoxK.Text += "(" + prometedores[i].origen.getId() + ") <" +
		    	                (float)prometedores[i].arista + "> ("
		    	                + prometedores[i].destino.getId() + ")  -->  ";
		    }
		}
		
		void etiquetasCirculos(int width, int heigth, Bitmap bmp, int tamLetra){
			for(int i = 0; i < circulos.Count; i++){
				ponerEtiqueta(circulos[i].getCentroX()-18, (circulos[i].getCentroY() +  Convert.ToInt32(circulos[i].getRadio())), width, heigth, bmp, circulos[i].getId(), tamLetra);
			}
		}
		
		
		void ponerEtiqueta(int x, int y, int width, int height, Bitmap bmp, int id, int tamLetra){
			RectangleF rectf = new RectangleF(x, y, width, height);

			Graphics g = Graphics.FromImage(bmp);	
			
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
			g.DrawString(id.ToString(), new Font("Tahoma", tamLetra), Brushes.Purple, rectf);
			
			g.Flush();
		}
		
		//Se dibuja una linea entre dos puntos
		void drawLine(Bitmap bmp, int x1, int y1, int x2, int y2){
			Graphics g = Graphics.FromImage(bmp);
			Pen p = new Pen(Color.Purple, 4);
			
			g.DrawLine(p, x1-1, y1-1, x2+1, y2+1);
		}
		
		
		double calculeDistance(Circulo origen, Circulo destino){
			return Math.Sqrt(Math.Pow(origen.getCentroX() - destino.getCentroX(), 2)
					         + Math.Pow(origen.getCentroY() - destino.getCentroY(), 2));
		}
		
	}
}
