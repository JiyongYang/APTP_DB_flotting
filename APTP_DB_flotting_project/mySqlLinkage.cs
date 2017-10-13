using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace APTP_DB_flotting_project
{
    struct ACC
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

    struct BPM
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

    struct RRI
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

    struct USER
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

    class mySqlLinkage
    {
        List<ACC> list_ACC = new List<ACC>();
        List<BPM> list_BPM = new List<BPM>();
        List<RRI> list_RRI = new List<RRI>();
        List<USER> list_USER = new List<USER>();

        public void SelectUsingReader()
        {
            string strConn = "Server=localhost;Database=aptp;Uid=aptp;Pwd=aptp1000;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql_ACC = "SELECT * FROM ACC";

                MySqlCommand cmd = new MySqlCommand(sql_ACC, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    int user_idx = rdr.GetInt32(rdr.GetOrdinal("user_idx"));
                    double x = rdr.GetDouble(rdr.GetOrdinal("x"));
                    double y = rdr.GetDouble(rdr.GetOrdinal("y"));
                    double z = rdr.GetDouble(rdr.GetOrdinal("z"));
                    DateTime timestamp = rdr.GetDateTime(rdr.GetOrdinal("timestamp"));
                    list_ACC.Add(new ACC(user_idx, x, y, z, timestamp));
                }
                rdr.Close();

                for (int i = 0; i < list_ACC.Count; i++)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}", list_ACC[i].user_idx, 
                        list_ACC[i].x, list_ACC[i].y, list_ACC[i].z, list_ACC[i].timestamp);
                }

                //conn.Close();
            }
        }
    }
}
