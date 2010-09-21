using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Mon1.CLI
{
    public class CLITask
    {
        public string ExecutableLocation { get; set; }
        public string WorkingDirectory { get; set; }
        public string CLICommand { get; set; }
        public string Parameters { get; set; }
        public string Scriptblock { get; set; }
        public string Logfile { get; set; }

        public static bool Execute(string ls,string mh, string newtext)
        {
            const string Logfile = "c:\\temp\\testing.log";
            string retMessage = String.Empty;

            if (System.IO.File.Exists(Logfile)) { 
                  System.IO.File.Delete(Logfile);
            }
            Process p = new Process();
            p.StartInfo.UseShellExecute= false;
            p.StartInfo.RedirectStandardOutput= true;
            p.StartInfo.Arguments = " " + ls + " " + mh + " " + "\"" + newtext + "\"";
            p.StartInfo.WorkingDirectory= "e:\\clikit\\vnmsh";
            p.StartInfo.FileName = "CLITask.exe";
            //p.OutputDataReceived += (sender, e) =>
            //{
             //   var s = (e.Data == "")? "foooo\r\n": e.Data;
              // System.IO.File.WriteAllText(Logfile, s);
               //retMessage = String.Format("Received output: {0} ", s);
            //};
            try
            {
                p.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("NotesController: " + e.Message);
                return false;
            }
            p.BeginOutputReadLine();
            return true;
        }
    }
}