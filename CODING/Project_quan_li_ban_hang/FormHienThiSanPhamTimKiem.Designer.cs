﻿namespace Project_quan_li_ban_hang
{
    partial class frmSanPhamTimKiem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSanPhamTimKiem));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.a = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lsvDssp = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel_new_GioHang = new System.Windows.Forms.Panel();
            this.panel_GioHang = new System.Windows.Forms.Panel();
            this.btnThemGioHang = new Guna.UI2.WinForms.Guna2Button();
            this.btnGiamU = new Guna.UI2.WinForms.Guna2Button();
            this.btnTang = new Guna.UI2.WinForms.Guna2Button();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.pic_Ctdh = new System.Windows.Forms.PictureBox();
            this.NNN = new System.Windows.Forms.Panel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.grpCtdh = new System.Windows.Forms.GroupBox();
            this.panel_Body = new System.Windows.Forms.Panel();
            this.Huỷ = new Guna.UI2.WinForms.Guna2Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Ctdh)).BeginInit();
            this.NNN.SuspendLayout();
            this.grpCtdh.SuspendLayout();
            this.panel_Body.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ghi chú";
            this.columnHeader1.Width = 216;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên sản phẩm";
            this.columnHeader2.Width = 124;
            // 
            // a
            // 
            this.a.Text = "Mã sản phẩm";
            this.a.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lsvDssp);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(532, 452);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // lsvDssp
            // 
            this.lsvDssp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.a,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1});
            this.lsvDssp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvDssp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvDssp.FullRowSelect = true;
            this.lsvDssp.GridLines = true;
            this.lsvDssp.HideSelection = false;
            this.lsvDssp.Location = new System.Drawing.Point(3, 29);
            this.lsvDssp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lsvDssp.Name = "lsvDssp";
            this.lsvDssp.Size = new System.Drawing.Size(526, 421);
            this.lsvDssp.TabIndex = 0;
            this.lsvDssp.UseCompatibleStateImageBehavior = false;
            this.lsvDssp.View = System.Windows.Forms.View.Details;
            this.lsvDssp.SelectedIndexChanged += new System.EventHandler(this.lsvDssp_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 77;
            // 
            // panel_new_GioHang
            // 
            this.panel_new_GioHang.AutoScroll = true;
            this.panel_new_GioHang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_new_GioHang.Location = new System.Drawing.Point(0, 320);
            this.panel_new_GioHang.Margin = new System.Windows.Forms.Padding(4);
            this.panel_new_GioHang.Name = "panel_new_GioHang";
            this.panel_new_GioHang.Size = new System.Drawing.Size(543, 321);
            this.panel_new_GioHang.TabIndex = 5;
            // 
            // panel_GioHang
            // 
            this.panel_GioHang.AutoScroll = true;
            this.panel_GioHang.AutoSize = true;
            this.panel_GioHang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_GioHang.Location = new System.Drawing.Point(0, 641);
            this.panel_GioHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_GioHang.Name = "panel_GioHang";
            this.panel_GioHang.Size = new System.Drawing.Size(543, 0);
            this.panel_GioHang.TabIndex = 4;
            // 
            // btnThemGioHang
            // 
            this.btnThemGioHang.BackColor = System.Drawing.Color.Transparent;
            this.btnThemGioHang.BorderRadius = 10;
            this.btnThemGioHang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemGioHang.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnThemGioHang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThemGioHang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThemGioHang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThemGioHang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThemGioHang.FillColor = System.Drawing.Color.Transparent;
            this.btnThemGioHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemGioHang.ForeColor = System.Drawing.Color.Black;
            this.btnThemGioHang.Image = ((System.Drawing.Image)(resources.GetObject("btnThemGioHang.Image")));
            this.btnThemGioHang.ImageSize = new System.Drawing.Size(50, 50);
            this.btnThemGioHang.Location = new System.Drawing.Point(112, 219);
            this.btnThemGioHang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThemGioHang.Name = "btnThemGioHang";
            this.btnThemGioHang.Size = new System.Drawing.Size(283, 46);
            this.btnThemGioHang.TabIndex = 3;
            this.btnThemGioHang.Text = "Thêm vào giỏ hàng";
            this.btnThemGioHang.Click += new System.EventHandler(this.btnThemGioHang_Click);
            // 
            // btnGiamU
            // 
            this.btnGiamU.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGiamU.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGiamU.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGiamU.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGiamU.FillColor = System.Drawing.Color.Transparent;
            this.btnGiamU.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGiamU.ForeColor = System.Drawing.Color.White;
            this.btnGiamU.Image = ((System.Drawing.Image)(resources.GetObject("btnGiamU.Image")));
            this.btnGiamU.Location = new System.Drawing.Point(184, 174);
            this.btnGiamU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGiamU.Name = "btnGiamU";
            this.btnGiamU.Size = new System.Drawing.Size(43, 30);
            this.btnGiamU.TabIndex = 2;
            this.btnGiamU.Click += new System.EventHandler(this.btnGiamU_Click);
            // 
            // btnTang
            // 
            this.btnTang.BackColor = System.Drawing.Color.Transparent;
            this.btnTang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTang.FillColor = System.Drawing.Color.White;
            this.btnTang.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTang.ForeColor = System.Drawing.Color.White;
            this.btnTang.Image = ((System.Drawing.Image)(resources.GetObject("btnTang.Image")));
            this.btnTang.Location = new System.Drawing.Point(311, 174);
            this.btnTang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(43, 30);
            this.btnTang.TabIndex = 2;
            this.btnTang.Click += new System.EventHandler(this.btnTang_Click);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(253, 174);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(19, 20);
            this.lblSoLuong.TabIndex = 1;
            this.lblSoLuong.Text = "1";
            // 
            // pic_Ctdh
            // 
            this.pic_Ctdh.Location = new System.Drawing.Point(147, 2);
            this.pic_Ctdh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pic_Ctdh.Name = "pic_Ctdh";
            this.pic_Ctdh.Size = new System.Drawing.Size(248, 158);
            this.pic_Ctdh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Ctdh.TabIndex = 0;
            this.pic_Ctdh.TabStop = false;
            // 
            // NNN
            // 
            this.NNN.BackColor = System.Drawing.Color.White;
            this.NNN.Controls.Add(this.panel_new_GioHang);
            this.NNN.Controls.Add(this.panel_GioHang);
            this.NNN.Controls.Add(this.btnThemGioHang);
            this.NNN.Controls.Add(this.btnGiamU);
            this.NNN.Controls.Add(this.btnTang);
            this.NNN.Controls.Add(this.lblSoLuong);
            this.NNN.Controls.Add(this.pic_Ctdh);
            this.NNN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NNN.Location = new System.Drawing.Point(4, 23);
            this.NNN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NNN.Name = "NNN";
            this.NNN.Size = new System.Drawing.Size(543, 641);
            this.NNN.TabIndex = 1;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 10;
            this.guna2Button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(72, 500);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(168, 42);
            this.guna2Button1.TabIndex = 3;
            this.guna2Button1.Text = "Đặt hàng";
            this.guna2Button1.Click += new System.EventHandler(this.btnDatHang_Click);
            // 
            // grpCtdh
            // 
            this.grpCtdh.Controls.Add(this.NNN);
            this.grpCtdh.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpCtdh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCtdh.Location = new System.Drawing.Point(541, 0);
            this.grpCtdh.Margin = new System.Windows.Forms.Padding(4);
            this.grpCtdh.Name = "grpCtdh";
            this.grpCtdh.Padding = new System.Windows.Forms.Padding(4);
            this.grpCtdh.Size = new System.Drawing.Size(551, 668);
            this.grpCtdh.TabIndex = 2;
            this.grpCtdh.TabStop = false;
            this.grpCtdh.Text = "THÔNG TIN GIỎ HÀNG";
            // 
            // panel_Body
            // 
            this.panel_Body.Controls.Add(this.Huỷ);
            this.panel_Body.Controls.Add(this.guna2Button1);
            this.panel_Body.Controls.Add(this.grpCtdh);
            this.panel_Body.Controls.Add(this.groupBox1);
            this.panel_Body.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Body.Location = new System.Drawing.Point(0, 0);
            this.panel_Body.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_Body.Name = "panel_Body";
            this.panel_Body.Size = new System.Drawing.Size(1092, 668);
            this.panel_Body.TabIndex = 8;
            // 
            // Huỷ
            // 
            this.Huỷ.BorderRadius = 10;
            this.Huỷ.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Huỷ.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Huỷ.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Huỷ.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Huỷ.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Huỷ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Huỷ.ForeColor = System.Drawing.Color.White;
            this.Huỷ.Location = new System.Drawing.Point(270, 500);
            this.Huỷ.Margin = new System.Windows.Forms.Padding(4);
            this.Huỷ.Name = "Huỷ";
            this.Huỷ.Size = new System.Drawing.Size(168, 42);
            this.Huỷ.TabIndex = 3;
            this.Huỷ.Text = "Huỷ";
            this.Huỷ.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // frmSanPhamTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 679);
            this.Controls.Add(this.panel_Body);
            this.Name = "frmSanPhamTimKiem";
            this.Text = "FormHienThiSanPhamTimKiem";
            this.Load += new System.EventHandler(this.FormHienThiSanPhamTimKiem_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_Ctdh)).EndInit();
            this.NNN.ResumeLayout(false);
            this.NNN.PerformLayout();
            this.grpCtdh.ResumeLayout(false);
            this.panel_Body.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader a;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lsvDssp;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel_new_GioHang;
        private System.Windows.Forms.Panel panel_GioHang;
        private Guna.UI2.WinForms.Guna2Button btnThemGioHang;
        private Guna.UI2.WinForms.Guna2Button btnGiamU;
        private Guna.UI2.WinForms.Guna2Button btnTang;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.PictureBox pic_Ctdh;
        private System.Windows.Forms.Panel NNN;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.GroupBox grpCtdh;
        private System.Windows.Forms.Panel panel_Body;
        private Guna.UI2.WinForms.Guna2Button Huỷ;
    }
}