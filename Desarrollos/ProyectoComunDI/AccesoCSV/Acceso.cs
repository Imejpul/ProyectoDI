using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Microsoft.VisualBasic;
using Utilidades;
using System.Globalization;

namespace AccesoCSV
{
    public class Acceso
    {
		private const string FILE_NAME = @"C:\Users\Anselmo\Desktop\iris.data"; //ATENCIÓN -> CAMBIAR RUTA

		//variables para almacenar datos flor
		private static double sepal_lenght;
		private static double sepal_width;
		private static double petal_lenght;
		private static double petal_width;
		private static string irisclass;

		private static string[] filas;

		public static void downloadFile()
		{
			var url = "https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data";
			try
			{
				WebClient cln = new WebClient();
				cln.DownloadFile(url, FILE_NAME);
			}
			catch (Exception e)//(WebException)
			{
				Console.WriteLine("¡Error al cargar archivo desde la web!");
			}
		}

		public static void cargarArchivoData() //lee y almacena los datos del archivo .data
		{
			if (File.Exists(FILE_NAME)) //Comprobaciones ayuda depuración
			{
				Console.WriteLine("{0} already exists!", FILE_NAME);			
					
					var rows = File.ReadAllLines(FILE_NAME);
					filas = new string[rows.Length];

					for (int i = 0; i < filas.Length; i++)
					{
						if (rows[i] != "")
						{
							filas[i] = rows[i];
						}
							
					}
			}
			else
			{
				Console.WriteLine("{0} NO exists!", FILE_NAME);
			}

			
		}

		//crea el archivo .csv y lo carga con los datos extraidos del dataset
		public static void crearArchivoCSV()
		{
			string filePath = @"C:\Users\Anselmo\Desktop\IRIS.csv"; //ATENCIÓN -> CAMBIAR RUTA

			StringBuilder sb = new StringBuilder();

			for (int index = 0; index < filas.Length; index++)
			{
				if (filas[index] != "")
				{
					sb.AppendLine(filas[index]);
				}
			}
			File.WriteAllText(filePath, sb.ToString());			
		}


		//carga los datos del dataset en una lista de evidencias
		public static List<Evidencia> cargarEvidencias()
		{
			List<Evidencia> evidencias = new List<Evidencia>();

			for (int i = 0; i < filas.Length; i++)
			{
				if (!(filas[i] is null))
				{
					var values = filas[i].Split(',');


					sepal_lenght = Double.Parse(values[0], CultureInfo.InvariantCulture);
					
					sepal_width = Double.Parse(values[1], CultureInfo.InvariantCulture);
					
					petal_lenght = Double.Parse(values[2], CultureInfo.InvariantCulture);
					
					petal_width = Double.Parse(values[3], CultureInfo.InvariantCulture);
						
					irisclass = values[4].ToString();

					//instancia de evidencia
					Evidencia evidencia = new Evidencia(petal_lenght, sepal_lenght, petal_width, sepal_width, irisclass);
					evidencias.Add(evidencia);
				}				

				
			}
			return evidencias;
		}
	}
}
