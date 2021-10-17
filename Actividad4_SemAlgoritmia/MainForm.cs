
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;

namespace Actividad4_SemAlgoritmia
	
{
	public partial class MainForm : Form
	{
		
		string c1 = "..\\..\\Imagenes\\ent 1.png";
		Circulo circulo;
		Color colorear = Color.Salmon;
		List<Circulo> circulos = new List<Circulo>();
		Bitmap bmpGlobal;
		Bitmap bmpAnimacion;
		int identificador;
		Grafo grafo;
		int actualCicleIndex = 0;
		int indiceOrigen = -1;
		int indiceDestino = -1;
		
		Window_Kruskal wk = new Window_Kruskal();
		Window_Prim wp = new Window_Prim();
		List<List<Circulo>> subarbolesPrim = new List<List<Circulo>>();
		List<List<Circulo>> subarbolesKuskal = new List<List<Circulo>>();
		List<VerticeDijkstra> caminosAnimacion = new List<VerticeDijkstra>();
		
		//Para el zoom de la imagen
		int tamHeight;
		int tamWidth;
		int top;
		int left;
		
		public MainForm()
		{
			InitializeComponent();
			imagen_PBox.ImageLocation = c1;
			panel1.AutoScroll = true;
			
			//Para el zoom de la imagen
			tamHeight = imagen_PBox.Height;
			tamWidth = imagen_PBox.Width;
			top = imagen_PBox.Top;
			left = imagen_PBox.Left;
			
			grafo = new Grafo();
			grafo.inicializar();
			
			
			stateButtons(false);
			btnAnimacion.Enabled = false;
			btnDijkstra.Enabled = false;
			
		}
		
		void stateButtons(bool state){
			btn_Burbuja.Enabled = state;
			btn_Closest.Enabled = state;
			btn_Insertion.Enabled = state;
			btn_Selection.Enabled = state;
			btn_Prim.Enabled = state;
			btn_Kruskal.Enabled = state;
		}
		
		void PictureBox1DoubleClick(object sender, EventArgs e)
		{
			seleccionarImagen();
		}
		
		void Btn_AnalisisClick(object sender, EventArgs e)
		{
			identificador = 1;
			circulos.Clear();
			cBox_Circulos.Items.Clear();
			grafo.anular();
			grafo = new Grafo();
			
			buscarCirculos(0, 0);
			cargarComboBox();
			grafo.listaAdyacenciaTreeView(treeViewAdy);
			imagen_PBox.BackgroundImage = bmpGlobal;
			imagen_PBox.BackgroundImageLayout = ImageLayout.Zoom;
			
			stateButtons(true);
		}
		
		bool isBlack(Color c){
			if(c.R <= 10){
					if(c.G <= 10){
						if(c.B <= 10){
							return true;
						}
					}
				}
			return false;
		}
		
		
		bool isWhite(Color c){
			if(c.R >= 250){
					if(c.G >= 250){
						if(c.B >= 250){
							return true;
						}
					}
				}
			return false;
		}
		
		bool isBrown(Color c){
			if(c.R == 165){
					if(c.G == 42){
						if(c.B == 42){
							return true;
						}
					}
				}
			return false;
		}
		
		//Color para las lineas que conectan los circulos
		bool isRed(Color c){
			if(c.R == 255){
					if(c.G == 0){
						if(c.B == 0){
							return true;
						}
					}
				}
			return false;
		}
		
		
		
		void buscarCirculos(int comienzoX, int comienzoY){
			
			//Bitmap bmp = new Bitmap(c1);
			bmpGlobal = new Bitmap(c1);
			imagen_PBox.Image = bmpGlobal;
			Color colorActual;
			int x, y;
			
			Debug.WriteLine("\nBuscando Circulos...");
			for(y = comienzoY; y < bmpGlobal.Height; y++){
				for(x = comienzoX; x < bmpGlobal.Width; x++){
					colorActual  = bmpGlobal.GetPixel(x, y);
					if(isBlack(colorActual)){
						buscarCentro(x, y, bmpGlobal);
					}
				}
			}
			bmpGlobal = new Bitmap(c1);
			drawLines(bmpGlobal);
			etiquetasCirculos(70, 50, bmpGlobal, 20);
			imagen_PBox.Image = bmpGlobal;
			//bmpGlobal = bmp;
			Debug.WriteLine("\nSe a completado el analisis de la imagen.");
		}
		
		
		void buscarCentro(int X, int Y, Bitmap bmp){
			
			int norteY=0, surY=0;
			int oesteX=0, esteX=0;
			int centroX=0, centroY=0;
			
			Color colorActual;
			
			surY = Y;
			colorActual = bmp.GetPixel(X, surY);
			while (isBlack(colorActual)) {
				colorActual  = bmp.GetPixel(X, surY);
				surY++;				
			}
			surY-=1;
			norteY = Y;
			norteY--;
			colorActual  = bmp.GetPixel(X, norteY);
			while (isBlack(colorActual)) {
				colorActual  = bmp.GetPixel(X, norteY);
				norteY--;			
			}
			norteY+=1;
			centroY = norteY + ((surY - norteY)/2);
			
			esteX = X;
			colorActual  = bmp.GetPixel(esteX, centroY);
			while(isBlack(colorActual)){
				colorActual  = bmp.GetPixel(esteX, centroY);
				esteX++;
			}
			esteX-=1;
			oesteX = X;
			oesteX--;
			colorActual  = bmp.GetPixel(oesteX, centroY);
			while(isBlack(colorActual)){
				colorActual  = bmp.GetPixel(oesteX, centroY);
				oesteX--;
			}
			oesteX+=1;
			
			centroX = oesteX + ((esteX - oesteX)/2);
			
			circulo = new Circulo(centroX, centroY, oesteX, esteX, identificador);
			identificador++;
			circulos.Add(circulo);
				
			dibujarCirculo(circulo);
			//colorearRespecto_X(circulo.getIniX(), circulo.getCentroY(), bmp);
			
		}
		
		
		void dibujarCirculo(Circulo c){
			float r = c.getRadio() + 5;
			int x = c.getCentroX();
			int y = c.getCentroY();

			Brush brush = new SolidBrush(colorear);
			Graphics g = Graphics.FromImage(bmpGlobal);
			g.FillEllipse(brush, (int)(Math.Round(x-r)), (int)(Math.Round(y-r)), 2*r, 2*r);
			//imagen_PBox.Image = bmpGlobal;
		}
		
		

		void CBox_CirculosSelectedIndexChanged(object sender, EventArgs e)
		{
			
			actualCicleIndex = cBox_Circulos.SelectedIndex;

			if(checkOrigen.Checked == true){
				checkDestino.Checked = false;
				indiceOrigen = cBox_Circulos.SelectedIndex;
				dibujarOrigen();
			}
			if(checkDestino.Checked == true && indiceOrigen != -1){
				checkOrigen.Checked = false;
				checkDestino.Checked = false;
				indiceDestino = cBox_Circulos.SelectedIndex;
				btnDijkstra.Enabled = true;
				//Hacer animacion / aplicar dijkstra
				//animarParticula();
			}
			
			
		}
		
		void cargarComboBox(){
			for(int i = 0; i < circulos.Count; i++){
				cBox_Circulos.Items.Add("[ID: " + circulos[i].getId() + "] - [Centroide: X: " + circulos[i].getCentroX() + ", Y: " + circulos[i].getCentroY() + 
				                        "] - [Area: " + circulos[i].getArea() + "] - [Radio: " + circulos[i].getRadio() + "]");
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
			g.DrawString(id.ToString(), new Font("Tahoma", tamLetra), Brushes.Brown, rectf);
			
			g.Flush();
		}
		
		//Ordenamientos
		void Btn_BurbujaClick(object sender, EventArgs e)
		{
			Ordenamientos burbuja = new Ordenamientos();
			cBox_Circulos.Items.Clear();
			
			circulos = burbuja.bubbleSort_Area(circulos);
			cargarComboBox();
		}
		
		void Btn_SelectionClick(object sender, EventArgs e)
		{
			Ordenamientos burbuja = new Ordenamientos();
			cBox_Circulos.Items.Clear();
			
			circulos = burbuja.seleccionSort_EjeX(circulos);
			cargarComboBox();
		}
		
		void Btn_InsertionClick(object sender, EventArgs e)
		{
			Ordenamientos burbuja = new Ordenamientos();
			cBox_Circulos.Items.Clear();
			
			circulos = burbuja.insetionSort_EjeY(circulos);
			cargarComboBox();			
		}
		
		void Brn_ImagenClick(object sender, EventArgs e)
		{
			seleccionarImagen();
		}
		
		void seleccionarImagen(){
			
			OpenFileDialog opF = new OpenFileDialog();
			opF.Filter = "Bitmaps|*.png|jpeps|*.jpg";	
			
			if(opF.ShowDialog() == DialogResult.OK){
				imagen_PBox.BackgroundImage = null;
				imagen_PBox.Update();
				cBox_Circulos.Items.Clear();
				imagen_PBox.ImageLocation = opF.FileName;
				//imagen_PBox.Image = Bitmap.FromFile(opF.FileName);
				c1 = opF.FileName;
				stateButtons(false);
				btnAnimacion.Enabled = false;
				btnDijkstra.Enabled = false;
				cBox_Circulos.Items.Clear();
				
				treeViewAdy.BeginUpdate();
				treeViewAdy.Nodes.Clear();
				treeViewAdy.EndUpdate();
				
				actualCicleIndex = 0;
			}
		}
		
		
		//Par de puntos mas cercanos
		Point getClosestPairOfPoints(){
			
			Point closestPoints = new Point(0, 0);
			double distance;
			double disMin = Double.PositiveInfinity;
			
			for(int i = 0; i < circulos.Count; i++){
				for(int j = i + 1; j < circulos.Count; j++){
					distance = Math.Sqrt(Math.Pow(circulos[i].getCentroX() - circulos[j].getCentroX(), 2)
					                     + Math.Pow(circulos[i].getCentroY() - circulos[j].getCentroY(), 2));
					if(distance < disMin){
						disMin = distance;
						closestPoints = new Point(i, j);
					}
						
				}
			}
			
			return closestPoints;
			
		}
		
		//Boton para par de puntos mas cercanos
		void Btn_ClosestClick(object sender, EventArgs e)
		{
			Point p = getClosestPairOfPoints();
			bmpGlobal  = new Bitmap(c1);
			imagen_PBox.Image = bmpGlobal;
			
			dibujarCirculo(circulos[p.X]);
			dibujarCirculo(circulos[p.Y]);
			
			etiquetasCirculos(36, 50, bmpGlobal, 30);
			drawLines(bmpGlobal);
		}
		
		
		//Recorrido de todos los circulos para dibujar lineas
		void drawLines(Bitmap bmp){
			
			//Se llena el grafo con los circulos, se introducen los vertices
			grafo.anular();
			insertInGraph(grafo);
			
			for(int i = 0; i < circulos.Count; i++){
				for(int j = 0; j < circulos.Count; j++){
					/*drawLine(bmp, circulos[i].getCentroX(), circulos[i].getCentroY(), 
					         circulos[j].getCentroX(), circulos[j].getCentroY());*/
					
					if(circulos[i].getId() != circulos[j].getId()){
						
						if(!isColision(bmp, circulos[i], circulos[j])){
							
							drawLine(bmp, circulos[i].getCentroX(), circulos[i].getCentroY(), 
						         circulos[j].getCentroX(), circulos[j].getCentroY());
							
							//Se agregan las aristas
							grafo.insertarArista(grafo.getVertice(circulos[i]), grafo.getVertice(circulos[j])
							                     , calculeDistance(circulos[i], circulos[j]));
							
						}
					}

				}
			}
			//bmpClickS
		}
		
		//Se dibuja una linea entre dos puntos
		void drawLine(Bitmap bmp, int x1, int y1, int x2, int y2){
			Graphics g = Graphics.FromImage(bmp);
			Pen p = new Pen(Color.Red, 2);
			
			g.DrawLine(p, x1-1, y1-1, x2+1, y2+1);
		}
		
		//Insercion en el grafo
		void insertInGraph(Grafo grafo){
			
			for(int i = 0; i < circulos.Count; i++){
						
				//Insercion de vertice en el grafo
				grafo.insertarVertice(circulos[i]);
			}
			
		}
		
		
		double calculeDistance(Circulo origen, Circulo destino){
			return Math.Sqrt(Math.Pow(origen.getCentroX() - destino.getCentroX(), 2)
					         + Math.Pow(origen.getCentroY() - destino.getCentroY(), 2));
		}
		
		
		//Se comprueba si hay obstaculos entre dos puntos
		bool isColision(Bitmap bmp, Circulo origen, Circulo destino){
			
			//Algoritmo: Bresenham's Line Algorithm
			
			int x = origen.getCentroX();
			int y = origen.getCentroY();
			int x2 = destino.getCentroX();
			int y2 = destino.getCentroY();
			Color c;
			
			int w = x2 - x ;
		    int h = y2 - y ;
		    int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0 ;
		    
		    if (w<0) dx1 = -1 ; else if (w>0) dx1 = 1 ;
		    if (h<0) dy1 = -1 ; else if (h>0) dy1 = 1 ;
		    if (w<0) dx2 = -1 ; else if (w>0) dx2 = 1 ;
		    int longest = Math.Abs(w) ;
		    int shortest = Math.Abs(h) ;
		    if (!(longest>shortest)) {
		        longest = Math.Abs(h) ;
		        shortest = Math.Abs(w) ;
		        if (h<0) dy2 = -1 ; else if (h>0) dy2 = 1 ;
		        dx2 = 0 ;            
		    }
		    int numerator = longest >> 1 ;
		    for (int i=0;i<=longest;i++) {
		    	
		    	c = bmp.GetPixel(x, y);
		    	
		    	//Debug.WriteLine("i: "+ i + ", longest: "+ longest);
		    			    	
		    	if(i > origen.getRadio() && i < longest - (destino.getRadio())){

		    		if(!isWhite(c) && !isRed(c) && !isGray(c) && !isBrown(c)){
		    			//Debug.WriteLine("Origen: " + origen.getId() + ", Destino: " + destino.getId());
		    			//Debug.WriteLine("Color: " + c);
			    		return true;
			    	}		    		
		    	}
		    	
		    	
		        numerator += shortest ;
		        if (!(numerator<longest)) {
		            numerator -= longest ;
		            x += dx1 ;
		            y += dy1 ;
		        } else {
		            x += dx2 ;
		            y += dy2 ;
		        }
		    }
			/* Sitio de obtencion de del algoritmo:
			ahttps://stackoverflow.com/questions/11678693/all-cases-covered-bresenhams-line-algorithm*/
			return false;
			
		}
		
		
		bool isGray(Color c){
			if(isBlack(c)){
				return false;
			}
			if(c.R == c.B && c.R == c.G){
				return true;
			}
			return false;
		}
		
		
		
		
		//Zoom a imagen
		int valorAnterior = 0;
		float incrementadorTL = 0.05f;
		float incrementadorHW = 0.1f;
		
		
		void TrackBar1Scroll(object sender, EventArgs e)
		{
			
			if(isIncreased(trackBar1.Value) == 1){
				imagen_PBox.Top = (int)(imagen_PBox.Top + (imagen_PBox.Height * incrementadorTL));
				imagen_PBox.Left = (int)(imagen_PBox.Left + (imagen_PBox.Width * incrementadorTL));
				imagen_PBox.Height = (int)(imagen_PBox.Height + (imagen_PBox.Height* incrementadorHW));
				imagen_PBox.Width = (int)(imagen_PBox.Width + (imagen_PBox.Width * incrementadorHW));
			}else if(isIncreased(trackBar1.Value) == 0){
				imagen_PBox.Top = (int)(imagen_PBox.Top + (imagen_PBox.Height * incrementadorTL));
				imagen_PBox.Left = (int)(imagen_PBox.Left + (imagen_PBox.Width * incrementadorTL));
				imagen_PBox.Height = (int)(imagen_PBox.Height - (imagen_PBox.Height* incrementadorHW));
				imagen_PBox.Width = (int)(imagen_PBox.Width - (imagen_PBox.Width * incrementadorHW));
			}
			
			if(trackBar1.Value == 0){
				imagen_PBox.Top = top;
				imagen_PBox.Left = left;
				imagen_PBox.Height = tamHeight;
				imagen_PBox.Width = tamWidth;
			}
			
			valorAnterior = trackBar1.Value;
		}
		
		int isIncreased(int value){
			if(value > valorAnterior){
				return 1;
			}else if(value < valorAnterior){
				return 0;
			}else{
				return 2;
			}
		}
		double pesoTotal = 0f;
		
		void Btn_KruskalClick(object sender, EventArgs e)
		{	
			pesoTotal = 0f;
			subarbolesKuskal.Clear();
			wk = new Window_Kruskal();
			wk.Show();
			
			Ordenamientos ordenar =  new Ordenamientos();//para ordenar las aristas
			List<Aristas> candidatos = grafo.getAristas();//todas las aristas del grafo
			List<Aristas> prometedores = new List<Aristas>();//aqui se ingresaran las aristas finales seleccionadas
			List<List<Circulo>> cc = inicializaCC();//Conjunto de cojuntos de los circulos, 
			//necesario para operar con Kruskal. Se inicializa con todos los vertices del grafo
			
			candidatos = elimininarRepetidos(candidatos);//Eliminino aristas repetidas, aristas no dirigidas. Solo quedan dirigidas
			candidatos = ordenar.ordenarAristasK(candidatos);//Ordeno las aristas resultantes de menor a mayor
			
			for(int i = 0; i < candidatos.Count; i++){
				Debug.WriteLine(candidatos[i].origen.getId() + " -> " +
				               candidatos[i].destino.getId());
			}
			
			//Inicia algoritmo de kruskal
			for(int i = 0; i < candidatos.Count; i++){//Recorro a los candidatos
				int indexOrigen = Buscar(candidatos[i].origen.getId(), cc);//Obtengo el indice del origen en el cc
				int indexDestino = Buscar(candidatos[i].destino.getId(), cc);//Obtengo el indice del destino en el cc
				
				if(indexOrigen != indexDestino){//Si los identificadores de los circulos estan en diferentes conjuntos
					prometedores.Add(candidatos[i]);//Se añade a prometedores la arista
					pesoTotal += candidatos[i].arista;
					//Se une el circulo destino al origen en el cc
					cc = fusionaCC(candidatos[i].origen, candidatos[i].destino, cc);
				}
			}
			
			//SUBARBOLES
			for(int o = 0; o < cc.Count; o++){
				if(cc[o].Count != 0){
					subarbolesKuskal.Add(cc[o]);
				}
			}
			
			
			//Creacion del grafo kruskal para visualizacion grafico
			wk.showGraph(c1, circulos, prometedores);
			wk.showInfo(subarbolesKuskal, pesoTotal);
		}
		
		//Busqueda de indices en el cc
		int Buscar(int comp, List<List<Circulo>> conjuntos){
			int i, j;
			for(i = 0; i < conjuntos.Count; i++){
				for(j = 0; j < conjuntos[i].Count; j++){
					if(conjuntos[i][j].getId() == comp){
						return i;
					}
				}
			}
			return -1;
		}
		
		//Union de los circulos en el cc
		List<List<Circulo>> fusionaCC(Circulo c1, Circulo c2, List<List<Circulo>> cc){
			int o = Buscar(c1.getId(), cc);
			int d = Buscar(c2.getId(), cc);
			
			//Aqui se hace la union, se agregan todos los vertices del conjunto en destino en el conjunto en el indice destino
			for(int i = 0; i < cc[d].Count; i++){
				cc[o].Add(cc[d][i]);
			}
			cc[d].Clear();
			return cc;
		}
		
		//Inicializacion del cc
		List<List<Circulo>> inicializaCC(){
			List<List<Circulo>> cc = new List<List<Circulo>>();
			for(int i = 0; i < circulos.Count; i++){
				List<Circulo> aux = new List<Circulo>();
				aux.Add(circulos[i]);
				cc.Add(aux);
			}
			return cc;
		}
		
		
		//Se eliminan aristas repetidas solo de los vertices que estan conectados de forma no dirigida
		//Por ejemplo: A->B hay 3.4, B->A hay 3.4, Se elimina B->A. Si fuera B->C y hay 3.4 entonces no se eliminaria
		List<Aristas> elimininarRepetidos(List<Aristas> prometedores){
			//Elimnar aristas repetidas
			for(int i = 0; i < prometedores.Count; i++){
				for(int j = 0; j < prometedores.Count; j++){
					if(i != j){
						if(prometedores[i].arista == prometedores[j].arista){
							if(prometedores[i].origen.getId() == prometedores[j].destino.getId()){
								if(prometedores[i].destino.getId() == prometedores[j].origen.getId()){
									//Debug.WriteLine("*Comparado: " + prometedores[i].origen.getId()
								    //          + " - " + prometedores[i].destino.getId());
									prometedores.RemoveAt(j);
	
								}
							}
						}
					}
				}
			}
			return prometedores;
		}
		
		
		void Btn_PrimClick(object sender, EventArgs e)
		{
			subarbolesPrim.Clear();
			wp = new Window_Prim();
			wp.Show();
			pesoTotal = 0f;
			
			List<Aristas> prometedores = new List<Aristas>();
			//Llamo a la funcion Prim, esto lo hago ya que estas es recursiva para que encuentre subarboles
			prometedores = Prim(prometedores, grafo.getVertice(circulos[actualCicleIndex]));
			//Rreutilizo la funcion para mostrar el grafo graficamente
			
			wp.showGraph(c1, circulos, prometedores);
			wp.showInfo(subarbolesPrim, pesoTotal);
		}
		
		
		//Funcion para el algoritmo de prim, es recursiva para encontrar los subarboles
		List<Aristas> Prim(List<Aristas> prometedores, Vertice sel){
			
			Vertice seleccionado = sel;//Vertice inicial seleccionado
			List<Aristas> candidatos = new List<Aristas>();//Se guardan las aristas adyacentes de cada vertice agregado al conjunto
			List<Circulo> conjunto = new List<Circulo>();//Sive para comprobar los vertices que se han seleccionado
			conjunto.Add(seleccionado.circulo);//Agrego el primer vertice elegido
			
			//Obtengo a las aristas adyacentes del primer vertice seleccionado
			candidatos = getCandidatos(candidatos, seleccionado);
			
			//Los candidatos se van eliminado mientras se va ejecutando el algoritmo, cuando ya no halla terminara la ejecucucion
			while(candidatos.Count != 0){
				//Se obtiene la arista de menor peso adyacente a los candidatos disponibles
				Aristas min = getMin(candidatos);
				
				//Si el vertice no esta añadido al conjunto entonces se procede a insertarlo en donde corresponde
				if(factible(conjunto, min)){
					pesoTotal += min.arista;
					prometedores.Add(min);//Se añade a prometedores el nuevo vertice que no esta en el conjunto
					//Si el origen de la arista esta en el conjunto, se añade el destino. Si no se hace lo contrario
					if(pertenece(min.origen, conjunto)){
						conjunto.Add(min.destino);//Se añade el nuevo vertice al conjunto
						//Se obtienen las aristas adyacentes del nuevo vertice, circulo y se añaden a candidatos
						candidatos = getCandidatos(candidatos, grafo.getVertice(min.destino));
					}else{
						conjunto.Add(min.origen);
						candidatos = getCandidatos(candidatos, grafo.getVertice(min.origen));
					}
				}
				//Se van eliminado las aristas que se van comprobado para que no se ejecute infinito
				eliminarCandidato(candidatos, min);
			}
			
			subarbolesPrim.Add(conjunto);
			
			//Esta funcion devuelve un circulo en caso de pertenecer a otro arbol no conexo
			Circulo c = revisarSubarboles(prometedores);
			
			//Si se obtuvo un circulo entonces significa que existe otro arbol
			if(c != null){
				//Debug.WriteLine("En subarbol: " + c.getId());
				//Se retorna lo que devuelve la funcion Prim pero ahora con los candidatos del otro subarbol
				return Prim(prometedores, grafo.getVertice(c));
			}else{
				//Si no hay otro arbol solo se retornan los candidatos del arbol unico
				return prometedores;
			}
			
		}
		
		//Esta funcion me ayuda a comprobar si existe algun otro subarbol
		Circulo revisarSubarboles(List<Aristas> prometedores){
			//Obtengo todas las aristas existentes en el grafo y sus adyacencias
			List<Aristas> aristasSubarboles = grafo.getAristas();
			bool band = false;
			
			//Recorro todas las aristas del grafo y comparo cada una de ellas con los elementos dentro de prometedores
			for(int i = 0; i < aristasSubarboles.Count; i++){
				for(int j = 0; j < prometedores.Count; j++){
					//Si se encuentran coincidencias significa que el vertice comprobado no esta en otro arbol
					if(aristasSubarboles[i].origen.getId() == prometedores[j].origen.getId()){
						band = true;
						break;
					}
					if(aristasSubarboles[i].origen.getId() == prometedores[j].destino.getId()){
						band = true;
						break;
					}
				}
				//Si nunca se encontraron coincidencias, es decir que la bandera nunca cambio de estado, 
				//... se retorna el circulo que no deberia pertenecer a prometedores. 
				if(band == false){
					//Debug.WriteLine("Retornado: " + aristasSubarboles[i].origen.getId());
					return aristasSubarboles[i].origen;
				}
				//Reset de la bandera
				band = false;
			}
			//Si siempre de encontraron coincidencias entonces no hay subarboles
			return null;
		}
		
		//Se comprueba si el vertice/circulo seleccionado esta ya agregado a conjuntos
		bool factible(List<Circulo> conjunto, Aristas min){
			for(int i = 0; i < conjunto.Count; i++){
				if(min.destino.getId() == conjunto[i].getId()){
					return false;
				}
			}
			//Si no se encontraron coincidencias en el for devuelve true para ingresar al seleccionado
			return true;
		}
		
		//Se comprueba si un circulo pertenece al conjunto de circulos
		bool pertenece(Circulo c, List<Circulo> conjunto){
			for(int i = 0; i < conjunto.Count; i++){
				if(c.getId() == conjunto[i].getId()){
					return true;
				}
			}
			return false;
		}
		
		//Eliminacion de candidatos
		List<Aristas> eliminarCandidato(List<Aristas> candidatos, Aristas eliminado){
			for(int i = 0; i < candidatos.Count; i++){
				if(candidatos[i] == eliminado){
					candidatos.RemoveAt(i);
				}
			}
			return candidatos;
		}
		
		//Con esta funcion obtengo los cadidatos del vertice que se recibe, candidatos son las aristas adyacentes
		List<Aristas> getCandidatos(List<Aristas> candidatos, Vertice seleccionado){
			Arista auxArista = seleccionado.ady;
			while(auxArista != null){
				Aristas a = new Aristas(seleccionado.circulo, auxArista.ady.circulo, auxArista.distance);
				candidatos.Add(a);
				auxArista = auxArista.sig;
			}
			return candidatos;
		}
		
		
		
		Aristas getMin(List<Aristas> candidatos){
			//Obtengo el valor menor de las aristas
			Aristas min = candidatos[0];
			for(int i = 1; i < candidatos.Count; i++){
				if(min.arista > candidatos[i].arista){
					min = candidatos[i];
				}
			}
			return min;
		}
		
		
		void dibujarOrigen(){
			if(checkBoxFast.Checked == false){
				bmpGlobal = new Bitmap(c1);
				drawLines(bmpGlobal);
				etiquetasCirculos(70, 50, bmpGlobal, 20);
			}
			imagen_PBox.Image = bmpGlobal;
			float r = circulos[actualCicleIndex].getRadio()/1.5f;
			int x = circulos[actualCicleIndex].getCentroX();
			int y = circulos[actualCicleIndex].getCentroY();
			Brush brush = new SolidBrush(Color.LightSteelBlue);
			Graphics g = Graphics.FromImage(bmpGlobal);
			g.FillEllipse(brush, (int)(Math.Round(x-r)), (int)(Math.Round(y-r)), 2*r, 2*r);
		}
		
		void animarParticula(Circulo origen, Circulo destino){
			float r = origen.getRadio()/1.5f;
			bmpAnimacion = new Bitmap(bmpGlobal.Width, bmpGlobal.Height);
			imagen_PBox.Image = bmpAnimacion;
			Brush brush = new SolidBrush(Color.LightSteelBlue);
			Brush brushBlanco = new SolidBrush(Color.White);
			Graphics g = Graphics.FromImage(bmpAnimacion);
			Graphics gGlobal = Graphics.FromImage(bmpGlobal);
			float x = origen.getCentroX();
			float y = destino.getCentroY();
			float xAnt = 0;
			float yAnt = 0;
			
			float m = 0, b = 0;
			int inc = 0;
			float xI = origen.getCentroX();
			float yI = origen.getCentroY();
			float xF = destino.getCentroX();
			float yF = destino.getCentroY();
			
			if(xF == xI){
				m = (yF - yI);
			}else{
				m = (yF - yI)/(xF - xI);
			}
			b = yF - xF * m;
			
			inc = 1;
			yAnt = yI;
			xAnt = xI;
			
			if(m > -1 && m < 1){
				if(xF < xI){
					inc = -1;
				}
				for(x = xI; x != xF; x += inc){
					y = m*x+b;
					g.FillEllipse(brushBlanco, (int)(Math.Round(x-inc-r)), (int)(Math.Round(yAnt-r)), 2*r, 2*r);
					g.FillEllipse(brush, (int)(Math.Round(x-r)), (int)(Math.Round(y-r)), 2*r, 2*r);
					//imagen_PBox.Refresh();
					imagen_PBox.Image = bmpAnimacion;
					imagen_PBox.Update();
					Thread.Sleep(5);
					yAnt = y;
					g.Clear(Color.Transparent);
				}
			}else{
				if(yF < yI){
					inc = -1;
				}
				for(y = yI; y != yF; y += inc){
					x = (y - b) / m;
					g.FillEllipse(brushBlanco, (int)(Math.Round(xAnt-r)), (int)(Math.Round(y-inc-r)), 2*r, 2*r);
					g.FillEllipse(brush, (int)(Math.Round(x-r)), (int)(Math.Round(y-r)), 2*r, 2*r);
					//imagen_PBox.Refresh();
					imagen_PBox.Image = bmpAnimacion;
					imagen_PBox.Update();
					Thread.Sleep(5);
					xAnt = x;
					g.Clear(Color.Transparent);
				}
			}
			
		}
		
		
		void BtnResetClick(object sender, EventArgs e)
		{
			resetBitmap(bmpGlobal);
			resetBitmap(bmpAnimacion);
		}
		
		void resetBitmap(Bitmap bmp){
			bmp = new Bitmap(c1);
			drawLines(bmp);
			etiquetasCirculos(70, 50, bmp, 20);
			imagen_PBox.Image = bmp;
			indiceOrigen = -1;
			indiceDestino = -1;
			btnAnimacion.Enabled = false;
			btnDijkstra.Enabled = false;
		}
		
		void CheckOrigenCheckedChanged(object sender, EventArgs e)
		{
			if(checkOrigen.Checked == true){
				checkDestino.Checked = false;
			}
		}
		
		void CheckDestinoCheckedChanged(object sender, EventArgs e)
		{
			if(checkDestino.Checked == true){
				checkOrigen.Checked = false;
			}
		}
		
		void BtnDijkstraClick(object sender, EventArgs e)
		{
			Dijkstra();
			btnAnimacion.Enabled = true;
		}
		
		void Dijkstra(){
			
			List<VerticeDijkstra> VD = new List<VerticeDijkstra>();
			VD = inicializarDijkstra(VD);
			List<Aristas> aristas = new List<Aristas>();
			aristas = obtenerPesos(aristas);
			VerticeDijkstra actual = new VerticeDijkstra();

			while(!solucionDijkstra(VD)){
				int indicMenor = seleccionaDefinitivo(VD);
				if(indicMenor == -1){
					break;
				}
				actual = VD[indicMenor];
				VD = actualizarVD(VD, indicMenor, aristas);
			}
			
			mostrarCaminoDijkstra(VD);
		}
		
		
		void mostrarCaminoDijkstra(List<VerticeDijkstra> VD){
			caminosAnimacion.Clear();
			int indiceSeleccionado = buscareEnVD(VD, circulos[indiceDestino]);
			int indiceO = buscareEnVD(VD, circulos[indiceOrigen]);
			VerticeDijkstra seleccionado = VD[indiceSeleccionado];
			VerticeDijkstra origen = VD[indiceO];
			
			while(seleccionado.vertice.getId() != origen.vertice.getId()){
				Debug.Write(seleccionado.vertice.getId() + " <- ");
				if(seleccionado.padre != null){
					drawLineDijkstra(seleccionado.vertice, seleccionado.padre, Color.DarkCyan, 10);
					caminosAnimacion.Add(seleccionado);
				}
				indiceSeleccionado = buscareEnVD(VD, seleccionado.padre);
				if(indiceSeleccionado != -1){
					seleccionado = VD[indiceSeleccionado];
				}else{
					Debug.WriteLine("Camino no encontrado");
					break;
				}
				
			}
			Debug.Write(seleccionado.vertice.getId());
			imagen_PBox.Image = bmpGlobal;
			imagen_PBox.Update();
		}
		
		bool solucionDijkstra(List<VerticeDijkstra> VD){
			for(int i = 0; i < VD.Count; i++){
				if(VD[i].definitivo == false){
					return false;
				}
			}
			return true;
		}
		
		
		List<VerticeDijkstra> inicializarDijkstra(List<VerticeDijkstra> VD){
			for(int i = 0; i < circulos.Count; i++){
				VerticeDijkstra v = new VerticeDijkstra();
				if(i == indiceOrigen){
					v.vertice = circulos[i];
					v.peso = 0;
				}else{
					v.vertice = circulos[i];
				}
				VD.Add(v);
			}
			return VD;
		}
		
		
		List<Aristas> obtenerPesos(List<Aristas> aristas){
			Ordenamientos ordenar =  new Ordenamientos();//para ordenar las aristas
			aristas = grafo.getAristas();//todas las aristas del grafo
			aristas = elimininarRepetidos(aristas);//Eliminino aristas repetidas, aristas no dirigidas. Solo quedan dirigidas
			return aristas;
		}
		
		int seleccionaDefinitivo(List<VerticeDijkstra> VD){
			int indice_menor = menorNoDefinitivo(VD);
			if(indice_menor != -1){
				VD[indice_menor].definitivo = true;
			}
			
			return indice_menor;
		}
		
		int menorNoDefinitivo(List<VerticeDijkstra> VD){
			double menor = Single.PositiveInfinity;
			int indice = -1;
			for(int i  = 0; i < VD.Count; i++){
				if(VD[i].definitivo == false){
					//Debug.WriteLine("Minimo: " + VD[i].vertice.getId() + ", " + VD[i].peso);
					if(menor > VD[i].peso){
						//Debug.WriteLine("Menor: " + VD[i].vertice.getId());
						menor = VD[i].peso;
						indice = i;
					}
				}
			}
			return indice;
		}
		
		List<VerticeDijkstra> actualizarVD(List<VerticeDijkstra> VD, int indiceMenor, List<Aristas> aristas){
			List<Aristas> aristasActual = new List<Aristas>();
			double pesoActual = VD[indiceMenor].peso;
			VerticeDijkstra v = VD[indiceMenor];
			aristasActual = getAristas(aristas, aristasActual, v);
			
			for(int i = 0; i < aristasActual.Count; i++){
				double pesoTotal = pesoActual + aristasActual[i].arista;
				//Debug.WriteLine("Origen: " + v.vertice.getId() + ", Destino: " + aristasActual[i].destino.getId());
				int indiceD = buscareEnVD(VD, aristasActual[i].destino);
				if(indiceD != -1){
					//Debug.WriteLine("PesoO: " + VD[indiceD].peso + ", PesoT: " + pesoTotal);
					if(VD[indiceD].peso > pesoTotal){
						VD[indiceD].peso = pesoTotal;
						VD[indiceD].padre = v.vertice;
					}
					
				}

			}
			return VD;
		}
		
		//Con esta funcion obtengo los cadidatos del vertice que se recibe, candidatos son las aristas adyacentes
		List<Aristas> getAristas(List<Aristas> aristas, List<Aristas> aristasActual, VerticeDijkstra actual){
			for(int i = 0; i < aristas.Count; i++){
				if(aristas[i].origen.getId() == actual.vertice.getId()){
					aristasActual.Add(aristas[i]);
				}
				if(aristas[i].destino.getId() == actual.vertice.getId()){
					Aristas a = new Aristas(aristas[i].destino, aristas[i].origen, aristas[i].arista);
					aristasActual.Add(a);
				}
			}
			return aristasActual;
		}
		
		int buscareEnVD(List<VerticeDijkstra> VD, Circulo c){
			for(int i = 0; i < VD.Count; i++){
				if(c != null){
					if(VD[i].vertice.getId() == c.getId()){
						return i;
					}
				}
			}
			return -1;
		}
		
		void drawLineDijkstra(Circulo origen, Circulo destino, Color c, int tam){
			Graphics g = Graphics.FromImage(bmpGlobal);
			Pen p = new Pen(c, tam);
			g.DrawLine(p, origen.getCentroX()-1, origen.getCentroY()-1, destino.getCentroX()+1, destino.getCentroY()+1);
		}
		

		
		void BtnAnimacionClick(object sender, EventArgs e)
		{
			for(int i = caminosAnimacion.Count-1; i >= 0; i--){
				animarParticula(caminosAnimacion[i].padre, caminosAnimacion[i].vertice);
			}
		}
	}
}
