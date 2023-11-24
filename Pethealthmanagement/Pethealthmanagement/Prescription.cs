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
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
            DisplayPres();
            GetDocId();
            GetPetId();
            GetTestId();
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
        public void DisplayPres()
        {
            Con.Open();
            string query = "Select * from Pres";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PresTable.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void Clear()
        {
            PDocName.Text = "";
            PPetName.Text = "";
            PTestName.Text = "";
            PMed.Text = "";
            PDocid.SelectedIndex = 0;
            PTestid.SelectedIndex = 0;
            PPetid.SelectedIndex = 0;
            key = 0;
        }
        private void GetDocId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select DocId from Doctor", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("DocId", typeof(int));
            dt.Load(rdr);
            PDocid.ValueMember = "DocId";
            PDocid.DataSource = dt;
            Con.Close();
        }
        private void GetPetId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select PetId from Pet", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PetId", typeof(int));
            dt.Load(rdr);
            PPetid.ValueMember = "PetId";
            PPetid.DataSource = dt;
            Con.Close();
        }
        private void GetTestId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select TestNum from Test", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("TestNum", typeof(int));
            dt.Load(rdr);
            PTestid.ValueMember = "TestNum";
            PTestid.DataSource = dt;
            Con.Close();
        }
        private void GetDocName()
        {
            Con.Open();
            string query = "Select * from Doctor where DocId=" + PDocid.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PDocName.Text = dr["DocName"].ToString();
            }
            Con.Close();
        }
        private void GetPetName()
        {
            Con.Open();
            string query = "Select * from Pet where PetId=" + PPetid.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PPetName.Text = dr["PetName"].ToString();
            }
            Con.Close();
        }
        private void GetTestName()
        {
            Con.Open();
            string query = "Select * from Test where TestNum=" + PTestid.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PTestName.Text = dr["TestName"].ToString();
            }
            Con.Close();
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PDocid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetDocName();
        }

        private void PPetid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPetName();
        }

        private void PTestid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetTestName();
        }

        private void PresAdd_Click(object sender, EventArgs e)
        {
            if (PDocName.Text == "" || PTestName.Text == "" || PPetName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Pres(DocId,DocName,TestId,TestName,PetId,PetName,Medicine,Cost,Date,Paid) values(@DI,@DN,@TI,@TN,@PI,@PN,@M,@C,GETDATE(),@PPa)", Con);
                    cmd.Parameters.AddWithValue("@DI", PDocid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DN", PDocName.Text);
                    cmd.Parameters.AddWithValue("@TI", PTestid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@TN", PTestName.Text);
                    cmd.Parameters.AddWithValue("@PI", PPetid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@PN", PPetName.Text);
                    cmd.Parameters.AddWithValue("@M", PMed.Text);
                    cmd.Parameters.AddWithValue("@C", PCost.Text);
                    cmd.Parameters.AddWithValue("@PPa", PresPaid.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prescription Added");
                    Con.Close();
                    DisplayPres();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void PresTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PresSum.Text = "";
            PresSum.Text = "                                        Pet Health\n\n" + "                                  PRESCRIPTION                     " + "\n*********************************************************************" + "\n" + PresTable.SelectedRows[0].Cells[9].Value.ToString() + "\n\n\nDoctor : " + PresTable.SelectedRows[0].Cells[2].Value.ToString() + "                                         Pet : " + PresTable.SelectedRows[0].Cells[4].Value.ToString() + "\n\n\nTest : " + PresTable.SelectedRows[0].Cells[6].Value.ToString() + "                        Medicine : " + PresTable.SelectedRows[0].Cells[7].Value.ToString() + "\n\n\nCost : " + PresTable.SelectedRows[0].Cells[8].Value.ToString() + "\n\n\n                                               Pet";
            PDocName.Text = PresTable.SelectedRows[0].Cells[2].Value.ToString();
            PPetName.Text = PresTable.SelectedRows[0].Cells[4].Value.ToString();
            PTestName.Text = PresTable.SelectedRows[0].Cells[6].Value.ToString();
            PDocid.Text = PresTable.SelectedRows[0].Cells[1].Value.ToString();
            PPetid.Text = PresTable.SelectedRows[0].Cells[3].Value.ToString();
            PTestid.Text = PresTable.SelectedRows[0].Cells[5].Value.ToString();
            PMed.Text = PresTable.SelectedRows[0].Cells[7].Value.ToString();
            PCost.Text = PresTable.SelectedRows[0].Cells[8].Value.ToString();
            PresPaid.Text = PresTable.SelectedRows[0].Cells[10].Value.ToString();


            if (PDocName.Text == "" || PPetName.Text == "" || PTestName.Text == "" || PMed.Text == "" || PCost.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PDocName.Text = PresTable.SelectedRows[0].Cells[0].Value.ToString());
            }


        }

        private void print_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog3.ShowDialog() == DialogResult.OK)
            {
                printDocument2.Print();
            }

        }

        private void printDocument2_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font drawFont = new Font("Arial", 16, FontStyle.Regular);
            SolidBrush drawBrush = new SolidBrush(Color.Black);
            e.Graphics.DrawString(PresSum.Text + "\n", drawFont, drawBrush, new Point(95, 80));
            e.Graphics.DrawString("\n\n\n\n\n\n\n\n\n\t" + "Thanks", new Font("Arial", 20, FontStyle.Bold), new SolidBrush(Color.Red), new Point(200, 300));

        }

        private void PresEdit_Click(object sender, EventArgs e)
        {
            if (PDocName.Text == "" || PTestName.Text == "" || PPetName.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update Pres set DocId=@DI,DocName=@DN,TestId=@TI,TestName=@TN,PetId=@PI,PetName=@PN,Medicine=@M,Cost=@C,Date=GETDATE(),Paid=@PPa where PresId=@PK", Con);
                    cmd.Parameters.AddWithValue("@DI", PDocid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@DN", PDocName.Text);
                    cmd.Parameters.AddWithValue("@TI", PTestid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@TN", PTestName.Text);
                    cmd.Parameters.AddWithValue("@PI", PPetid.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@PN", PPetName.Text);
                    cmd.Parameters.AddWithValue("@M", PMed.Text);
                    cmd.Parameters.AddWithValue("@C", PCost.Text);
                    cmd.Parameters.AddWithValue("@PK", key);
                    cmd.Parameters.AddWithValue("@PPa", PresPaid.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Prescription updated");
                    Con.Close();
                    DisplayPres();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PresDel_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Prescription");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Pres where PresId=@PK", Con);
                    cmd.Parameters.AddWithValue("@PK", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Doctor's Prescription Deleted");
                    Con.Close();
                    DisplayPres();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
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

        private void PresSum_TextChanged(object sender, EventArgs e)
        {

        }
    }
}