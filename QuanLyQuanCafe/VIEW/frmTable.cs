using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.VIEW
{
    public partial class frmTable : Form
    {
        public frmTable()
        {
            InitializeComponent();
        }
        int x = 5;
        int y = 25;
        int flag = 1; //Add: 1, delete: 0
        private void btnThem_Click(object sender, EventArgs e)
        {
            
            //PictureBox picture = new PictureBox
            //{
            //    Name = "pictureBox",
            //    Location = new Point(x, y),
            //    Image = Image.FromFile(@"C:\Users\hp\Documents\GitHubl\QuanLyCafe\QuanLyQuanCafe\Picture\tablecafe.png"),
            //    SizeMode = PictureBoxSizeMode.CenterImage
            //};
            //Label label = new Label
            //{
            //    Text = "Bàn 1",
            //    Location = new Point(x + 30, y + 50)
            //};
            //groupPicture.Controls.Add(picture);
            //groupPicture.Controls.Add(label);

            //x = x + 100;
            //if (x > 580)
            //{
            //    y = y + 100;
            //    x = 5;
            //}

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flag == 1)
            {
                Table_DTO table = new Table_DTO(txtSoBan.Text, 0);
                Table_BUS.AddTable(table);
            }
            
        }
    }
}
