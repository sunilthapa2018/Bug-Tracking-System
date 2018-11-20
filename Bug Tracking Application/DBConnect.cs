using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bug_Tracking_Application
{
    class DBConnect
    {
        private MySqlConnection connection;
        private MySqlCommand cmmd;
        private string datasource;
        private string port;
        private string database;
        private string uid;
        private string password;
        public byte[] imageByte;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            datasource = "localhost";
            port = "3306";
            database = "bugtrackerdatabase";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "DATASOURCE=" + datasource + ";" + "PORT=" + port + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "SSLMODE=none;";
            connectionString = "DATASOURCE=localhost;PORT=3306;DATABASE=bugtrackerdatabase;UID=root;PASSWORD='';SSLMODE=none;";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {                
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                        
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Execute any given query 
        public void executeQuery(String query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Execute any given query 
        public void executeQueryWithParams(String query)
        {
            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                cmmd = new MySqlCommand(query, connection);

                //Execute command
                cmmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }
        //Select statement
        public List<string>[] Select(String query,String tableName)
        {            
            //Create a list to store the result
            List<string>[] list = new List<string>[10];            
            for (int i = 0; i < 10; i++) {
                list[i] = new List<string>();
            }
            

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();                

                
                try
                {                 

                    if (dataReader.HasRows)
                    {
                        //int i = 0;
                        while (dataReader.Read())
                        {                            

                            if (tableName.Equals("bug"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3) };
                                for (int i = 0; i < 4; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("userdetails"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3),
                                    dataReader.GetString(4) };
                                for (int i = 0; i < 5; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("bugreports"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5),
                                    dataReader.GetString(6),dataReader.GetString(7)};
                                for (int i = 0; i < 8; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("project"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1) };
                                for (int i = 0; i < 2; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("bugassign"))
                            {

                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3)};
                                for (int i = 0; i < 4; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("bugsolve"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5),
                                    dataReader.GetString(6), dataReader.GetString(7), dataReader.GetString(8)};
                                for (int i = 0; i < 9; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("join")){
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3), dataReader.GetString(4), dataReader.GetString(5), dataReader.GetString(6) };
                                for (int i = 0; i < 7; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("joinType2"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3)};
                                for (int i = 0; i < 4; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("joinType3"))
                            {                                             

                                imageByte = (byte[])dataReader.GetValue(3);
                                
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3)};
                                for (int i = 0; i < 4; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("joinType4"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3),dataReader.GetString(4), dataReader.GetString(5),
                                    dataReader.GetString(6)};
                                for (int i = 0; i < 7; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            else if (tableName.Equals("joinType5"))
                            {
                                string[] row = { dataReader.GetString(0), dataReader.GetString(1), dataReader.GetString(2),
                                    dataReader.GetString(3),dataReader.GetString(4), dataReader.GetString(5),
                                    dataReader.GetString(6),dataReader.GetString(7),dataReader.GetString(8)};
                                for (int i = 0; i < 9; i++)
                                {
                                    list[i].Add(dataReader.GetString(i) + "");
                                }
                            }
                            

                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows found.");
                    }

                    //close Connection
                    this.CloseConnection();
                }
                catch (Exception ex)
                {
                    // Show any error message.
                    MessageBox.Show(ex.Message);
                }

                return list;
            }
            else
            {
                return list;
            }




            
        }

        //Count statement
        public int Count(String query)
        {
            //string query = "SELECT Count(*) FROM " + tableName;
            int Count = -1;

            //Open Connection
            if (this.OpenConnection() == true)
            {
                //Create Mysql Command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                //close Connection
                this.CloseConnection();

                return Count;
            }
            else
            {
                return Count;
            }
        }
    }
}
