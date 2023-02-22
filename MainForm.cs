using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Threading;

namespace _102210247_LeVanTienDat
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            
            
            GetCBBLSH();
        }
        public void GetCBBLSH()
        {
            lop1.Items.Add("All");
            QLSV e=new QLSV();
            lop1.Items.AddRange(e.GetAllLSH().ToArray());
        }

        public void ShowDGV(string lopsh, string txt)
        {
            QLSV f = new QLSV();
            
            data.DataSource = f.GetSinhVienBySearch(lopsh, txt);
        }
        private void buttonadd_Click(object sender, EventArgs e)
        {
            DetailForm dtf= new DetailForm(0);
           
            dtf.d += new DetailForm.MyDel(ShowDGV);
            //ShowDGV("All", "");
            dtf.Show();

            

        }
        
        private void buttonedit_Click(object sender, EventArgs e)
        {
            if (data.SelectedRows.Count == 1)
            {
                int mssv =Convert.ToInt32(data.SelectedRows[0].Cells["MSSV"].Value.ToString());
                DetailForm f=new DetailForm(mssv);
                f.d+=new DetailForm.MyDel(ShowDGV);
                f.Show();
            }
            
        }
       
        private void buttondelete_Click(object sender, EventArgs e)
        {
            List<string > list = new List<string>();
            if (data.SelectedRows.Count > 0)
            {
                foreach(DataGridViewRow i in data.SelectedRows)
                {
                    list.Add(i.Cells["MSSV"].Value.ToString());
                }
                QLSV f =new QLSV();
                f.DelSV(list);
                ShowDGV("All", "");
                //ShowDGV(lop1.SelectedItem.ToString(), textsearch.Text);
            }


        }

        private void buttonsearch_Click(object sender, EventArgs e)
        {
            string lopsh = lop1.SelectedItem.ToString();
            string txt=textsearch.Text;
            ShowDGV(lopsh, txt);
        }

        private void buttonsort_Click(object sender, EventArgs e)
        {
            List<string> li =new List<string>();
            foreach(DataGridViewRow i in data.Rows)
            {
                li.Add(i.Cells["MSSV"].Value.ToString());
            }
            QLSV f =new QLSV();
            
            data.DataSource = f.SortBy(li, sort.SelectedItem.ToString());
        }

        
    }
}
