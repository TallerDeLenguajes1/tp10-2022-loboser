// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Net;
using System.IO;   
using System.Text.Json;
using System.Text.Json.Serialization;

namespace tp10
{
    class Program
    {
        public static void Main(string[] args)
        {   
            var ListCivilizaciones = ObtenerListaDeCivilizaciones();
            int maximo = 0;
            int idSeleccionado = -1;

            foreach (var Civilizacion in ListCivilizaciones)
            {
                Console.WriteLine("\nId: " + Civilizacion.Id);
                Console.WriteLine("Nombre: " + Civilizacion.Name);
                if (Civilizacion.Id>maximo)
                { 
                    maximo = Civilizacion.Id;
                }
            }

            do
            {  
                Console.Write("\n\nId de la civilizacion que desea mostrar sus caracteristicas: ");
                idSeleccionado = Convert.ToInt32(Console.ReadLine());

                if (idSeleccionado<0 || idSeleccionado>maximo)
                {
                    Console.WriteLine("\nId Inexistente ENTER para volver a ingresaar uno...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (idSeleccionado<1 || idSeleccionado>maximo);
            
           foreach (var Civilizacion in ListCivilizaciones)
           {
                if (Civilizacion.Id == idSeleccionado)
                {
                    Console.WriteLine("\nId: " + Civilizacion.Id);
                    Console.WriteLine("Nombre: " + Civilizacion.Name);
                    Console.WriteLine("Expansion: " + Civilizacion.Expansion);
                    Console.WriteLine("Tipo de Ejercito: " + Civilizacion.ArmyType);
                    Console.WriteLine("Bono de Equipo: " + Civilizacion.TeamBonus);
                    if (Civilizacion.CivilizationBonus.Length>0)
                    {
                    Console.WriteLine("Bonos de Civilizacion: ");
                        for (int i = 0; i < Civilizacion.CivilizationBonus.Length; i++)
                        {
                            Console.WriteLine((i+1) + ". " + Civilizacion.CivilizationBonus[i]);
                        }
                    }
                }
           }
        }

        private static List<Civilizaciones> ObtenerListaDeCivilizaciones()
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/civilizations";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using(WebResponse response = request.GetResponse()){
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            ListaDeCivilizaciones ListCivilizaciones = JsonSerializer.Deserialize<ListaDeCivilizaciones>(responseBody);
                            return ListCivilizaciones.Lista;
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                
                throw;
            }
            

        }
    }
}