using gttgBackend.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace gttgBackend.Utils
{
    public class FileReader
    {
        public static List<PlanetData> ReadFile(string filePath)
        {

            
            string jsonString = File.ReadAllText(filePath);
            Console.WriteLine("Jsonstring: " + jsonString);
            return JsonSerializer.Deserialize<List<PlanetData>>(jsonString);

        }

    }
}

