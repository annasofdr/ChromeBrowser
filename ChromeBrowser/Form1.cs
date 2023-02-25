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

namespace ChromeBrowser
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }
   

        private void Form1_Load(object sender, EventArgs e)
        {
            CefSettings settings = new CefSettings();
            Cef.Initialize(settings);
            txtUrl.Text = "https://www.google.com";
            ChromiumWebBrowser browser = new ChromiumWebBrowser(txtUrl.Text);
            browser.Parent = tabControl.SelectedTab;
            browser.Dock = DockStyle.Fill;
            browser.AddressChanged += Browser_AddressChanged;

        }

        private void Browser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
            { 
              txtUrl.Text = e.Address;
            }));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (browser != null)
            {
                if (browser.CanGoBack)
                    browser.Back();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGo_Click(object sender, EventArgs e)
        {   
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (browser != null)
            browser.Load(txtUrl.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (browser != null)
                browser.Refresh();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            ChromiumWebBrowser browser = tabControl.SelectedTab.Controls[0] as ChromiumWebBrowser;
            if (browser != null)
            {
                if (browser.CanGoForward)
                    browser.Forward();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void btnNewTab_Click(object sender, EventArgs e)
        {
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
                tabControl.SelectedTab.Text = e.Title;  
            }));
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
