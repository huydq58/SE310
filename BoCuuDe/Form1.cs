using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoCuuDe;

namespace BoCuuDe
{
    public partial class Form1 : Form
    {
        Bo bo;
        Cuu cuu;
        De de;
        string connectionString = @"Data Source=LAPTOP-EMD0MQBF\SQLEXPRESS;Initial Catalog=BoCuuDe;User ID=sa;Password=huy582004";


        public Form1()
        {
            InitializeComponent();
            inputBo.Text = "0";
            inputCuu.Text = "0";
            inputDe.Text = "0";


            // Đặt chế độ hiển thị cho ListView là Details
            listView1.View = View.Details;

            // Thêm cột vào ListView
            listView1.Columns.Add("ID ", 100);  
            listView1.Columns.Add("Tên gia súc", 250);  
            listView1.Columns.Add("Số lượng ", 250);  
            // Tạo danh sách dữ liệu cho bảng 3 dòng, 2 cột
            string[,] data = new string[,]
            {
                { "Dòng 1, Cột 1", "Dòng 1, Cột 2" },
                { "Dòng 2, Cột 1", "Dòng 2, Cột 2" },
                { "Dòng 3, Cột 1", "Dòng 3, Cột 2" }
            };

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();
                    Console.WriteLine("Kết nối thành công!");

                    // Truy vấn dữ liệu từ bảng GIASUC
                    string query = "SELECT * FROM GIASUC";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Xóa các mục cũ trong ListView
                        listView1.Items.Clear();

                        // Duyệt qua từng dòng dữ liệu
                        while (reader.Read())
                        {
                            // Tạo một ListViewItem đại diện cho một dòng
                            ListViewItem item = new ListViewItem(reader["ID"].ToString());  // Cột ID
                            item.SubItems.Add(reader["TENGIASUC"].ToString());  // Cột TENGIASUC
                            item.SubItems.Add(reader["SOLUONG"].ToString());  // Cột SOLUONG

                            // Thêm dòng vào ListView
                            listView1.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra lại.\n\nLỗi: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {

                    connection.Open();
                    Console.WriteLine("Kết nối thành công!");

                    // Truy vấn dữ liệu từ bảng GIASUC
                    string query = "UPDATE GIASUC\r\nSET SOLUONG+=SOLUONG/2";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("Số dòng đã cập nhật: " + rowsAffected);
                        button1_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra lại.\n\nLỗi: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bo = new Bo(int.Parse(inputBo.Text));
            cuu = new Cuu(int.Parse(inputCuu.Text));
            de = new De(int.Parse(inputDe.Text));

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();
                    Console.WriteLine("Kết nối thành công!");

                    // Câu lệnh SQL để cập nhật số lượng
                    string query = "UPDATE GIASUC SET SOLUONG = SOLUONG + @SoLuongBo WHERE ID ='1';" +
                        "UPDATE GIASUC SET SOLUONG = SOLUONG + @SoLuongCuu WHERE ID ='2'" +
                        "UPDATE GIASUC SET SOLUONG = SOLUONG + @SoLuongDe WHERE ID ='3'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào câu lệnh
                        command.Parameters.AddWithValue("@SoLuongBo", bo.SoLuong);
                        command.Parameters.AddWithValue("@SoLuongCuu", cuu.SoLuong);
                        command.Parameters.AddWithValue("@SoLuongDe", de.SoLuong);
                    

                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("Số dòng đã cập nhật: " + rowsAffected);
                        button1_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Vui lòng kiểm tra lại.\n\nLỗi: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
