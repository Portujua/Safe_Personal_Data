using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Safe_Personal_Data
{
    class ConnectionHandler
    {
        public const long HIGH_PING = 250;
        public const double HIGH_PACKET_LOSS = 5;

        private const int COLOR_GREEN = 0x007201;
        private const int COLOR_YELLOW = 0xFFD000;
        private const int COLOR_RED = 0xFF1905;

        private const int PINGS_TO_CALCULATE_LOSS = 10;

        private string ip = "www.google.com";
        private List<PingReply> pings = new List<PingReply>();
        private long lastAvgPing;
        private double lastPacketLoss;

        public ConnectionHandler()
        {

        }

        public void setIp(string ip)
        {
            this.ip = ip;
        }

        public void resetPingList()
        {
            pings = new List<PingReply>();
        }

        public void startPinging()
        {
            using (Ping thisPing = new Ping())
            {
                PingReply pr = thisPing.Send(ip);

                if (pings.Count < 100)
                    pings.Add(pr);
                else
                {
                    List<PingReply> newPings = new List<PingReply>();
                    for (int i = 1; i < pings.Count; i++)
                        newPings.Add(pings[i]);
                    newPings.Add(pr);
                    pings = newPings;
                }   
            }
        }

        public string getPing()
        {
            if (pings.Count == 0) return "Calculando..";

            long pingTotalXi = 0;
            long maxPing = 0;
            long minPing = 0;

            foreach (PingReply reply in pings)
            {
                pingTotalXi += reply.RoundtripTime;

                if (reply.RoundtripTime > maxPing)
                    maxPing = reply.RoundtripTime;
                if (reply.RoundtripTime < minPing)
                    minPing = reply.RoundtripTime;
            }

            lastAvgPing = Convert.ToInt32(pingTotalXi / pings.Count);

            return lastAvgPing.ToString() + " ± " + Convert.ToInt32((minPing + maxPing) / 2);            
        }

        public Color getLabelColor()
        {
            if (lastAvgPing < 150 && lastPacketLoss < HIGH_PACKET_LOSS)
                return Color.FromArgb(COLOR_GREEN);
            else if (lastAvgPing < 250 && lastPacketLoss < HIGH_PACKET_LOSS)
                return Color.FromArgb(COLOR_YELLOW);
            else
                return Color.FromArgb(COLOR_RED);
        }

        public double getPacketLoss()
        {
            if (pings.Count == 0) return 0;

            int succeed = 0;
            int failed = 0;
            /* Usar solo los ultimos 10
            if (pings.Count > PINGS_TO_CALCULATE_LOSS)
            {
                for (int i = pings.Count - PINGS_TO_CALCULATE_LOSS - 1; i < pings.Count; i++)
                    if (pings[i].Status == IPStatus.Success)
                        succeed++;
                    else
                        failed++;

                lastPacketLoss = (failed * 100) / PINGS_TO_CALCULATE_LOSS;
            }
            else
            {
                foreach (PingReply reply in pings)
                    if (reply.Status == IPStatus.Success)
                        succeed++;
                    else
                        failed++;

                lastPacketLoss = (failed * 100) / pings.Count;
            }
            */

            /* Usar todos */
            foreach (PingReply reply in pings)
                if (reply.Status == IPStatus.Success)
                    succeed++;
                else
                    failed++;

            lastPacketLoss = (failed * 100) / pings.Count;
            return lastPacketLoss;
        }

        public long getLastPing()
        {
            return lastAvgPing;
        }

        public double getLastPacketLoss()
        {
            return lastPacketLoss;
        }
    }
}
