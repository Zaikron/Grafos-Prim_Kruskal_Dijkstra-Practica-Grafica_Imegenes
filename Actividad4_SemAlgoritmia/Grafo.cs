
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Actividad4_SemAlgoritmia
{

	public class Grafo
	{
		public Vertice h;
		
		public Grafo()
		{
		}
		
		public void inicializar(){
			h = null;
		}
		public bool esVacio(){
			return h == null;
		}	
		public int tam(){
			int cont = 0;
			Vertice aux;
			aux = h;
			while (aux != null) {
				cont++;
				aux = aux.sig;
			}
			return cont;
		}
		
		public Vertice getVertice(Circulo c){
			Vertice aux;
			aux = h;
			while (aux != null) {
				
				if(aux.circulo.getId() == c.getId()){
					return aux;
				}
				
				aux = aux.sig;
			}
			return null;
		}
		
		public void insertarArista(Vertice origen, Vertice destino, double distance){
			Arista nueva = new Arista();
			nueva.distance = distance;
			nueva.sig = null;
			nueva.ady = null;
			
			Arista aux;
			aux = origen.ady;
			
			if(aux == null){
				origen.ady = nueva;
				nueva.ady = destino;
			}else{
				while(aux.sig != null){
					aux = aux.sig;
				}
				aux.sig = nueva;
				nueva.ady = destino;
			}
		}
		
		public void insertarVertice(Circulo c){
			Vertice nuevo = new Vertice();
			nuevo.circulo = c;
			nuevo.sig = null;
			nuevo.ady = null;
			
			if(esVacio()){
				h = nuevo;
			}else{
				Vertice aux;
				aux = h;
				while(aux.sig != null){
					aux = aux.sig;
				}
				aux.sig = nuevo;
			}
		}
		
		
		
		public void listaAdyacencia(TextBox textB){
			
			Vertice vertAux;
			Arista arAux;
			textB.Clear();
			
			vertAux = h;
			textB.Text += "Lista de Adyacencia:";
			textB.Text += Environment.NewLine;
			textB.Text += "Tamaño del grafo: " + tam() + " (Vertices)";
			textB.Text += Environment.NewLine;
			
			while(vertAux != null){
				//Debug.Write("(" + vertAux.circulo.getId() + ")" + "-->");
				textB.Text += Environment.NewLine;
				textB.Text += "[" + vertAux.circulo.getId() + "]" + " es adyacente con: ";
				textB.Text += Environment.NewLine;
				
				arAux = vertAux.ady;
				while (arAux != null) {

					//Debug.Write("(" + arAux.ady.circulo.getId() + ")" + "[Distancia: " + (float)arAux.distance + "px]" + " - ");
					textB.Text += "	(" + arAux.ady.circulo.getId() + ": a " + (float)arAux.distance + "px)";
					textB.Text += Environment.NewLine;
					arAux = arAux.sig;
				}
				vertAux = vertAux.sig;
				//Debug.Write("\n");
				textB.Text += Environment.NewLine;
			}
		}
		
		
		public void listaAdyacenciaTreeView(TreeView view){
			
			Vertice vertAux;
			Arista arAux;
			int contadorVertices = 0;
			
			view.BeginUpdate();
			view.Nodes.Clear();
			
			
			vertAux = h;
			
			while(vertAux != null){
				view.Nodes.Add("Adyacencias de " + vertAux.circulo.getId());
				arAux = vertAux.ady;
				while (arAux != null) {
					view.Nodes[contadorVertices].Nodes.Add(arAux.ady.circulo.getId() + ": " + (float)arAux.distance + "px");
					arAux = arAux.sig;
				}
				view.Nodes[contadorVertices].Expand();
				vertAux = vertAux.sig;
				contadorVertices++;
			}
			view.EndUpdate();
		}
		
		
		
		public List<Aristas> getAristas(){
			
			List<Aristas> aristas = new List<Aristas>();
			Vertice vertAux;
			Arista arAux;
			
			vertAux = h;
			
			while(vertAux != null){
				arAux = vertAux.ady;
				while (arAux != null) {
					
					Aristas a = new Aristas(vertAux.circulo, arAux.ady.circulo, arAux.distance);
					aristas.Add(a);
					arAux = arAux.sig;
				}
				vertAux = vertAux.sig;
			}
			return aristas;
		}
		
		
		
		public void eliminarArista(Vertice origen, Vertice destino){
			Arista actual;
			Arista anterior = null;
			actual = origen.ady;
			int band = 0;
			
			if(actual == null){
				Debug.WriteLine("El origen no tiene aristas");
			}else if(actual.ady == destino){
				origen.ady = actual.sig;
				actual = null;
			}else{
				while (actual != null) {
					if(actual.ady == destino){
						anterior.sig = actual.sig;
						actual = null;
						band  = 1;
						break;
					}
					anterior = actual;
					actual = actual.sig;
				}
				if(band == 0){
					Debug.WriteLine("Vertices no conectados");
				}
				
			}
		}
		
		public void anular(){
			Vertice aux;
			
			while(h != null){
				aux = h;
				h = h.sig;
				aux = null;
			}
		}
		
		
		
		public void recorridoProfundidad(Vertice origen){
			Vertice actual = new Vertice();
			Stack<Vertice> pila = new Stack<Vertice>();
			List<Vertice> lista = new List<Vertice>();
			int band;
			int band2;
			
			pila.Push(origen);
			
			while(pila.Count != 0){
				band = 0;
				actual = pila.Peek();
				pila.Pop();
				
				for(int i = 0; i < lista.Count; i++){
					if(lista[i] == actual){
						band = 1;
					}
				}
				if(band == 0){
					//Se muestra el vertice actual
					Debug.WriteLine("Vertice: " + actual.circulo.getId());
					
					lista.Add(actual);
					
					Arista aux;
					aux = actual.ady;
					
					while (aux != null) {
						band2 = 0;
						for(int j = 0; j < lista.Count; j++){
							if(lista[j] == aux.ady){
								band2 = 1;
							}
						}
						if(band2 == 0){
							pila.Push(aux.ady);
							Debug.WriteLine("Arista: " + aux.distance);
						}
						aux = aux.sig;
					}
				}
			}
		}
		
	}
}
