using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Data.SQLite;
using System.Globalization;
using System.Data.Entity.Migrations.History;
using System.Security.Cryptography;

namespace ChromeBrowser
{
    public partial class MainForm : Form
    {
        private string closeButtonFullPath = "C:\\Users\\1\\Pictures\\5657.close.png";
        private string wtitle = "";
        private string waddr = "";


        public MainForm()
        {
            InitializeComponent();
    

        }
   

        private void Form1_Load(object sender, EventArgs e)
        {   //sets up Cefsharp's chromium browser and puts Google as homepage
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            txtUrl.Text = "https://www.google.com";
            ChromiumWebBrowser browser = new ChromiumWebBrowser(txtUrl.Text);
            //gets tab's url address and title
            browser.Parent = tabControl.SelectedTab;
            browser.Dock = DockStyle.Fill;
            browser.AddressChanged += Browser_AddressChanged;
            browser.TitleChanged += Browser_TitleChanged;

        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                txtUrl.Text = e.Address;
                waddr = e.Address;
            }));
        }

        private void btnBack_Click(object sender, EventArgs e)
        { //returns to the previous page if browser isnt null
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (browser != null)
            {
                if (browser.CanGoBack)
                    browser.Back();
            }
        }

     

        private void btnGo_Click(object sender, EventArgs e)
        {
           //loads the url text thats mentioned in the search bar if browser isnt null
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;

            if (browser != null)
            {
                browser.Load(txtUrl.Text);
            }


        }
    
         
        

        private void btnRefresh_Click(object sender, EventArgs e)
        { //refreshes current page if browser isnt null
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (browser != null)
                browser.Refresh();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {  //moves forward to the next page if browser isnt null 
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (browser != null)
            {
                if (browser.CanGoForward)
                    browser.Forward();
            }
        }

      
      
        private void btnNewTab_Click(object sender, EventArgs e)
        { //creates a new tab element on click and sets google as homepage
            TabPage tab = new TabPage();
            tab.Text = "New Tab";
            tabControl.Controls.Add(tab);
            tabControl.SelectTab(tabControl.TabCount - 1);
            ChromiumWebBrowser browser = new ChromiumWebBrowser("https://www.google.com");
            browser.Parent = tab;
            browser.Dock= DockStyle.Fill;
            txtUrl.Text = "https://www.google.com";
            browser.AddressChanged += Browser_AddressChanged;
            browser.TitleChanged += Browser_TitleChanged;

        }

        private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            {
               //gets tabs title and inserts it to the string variable
                tabControl.SelectedTab.Text = e.Title;
                wtitle = e.Title;
                //gets current time and date
                DateTime localDate = DateTime.Now;
                var culture = new CultureInfo("en-US");
                string entime = localDate.ToString("yyyy-MM-dd HH:mm:ss");
                var title = e.Title;
                string Url = waddr;

                try
                {
                    //inserting the search into the history database
                    SQLiteConnection con = new SQLiteConnection(@"data source=D:\database\browser.db");
                    con.Open();
                    var cmd = new SQLiteCommand(con);
                    cmd.CommandText = "INSERT INTO history(Url,Title,Last_Visit) VALUES (@txtUrl,@title,@lvisit)";

                    cmd.Parameters.AddWithValue("@txtUrl", Url);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@lvisit", entime);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Console.WriteLine("cannot insert data");

                }



            }));
        }
  

       
        private void btnHistory_Click(object sender, EventArgs e)
        {   //shows the history form on click
            HistoryForm historyWindow = new HistoryForm();
            historyWindow.Show();
            
           
        }

        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
                //draws the X icon for closing the tab 
                try
                {
                    var tabPage = this.tabControl.TabPages[e.Index];
                    var tabRect = this.tabControl.GetTabRect(e.Index);
                    tabRect.Inflate(4, -2);
                    
                        var closeImage = new Bitmap(closeButtonFullPath);
                        e.Graphics.DrawImage(closeImage,

                            (tabRect.Right - closeImage.Width) ,
                            tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                        TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                            tabRect, tabPage.ForeColor, TextFormatFlags.Left);
                    
                }
                catch (Exception ex) { throw new Exception(ex.Message); } }

        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            for (var i = 0; i < this.tabControl.TabPages.Count; i++)
            {
                var tabRect = this.tabControl.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var closeImage = new Bitmap(closeButtonFullPath);
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.tabControl.TabPages.RemoveAt(i);
                    break;
                }
              

            }
        }

       

       


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        { //shutdowns cefsharp's browser
            Cef.Shutdown();
        }
    }
    }

