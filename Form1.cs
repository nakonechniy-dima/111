using System.IO;
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
            timer1.Enabled = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            double C; 
            int P = Convert.ToInt32(textBox3.Text);
            int Y = Convert.ToInt32(textBox4.Text);
            double I = Convert.ToDouble(textBox5.Text);
            int R = Convert.ToInt32(textBox6.Text);
            int S = Convert.ToInt32(textBox8.Text);
            C = ((Y * I * S) / (P + R)) * 100;
            textBox2.Text = C.ToString();
         }

        public void textBox3_KeyPress_1(object sender, KeyPressEventArgs e)
            {  
              if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))  
       e.Handled = true;  
            }  
            
        private void закритиПрограмуToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Close();
        }

        private void інструкціяToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Ласкаво просимо до нашої програми, вона допоможе вам вибрати оптимальний варіант для купівлі автомобіля. Для початку роботи з програмою завантажте базу даних в програму і далі все просто. Ввести дані і програма знайде оптимальний варіант згідно заданих параметрів");

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(+70);
            if (progressBar1.Value == 100)
            {
                timer1.Enabled = false;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                    e.Handled = true;  
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (((e.KeyChar != 8) && (e.KeyChar != 44)) && (e.KeyChar < 48 || e.KeyChar > 57))
                    e.Handled = true;  
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabControl1.TabPages["TabPage1"];
            dataGridView1.DataSource = GetComments();
            timer1.Enabled = true;

        }  
    }
}
        
    

