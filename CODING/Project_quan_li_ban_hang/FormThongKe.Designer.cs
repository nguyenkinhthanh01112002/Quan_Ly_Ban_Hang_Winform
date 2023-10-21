namespace Project_quan_li_ban_hang
{
    partial class frmThongKe
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
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.btnTop3_Count_Product = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTop3_Max_Rev = new Guna.UI2.WinForms.Guna2Button();
            this.btnTop3_Min_Count_Product = new Guna.UI2.WinForms.Guna2Button();
            this.btnTop3_Min_Rev = new Guna.UI2.WinForms.Guna2Button();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.grp_ThongKe = new System.Windows.Forms.GroupBox();
            this.lsv_Show = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.panel_Body.SuspendLayout();
            this.grp_ThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BorderRadius = 10;
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(162)))), ((int)(((byte)(116)))));
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.Black;
            this.btnExit.Location = new System.Drawing.Point(12, 578);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(227, 56);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnTop3_Count_Product
            // 
            this.btnTop3_Count_Product.BorderRadius = 10;
            this.btnTop3_Count_Product.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Count_Product.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Count_Product.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTop3_Count_Product.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTop3_Count_Product.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(162)))), ((int)(((byte)(116)))));
            this.btnTop3_Count_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTop3_Count_Product.ForeColor = System.Drawing.Color.Black;
            this.btnTop3_Count_Product.Location = new System.Drawing.Point(12, 58);
            this.btnTop3_Count_Product.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTop3_Count_Product.Name = "btnTop3_Count_Product";
            this.btnTop3_Count_Product.Size = new System.Drawing.Size(227, 71);
            this.btnTop3_Count_Product.TabIndex = 1;
            this.btnTop3_Count_Product.Text = "Top 3 sản phẩm bán chạy nhất";
            this.btnTop3_Count_Product.Click += new System.EventHandler(this.btnTop3_Count_Product_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnTop3_Min_Rev);
            this.panel1.Controls.Add(this.btnTop3_Min_Count_Product);
            this.panel1.Controls.Add(this.btnTop3_Max_Rev);
            this.panel1.Controls.Add(this.btnTop3_Count_Product);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 694);
            this.panel1.TabIndex = 2;
            // 
            // btnTop3_Max_Rev
            // 
            this.btnTop3_Max_Rev.BorderRadius = 10;
            this.btnTop3_Max_Rev.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Max_Rev.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Max_Rev.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTop3_Max_Rev.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTop3_Max_Rev.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(162)))), ((int)(((byte)(116)))));
            this.btnTop3_Max_Rev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTop3_Max_Rev.ForeColor = System.Drawing.Color.Black;
            this.btnTop3_Max_Rev.Location = new System.Drawing.Point(12, 187);
            this.btnTop3_Max_Rev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTop3_Max_Rev.Name = "btnTop3_Max_Rev";
            this.btnTop3_Max_Rev.Size = new System.Drawing.Size(227, 70);
            this.btnTop3_Max_Rev.TabIndex = 1;
            this.btnTop3_Max_Rev.Text = "Top 3 sản phẩm có doanh thu cao nhất";
            this.btnTop3_Max_Rev.Click += new System.EventHandler(this.btnTop3_Max_Rev_Click);
            // 
            // btnTop3_Min_Count_Product
            // 
            this.btnTop3_Min_Count_Product.BorderRadius = 10;
            this.btnTop3_Min_Count_Product.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Min_Count_Product.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Min_Count_Product.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTop3_Min_Count_Product.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTop3_Min_Count_Product.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(162)))), ((int)(((byte)(116)))));
            this.btnTop3_Min_Count_Product.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTop3_Min_Count_Product.ForeColor = System.Drawing.Color.Black;
            this.btnTop3_Min_Count_Product.Location = new System.Drawing.Point(12, 313);
            this.btnTop3_Min_Count_Product.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTop3_Min_Count_Product.Name = "btnTop3_Min_Count_Product";
            this.btnTop3_Min_Count_Product.Size = new System.Drawing.Size(227, 72);
            this.btnTop3_Min_Count_Product.TabIndex = 1;
            this.btnTop3_Min_Count_Product.Text = "Top 3 sản phẩm có doanh số thấp nhất";
            this.btnTop3_Min_Count_Product.Click += new System.EventHandler(this.btnTop3_Min_Count_Product_Click);
            // 
            // btnTop3_Min_Rev
            // 
            this.btnTop3_Min_Rev.BorderRadius = 10;
            this.btnTop3_Min_Rev.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Min_Rev.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTop3_Min_Rev.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTop3_Min_Rev.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTop3_Min_Rev.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(162)))), ((int)(((byte)(116)))));
            this.btnTop3_Min_Rev.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTop3_Min_Rev.ForeColor = System.Drawing.Color.Black;
            this.btnTop3_Min_Rev.Location = new System.Drawing.Point(12, 443);
            this.btnTop3_Min_Rev.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTop3_Min_Rev.Name = "btnTop3_Min_Rev";
            this.btnTop3_Min_Rev.Size = new System.Drawing.Size(227, 75);
            this.btnTop3_Min_Rev.TabIndex = 1;
            this.btnTop3_Min_Rev.Text = "Top 3 sản phẩm có doanh thu thấp nhất";
            this.btnTop3_Min_Rev.Click += new System.EventHandler(this.btnTop3_Min_Rev_Click);
            // 
            // panel_Body
            // 
            this.panel_Body.Controls.Add(this.grp_ThongKe);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Body.Location = new System.Drawing.Point(245, 0);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(804, 694);
            this.panel_Body.TabIndex = 3;
            // 
            // grp_ThongKe
            // 
            this.grp_ThongKe.Controls.Add(this.lsv_Show);
            this.grp_ThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_ThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_ThongKe.Location = new System.Drawing.Point(0, 0);
            this.grp_ThongKe.Name = "grp_ThongKe";
            this.grp_ThongKe.Size = new System.Drawing.Size(804, 694);
            this.grp_ThongKe.TabIndex = 0;
            this.grp_ThongKe.TabStop = false;
            this.grp_ThongKe.Text = "Top 3 sản phẩm bán chạy nhất";
            // 
            // lsv_Show
            // 
            this.lsv_Show.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsv_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsv_Show.FullRowSelect = true;
            this.lsv_Show.GridLines = true;
            this.lsv_Show.HideSelection = false;
            this.lsv_Show.Location = new System.Drawing.Point(3, 26);
            this.lsv_Show.Name = "lsv_Show";
            this.lsv_Show.Size = new System.Drawing.Size(798, 665);
            this.lsv_Show.TabIndex = 0;
            this.lsv_Show.UseCompatibleStateImageBehavior = false;
            this.lsv_Show.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã sản phẩm";
            this.columnHeader1.Width = 183;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sản phẩm";
            this.columnHeader2.Width = 197;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Tổng tiền";
            this.columnHeader4.Width = 220;
            // 
            // frmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 694);
            this.Controls.Add(this.panel_Body);
            this.Controls.Add(this.panel1);
            this.Name = "frmThongKe";
            this.Text = "FormThongKe";
            this.panel1.ResumeLayout(false);
            this.panel_Body.ResumeLayout(false);
            this.grp_ThongKe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Button btnTop3_Count_Product;
        private System.Windows.Forms.Panel panel1;
        private Guna.UI2.WinForms.Guna2Button btnTop3_Min_Rev;
        private Guna.UI2.WinForms.Guna2Button btnTop3_Min_Count_Product;
        private Guna.UI2.WinForms.Guna2Button btnTop3_Max_Rev;
        private System.Windows.Forms.Panel panel_Body;
        private System.Windows.Forms.GroupBox grp_ThongKe;
        private System.Windows.Forms.ListView lsv_Show;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}