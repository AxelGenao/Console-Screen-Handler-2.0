using System;
using System.Text;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using ProgramJson.Datos;
using Newtonsoft.Json;
using System.IO;

namespace Program
{
    class Program
    {
        private static string _path = @"C:\Users\axelg\JSON\Persona.json";
        static void Main(string[] args)
        {
            // var persona = GetPersona();
            // SerializeJsonFile(persona);

            var persona = GetPersonaJsonFromFile();
            DeserializeJsonFromFile (persona);

        }

        #region "Escribiendo el JSon" 
        public static void SerializeJsonFile(List<Persona> persona)
        {
            string personaJson = JsonConvert.SerializeObject(persona.ToArray(), Formatting.Indented);

            File.WriteAllText(_path , personaJson);
        }

        
        public static List<Persona>? GetPersona()
        {
            List<Persona> persona = new List<Persona>
            {
                new Persona
                {
                    Nombre = "Axel",
                    Apellido = "Genao",
                    Edad = "21",
                }
            };
            return null;
            
        }
        #endregion

        public static string GetPersonaJsonFromFile()
        {
            string personaJsonFromFile;
            using (var reader = new StreamReader(_path))
            {
                personaJsonFromFile = reader.ReadToEnd();
            }
            return personaJsonFromFile;
        }

        public static  void DeserializeJsonFromFile(string personaJsonFromFile)
        {
            Console.WriteLine(personaJsonFromFile);

            var persona = JsonConvert.DeserializeObject<List<Persona>>(personaJsonFromFile);

            Console.WriteLine(string.Format("Nombre es: {0} " , persona[0].Nombre));
            Console.WriteLine(string.Format("Apellido es: {0} ", persona[0].Apellido));
            Console.WriteLine(string.Format("Edad es: {0} ", persona[0].Edad));

        }
    }
}