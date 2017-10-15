using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace APTP_DB_flotting_project
{
    public struct ACC
    {
        public int user_idx;
        public double x;
        public double y;
        public double z;
        public DateTime timestamp;

        public ACC(int user_idx, double x, double y, double z, DateTime timestamp)
        {
            this.user_idx = user_idx;
            this.x = x;
            this.y = y;
            this.z = z;
            this.timestamp = timestamp;
        }
    }

    public struct BPM
    {
        public int user_idx;
        public int bpm;
        public DateTime timestamp;

        public BPM(int user_idx, int bpm, DateTime timestamp)
        {
            this.user_idx = user_idx;
            this.bpm = bpm;
            this.timestamp = timestamp;
        }
    }

    public struct RRI
    {
        public int user_idx;
        public int rri;
        public DateTime timestamp;

        public RRI(int user_dix, int rri, DateTime timestamp)
        {
            this.user_idx = user_dix;
            this.rri = rri;
            this.timestamp = timestamp;
        }
    }

    public struct USER
    {
        public int idx;
        public string email;
        public string password;
        public string name;
        public int gender;
        public double height;
        public double weight;
        public DateTime signup_time;

        public USER(int idx, string email, string password, string name, 
            int gender, double height, double weight, DateTime signup_time)
        {
            this.idx = idx;
            this.email = email;
            this.password = password;
            this.name = name;
            this.gender = gender;
            this.height = height;
            this.weight = weight;
            this.signup_time = signup_time;
        }
    }

    public class mySqlLinkage
    {
        public List<ACC> list_ACC = new List<ACC>();
        public List<BPM> list_BPM = new List<BPM>();
        public List<RRI> list_RRI = new List<RRI>();
        public List<USER> list_USER = new List<USER>();

        public void SelectUsingReader()
        {
            string strConn = "Server=localhost;Database=aptp;Uid=aptp;Pwd=aptp1000;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql_ACC = "SELECT * FROM ACC";
                MySqlCommand cmd_ACC = new MySqlCommand(sql_ACC, conn);
                MySqlDataReader rdr_ACC = cmd_ACC.ExecuteReader();
                while(rdr_ACC.Read())
                {
                    int user_idx = rdr_ACC.GetInt32(rdr_ACC.GetOrdinal("user_idx"));
                    double x = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("x"));
                    double y = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("y"));
                    double z = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("z"));
                    DateTime timestamp = rdr_ACC.GetDateTime(rdr_ACC.GetOrdinal("timestamp"));
                    list_ACC.Add(new ACC(user_idx, x, y, z, timestamp));
                }
                rdr_ACC.Close();

                string sql_BPM = "SELECT * FROM BPM";
                MySqlCommand cmd_BPM = new MySqlCommand(sql_BPM, conn);
                MySqlDataReader rdr_BPM = cmd_BPM.ExecuteReader();
                while (rdr_BPM.Read())
                {
                    int user_idx = rdr_BPM.GetInt32(rdr_BPM.GetOrdinal("user_idx"));
                    int bpm = rdr_BPM.GetInt32(rdr_BPM.GetOrdinal("bpm"));
                    DateTime timestamp = rdr_BPM.GetDateTime(rdr_BPM.GetOrdinal("timestamp"));
                    list_BPM.Add(new BPM(user_idx, bpm, timestamp));
                }
                rdr_BPM.Close();

                string sql_RRI = "SELECT * FROM RRI";
                MySqlCommand cmd_RRI = new MySqlCommand(sql_RRI, conn);
                MySqlDataReader rdr_RRI = cmd_RRI.ExecuteReader();
                while (rdr_RRI.Read())
                {
                    int user_idx = rdr_RRI.GetInt32(rdr_RRI.GetOrdinal("user_idx"));
                    int rri = rdr_RRI.GetInt32(rdr_RRI.GetOrdinal("rri"));
                    DateTime timestamp = rdr_RRI.GetDateTime(rdr_RRI.GetOrdinal("timestamp"));
                    list_RRI.Add(new RRI(user_idx, rri, timestamp));
                }
                rdr_RRI.Close();

                string sql_USER = "SELECT * FROM USER";
                MySqlCommand cmd_USER = new MySqlCommand(sql_USER, conn);
                MySqlDataReader rdr_USER = cmd_USER.ExecuteReader();
                while (rdr_USER.Read())
                {
                    int idx = rdr_USER.GetInt32(rdr_USER.GetOrdinal("idx"));
                    string email = rdr_USER.GetString(rdr_USER.GetOrdinal("email"));
                    string password = rdr_USER.GetString(rdr_USER.GetOrdinal("password"));
                    string name = rdr_USER.GetString(rdr_USER.GetOrdinal("name"));
                    int gender = rdr_USER.GetInt32(rdr_USER.GetOrdinal("gender"));
                    double weight = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("height"));
                    double height = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("weight"));
                    DateTime signup_time = rdr_USER.GetDateTime(rdr_USER.GetOrdinal("signup_time"));
                    list_USER.Add(new USER(idx, email, password, name, gender, height, weight, signup_time));
                }
                rdr_USER.Close();

                // for test
                /*
                Console.WriteLine("ACC");
                for (int i = 0; i < list_ACC.Count; i++)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", list_ACC[i].user_idx, 
                        list_ACC[i].x, list_ACC[i].y, list_ACC[i].z, list_ACC[i].timestamp);
                }

                Console.WriteLine("\nBPM");
                for (int i = 0; i < list_BPM.Count; i++)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", list_BPM[i].user_idx,
                        list_BPM[i].bpm, list_BPM[i].timestamp);
                }

                Console.WriteLine("\nRRI");
                for (int i = 0; i < list_RRI.Count; i++)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", list_RRI[i].user_idx,
                        list_RRI[i].rri, list_RRI[i].timestamp);
                }

                Console.WriteLine("\nUSER");
                for (int i = 0; i < list_USER.Count; i++)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", list_USER[i].idx,
                        list_USER[i].email, list_USER[i].password, list_USER[i].name, list_USER[i].gender, list_USER[i].height, list_USER[i].weight, list_USER[i].signup_time);
                }
                */
                //conn.Close();
            }
        }

        public void FakeDataGenerator()
        {
            Random r = new Random();
            // ACC data
            {
                for (int h = 0; h < 24; h++)
                {
                    for (int m = 0; m < 60; m++)
                    {
                        for (int s = 0; s < 60; s++)
                        {
                            int user_idx = 1;
                            double x = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                            double y = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                            double z = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                            DateTime timestamp = new DateTime(2017, 10, r.Next() %4 + 10, h, m, s);
                            list_ACC.Add(new ACC(user_idx, x, y, z, timestamp));
                        }
                    }
                }
            }

            {
                for (int h = 0; h < 24; h++)
                {
                    for (int m = 0; m < 60; m++)
                    {
                        for (int s = 0; s < 60; s++)
                        {
                            int user_idx = 1;
                            int bpm = r.Next(50, 110);
                            DateTime timestamp = new DateTime(2017, 10, 14, h, m, s);
                            list_BPM.Add(new BPM(user_idx, bpm, timestamp));
                        }
                    }
                }
            }

            {
                for (int h = 0; h < 24; h++)
                {
                    for (int m = 0; m < 60; m++)
                    {
                        for (int s = 0; s < 60; s++)
                        {
                            int user_idx = 1;
                            int rri = r.Next(50, 110);
                            DateTime timestamp = new DateTime(2017, 10, 14, h, m, s);
                            list_RRI.Add(new RRI(user_idx, rri, timestamp));
                        }
                    }
                }
            }

            {
                int idx = 1;
                string email = "elleinuo0@gmail.com";
                string password = "qwer1234";
                string name = "Handong Kim";
                int gender = 1;
                double weight = 69.7;
                double height = 173.4;
                DateTime signup_time = new DateTime(2017, 10, 14);
                list_USER.Add(new USER(idx, email, password, name, gender, height, weight, signup_time));
            }
        }
    }
}
