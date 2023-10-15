using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_quan_li_ban_hang
{
    public partial class frmQuanTri : Form
    {
        public frmQuanTri()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmSanPham());

        }
        private Form currentFormChild;

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
                    currentFormChild = childForm;
                    childForm.TopLevel = false;
                    childForm.FormBorderStyle = FormBorderStyle.None;
                    childForm.Dock = DockStyle.Fill;
                    panel_Body.Controls.Add(childForm);
                    panel_Body.Tag = childForm;
                    childForm.BringToFront();
                    childForm.Show();
                }


        private void FormQuanTri_Load(object sender, EventArgs e)
        {

        }

        private void frmQuanTri_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmKhachHang());
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
        }
    } 
}
