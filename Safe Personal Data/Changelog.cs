using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Safe_Personal_Data
{
    public partial class Changelog : Form
    {
        public Changelog()
        {
            InitializeComponent();
        }

        private void Changelog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
        }

        private void Changelog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.WindowsShutDown)
                return;
            else if (e.CloseReason == CloseReason.ApplicationExitCall)
                return;
            else
            {
                e.Cancel = true;
                this.Visible = false;
            }
        }

        private void label_pingExplicacion_Click(object sender, EventArgs e)
        {
            string info = "                            ~ Sistema de Ping basado en Estadisticas ~ \n\n"
                + "Un sistema de Ping basado en estadistica tiene la siguiente estructura \"pingActual ± promedio\", esto significa que el valor que se muestra de primero es el resultado del ultimo ping hecho, en pocas palabras nuestro ping actual; y el segundo valor es cuanto varia nuestro ping en un periodo de tiempo. \n\n"
                + "- Tengo 100 ± 200 pero no tengo lag, ¿como es eso?\n"
                + "Ese 200 no significa que tengas lag, significa que en los ultimos 100 ping hechos llegaste a tener un maximo de 300 de ping.\n\n"
                + "- ¿Que significa ±?\n"
                + "Significa que tu ping varia entre pingActual + promedio, o, pingActual - promedio\n\n"
                + "- Entonces si tengo 100 ± 200, ¿significa que llegue a tener -100 de ping?\n"
                + "No, el segundo valor es la suma del ping minimo y el ping maximo dividido entre 2. Lo cual significa que si tu ping actual es 100, el ping minimo de promedio es 90 y el ping maximo de promedio es 310 entonces 90+310 = 400 ~ 400/2 = 200 (recuerda, son valores estadisticos)";

            MessageBox.Show(info, "Informacion", MessageBoxButtons.OK);
        }
    }
}
