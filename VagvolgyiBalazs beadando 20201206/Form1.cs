using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VagvolgyiBalazs_beadando_20201206
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            
            StreamReader sr = new StreamReader(@"tracks.txt");
            string s = sr.ReadLine();
            string[] parts = s.Split(';');
            Name = parts[0];
            for (int i = 0; i < parts.Length; i++)
            {
                ArtistcomboBox1.Items.Add(parts[0]);
            }

            if (AlbumcomboBox2.Tag == "Hold Your Colour")
            {
                pictureBox1.Image = Image.FromFile(@"hold_your_colour.jpg");
            }
            if (AlbumcomboBox2.Tag == "In Silico")
            {
                pictureBox1.Image = Image.FromFile(@"immersion.jpg");
            }
            if (AlbumcomboBox2.Tag == "Immersion")
            {
                pictureBox1.Image = Image.FromFile(@"in_silico.jpg");
            }
/*
            if (dataGridView1.SelectedRows.Count > 0)
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
*/
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            textBox1.Text = dlg.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LoadCSV(textBox1.Text);

        }

        public List<Product> LoadCSV(string csvFile)
        {
            var query = from l in File.ReadAllLines(csvFile)
                        let data = l.Split(';')
                        select new Product
                        {
                            Name = data[0],
                            Length = data[1],
                            rov = data[2],
                            link = data[3]
                        };
            return query.ToList();
        }

        public class Product
        {
            public string Name { get; set; }
            public string Length { get; set; }
            public string rov { get; set; }
            public string link { get; set; }
        }

        private void ArtistcomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
 
            if (ArtistcomboBox1 != null)
            {
                AlbumcomboBox2.Enabled = true;
            }
        }
        private void AlbumcomboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ArtistcomboBox1.Text))
            {
                AlbumcomboBox2.Enabled = false;
                MessageBox.Show("Előbb jelölj ki egy előadót!");
            }


        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Text != null)
            {
                textBox1.Enabled = false;
            }
            if (String.IsNullOrEmpty(dataGridView1.Text))
            {
                textBox1.Enabled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
        }
    }
}
