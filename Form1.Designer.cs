namespace SimuladorSemaforo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBoxRojo = new PictureBox();
            pictureBoxAmarillo = new PictureBox();
            pictureBoxVerde = new PictureBox();
            lblEstado = new Label();
            btnIniciar = new Button();
            btnDetener = new Button();
            btnConfigurar = new Button();
            btnSensor = new Button();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxRojo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAmarillo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVerde).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxRojo
            // 
            pictureBoxRojo.Location = new Point(24, 13);
            pictureBoxRojo.Name = "pictureBoxRojo";
            pictureBoxRojo.Size = new Size(80, 80);
            pictureBoxRojo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxRojo.TabIndex = 0;
            pictureBoxRojo.TabStop = false;
            // 
            // pictureBoxAmarillo
            // 
            pictureBoxAmarillo.Location = new Point(24, 140);
            pictureBoxAmarillo.Name = "pictureBoxAmarillo";
            pictureBoxAmarillo.Size = new Size(80, 80);
            pictureBoxAmarillo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAmarillo.TabIndex = 1;
            pictureBoxAmarillo.TabStop = false;
            // 
            // pictureBoxVerde
            // 
            pictureBoxVerde.Location = new Point(24, 257);
            pictureBoxVerde.Name = "pictureBoxVerde";
            pictureBoxVerde.Size = new Size(80, 80);
            pictureBoxVerde.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxVerde.TabIndex = 2;
            pictureBoxVerde.TabStop = false;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(209, 20);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 28);
            lblEstado.TabIndex = 6;
            lblEstado.Click += lblEstado_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(337, 112);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(127, 50);
            btnIniciar.TabIndex = 7;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = true;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // btnDetener
            // 
            btnDetener.Location = new Point(334, 200);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(127, 43);
            btnDetener.TabIndex = 8;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = true;
            btnDetener.Click += btnDetener_Click;
            // 
            // btnConfigurar
            // 
            btnConfigurar.Location = new Point(334, 273);
            btnConfigurar.Name = "btnConfigurar";
            btnConfigurar.Size = new Size(127, 48);
            btnConfigurar.TabIndex = 9;
            btnConfigurar.Text = "Configurar";
            btnConfigurar.UseVisualStyleBackColor = true;
            btnConfigurar.Click += btnConfigurar_Click;
            // 
            // btnSensor
            // 
            btnSensor.Location = new Point(334, 359);
            btnSensor.Name = "btnSensor";
            btnSensor.Size = new Size(130, 59);
            btnSensor.TabIndex = 10;
            btnSensor.Text = "Sensor Tráfico";
            btnSensor.UseVisualStyleBackColor = true;
            btnSensor.Click += btnSensor_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlText;
            panel2.Controls.Add(pictureBoxRojo);
            panel2.Controls.Add(pictureBoxAmarillo);
            panel2.Controls.Add(pictureBoxVerde);
            panel2.Location = new Point(71, 81);
            panel2.Name = "panel2";
            panel2.Size = new Size(138, 368);
            panel2.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(680, 461);
            Controls.Add(panel2);
            Controls.Add(btnSensor);
            Controls.Add(btnConfigurar);
            Controls.Add(btnDetener);
            Controls.Add(btnIniciar);
            Controls.Add(lblEstado);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Simulador Semaforo";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxRojo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAmarillo).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxVerde).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxRojo;
        private PictureBox pictureBoxAmarillo;
        private PictureBox pictureBoxVerde;
        private Label lblEstado;
        private Button btnIniciar;
        private Button btnDetener;
        private Button btnConfigurar;
        private Button btnSensor;
        private Panel panel2;
    }
}
