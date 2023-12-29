using System;
using System.Windows.Forms;
using Npgsql;
using System.Data;
using System.Collections.Generic;
using System.Linq;


namespace deneme.project
{
    public partial class kategoriTipiForm : Form
    {
        // PostgreSQL bağlantısı için gerekli bilgileri ayarlayın
        NpgsqlConnection baglanti = new NpgsqlConnection("Host=localhost; Port=5432; Database=Project; Username=postgres; Password=labon");

        public kategoriTipiForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Bağlantıyı aç
                baglanti.Open();

                // Veritabanından verileri çek
                string sorgu = "SELECT id, tip FROM kategori_tipi";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // DataGridView'e verileri yükle
                dataGridView1.DataSource = ds.Tables[0];

                MessageBox.Show("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                baglanti.Close();
            }
        }

        // Yeni metod: Kategori tablosunu yükle
        public void LoadKategoriData()
        {
            try
            {
                // Bağlantıyı aç
                baglanti.Open();

                // Veritabanından verileri çek
                string sorgu = "SELECT id, ad, tip FROM kategori";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // DataGridView'e verileri yükle
                dataGridView1.DataSource = ds.Tables[0];

                MessageBox.Show("Bağlantı başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                baglanti.Close();
            }
        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Bağlantıyı aç
                baglanti.Open();

                // Veritabanından verileri çek
                string sorgu = "SELECT id, ad, tip FROM kategori";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // DataGridView'e verileri yükle
                dataGridView1.DataSource = ds.Tables[0];

                MessageBox.Show("Bağlantı başarılı! Kategori verileri yüklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                baglanti.Close();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                // Bağlantıyı aç
                baglanti.Open();

                // Veritabanından verileri çek
                string sorgu = "SELECT id, ad, fiyat FROM urun";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);

                // DataGridView'e verileri yükle
                dataGridView1.DataSource = ds.Tables[0];

                MessageBox.Show("Bağlantı başarılı! Ürün verileri yüklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                // Bağlantıyı kapat
                baglanti.Close();
            }
        }

        private void textİdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                // TextBox kontrollerinden değerleri al
                int idValue = Convert.ToInt32(textİdBox.Text);
                string adValue = textAdBox.Text;
                int fiyatValue = Convert.ToInt32(textFiyatBox.Text);

                // "urun" tablosuna ekle
                string eklemeSorgusu = "INSERT INTO urun (id, ad, fiyat) VALUES (@p1, @p2, @p3)";
                NpgsqlCommand eklemeKomutu = new NpgsqlCommand(eklemeSorgusu, baglanti);
                eklemeKomutu.Parameters.AddWithValue("@p1", idValue);
                eklemeKomutu.Parameters.AddWithValue("@p2", adValue);
                eklemeKomutu.Parameters.AddWithValue("@p3", fiyatValue);
                eklemeKomutu.ExecuteNonQuery();

                // DataGridView'i güncellenmiş veriyle yenile
                string secmeSorgusu = "SELECT id, ad, fiyat FROM urun";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(secmeSorgusu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                MessageBox.Show("Ürün ekleme işlemi başarılı bir şekilde gerçekleşti.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                // TextBox kontrollerinden değerleri al
                int idValue = Convert.ToInt32(textİdBox.Text);

                // "urun" tablosundan ilgili satırı sil
                string silmeSorgusu = "DELETE FROM urun WHERE id = @p1";
                NpgsqlCommand silmeKomutu = new NpgsqlCommand(silmeSorgusu, baglanti);
                silmeKomutu.Parameters.AddWithValue("@p1", idValue);
                silmeKomutu.ExecuteNonQuery();

                // DataGridView'i güncellenmiş veriyle yenile
                string secmeSorgusu = "SELECT id, ad, fiyat FROM urun";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(secmeSorgusu, baglanti);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                MessageBox.Show("Ürün silme işlemi başarılı bir şekilde gerçekleşti.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }
        // ... (previous code)

        // ... (previous code)

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                // TextBox kontrollerinden değerleri al
                if (int.TryParse(textİdBox.Text, out int idValue) && int.TryParse(textFiyatBox.Text, out int yeniFiyatValue))
                {
                    string yeniAdValue = textAdBox.Text;

                    // "urun" tablosunda ilgili satırı güncelle
                    string guncellemeSorgusu = "UPDATE urun SET ad = @p2, fiyat = @p3 WHERE id = @p1";
                    NpgsqlCommand guncellemeKomutu = new NpgsqlCommand(guncellemeSorgusu, baglanti);
                    guncellemeKomutu.Parameters.AddWithValue("@p1", idValue);
                    guncellemeKomutu.Parameters.AddWithValue("@p2", yeniAdValue);
                    guncellemeKomutu.Parameters.AddWithValue("@p3", yeniFiyatValue);
                    guncellemeKomutu.ExecuteNonQuery();

                    // DataGridView'i güncellenmiş veriyle yenile
                    string secmeSorgusu = "SELECT id, ad, fiyat FROM urun";
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(secmeSorgusu, baglanti);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];

                    MessageBox.Show("Ürün güncelleme işlemi başarılı bir şekilde gerçekleşti.");
                }
                else
                {
                    // ID veya Fiyat için geçersiz giriş
                    MessageBox.Show("ID veya Fiyat için geçersiz giriş. Lütfen geçerli bir tamsayı girin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void textAdBox_TextChanged(object sender, EventArgs e)
        {
            // TextBox metin değeri değiştiğinde yapılacak işlemler
            string yeniMetin = textAdBox.Text;

            // Yapmak istediğiniz işlemleri buraya ekleyin
            // Örneğin, yeniMetin'i kullanarak bir işlem gerçekleştirebilirsiniz.
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();

                // TextBox kontrollerinden değerleri al
                int idValue = 0;
                if (int.TryParse(textİdBox.Text, out int parsedId))
                {
                    idValue = parsedId;
                }

                string adValue = textAdBox.Text;

                int fiyatValue = 0;
                if (int.TryParse(textFiyatBox.Text, out int parsedFiyat))
                {
                    fiyatValue = parsedFiyat;
                }

                // Tablo sütun isimlerini kontrol et
                List<string> validColumns = new List<string> { "id", "ad", "fiyat" };

                List<string> invalidColumns = new List<string>();
                if (!validColumns.Contains("id"))
                    invalidColumns.Add("id");
                if (!validColumns.Contains("ad"))
                    invalidColumns.Add("ad");
                if (!validColumns.Contains("fiyat"))
                    invalidColumns.Add("fiyat");

                if (invalidColumns.Any())
                {
                    MessageBox.Show($"Hata: Var olmayan sütun(lar) [{string.Join(", ", invalidColumns)}] için arama yapılamaz.");
                    return;
                }

                // Ürün verilerini ara
                string aramaSorgusu = "SELECT id, ad, fiyat FROM urun WHERE (@p1 = 0 OR id = @p1) AND (@p2 = '' OR ad = @p2) AND (@p3 = 0 OR fiyat = @p3)";
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(aramaSorgusu, baglanti);
                da.SelectCommand.Parameters.AddWithValue("@p1", idValue);
                da.SelectCommand.Parameters.AddWithValue("@p2", adValue);
                da.SelectCommand.Parameters.AddWithValue("@p3", fiyatValue);

                DataSet ds = new DataSet();
                da.Fill(ds);

                // Check if any rows were returned
                if (ds.Tables[0].Rows.Count > 0)
                {
                    // DataGridView'e arama sonuçlarını yükle
                    dataGridView1.DataSource = ds.Tables[0];
                    MessageBox.Show("Arama işlemi başarılı!");
                }
                else
                {
                    // No matching records found
                    MessageBox.Show("Arama sonuçları bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }







        // ... (remaining code)

        // This is the correct closing brace for the class
    }

}

        // ... (remaining code)
      // <- This is the correct closing brace for the class
 public class KategoriManager
{
    private NpgsqlConnection baglanti;

    public KategoriManager(NpgsqlConnection connection)
    {
        baglanti = connection;
    }

    public void LoadKategoriData(DataGridView dataGridView)
    {
        // Kategori verilerini yükleme işlemleri
        // ...
    }

    public void AddKategori(string ad, string tip)
    {
        // Yeni kategori ekleme işlemleri
        // ...
    }

    // Diğer kategori işlemleri metotları
}

public class UrunManager
{
    private NpgsqlConnection baglanti;

    public UrunManager(NpgsqlConnection connection)
    {
        baglanti = connection;
    }

    public void LoadUrunData(DataGridView dataGridView)
    {
        // Ürün verilerini yükleme işlemleri
        // ...
    }

    public void AddUrun(string ad, int fiyat)
    {
        // Yeni ürün ekleme işlemleri
        // ...
    }

    // Diğer ürün işlemleri metotları
}
