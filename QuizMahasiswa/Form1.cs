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

namespace QuizMahasiswa
{
    public partial class Form1 : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ALDVS5GI;Initial Catalog=QuizMahasiswa;Integrated Security=True;");

        public Form1()
        {
            InitializeComponent();
        }


        DataClasses1 db = new DataClasses1();
        private void btnSave_Click(object sender, EventArgs e)
        {
            string barang = txtNamaBarang.Text;
            int harga = int.Parse(txtHarga.Text);
            int stok = int.Parse(txtStok.Text);
            string supplier = txtSupplier.Text;
            var data = new tbl_barang
            {
                nama_barang = barang,
                harga = harga,
                stok = stok,
                nama_supplier = supplier
            };
            db.tbl_barangs.InsertOnSubmit(data);
            db.SubmitChanges();
            MessageBox.Show("Save Successfully");
            txtNamaBarang.Clear();
            txtHarga.Clear();
            txtStok.Clear();
            txtSupplier.Clear();
            LoadData();
        }

        void LoadData()
        {
            var st = from tb in db.tbl_barangs select tb;
            dt.DataSource = st;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            MasterBarang007 a = new MasterBarang007();
            a.Close();
        }
    }
}
