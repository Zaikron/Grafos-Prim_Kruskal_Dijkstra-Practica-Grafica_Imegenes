
using System;
using System.Collections.Generic;

namespace Actividad4_SemAlgoritmia
{

	public class Ordenamientos
	{
		public Ordenamientos()
		{
		}
		
		public List<Circulo> bubbleSort_Area(List<Circulo> circulos){
			
			Circulo aux;

		    for(int i = 0; i < circulos.Count - 1; i++){
		        for(int j = 0; j  < circulos.Count - 1; j++){
					if(circulos[j+1].getArea() < circulos[j].getArea()){
		                aux = circulos[j+1];
		                circulos[j+1] = circulos[j];
		                circulos[j] = aux;
		            }
		        }
		    }
			
			return circulos;		
		}
		
		
		public List<Circulo> seleccionSort_EjeX(List<Circulo> circulos){
			int min;

		    for (int i = 0; i < circulos.Count-1; ++i)
		    {
		        min = i;
		        for (int j = (i + 1); j < circulos.Count; ++j)
		        {
		        	if (circulos[min].getCentroX() > circulos[j].getCentroX())//lista[j] < lista[min]
		            {
		                min = j;
		            }
		        }
		        Circulo aux;
		        aux = circulos[i];
		        circulos[i] = circulos[min];
		        circulos[min] = aux;
		    }
		    
		    return circulos;	
		}
		
		
		public List<Circulo> insetionSort_EjeY(List<Circulo> circulos){
			Circulo v;
		    int j;
		
		    for(int i = 1; i < circulos.Count; i++){
		        v = circulos[i];
		        j = i - 1;
		        while(j >= 0 && circulos[j].getCentroY() > v.getCentroY()){
		            circulos[j+1] = circulos[j];
		            j = j - 1;
		        }
		        circulos[j + 1] = v;
		    }
		    
		    return circulos;
		}
		
		public List<Arista> ordenarAristas(List<Arista> aristas){
			Arista v;
		    int j;
		
		    for(int i = 1; i < aristas.Count; i++){
		        v = aristas[i];
		        j = i - 1;
		        while(j >= 0 && aristas[j].distance > v.distance){
		            aristas[j+1] = aristas[j];
		            j = j - 1;
		        }
		        aristas[j + 1] = v;
		    }
		    
		    return aristas;
		}
		
		public List<Aristas> ordenarAristasK(List<Aristas> aristas){
			Aristas v;
		    int j;
		
		    for(int i = 1; i < aristas.Count; i++){
		        v = aristas[i];
		        j = i - 1;
		        while(j >= 0 && aristas[j].arista > v.arista){
		            aristas[j+1] = aristas[j];
		            j = j - 1;
		        }
		        aristas[j + 1] = v;
		    }
		    
		    return aristas;
		}
		
		
	}
	
	
}
