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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            if (Logi.Role == "Receptionist")
            {
                RecepPic.Enabled = false;
                TestPic.Enabled = false;
                RecepLbl.Enabled = false;
                TestLbl.Enabled = false;
            }else if(Logi.Role == "Doctor")
            {
                RecepPic.Enabled = false;
                RecepLbl.Enabled = false;
                DocPic.Enabled = false;
                DocLbl.Enabled = false;
            }
            CountPets();
            CountDoc();
            PetHighCat();
            TotCost();
            GetPetId();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K63CD7V;Initial Catalog=petHelDB;Integrated Security=True");
        private void CountPets()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("CountPets", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            PetNum.Text = dt.Rows[0][0].ToString();
            rdr.Close();
            Con.Close();
        }
        private void CountDoc()
        {
            Con.Open();
            SqlDataAdapter sda1 = new SqlDataAdapter("select Count(*) from Doctor", Con);
            SqlDataAdapter sda2 = new SqlDataAdapter("select Count(*) from Test", Con);
            SqlDataAdapter sda3 = new SqlDataAdapter("select Count(*) from Pres", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            DocNum.Text = dt1.Rows[0][0].ToString();
            DataTable dt3 = new DataTable();
            sda3.Fill(dt3);
            PresNum.Text = dt3.Rows[0][0].ToString();
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Tests.Text = dt2.Rows[0][0].ToString();
            Con.Close();
        }

        private void TotCost()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("totCost", Con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            Cost.Text = dt.Rows[0][0].ToString();
            rdr.Close();
            Con.Close();
        }
        private void PetHighCat()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.PetHighCat()", Con);
            SqlDataReader rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(rdr);
            PetHigh.Text = dt.Rows[0][0].ToString();
            rdr.Close();
            Con.Close();
        }


        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PetPic_Click(object sender, EventArgs e)
        {
            petmanagement Obj = new petmanagement();
            Obj.Show();
            this.Hide();
        }
        private void GetPetId()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select PetId from Pres", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("PetId", typeof(int));
            dt.Load(rdr);
            DPetid.ValueMember = "PetId";
            DPetid.DataSource = dt;
            Con.Close();
        }
        private void GetPetName()
        {
            Con.Open();
            string query = "Select * from Pres where PetId=" + DPetid.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DPetName.Text = dr["PetName"].ToString();
            }
            Con.Close();
        }
        private void GetSpecialization()
        {
            Con.Open();
            string query = "Select DocSpec from Doctor d join Pres p on d.DocId = p.DocId where p.PetId=" + DPetid.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                Spec.Text = dr["DocSpec"].ToString();
            }
            Con.Close();

        }
        private void GetAllegies()
        {
            Con.Open();
            string query = "Select petallergies from Pet where Petid in (Select Petid from Pres where PetId=" + DPetid.SelectedValue.ToString() + ")";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                DPetAll.Text = dr["petallergies"].ToString();
            }
            Con.Close();
        }

        private void DocPic_Click(object sender, EventArgs e)
        {
            doctormanagement Obj = new doctormanagement();
            Obj.Show();
            this.Hide();
        }

        private void RecepPic_Click(object sender, EventArgs e)
        {
            Receptionist Obj = new Receptionist();
            Obj.Show();
            this.Hide();
        }

        private void PresPic_Click(object sender, EventArgs e)
        {
            Prescription Obj = new Prescription();
            Obj.Show();
            this.Hide();
        }

        private void TestPic_Click(object sender, EventArgs e)
        {
            Test Obj = new Test();
            Obj.Show();
            this.Hide();
        }

        private void LogoutPic_Click(object sender, EventArgs e)
        {
            Logi Obj = new Logi();
            Obj.Show();
            this.Hide();
        }

        private void DPetid_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetPetName();
            GetSpecialization();
            GetAllegies();
        }


    }
}
