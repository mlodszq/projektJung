using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2_Karwowski65859
{
    public partial class pkProjektIndywidualnyNr2 : Form
    {
        private Stack<Bitmap> undoStack;

        public pkProjektIndywidualnyNr2()
        {
            InitializeComponent();
        }



        private void pkProjektIndywidualnyNr2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //utworzeie okna dialogowego z odwpoeidnim pytaniem
            DialogResult OknoDialogowe = MessageBox.Show("czy chcesz zamknac ten formularz i wrocic do formularza glownego?",
                this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //rozpoznanie wybranego (kliknieciem) przycisku: Yes lub No
            if (OknoDialogowe == DialogResult.Yes)
            { //odszukanie formularza glownego w kolekcji OpenForms
                foreach (Form SzukanyFormularz in Application.OpenForms)
                    //sprawdzenie czy jest to formularz glowny 
                    if (SzukanyFormularz.Name == "KokpitNr2")
                    { //ukrycie biezacego formularza 
                        this.Hide();
                        //odsloniecie znalezionego formularza 
                        SzukanyFormularz.Show();
                        //Zakonczenie obslugi zdarzenia FormClicking 
                        return;
                    }
                //a gdy znajdziemy sie tutaj, to jest awaria !!!
                MessageBox.Show("AWARIA: Ktos usunal z kolekcji OpenForms " +
                    "egzemplarz formularza glownego i musi nastapic zamkniecie programu", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //zamkniecie calego programu, lacznie z rownolegle dzialajacymi procesami rownoleglymi (zwanymi watkami)
                Application.ExitThread();


            }
            else
                //nie, nie! to przypadkowo
                e.Cancel = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Utwórz obiekt ColorDialog
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Otwórz okno dialogowe do wyboru koloru
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Pobierz wybrany kolor
                    Color selectedColor = colorDialog.Color;
                    button11.BackColor = selectedColor;

                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Utwórz obiekt ColorDialog
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Otwórz okno dialogowe do wyboru koloru
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Pobierz wybrany kolor
                    Color selectedColor = colorDialog.Color;
                    pictureBox1.BackColor = selectedColor;

                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text = $"X={e.X}, Y={e.Y}";
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton1.Checked)
            {
                using (Graphics g = pictureBox1.CreateGraphics())
                {
                    // Narysuj punkt w miejscu kliknięcia myszą
                    g.FillEllipse(Brushes.Black, e.X, e.Y, 4, 4);
                }
            }


            /* private void radioButton1_MouseDown(object sender, MouseEventArgs e)
             {
                 // Sprawdź, czy RadioButton1 jest zaznaczone
                 if (radioButton1.Checked)
                 {
                     using (Graphics g = pictureBox1.CreateGraphics())
                     {
                         // Narysuj punkt w miejscu kliknięcia myszą
                         g.FillEllipse(Brushes.Black, e.X, e.Y, 4, 4);
                     }
                 }

             }*/


        }
    }
}

