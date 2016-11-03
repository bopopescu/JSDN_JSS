using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace JSE
{
    class CompilePython
    {
        /// <summary>
        /// Compile Python, Console Log 기록과 source 파일 위치를 가져온다.
        /// </summary>
        /// <param name="source">source 파일의 위치이다.</param>
        /// <returns></returns>
        public string Compile(string source) 
        {
            ProcessStartInfo proInfo = new ProcessStartInfo();
            Process pro = new Process();
            proInfo.FileName = @"cmd";
            proInfo.CreateNoWindow = false;
            proInfo.UseShellExecute = false;
            proInfo.RedirectStandardOutput = true;
            proInfo.RedirectStandardInput = true;
            proInfo.RedirectStandardError = true;
            pro.StartInfo = proInfo;
            pro.Start();
            pro.StandardInput.Write(Application.StartupPath + @"\Python27\python " + source);//ex> D:\Desktop\Python27\python test1.py
            pro.Close();
            string returnVal = pro.StandardOutput.ReadToEnd();
            string filename = source;
//            var result = Tuple.Create(returnVal,filename);
            return returnVal;
        }
    }
}
