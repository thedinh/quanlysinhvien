using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // khởi tạo ra 2 đối tượng hs_ctrl và hs_info
        HocSinhCtrl hs_ctrl = new HocSinhCtrl();
        HocSinhinfo hs_info = new HocSinhinfo();
        private void Form1_Load(object sender, EventArgs e)
        {
            DataProvider.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\MSI MODERN 15\\OneDrive\\Máy tính\\MVC_Form\\WindowsFormsApp1\\WindowsFormsApp1\\App_data\\hocsinhdata.mdf\";Integrated Security=True";
            hs_ctrl.Connect();
            loadlop();
            loadDSHS();
            hs_ctrl.Disconnect();
        }
        // hiện thị lớp
        public void loadlop()
        {
            cbolop.DisplayMember = "tenlop";
            cbolop.ValueMember = "malop";
            cbolop.DataSource = hs_ctrl.getDataTable();
        }
        // hiện thị danh sách học sinh
        public void loadDSHS()
        {
            dgrhocsinh.DataSource = hs_ctrl.GetinfoHS();
        }
        // nhút nhập
        private void button1_Click(object sender, EventArgs e)
        {
            hs_ctrl.Connect();
            hs_info.MaHS = txtmahs.Text;
            hs_info.TenHS = txttenhs.Text;
            hs_info.NgaySinh = dtngaysinh.Value;
            hs_info.DiaChi = txtdiachi.Text;
            hs_info.DTB = txtdiemtrungbinh.Text;
            hs_info.MaLop = cbolop.SelectedValue.ToString();
            hs_ctrl.addHS(hs_info.MaHS, hs_info.TenHS, hs_info.NgaySinh, hs_info.DiaChi, hs_info.DTB, hs_info.MaLop);
            loadDSHS();
            hs_ctrl.Disconnect();
        }
        // nút xóa
        private void btnxoa_Click(object sender, EventArgs e)
        {
            hs_ctrl.Connect();
            DialogResult h = MessageBox.Show("Bạn có chắc muốn xóa học sinh này không?", "cảnh báo", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
            {
                if (dgrhocsinh.SelectedCells.Count > 0)
                {
                    int selectRowIndex = dgrhocsinh.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgrhocsinh.Rows[selectRowIndex];
                    string cellValue = Convert.ToString(selectedRow.Cells["mahs"].Value);
                    hs_ctrl.deleteHS(cellValue);
                    MessageBox.Show("xóa thành công");
                    loadDSHS();
                    reset();
                }
                else
                {
                    MessageBox.Show("không có gì để xóa nữa");
                    loadDSHS();
                }
            }
            hs_ctrl.Disconnect();

        }
        // nút sửa
        private void btnsua_Click(object sender, EventArgs e)
        {
            hs_ctrl.Connect();
            hs_info.MaHS = txtmahs.Text;
            hs_info.TenHS = txttenhs.Text;
            hs_info.NgaySinh = dtngaysinh.Value;
            hs_info.DiaChi = txtdiachi.Text;
            hs_info.DTB = txtdiemtrungbinh.Text;
            hs_info.MaLop = cbolop.SelectedValue.ToString();
            hs_ctrl.updateHS(hs_info.MaHS, hs_info.TenHS, hs_info.NgaySinh, hs_info.DiaChi, hs_info.DTB, hs_info.MaLop);
            loadDSHS();
            reset();
            hs_ctrl.Disconnect();
        }
        // hàm reset 
        public void reset(){
            txtmahs.Clear();
            txttenhs.Clear();
            txtdiachi.Clear();
            txtdiemtrungbinh.Clear();
            cbolop.SelectedIndex = 0;
        }
        // hàm lấy dữ liệu từ datagridview rồi đẩy lên textbox
        private void dgrhocsinh_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgrhocsinh.SelectedRows){
                txtmahs.Text = row.Cells[0].Value.ToString();
                txttenhs.Text = row.Cells[1].Value.ToString();
                dtngaysinh.Value = Convert.ToDateTime(row.Cells[2].Value.ToString());
                txtdiachi.Text = row.Cells[3].Value.ToString();
                txtdiemtrungbinh.Text = Convert.ToString(row.Cells[4].Value);
                cbolop.SelectedValue = row.Cells[5].Value.ToString();
                txtmahs.ReadOnly = true;
            }
        }
    }
}
