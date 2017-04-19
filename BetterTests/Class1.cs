using System;
using System.Linq;
using Xunit;
using EntityAndSql;
using EntityAndSql.Models;
using MyAspCoreProject.Models;
using MyAspCoreProject.Controllers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using MyAspCoreProject;
using System.IO;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace BetterTests
{
    public class Class1
    {
        [Fact]
        public void PassingTest()
        {
            // DO NOT DO THIS

            int rowsAffected = EntityAndSql.Program.AddCoursesAsync().Result;
            Assert.Equal(4, rowsAffected);

            // THIS NEITHER

            // USE MOCKING.

            using (var context = new CourseContext())
            {
                //  Assert.Single(context.Students.Where(x => x.Name == "Arjen"));
                var result = context.Students.Single(x => x.Name == "Arjen");

                Console.WriteLine($"{result.Scores} scores");
                Assert.Equal(7, result.Scores);

            }
        }

        [Fact]
        public void DeletingFiles()
        {
            int result = EntityAndSql.Program.DeleteCourseAsync().Result;
            Assert.Equal(0, result);

            using (var context = new CourseContext())
            {
                Assert.Empty(context.Students);
            }
        }

        [Fact]
        public void UpdatingFiles()
        {
            var context = new BooksContext();
            var s = new BooksService(context);
            s.UpdateBookAsync().Wait();
            var result = context.Books.Single(x => x.Publisher == "Proffesional c# and .NET core 6");
            Assert.Equal("c#", result.Publisher);

        }
        [Fact]
        public void ImportingFiles()
        {
            SerialContext context = new SerialContext();
            SerialsController con = new SerialsController(context);
            
            List<IFormFile> file = new List<IFormFile>();
            var result = con.Browse(file) as ViewResult;
            Assert.IsType(typeof(Serial), result.ViewData.Model);
            Serial serial = (Serial)result.ViewData.Model;
            Assert.Equal("kumkum", serial.SerialName);
             
        }
    }
}
