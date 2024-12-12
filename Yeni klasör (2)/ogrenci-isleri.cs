using Odev_12Aralık;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Odev_12Aralik
{
    public partial class OgrenciIsleri : Form
    {
        public OgrenciIsleri()
        {
            InitializeComponent();
        }

        // SQL bağlantısı
        string connectionString = "Data Source=FURKANN\\SQLEXPRESS;Initial Catalog=ogu.bs;Persist Security Info=True;User ID=sa;Password=1;Encrypt=True;TrustServerCertificate=True";

        // Form yüklendiğinde veritabanındaki öğrencileri listele
        private void OgrenciIsleri_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        // Öğrencileri datagridview'e yüklemek
        private void LoadStudents()
        {
            string query = "SELECT OgrenciNo, Ad, Soyad, FROM Ogrenciler";  // OgrenciNo'yu da ekledim.

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;  // DataGridView'e veri yükleme
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veri çekilirken bir hata oluştu: " + ex.Message);
                }
            }
        }

        // Öğrenci ekleme
        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string studentNumber = textBox3.Text;

            string query = "INSERT INTO Ogrenciler (Ad, Soyad, OgrenciNo) VALUES (@Ad, @Soyad, @OgrenciNo)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", name);
                command.Parameters.AddWithValue("@Soyad", surname);
                command.Parameters.AddWithValue("@OgrenciNo", studentNumber);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Öğrenci başarıyla eklendi.");
            LoadStudents();  // Öğrenciyi ekledikten sonra listeyi güncelle
        }

        // Öğrenci silme
        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); // Seçilen öğrencinin ID'sini al

            string query = "DELETE FROM Ogrenciler WHERE OgrenciID = @OgrenciID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OgrenciID", studentId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Öğrenci başarıyla silindi.");
            LoadStudents();  // Öğrenciyi sildikten sonra listeyi güncelle
        }

        // Öğrenci güncelleme
        private void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); // Seçilen öğrencinin ID'sini al
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string studentNumber = textBox3.Text;

            string query = "UPDATE Ogrenciler SET Ad = @Ad, Soyad = @Soyad, OgrenciNo = @OgrenciNo WHERE OgrenciID = @OgrenciID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", name);
                command.Parameters.AddWithValue("@Soyad", surname);
                command.Parameters.AddWithValue("@OgrenciNo", studentNumber);
                command.Parameters.AddWithValue("@OgrenciID", studentId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Öğrenci başarıyla güncellendi.");
            LoadStudents();  // Öğrenciyi güncelledikten sonra listeyi güncelle
        }

        // Ders ekleme formuna gitme
        private void btnGoToDersEkle_Click(object sender, EventArgs e)
        {
            ogrenci_isleriDers dersEkleForm = new ogrenci_isleriDers();
            dersEkleForm.Show();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string studentNumber = textBox3.Text;

            string query = "INSERT INTO Ogrenciler (Ad, Soyad, OgrenciNo) VALUES (@Ad, @Soyad, @OgrenciNo)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", name);
                command.Parameters.AddWithValue("@Soyad", surname);
                command.Parameters.AddWithValue("@OgrenciNo", studentNumber);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Öğrenci başarıyla eklendi.");
            LoadStudents();  // Öğrenciyi ekledikten sonra listeyi güncelle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); // Seçilen öğrencinin ID'sini al

            string query = "DELETE FROM Ogrenciler WHERE OgrenciID = @OgrenciID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@OgrenciID", studentId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Öğrenci başarıyla silindi.");
            LoadStudents();  // Öğrenciyi sildikten sonra listeyi güncelle
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int studentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); // Seçilen öğrencinin ID'sini al
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string studentNumber = textBox3.Text;

            string query = "UPDATE Ogrenciler SET Ad = @Ad, Soyad = @Soyad, OgrenciNo = @OgrenciNo WHERE OgrenciID = @OgrenciID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Ad", name);
                command.Parameters.AddWithValue("@Soyad", surname);
                command.Parameters.AddWithValue("@OgrenciNo", studentNumber);
                command.Parameters.AddWithValue("@OgrenciID", studentId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show("Öğrenci başarıyla güncellendi.");
            LoadStudents();  // Öğrenciyi güncelledikten sonra listeyi güncelle
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ogrenci_isleriDers dersEkleForm = new ogrenci_isleriDers();
            dersEkleForm.Show();
        }

        private void OgrenciIsleri_Load_1(object sender, EventArgs e)
        {
            LoadStudents();
        }
    }
}
