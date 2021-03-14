using System;
using System.Windows.Forms;

namespace GameUI
{
    public partial class FormColorPlate : Form
    {
        private Button m_CurrentButton;

        public FormColorPlate()
        {
            InitializeComponent();
        }

        public Button CurrentButton
        {
            get { return m_CurrentButton; }
            set { m_CurrentButton = value; }

        }

        private void InitializeComponent()
        {
            this.PaleGreen = new System.Windows.Forms.Button();
            this.Pink = new System.Windows.Forms.Button();
            this.Plum = new System.Windows.Forms.Button();
            this.Khaki = new System.Windows.Forms.Button();
            this.SandyBrown = new System.Windows.Forms.Button();
            this.CornflowerBlue = new System.Windows.Forms.Button();
            this.PaleTurquoise = new System.Windows.Forms.Button();
            this.LightCoral = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PaleGreen
            // 
            this.PaleGreen.BackColor = System.Drawing.Color.PaleGreen;
            this.PaleGreen.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.PaleGreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PaleGreen.Location = new System.Drawing.Point(56, 12);
            this.PaleGreen.Name = "PaleGreen";
            this.PaleGreen.Size = new System.Drawing.Size(40, 40);
            this.PaleGreen.TabIndex = 2;
            this.PaleGreen.UseVisualStyleBackColor = false;
            this.PaleGreen.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // Pink
            // 
            this.Pink.BackColor = System.Drawing.Color.Pink;
            this.Pink.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.Pink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Pink.Location = new System.Drawing.Point(10, 58);
            this.Pink.Name = "Pink";
            this.Pink.Size = new System.Drawing.Size(40, 40);
            this.Pink.TabIndex = 5;
            this.Pink.UseVisualStyleBackColor = false;
            this.Pink.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // Plum
            // 
            this.Plum.BackColor = System.Drawing.Color.Plum;
            this.Plum.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.Plum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Plum.Location = new System.Drawing.Point(102, 58);
            this.Plum.Name = "Plum";
            this.Plum.Size = new System.Drawing.Size(40, 40);
            this.Plum.TabIndex = 7;
            this.Plum.UseVisualStyleBackColor = false;
            this.Plum.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // Khaki
            // 
            this.Khaki.BackColor = System.Drawing.Color.Khaki;
            this.Khaki.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.Khaki.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Khaki.Location = new System.Drawing.Point(10, 12);
            this.Khaki.Name = "Khaki";
            this.Khaki.Size = new System.Drawing.Size(40, 40);
            this.Khaki.TabIndex = 1;
            this.Khaki.UseVisualStyleBackColor = false;
            this.Khaki.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // SandyBrown
            // 
            this.SandyBrown.BackColor = System.Drawing.Color.SandyBrown;
            this.SandyBrown.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.SandyBrown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SandyBrown.Location = new System.Drawing.Point(148, 58);
            this.SandyBrown.Name = "SandyBrown";
            this.SandyBrown.Size = new System.Drawing.Size(40, 40);
            this.SandyBrown.TabIndex = 8;
            this.SandyBrown.UseVisualStyleBackColor = false;
            this.SandyBrown.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // CornflowerBlue
            // 
            this.CornflowerBlue.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CornflowerBlue.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.CornflowerBlue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CornflowerBlue.Location = new System.Drawing.Point(148, 12);
            this.CornflowerBlue.Name = "CornflowerBlue";
            this.CornflowerBlue.Size = new System.Drawing.Size(40, 40);
            this.CornflowerBlue.TabIndex = 4;
            this.CornflowerBlue.UseVisualStyleBackColor = false;
            this.CornflowerBlue.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // PaleTurquoise
            // 
            this.PaleTurquoise.BackColor = System.Drawing.Color.PaleTurquoise;
            this.PaleTurquoise.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.PaleTurquoise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PaleTurquoise.Location = new System.Drawing.Point(102, 12);
            this.PaleTurquoise.Name = "PaleTurquoise";
            this.PaleTurquoise.Size = new System.Drawing.Size(40, 40);
            this.PaleTurquoise.TabIndex = 3;
            this.PaleTurquoise.UseVisualStyleBackColor = false;
            this.PaleTurquoise.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // LightCoral
            // 
            this.LightCoral.BackColor = System.Drawing.Color.LightCoral;
            this.LightCoral.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.LightCoral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LightCoral.Location = new System.Drawing.Point(56, 58);
            this.LightCoral.Name = "LightCoral";
            this.LightCoral.Size = new System.Drawing.Size(40, 40);
            this.LightCoral.TabIndex = 6;
            this.LightCoral.UseVisualStyleBackColor = false;
            this.LightCoral.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // FormColorPlate
            // 
            this.ClientSize = new System.Drawing.Size(201, 110);
            this.Controls.Add(this.PaleTurquoise);
            this.Controls.Add(this.CornflowerBlue);
            this.Controls.Add(this.SandyBrown);
            this.Controls.Add(this.Khaki);
            this.Controls.Add(this.Plum);
            this.Controls.Add(this.Pink);
            this.Controls.Add(this.PaleGreen);
            this.Controls.Add(this.LightCoral);
            this.Name = "FormColorPlate";
            this.Text = "Color Plate";
            this.ResumeLayout(false);

        }

        private void colorButton_Click(object sender, EventArgs e)
        {
            string color = m_CurrentButton.BackColor.Name;

            if (color != "Control")
            {
                Control colorButton = Controls.Find(color, false)[0];
                (colorButton as Button).Enabled = true;
            }

            m_CurrentButton.BackColor = (sender as Button).BackColor;
            (sender as Button).Enabled = false;
            this.Hide();
        }
    }
}
