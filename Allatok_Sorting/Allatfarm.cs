using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace Allatok_Sorting
{
    public partial class Allatfarm : Form
    {
        //2. Make a List that can be reached from anywhere.
        public static List<Animals> listed = new List<Animals>();
        public Allatfarm()
        {
            InitializeComponent();
        }

        private void Allatfarm_Load(object sender, EventArgs e)
        {
            //3. File reading and first row out cause of file containing types in first row.
            StreamReader sr = new StreamReader("allatok_es_adataik.txt", Encoding.UTF8);
            string rowone=sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var animal = new Animals(sr.ReadLine());
                listed.Add(animal);
            }

            //4. How many animals are there in the file? (Write it into the txtCount)
            txtCount.Text = listed.Count().ToString()+" állat van a fájlban";

            //5. When loading the Form make the ListBox items be in the ListBox.
            
                var animals = from a in listed select a.animal_name;
                foreach (var item in animals)
                {
                    lbxAnimals.Items.Add(item+"\n");
                }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //6. Make a button work as an Exit.
            Application.Exit();
        }

        private void btnCountIt_Click(object sender, EventArgs e)
        {
            //7. In a RichTextBox make the full weight of the animals written from the ListBox by the count of Items, when the Items.Count is 0 make the RichTextBox have nothing, but a 0 in it.
            rtbOsszsuly.Clear();
            if (lbxAnimals.Items.Count==0)
            {
                rtbOsszsuly.Text = "0";
            }
            else
            {
                double fullweight = 0;
                for (int i = 0; i < lbxAnimals.Items.Count; i++)
                {
                    double weights = Convert.ToDouble(listed[i].animal_weight);
                    rtbOsszsuly.Text += listed[i].animal_name +" "+listed[i].animal_weight+" kg\n";
                    fullweight+=weights;
                }
                rtbOsszsuly.Text += "\n Az összes találat össz súlya: " + fullweight+" kg";
            }
        }

        private void btnSzures_Click(object sender, EventArgs e)
        {
            //8. Create a functional button where the ListBox Items are Updated and only the names that contain the letters from the TextBox will be shown
            lbxAnimals.Update();
            lbxAnimals.Items.Clear();
            lbxAnimals.EndUpdate();
            
            if (txtSearch.Text=="")
            {
                MessageBox.Show("Kérjük legalább egy betűt adjon meg a szűréshez!");
            }
            else
            {
                var everyone = from a in listed select a.animal_name;
                lbxAnimals.Items.Remove(everyone);
                var contain=from c in listed where c.animal_name.Contains(txtSearch.Text) select c.animal_name;
                foreach (var item in contain)
                {
                    
                    lbxAnimals.Items.Add(item);
                }
            }
        }

        private void lbxAnimals_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void chck1_CheckedChanged(object sender, EventArgs e)
        {
            lbxAnimals.Update();
            lbxAnimals.Items.Clear();
            lbxAnimals.EndUpdate();

            if (chck1.Checked)
            {

            
                var everyone = from a in listed select a.animal_name;
                lbxAnimals.Items.Remove(everyone);
                var contain = from c in listed where c.animal_weight<=1 select c.animal_name;
                foreach (var item in contain)
                {

                    lbxAnimals.Items.Add(item);
                }
            }
        }

        private void chck2_CheckedChanged(object sender, EventArgs e)
        {
            lbxAnimals.Update();
            lbxAnimals.Items.Clear();
            lbxAnimals.EndUpdate();

            if (chck2.Checked)
            {


                var everyone = from a in listed select a.animal_name;
                lbxAnimals.Items.Remove(everyone);
                var contain = from c in listed where c.animal_weight>1 && c.animal_weight<=5 select c.animal_name;
                foreach (var item in contain)
                {
                    lbxAnimals.Items.Add(item);
                }
            }
        }

        private void chck8_CheckedChanged(object sender, EventArgs e)
        {
            lbxAnimals.Update();
            lbxAnimals.Items.Clear();
            lbxAnimals.EndUpdate();

            if (chck8.Checked)
            {


                var everyone = from a in listed select a.animal_name;
                lbxAnimals.Items.Remove(everyone);
                var contain = from c in listed where c.animal_weight > 30 select c.animal_name;
                foreach (var item in contain)
                {
                    lbxAnimals.Items.Add(item);
                }
            }
        }

        private void pcbChosen_Click(object sender, EventArgs e)
        {
            
        }
    }
}
