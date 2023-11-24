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
    public partial class doctormanagement : Form
    {
        public doctormanagement()
        {
            InitializeComponent();
            DisplayDoc();
            if (Logi.Role == "Receptionist")
            {
                pictureBox3.Enabled = false;
                pictureBox6.Enabled = false;
                label3.Enabled = false;
                label6.Enabled = false;
            }
            else if (Logi.Role == "Doctor")
            {
                pictureBox6.Enabled = false;
                label6.Enabled = false;
                pictureBox2.Enabled = false;
                label2.Enabled = false;
            }
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K63CD7V;Initial Catalog=petHelDB;Integrated Security=True");
        int key = 0;

        private void DAddBtn_Click(object sender, EventArgs e)
        {
            if (DocName.Text == "" || DocPhone.Text == "" || DocPass.Text == "" || DocAdd.Text == "" || DocGender.SelectedIndex == -1 || DocSpec.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Doctor(DocName,DocPass,DocAdd,DocPhone,DocGender,DocSpec,DocYear,DocDOB) values(@DN,@DPA,@DA,@DP,@DG,@DS,@DY,@DDOB)", Con);
                    cmd.Parameters.AddWithValue("@DN", DocName.Text);
                    cmd.Parameters.AddWithValue("@DPA", DocPass.Text);
                    cmd.Parameters.AddWithValue("@DA", DocAdd.Text);
                    cmd.Parameters.AddWithValue("@DP", DocPhone.Text);
                    cmd.Parameters.AddWithValue("@DG", DocGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", DocSpec.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DY", DocYOE.Text);
                    cmd.Parameters.AddWithValue("@DDOB", DocDOB.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Added");
                    Con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        public void DisplayDoc()
        {
            Con.Open();
            string query = "Select * from Doctor";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DocTable.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void Clear()
        {
            DocName.Text = "";
            DocPass.Text = "";
            DocPhone.Text = "";
            DocAdd.Text = "";
            DocGender.SelectedIndex = 0;
            DocSpec.SelectedIndex = 0;
            key = 0;
        }

        private void DEditBtn_Click(object sender, EventArgs e)
        {
            if (DocName.Text == "" || DocPhone.Text == "" || DocPass.Text == "" || DocAdd.Text == "" || DocGender.SelectedIndex == -1 || DocSpec.SelectedIndex == -1)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update Doctor set DocName=@DN,DocPass=@DPA,DocAdd=@DA,DocPhone=@DP,DocGender=@DG,DocSpec=@DS,DocYear=@DY,DocDOB=@DDOB where DocId=@DK", Con);
                    cmd.Parameters.AddWithValue("@DN", DocName.Text);
                    cmd.Parameters.AddWithValue("@DPA", DocPass.Text);
                    cmd.Parameters.AddWithValue("@DA", DocAdd.Text);
                    cmd.Parameters.AddWithValue("@DP", DocPhone.Text);
                    cmd.Parameters.AddWithValue("@DG", DocGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DS", DocSpec.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@DY", DocYOE.Text);
                    cmd.Parameters.AddWithValue("@DDOB", DocDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@DK", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Updated");
                    Con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DocTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DocName.Text = DocTable.SelectedRows[0].Cells[1].Value.ToString();
            DocGender.Text = DocTable.SelectedRows[0].Cells[2].Value.ToString();
            DocDOB.Text = DocTable.SelectedRows[0].Cells[3].Value.ToString();
            DocAdd.Text = DocTable.SelectedRows[0].Cells[4].Value.ToString();
            DocPhone.Text = DocTable.SelectedRows[0].Cells[5].Value.ToString();
            DocYOE.Text = DocTable.SelectedRows[0].Cells[6].Value.ToString();
            DocSpec.Text = DocTable.SelectedRows[0].Cells[7].Value.ToString();
            DocPass.Text = DocTable.SelectedRows[0].Cells[8].Value.ToString();

            if (DocName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(DocName.Text = DocTable.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DDelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Doctor");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Doctor where DocId=@DK", Con);
                    cmd.Parameters.AddWithValue("@DK", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor Deleted");
                    Con.Close();
                    DisplayDoc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
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