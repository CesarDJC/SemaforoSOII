using System.Media;

namespace SimuladorSemaforo
{
    public partial class Form1 : Form
    {
        // Control de hilos
        private CancellationTokenSource cts;

        // Tiempos
        private int tiempoRojo = 10;
        private int tiempoAmarillo = 3;
        private int tiempoVerde = 7;

        // Estados de los semáforos
        private int estado1 = 0; // Semáforo 1 empieza en Rojo
        private int estado2 = 2; // Semáforo 2 empieza en Verde
        private int contador1;
        private int contador2;

        // Sensor de tráfico
        private bool sensorActivado = false;

        // Recursos
        private readonly string rutaRecursos = Application.StartupPath + "\\Recursos\\";
        private SoundPlayer sonidoVerde;
        private SoundPlayer sonidoRojo;

        private Image rojoOn, rojoOff, amarilloOn, amarilloOff, verdeOn, verdeOff;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Cargar sonidos
            sonidoVerde = new SoundPlayer(rutaRecursos + "verde.wav");
            sonidoRojo = new SoundPlayer(rutaRecursos + "rojo.wav");

            // Cargar imágenes
            rojoOn = Image.FromFile(rutaRecursos + "rojo_on.png");
            rojoOff = Image.FromFile(rutaRecursos + "rojo_off.png");
            amarilloOn = Image.FromFile(rutaRecursos + "amarillo_on.png");
            amarilloOff = Image.FromFile(rutaRecursos + "amarillo_off.png");
            verdeOn = Image.FromFile(rutaRecursos + "verde_on.png");
            verdeOff = Image.FromFile(rutaRecursos + "verde_off.png");

            InicializarSemaforo();
        }
        private void InicializarSemaforo()
        {
            estado1 = 0; contador1 = tiempoRojo;   // Semáforo 1 empieza en rojo
            estado2 = 2; contador2 = tiempoVerde;  // Semáforo 2 empieza en verde
            ActualizarSemaforos();
        }


        // 🚦 Simulación en un hilo aparte
        // 🚦 Simulación en un hilo aparte
        private void SimularSemaforos(CancellationToken token)
        {
            // Variables para guardar la duración total de cada fase
            int duracion1 = 0;
            int duracion2 = 0;

            while (!token.IsCancellationRequested)
            {
                contador1--;
                contador2--;

                // ---- Semáforo 1 ----
                if (contador1 <= 0)
                {
                    switch (estado1)
                    {
                        case 0: // Rojo → Verde
                            estado1 = 2;
                            duracion1 = tiempoVerde;
                            if (sensorActivado) { duracion1 += 5; }
                            contador1 = duracion1;
                            TryPlay(sonidoVerde);
                            break;

                        case 2: // Verde → Amarillo
                            estado1 = 1;
                            duracion1 = tiempoAmarillo;
                            contador1 = duracion1;
                            break;

                        case 1: // Amarillo → Rojo
                            estado1 = 0;
                            duracion1 = tiempoRojo;
                            contador1 = duracion1;
                            TryPlay(sonidoRojo);
                            break;
                    }
                }

                // ---- Semáforo 2 ----
                if (contador2 <= 0)
                {
                    switch (estado2)
                    {
                        case 0: // Rojo → Verde
                            estado2 = 2;
                            duracion2 = tiempoVerde;
                            if (sensorActivado) { duracion2 += 5; }
                            contador2 = duracion2;
                            TryPlay(sonidoVerde);
                            break;

                        case 2: // Verde → Amarillo
                            estado2 = 1;
                            duracion2 = tiempoAmarillo;
                            contador2 = duracion2;
                            break;

                        case 1: // Amarillo → Rojo
                            estado2 = 0;
                            duracion2 = tiempoRojo;
                            contador2 = duracion2;
                            TryPlay(sonidoRojo);
                            break;
                    }
                }

                // ✅ Desactivamos el sensor después de aplicarlo
                if (sensorActivado) sensorActivado = false;

                // 🔄 Actualizar la interfaz gráfica (desde hilo UI con Invoke)
                this.Invoke((Action)(() =>
                {
                    ActualizarSemaforos();
                    lblEstado.Text =
                        $"Semáforo 1: {(estado1 == 0 ? "Rojo" : estado1 == 1 ? "Amarillo" : "Verde")} ({contador1}/{duracion1}s)\n" +
                        $"Semáforo 2: {(estado2 == 0 ? "Rojo" : estado2 == 1 ? "Amarillo" : "Verde")} ({contador2}/{duracion2}s)";
                }));

                Thread.Sleep(1000); // ⏱ Espera 1 segundo entre ciclos
            }
        }


        // Actualiza imágenes de luces
        private void ActualizarSemaforos()
        {
            // Semáforo 1
            pictureBoxRojo.Image = (estado1 == 0) ? rojoOn : rojoOff;
            pictureBoxAmarillo.Image = (estado1 == 1) ? amarilloOn : amarilloOff;
            pictureBoxVerde.Image = (estado1 == 2) ? verdeOn : verdeOff;

            // Semáforo 2
            pictureBoxRojo2.Image = (estado2 == 0) ? rojoOn : rojoOff;
            pictureBoxAmarillo2.Image = (estado2 == 1) ? amarilloOn : amarilloOff;
            pictureBoxVerde2.Image = (estado2 == 2) ? verdeOn : verdeOff;
        }

        private static void TryPlay(SoundPlayer sp)
        {
            try { sp?.Play(); } catch { }
        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            await Task.Run(() => SimularSemaforos(cts.Token));
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            cts?.Cancel();
        }

        private void btnConfigurar_Click(object sender, EventArgs e)
        {
            using var config = new FormConfig(tiempoRojo, tiempoAmarillo, tiempoVerde);
            if (config.ShowDialog(this) == DialogResult.OK)
            {
                tiempoRojo = config.TiempoRojo;
                tiempoAmarillo = config.TiempoAmarillo;
                tiempoVerde = config.TiempoVerde;
                InicializarSemaforo();
            }
        }

        private void btnSensor_Click(object sender, EventArgs e)
        {
            sensorActivado = true;

            // ⏱ Si alguno está en verde ahora mismo, le añadimos +5 al contador directamente
            if (estado1 == 2) contador1 += 5;
            if (estado2 == 2) contador2 += 5;

            MessageBox.Show("Sensor activado: el próximo o actual verde durará +5s.",
                            "Sensor de tráfico", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        { cts?.Cancel();

            try { sonidoVerde?.Stop(); sonidoVerde?.Dispose(); } catch { }
            try { sonidoRojo?.Stop(); sonidoRojo?.Dispose(); } catch { }

            rojoOn?.Dispose();
            rojoOff?.Dispose();
            amarilloOn?.Dispose();
            amarilloOff?.Dispose();
            verdeOn?.Dispose();
            verdeOff?.Dispose();

            base.OnFormClosing(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
