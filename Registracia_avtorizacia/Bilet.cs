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
    public partial class Bilet : Form
    {
        DateBase dataBase = new DateBase();
        public Bilet()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Bilet_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select* from Bilet";

            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

        }

    }
}
