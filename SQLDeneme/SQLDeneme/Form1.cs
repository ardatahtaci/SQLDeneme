using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;
using System.Diagnostics;

namespace LotoAlgoritma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //SQL Serverınıza bağlanma
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-BI91U1J\SQLEXPRESS;Integrated Security=True;MultipleActiveResultSets=True"); //Kendi veritabanızı tırnak içine yazın

        int sayitopla = 0; //Sayı toplama işlemi için değer
        private void button1_Click(object sender, EventArgs e)
        {
            if(baglanti.State == ConnectionState.Open)
            {
                baglanti.Close();
            }
            baglanti.Open();

            try
            {
                SqlCommand topla = new SqlCommand("select Sayı from Örnek",baglanti); //Veriyi çekme
                SqlDataReader veriOku = topla.ExecuteReader(); //Okuma
                //Eğer veriyi okuyorsa toplama işlemini yapma
                while (veriOku.Read())
                {
                    sayitopla += Convert.ToInt16(veriOku["Sayı"]); 
                }

                label1.Text = sayitopla.ToString(); //Sonuçu yazdırma

                topla.Dispose();
                veriOku.Close();
            }
            //Hata mesajı
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
            finally
            {
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Discord sunucumuz
            Process.Start("https://discord.com/invite/vVkMErN");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
