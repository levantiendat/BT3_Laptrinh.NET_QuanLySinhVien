using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102210247_LeVanTienDat
{
    public class QLSV
    {
        public List<string> GetAllLSH()
        {
            List<string> db = new List<string>();
            foreach(SinhVien i in CSDL.Instance.GetAllSV())
            {
                db.Add(i.lopsh);
            }
            return db.Distinct().ToList();
        }
        public List<SinhVien> GetSinhVienBySearch(string lopsh, string txt)
        {
            List<SinhVien> db=new List<SinhVien>();
            if (lopsh.CompareTo("All")==0)
            {
                db=CSDL.Instance.GetAllSV();
            }
            else
            {
                foreach(SinhVien i in CSDL.Instance.GetAllSV())
                {
                    if(i.lopsh== lopsh)
                    {
                        db.Add(i);
                    }
                }
            }
            //tren list db hien tai, lay cac doi tuong can hien thi vao txt --> Contains(txt)
            List<SinhVien> dbs=new List<SinhVien>();

            if (txt != "")
            {
                foreach(SinhVien i in db)
                {
                    if (i.mssv.ToString().Contains(txt)==true)
                    {
                        dbs.Add(i);
                    }
                    
                }
                return dbs;
            }
            else
            {
                return db;
            }
            
        }
        public void DelSV(List<string> li)
        {
            foreach(string i in li)
            {
                CSDL.Instance.Del(i);
            }
        }
        private List<SinhVien> GetSVByDGV(List<string> li)
        {
            List<SinhVien> db = new List<SinhVien>();
            foreach(string i in li)
            {
                foreach(SinhVien j in CSDL.Instance.GetAllSV())
                {
                    if (Convert.ToInt32(i) == j.mssv)
                    {
                        db.Add(j);
                    }
                }
            }
            return db;
        }
        public List<SinhVien> SortBy(List<string> li, string txt) 
        {
            List<SinhVien> lp=new List<SinhVien>();
            lp = GetSVByDGV(li);
            
            if (txt == "MSSV")
            {
                for(int i = 0; i < lp.Count - 1; i++)
                {
                    for(int j = i + 1; j < lp.Count; j++)
                    {
                        if (lp[i].mssv > lp[j].mssv)
                        {
                            SinhVien tmp= new SinhVien();
                            tmp = lp[i];
                            lp[i] = lp[j];
                            lp[j] = tmp;
                        }
                    }
                }
            }
            else if (txt == "Lớp SH")
            {
                for (int i = 0; i < lp.Count - 1; i++)
                {
                    for (int j = i + 1; j < lp.Count; j++)
                    {
                        if (String.Compare(lp[i].lopsh, lp[j].lopsh)>0)
                        {
                            SinhVien tmp = new SinhVien();
                            tmp = lp[i];
                            lp[i] = lp[j];
                            lp[j] = tmp;
                        }
                    }
                }
            }
            else if (txt == "Ngày sinh")
            {
                for (int i = 0; i < lp.Count - 1; i++)
                {
                    for (int j = i + 1; j < lp.Count; j++)
                    {
                        if (DateTime.Compare(lp[i].ngaysinh, lp[j].ngaysinh) > 0)
                        {
                            SinhVien tmp = new SinhVien();
                            tmp = lp[i];
                            lp[i] = lp[j];
                            lp[j] = tmp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < lp.Count - 1; i++)
                {
                    for (int j = i + 1; j < lp.Count; j++)
                    {
                        if (lp[i].diemtb > lp[j].diemtb)
                        {
                            SinhVien tmp = new SinhVien();
                            tmp = lp[i];
                            lp[i] = lp[j];
                            lp[j] = tmp;
                        }
                    }
                }
            }
            return lp;
            //if theo txt
            //SX GétVByDGV theo thuoc tinh, tra ve List<SV> da sap xep


        }
        public SinhVien GetSVByMSSV(int mssv)
        {
            SinhVien s = new SinhVien();
            foreach(SinhVien i in CSDL.Instance.GetAllSV())
            {
                if (mssv == i.mssv)
                {
                    s = i;
                    break;
                }
            }
            return s;
        }
        private bool Check(int mssv)
        {
            bool check = false;
            foreach(SinhVien i in CSDL.Instance.GetAllSV())
            {
                if (mssv == i.mssv)
                {
                    check = true;
                    break;
                }
            }
            return check;
        }
        public void SyncDB(SinhVien s)
        {
            if (Check(s.mssv))
            {
                CSDL.Instance.Update(s);
                
            }
            else
            {
                CSDL.Instance.add(s);
            }
        }
    }
}
