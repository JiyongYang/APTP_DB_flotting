﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APTP_DB_flotting_project
{

    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            mySqlLinkage _mySqlLinkage = new mySqlLinkage();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            APTP_Application form = new APTP_Application(_mySqlLinkage);
            Application.Run(form);
        }

        //mysql로부터 불러온 데이터를 추가하는 루틴

    }
}
