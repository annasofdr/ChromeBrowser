namespace ChromeBrowser
{
    partial class HistoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonClrToday = new System.Windows.Forms.Button();
            this.buttonClrAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 396);
            this.dataGridView1.TabIndex = 0;

            // 
            // buttonClrToday
            // 
            this.buttonClrToday.Location = new System.Drawing.Point(12, 2);
            this.buttonClrToday.Name = "buttonClrToday";
            this.buttonClrToday.Size = new System.Drawing.Size(75, 23);
            this.buttonClrToday.TabIndex = 1;
            this.buttonClrToday.Text = "Clear Today";
            this.buttonClrToday.UseVisualStyleBackColor = true;
            this.buttonClrToday.Click += new System.EventHandler(this.buttonClrToday_Click);
            // 
            // buttonClrAll
            // 
            this.buttonClrAll.Location = new System.Drawing.Point(93, 2);
            this.buttonClrAll.Name = "buttonClrAll";
            this.buttonClrAll.Size = new System.Drawing.Size(75, 23);
            this.buttonClrAll.TabIndex = 2;
            this.buttonClrAll.Text = "Clear All";
            this.buttonClrAll.UseVisualStyleBackColor = true;
            this.buttonClrAll.Click += new System.EventHandler(this.buttonClrAll_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonClrAll);
            this.Controls.Add(this.buttonClrToday);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "History";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonClrToday;
        private System.Windows.Forms.Button buttonClrAll;
    }
}