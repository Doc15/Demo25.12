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

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getInfo(dataGridView1);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string query = "select ID, Title, MaterialTypeID, Cost, CountInStock, MinCount, CountPack, Description from material where concat() like %'"+textBox1.Text+"'%;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        dataGridView1.Rows.Clear();
                        dataGridView1.Rows.Add(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetString(7));
                    }
                }
                 conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Materials win = new Materials();
            win.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Materials win = new Materials();
            win.Show();
            this.Hide();
        }
        // Вывод данных из базы данных
        void getInfo(DataGridView dataGrid)
        {
            string query = "select ID, Title, MaterialTypeID, Cost, CountInStock, MinCount, CountPack, Description from material";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        dataGridView1.Rows.Add(rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4), rd.GetString(5), rd.GetString(6), rd.GetString(7));
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            getInfo(dataGridView1);

        }
    }
}
