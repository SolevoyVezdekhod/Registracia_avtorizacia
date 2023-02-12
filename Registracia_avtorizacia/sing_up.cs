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

namespace Registracia_avtorizacia
{
    public partial class sing_up : Form
    {
        DateBase dataBase = new DateBase();
        int i = 0;
        public sing_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            i++;
            if (i >= 4)
            {
                MessageBox.Show("Превышено попыток входа, попробуйте ещё раз через 10 секунд.", "Ошибка", MessageBoxButtons.OK);
                button1.Enabled = false;
                timer1.Start();
            }

            if (label4_captcha.Text == textBox3_captcha.Text)
            {
                if (checkuser())
                {
                    return;

                }
                var login = textBox1.Text;
                var password = textBox2.Text;

                string querystring = $"insert into registracia(Password, login) values('{login}', '{password}' )";

                SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

                dataBase.openConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан.", "Успех!");
                    Form1 frm_login = new Form1();
                    this.Hide();
                    frm_login.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Аккаунт не создан!");
                }
                dataBase.CloseConnection();


            }
        }
        private Boolean checkuser()
        {
            var loginUser = textBox1.Text;
            var passUser = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select ID, Password, login from registracia where login = '{loginUser}' and password = '{passUser}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            else
            {
                return false;
            }
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void sing_up_Load(object sender, EventArgs e)
        {
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 10000;

            pictureBox3.Visible = false;
            textBox1.MaxLength = 50;
            textBox2.MaxLength = 50;

            
            Random rand = new Random();
            int num = rand.Next(3, 4);
            string captcha = "";
            int totl = 0;
            do
            {
                int chr = rand.Next(48, 123);
                if ((chr >= 48 && chr <= 57) || (chr >= 65 && chr <= 90) || (chr >= 97 && chr <= 122))
                {
                    captcha = captcha + (char)chr;
                    totl++;
                    if (totl > num)
                        break;
                    {
                    }
                }
            } while (true);
            label4_captcha.Text = captcha;
        }
        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
            textBox2.UseSystemPasswordChar = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 frm_1 = new Form1();
            frm_1.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            button1.Enabled = true;
            i = 0;
            timer1.Stop();
        }

       
    }
    
    
}
