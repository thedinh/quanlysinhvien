using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class HocSinhCtrl
    {
        DataProvider _provider ;
        HocSinhinfo _hs_info;
        public HocSinhCtrl() {
            _provider = new DataProvider();
            _hs_info = new HocSinhinfo();
        }
        public void Connect()
        {
              _provider.Connect();
        }

        public DataTable getDataTable() {
            return _provider.GetDataTable("sp_select","Lop");
        }
        public DataTable GetinfoHS()
        {
            return _provider.GetDataTable("sp_select","HocSinh");
        }
        // function insert students
        public void addHS(string mahs,string tenhs,DateTime ngaysinh,string diachi,string dtb,string malop) {
           _provider.ENQInsert_HS("sp_insertHocSinh",mahs,tenhs,ngaysinh,diachi,dtb,malop);
        }
        // function delete students
        public void deleteHS(string selectedrow) {
            _provider.ENQDelete_HS("sp_deleteHS","HocSinh","mahs = '"+ selectedrow + "'");
        }

        public void updateHS(string mahs, string tenhs, DateTime ngaysinh, string diachi, string dtb, string malop) {
           _provider.ENQUpdateHS("sp_updateHocSinh", mahs, tenhs, ngaysinh, diachi, dtb, malop);
        }
        public void Disconnect()
        {
            _provider.Disconnect();
        }
    }
}
