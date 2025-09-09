namespace SimuladorSemaforo
{
    partial class FormConfig
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
            numericUpDownRojo = new NumericUpDown();
            numericUpDownAmarillo = new NumericUpDown();
            numericUpDownVerde = new NumericUpDown();
            btnAceptar = new Button();
            btnCancelar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRojo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmarillo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVerde).BeginInit();
            SuspendLayout();
            // 
            // numericUpDownRojo
            // 
            numericUpDownRojo.Location = new Point(204, 86);
            numericUpDownRojo.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numericUpDownRojo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRojo.Name = "numericUpDownRojo";
            numericUpDownRojo.Size = new Size(150, 27);
            numericUpDownRojo.TabIndex = 0;
            numericUpDownRojo.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // numericUpDownAmarillo
            // 
            numericUpDownAmarillo.Location = new Point(204, 163);
            numericUpDownAmarillo.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            numericUpDownAmarillo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownAmarillo.Name = "numericUpDownAmarillo";
            numericUpDownAmarillo.Size = new Size(150, 27);
            numericUpDownAmarillo.TabIndex = 1;
            numericUpDownAmarillo.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // numericUpDownVerde
            // 
            numericUpDownVerde.Location = new Point(204, 233);
            numericUpDownVerde.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            numericUpDownVerde.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownVerde.Name = "numericUpDownVerde";
            numericUpDownVerde.Size = new Size(150, 27);
            numericUpDownVerde.TabIndex = 2;
            numericUpDownVerde.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // btnAceptar
            // 
            btnAceptar.DialogResult = DialogResult.OK;
            btnAceptar.Location = new Point(494, 122);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(494, 199);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 29);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(56, 86);
            label1.Name = "label1";
            label1.Size = new Size(51, 25);
            label1.TabIndex = 5;
            label1.Text = "Rojo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 163);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 6;
            label2.Text = "Anaranjado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(56, 240);
            label3.Name = "label3";
            label3.Size = new Size(61, 25);
            label3.TabIndex = 7;
            label3.Text = "Verde";
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(numericUpDownVerde);
            Controls.Add(numericUpDownAmarillo);
            Controls.Add(numericUpDownRojo);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración semaforos";
            Load += FormConfig_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownRojo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAmarillo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownVerde).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numericUpDownRojo;
        private NumericUpDown numericUpDownAmarillo;
        private NumericUpDown numericUpDownVerde;
        private Button btnAceptar;
        private Button btnCancelar;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}