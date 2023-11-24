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
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            DisplayTest();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-K63CD7V;Initial Catalog=petHelDB;Integrated Security=True");
        int key = 0;
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TAddBtn_Click(object sender, EventArgs e)
        {
            if (TestName.Text == "" || TestCost.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Test(TestName,TestCost) values(@TN,@TC)", Con);
                    cmd.Parameters.AddWithValue("@TN", TestName.Text);
                    cmd.Parameters.AddWithValue("@TC", TestCost.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Added");
                    Con.Close();
                    DisplayTest();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        public void DisplayTest()
        {
            Con.Open();
            string query = "Select * from Test";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TestTable.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void Clear()
        {
            TestName.Text = "";
            TestCost.Text = "";
            key = 0;
        }
        private void TEditBtn_Click(object sender, EventArgs e)
        {
            if (TestName.Text == "" || TestCost.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update Test set TestName=@TN ,TestCost=@TC where TestNum=@TK", Con);
                    cmd.Parameters.AddWithValue("@TN", TestName.Text);
                    cmd.Parameters.AddWithValue("@TC", TestCost.Text);
                    cmd.Parameters.AddWithValue("@TK", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Edited");
                    Con.Close();
                    DisplayTest();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void TestTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TestName.Text = TestTable.SelectedRows[0].Cells[1].Value.ToString();
            TestCost.Text = TestTable.SelectedRows[0].Cells[2].Value.ToString();

            if (TestName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TestName.Text = TestTable.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void TDelBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Test");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from Test where TestNum=@TK", Con);
                    cmd.Parameters.AddWithValue("@TK", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Test Deleted");
                    Con.Close();
                    DisplayTest();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Logi Obj = new Logi();
            Obj.Show();
            this.Hide();
        }
    }
}
