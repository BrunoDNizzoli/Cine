namespace BrujudamRemaster
{
    partial class PantallaEmpleados
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
            this.btnAMBU = new System.Windows.Forms.Button();
            this.btnAMBP = new System.Windows.Forms.Button();
            this.btnAMBPRO = new System.Windows.Forms.Button();
            this.btnAMBS = new System.Windows.Forms.Button();
            this.btnInformes = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAMBU
            // 
            this.btnAMBU.Location = new System.Drawing.Point(21, 64);
            this.btnAMBU.Name = "btnAMBU";
            this.btnAMBU.Size = new System.Drawing.Size(109, 23);
            this.btnAMBU.TabIndex = 0;
            this.btnAMBU.Text = "AMB USUARIOS";
            this.btnAMBU.UseVisualStyleBackColor = true;
            this.btnAMBU.Click += new System.EventHandler(this.btnAMBU_Click);
            // 
            // btnAMBP
            // 
            this.btnAMBP.Location = new System.Drawing.Point(153, 64);
            this.btnAMBP.Name = "btnAMBP";
            this.btnAMBP.Size = new System.Drawing.Size(105, 23);
            this.btnAMBP.TabIndex = 1;
            this.btnAMBP.Text = "AMB PELICULAS";
            this.btnAMBP.UseVisualStyleBackColor = true;
            this.btnAMBP.Click += new System.EventHandler(this.btnAMBP_Click);
            // 
            // btnAMBPRO
            // 
            this.btnAMBPRO.Location = new System.Drawing.Point(293, 64);
            this.btnAMBPRO.Name = "btnAMBPRO";
            this.btnAMBPRO.Size = new System.Drawing.Size(112, 23);
            this.btnAMBPRO.TabIndex = 2;
            this.btnAMBPRO.Text = "AMB PRODUCTOS";
            this.btnAMBPRO.UseVisualStyleBackColor = true;
            this.btnAMBPRO.Click += new System.EventHandler(this.btnAMBPRO_Click);
            // 
            // btnAMBS
            // 
            this.btnAMBS.Location = new System.Drawing.Point(420, 64);
            this.btnAMBS.Name = "btnAMBS";
            this.btnAMBS.Size = new System.Drawing.Size(75, 23);
            this.btnAMBS.TabIndex = 3;
            this.btnAMBS.Text = "AMB SALA";
            this.btnAMBS.UseVisualStyleBackColor = true;
            this.btnAMBS.Click += new System.EventHandler(this.btnAMBS_Click);
            // 
            // btnInformes
            // 
            this.btnInformes.Location = new System.Drawing.Point(236, 117);
            this.btnInformes.Name = "btnInformes";
            this.btnInformes.Size = new System.Drawing.Size(75, 23);
            this.btnInformes.TabIndex = 4;
            this.btnInformes.Text = "INFORMES";
            this.btnInformes.UseVisualStyleBackColor = true;
            this.btnInformes.Click += new System.EventHandler(this.btnInformes_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "               Bienvenido a la pestaña de empleados \r\n!su uso esta autorizado sol" +
    "o para personal de brujudam!";
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(420, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(93, 23);
            this.btnRegresar.TabIndex = 6;
            this.btnRegresar.Text = "Volver a login";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // PantallaEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 168);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnInformes);
            this.Controls.Add(this.btnAMBS);
            this.Controls.Add(this.btnAMBPRO);
            this.Controls.Add(this.btnAMBP);
            this.Controls.Add(this.btnAMBU);
            this.Name = "PantallaEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PantallaEmpleados";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAMBU;
        private System.Windows.Forms.Button btnAMBP;
        private System.Windows.Forms.Button btnAMBPRO;
        private System.Windows.Forms.Button btnAMBS;
        private System.Windows.Forms.Button btnInformes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegresar;
    }
}