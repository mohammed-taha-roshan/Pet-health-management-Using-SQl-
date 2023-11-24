using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Pethealthmanagement
{
    public partial class Logi : Form
    {
        public Logi()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K63CD7V;Initial Catalog=petHelDB;Integrated Security=True");
        int key = 0;
        public static string Role;
        private void LogRes_Click(object sender, EventArgs e)
        {
            LogRole.SelectedIndex = 0;
            LogName.Text = "";
            LogPass.Text = "";
        }

        private void LogBtn_Click(object sender, EventArgs e)
        {
            if (LogRole.SelectedIndex == -1)
            {
                MessageBox.Show("Select Your Role");
            }else if(LogRole.SelectedIndex==0)
            {
                if(LogName.Text=="" || LogPass.Text=="")
                {
                    MessageBox.Show("Enter Both Admin Name and Password");
                }else if(LogName.Text == "Admin" && LogPass.Text == "Password")
                {
                    Role = "Admin";
                    petmanagement Obj = new petmanagement();
                    Obj.Show();
                    this.Hide();
                }else
                {
                    MessageBox.Show("Wrong Admin Name and Password");
                }
            }else if(LogRole.SelectedIndex==1)
            {
                if (LogName.Text == "" || LogPass.Text == "")
                {
                    MessageBox.Show("Enter Both Doctor Name and Password");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Doctor where DocName='"+LogName.Text+"' and DocPass='"+LogPass.Text+"'",Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Doctor";
                        Prescription Obj = new Prescription();
                        Obj.Show();
                        this.Hide();
                    }else
                    {
                        MessageBox.Show("Doctor Not Found");
                    }
                    Con.Close();
                }
            }
            else
            {
                if (LogName.Text == "" || LogPass.Text == "")
                {
                    MessageBox.Show("Enter Both Receptionist Name and Password");
                }
                else
                {
                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Recep where RecepName='" + LogName.Text + "' and RecepPass='" + LogPass.Text + "'", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        Role = "Receptionist";
                        Dashboard Obj = new Dashboard();
                        Obj.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Receptionist Not Found");
                    }
                    Con.Close();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
