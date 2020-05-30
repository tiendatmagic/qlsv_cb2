/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


//Ahihi Tiendatmagic
namespace quanlysinhvien
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> listName;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void btnKetnoi_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                using (SqlConnection connection =

                    new SqlConnection(@"Server=DESKTOP-24L225P;Database=QuanLySinhVien; Integrated Security=SSPI"))

                {

                    connection.Open();

                }

                MessageBox.Show("Mo va dong co so du lieu thanh cong(KETNOI).");

            }

            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi: " + ex.Message);

            }
        }

        private void btnDulieu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=QuanLySinhVien; Integrated Security=SSPI"))
                using (SqlCommand command =
                    new SqlCommand("SELECT MaSV, TenSV, Email, MaKH FROM SinhVien; ", connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(danhsach);
                    }
                }
                MessageBox.Show("Ket noi co so du lieu thanh cong,HIHI.");
                dulieu.ItemsSource = danhsach.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }

        }

        private void btnThem_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text;
            sv.TenSV = txtTenSV.Text;
            sv.Email = txtEmail.Text;
            sv.MaKH = txtMaKH.Text;
            Them_sinh_vien(sv);
        }

        private void Them_sinh_vien(SinhVien sinhvien)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=QuanLySinhVien; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM SinhVien;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    DataRow sv = danhsach.NewRow();
                    sv["MaSV"] = sinhvien.MaSV;
                    sv["TenSV"] = sinhvien.TenSV;
                    sv["Email"] = sinhvien.Email;
                    sv["MaKH"] = sinhvien.MaKH;
                    danhsach.Rows.Add(sv);
                    adapter.Update(danhsach);
                }
                MessageBox.Show("Them du lieu thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
        

    }

    private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien();
            sv.MaSV = txtMaSV.Text;
            Xoa_sinh_vien(sv);
        }


        private void Xoa_sinh_vien(SinhVien sinhvien)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=QuanLySinhVien; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM SinhVien;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    DataRow[] dt =
                    danhsach.Select("MaSV = '" + sinhvien.MaSV + "'");
                    dt[0].Delete();
                    adapter.Update(dt);
                }
                MessageBox.Show("Xoa du lieu thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
        }

        private void btnCapnhat_Click(object sender, RoutedEventArgs e)
        {
            SinhVien sv = new SinhVien();
            txtMaSV.MaxLength = 9;
            sv.MaSV = txtMaSV.Text;
            sv.TenSV = txtTenSV.Text;
            sv.Email = txtEmail.Text;
            sv.MaKH = txtMaKH.Text;
            Cap_nhat_sinh_vien(sv);
        }





        private void Cap_nhat_sinh_vien(SinhVien sinhvien)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=QuanLySinhVien; Integrated Security=SSPI"))
                using (SqlCommand command =
                new SqlCommand("SELECT * FROM SinhVien;", connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                using (SqlCommandBuilder builder = new SqlCommandBuilder(adapter))
                {
                    adapter.FillSchema(danhsach, SchemaType.Source);
                    adapter.Fill(danhsach);
                    DataRow[] dt = danhsach.Select(
                    "MaSV = '" + sinhvien.MaSV + "'");
                    dt[0]["TenSV"] = sinhvien.TenSV;
                    dt[0]["Email"] = sinhvien.Email;
                    dt[0]["MaKH"] = sinhvien.MaKH;
                    adapter.Update(danhsach);
                }
                MessageBox.Show("Cap nhat du lieu thanh cong!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
        }

        private void cbmakh_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(cbmakh.SelectedValue.ToString());
            hienthi(cbmakh.SelectedValue.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hienthicbx1(); 
        }

        public void hienthi (string S)
        {
            try
            {
                DataTable danhsach = new DataTable();
                using (SqlConnection connection =
                new SqlConnection(@"Server=DESKTOP-24L225P;Database=QuanLySinhVien; Integrated Security=SSPI"))
                using (SqlCommand command =
                    new SqlCommand("select SinhVien.MaSV,SinhVien.TenSV,SinhVien.Email,SinhVien.MaKH from SinhVien, Khoa where SinhVien.MaKH = Khoa.MaKH and Khoa.MaKH =" + "'" + S + "';", connection))
                
                    {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(danhsach);
                    }
                }
               // MessageBox.Show("Ket noi co so du lieu thanh cong,HIHI.");
                dulieu.ItemsSource = danhsach.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi khi mo ket noi: " + ex.Message);
            }
        }

        public void hienthicbx1()
        {
            try

            {

               
                
                string connectionString =

                       ConfigurationManager.ConnectionStrings["QLSV"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))

                using (SqlCommand command = new SqlCommand("SELECT MaKH, TenKhoa FROM Khoa;",

                                connection))

                {

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())

                    {

                        //xử lý tập dữ liệu từ bảng Khoa

                        while (reader.Read())

                        {

                           

                            



                            cbmakh.Items.Add(reader.GetString(0));

                        }

                        //di chuyển đến tập dữ liệu từ bảng SinhVien



                        //MessageBox.Show("Du lieu tu bang Khoa:");


                    }
                }
            }


            catch (Exception ex)

            {

                MessageBox.Show("Loi khi mo  ket noi:" + ex.Message);

            }
        }
    }


   
}
//Ahihi Tiendatmagic
//Copy and paste by Tiendatmagic ahihi



 * */