using Safe_Personal_Data.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Safe_Personal_Data
{
    public partial class Form1 : Form
    {
        private Changelog changelog = new Changelog();

        private string PASSWORD = "Dellons";
        private const string FILE_EXTENSION = ".ed";

        private ContextMenu trayMenu = new ContextMenu();

        private int[] constantesTeclasPegadoInteligente = { -127, -128 };
        private const int STANDBY = 0;
        private const int WAITING_FIRST_PASTE = 1;
        private const int WAITING_SECOND_PASTE = 2;

        private bool ctrlC = false;
        private bool ctrlV = false;
        /*
         * 0 = No ha comenzado
         * 1 = Comenzo, esperando CTRL + V
         * 2 = Primer CTRL + V detectado, esperando segundo
         */ 
        private int etapaPegadoInteligente = 0;

        private bool yaMostroAlarmaInfo = false;
        private bool yaMostroPingInfo = false;
        
        private string itemSeleccionado;
        private int idCopiadoInteligente;

        private ConnectionHandler ch = new ConnectionHandler();

        #region Funciones copiadas

        [Flags]
        private enum KeyStates
        {
            None = 0,
            Down = 1,
            Toggled = 2
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern short GetKeyState(int keyCode);

        private static KeyStates GetKeyState(Keys key)
        {
            KeyStates state = KeyStates.None;

            short retVal = GetKeyState((int)key);

            //If the high-order bit is 1, the key is down
            //otherwise, it is up.
            if ((retVal & 0x8000) == 0x8000)
                state |= KeyStates.Down;

            //If the low-order bit is 1, the key is toggled.
            if ((retVal & 1) == 1)
                state |= KeyStates.Toggled;

            return state;
        }

        public static bool IsKeyDown(Keys key)
        {
            return KeyStates.Down == (GetKeyState(key) & KeyStates.Down);
        }

        public static bool IsKeyToggled(Keys key)
        {
            return KeyStates.Toggled == (GetKeyState(key) & KeyStates.Toggled);
        }
       
        #endregion

        #region Mis Funciones

        private void subirCuenta()
        {
            if (itemSeleccionado != null)
            {
                // Paramos el timer
                timerActivarSubirBajar.Stop();

                ListView nuevaListViewCuentas = new ListView();
                ListView nuevaListViewClaves = new ListView();

                // Para seguir despues de haber encontrado a subir
                int seguirDesde = 0;

                for (int i = 0; i < listaCuentas.Items.Count; i++)
                {
                    if (i + 1 < listaCuentas.Items.Count)
                    {
                        if (listaCuentas.Items[i + 1].Text == itemSeleccionado || listaClaves.Items[i + 1].Text == itemSeleccionado)
                        {
                            // Añadimos el que vamos a subir
                            nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i + 1].Clone());
                            nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i + 1].Clone());
                            // Añadimos el que estaba antes (arriba)
                            nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i].Clone());
                            nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i].Clone());
                            // Salimos y dejamos donde debemos seguir
                            seguirDesde = i + 2;
                            break;
                        }
                        else
                        {
                            nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i].Clone());
                            nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i].Clone());
                        }
                    }
                }

                // Seguimos copiando
                for (int i = seguirDesde; i < listaCuentas.Items.Count; i++)
                {
                    nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i].Clone());
                    nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i].Clone());
                }

                // Vaciamos las lista actuales
                listaCuentas.Items.Clear();
                listaClaves.Items.Clear();

                // Copiamos todo lo de las nuevas ListView
                for (int i = 0; i < nuevaListViewCuentas.Items.Count; i++)
                {
                    listaCuentas.Items.Add((ListViewItem)nuevaListViewCuentas.Items[i].Clone());
                    listaClaves.Items.Add((ListViewItem)nuevaListViewClaves.Items[i].Clone());
                }

                // Reactivamos el timer
                timerActivarSubirBajar.Start();
            }            
        }

        private void bajarCuenta()
        {
            if (itemSeleccionado != null)
            {
                // Paramos el timer
                timerActivarSubirBajar.Stop();

                ListView nuevaListViewCuentas = new ListView();
                ListView nuevaListViewClaves = new ListView();

                // Para seguir despues de haber encontrado a subir
                int seguirDesde = 0;

                for (int i = 0; i < listaCuentas.Items.Count; i++)
                {
                    if (i + 1 < listaCuentas.Items.Count)
                    {
                        if (listaCuentas.Items[i].Text == itemSeleccionado || listaClaves.Items[i].Text == itemSeleccionado)
                        {
                            // Añadimos el que vamos a subir
                            nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i + 1].Clone());
                            nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i + 1].Clone());
                            // Añadimos el que estaba antes (arriba)
                            nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i].Clone());
                            nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i].Clone());
                            // Salimos y dejamos donde debemos seguir
                            seguirDesde = i + 2;
                            break;
                        }
                        else
                        {
                            nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i].Clone());
                            nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i].Clone());
                        }
                    }
                }

                // Seguimos copiando
                for (int i = seguirDesde; i < listaCuentas.Items.Count; i++)
                {
                    nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i].Clone());
                    nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i].Clone());
                }

                // Vaciamos las lista actuales
                listaCuentas.Items.Clear();
                listaClaves.Items.Clear();

                // Copiamos todo lo de las nuevas ListView
                for (int i = 0; i < nuevaListViewCuentas.Items.Count; i++)
                {
                    listaCuentas.Items.Add((ListViewItem)nuevaListViewCuentas.Items[i].Clone());
                    listaClaves.Items.Add((ListViewItem)nuevaListViewClaves.Items[i].Clone());
                }

                // Reactivamos el timer
                timerActivarSubirBajar.Start();
            }      
        }

        private void eliminarCuenta()
        {
            if (itemSeleccionado != null)
            {
                // Paramos el timer
                timerActivarSubirBajar.Stop();

                ListView nuevaListViewCuentas = new ListView();
                ListView nuevaListViewClaves = new ListView();

                // Para seguir despues de haber encontrado a subir
                int seguirDesde = 0;

                for (int i = 0; i < listaCuentas.Items.Count; i++)
                {
                    if (listaCuentas.Items[i].Text == itemSeleccionado || listaClaves.Items[i].Text == itemSeleccionado)
                        continue;
                    else
                    {
                        nuevaListViewCuentas.Items.Add((ListViewItem)listaCuentas.Items[i].Clone());
                        nuevaListViewClaves.Items.Add((ListViewItem)listaClaves.Items[i].Clone());
                    }

                }

                // Vaciamos las lista actuales
                listaCuentas.Items.Clear();
                listaClaves.Items.Clear();

                // Copiamos todo lo de las nuevas ListView
                for (int i = 0; i < nuevaListViewCuentas.Items.Count; i++)
                {
                    listaCuentas.Items.Add((ListViewItem)nuevaListViewCuentas.Items[i].Clone());
                    listaClaves.Items.Add((ListViewItem)nuevaListViewClaves.Items[i].Clone());
                }

                // Reactivamos el timer
                timerActivarSubirBajar.Start();
            }            
        }

        private void iniciarTrayMenu()
        {
            trayMenu.MenuItems.Add("Mostrar", mostrarApp);
            trayMenu.MenuItems.Add("Cerrar", cerrarApp);

            trayIcon.ContextMenu = trayMenu;
        }

        private void mostrarApp(object sender, EventArgs e)
        {
            this.Visible = true;
            timerActivarSubirBajar.Enabled = true;
        }

        private void cerrarApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void copyToClipboard()
        {
            if (ctrlC)
            {
                try
                {
                    string cta = "null";
                    string pass = "null";
                    if (listaCuentas.Focused)
                        cta = listaCuentas.FocusedItem.Text;
                    if (listaClaves.Focused)
                        pass = listaClaves.FocusedItem.Text;

                    if (cta != "null")                    
                        Clipboard.SetText(cta);
                    if (pass != "null")                    
                        Clipboard.SetText(pass);                        
                    
                }
                catch (Exception e) { }
            }
        }

        private void smartCopy()
        {            
            try
            {
                string cta = "null";
                if (listaCuentas.Focused)
                    cta = listaCuentas.FocusedItem.Text;

                if (cta != "null")
                {
                    Clipboard.SetText(cta);
                    idCopiadoInteligente = listaCuentas.FocusedItem.Index;
                }
            }
            catch (Exception e) { }            
        }

        private void saveFile()
        {
            string archivo = "";

            for (int i = 0; i < listaCuentas.Items.Count; i++)
            {
                if (i > 0)
                    archivo += "\n";
                archivo += listaCuentas.Items[i].Text + "\n" + listaClaves.Items[i].Text;
            }

            string enc = Encriptador.Encrypt(archivo, PASSWORD);

            System.IO.File.WriteAllText(@"" + nombreArchivoGuardar.Text + FILE_EXTENSION, enc);
        }

        private void loadFile()
        {
            try
            {
                string[] lineas = System.IO.File.ReadAllLines(@"" + nombreArchivoCargar.Text + FILE_EXTENSION);

                string desencriptado = Encriptador.Decrypt(lineas.ElementAt(0), PASSWORD);
                string actual = "";
                int k = 0;

                for (int i = 0; i < desencriptado.Length; i++)
                {
                    if (desencriptado[i] == '\n')
                    {
                        if (k % 2 == 0)
                        {
                            ListViewItem cuenta = new ListViewItem(actual);
                            listaCuentas.Items.Add(cuenta);
                        }
                        else
                        {
                            ListViewItem clave = new ListViewItem(actual);
                            listaClaves.Items.Add(clave);
                        }
                        k++;
                        actual = "";
                    }
                    else
                        actual += desencriptado[i];

                    /* Chequeo ultima palabra */
                    if (i + 1 == desencriptado.Length)
                    {
                        ListViewItem clave = new ListViewItem(actual);
                        listaClaves.Items.Add(clave);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Archivo \"" + nombreArchivoCargar.Text + FILE_EXTENSION + "\" no encontrado o la palabra secreta no es la adecuada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        public Form1()
        {
            InitializeComponent();
            //MessageBox.Show(Encriptador.Encrypt("8332270894sf", "sf"));
            //System.IO.File.WriteAllText(@"Clave Sf", Encriptador.Encrypt("8332270894sf", "sf"));
            PASSWORD = secretWord.Text;

            changelog.Show();
            changelog.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            iniciarTrayMenu();
            ch.setIp("www.tibia.com");            
        }

        private void cuentaClaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Creamos el nuevo elemento
            ListViewItem cuenta = new ListViewItem("Nueva Cuenta");
            ListViewItem clave = new ListViewItem("Nueva Clave");
            

            listaCuentas.Items.Add(cuenta);
            listaClaves.Items.Add(clave);
        }

        #region Funciones de CTRL C y Doble Click

        private void listaCuentas_KeyDown(object sender, KeyEventArgs e)
        {
            /* Copiar al portapapeles con Ctrl+C */
            ctrlC = (e.Modifiers == Keys.Control && e.KeyCode == Keys.C);

            /* Copiado inteligente */
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.X)
            {
                etapaPegadoInteligente = WAITING_FIRST_PASTE;
                smartCopy();
            }

            // Hotkeys
            if (e.KeyCode == Keys.Up && subirToolStripMenuItem.Visible)
            {
                subirToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.Down && bajarToolStripMenuItem.Visible)
            {
                bajarToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.Delete)
            {
                eliminarCuenta();
            }
        }

        private void listaCuentas_KeyPress(object sender, KeyPressEventArgs e)
        {
            copyToClipboard();            
        }

        private void listaClaves_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlC = (e.Modifiers == Keys.Control && e.KeyCode == Keys.C);
        }

        private void listaClaves_KeyPress(object sender, KeyPressEventArgs e)
        {
            copyToClipboard();
        }

        private void listaCuentas_DoubleClick(object sender, EventArgs e)
        {
            listaCuentas.FocusedItem.BeginEdit();
        }

        private void listaClaves_DoubleClick(object sender, EventArgs e)
        {
            listaClaves.FocusedItem.BeginEdit();
        }

        #endregion

        private void cargarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFile();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Se sobreescribira el archivo existente de claves!\nEstas seguro que quieres continuar?", "ALERTA!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr == DialogResult.Yes)
            {
                saveFile();
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!this.Visible) return;

            listaClaves.AutoScrollOffset = new Point(listaClaves.AutoScrollOffset.X, listaCuentas.AutoScrollOffset.Y);
            
            if (!timerEsperarCopiado.Enabled)
                if (/* Estado de CTRL */
                    (GetKeyState((int)Keys.ControlKey) == constantesTeclasPegadoInteligente[0] ||
                    GetKeyState((int)Keys.ControlKey) == constantesTeclasPegadoInteligente[1]) &&
                    /* Estado de V */
                    (GetKeyState((int)Keys.V) == constantesTeclasPegadoInteligente[0] ||
                    GetKeyState((int)Keys.V) == constantesTeclasPegadoInteligente[1]))
                {
                    /* Vemos en que etapa estamos del pegado inteligente */

                    /* Aqui ya pego la primera vez, debemos copiar la clave */
                    if (etapaPegadoInteligente == WAITING_FIRST_PASTE)
                    {   
                        Clipboard.SetText(listaClaves.Items[idCopiadoInteligente].Text);
                        etapaPegadoInteligente = WAITING_SECOND_PASTE;
                        timerEsperarCopiado.Start();
                    }
                    /* Aqui ya pego la clave, reiniciamos todo */
                    else if (etapaPegadoInteligente == WAITING_SECOND_PASTE)
                        etapaPegadoInteligente = STANDBY;
                }


            /* Activar/Desactivar botones de Eliminar,Subir,Bajar */
            bool activoAlguno = false;
            try
            {
                string cta = "null";
                string pass = "null";
                if (listaCuentas.Focused)
                    cta = listaCuentas.FocusedItem.Text;
                if (listaClaves.Focused)
                    pass = listaClaves.FocusedItem.Text;

                if (cta != "null")
                {
                    if (listaCuentas.FocusedItem.Index > 0)
                        subirToolStripMenuItem.Visible = true;
                    else
                        subirToolStripMenuItem.Visible = false;

                    if (listaCuentas.FocusedItem.Index < listaCuentas.Items.Count - 1)
                        bajarToolStripMenuItem.Visible = true;
                    else
                        bajarToolStripMenuItem.Visible = false;


                    activoAlguno = true;
                    itemSeleccionado = listaCuentas.FocusedItem.Text;
                }
                if (pass != "null")
                {
                    if (listaClaves.FocusedItem.Index > 0)
                        subirToolStripMenuItem.Visible = true;
                    else
                        subirToolStripMenuItem.Visible = false;

                    if (listaClaves.FocusedItem.Index < listaClaves.Items.Count - 1)
                        bajarToolStripMenuItem.Visible = true;
                    else
                        bajarToolStripMenuItem.Visible = false;


                    activoAlguno = true;
                    itemSeleccionado = listaClaves.FocusedItem.Text;
                }
            }
            catch (Exception er) { }

            if (!activoAlguno)
            {
                subirToolStripMenuItem.Visible = false;
                bajarToolStripMenuItem.Visible = false;
                itemSeleccionado = null;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            int resize = 95;
            int constHorizForm = 450;

            listaCuentas.Size = new Size(listaCuentas.Size.Width, this.Size.Height - resize);
            listaClaves.Size = new Size(listaClaves.Size.Width, this.Size.Height - resize);
            this.Size = new Size(constHorizForm, this.Size.Height);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listaCuentas.Items.Clear();
            listaClaves.Items.Clear();
        }

        private void subirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            subirCuenta();
        }

        private void bajarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bajarCuenta();
        }

        private void separadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Separador
            ListViewItem cuenta = new ListViewItem("████████████████████████");
            ListViewItem clave = new ListViewItem("████████████████████████");


            listaCuentas.Items.Add(cuenta);
            listaClaves.Items.Add(clave);

            // Texto
            ListViewItem cuenta2 = new ListViewItem("Nombre Separador");
            ListViewItem clave2 = new ListViewItem("Nombre Separador");


            listaCuentas.Items.Add(cuenta2);
            listaClaves.Items.Add(clave2);

            // Separador
            ListViewItem cuenta3 = new ListViewItem("████████████████████████");
            ListViewItem clave3 = new ListViewItem("████████████████████████");


            listaCuentas.Items.Add(cuenta3);
            listaClaves.Items.Add(clave3);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarCuenta();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string info = "Al usar Ctrl + X en una cuenta se activara el pegado inteligente. Este consiste en que al presionar Ctrl + V se copiara automaticamente la clave de la cuenta que copiamos.\n" + 
                            "\n<Flecha Arriba> : Mover arriba una cuenta" + 
                            "\n<Flecha Abajo> : Mover abajo una cuenta" +
                            "\n<Suprimir> : Eliminar una cuenta";
            MessageBox.Show(info, "Instrucciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
                return;
            else if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;
            else
            {
                if (etapaPegadoInteligente == 0)
                    timerActivarSubirBajar.Enabled = false;
                e.Cancel = true;
                this.Visible = false;
            }

            
        }

        private void secretWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La palabra que aqui escribas se usara para encriptar las claves.", "Secret Word", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            PASSWORD = secretWord.Text;
        }

        private void timerEsperarCopiado_Tick(object sender, EventArgs e)
        {
            timerEsperarCopiado.Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            changelog.Visible = true;
        }

        private void timerPing_Tick(object sender, EventArgs e)
        {
            if (checkbox_usarPing.Checked)
            {
                if (!pingThread.IsBusy)
                    pingThread.RunWorkerAsync();

                string myping = ch.getPing();
                string mypacketloss = ch.getPacketLoss().ToString();

                label_connectionInfo.ForeColor = ch.getLabelColor();
                label_connectionInfo.Text = "Ping: " + myping + " ~ Packet Loss: " + mypacketloss + " %";

                trayIcon.Text = "Ping: " + myping + "  ~~  Packet Loss: " + mypacketloss + " %";

                // Reproducir sonido alarma
                if (checkbox_usarAlarma.Checked && ch.getLastPing() >= ConnectionHandler.HIGH_PING)
                {
                    try
                    {
                        SoundPlayer player = new SoundPlayer(Resources.alert);
                        player.Play();
                    }
                    catch (Exception ex) { }

                    // Mostramos el globo con la info
                    string titulo = "";
                    string info = "";

                    if (ch.getLastPing() >= ConnectionHandler.HIGH_PING && ch.getLastPacketLoss() < ConnectionHandler.HIGH_PACKET_LOSS)
                    {
                        titulo = "Ping Alto!";
                        info = myping;
                    }
                    else if (ch.getLastPing() < ConnectionHandler.HIGH_PING && ch.getLastPacketLoss() >= ConnectionHandler.HIGH_PACKET_LOSS)
                    {
                        titulo = "Packet Loss Alto!";
                        info = mypacketloss + " %";
                    }
                    else if (ch.getLastPing() >= ConnectionHandler.HIGH_PING && ch.getLastPacketLoss() >= ConnectionHandler.HIGH_PACKET_LOSS)
                    {
                        titulo = "Ping y Packet Loss Alto!!";
                        info = myping + " ~ " + mypacketloss + " %";
                    }

                    trayIcon.BalloonTipTitle = titulo;
                    trayIcon.BalloonTipIcon = ToolTipIcon.Warning;
                    trayIcon.BalloonTipText = info;
                    trayIcon.ShowBalloonTip(2000);
                }
                
            }
            else
            {
                label_connectionInfo.Text = "Ping desactivado";
                label_connectionInfo.ForeColor = Color.FromArgb(0xFF1905);
            }
        }

        private void checkbox_usarAlarma_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_usarAlarma.Checked && !yaMostroAlarmaInfo)
            {
                MessageBox.Show("La alarma solo se activa con el ping, no con el packet loss.", "ALERTA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                yaMostroAlarmaInfo = true;
            }
        }

        private void checkbox_usarPing_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbox_usarPing.Checked && !yaMostroPingInfo)
            {
                MessageBox.Show("El sistema de ping esta basado en estadistica, lo cual significa que mientras mas tiempo hayas tenido activado el ping mas acertado sera su valor, al igual que el packet loss. Mas informacion en el changelog.", "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Information);
                yaMostroPingInfo = true;
                ch.resetPingList();
            }
        }

        private void pingThread_DoWork(object sender, DoWorkEventArgs e)
        {
            ch.startPinging();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
