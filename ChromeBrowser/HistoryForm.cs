using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromeBrowser
{
    public partial class HistoryForm : Form
    {
       
       
        public HistoryForm()
        {
            InitializeComponent();
           
        }

   

        private void Form2_Load(object sender, EventArgs e)
        {
            //connects with the database
            SQLiteConnection con = new SQLiteConnection(@"data source=D:\database\browser.db");
            con.Open();
            //gets the url,title and time of the last visit 
            string query = "SELECT Url,Title,STRFTIME('%d-%m-%Y %H:%M:%S',Last_Visit) " +
            "AS Last_visit FROM history ORDER BY Last_Visit DESC ";
            SQLiteCommand cmd = new SQLiteCommand(query, con);

            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);


            dataGridView1.DataSource = dt;

        }

        private void buttonClrToday_Click(object sender, EventArgs e)
        {   //gets current datetime
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("en-US");
            string entime = localDate.ToString("yyyy-MM-dd");
            //database connection
            SQLiteConnection con = new SQLiteConnection(@"data source=D:\database\browser.db");
            con.Open();

            var cmd = new SQLiteCommand(con);
            //clears current day's history
            cmd.CommandText = "DELETE FROM history WHERE STRFTIME('%Y-%m-%d',Last_Visit) = @lvisit";
            cmd.Parameters.AddWithValue("@lvisit", entime);
            cmd.ExecuteNonQuery();
            this.Close();
            //refreshes history form 
            HistoryForm historyWindow = new HistoryForm();
            historyWindow.Show();

        }

        private void buttonClrAll_Click(object sender, EventArgs e)
        {
           //database connection
            SQLiteConnection con = new SQLiteConnection(@"data source=D:\database\browser.db");
            con.Open();

            var cmd = new SQLiteCommand(con);
            //deletes all data from history
            cmd.CommandText = "DELETE FROM history";
            cmd.ExecuteNonQuery();
            this.Close();
            //refreshes history form
            HistoryForm historyWindow = new HistoryForm();
            historyWindow.Show();
        }
    }
}
