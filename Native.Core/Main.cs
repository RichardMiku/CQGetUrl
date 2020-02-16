using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Native.Tool.IniConfig;
using DemoInI;
using Native.Core.Domain;

namespace Native.Core
{
    public partial class Main : MetroFramework .Forms .MetroForm 
    {
        public Main()
        {
            InitializeComponent();
        }
        InI ini = new InI(AppData.CQApi.AppDirectory + "main.ini");
        private void Main_Load(object sender, EventArgs e)
        {
            this.metroTextBox1.Text = ini.ReadConfiguration("Manager");
            this.metroTextBox2.Text = ini.ReadConfiguration("Command");
            this.metroTextBox3.Text = ini.ReadConfiguration("Url");
            string all;
            all = ini.ReadConfiguration("AllUse");
            if (all =="false")
            {
                this.metroCheckBox1.Checked = true;
            }
            else
            {
                this.metroCheckBox1.Checked = false;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            ini.WriteConfiguration("Manager", metroTextBox1.Text);
            ini.WriteConfiguration("Command", metroTextBox2.Text);
            ini.WriteConfiguration("Url", metroTextBox3.Text);
            if (metroCheckBox1 .Checked == true )
            {
                ini.WriteConfiguration("AllUse", "false");
            }
            else
            {
                ini.WriteConfiguration("AllUse", "true");
            }
            MessageBox.Show("保存成功！", "提示");
        }
    }
}
