using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorSemaforo
{
    public partial class FormConfig : Form
    {
        public int TiempoRojo { get; private set; }
        public int TiempoAmarillo { get; private set; }
        public int TiempoVerde { get; private set; }

        public FormConfig(int rojo, int amarillo, int verde)
        {
            InitializeComponent();

            numericUpDownRojo.Minimum = 1; numericUpDownRojo.Maximum = 300;
            numericUpDownAmarillo.Minimum = 1; numericUpDownAmarillo.Maximum = 60;
            numericUpDownVerde.Minimum = 1; numericUpDownVerde.Maximum = 300;

            numericUpDownRojo.Value = rojo;
            numericUpDownAmarillo.Value = amarillo;
            numericUpDownVerde.Value = verde;

            btnAceptar.Click += btnAceptar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
          
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            TiempoRojo = (int)numericUpDownRojo.Value;
            TiempoAmarillo = (int)numericUpDownAmarillo.Value;
            TiempoVerde = (int)numericUpDownVerde.Value;

            if (TiempoRojo <= 0 || TiempoAmarillo <= 0 || TiempoVerde <= 0)
            {
                MessageBox.Show("Todos los tiempos deben ser mayores que 0.", "Validación",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
