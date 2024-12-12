using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Odev_12Aralik
{
    public partial class ogretmen_panel : Form
    {
        public ogretmen_panel()
        {
            InitializeComponent();
        }

        // SQL bağlantı dizesi
        string connectionString = "Data Source=FURKANN\\SQLEXPRESS;Initial Catalog=ogu.bs;Persist Security Info=True;User ID=sa;Password=1;Encrypt=True;TrustServerCertificate=True";

        // Form yüklendiğinde öğretmenleri listele
        private void ogretmen_panel_Load(object sender, EventArgs e)
        {
            LoadOgretmenler();
        }

        // Öğretmenleri DataGridView ve ListView'e yüklemek
        private void LoadOgretmenler()
        {
            string query = "SELECT OgretmenID, Ad, Soyad, Branş FROM Ogretmenler";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // DataGridView için veri yükleme
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;

                    // ListView için veri yükleme
                    listView1.Items.Clear();
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OgretmenID"].ToString());
                        item.SubItems.Add(reader["Ad"].ToString());
                        item.SubItems.Add(reader["Soyad"].ToString());
                        item.SubItems.Add(reader["Branş"].ToString());
                        listView1.Items.Add(item);
                    }
                    reader.Close();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Öğretmenleri yüklerken hata oluştu: " + ex.Message);
                }
            }
        }

        // Öğretmen ekleme işlemi
        private void button1_Click(object sender, EventArgs e)
        {
            // TextBox'lar üzerinden veri alıyoruz
            string ad = textBox1.Text.Trim();
            string soyad = textBox2.Text.Trim();
            string brans = textBox3.Text.Trim();

            if (string.IsNullOrWhiteSpace(ad) || string.IsNullOrWhiteSpace(soyad) || string.IsNullOrWhiteSpace(brans))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            string query = "INSERT INTO Ogretmenler (Ad, Soyad, Branş) VALUES (@Ad, @Soyad, @Branş)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Ad", ad);
                    command.Parameters.AddWithValue("@Soyad", soyad);
                    command.Parameters.AddWithValue("@Branş", brans);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Öğretmen başarıyla eklendi.");
                    LoadOgretmenler(); // Listeyi güncelle

                    // TextBox'ları temizle
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Öğretmen eklerken hata oluştu: " + ex.Message);
                }
            }
        }

        // Öğretmen silme işlemi
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir öğretmeni seçin.");
                return;
            }

            int ogretmenId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OgretmenID"].Value);

            string query = "DELETE FROM Ogretmenler WHERE OgretmenID = @OgretmenID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@OgretmenID", ogretmenId);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    MessageBox.Show("Öğretmen başarıyla silindi.");
                    LoadOgretmenler(); // Listeyi güncelle
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Öğretmen silerken hata oluştu: " + ex.Message);
                }
            }
        }
    }
}
