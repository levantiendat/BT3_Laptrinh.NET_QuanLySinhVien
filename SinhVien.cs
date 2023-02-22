using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _102210247_LeVanTienDat
{
    public class SinhVien
    {
        

        public int mssv { get; set; }
        public string lopsh { get; set; }
        public DateTime ngaysinh { get; set; }
        public bool gioitinh { get; set; }
        public double diemtb { get; set; }
        public bool anh { get; set; }
        public bool hocba { get; set; }
        public bool cccd { get; set; }

        public SinhVien()
        {
            this.mssv = 0;
            this.lopsh = "";
            this.ngaysinh = DateTime.Now;
            this.gioitinh = false;
            this.diemtb = 0;
            this.anh = false;
            this.hocba = false;
            this.cccd = false;
        }
        public SinhVien(int mssv, string lopsh, DateTime ngaysinh, bool gioitinh, double diemtb, bool anh, bool hocba, bool cccd)
        {
            this.mssv = mssv;
            this.lopsh = lopsh;
            this.ngaysinh = ngaysinh;
            this.gioitinh = gioitinh;
            this.diemtb = diemtb;
            this.anh = anh;
            this.hocba = hocba;
            this.cccd = cccd;
        }

        public void Add(SinhVien s)
        {
            mssv = s.mssv;
            lopsh=s.lopsh;
            ngaysinh= s.ngaysinh;
            gioitinh= s.gioitinh;
            diemtb= s.diemtb;
            anh = s.anh;
            hocba = s.hocba;
            cccd=s.cccd;
        }
        public bool Del(int mssv)
        {
            if (this.mssv == mssv) return true;
            else return false;
        }
        public void update(SinhVien s)
        {
            lopsh = s.lopsh;
            ngaysinh = s.ngaysinh;
            gioitinh = s.gioitinh;
            diemtb = s.diemtb;
            anh = s.anh;
            hocba = s.hocba;
            cccd = s.cccd;
        }
        public SinhVien GetSVByDataRow(DataRow i)
        {
            return new SinhVien
            {
                mssv = Convert.ToInt32(i["MSSV"].ToString()),
                lopsh = i["Lớp sinh hoạt"].ToString(),
                ngaysinh = Convert.ToDateTime(i["Ngày sinh"].ToString()),
                gioitinh = Convert.ToBoolean(i["Giới tính"].ToString()),
                diemtb = Convert.ToDouble(i["Điểm TB"].ToString()),
                anh = Convert.ToBoolean(i["Ảnh"].ToString()),
                hocba = Convert.ToBoolean(i["Học bạ"].ToString()),
                cccd = Convert.ToBoolean(i["CCCD"].ToString()),


            };
        }
    }
}
