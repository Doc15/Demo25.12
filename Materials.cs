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
    public partial class Materials : Form
    {
        public Materials()
        {
            InitializeComponent();
            getInfo(dataGridView1);
            getType(comboBox1);
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
                if(rd.HasRows)
                {
                    while(rd.Read())
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

        //Вывод типа материала из базы
        void getType(ComboBox comboBox1)
        {
            string query = "select Title from materialtype";
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
                        string row = rd.GetString(0);
                        comboBox1.Items.Add(row);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Кнопка добавления
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select ID, Title, MaterialTypeID, Cost, CountInStock, MinCount, CountPack, Description from material";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // выбор строки и отображение данных в полях 
        private void DataGridView_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }


        // Кнопка редактирования
        private void button3_Click(object sender, EventArgs e)
        {
            string query = "update materials set Title='"+textBox2.Text+"', MaterialTypeID="+(comboBox1.SelectedIndex+1).ToString()+", Cost='"+textBox2.Text+"', CountInStock"+textBox4.Text+", MinCount='"+textBox5.Text+"', CountPack'"+textBox6.Text+"', Description'"+textBox7.Text+"' where ID="+textBox1.Text+";";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // кнопка удаления
        private void button2_Click(object sender, EventArgs e)
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


        // кнопка обновление 
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            getInfo(dataGridView1);
        }


        //возврат на гланую форму
        private void button5_Click(object sender, EventArgs e)
        {
            Form1 win = new Form1();
            win.Show();
            this.Hide();
        }
    }
}
