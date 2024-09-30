using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LINQ
{
    public partial class Form1 : Form
    {
        List<Products> products = new List<Products>();
        public Form1()
        {
            InitializeComponent();
            
            //Hien thi listview 1
            listView1.View = View.Details;
            listView1.Columns.Add("Mã SP ", 60);
            listView1.Columns.Add("Tên SP", 120);
            listView1.Columns.Add("SL", 50);
            listView1.Columns.Add("Đơn giá", 60);
            listView1.Columns.Add("Xuất sứ", 100);
            listView1.Columns.Add("Ngày hết hạn", 100);


            //Hien thi listview 2
            listView2.View = View.Details;
            listView2.Columns.Add("Mã SP ", 60);
            listView2.Columns.Add("Tên SP", 120);
            listView2.Columns.Add("SL", 50);
            listView2.Columns.Add("Đơn giá", 60);
            listView2.Columns.Add("Xuất sứ", 100);
            listView2.Columns.Add("Ngày hết hạn", 100);
            //Products product = new Products("SP1","But bi", 10, 100, "VN",dateTimePicker1.Value);
            //ListViewItem item = new ListViewItem("SP1");
            //item.SubItems.Add(dateTimePicker1.Value.ToString("dd/mm/yyyy"));
            //listView1.Items.Add(item);


        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckValid(textBox1, textBox2, textBox3, textBox4, textBox5))
            {
                Products product = new Products(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), double.Parse(textBox4.Text), textBox5.Text, dateTimePicker1.Value);
                AddProductToListView(listView2, product);
                products.Add(product);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Error", MessageBoxButtons.OK);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (CheckValid(textBox1))
            {
                Products productToRemove = products.FirstOrDefault(p => p.ID == textBox1.Text);

                if (productToRemove != null)
                {
                    
                    products.Remove(productToRemove);
                    ReloadProductsToListView(listView2, products);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm để xóa", "Error", MessageBoxButtons.OK);

            }

        }
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var highestPricedProduct = products
    .OrderByDescending(p => p.Price)
    .FirstOrDefault();
            if (highestPricedProduct != null)
            {
                AddProductToListView(listView1, highestPricedProduct);
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào", "Error", MessageBoxButtons.OK);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var JapanProduct = products.Where(p => p.Origin == "JP").ToList();
            ReloadProductsToListView(listView1, JapanProduct);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (products == null) return;
            listView1.Items.Clear();
            DateTime dateTime = DateTime.Now;
            var ExpiredProduct = products.Where(p => p.Expiry < dateTime).ToList();
            ReloadProductsToListView(listView1, ExpiredProduct);

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (products == null) return;
            listView1.Items.Clear();
            var productsInRange = products.Where(p => p.Price >= int.Parse(textBox7.Text) && p.Price <= int.Parse(textBox8.Text)).ToList(); ;
            ReloadProductsToListView(listView1, productsInRange);


        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (CheckValid(textBox6))
            {
                Products productToRemove = products.FirstOrDefault(p => p.Origin == textBox6.Text);

                if (productToRemove != null)
                {

                    products.Remove(productToRemove);
                    ReloadProductsToListView(listView2, products);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã sản phẩm để xóa", "Error", MessageBoxButtons.OK);

            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (products == null) return;
            listView1.Items.Clear();
            DateTime dateTime = DateTime.Now;
            var ExpiredProduct = products.Where(p => p.Expiry < dateTime).ToList();
            if (ExpiredProduct.Count > 0)
            {
                MessageBox.Show("Kho có " + ExpiredProduct.Count + " sản phẩm quá hạn", "", MessageBoxButtons.OK);

            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            products.Clear();
            listView1.Items.Clear();
            listView2.Items.Clear();
        }





        private bool CheckValid(params TextBox[] textBoxes)
        {
            foreach (TextBox box in textBoxes)
            {
                if(string.IsNullOrEmpty(box.Text)) return false;
            }
            return true;
        }
        private void AddProductToListView (ListView listView, Products products)
        {
            if (products == null) return;
            ListViewItem item = new ListViewItem(products.ID);
            item.SubItems.Add(products.Name);
            item.SubItems.Add(products.Quantity.ToString());
            item.SubItems.Add(products.Price.ToString());
            item.SubItems.Add(products.Origin);
            item.SubItems.Add(products.Expiry.ToString("dd/mm/yyyy"));

            listView.Items.Add(item);
        }
        private void ReloadProductsToListView(ListView listView, List<Products> products)
        {
            if (products == null) return;
            listView.Items.Clear();
            foreach (Products product in products)
            {
                ListViewItem item = new ListViewItem(product.ID);
                item.SubItems.Add(product.Name);
                item.SubItems.Add(product.Quantity.ToString());
                item.SubItems.Add(product.Price.ToString());
                item.SubItems.Add(product.Origin);
                item.SubItems.Add(product.Expiry.ToString("dd/mm/yyyy"));
                listView.Items.Add(item);
            }

        }

    }
}
