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

namespace BonusProje1
{
    public partial class frmKulup : Form
    {
        public frmKulup()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=BARıŞ;Initial Catalog=BonusOkul;Integrated Security=True");
        private void frmKulup_Load(object sender, EventArgs e)
        {
            
        }

        public void liste()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select* from TBL_KULUPLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBL_KULUPLER (KULUPAD) values (@p1)",baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulüpAd.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp bilgileri başarı ile eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information );
            liste();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from TBL_KULUPLER Where KULUPID=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulüpId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp bilgileri silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update TBL_KULUPLER set KULUPAD=@p1 where KULUPID=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", txtKulüpAd.Text);
            komut.Parameters.AddWithValue("@p2", txtKulüpId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kulüp bilgileri güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKulüpId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKulüpAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
