using System;

namespace TestGridAddIns
{
	/// <summary>
	/// Clase Generica de Prueba
	/// </summary>
	public class Prueba
	{
		private System.Random objRandom;
		
		public int Campo1 = 0;
		public string Campo2 = string.Empty;
		public string Campo3 = string.Empty;
		public int Campo4 = 0;
		public double Campo5 = 0.0;
		
		public Prueba()
		{
			this.objRandom = new System.Random((int)(System.DateTime.Now.Millisecond));
		}
		
		public Prueba(int Semilla)
		{
			this.objRandom = new System.Random((int)(System.DateTime.Now.Millisecond % Semilla));
		}
		
		public void LlenarAleatorio()
		{
			this.Campo1 = this.GetEnteroAleatorio(0,120);
			this.Campo2 = this.GetCadenaAleatoria(20);
			this.Campo3 = this.GetCadenaAleatoria(120);
			this.Campo4 = this.GetEnteroAleatorio(0,999);
			this.Campo5 = this.GetDobleAleatorio(0,10);
		}
		
		/// <summary>
		/// Obtener un numero entero aleatorio
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public int GetEnteroAleatorio(int a, int b)
		{
			return this.objRandom.Next(a, (b + 1));
		}

		/// <summary>
		/// Obtener un numero doble aleatorio
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		/// <returns></returns>
		public double GetDobleAleatorio(int a, int b)
		{
			//primero obtenemos la parte entra
			double num = this.objRandom.Next((int)a, (int)(b + 1));
			//luego obtenemos la parte decimal, [0.0 .. 1.0]
			num += this.objRandom.NextDouble();
			return num;
		}
		
		/// <summary>
		/// Obtiener una cadena de caracteres aleatorios
		/// </summary>
		/// <param name="Tamaño"></param>
		/// <returns></returns>
		public String GetCadenaAleatoria(int Tamaño)
		{
        	string[] chars = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", 
                        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        	string s = string.Empty;
        	for (int i = 0; i < Tamaño; i++)
        	{
           		s += chars[this.objRandom.Next(0, 50)];
        	}
        	return s;
     	}
		
	}
}
