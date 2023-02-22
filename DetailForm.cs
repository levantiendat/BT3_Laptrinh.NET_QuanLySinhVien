using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _102210247_LeVanTienDat
{
    public partial class DetailForm : Form
    {
        
        public delegate void MyDel(string lopsh,string txt);
        public MyDel d { get; set; }
        public int MSSV { get; set; }
        
        public DetailForm(int mssv) 
        {
            
            MSSV = mssv;
            InitializeComponent();
            GUI();
        }
        
        public void GUI()
        {
            if (MSSV > 0)
            {
                QLSV f = new QLSV();
                SinhVien s=new SinhVien();
                s=f.GetSVByMSSV(MSSV);
                textname.Text = s.mssv.ToString();
                textlopsh.Text = s.lopsh.ToString();
                textDate.Text=s.ngaysinh.ToString();
                textdtb.Text=s.diemtb.ToString();
                if(s.gioitinh==true)
                {
                    nam.Checked = true;
                }
                else
                {
                    nu.Checked = true;
                }
                anh.Checked = s.anh;
                hocba.Checked = s.hocba;
                cccd.Checked = s.cccd;
                textname.Enabled = false;
            }
        }
        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            SinhVien s=new SinhVien();
            s.mssv = Convert.ToInt32(textname.Text);
            s.lopsh = textlopsh.Text.ToString();
            s.ngaysinh = Convert.ToDateTime(textDate.Text.ToString());
            s.diemtb = Convert.ToDouble(textdtb.Text.ToString());
            if (nam.Checked) s.gioitinh = true;
            else s.gioitinh = false;
            s.anh=anh.Checked;
            s.hocba=hocba.Checked;
            s.cccd=cccd.Checked;
            QLSV f =new QLSV();
            f.SyncDB(s);
            
            d("All", "");

            this.Close();
        }

        
    }
}
