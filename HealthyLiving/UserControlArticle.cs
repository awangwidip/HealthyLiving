using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthyLiving
{
    public partial class UserControlArticle : UserControl
    {
        public UserControlArticle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://hellosehat.com/hidup-sehat/tips-sehat/tips-pola-hidup-sehat/");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.astaga.com/lifestyle/10-tips-ampuh-dan-alami-mencapai-berat-badan-ideal");
        }
    }
}
