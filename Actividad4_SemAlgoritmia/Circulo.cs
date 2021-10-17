
using System;

namespace Actividad4_SemAlgoritmia
{

	public class Circulo
	{
		private int centroX;
		private int centroY;
		private int inicioX;
		private int finX;
		private float areaCirculo;
		private int identificador;
		private float radio;
		
		public Circulo(int cX, int cY, int iniX, int fX, int id)
		{
			this.centroX = cX;
			this.centroY = cY;
			this.inicioX = iniX;
			this.finX = fX;
			this.identificador = id;
			calcularArea();
		}
		
		private void calcularArea(){
			radio = (finX - inicioX) / 2;
			areaCirculo = 3.1416f * (radio*radio);
		}
		
		public float getArea(){
			return areaCirculo;
		}
		
		public int getCentroX(){
			return centroX;
		}
		
		public int getCentroY(){
			return centroY;
		}
		
		public int getIniX(){
			return inicioX;
		}
		
		public int getFinX(){
			return finX;
		}
		
		public int getId(){
			return identificador;
		}
		
		public float getRadio(){
			return radio;
		}
	}
}
