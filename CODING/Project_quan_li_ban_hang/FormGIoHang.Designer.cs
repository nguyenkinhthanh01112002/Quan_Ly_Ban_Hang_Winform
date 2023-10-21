namespace Project_quan_li_ban_hang
{
    partial class frmGioHang
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
            this.grp_GioHang = new System.Windows.Forms.GroupBox();
            this.lsv_GioHang = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grp_GioHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_GioHang
            // 
            this.grp_GioHang.Controls.Add(this.lsv_GioHang);
            this.grp_GioHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_GioHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grp_GioHang.Location = new System.Drawing.Point(0, 0);
            this.grp_GioHang.Margin = new System.Windows.Forms.Padding(2);
            this.grp_GioHang.Name = "grp_GioHang";
            this.grp_GioHang.Padding = new System.Windows.Forms.Padding(2);
            this.grp_GioHang.Size = new System.Drawing.Size(538, 321);
            this.grp_GioHang.TabIndex = 0;
            this.grp_GioHang.TabStop = false;
            this.grp_GioHang.Text = "THÔNG TIN GIỎ HÀNG";
            // 
            // lsv_GioHang
            // 
            this.lsv_GioHang.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lsv_GioHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lsv_GioHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsv_GioHang.FullRowSelect = true;
            this.lsv_GioHang.GridLines = true;
            this.lsv_GioHang.HideSelection = false;
            this.lsv_GioHang.Location = new System.Drawing.Point(2, 21);
            this.lsv_GioHang.Margin = new System.Windows.Forms.Padding(2);
            this.lsv_GioHang.Name = "lsv_GioHang";
            this.lsv_GioHang.Size = new System.Drawing.Size(534, 231);
            this.lsv_GioHang.TabIndex = 0;
            this.lsv_GioHang.UseCompatibleStateImageBehavior = false;
            this.lsv_GioHang.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã hàng";
            this.columnHeader1.Width = 107;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên hàng";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Số lượng";
            this.columnHeader3.Width = 102;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.Width = 199;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thành tiền";
            // 
            // frmGioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 321);
            this.Controls.Add(this.grp_GioHang);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmGioHang";
            this.Text = "FormGioHang";
            this.Load += new System.EventHandler(this.frmGioHang_Load);
            this.grp_GioHang.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_GioHang;
        private System.Windows.Forms.ListView lsv_GioHang;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}