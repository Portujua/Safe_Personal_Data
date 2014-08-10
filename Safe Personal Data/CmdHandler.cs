using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safe_Personal_Data
{
    class CmdHandler
    {
        private double packetLoss = 0;
        private int ping = 0;

        private Thread pingThread = null;
        private bool isPinging = false;

        public CmdHandler()
        {

        }

        public bool isProcessRunning(string processName)
        {
            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            /* execute "dir" */

            cmd.StandardInput.WriteLine("tasklist");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();

            using (StreamReader sr = cmd.StandardOutput)
                while (!sr.EndOfStream)
                    if (sr.ReadLine().ToUpper().Contains(processName.ToUpper()))
                        return true;


            return false;
        }

        public void closeLocalProcess(string processName)
        {
            Process cmd = new Process();

            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;

            cmd.Start();

            /* execute "dir" */

            cmd.StandardInput.WriteLine("taskkill -fi \"imagename eq " + processName + "\"");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
        }

        public void doPing(string ip)
        {
            if (!isPinging)
            {
                isPinging = true;

                pingThread = new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;

                    Process cmd = new Process();
                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.RedirectStandardInput = true;
                    cmd.StartInfo.RedirectStandardOutput = true;
                    cmd.StartInfo.CreateNoWindow = true;
                    cmd.StartInfo.UseShellExecute = false;

                    cmd.Start();

                    /* execute "dir" */

                    cmd.StandardInput.WriteLine("tasklist");
                    cmd.StandardInput.Flush();
                    cmd.StandardInput.Close();

                    using (StreamReader sr = cmd.StandardOutput)
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            if (line.Contains("perdidos"))
                                setPacketLoss(line);
                            if (line.Contains("Media"))
                                setPing(line);
                        }

                    isPinging = false;
                });

                pingThread.Start();
            }
        }

        public int getPing()
        {
            return this.ping;
        }

        public double getPacketLoss()
        {
            return this.packetLoss;
        }

        private void setPacketLoss(string line)
        {
            int i = 1;
            string packetLoss = "";

            while (line[i] != '%')            
                packetLoss += line[i];

            this.packetLoss = Convert.ToDouble(packetLoss);            
        }

        private void setPing(string line)
        {
            MessageBox.Show(line);
        }
    }
}
