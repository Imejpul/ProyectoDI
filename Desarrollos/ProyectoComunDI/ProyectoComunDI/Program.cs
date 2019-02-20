using AccesoCSV;
using System;
﻿using AccesoSqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoBDMySql;
using Utilidades;
using AccesoCSV;

namespace ProyectoComunDI
{
	class Program
	{
		static void Main(string[] args)
		{
			/*
			#region Acceso MySQL
			List<string[]> dataseti = new List<string[]>();
			dataseti = Dataset.cargarDatos("127.0.0.1", "3306", "root", "", "dataset");
		
			#endregion
			*/

			#region AccesoCSV
			List<Evidencia> iris = new List<Evidencia>();

			AccesoCSV.Acceso.downloadFile();
			AccesoCSV.Acceso.cargarArchivoData();
			AccesoCSV.Acceso.crearArchivoCSV();
			iris = AccesoCSV.Acceso.cargarEvidencias(); //iris -> lista con evidencias cargadas

			#endregion

			
			/*
			#region Aceso SQLServer
			//Lista de evidencias            
			List<Evidencia> evidencias = Consulta.ConsultaTodaLaTabla();
			#endregion
			*/

			
			#region Configurador
			//Se recorre la lista de objetos para extraer los datos
			foreach (Evidencia evidencia in iris)
			{

				/* Sale por consola todos los datos*/
                  Console.WriteLine(evidencia.Longitud_petalo+"--"+evidencia.Longitud_sepalo+
                    "--"+evidencia.Ancho_petalo + "--" + evidencia.Ancho_sepalo+"--"+evidencia.Clase);
			}
			Console.ReadKey();

			// aquí se instancian las clases necesarias para conectarse a cada base de datos.
			#endregion

			
		}
	}
}