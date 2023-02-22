using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _102210247_LeVanTienDat
{
    public class CSDL
    {
        private DataTable dt;
        private static CSDL _Instance;

        public static CSDL Instance
        {
            get { 
                if (_Instance == null)
                    _Instance = new CSDL();
                return _Instance; }
            private set { }
        }
        private CSDL()
        {
            dt=new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn{ColumnName="MSSV",DataType = typeof(int) },
                new DataColumn{ColumnName="Lớp sinh hoạt",DataType = typeof(string) },
                new DataColumn{ColumnName="Ngày sinh",DataType = typeof(DateTime) },
                new DataColumn{ColumnName="Giới tính",DataType = typeof(string) },
                new DataColumn{ColumnName="Điểm TB",DataType = typeof(double) },
                new DataColumn{ColumnName="Ảnh",DataType = typeof(bool) },
                new DataColumn{ColumnName="Học bạ",DataType = typeof(bool) },
                new DataColumn{ColumnName="CCCD",DataType = typeof(bool) },

            });
            
        }
        public List<SinhVien> GetAllSV()
        {
            List<SinhVien> db = new List<SinhVien>();
            
            foreach (DataRow i in dt.Rows)
            {
                db.Add(GetSVByDataRow(i));
            }
            return db;
            
        }
        public SinhVien GetSVByDataRow(DataRow i)
        {
            SinhVien s= new SinhVien();
            s.mssv = Convert.ToInt32(i["MSSV"].ToString());
            s.lopsh = i["Lớp sinh hoạt"].ToString();
            s.ngaysinh = Convert.ToDateTime(i["Ngày sinh"].ToString());
            s.gioitinh = Convert.ToBoolean(i["Giới tính"].ToString());
            s.diemtb = Convert.ToDouble(i["Điểm TB"].ToString());
            s.anh = Convert.ToBoolean(i["Ảnh"].ToString());
            s.hocba = Convert.ToBoolean(i["Học bạ"].ToString());
            s.cccd = Convert.ToBoolean(i["CCCD"].ToString());
            return s;
        }
        public void Del(string s)
        {
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["MSSV"].ToString() == s)
                {
                    dt.Rows.RemoveAt(i);
                    break;
                }
            }
        }
        public void Update (SinhVien s)
        {
            List<SinhVien> p=new List<SinhVien>();
            SinhVien k = new SinhVien();
            k.Add(s);
            p = GetAllSV();
            for(int i = 0; i < p.Count; i++)
            {
                if (k.mssv == p[i].mssv)
                {
                    p[i].update(k);
                    break;
                }
            }
            dt.Clear();
            foreach(SinhVien v in p)
            {
                dt.Rows.Add(v.mssv, v.lopsh, v.ngaysinh, v.gioitinh, v.diemtb, v.anh, v.hocba, v.cccd);
            }
        }
        public void add(SinhVien s)

        {
            SinhVien v = new SinhVien();
            v.Add(s);
            dt.Rows.Add(v.mssv, v.lopsh, v.ngaysinh, v.gioitinh, v.diemtb,  v.anh, v.hocba, v.cccd);
            
        }
    }

}
