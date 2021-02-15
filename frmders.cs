using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BonusProje1
{
    public partial class frmders : Form
    {
        public frmders()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.TBL_DERSLERTableAdapter ds = new DataSet1TableAdapters.TBL_DERSLERTableAdapter();

        private void frmders_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtDersAd.Text);
            MessageBox.Show("Ders eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDersAd.Clear();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtDersAd.Text, byte.Parse(txtDersId.Text));
            MessageBox.Show("Ders bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDersAd.Clear();
            txtDersId.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtDersId.Text));
            MessageBox.Show("Ders silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDersId.Clear();
            txtDersAd.Clear();
        
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtDersId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtDersAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtDersAd.Clear();
            txtDersId.Clear();
        }
    }
}
