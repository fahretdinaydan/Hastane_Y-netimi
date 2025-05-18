using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hastane_Yönetimi
{
    public partial class Form4 : Form
    {
        private Form3 _form3;

        public Form4(Form3 form3)
        {
            InitializeComponent();
            _form3 = form3;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.randevularTableAdapter.Fill(this.dataSet1.Randevular);
            this.doktorlarTableAdapter.Fill(this.dataSet1.Doktorlar);
            this.bolumlerTableAdapter.Fill(this.dataSet1.Bolumler);

            comboBox1.DisplayMember = "HastaAdSoyad";
            comboBox1.ValueMember = "HastaID";

            comboBox2.DisplayMember = "DoktorAdSoyad";
            comboBox2.ValueMember = "DoktorID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-0SI016LJ\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"))
                {
                    conn.Open();

                    if (comboBox2.SelectedItem == null || comboBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    bool randevuUygun = KontrolEtRandevuUygunMu();

                    if (randevuUygun)
                    {
                        string sorgu = "INSERT INTO Randevular (RandevuID, HastaID, DoktorID, Tarih, Saat) " +
                                       "VALUES (@RandevuID, @HastaID, @DoktorID, @Tarih, @Saat)";

                        SqlCommand komut = new SqlCommand(sorgu, conn);
                        komut.Parameters.AddWithValue("@RandevuID", Guid.NewGuid());
                        komut.Parameters.AddWithValue("@HastaID", comboBox1.SelectedValue);
                        komut.Parameters.AddWithValue("@DoktorID", comboBox2.SelectedValue);
                        komut.Parameters.AddWithValue("@Tarih", dateTimePicker1.Value.Date);
                        komut.Parameters.AddWithValue("@Saat", dateTimePicker2.Value.TimeOfDay);

                        komut.ExecuteNonQuery();

                        MessageBox.Show("Randevu başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Form3'ün DataGridView'ini yenile
                        _form3.YenileRandevuListesi();

                        // Form4'ü kapat, Form3'ü göster
                        this.Close();
                        _form3.Show();
                    }
                    else
                    {
                        MessageBox.Show("Uygun randevu bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KontrolEtRandevuUygunMu()
        {
            // Buraya gerçek uygunluk kontrolü kodu yazılabilir
            return true;
        }
    }
}