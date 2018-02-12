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
        public double rri;
        public DateTime timestamp;

        public RRI(int user_dix, double rri, DateTime timestamp)
        {
            this.user_idx = user_dix;
            this.rri = rri;
            this.timestamp = timestamp;
        }
    }

    public struct GSR
    {
        public int user_idx;
        public int gsr;
        public DateTime timestamp;

        public GSR(int user_dix, int gsr, DateTime timestamp)
        {
            this.user_idx = user_dix;
            this.gsr = gsr;
            this.timestamp = timestamp;
        }
    }

    public struct STRESS
    {
        public int user_idx;
        public int stress;
        public DateTime timestamp;

        public STRESS(int user_dix, int stress, DateTime timestamp)
        {
            this.user_idx = user_dix;
            this.stress = stress;
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
        public List<GSR> list_GSR = new List<GSR>();
        public List<STRESS> list_STRESS = new List<STRESS>();
        public List<USER> list_USER = new List<USER>();

        public void FakeDataGenerator()
        {
            Random r = new Random();
            // ACC data
            {
                for (int d = 9; d < 14; d++)
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
                                DateTime timestamp = new DateTime(2017, 10, d, h, m, s);
                                list_ACC.Add(new ACC(user_idx, x, y, z, timestamp));
                            }
                        }
                    }

                }
            }

            //BPM data
            {
                for (int d = 9; d < 14; d++)
                {
                    for (int h = 0; h < 24; h++)
                    {
                        for (int m = 0; m < 60; m++)
                        {
                            for (int s = 0; s < 60; s++)
                            {
                                int user_idx = 1;
                                int bpm = r.Next(0, 200);
                                DateTime timestamp = new DateTime(2017, 10, d, h, m, s);
                                list_BPM.Add(new BPM(user_idx, bpm, timestamp));
                            }
                        }
                    }
                }
            }

            //RRI data
            {
                for (int d = 9; d < 14; d++)
                {
                    for (int h = 0; h < 24; h++)
                    {
                        for (int m = 0; m < 60; m++)
                        {
                            for (int s = 0; s < 60; s++)
                            {
                                int user_idx = 1;
                                double rri = r.NextDouble();
                                DateTime timestamp = new DateTime(2017, 10, d, h, m, s);
                                list_RRI.Add(new RRI(user_idx, rri, timestamp));
                            }
                        }
                    }
                }
            }

            //User info data
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

        public void SelectUsingReader()
        {
            string strConn = "Server=localhost;Database=aptp;Uid=aptp;Pwd=aptp1100;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();
                string sql_ACC = "SELECT * FROM ACC";
                MySqlCommand cmd_ACC = new MySqlCommand(sql_ACC, conn);
                MySqlDataReader rdr_ACC = cmd_ACC.ExecuteReader();
                while (rdr_ACC.Read())
                {
                    int user_idx = rdr_ACC.GetInt32(rdr_ACC.GetOrdinal("user_idx"));
                    double x = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("x"));
                    double y = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("y"));
                    double z = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("z"));
                    DateTime timestamp = rdr_ACC.GetDateTime(rdr_ACC.GetOrdinal("timestamp"));
                    int k = timestamp.Hour * 60 * 60 + timestamp.Minute * 60 + timestamp.Second;
                    int d = timestamp.Day - 9;
                    list_ACC[d * 24 * 60 * 60 + k] = new ACC(user_idx, x, y, z, timestamp);
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
                    int k = timestamp.Hour * 60 * 60 + timestamp.Minute * 60 + timestamp.Second;
                    int d = timestamp.Day - 9;
                    list_BPM[d * 24 * 60 * 60 + k] = new BPM(user_idx, bpm, timestamp);
                }
                rdr_BPM.Close();

                string sql_RRI = "SELECT * FROM RRI";
                MySqlCommand cmd_RRI = new MySqlCommand(sql_RRI, conn);
                MySqlDataReader rdr_RRI = cmd_RRI.ExecuteReader();
                while (rdr_RRI.Read())
                {
                    int user_idx = rdr_RRI.GetInt32(rdr_RRI.GetOrdinal("user_idx"));
                    double rri = rdr_RRI.GetDouble(rdr_RRI.GetOrdinal("rri"));
                    DateTime timestamp = rdr_RRI.GetDateTime(rdr_RRI.GetOrdinal("timestamp"));
                    int k = timestamp.Hour * 60 * 60 + timestamp.Minute * 60 + timestamp.Second;
                    int d = timestamp.Day - 9;
                    list_RRI[d * 24 * 60 * 60 + k] = new RRI(user_idx, rri, timestamp);
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
                    double weight = rdr_USER.GetDouble(rdr_USER.GetOrdinal("height"));
                    double height = rdr_USER.GetDouble(rdr_USER.GetOrdinal("weight"));
                    DateTime signup_time = rdr_USER.GetDateTime(rdr_USER.GetOrdinal("signup_time"));
                    list_USER.Add(new USER(idx, email, password, name, gender, height, weight, signup_time));
                }
                rdr_USER.Close();

            }
        }

        public void Realtime_SelectUsingReader(int user_id)
        {
            string strConn = "Server=localhost;Database=aptp;Uid=aptp;Pwd=aptp1100;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                list_ACC.Clear();
                list_BPM.Clear();
                list_RRI.Clear();
                list_GSR.Clear();
                list_STRESS.Clear();

                conn.Open();


                int acc_length;
                string sql_ACC_LENGTH = "SELECT count(*) from ACC where user_idx = " + user_id.ToString();
                MySqlCommand cmd_ACC_LENGTH = new MySqlCommand(sql_ACC_LENGTH, conn);
                acc_length = Convert.ToInt32(cmd_ACC_LENGTH.ExecuteScalar());

                string sql_ACC;
                if (acc_length < 60)
                    sql_ACC = "SELECT * FROM ACC where user_idx = " + user_id.ToString() + " LIMIT 0," + acc_length;
                else
                    sql_ACC = "SELECT * FROM ACC where user_idx = " + user_id.ToString() + " LIMIT " + (acc_length - 60) + ",60";

                MySqlCommand cmd_ACC = new MySqlCommand(sql_ACC, conn);
                MySqlDataReader rdr_ACC = cmd_ACC.ExecuteReader();
                while (rdr_ACC.Read())
                {
                    int user_idx = rdr_ACC.GetInt32(rdr_ACC.GetOrdinal("user_idx"));
                    double x = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("x"));
                    double y = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("y"));
                    double z = rdr_ACC.GetDouble(rdr_ACC.GetOrdinal("z"));
                    DateTime timestamp = rdr_ACC.GetDateTime(rdr_ACC.GetOrdinal("timestamp"));

                    list_ACC.Add(new ACC(user_idx, x, y, z, timestamp));
                }
                rdr_ACC.Close();


                int bpm_length;
                string sql_BPM_LENGTH = "SELECT count(*) from BPM where user_idx = " + user_id.ToString();
                MySqlCommand cmd_BPM_LENGTH = new MySqlCommand(sql_BPM_LENGTH, conn);
                bpm_length = Convert.ToInt32(cmd_BPM_LENGTH.ExecuteScalar());

                string sql_BPM;
                if (acc_length < 60)
                    sql_BPM = "SELECT * FROM BPM where user_idx = " + user_id.ToString() + " LIMIT 0," + bpm_length;
                else
                    sql_BPM = "SELECT * FROM BPM where user_idx = " + user_id.ToString() + " LIMIT " + (bpm_length - 60) + ",60";

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


                int rri_length;
                string sql_RRI_LENGTH = "SELECT count(*) from RRI where user_idx = " + user_id.ToString();
                MySqlCommand cmd_RRI_LENGTH = new MySqlCommand(sql_RRI_LENGTH, conn);
                rri_length = Convert.ToInt32(cmd_RRI_LENGTH.ExecuteScalar());

                string sql_RRI;
                if (rri_length < 60)
                    sql_RRI = "SELECT * FROM RRI where user_idx = " + user_id.ToString() + " LIMIT 0," + rri_length;
                else
                    sql_RRI = "SELECT * FROM RRI where user_idx = " + user_id.ToString() + " LIMIT " + (rri_length - 60) + ",60";

                MySqlCommand cmd_RRI = new MySqlCommand(sql_RRI, conn);
                MySqlDataReader rdr_RRI = cmd_RRI.ExecuteReader();
                while (rdr_RRI.Read())
                {
                    int user_idx = rdr_RRI.GetInt32(rdr_RRI.GetOrdinal("user_idx"));
                    double rri = rdr_RRI.GetDouble(rdr_RRI.GetOrdinal("rri"));
                    DateTime timestamp = rdr_RRI.GetDateTime(rdr_RRI.GetOrdinal("timestamp"));

                    list_RRI.Add(new RRI(user_idx, rri, timestamp));
                }
                rdr_RRI.Close();


                int gsr_length;
                string sql_GSR_LENGTH = "SELECT count(*) from GSR where user_idx = " + user_id.ToString();
                MySqlCommand cmd_GSR_LENGTH = new MySqlCommand(sql_GSR_LENGTH, conn);
                gsr_length = Convert.ToInt32(cmd_GSR_LENGTH.ExecuteScalar());

                string sql_GSR;
                if (gsr_length < 60)
                    sql_GSR = "SELECT * FROM GSR where user_idx = " + user_id.ToString() + " LIMIT 0," + gsr_length;
                else
                    sql_GSR = "SELECT * FROM GSR where user_idx = " + user_id.ToString() + " LIMIT " + (gsr_length - 60) + ",60";

                MySqlCommand cmd_GSR = new MySqlCommand(sql_GSR, conn);
                MySqlDataReader rdr_GSR = cmd_GSR.ExecuteReader();
                while (rdr_GSR.Read())
                {
                    int user_idx = rdr_GSR.GetInt32(rdr_GSR.GetOrdinal("user_idx"));
                    int gsr = rdr_GSR.GetInt32(rdr_GSR.GetOrdinal("gsr"));
                    DateTime timestamp = rdr_GSR.GetDateTime(rdr_GSR.GetOrdinal("timestamp"));

                    list_GSR.Add(new GSR(user_idx, gsr, timestamp));
                }
                rdr_GSR.Close();

                // ******************************* stress는 table 값 명에 따라 수정 필요
                int stress_length;
                string sql_stress_LENGTH = "SELECT count(*) from stless where user_idx = " + user_id.ToString();
                MySqlCommand cmd_stress_LENGTH = new MySqlCommand(sql_stress_LENGTH, conn);
                stress_length = Convert.ToInt32(cmd_stress_LENGTH.ExecuteScalar());

                string sql_stress;
                if (stress_length < 60)
                    sql_stress = "SELECT * FROM stless where user_idx = " + user_id.ToString() + " LIMIT 0," + stress_length;
                else
                    sql_stress = "SELECT * FROM stless where user_idx = " + user_id.ToString() + " ORDER BY timestamp ASC LIMIT " + (stress_length - 60) + ",60";

                MySqlCommand cmd_stress = new MySqlCommand(sql_stress, conn);
                MySqlDataReader rdr_stress = cmd_stress.ExecuteReader();
                while (rdr_stress.Read())
                {
                    int user_idx = rdr_stress.GetInt32(rdr_stress.GetOrdinal("user_idx"));
                    int stress = rdr_stress.GetInt32(rdr_stress.GetOrdinal("stress_value"));
                    String strDate = rdr_stress.GetString(rdr_stress.GetOrdinal("timestamp"));
                    strDate.Trim();
                    DateTime timestamp = Convert.ToDateTime(strDate);

                    list_STRESS.Add(new STRESS(user_idx, stress, timestamp));
                }
                rdr_stress.Close();

            }
        }

        public void Realtime_SelectUserInfoUsingReader()
        {
            string strConn = "Server=localhost;Database=aptp;Uid=aptp;Pwd=aptp1100;";

            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                conn.Open();

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
                    double weight = rdr_USER.GetDouble(rdr_USER.GetOrdinal("height"));
                    double height = rdr_USER.GetDouble(rdr_USER.GetOrdinal("weight"));
                    DateTime signup_time = rdr_USER.GetDateTime(rdr_USER.GetOrdinal("signup_time"));
                    list_USER.Add(new USER(idx, email, password, name, gender, height, weight, signup_time));
                }
                rdr_USER.Close();
            }

        }

        public void Realtime_FakeUserInfoGenerator()
        {
            //User info data
            {
                int idx = 1;
                string email = "elleinuo0@gmail.com";
                string password = "qwer1234";
                string name = "Handong Kim";
                int gender = 1;
                double weight = 69.7;
                double height = 173.4;
                DateTime signup_time = DateTime.Now;
                list_USER.Add(new USER(idx, email, password, name, gender, height, weight, signup_time));

                idx = 2;
                email = "chj4219@gmail.com";
                password = "asdf2345";
                name = "Handong Choi";
                gender = 2;
                weight = 53.3;
                height = 168.1;
                signup_time = DateTime.Now;
                list_USER.Add(new USER(idx, email, password, name, gender, height, weight, signup_time));

                idx = 3;
                email = "wbqd@gmail.com";
                password = "zxcv3456";
                name = "Handong Jung";
                gender = 1;
                weight = 78.1;
                height = 181.2;
                signup_time = DateTime.Now;
                list_USER.Add(new USER(idx, email, password, name, gender, height, weight, signup_time));
            }
        }

        public void Realtime_FakeDataGenerator(int given_idx)
        {
            if(list_ACC.Count == 0)
            {
                Random r = new Random();
                DateTime cur_time = DateTime.Now;

                // ACC data
                {
                    for (DateTime time = cur_time.AddSeconds(-60); time < cur_time; time = time.AddSeconds(1))
                    {
                        int user_idx = given_idx;
                        double x = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                        double y = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                        double z = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                        list_ACC.Add(new ACC(user_idx, x, y, z, time));
                    }
                }

                //BPM data
                {
                    for (DateTime time = cur_time.AddSeconds(-60); time < cur_time; time = time.AddSeconds(1))
                    {
                        int user_idx = given_idx;
                        int bpm = r.Next(0, 200);
                        list_BPM.Add(new BPM(user_idx, bpm, time));
                    }
                }

                //RRI data
                {
                    for (DateTime time = cur_time.AddSeconds(-60); time < cur_time; time = time.AddSeconds(1))
                    {
                        int user_idx = given_idx;
                        double rri = r.NextDouble();
                        list_RRI.Add(new RRI(user_idx, rri, time));
                    }
                }

                //GSR data
                {
                    for (DateTime time = cur_time.AddSeconds(-60); time < cur_time; time = time.AddSeconds(1))
                    {
                        int user_idx = given_idx;
                        int gsr = r.Next(0, 5000);
                        list_GSR.Add(new GSR(user_idx, gsr, time));
                    }
                }

                {
                    for (DateTime time = cur_time.AddSeconds(-60); time < cur_time; time = time.AddSeconds(1))
                    {
                        int user_idx = given_idx;
                        int stress = r.Next(0, 100);
                        list_STRESS.Add(new STRESS(user_idx, stress, time));
                    }
                }
            }
            else
            {
                list_ACC.RemoveAt(0);
                list_BPM.RemoveAt(0);
                list_RRI.RemoveAt(0);
                list_GSR.RemoveAt(0);
                list_STRESS.RemoveAt(0);

                Random r = new Random();
                DateTime cur_time = DateTime.Now;

                int user_idx = given_idx;
                double x = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                double y = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                double z = r.Next() % 2 == 0 ? r.NextDouble() : r.NextDouble() * -1;
                list_ACC.Add(new ACC(user_idx, x, y, z, cur_time));

                int bpm = r.Next(0, 200);
                list_BPM.Add(new BPM(user_idx, bpm, cur_time));

                double rri = r.NextDouble();
                list_RRI.Add(new RRI(user_idx, rri, cur_time));

                int gsr = r.Next(0, 5000);
                list_GSR.Add(new GSR(user_idx, gsr, cur_time));

                int stress = r.Next(0, 100);
                list_STRESS.Add(new STRESS(user_idx, stress, cur_time));
            }
        }        
    }
}