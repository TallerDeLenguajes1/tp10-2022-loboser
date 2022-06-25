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
            var ListaDeUnidades = ObtenerListaDeUnidades();
            int maximo = 0;
            int idSeleccionado = -1;

            foreach (var unidad in ListaDeUnidades)
            {
                Console.WriteLine("\nId: " + unidad.id);
                Console.WriteLine("Nombre: " + unidad.name);
                if (unidad.id>maximo)
                { 
                    maximo = unidad.id;
                }
            }

            do
            {  
                Console.Write("\n\nId de la unidad que desea mostrar completa: ");
                idSeleccionado = Convert.ToInt32(Console.ReadLine());

                if (idSeleccionado<0 || idSeleccionado>maximo)
                {
                    Console.WriteLine("\nId Inexistente ENTER para volver a ingresaar uno...");
                    Console.ReadLine();
                    Console.Clear();
                }
            } while (idSeleccionado<1 || idSeleccionado>maximo);
            
           foreach (var unidad in ListaDeUnidades)
           {
                if (unidad.id == idSeleccionado)
                {
                    Console.WriteLine("\nId: " + unidad.id);
                    Console.WriteLine("Nombre: " + unidad.name);
                    Console.WriteLine("Descripcion: " + unidad.description);
                    Console.WriteLine("Expansion: " + unidad.expansion);
                    Console.WriteLine("Edad: " + unidad.age);
                    Console.WriteLine("Creado En: " + unidad.created_in);
                    Console.WriteLine("Costo: ");
                    if (unidad.cost.Food != 0)
                    {
                        Console.WriteLine("Comida: " + unidad.cost.Food);
                    }
                    if (unidad.cost.Wood != 0)
                    {
                        Console.WriteLine("Madera: " + unidad.cost.Wood);
                    }
                    if (unidad.cost.Stone != 0)
                    {
                        Console.WriteLine("Piedra: " + unidad.cost.Stone);
                    }
                    if (unidad.cost.Gold != 0)
                    {
                        Console.WriteLine("Oro: " + unidad.cost.Gold);
                    }
                    Console.WriteLine("\nTiempo de Creacion: " + unidad.build_time);
                    Console.WriteLine("Tiempo de Recarga: " + unidad.reload_time);
                    Console.WriteLine("Retraso de Ataque: " + unidad.attack_delay);
                    Console.WriteLine("Ratio de Movimiento: " + unidad.movement_rate);
                    Console.WriteLine("Linea de Vision: " + unidad.line_of_sight);
                    Console.WriteLine("Puntos de Golpe: " + unidad.hit_points);
                    Console.WriteLine("Ataque: " + unidad.attack);
                    Console.WriteLine("Proteccion: " + unidad.armor);

                    if (unidad.attack_bonus!=null)
                    {
                        Console.WriteLine("Bonos de Ataque: ");
                        foreach (var item in unidad.attack_bonus)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    
                    if (unidad.armor_bonus!=null)
                    {
                        Console.WriteLine("Bonos de Proteccion: ");
                        foreach (var item in unidad.armor_bonus)
                        {
                            Console.WriteLine(item);
                        }
                    }

                    if (unidad.search_radius!=0)
                    {
                        Console.WriteLine("Radio de Busqueda: " + unidad.search_radius);
                    }
                    if (unidad.accuracy!=null)
                    {
                        Console.WriteLine("Precision: " + unidad.accuracy);
                    }
                    if (unidad.blast_radius!=0)
                    {
                        Console.WriteLine("Radio de Explosion: " + unidad.blast_radius);
                    }
                }
           }
        }

        private static List<Unit> ObtenerListaDeUnidades()
        {
            var url = $"https://age-of-empires-2-api.herokuapp.com/api/v1/units";
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
                            Root ListaDeUnidades = JsonSerializer.Deserialize<Root>(responseBody);
                            return ListaDeUnidades.units;
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