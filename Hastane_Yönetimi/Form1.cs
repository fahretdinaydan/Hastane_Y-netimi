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

namespace Hastane_Yönetimi
{
   

   
    
        
   
    public partial class Form1 : Form
    {
        SQLBaglantim bgl = new SQLBaglantim();

        public void Listeleme()
        {
            //eğer bağlantı kapalıysa aç
            if (bgl.baglanti().State == ConnectionState.Closed)
                bgl.baglanti().Open();
            // sql server işleri için kullanılan komutlar
            SqlCommand list = new SqlCommand("SELECT * FROM dbo.kullanici", bgl.baglanti());




            SqlDataAdapter sda = new SqlDataAdapter(list);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            bgl.baglanti().Close();

        }
        SqlConnection connection = new SqlConnection("Data Source=LAPTOP-0SI016LJ\\SQLEXPRESS; Initial Catalog=test; Integrated Security=TRUE");
        public Form1(Form2 form2)
        {
            InitializeComponent();
        }

        public Form1()
        {
        }

        bool isThere;
       public void btngiris_Click(object sender, EventArgs e)
        {
            textBox1.MaxLength = 11;

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM kullanici WHERE username = @username AND pass = @pass", bgl.baglanti());
                cmd.Parameters.AddWithValue("@username", textBox1.Text); // Kullanıcı adı
                cmd.Parameters.AddWithValue("@pass", textBox2.Text); // Şifre

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Giriş başarılı!");
                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Giriş Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                bgl.baglanti().Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnkayit_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {


            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
        
    }



