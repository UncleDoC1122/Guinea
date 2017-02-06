using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Guinea
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> rawInfo = SiteDownloader.getter();

            //File.Create("D:\\Test.txt");

            for (int i = 0; i < rawInfo.Count; i++)
            {
                File.AppendAllText("D:\\Test.txt", rawInfo[i] + "/n");
            }

            ExcelPutter.put(rawInfo);
        }
    }
}
