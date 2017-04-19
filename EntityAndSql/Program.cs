using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using static System.Console;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using EntityAndSql.Models;

namespace EntityAndSql
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var context = new BooksContext();
            //context.AddBookAsync().Wait(); //to add records
            //context.ReadBooks(); //to read records
            //context.UpdateBookAsync().Wait();
            //context.DeleteBookAsync().Wait();
            CreateDatabaseAsync().Wait();
            AddCoursesAsync().Wait();
            
            DeleteCourseAsync().Wait();

            var p = new Program();
            p.InitializeServices();
            var service = p.Container.GetService<BooksService>();
            service.AddBookAsync().Wait();
            service.ReadBooks();
            service.DeleteBookAsync().Wait();
            Main2();

        }
        private static async Task CreateDatabaseAsync()
        {
            using (var context = new CourseContext())
            {
                bool created = await context.Database.EnsureCreatedAsync();
                string createdText = created ? "created" : "already exists";
                WriteLine($"database {createdText}");
            }
        }
        public static async Task<int> AddCoursesAsync()
        {
            using (var context = new CourseContext())
            {
                var courseList = new Course();
                List<Student> students = new List<Student>()
                {
                    new Student
                    {
                        Name = "John",
                        Title = "Sql",
                        Scores = 5
                    },
                    new Student
                    {
                        Name = "Elma",
                        Title = "C#",
                        Scores = 6
                    },
                     new Student
                    {
                        Name = "Arjen",
                        Title = "Java",
                        Scores = 7
                    }
                };
                courseList.Title = "c# and .Net";
                courseList.Students = students;
                context.Courses.Add(courseList);

                ShowState(context);
                int records = await context.SaveChangesAsync();
                Console.WriteLine($"{records} added");
                return records;
            }
        }
        public static async Task<int> DeleteCourseAsync()
        {
            var context = new CourseContext();
            var course = context.Courses;
            context.Courses.RemoveRange(course);
            int records = await context.SaveChangesAsync();
            WriteLine($"{records} records deleted");
            return records;
        }
        public void ReadCourseData()
        {
            var context = new CourseContext();
            var student = from b in context.Students
                          orderby b
                          select b;
            foreach(var b in student)
            {
                WriteLine($"{b.Name}");
            }
        }
        public static void ShowState(CourseContext context)
        {
            foreach (EntityEntry entry in context.ChangeTracker.Entries())
            {
                Console.WriteLine($"type:{entry.Entity.GetType().Name}, state: {entry.State}," +
                    $"{entry.Entity}");
            }
            Console.WriteLine();
        }
        public void InitializeServices()
        {
            const string ConnectionString = @"server =CURSISTE02\SQLEXPRESS;database =Books;trusted_connection=true";
            var services = new ServiceCollection();

            services.AddTransient<BooksService>();
            services.AddEntityFramework()
                .AddEntityFrameworkSqlServer()
                .AddDbContext<BooksContext>(options =>
                options.UseSqlServer(ConnectionString));
            Container = services.BuildServiceProvider();
        }
        public IServiceProvider Container { get; private set; }

        public static void Main2()
        {
            var plaatsnamen = new List<string> {
          "Amsterdam", "Arnhem", "Amersfoort",
              "Assen", "Amstelveen", "Alphen",
           };

            var query = plaatsnamen.Where(x => x.Length < 8).OrderBy(x => x.Length).ThenBy(x => x).ToList();  //extension method

            foreach(var item in query)
            {
                Console.WriteLine(item);                    
            }
            var query2 = plaatsnamen.Where(x => x.EndsWith("m")).Sum(x => x.Length);

            Console.WriteLine(query2);


            var s = "bladieblaq";


            Console.WriteLine(s[s.Length - 1]);

        }

    }
}
