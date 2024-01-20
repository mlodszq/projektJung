﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// dodanie przestrzeni nazw FiguryGeometryczne
using static Projekt2_Karwowski65859.FiguryGeometryczne;
//dodanie przestrzeni nazw dla potrzeb grafiki 2D
using System.Drawing.Drawing2D;
using System.Reflection.Emit;

namespace Projekt2_Karwowski65859
{
    public partial class LaboratoriumNr2 : Form
    {// deklaracja stalych pomocniczych
        const int Odstep = 30; // odstep od krawedzi PictureBox 
        // deklaracja zmiennej referencyjnej egzemplarza powierzchni graficznej 
        Graphics Rysownica;
        // deklaracja tablicy TFG (Tablica Figur Geometrycznych)
        Punkt[] TFG; ushort IndexTFG;
        Pen Pioro = new Pen(Color.Black, 1.0F);
        SolidBrush Pedzel = new SolidBrush(Color.Blue);
        const ushort Margines = 10;
        const ushort MarginesFormularza = 20;

        public LaboratoriumNr2()
        {
            InitializeComponent();


            //lokalizacja i zweryfikowanie formularza
            this.Location = new Point(Screen.PrimaryScreen.Bounds.X + MarginesFormularza,
                Screen.PrimaryScreen.Bounds.Y + MarginesFormularza);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85F);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.9F);
            this.StartPosition = FormStartPosition.Manual;
            //lokalizacja kontrolek umieszczonych na formularzu

            //lokalizacja kontrolki label: "Podaj liczbe figur geom. do losowej prezentacji" 
            lblN.Location = new Point(this.Left + MarginesFormularza, this.Top + MarginesFormularza);

            //lokalizacja kontrolki TextBox: txtN
            txtN.Location = new Point(lblN.Left - Margines, lblN.Top + lblN.Height + Margines);

            //lokalizacja kontrolki Button: btnStart
            btnStart.Location = new Point(txtN.Left, txtN.Top + txtN.Height + Margines);

            //lokalizacja i zwymiarowanie kontrolki PictureBox
            pbRysownica.Location = new Point(txtN.Left + txtN.Width + MarginesFormularza, txtN.Top);
            pbRysownica.Width = (int)(this.Width * 0.6F);
            pbRysownica.Height = (int)(this.Height * 0.6F);
            pbRysownica.BackColor = Color.Beige;
            pbRysownica.BorderStyle = BorderStyle.FixedSingle;

            //utworzenie mapy bitowej i podpiecie jej do kontrolki PictureBox
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);

            //lokalizacja kontrolki CheckListBox
            chbFiguryGeometryczne.Location = new Point(pbRysownica.Left + pbRysownica.Width + Margines,
                pbRysownica.Top);

            //lokazliacja kontrolki label (nad kontrolka CheckListBox): "Zaznacz figury do prezentacji"
            lblWyborFigury.Location = new Point(chbFiguryGeometryczne.Location.X,
                chbFiguryGeometryczne.Location.Y - Margines - lblWyborFigury.Height);

            //utworzenie egzemplarza powierzchni graficznej
            Rysownica = Graphics.FromImage(pbRysownica.Image);

            //lokalizacja kontrolki label: "Zmien grubosc linii" 
            lblGrubosc.Location = new Point(pbRysownica.Right - Margines * 15,
                pbRysownica.Bottom + Margines * 3);

            // Dodanie kontrolki do formularza
            this.Controls.Add(lblGrubosc);
            this.Controls.Add(numericGrubosc);

            //lokalizacja kontrolki NumericUpDown 
            numericGrubosc.Location = new Point(lblGrubosc.Location.X, lblGrubosc.Location.Y + Margines * 2);

            //lokalizacja przycisku: "Przesuniecie do nowego polozenia bez zmiany atrybutow graficznych"
            btnPrzesuniecieBezZmian.Location = new Point(btnStart.Location.X, btnStart.Location.Y + Margines * 7);

            //lokalizacja przycisku: "Zmien kolor tla powierzchni kreslarskiej"
            btnZmienKolorTla.Location = new Point(pbRysownica.Location.X + Margines * 40, pbRysownica.Location.Y - Margines * 5);

            //lokalizacja przycisku: "Zmien kolor linii"
            btnZmienKolorLinii.Location = new Point(pbRysownica.Location.X + Margines * 2, pbRysownica.Bottom + Margines * 4);

            //lokalizacja przycisku: "btnWziernikKoloruLinii"
            btnWziernikKoloruLinii.Location = new Point(btnZmienKolorLinii.Location.X + Margines * 20, btnZmienKolorLinii.Location.Y + Margines * 2);

            //lokalizacja kontrolki label: "Wziernik koloru linii"
            lblWziernikKoloruLinii.Location = new Point(btnWziernikKoloruLinii.Location.X, btnWziernikKoloruLinii.Location.Y - Margines * 2);

            //lokalizacja kontrolki label: "Zmiana stylu linii"
            lblZmienStylLinii.Location = new Point(lblWziernikKoloruLinii.Location.X + Margines * 38, lblWziernikKoloruLinii.Location.Y);

            //lokalizacja kontrolki comboBoxStylLinii
            comboBoxStylLinii.Location = new Point(btnWziernikKoloruLinii.Location.X + Margines * 32, btnWziernikKoloruLinii.Location.Y);

            //lokalizacja przycisku btnPrzesuniecieZeZmianami
            btnPrzesuniecieZeZmianami.Location = new Point(btnPrzesuniecieBezZmian.Location.X, btnPrzesuniecieBezZmian.Bottom + Margines);

            //lokalizacja przycisku btnNowaFigura
            btnNowaFigura.Location = new Point(btnPrzesuniecieZeZmianami.Location.X, btnPrzesuniecieZeZmianami.Bottom + Margines);

            //lokalizacja kontrolki lblNarzedzia
            lblNarzedzia.Location = new Point(btnZmienKolorLinii.Location.X, btnZmienKolorLinii.Top - Margines * 3);

            //lokalizacja przycisku btnWlaczPrezentacje
            btnWlaczPrezentacje.Location = new Point(chbFiguryGeometryczne.Location.X, chbFiguryGeometryczne.Bottom + Margines);

            //lokalizacja kontrolki lblIndeksFigury
            lblIndeksFigury.Location = new Point(btnWlaczPrezentacje.Location.X + Margines * 3, btnWlaczPrezentacje.Bottom + Margines);

            //lokalizacja kontrolki txtIndeksFigury
            txtIndeksFigury.Location = new Point(lblIndeksFigury.Location.X, lblIndeksFigury.Bottom + Margines);

            //lokalizacja kontrolki btnNastepny
            btnNastepny.Location = new Point(btnWlaczPrezentacje.Location.X, txtIndeksFigury.Bottom + Margines);

            //lokalizacja kontrolki btnPoprzedni
            btnPoprzedni.Location = new Point(btnNastepny.Right + Margines, btnNastepny.Location.Y);

            //lokalizacja kontrolki btnWylaczPrezentacje
            btnWylaczPrezentacje.Location = new Point(btnNastepny.Location.X, btnNastepny.Bottom + Margines);
            //lokalizacja przycisku btnStop
            // btnStop.Location = new Point();
        }

        private void LaboratoriumNr2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            // deklaracja i utworzenie egzemplarza generatora liczb losowych
            Random rnd = new Random();
            // deklaracja zmiennej N dla wczytania liczb figur do prezentacji
            ushort N;
            // zgaszenie kontrolki errorProvider
            errorProvider1.Dispose();
            //sprawdzenie czy kontrolka txtN.Text jest wypełniona 
            if (string.IsNullOrEmpty(txtN.Text.Trim()))
            { //jest blad to go sygnalizujemy
                errorProvider1.SetError(txtN, "ERROR: Musisz podac liczbe figur geometrycznych do wykreslenia");
                return; // przerwanie dalszej obslugi zdarzenia Click: btnStart_Click 
            }
            // sprawdzenie, czy jest to liczba naturalna > 0
            if ((!ushort.TryParse(txtN.Text, out N)) || (N == 0))
            { //jest blad to go sygnalizujemy
                errorProvider1.SetError(txtN, "ERROR: w zapisie liczby figur wystapil blad niedozwolony znak lub podana liczba figur jest rowna 0");
                return; // przerwanie dalszej obslugi zdarzenia Click: btnStart_Click 
            }
            //zablokowanie mozliwosci zmiany wartosci txtN Text
            txtN.Enabled = false;
            // utworzenie egzemplarza tablicy TFG 
            TFG = new Punkt[N]; IndexTFG = 0;
            //sprawdzenie, czy Uzytkownik wybral (zaznaczyl) figury geometryczne do wykreslenia 
            if (chbFiguryGeometryczne.CheckedItems.Count <= 0)
            {//jest blad, to go sygnalizujemy
                errorProvider1.SetError(chbFiguryGeometryczne, "ERROR: musisz wybrac (zaznaczyc) co najmniej jedna figure geometryczna");
                return; // przerwanie dalszej obslugi zdarzenia Click: btnStart_Click
            }
            //skopiowanie kolekcji wybranych (zaznaczony) figur Geometrycznych 
            CheckedListBox.CheckedItemCollection WybraneFigury =
                                chbFiguryGeometryczne.CheckedItems;
            // ustawienie stanu braku aktywnosci dla kontrolki chbFiguryGeometryczne
            chbFiguryGeometryczne.Enabled = true;
            // przygotowanie parametrow dla losowania atrybutow kreslonych figur geometrycznych
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            // deklaracje pomocnicze zmiennych dla przechowania wartosci wylosowanych atrybutow kreslonych figur geometrycznych 
            int X, Y, Xk, Yk;
            Color KolorLinii;
            float GruboscLinii;
            DashStyle StylLinii;
            int OsDuza, OsMala;
            int WylosowanyIndeksFigury;
            // dla N figur geometrycznych losujemy ich atrybuty, tworzymy egzemplarz i wykreslamy 
            for (int i = 0; i < N; i++)
            {
                // losowanie wartosci atrybutow dla i-tej figury geometrycznej 
                X = rnd.Next(Odstep, Xmax - Odstep);
                Y = rnd.Next(Odstep, Ymax - Odstep);
                // losowanie koloru 
                // to nie tak: KolorLinii = Color.Black;
                KolorLinii = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
                //losowanie grubosci linii 
                GruboscLinii = rnd.Next(1, 10);
                //losowanie stylu linii 
                switch (rnd.Next(0, 5))
                {
                    case 0:
                        StylLinii = DashStyle.Solid;
                        break;

                    case 1:
                        StylLinii = DashStyle.Dash;
                        break;
                    case 2:
                        StylLinii = DashStyle.Dot;
                        break;
                    case 3:
                        StylLinii = DashStyle.DashDot;
                        break;
                    case 4:
                        StylLinii = DashStyle.DashDotDot;
                        break;
                    default: StylLinii = DashStyle.Solid; break;
                }
                // wylosowanie indexu figury do utworzenia jej egzemplarza 
                WylosowanyIndeksFigury = rnd.Next(WybraneFigury.Count);
                // rozpoznanie wylosowanej figury i utworzenie dla egzemplarza
                switch (WybraneFigury[WylosowanyIndeksFigury].ToString())
                {
                    case "Punkt":
                        // utworzenie egzemplarzu i wpisanie jego adresu referencyjnego do TFG
                        TFG[IndexTFG] = new Punkt(X, Y, KolorLinii);
                        // wykreslenie punktu 
                        TFG[IndexTFG].Wykresl(Rysownica);
                        // zwiekszenie indeksu 
                        IndexTFG++;
                        break;
                    case "Linia":
                        //poczatek linii wyznaczaja wspolrzedne: X orz Y
                        //Wylosowanie wspolrzednych konca Linii
                        Xk = rnd.Next(Margines, Xmax - Margines);
                        Yk = rnd.Next(Margines, Ymax - Margines);
                        //utworzenie egzemplarza linii 
                        TFG[IndexTFG] = new Linia(X, Y, Xk, Yk, KolorLinii, StylLinii, GruboscLinii);
                        TFG[IndexTFG].Wykresl(Rysownica);
                        //zwiekszenie indeksu
                        IndexTFG++; //bedzie "wskazywal" nastepna wolna pozycje w TFG
                        break;
                    case "Elipsa":
                        // Losowanie osi dużych i małych elipsy
                        OsDuza = rnd.Next(Margines, (Xmax - Margines * 2) / 2);
                        OsMala = rnd.Next(Margines, (Ymax - Margines * 2) / 2);
                        // Losowanie współrzędnych elipsy tak, aby nie wychodziła poza ekran
                        X = rnd.Next(OsDuza + Margines, Xmax - OsDuza - Margines);
                        Y = rnd.Next(OsMala + Margines, Ymax - OsMala - Margines);
                        // Utworzenie egzemplarza elipsy
                        TFG[IndexTFG] = new Elipsa(X, Y, OsDuza, OsMala, KolorLinii, StylLinii, GruboscLinii);
                        TFG[IndexTFG].Wykresl(Rysownica);
                        // Zwiększenie indeksu
                        IndexTFG++;
                        break;
                    case "Okrag":
                        int PromienOkregu = rnd.Next(Margines, Math.Min((Xmax - Margines * 2) / 2, (Ymax - Margines * 2) / 2));
                        X = rnd.Next(PromienOkregu + Margines, Xmax - PromienOkregu - Margines);
                        Y = rnd.Next(PromienOkregu + Margines, Ymax - PromienOkregu - Margines);

                        // Sprawdź, czy środek i promień okręgu nie wychodzą poza granice ekranu
                        if (X - PromienOkregu < Margines)
                        {
                            X = PromienOkregu + Margines;
                        }
                        if (Y - PromienOkregu < Margines)
                        {
                            Y = PromienOkregu + Margines;
                        }
                        if (X + PromienOkregu > Xmax - Margines)
                        {
                            X = Xmax - Margines - PromienOkregu;
                        }
                        if (Y + PromienOkregu > Ymax - Margines)
                        {
                            Y = Ymax - Margines - PromienOkregu;
                        }

                        TFG[IndexTFG] = new Okrag(X, Y, PromienOkregu, KolorLinii, StylLinii, GruboscLinii);
                        TFG[IndexTFG].Wykresl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Prostokat":
                        int Szerokosc = rnd.Next(10, Math.Min((Xmax - Margines * 2), (Ymax - Margines * 2)));
                        int Wysokosc = rnd.Next(10, Math.Min((Xmax - Margines * 2), (Ymax - Margines * 2)));

                        // Sprawdź, czy prostokąt mieści się w granicach ekranu
                        X = rnd.Next(Margines, Xmax - Szerokosc - Margines);
                        Y = rnd.Next(Margines, Ymax - Wysokosc - Margines);

                        TFG[IndexTFG] = new Prostokat(X, Y, Szerokosc, Wysokosc, KolorLinii, StylLinii, GruboscLinii);
                        TFG[IndexTFG].Wykresl(Rysownica);
                        IndexTFG++;
                        break;
                    case "Kwadrat":
                        int DlugoscBoku = rnd.Next(10, Math.Min((Xmax - Margines * 2), (Ymax - Margines * 2)));

                        // Sprawdź, czy kwadrat mieści się w granicach ekranu
                        X = rnd.Next(Margines, Xmax - DlugoscBoku - Margines);
                        Y = rnd.Next(Margines, Ymax - DlugoscBoku - Margines);

                        TFG[IndexTFG] = new Kwadrat(X, Y, DlugoscBoku, KolorLinii, StylLinii, GruboscLinii);
                        TFG[IndexTFG].Wykresl(Rysownica);
                        IndexTFG++;
                        break;

                    case "Elipsa Wypelniana":
                        // Losowanie osi dużych i małych elipsy
                        OsDuza = rnd.Next(Margines, (Xmax - Margines * 2) / 2);
                        OsMala = rnd.Next(Margines, (Ymax - Margines * 2) / 2);
                        // Losowanie współrzędnych elipsy tak, aby nie wychodziła poza ekran
                        X = rnd.Next(OsDuza + Margines, Xmax - OsDuza - Margines);
                        Y = rnd.Next(OsMala + Margines, Ymax - OsMala - Margines);
                        // Utworzenie egzemplarza wypełnionej elipsy
                        Color KolorTlaElipsy = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)); // Losowy kolor tła elipsy
                        TFG[IndexTFG] = new ElipsaWypelnialna(X, Y, OsDuza, OsMala, KolorLinii, StylLinii, GruboscLinii, KolorTlaElipsy);
                        TFG[IndexTFG].Wykresl(Rysownica);
                        // Zwiększenie indeksu
                        IndexTFG++;
                        break;

                    default:
                        MessageBox.Show("Wylosowana Figura: " + (string)chbFiguryGeometryczne.CheckedItems[WylosowanyIndeksFigury] +
                            " nie jest jeszcze obslugiwana");
                        return;




                } //od switcha

                // Po utworzeniu figur, ustaw dostępność przycisków
                btnPrzesuniecieBezZmian.Enabled = true;
                btnZmienKolorLinii.Enabled = true;
                numericGrubosc.Enabled = true;
                comboBoxStylLinii.Enabled = true;
                btnPrzesuniecieZeZmianami.Enabled = true;
                btnNowaFigura.Enabled = true;
                btnWlaczPrezentacje.Enabled = true;
                txtIndeksFigury.Enabled = true;
                btnStop.Enabled = true;

            }  //od for ( . . . )
            // odswiezenie powierzchni graficznej 
            pbRysownica.Refresh();
            //ustawienie stanu braku aktywnosci dla przycisku polecen START
            btnStart.Enabled = false;

            // Po utworzeniu figur, dodaj ich typy do chbFiguryGeometryczne
            chbFiguryGeometryczne.Items.Clear();

            HashSet<string> dodaneTypyFigur = new HashSet<string>();

            for (int i = 0; i < IndexTFG; i++)
            {
                if (TFG[i] != null)
                {
                    string nazwaTypuFigury = TFG[i].GetType().Name;

                    // Sprawdź, czy nazwa typu figury została już dodana
                    if (!dodaneTypyFigur.Contains(nazwaTypuFigury))
                    {
                        chbFiguryGeometryczne.Items.Add(nazwaTypuFigury);
                        dodaneTypyFigur.Add(nazwaTypuFigury);
                    }
                }
            }

        }



        private void numericGrubosc_ValueChanged(object sender, EventArgs e)
        {
            pbRysownica.Invalidate();

            // Pobierz wartość z kontrolki numericGrubosc
            float nowaGrubosc = (float)numericGrubosc.Value;

            // Przypisz nową grubość linii wybranym figurom geometrycznym
            for (int i = 0; i < IndexTFG; i++)
            {
                if (TFG[i] != null)
                {
                    TFG[i].GruboscLinii = nowaGrubosc;
                    // Ponownie wykreśl figurę z zaktualizowaną grubością linii
                    TFG[i].Wymaz(pbRysownica, Rysownica);
                    TFG[i].Wykresl(Rysownica);
                }
            }
        }

        private Random random = new Random();

        private void btnPrzesuniecieBezZmian_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy figury zostały utworzone
            if (TFG == null || TFG.Length == 0)
            {
                MessageBox.Show("Najpierw utwórz figury geometryczne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Wyczyść powierzchnię graficzną przed przesunięciem figur
            WyczyscPowierzchnieGraficzna();

            // deklaracja i utworzenie egzemplarza generatora liczb losowych
            Random rnd = new Random();

            // Przesuń każdą figurę do nowego losowego miejsca
            for (int i = 0; i < IndexTFG; i++)
            {
                if (TFG[i] != null)
                {
                    // Losowanie nowych współrzędnych dla figury
                    int newX = rnd.Next(Odstep, pbRysownica.Width - Odstep);
                    int newY = rnd.Next(Odstep, pbRysownica.Height - Odstep);

                    // Przesunięcie figury do nowego miejsca
                    TFG[i].PrzesunDoNowegoXY(pbRysownica, Rysownica, newX, newY);
                }
            }

            // Odświeżenie powierzchni graficznej
            pbRysownica.Refresh();

        }



        private void btnZmienKolorTla_Click(object sender, EventArgs e)
        {
            // Utwórz nowy ColorDialog
            ColorDialog colorDialog = new ColorDialog();

            // Ustaw aktualny kolor jako domyślny kolor wyboru
            colorDialog.Color = pbRysownica.BackColor;

            // Pokaż okno dialogowe do wyboru koloru
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Ustaw nowy kolor tła dla pbRysownica
                pbRysownica.BackColor = colorDialog.Color;

                // Wyczyszczenie i ponowne narysowanie figur na nowym tle
                WyczyscPowierzchnieGraficzna();
                RysujFigury();
            }
        }

        private void WyczyscPowierzchnieGraficzna()
        {
            Rysownica.Clear(pbRysownica.BackColor);
        }

        private void RysujFigury()
        {
            // Przesuń każdą figurę do nowego losowego miejsca
            for (int i = 0; i < IndexTFG; i++)
            {
                if (TFG[i] != null)
                {
                    TFG[i].Wykresl(Rysownica);
                }
            }

            // Odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void btnWziernikKoloruLinii_Click(object sender, EventArgs e)
        {
            // Utwórz obiekt ColorDialog
            using (ColorDialog colorDialog = new ColorDialog())
            {
                // Otwórz okno dialogowe do wyboru koloru
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Pobierz wybrany kolor
                    Color selectedColor = colorDialog.Color;
                    btnWziernikKoloruLinii.BackColor = selectedColor;

                }
            }
        }

        private void btnZmienKolorLinii_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy figury zostały utworzone
            if (TFG == null || TFG.Length == 0)
            {
                MessageBox.Show("Najpierw utwórz figury geometryczne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Pobierz wybrany kolor z przycisku wziernika koloru linii
            Color nowyKolorLinii = btnWziernikKoloruLinii.BackColor;

            // Pobierz wybrany typ figury
            if (chbFiguryGeometryczne.SelectedItem == null)
            {
                MessageBox.Show("Wybierz typ figury, któremu chcesz zmienić kolor.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string wybranyTypFigury = chbFiguryGeometryczne.SelectedItem.ToString();

            // Przejdź przez wszystkie figury i zmień kolor tych, które pasują do wybranego typu
            foreach (Punkt figura in TFG)
            {
                if (figura != null && figura.GetType().Name == wybranyTypFigury)
                {
                    figura.Kolor = nowyKolorLinii; // Ustaw nowy kolor
                    figura.Wymaz(pbRysownica, Rysownica); // Wymaż starą figurę
                    figura.Wykresl(Rysownica); // Wykreśl ponownie z nowym kolorem
                }
            }

            // Odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }



        private void btnStop_Click(object sender, EventArgs e)
        {
            // 1. Wyczyszczenie tablicy TFG
            TFG = null;
            IndexTFG = 0;

            // 2. Resetowanie grafiki
            Rysownica.Clear(pbRysownica.BackColor);
            pbRysownica.Refresh();

            // 3. Przywrócenie domyślnych ustawień kontrolek
            txtN.Enabled = true;
            txtN.Text = "";
            numericGrubosc.Value = 1;
            btnWziernikKoloruLinii.BackColor = Color.Transparent;

            // 4. Resetowanie chbFiguryGeometryczne do początkowych elementów
            chbFiguryGeometryczne.Items.Clear();
            chbFiguryGeometryczne.Items.Add("Punkt");
            chbFiguryGeometryczne.Items.Add("Linia");
            chbFiguryGeometryczne.Items.Add("Elipsa");
            chbFiguryGeometryczne.Items.Add("Okrag");
            chbFiguryGeometryczne.Items.Add("Prostokat");
            chbFiguryGeometryczne.Items.Add("Kwadrat");
            chbFiguryGeometryczne.Items.Add("Elipsa Wypelniana");
            // Dodaj więcej elementów według potrzeb...

            // 5. Aktywowanie/deaktywowanie odpowiednich kontrolek
            btnStart.Enabled = true;
            chbFiguryGeometryczne.Enabled = true;
            btnPrzesuniecieBezZmian.Enabled = false;
            btnZmienKolorLinii.Enabled = false;
            numericGrubosc.Enabled = false;
            comboBoxStylLinii.Enabled = false;
            btnPrzesuniecieZeZmianami.Enabled = false;
            btnNowaFigura.Enabled = false;
            btnWlaczPrezentacje.Enabled = false;
            txtIndeksFigury.Enabled = false;
            btnStop.Enabled = false;

            //dodać inne resety które będą potrzebne
        }

        private void comboBoxStylLinii_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Pobierz wybrany typ figury
            if (chbFiguryGeometryczne.SelectedItem == null)
            {
                MessageBox.Show("Wybierz typ figury, której chcesz zmienić styl linii.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnPrzesuniecieZeZmianami_Click(object sender, EventArgs e)
        {
            // Sprawdź, czy figury zostały utworzone
            if (TFG == null || TFG.Length == 0)
            {
                MessageBox.Show("Najpierw utwórz figury geometryczne.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Wyczyść powierzchnię graficzną przed przesunięciem figur
            WyczyscPowierzchnieGraficzna();

            // deklaracja i utworzenie egzemplarza generatora liczb losowych
            Random rnd = new Random();

            // Przesuń każdą figurę do nowego losowego miejsca i nadaj jej nowe atrybuty
            for (int i = 0; i < IndexTFG; i++)
            {
                if (TFG[i] != null)
                {
                    // Losowanie nowych współrzędnych dla figury
                    int newX = rnd.Next(Odstep, pbRysownica.Width - Odstep);
                    int newY = rnd.Next(Odstep, pbRysownica.Height - Odstep);

                    // Losowanie nowego koloru linii
                    Color newLineColor = Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

                    // Losowanie nowej grubości linii
                    float newLineWidth = rnd.Next(1, 10);

                    // Losowanie nowego stylu linii
                    DashStyle newLineStyle;
                    switch (rnd.Next(0, 5))
                    {
                        case 0:
                            newLineStyle = DashStyle.Solid;
                            break;
                        case 1:
                            newLineStyle = DashStyle.Dash;
                            break;
                        case 2:
                            newLineStyle = DashStyle.Dot;
                            break;
                        case 3:
                            newLineStyle = DashStyle.DashDot;
                            break;
                        case 4:
                            newLineStyle = DashStyle.DashDotDot;
                            break;
                        default:
                            newLineStyle = DashStyle.Solid;
                            break;
                    }

                    // Aktualizacja atrybutów figury
                    TFG[i].X = newX;
                    TFG[i].Y = newY;
                    TFG[i].Kolor = newLineColor;
                    TFG[i].GruboscLinii = newLineWidth;
                    TFG[i].StylLinii = newLineStyle;

                    // Przesunięcie figury do nowego miejsca
                    TFG[i].PrzesunDoNowegoXY(pbRysownica, Rysownica, newX, newY);
                }
            }

            // Odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void btnNowaFigura_Click(object sender, EventArgs e)
        {

        }

        private void btnWlaczPrezentacje_Click(object sender, EventArgs e)
        {
            //wymazanie (wyczyszczenie) powierzchni graficznej
            Rysownica.Clear(pbRysownica.BackColor);

            int IndeksFigury = 0;

            //sprawdzenie czy został podany indeks figury do prezentacji
            if (string.IsNullOrEmpty(txtIndeksFigury.Text.Trim()))
                txtIndeksFigury.Text = "0"; //wpisanie indeksu domyslnego, gdyz pole edycyjne kontrolki txtIndeksFigury bylo puste
            else
            { //pobranie wpisanego indeksu figury w TFG
                if (!int.TryParse(txtIndeksFigury.Text, out IndeksFigury))
                {
                    errorProvider1.SetError(txtIndeksFigury, "ERROR: Bledny zapis indeksu figury!");
                    return;
                }    

                if ((IndeksFigury < 0 || IndeksFigury >= (TFG.Length)))
                {
                    errorProvider1.SetError(txtIndeksFigury, "ERROR: Indeks figur wykracza poza tablice TFG!");
                    return;
                }
                // "zgaszenie" wylaczenie errorProvider1
                errorProvider1.Dispose();
            }

            txtIndeksFigury.ReadOnly = true;

            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            //prezentacja figury geometrycznej w środku powierzchni graficznej
            TFG[IndeksFigury].PrzesunDoNowegoXY(pbRysownica, Rysownica, Xmax / 2, Ymax / 2);

            //uaktywnienie przyciskow nawigacyjnych
            btnNastepny.Enabled = true;
            btnPoprzedni.Enabled = true;

            pbRysownica.Refresh();

            //ustawienie stanu braku aktywnosci dla przycisku polecen: Wlaczenie slajdera figur geometrycznych, gdyz jego obsluga zostala zakonczona
            btnWlaczPrezentacje.Enabled = false;
            //uaktywnienie przycisku polecen wylacz pokaz (slajder) figur geometrycznych
            btnWylaczPrezentacje.Enabled = true;
        } //od btnWlaczPrezentacje

        private void timer1_Tick(object sender, EventArgs e)
        { //wymazanie (wyczyszczenie) powierzchni graficznej
            Rysownica.Clear(pbRysownica.BackColor);

            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height; 

            txtIndeksFigury.Text = timer1.Tag.ToString();

            TFG[(int)timer1.Tag].PrzesunDoNowegoXY(pbRysownica, Rysownica, Xmax / 2, Ymax / 2);

            pbRysownica.Refresh();

            timer1.Tag = (int.Parse(timer1.Tag.ToString()) + 1) % (TFG.Length - 1);




        } //od timer1_Tick
    }
}