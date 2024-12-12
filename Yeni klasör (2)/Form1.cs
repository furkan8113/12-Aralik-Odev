using Odev_12Aralık;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Odev_12Aralik
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=FURKANN\\SQLEXPRESS;Initial Catalog=ogu.bs;Persist Security Info=True;User ID=sa;Password=1;Encrypt=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Rol FROM Kullanici WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string rol = result.ToString();

                        if (rol == "Ogrenci")
                        {
                            ogrenci_panel ogrenciForm = new ogrenci_panel();
                            ogrenciForm.Show();
                        }
                        else if (rol == "Ogretmen")
                        {
                            ogretmen_panel ogretmenForm = new ogretmen_panel();
                            ogretmenForm.Show();
                        }
                        else if (rol == "OgrenciIsleri")
                        {
                            OgrenciIsleri ogrenciIsleriForm = new OgrenciIsleri();
                            ogrenciIsleriForm.Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text.Trim();
            string sifre = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Rol FROM Kullanici WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@Sifre", sifre);

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        string rol = result.ToString();

                        if (rol == "Ogrenci")
                        {
                            ogrenci_panel ogrenciForm = new ogrenci_panel();
                            ogrenciForm.Show();
                        }
                        else if (rol == "Ogretmen")
                        {
                            ogretmen_panel ogretmenForm = new ogretmen_panel();
                            ogretmenForm.Show();
                        }
                        else if (rol == "OgrenciIsleri")
                        {
                            OgrenciIsleri ogrenciIsleriForm = new OgrenciIsleri();
                            ogrenciIsleriForm.Show();
                        }

                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
