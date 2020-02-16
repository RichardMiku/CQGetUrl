using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;
using DemoInI;
using Native.Core.Domain;

namespace Native.Core.App
{
    public class Event_DiscussMessage : IDiscussMessage
    {
        public void DiscussMessage(object sender, CQDiscussMessageEventArgs e)
        {
            InI ini = new InI(AppData.CQApi.AppDirectory + "main.ini");
            Getjson gt = new Getjson();
            string command = ini.ReadConfiguration("Command");
            string str = e.Message.Text;
            int t = command.Length;
            int s = str.Length;
            if (t < s)
            {
                string left = str.Substring(0, t);
                if (left == command)
                {
                    string a = ini.ReadConfiguration("AllUse");
                    string manager = ini.ReadConfiguration("Manager");
                    if (a == "false" | manager == e.FromQQ.ToString())
                    {
                        string sending = gt.Get(str);
                        AppData.CQApi.SendPrivateMessage(e.FromQQ, sending);
                    }
                    else
                    {
                        string sending = gt.Get(str);
                        AppData.CQApi.SendPrivateMessage(e.FromQQ, sending);
                    }
                }
            }
        }
    }
}
