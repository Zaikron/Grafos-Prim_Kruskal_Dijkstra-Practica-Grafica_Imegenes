
using System;

namespace Actividad4_SemAlgoritmia
{
	
	public class Aristas
	{
		
		public Circulo origen;
		public Circulo destino;
		public double arista;
		
		public Aristas(Circulo or, Circulo des, double ar)
		{
			origen = or;
			destino = des;
			arista = ar;
		}
	}
}
