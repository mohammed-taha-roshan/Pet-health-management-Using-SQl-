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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
            DisplayRec();
            if (Logi.Role == "Receptionist")
            {
                pictureBox3.Enabled = false;
                pictureBox6.Enabled = false;
                label3.Enabled = false;
                label6.Enabled = false;
            }
            else if (Logi.Role == "Doctor")
            {
                pictureBox3.Enabled = false;
                label3.Enabled = false;
                pictureBox2.Enabled = false;
                label2.Enabled = false;
            }
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K63CD7V;Initial Catalog=petHelDB;Integrated Security=True");
        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(RName.Text == "" || RPhone.Text == "" || RPass.Text == "" || RAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            }else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Recep(RecepName,RecepPass,RecepAdd,RecepPhone) values(@RN,@RPA,@RA,@RP)",Con);
                    cmd.Parameters.AddWithValue("@RN", RName.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPass.Text);
                    cmd.Parameters.AddWithValue("@RA", RAdd.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhone.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Added");
                    Con.Close();
                    DisplayRec();
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (RName.Text == "" || RPhone.Text == "" || RPass.Text == "" || RAdd.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update Recep set RecepName=@RN,RecepPass=@RPA,RecepAdd=@RA,RecepPhone=@RP where RecepId=@Rkey", Con);
                    cmd.Parameters.AddWithValue("@RN", RName.Text);
                    cmd.Parameters.AddWithValue("@RPA", RPass.Text);
                    cmd.Parameters.AddWithValue("@RA", RAdd.Text);
                    cmd.Parameters.AddWithValue("@RP", RPhone.Text);
                    cmd.Parameters.AddWithValue("@Rkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Updated");
                    Con.Close();
                    DisplayRec();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Select The Receptionist");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Recep where RecepId=@Rkey", Con);
                    cmd.Parameters.AddWithValue("@Rkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Receptionist Deleted");
                    Con.Close();
                    DisplayRec();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        public void DisplayRec()
        {
            Con.Open();
            string query = "Select * from Recep";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            RecepTable.DataSource = ds.Tables[0];

            Con.Close();
        }

        int key = 0;
        private void RecepTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RName.Text = RecepTable.SelectedRows[0].Cells[1].Value.ToString();
            RPass.Text = RecepTable.SelectedRows[0].Cells[2].Value.ToString();
            RAdd.Text = RecepTable.SelectedRows[0].Cells[3].Value.ToString();
            RPhone.Text = RecepTable.SelectedRows[0].Cells[4].Value.ToString();
            if(RName.Text == "")
            {
                key = 0 ;
            }else
            {
                key = Convert.ToInt32(RName.Text = RecepTable.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Clear()
        {
            RName.Text = "";
            RPass.Text = "";
            RPhone.Text = "";
            RAdd.Text = "";
            key = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            petmanagement Obj = new petmanagement();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            doctormanagement Obj = new doctormanagement();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Receptionist Obj = new Receptionist();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Prescription Obj = new Prescription();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Test Obj = new Test();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Logi Obj = new Logi();
            Obj.Show();
            this.Hide();
        }

    }
}
