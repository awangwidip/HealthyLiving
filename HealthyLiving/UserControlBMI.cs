using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Data.Entity.Infrastructure;

namespace HealthyLiving
{
    public partial class UserControlBMI : UserControl
    {
        UserData user = new UserData();
        public UserControlBMI()
        {
            InitializeComponent();
        }
        void Clear()
        {
            textAge.Text = textName.Text = textWeight.Text = textHeight.Text = textResult.Text = "";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textName.Text = "";
            textAge.Text = "";
            textHeight.Text = "";
            textWeight.Text = "";
            textResult.Text = "";

            ManButton.Checked = false;
            WomanButton.Checked = false;
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            
            double weight, height;

            weight = Double.Parse(textWeight.Text);
            height = Double.Parse(textHeight.Text);
            double BMI = weight / (height * height);
            textResult.Text = String.Format("{0:f}", BMI);
            if (BMI < 16)
            {
                catShower.Text = "Severe underweight,\nmight be a good idea to see doctor";
            }
            else if (BMI >= 16 && BMI <= 18.5)
            {
                catShower.Text = "Underweight,\ntry adding more calorie intake";
            }
            else if (BMI > 18.5 && BMI <= 25)
            {
                catShower.Text = "BMI category normal, keep it up";
            }
            else if (BMI > 25 && BMI <= 30)
            {
                MessageBox.Show("You. Are. Overweight.");
                catShower.Text = "Overweight, try exercising more\nand reduce calorie intake";
            }
            else if (BMI > 30 && BMI <= 35)
            {
                MessageBox.Show("Caution: Obese Class 1");
                catShower.Text = "Obese Class 1,\ntry looking for personal trainer";
            }
            else if (BMI > 35 && BMI <= 40)
            {
                MessageBox.Show("You are entering dangerous category Obese Class 2");
                catShower.Text = "Obese Class 2,\ncontact personal trainer,\nand consider looking for medical treatment";
            }
            else if (BMI > 40)
            {
                MessageBox.Show("Warning! You are unhealthy");
                catShower.Text = "Obese Class 3,\nSevere obesity, seeking for\nmedical treatment is a must";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textAge_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                user.Nama = textName.Text.Trim();
                user.Height = Convert.ToDouble(textHeight.Text.Trim());
                user.Weight = Convert.ToInt32(textWeight.Text.Trim());
                user.Usia = Convert.ToInt32(textAge.Text.Trim());
                if (ManButton.Checked)
                {
                    user.Gender = 1;
                }
                else if (WomanButton.Checked)
                {
                    user.Gender = 2;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Box cannot be empty and must be in the right format");
            }
            try
            {
                using (UserDataModel db = new UserDataModel())
                {
                    db.UserDatas.Add(user);
                    db.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {
                MessageBox.Show("Data already exist");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var db = new UserDataModel())
            {
                var query = from UserData in db.UserDatas where UserData.Nama == tbLoad.Text select UserData;
                foreach (var item in query)
                {
                    textName.Text = item.Nama;
                    textHeight.Text = Convert.ToString(item.Height);
                    textWeight.Text = Convert.ToString(item.Weight);
                    textAge.Text = Convert.ToString(item.Usia);
                    if (item.Gender == 1)
                    {
                        ManButton.Checked = true;
                    }
                    else if (item.Gender == 2)
                    {
                        WomanButton.Checked = true;
                    }
                }
            }
        }
    }
}
