using MyAspCoreProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;
using MyAspCoreProject.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyAspCoreProject
{
    public class DoSomething
    {
        public static void CreateMyDatabase()
        {
            using (var context = new SerialContext())
            {
                context.Database.EnsureCreated();

            }
        }
        public IActionResult ParseMyStuff(Stream uploadedFileStream)
        {
            using (var reader = new StreamReader(uploadedFileStream))
            {
                using (var _context = new SerialContext())
                { 
                    string one = reader.ReadLine();

                    while (one != null)
                    {
                        var serial = new Serial();

                        string val1 = one.Substring(one.IndexOf('=') + 1);
                        string two = reader.ReadLine();
                        string val2 = two.Substring(two.IndexOf('=') + 1);
                        val2 = val2.Trim();
                        DateTime dt2 = DateTime.ParseExact(val2, "HH:mm:ss", CultureInfo.InvariantCulture);
                        string three = reader.ReadLine();
                        string val3 = three.Substring(three.IndexOf('=') + 1);
                        val3 = val3.Trim();
                        DateTime dt3 = DateTime.ParseExact(val3, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                        serial.SerialName = val1;
                        serial.SerialTime = dt2;
                        serial.ReleaseDate = dt3;


                        _context.Serials.Add(serial);
                      
                        one = reader.ReadLine();
                    }
                    _context.SaveChanges();
                    return new NoContentResult();
                }
            }
        }
    }
}
