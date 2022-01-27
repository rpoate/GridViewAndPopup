using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridViewAndPopup
{
    public partial class Form1 : Form
    {

        private class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public double Price { get; set; }

            public Product(string name, string desc, double price)
            {
                Name = name;
                Description = desc;
                Price = price;
            }

        }

        private List<Product> AllProducts;

        public Form1()
        {
            InitializeComponent();

            AllProducts = new List<Product>
            {
                new Product("Product1", "Product <strong>1</strong> Desc", 123.23),
                new Product("Product2", "Product <u>2</u> Desc", 99.99),
                new Product("Product3", "Product 3 Desc", 100.50)
            };

            this.dataGridView1.DataSource = AllProducts;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            frmEdit oEdit = new frmEdit();

            oEdit.htmlEditControl1.DocumentHTML = AllProducts[e.RowIndex].Description;
            oEdit.FormClosing += OEdit_FormClosing;
            oEdit.ShowDialog(this);

        }

        private void OEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllProducts[dataGridView1.SelectedRows[0].Index].Description = ((frmEdit)sender).htmlEditControl1.DocumentHTML;
            this.dataGridView1.Refresh();
        }
    }
}
