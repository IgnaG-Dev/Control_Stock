namespace CapaPresentacion
{
    partial class Login
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBDni = new System.Windows.Forms.TextBox();
            this.TBClave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BIngresar = new FontAwesome.Sharp.IconButton();
            this.BSalir = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(409, 372);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "SISTEMA DE VENTA";
            // 
            // TBDni
            // 
            this.TBDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDni.Location = new System.Drawing.Point(439, 77);
            this.TBDni.Name = "TBDni";
            this.TBDni.Size = new System.Drawing.Size(313, 35);
            this.TBDni.TabIndex = 3;
            // 
            // TBClave
            // 
            this.TBClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBClave.Location = new System.Drawing.Point(439, 154);
            this.TBClave.Name = "TBClave";
            this.TBClave.PasswordChar = '*';
            this.TBClave.Size = new System.Drawing.Size(313, 35);
            this.TBClave.TabIndex = 4;
            this.TBClave.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(435, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nro. Documento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(435, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña";
            // 
            // BIngresar
            // 
            this.BIngresar.BackColor = System.Drawing.Color.RoyalBlue;
            this.BIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BIngresar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BIngresar.ForeColor = System.Drawing.Color.White;
            this.BIngresar.IconChar = FontAwesome.Sharp.IconChar.SignIn;
            this.BIngresar.IconColor = System.Drawing.Color.White;
            this.BIngresar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BIngresar.IconSize = 25;
            this.BIngresar.Location = new System.Drawing.Point(602, 267);
            this.BIngresar.Name = "BIngresar";
            this.BIngresar.Size = new System.Drawing.Size(150, 44);
            this.BIngresar.TabIndex = 7;
            this.BIngresar.Text = "Ingresar";
            this.BIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BIngresar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BIngresar.UseVisualStyleBackColor = false;
            this.BIngresar.Click += new System.EventHandler(this.BIngresar_Click);
            // 
            // BSalir
            // 
            this.BSalir.BackColor = System.Drawing.Color.Firebrick;
            this.BSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BSalir.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.BSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BSalir.ForeColor = System.Drawing.Color.White;
            this.BSalir.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.BSalir.IconColor = System.Drawing.Color.White;
            this.BSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.BSalir.IconSize = 25;
            this.BSalir.Location = new System.Drawing.Point(439, 267);
            this.BSalir.Name = "BSalir";
            this.BSalir.Size = new System.Drawing.Size(150, 44);
            this.BSalir.TabIndex = 8;
            this.BSalir.Text = "Salir";
            this.BSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BSalir.UseVisualStyleBackColor = false;
            this.BSalir.Click += new System.EventHandler(this.BSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources._13183281_1065443036886929_936090605_a;
            this.pictureBox1.Location = new System.Drawing.Point(73, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(240, 215);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Login
            // 
            this.AcceptButton = this.BIngresar;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.BSalir;
            this.ClientSize = new System.Drawing.Size(764, 372);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BSalir);
            this.Controls.Add(this.BIngresar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBClave);
            this.Controls.Add(this.TBDni);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBDni;
        private System.Windows.Forms.TextBox TBClave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton BIngresar;
        private FontAwesome.Sharp.IconButton BSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}