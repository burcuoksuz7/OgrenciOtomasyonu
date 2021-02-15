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
    public partial class frmOgrenci : Form
    {
        public frmOgrenci()
        {
            InitializeComponent();
        }

        
        
        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection baglanti = new SqlConnection(@"Data Source=BARıŞ;Initial Catalog=BonusOkul;Integrated Security=True");

        private void frmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from TBL_KULUPLER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KULUPAD";
            comboBox1.ValueMember = "KULUPID";
            comboBox1.DataSource = dt;
            baglanti.Close();
        }
        string c = "";
        private void btnEkle_Click(object sender, EventArgs e)
        {
            

            ds.OgrenciEkle(txtOgrAd.Text, txtOgrSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Öğrenci eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtOgrId.Text = comboBox1.SelectedValue.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtOgrId.Text));
        }
        string cinsiyet;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtOgrId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtOgrAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtOgrSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cinsiyet = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (cinsiyet == "Erkek")
            {
                rbErkek.Checked = true;
                rbKadın.Checked = false;
            }
            if (cinsiyet == "Kadın")
            {
                rbErkek.Checked = false;
                rbKadın.Checked = true;
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrencıGuncelle(txtOgrAd.Text, txtOgrSoyad.Text,byte.Parse( comboBox1.SelectedValue.ToString()), c, int.Parse(txtOgrId.Text));
            MessageBox.Show("Öğrenci bilgisi güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void rbErkek_CheckedChanged(object sender, EventArgs e)
        {
            if (rbErkek.Checked == true)
            {
                c = "Erkek";
            }          
        }

        private void rbKadın_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKadın.Checked == true)
            {
                c = "Kadın";
            }           
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciGetir(txtAra.Text);
        }
    }
}
