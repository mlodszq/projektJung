using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2_Karwowski65859
{
    public partial class pkProjektIndywidualnyNr2 : Form
    {
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
    }
}
