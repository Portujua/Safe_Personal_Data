namespace Safe_Personal_Data
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreArchivoCargar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreArchivoGuardar = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.secretWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secretWord = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuentaClaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileLoader = new System.Windows.Forms.OpenFileDialog();
            this.listaCuentas = new System.Windows.Forms.ListView();
            this.column_cuenta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listaClaves = new System.Windows.Forms.ListView();
            this.column_clave = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timerActivarSubirBajar = new System.Windows.Forms.Timer(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerEsperarCopiado = new System.Windows.Forms.Timer(this.components);
            this.timerPing = new System.Windows.Forms.Timer(this.components);
            this.label_connectionInfo = new System.Windows.Forms.Label();
            this.checkbox_usarAlarma = new System.Windows.Forms.CheckBox();
            this.checkbox_usarPing = new System.Windows.Forms.CheckBox();
            this.pingThread = new System.ComponentModel.BackgroundWorker();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.nuevoToolStripMenuItem,
            this.subirToolStripMenuItem,
            this.bajarToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.cargarToolStripMenuItem,
            this.nombreArchivoCargar,
            this.toolStripSeparator1,
            this.guardarToolStripMenuItem,
            this.nombreArchivoGuardar,
            this.toolStripSeparator3,
            this.toolStripMenuItem2,
            this.toolStripSeparator4,
            this.secretWordToolStripMenuItem,
            this.secretWord,
            this.toolStripSeparator7,
            this.toolStripMenuItem3,
            this.toolStripSeparator5,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem1.Text = "Vaciar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(162, 6);
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.cargarToolStripMenuItem.Text = "Cargar";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // nombreArchivoCargar
            // 
            this.nombreArchivoCargar.Name = "nombreArchivoCargar";
            this.nombreArchivoCargar.Size = new System.Drawing.Size(100, 23);
            this.nombreArchivoCargar.Text = "pw";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // nombreArchivoGuardar
            // 
            this.nombreArchivoGuardar.Name = "nombreArchivoGuardar";
            this.nombreArchivoGuardar.Size = new System.Drawing.Size(100, 23);
            this.nombreArchivoGuardar.Text = "pw";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(162, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem2.Text = "Instrucciones";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(162, 6);
            // 
            // secretWordToolStripMenuItem
            // 
            this.secretWordToolStripMenuItem.Name = "secretWordToolStripMenuItem";
            this.secretWordToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.secretWordToolStripMenuItem.Text = "Secret Word";
            this.secretWordToolStripMenuItem.Click += new System.EventHandler(this.secretWordToolStripMenuItem_Click);
            // 
            // secretWord
            // 
            this.secretWord.Name = "secretWord";
            this.secretWord.Size = new System.Drawing.Size(100, 23);
            this.secretWord.Text = "osszoi";
            this.secretWord.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(162, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(165, 22);
            this.toolStripMenuItem3.Text = "Changelog";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cuentaClaveToolStripMenuItem,
            this.separadorToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // cuentaClaveToolStripMenuItem
            // 
            this.cuentaClaveToolStripMenuItem.Name = "cuentaClaveToolStripMenuItem";
            this.cuentaClaveToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.cuentaClaveToolStripMenuItem.Text = "Cuenta/Clave";
            this.cuentaClaveToolStripMenuItem.Click += new System.EventHandler(this.cuentaClaveToolStripMenuItem_Click);
            // 
            // separadorToolStripMenuItem
            // 
            this.separadorToolStripMenuItem.Name = "separadorToolStripMenuItem";
            this.separadorToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.separadorToolStripMenuItem.Text = "Separador";
            this.separadorToolStripMenuItem.Click += new System.EventHandler(this.separadorToolStripMenuItem_Click);
            // 
            // subirToolStripMenuItem
            // 
            this.subirToolStripMenuItem.Name = "subirToolStripMenuItem";
            this.subirToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.subirToolStripMenuItem.Text = "↑ Subir ↑";
            this.subirToolStripMenuItem.Click += new System.EventHandler(this.subirToolStripMenuItem_Click);
            // 
            // bajarToolStripMenuItem
            // 
            this.bajarToolStripMenuItem.Name = "bajarToolStripMenuItem";
            this.bajarToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.bajarToolStripMenuItem.Text = "↓ Bajar ↓";
            this.bajarToolStripMenuItem.Click += new System.EventHandler(this.bajarToolStripMenuItem_Click);
            // 
            // fileLoader
            // 
            this.fileLoader.FileName = "fileLoader";
            // 
            // listaCuentas
            // 
            this.listaCuentas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_cuenta});
            this.listaCuentas.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaCuentas.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listaCuentas.LabelEdit = true;
            this.listaCuentas.Location = new System.Drawing.Point(14, 52);
            this.listaCuentas.MultiSelect = false;
            this.listaCuentas.Name = "listaCuentas";
            this.listaCuentas.Size = new System.Drawing.Size(204, 352);
            this.listaCuentas.TabIndex = 1;
            this.listaCuentas.UseCompatibleStateImageBehavior = false;
            this.listaCuentas.View = System.Windows.Forms.View.Details;
            this.listaCuentas.DoubleClick += new System.EventHandler(this.listaCuentas_DoubleClick);
            this.listaCuentas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaCuentas_KeyDown);
            this.listaCuentas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listaCuentas_KeyPress);
            // 
            // column_cuenta
            // 
            this.column_cuenta.Text = "Cuenta";
            this.column_cuenta.Width = 180;
            // 
            // listaClaves
            // 
            this.listaClaves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_clave});
            this.listaClaves.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaClaves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listaClaves.LabelEdit = true;
            this.listaClaves.Location = new System.Drawing.Point(224, 52);
            this.listaClaves.MultiSelect = false;
            this.listaClaves.Name = "listaClaves";
            this.listaClaves.Size = new System.Drawing.Size(206, 352);
            this.listaClaves.TabIndex = 2;
            this.listaClaves.UseCompatibleStateImageBehavior = false;
            this.listaClaves.View = System.Windows.Forms.View.Details;
            this.listaClaves.DoubleClick += new System.EventHandler(this.listaClaves_DoubleClick);
            this.listaClaves.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listaClaves_KeyDown);
            this.listaClaves.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listaClaves_KeyPress);
            // 
            // column_clave
            // 
            this.column_clave.Text = "Clave";
            this.column_clave.Width = 181;
            // 
            // timerActivarSubirBajar
            // 
            this.timerActivarSubirBajar.Enabled = true;
            this.timerActivarSubirBajar.Interval = 50;
            this.timerActivarSubirBajar.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Safe Personal Accounts";
            this.trayIcon.Visible = true;
            // 
            // timerEsperarCopiado
            // 
            this.timerEsperarCopiado.Interval = 1000;
            this.timerEsperarCopiado.Tick += new System.EventHandler(this.timerEsperarCopiado_Tick);
            // 
            // timerPing
            // 
            this.timerPing.Enabled = true;
            this.timerPing.Interval = 3000;
            this.timerPing.Tick += new System.EventHandler(this.timerPing_Tick);
            // 
            // label_connectionInfo
            // 
            this.label_connectionInfo.AutoSize = true;
            this.label_connectionInfo.Location = new System.Drawing.Point(30, 27);
            this.label_connectionInfo.Name = "label_connectionInfo";
            this.label_connectionInfo.Size = new System.Drawing.Size(119, 15);
            this.label_connectionInfo.TabIndex = 3;
            this.label_connectionInfo.Text = "Iniciando ping..";
            // 
            // checkbox_usarAlarma
            // 
            this.checkbox_usarAlarma.AutoSize = true;
            this.checkbox_usarAlarma.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_usarAlarma.Location = new System.Drawing.Point(338, 28);
            this.checkbox_usarAlarma.Name = "checkbox_usarAlarma";
            this.checkbox_usarAlarma.Size = new System.Drawing.Size(92, 17);
            this.checkbox_usarAlarma.TabIndex = 5;
            this.checkbox_usarAlarma.Text = "Usar Alarma";
            this.checkbox_usarAlarma.UseVisualStyleBackColor = true;
            this.checkbox_usarAlarma.CheckedChanged += new System.EventHandler(this.checkbox_usarAlarma_CheckedChanged);
            // 
            // checkbox_usarPing
            // 
            this.checkbox_usarPing.AutoSize = true;
            this.checkbox_usarPing.Location = new System.Drawing.Point(14, 27);
            this.checkbox_usarPing.Name = "checkbox_usarPing";
            this.checkbox_usarPing.Size = new System.Drawing.Size(15, 14);
            this.checkbox_usarPing.TabIndex = 6;
            this.checkbox_usarPing.UseVisualStyleBackColor = true;
            this.checkbox_usarPing.CheckedChanged += new System.EventHandler(this.checkbox_usarPing_CheckedChanged);
            // 
            // pingThread
            // 
            this.pingThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pingThread_DoWork);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(162, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 421);
            this.Controls.Add(this.checkbox_usarPing);
            this.Controls.Add(this.checkbox_usarAlarma);
            this.Controls.Add(this.label_connectionInfo);
            this.Controls.Add(this.listaClaves);
            this.Controls.Add(this.listaCuentas);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Safe Personal Accounts 1.7";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuentaClaveToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog fileLoader;
        private System.Windows.Forms.ListView listaCuentas;
        private System.Windows.Forms.ColumnHeader column_cuenta;
        private System.Windows.Forms.ListView listaClaves;
        private System.Windows.Forms.ColumnHeader column_clave;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.Timer timerActivarSubirBajar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox nombreArchivoCargar;
        private System.Windows.Forms.ToolStripTextBox nombreArchivoGuardar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem subirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem separadorToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem secretWordToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox secretWord;
        private System.Windows.Forms.Timer timerEsperarCopiado;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Timer timerPing;
        private System.Windows.Forms.Label label_connectionInfo;
        private System.Windows.Forms.CheckBox checkbox_usarAlarma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.CheckBox checkbox_usarPing;
        private System.ComponentModel.BackgroundWorker pingThread;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
    }
}

