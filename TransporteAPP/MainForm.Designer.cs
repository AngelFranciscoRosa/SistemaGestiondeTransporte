namespace TransporteAPP
{
    partial class MainForm
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
            this.lblhora = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.btnRutas = new System.Windows.Forms.Button();
            this.btnAutobuses = new System.Windows.Forms.Button();
            this.btnAsignaciones = new System.Windows.Forms.Button();
            this.btnChoferes = new System.Windows.Forms.Button();
            this.btncerrarsesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblhora
            // 
            this.lblhora.AutoSize = true;
            this.lblhora.BackColor = System.Drawing.Color.Transparent;
            this.lblhora.Font = new System.Drawing.Font("Times New Roman", 35F, System.Drawing.FontStyle.Bold);
            this.lblhora.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblhora.Location = new System.Drawing.Point(346, 185);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(361, 67);
            this.lblhora.TabIndex = 5;
            this.lblhora.Text = "LabelTiempo";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(373, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(334, 68);
            this.label1.TabIndex = 6;
            this.label1.Text = "!Bienvenido";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.Transparent;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblusuario.Location = new System.Drawing.Point(443, 377);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(86, 25);
            this.lblusuario.TabIndex = 7;
            this.lblusuario.Text = "Usuario";
            // 
            // btnRutas
            // 
            this.btnRutas.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRutas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRutas.Location = new System.Drawing.Point(12, 129);
            this.btnRutas.Name = "btnRutas";
            this.btnRutas.Size = new System.Drawing.Size(179, 77);
            this.btnRutas.TabIndex = 2;
            this.btnRutas.Text = "Rutas";
            this.btnRutas.UseVisualStyleBackColor = false;
            this.btnRutas.Click += new System.EventHandler(this.btnRutas_Click);
            // 
            // btnAutobuses
            // 
            this.btnAutobuses.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAutobuses.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutobuses.Location = new System.Drawing.Point(14, 324);
            this.btnAutobuses.Name = "btnAutobuses";
            this.btnAutobuses.Size = new System.Drawing.Size(179, 78);
            this.btnAutobuses.TabIndex = 1;
            this.btnAutobuses.Text = "Autobuses";
            this.btnAutobuses.UseVisualStyleBackColor = false;
            this.btnAutobuses.Click += new System.EventHandler(this.btnAutobuses_Click);
            // 
            // btnAsignaciones
            // 
            this.btnAsignaciones.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAsignaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsignaciones.Location = new System.Drawing.Point(12, 31);
            this.btnAsignaciones.Name = "btnAsignaciones";
            this.btnAsignaciones.Size = new System.Drawing.Size(179, 77);
            this.btnAsignaciones.TabIndex = 3;
            this.btnAsignaciones.Text = "Asignaciones";
            this.btnAsignaciones.UseVisualStyleBackColor = false;
            this.btnAsignaciones.Click += new System.EventHandler(this.btnAsignaciones_Click);
            // 
            // btnChoferes
            // 
            this.btnChoferes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnChoferes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoferes.Location = new System.Drawing.Point(14, 226);
            this.btnChoferes.Name = "btnChoferes";
            this.btnChoferes.Size = new System.Drawing.Size(179, 77);
            this.btnChoferes.TabIndex = 0;
            this.btnChoferes.Text = "Choferes";
            this.btnChoferes.UseVisualStyleBackColor = false;
            this.btnChoferes.Click += new System.EventHandler(this.btnChoferes_Click);
            // 
            // btncerrarsesion
            // 
            this.btncerrarsesion.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btncerrarsesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrarsesion.Location = new System.Drawing.Point(12, 618);
            this.btncerrarsesion.Name = "btncerrarsesion";
            this.btncerrarsesion.Size = new System.Drawing.Size(180, 52);
            this.btncerrarsesion.TabIndex = 5;
            this.btncerrarsesion.Text = "Cerrar Sesion ";
            this.btncerrarsesion.UseVisualStyleBackColor = false;
            this.btncerrarsesion.Click += new System.EventHandler(this.btncerrarsesion_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = global::TransporteAPP.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1001, 699);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btncerrarsesion);
            this.Controls.Add(this.lblhora);
            this.Controls.Add(this.btnChoferes);
            this.Controls.Add(this.btnAutobuses);
            this.Controls.Add(this.btnAsignaciones);
            this.Controls.Add(this.btnRutas);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Button btnRutas;
        private System.Windows.Forms.Button btnAutobuses;
        private System.Windows.Forms.Button btnAsignaciones;
        private System.Windows.Forms.Button btnChoferes;
        private System.Windows.Forms.Button btncerrarsesion;
    }
}