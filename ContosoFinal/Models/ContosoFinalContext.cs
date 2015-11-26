using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ContosoFinal.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class ContosoFinalContext : DbContext
    {
        public class MyConfiguration : DbMigrationsConfiguration<ContosoFinalContext>
        {

            public MyConfiguration()
            {
                this.AutomaticMigrationsEnabled = true;
                this.AutomaticMigrationDataLossAllowed = true;
            }

            protected override void Seed(ContosoFinalContext context)
            {
                var students = new List<Student>
                {
                new Student { FirstMidName = "Carson",   LastName = "Alexander"},
                new Student { FirstMidName = "Meredith", LastName = "Alonso"},
                new Student { FirstMidName = "Arturo",   LastName = "Anand"},
                };
                students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
                context.SaveChanges();


                var courses = new List<Course>
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3, },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3, },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3, },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4, },
            };
                courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
                context.SaveChanges();

                var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.A
                },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                 },
                 new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                 },
            };

                foreach (Enrollment e in enrollments)
                {
                    var enrollmentInDataBase = context.Enrollments.Where(
                        s =>
                             s.Student.ID == e.StudentID &&
                             s.Course.CourseID == e.CourseID).SingleOrDefault();
                    if (enrollmentInDataBase == null)
                    {
                        context.Enrollments.Add(e);
                    }
                }
                context.SaveChanges();

                var items = new List<Item>
                {
                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                        DueDate = DateTime.Parse("2015-9-11"),
                        Title = "Assignment 1 - Topic 1",
                        Percentage = 20,
                        Type = AssignmentTypes.Assignment
                    },
                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                        DueDate = DateTime.Parse("2015-11-11"),
                        Title = "Assignment 2 - Topic 3-5",
                        Percentage = 20,
                        Type = AssignmentTypes.Assignment
                    },
                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                        DueDate = DateTime.Parse("2015-9-24"),
                        Title = "Test 1 - Topic 1",
                        Percentage = 60,
                        Type = AssignmentTypes.Test
                    },


                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                        DueDate = DateTime.Parse("2015-9-11"),
                        Title = "PDEs",
                        Percentage = 60,
                        Type = AssignmentTypes.Test
                    },
                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                        DueDate = DateTime.Parse("2014-11-11"),
                        Title = "ODEs",
                        Percentage = 40,
                        Type = AssignmentTypes.Test
                    },
                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        DueDate = DateTime.Parse("2015-3-24"),
                        Title = "Lab 1",
                        Percentage = 25,
                        Type = AssignmentTypes.Lab
                    },

                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        DueDate = DateTime.Parse("2015-4-23"),
                        Title = "Lab 2",
                        Percentage = 25,
                        Type = AssignmentTypes.Lab
                    },

                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        DueDate = DateTime.Parse("2015-5-22"),
                        Title = "Lab 3",
                        Percentage = 25,
                        Type = AssignmentTypes.Lab
                    },

                    new Item
                    {
                        CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                        DueDate = DateTime.Parse("2015-6-20"),
                        Title = "Lab 4",
                        Percentage = 25,
                        Type = AssignmentTypes.Lab
                    },
                };

                items.ForEach(s => context.Items.AddOrUpdate(p => p.Title, s));
                context.SaveChanges();



            }
        }

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ContosoFinalContext() : base("name=ContosoFinalContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContosoFinalContext, MyConfiguration>());
        }

        public System.Data.Entity.DbSet<ContosoFinal.Models.Course> Courses { get; set; }

        public System.Data.Entity.DbSet<ContosoFinal.Models.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<ContosoFinal.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<ContosoFinal.Models.Item> Items { get; set; }
    }
}
