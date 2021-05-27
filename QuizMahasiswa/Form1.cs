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

        SqlConnection con = new SqlConnection("integrated security=true; data source=.;initial catalog=quizmahasiswa");
        DataClasses1DataContext db = new DataClasses1DataContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtHarga.Text == "" || txtStok.Text == "" || txtSupplier.Text == "" || txtNamaBarang.Text == "")
            {
                MessageBox.Show
                ("Seluruh data wajib diisi dengan benar!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    int id = int.Parse(txtID.Text);
                    string nama_brg = txtNamaBarang.Text;
                    int hrg = int.Parse(txtHarga.Text);
                    int stck = int.Parse(txtStok.Text);
                    string nama_sup = txtSupplier.Text;
                    var data = new tbl_barang
                    {
                        id_barang = id,
                        nama_barang = nama_brg,
                        harga = hrg,
                        stok = stck,
                        nama_supplier = nama_sup
                    };

                    db.tbl_barangs.InsertOnSubmit(data);
                    db.SubmitChanges();
                    MessageBox.Show("Save Successfully");
                    txtHarga.Clear();
                    txtNamaBarang.Clear();
                    txtStok.Clear();
                    txtSupplier.Clear();
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex);
                }
            }
        }
        private void MasterBarang022_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max (cast (id_barang as int)),0) +1 from tbl_barang", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                txtID.Text = dt.Rows[0][0].ToString();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        void LoadData()
        {
            try
            {
                var st = from tb in db.tbl_barangs select tb;
                dt.DataSource = st;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void txtHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select isnull(max (cast (id_barang as int)),0) +1 from tbl_barang", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                txtID.Text = dt.Rows[0][0].ToString();
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
    }
}
