using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromeBrowser
{
    public partial class Form2 : Form
    {
       
       
        public Form2()
        {
            InitializeComponent();
           
        }

        public void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            SQLiteConnection con = new SQLiteConnection(@"data source=D:\database\browser.db");
            con.Open();

            string query = "SELECT * FROM history";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);


            dataGridView1.DataSource = dt;

        }
    }
}
