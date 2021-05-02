using HCL.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.IO;

namespace HCL.DAL
{
    public class Database:IDisposable
    {
        public SQLiteConnection myConnection;
        public Database()
        {

            if (!File.Exists("./database.sqlite3"))
            {
                SQLiteConnection.CreateFile("database.sqlite3");
                System.Console.WriteLine("Database file created");

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS [User] (
                          [UserId] VARCHAR(40) NOT NULL PRIMARY KEY,
                          [PCode] VARCHAR(1000) NULL,
                          [FirstName] VARCHAR(100) NULL,
                          [LastName] VARCHAR(100) NULL,
                          [Email] VARCHAR(100) NULL,
                          [IsActive] BIT NULL
                          )";
                string dbfullpath = Path.GetFullPath("database.sqlite3");

                myConnection = new SQLiteConnection(@"Data Source=C:\Users\Sita Ramudu\Source\Repos\UserManagement\HCL.DAL\AppData\database.sqlite3");
                using (SQLiteCommand com = new SQLiteCommand(myConnection))
                {
                    OpenConnection();                   // Open the connection to the database

                    com.CommandText = createTableQuery;     // Set CommandText to our query that will create the table
                    com.ExecuteNonQuery();                  // Execute the query

                    CloseConnection();      // Close the connection to the database
                }

            }
            else
            {
                string dbfullpath = Path.GetFullPath("database.sqlite3");

                myConnection = new SQLiteConnection(@"Data Source=C:\Users\Sita Ramudu\Source\Repos\UserManagement\HCL.DAL\AppData\database.sqlite3");

            }
        }

        public void OpenConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (myConnection.State != System.Data.ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }

        public int ExecuteWrite(string query, Dictionary<string, object> args)
        {
            int numberOfRowsAffected;


            OpenConnection();

            //open a new command
            using (var cmd = new SQLiteCommand(query, myConnection))
            {
                //set the arguments given in the query
                foreach (var pair in args)
                {
                    cmd.Parameters.AddWithValue(pair.Key, pair.Value);
                }

                //execute the query and get the number of row affected
                numberOfRowsAffected = cmd.ExecuteNonQuery();
            }
            CloseConnection();

            return numberOfRowsAffected;
        }

        public DataTable Execute(string query, IDictionary<string,object> args = null)
        {
            if (string.IsNullOrEmpty(query.Trim()))
                return null;


            OpenConnection();
            using (var cmd = new SQLiteCommand(query, myConnection))
            {
                if (args?.Count > 0)
                {
                    foreach (KeyValuePair<string, object> entry in args)
                    {
                        cmd.Parameters.AddWithValue(entry.Key, entry.Value);
                    }
                }

                var da = new SQLiteDataAdapter(cmd);

                var dt = new DataTable();
                da.Fill(dt);

                da.Dispose();
                return dt;
            }
        }


        #region IDisposable Support

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
    }

    public class ApplicationDBContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Chinook Database does not pluralize table names
            modelBuilder.Conventions
                .Remove<PluralizingTableNameConvention>();
        }
    }
}
