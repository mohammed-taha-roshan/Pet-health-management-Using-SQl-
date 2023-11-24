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
    public partial class petmanagement : Form
    {
        public petmanagement()
        {
            InitializeComponent();
            DisplayPet();
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
        int key = 0;
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PAddBtn_Click(object sender, EventArgs e)
        {
            if (PetName.Text == "" || PetPhone.Text == "" || PetAdd.Text == "" || PetGender.SelectedIndex == -1 ||PetAll.Text=="" || PetCat.Text=="")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Pet(PetName,PetAdd,PetGender,PetAge,PetPhone,PetAllergies,PetCategory) values(@PN,@PA,@PG,@PAge,@PP,@PAL,@PC)", Con);
                    cmd.Parameters.AddWithValue("@PN", PetName.Text);
                    cmd.Parameters.AddWithValue("@PA", PetAdd.Text);
                    cmd.Parameters.AddWithValue("@PP", PetPhone.Text);
                    cmd.Parameters.AddWithValue("@PG", PetGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PAge", PetAge.Text);
                    cmd.Parameters.AddWithValue("@PAL", PetAll.Text);
                    cmd.Parameters.AddWithValue("@PC", PetCat.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Added");
                    Con.Close();
                    DisplayPet();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }
        public void DisplayPet()
        {
            Con.Open();
            string query = "Select * from Pet";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PetTable.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void Clear()
        {
            PetName.Text = "";
            PetCat.Text = "";
            PetAll.Text = "";
            PetAdd.Text = "";
            PetGender.SelectedIndex = 0;
            PetAge.Text = "";
            PetPhone.Text = "";
            key = 0;
        }

        private void PEditBtn_Click(object sender, EventArgs e)
        {
            if (PetName.Text == "" || PetPhone.Text == "" || PetAdd.Text == "" || PetGender.SelectedIndex == -1 || PetAll.Text == "" || PetCat.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update Pet set PetName=@PN,PetAdd=@PA,PetGender=@PG,PetAge=@PAge,PetPhone=@PP,PetAllergies=@PAL,PetCategory=@PC where PetId=@PK", Con);
                    cmd.Parameters.AddWithValue("@PN", PetName.Text);
                    cmd.Parameters.AddWithValue("@PA", PetAdd.Text);
                    cmd.Parameters.AddWithValue("@PP", PetPhone.Text);
                    cmd.Parameters.AddWithValue("@PG", PetGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@PAge", PetAge.Text);
                    cmd.Parameters.AddWithValue("@PAL", PetAll.Text);
                    cmd.Parameters.AddWithValue("@PC", PetCat.Text);
                    cmd.Parameters.AddWithValue("@Pk", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Updated");
                    Con.Close();
                    DisplayPet();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PDelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Pet");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Pet where PetId=@PK", Con);
                    cmd.Parameters.AddWithValue("@PK", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Pet Deleted");
                    Con.Close();
                    DisplayPet();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PetTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PetName.Text = PetTable.SelectedRows[0].Cells[1].Value.ToString();
            PetGender.Text = PetTable.SelectedRows[0].Cells[2].Value.ToString();
            PetAge.Text = PetTable.SelectedRows[0].Cells[3].Value.ToString();
            PetAdd.Text = PetTable.SelectedRows[0].Cells[4].Value.ToString();
            PetPhone.Text = PetTable.SelectedRows[0].Cells[5].Value.ToString();
            PetAll.Text = PetTable.SelectedRows[0].Cells[6].Value.ToString();
            PetCat.Text = PetTable.SelectedRows[0].Cells[7].Value.ToString();

            if (PetName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PetName.Text = PetTable.SelectedRows[0].Cells[0].Value.ToString());
            }
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
