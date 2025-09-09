using System.Media;

namespace SimuladorSemaforo
{
    public partial class Form1 : Form
    {
        // Control de hilos
        private CancellationTokenSource cts;
        private bool simulando = false; //evitar múltiples hilos

        // Tiempos
        private int tiempoRojo = 10;
        private int tiempoAmarillo = 3;
        private int tiempoVerde = 7;

        // Estado del semáforo
        private int estado = 0; // 0 = Rojo, 1 = Amarillo, 2 = Verde
        private int contador;

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
            estado = 0;
            contador = tiempoRojo;   // Semáforo empieza en rojo
            ActualizarSemaforo();
        }

        private void SimularSemaforo(CancellationToken token)
        {
            int duracion = tiempoRojo;

            while (!token.IsCancellationRequested)
            {
                contador--;

                if (contador <= 0)
                {
                    switch (estado)
                    {
                        case 0: // Rojo a Verde
                            estado = 2;
                            duracion = tiempoVerde;

                            //  aplicar sensor antes de asignar contador
                            if (sensorActivado)
                            {
                                duracion += 5;
                                sensorActivado = false; // consumirlo aquí
                            }

                            contador = duracion;
                            TryPlay(sonidoVerde);
                            break;

                        case 2: // Verde a Amarillo
                            estado = 1;
                            duracion = tiempoAmarillo;
                            contador = duracion;
                            break;

                        case 1: //  Amarillo a Rojo
                            estado = 0;
                            duracion = tiempoRojo;
                            contador = duracion;
                            TryPlay(sonidoRojo);
                            break;
                    }
                }


                this.Invoke((Action)(() =>
                {
                    ActualizarSemaforo();
                    lblEstado.Text =
                        $"Semáforo: {(estado == 0 ? "Rojo" : estado == 1 ? "Amarillo" : "Verde")} ({contador}/{duracion}s)";
                }));

                Thread.Sleep(1000); // ⏱ 1 segundo
            }
        }

        private void ActualizarSemaforo()
        {
            pictureBoxRojo.Image = (estado == 0) ? rojoOn : rojoOff;
            pictureBoxAmarillo.Image = (estado == 1) ? amarilloOn : amarilloOff;
            pictureBoxVerde.Image = (estado == 2) ? verdeOn : verdeOff;
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
            if (simulando) return; 
            simulando = true;

            cts = new CancellationTokenSource();
            try
            {
                await Task.Run(() => SimularSemaforo(cts.Token));
            }
            finally
            {
                simulando = false;
            }

        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            if (!simulando) return; 
            cts?.Cancel();
            simulando = false;

            
            InicializarSemaforo();
            lblEstado.Text=string.Empty;
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

            // Si está en verde ahora mismo, alarga directamente
            if (estado == 2) contador += 5;

            MessageBox.Show("Sensor activado: el próximo o actual verde durará +5s.",
                            "Sensor de tráfico", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            cts?.Cancel();

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
