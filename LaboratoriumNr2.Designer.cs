﻿namespace Projekt2_Karwowski65859
{
    partial class LaboratoriumNr2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.chbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.lblWyborFigury = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblGrubosc = new System.Windows.Forms.Label();
            this.numericGrubosc = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGrubosc)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRysownica
            // 
            this.pbRysownica.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbRysownica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbRysownica.Location = new System.Drawing.Point(204, 31);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(674, 418);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            // 
            // chbFiguryGeometryczne
            // 
            this.chbFiguryGeometryczne.FormattingEnabled = true;
            this.chbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrag",
            "Prostokat",
            "Kwadrat",
            "Elipsa Wypelniana"});
            this.chbFiguryGeometryczne.Location = new System.Drawing.Point(896, 188);
            this.chbFiguryGeometryczne.Name = "chbFiguryGeometryczne";
            this.chbFiguryGeometryczne.Size = new System.Drawing.Size(161, 124);
            this.chbFiguryGeometryczne.TabIndex = 1;
            // 
            // lblWyborFigury
            // 
            this.lblWyborFigury.AutoSize = true;
            this.lblWyborFigury.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWyborFigury.Location = new System.Drawing.Point(884, 141);
            this.lblWyborFigury.Name = "lblWyborFigury";
            this.lblWyborFigury.Size = new System.Drawing.Size(185, 34);
            this.lblWyborFigury.TabIndex = 2;
            this.lblWyborFigury.Text = "Zaznacz (kliknieciem myszą)\r\nfigury geometryczne do okazu\r\n";
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblN.Location = new System.Drawing.Point(3, 107);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(200, 17);
            this.lblN.TabIndex = 3;
            this.lblN.Text = "Podaj liczbe figur do prezentacji ";
            // 
            // txtN
            // 
            this.txtN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtN.Location = new System.Drawing.Point(21, 141);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(162, 29);
            this.txtN.TabIndex = 4;
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(39, 188);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 57);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // lblGrubosc
            // 
            this.lblGrubosc.AutoSize = true;
            this.lblGrubosc.Location = new System.Drawing.Point(767, 473);
            this.lblGrubosc.Name = "lblGrubosc";
            this.lblGrubosc.Size = new System.Drawing.Size(94, 13);
            this.lblGrubosc.TabIndex = 8;
            this.lblGrubosc.Text = "Zmień grubość linii";
            // 
            // numericGrubosc
            // 
            this.numericGrubosc.Location = new System.Drawing.Point(758, 489);
            this.numericGrubosc.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericGrubosc.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericGrubosc.Name = "numericGrubosc";
            this.numericGrubosc.Size = new System.Drawing.Size(120, 20);
            this.numericGrubosc.TabIndex = 9;
            this.numericGrubosc.ValueChanged += new System.EventHandler(this.numericGrubosc_ValueChanged);
            // 
            // LaboratoriumNr2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 631);
            this.Controls.Add(this.numericGrubosc);
            this.Controls.Add(this.lblGrubosc);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.lblWyborFigury);
            this.Controls.Add(this.chbFiguryGeometryczne);
            this.Controls.Add(this.pbRysownica);
            this.Name = "LaboratoriumNr2";
            this.Text = "LaboratoriumNr2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaboratoriumNr2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGrubosc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.CheckedListBox chbFiguryGeometryczne;
        private System.Windows.Forms.Label lblWyborFigury;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.NumericUpDown numericGrubosc;
        private System.Windows.Forms.Label lblGrubosc;
    }
}