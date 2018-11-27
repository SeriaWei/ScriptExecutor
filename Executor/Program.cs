using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace Executor
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = Directory.GetCurrentDirectory();
            string command = File.ReadAllText(Path.Combine(dir, "Command.sql"), System.Text.Encoding.UTF8);

            using (StreamReader reader = new StreamReader(new FileStream(Path.Combine(dir, "DbPath.txt"), FileMode.Open), System.Text.Encoding.UTF8))
            {
                string dbPah = reader.ReadLine();
                while (dbPah != null)
                {
                    Console.WriteLine(dbPah);
                    var dbs = Directory.GetFiles(dbPah, "*.sqlite");
                    foreach (var item in dbs)
                    {
                        Console.WriteLine(item);
                        try
                        {
                            Console.WriteLine(new SqliteDbContext(item).Database.ExecuteSqlCommand(command));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                    }
                    dbPah = reader.ReadLine();
                }

            }
        }
    }
    class SqliteDbContext : DbContext
    {
        public string DatabaseFile { get; set; }
        public SqliteDbContext(string file)
        {
            DatabaseFile = file;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=" + DatabaseFile);
        }
    }
}