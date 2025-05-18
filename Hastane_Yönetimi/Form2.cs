using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Yönetimi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-0SI016LJ\SQLEXPRESS;Initial Catalog=test;Integrated Security=True"))
                {
                    conn.Open();



                    // SQL INSERT sorgusu
                    string sorgu = "INSERT INTO kullanici (tckimlikno, ad, soyad, cinsiyet, dogumtarihi ) " +
                    "VALUES (@tckimlikno, @ad, @soyad, @cinsiyet, @dogumtarihi )";

                    SqlCommand komut = new SqlCommand(sorgu, conn);
                    komut.Parameters.AddWithValue("@tckimlikno", textBox1.Text);
                    komut.Parameters.AddWithValue("@ad", textBox2.Text);
                    komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                    komut.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
                    komut.Parameters.AddWithValue("@dogumTarihi", Convert.ToDateTime(dateTimePicker1.Value.Date));

                    int sonuc = komut.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla tamamlandı!", "Başarılı");
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show("Kayıt başarısız. Hiçbir satır eklenmedi.");
                    }

                }
            }
            catch (Exception ex)

            {

                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(this);
            form1.Show();
            this.Hide();
        }
    }
}
