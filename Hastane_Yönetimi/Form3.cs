// Form3.cs
using System;
using System.Windows.Forms;

namespace Hastane_Yönetimi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            this.randevularTableAdapter.Fill(this.dataSet1.Randevular);
        }
        

        // Form4'ü açan buton
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(this);
            form4.Show();
            this.Hide();
        }

        // Randevu listesini yenilemek için metot
        public void YenileRandevuListesi()
        {
            this.randevularTableAdapter.Fill(this.dataSet1.Randevular);
        }
    }
}