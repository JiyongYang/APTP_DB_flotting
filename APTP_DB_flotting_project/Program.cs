using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

    public class MySqlLinkage
    {
        List<ACC> list_ACC = new List<ACC>();
        List<BPM> list_BPM = new List<BPM>();
        List<RRI> list_RRI = new List<RRI>();
        List<USER> list_USER = new List<USER>();

    }

    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            mySqlLinkage _mySqlLinkage = new mySqlLinkage();
            _mySqlLinkage.SelectUsingReader();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MySqlLinkage msl = new MySqlLinkage();
            Visualizer form = new Visualizer();
            Application.Run(form);
        }

        //mysql로부터 불러온 데이터를 추가하는 루틴
        //form.tabControl1.SelectedIndex => 0: acc, 1: bpm, 2: rri

    }
}
