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
    public partial class frmOgrNot : Form
    {
        public frmOgrNot()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=BARıŞ;Initial Catalog=BonusOkul;Integrated Security=True");
        public string numara;
        private void frmOgrNot_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("SELECT DERSAD,SINAV1,SINAV2,SINAV3,PROJE,ORTALAMA,DURUM FROM TBL_NOTLAR INNER JOIN TBL_DERSLER ON TBL_NOTLAR.DERSID = TBL_DERSLER.DERSID WHERE OGRENCIID = @p1", baglanti);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            //isim çekme
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select OGRAD,OGRSOYAD from TBL_OGRENCILER where OGRID=@p1", baglanti);
            komut1.Parameters.AddWithValue("@p1", numara);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                this.Text = dr1[0] + " " + dr1[1].ToString();
            }
            baglanti.Close();
        }
    }
}
