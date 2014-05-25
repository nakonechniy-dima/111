using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _111
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private DataTable GetComments()
        {
            DataTable dt = new DataTable();

            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "192.186.246.132";
            mysqlCSB.Database = "alien";
            mysqlCSB.UserID = "dima";
            mysqlCSB.Password = "1zbMhXzF6v";

            string queryString = @"SELECT * FROM `cars`";

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = mysqlCSB.ConnectionString;

                MySqlCommand com = new MySqlCommand(queryString, con);

                try
                {
                    con.Open();

                    using (MySqlDataReader dr = com.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dt.Load(dr);
                        }
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetComments();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

       
        public string conString, CommandText;
        private void button4_Click(object sender, EventArgs e)
        {
            conString = "Database=alien;Data Source=192.186.246.132;User Id=dima;Password=1zbMhXzF6v";
            MySqlConnection con = new MySqlConnection(conString);
            try
            {
                con.Open();
                MessageBox.Show("Підключення пройшло успішно. Тепер натисніть 'Завантаження бази даних в програму'");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Збій підключення! ");
            }
            con.Close();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage1"];
        }



        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage2"];
        }
    }
}
