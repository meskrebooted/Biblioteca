namespace Biblioteca
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutControls = new System.Windows.Forms.TableLayoutPanel();
            this.groupActions = new System.Windows.Forms.GroupBox();
            this.btnVelocitaVeloce = new System.Windows.Forms.Button();
            this.btnVelocitaMedia = new System.Windows.Forms.Button();
            this.btnVelocitaLenta = new System.Windows.Forms.Button();
            this.lblVelocita = new System.Windows.Forms.Label();
            this.lblSimulationStatus = new System.Windows.Forms.Label();
            this.btnToggleSimulation = new System.Windows.Forms.Button();
            this.btnAddRequest = new System.Windows.Forms.Button();
            this.groupQueue = new System.Windows.Forms.GroupBox();
            this.listQueue = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBook = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSource = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupCatalog = new System.Windows.Forms.GroupBox();
            this.panelBooks = new System.Windows.Forms.FlowLayoutPanel();
            this.groupLog = new System.Windows.Forms.GroupBox();
            this.listLog = new System.Windows.Forms.ListBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblQueueCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProcessedCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutMain.SuspendLayout();
            this.tableLayoutControls.SuspendLayout();
            this.groupActions.SuspendLayout();
            this.groupQueue.SuspendLayout();
            this.groupCatalog.SuspendLayout();
            this.groupLog.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutMain
            // 
            this.tableLayoutMain.ColumnCount = 2;
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutMain.Controls.Add(this.tableLayoutControls, 0, 0);
            this.tableLayoutMain.Controls.Add(this.groupQueue, 0, 1);
            this.tableLayoutMain.Controls.Add(this.groupCatalog, 1, 1);
            this.tableLayoutMain.Controls.Add(this.groupLog, 0, 2);
            this.tableLayoutMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutMain.Name = "tableLayoutMain";
            this.tableLayoutMain.RowCount = 3;
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 113F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutMain.Size = new System.Drawing.Size(1010, 689);
            this.tableLayoutMain.TabIndex = 0;
            // 
            // tableLayoutControls
            // 
            this.tableLayoutControls.ColumnCount = 1;
            this.tableLayoutMain.SetColumnSpan(this.tableLayoutControls, 2);
            this.tableLayoutControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutControls.Controls.Add(this.groupActions, 0, 0);
            this.tableLayoutControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutControls.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutControls.Name = "tableLayoutControls";
            this.tableLayoutControls.RowCount = 1;
            this.tableLayoutControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutControls.Size = new System.Drawing.Size(1004, 107);
            this.tableLayoutControls.TabIndex = 0;
            // 
            // groupActions
            // 
            this.groupActions.Controls.Add(this.btnVelocitaVeloce);
            this.groupActions.Controls.Add(this.btnVelocitaMedia);
            this.groupActions.Controls.Add(this.btnVelocitaLenta);
            this.groupActions.Controls.Add(this.lblVelocita);
            this.groupActions.Controls.Add(this.lblSimulationStatus);
            this.groupActions.Controls.Add(this.btnToggleSimulation);
            this.groupActions.Controls.Add(this.btnAddRequest);
            this.groupActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupActions.Location = new System.Drawing.Point(3, 3);
            this.groupActions.Name = "groupActions";
            this.groupActions.BackColor = System.Drawing.Color.White;
            this.groupActions.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.groupActions.Size = new System.Drawing.Size(998, 101);
            this.groupActions.TabIndex = 0;
            this.groupActions.TabStop = false;
            this.groupActions.Text = "Simulazione";
            // 
            // lblVelocita
            // 
            this.lblVelocita.AutoSize = true;
            this.lblVelocita.Location = new System.Drawing.Point(260, 32);
            this.lblVelocita.Name = "lblVelocita";
            this.lblVelocita.Size = new System.Drawing.Size(52, 13);
            this.lblVelocita.TabIndex = 3;
            this.lblVelocita.Text = "Velocità:";
            // 
            // lblSimulationStatus
            // 
            this.lblSimulationStatus.AutoSize = true;
            this.lblSimulationStatus.Location = new System.Drawing.Point(197, 32);
            this.lblSimulationStatus.Name = "lblSimulationStatus";
            this.lblSimulationStatus.Size = new System.Drawing.Size(64, 13);
            this.lblSimulationStatus.TabIndex = 2;
            this.lblSimulationStatus.Text = "Stato: ferma";
            // 
            // btnToggleSimulation
            // 
            this.btnToggleSimulation.Location = new System.Drawing.Point(14, 26);
            this.btnToggleSimulation.Name = "btnToggleSimulation";
            this.btnToggleSimulation.Size = new System.Drawing.Size(163, 26);
            this.btnToggleSimulation.TabIndex = 0;
            this.btnToggleSimulation.Text = "Avvia simulazione";
            this.btnToggleSimulation.BackColor = System.Drawing.Color.FromArgb(70, 130, 180);
            this.btnToggleSimulation.FlatAppearance.BorderSize = 0;
            this.btnToggleSimulation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleSimulation.ForeColor = System.Drawing.Color.White;
            this.btnToggleSimulation.UseVisualStyleBackColor = false;
            this.btnToggleSimulation.Click += new System.EventHandler(this.btnToggleSimulation_Click);
            // 
            // btnAddRequest
            // 
            this.btnAddRequest.Location = new System.Drawing.Point(14, 61);
            this.btnAddRequest.Name = "btnAddRequest";
            this.btnAddRequest.Size = new System.Drawing.Size(163, 26);
            this.btnAddRequest.TabIndex = 1;
            this.btnAddRequest.Text = "Aggiungi richiesta";
            this.btnAddRequest.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAddRequest.FlatAppearance.BorderSize = 0;
            this.btnAddRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRequest.ForeColor = System.Drawing.Color.White;
            this.btnAddRequest.UseVisualStyleBackColor = false;
            this.btnAddRequest.Click += new System.EventHandler(this.btnAddRequest_Click);
            // 
            // btnVelocitaLenta
            // 
            this.btnVelocitaLenta.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnVelocitaLenta.FlatAppearance.BorderSize = 0;
            this.btnVelocitaLenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVelocitaLenta.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnVelocitaLenta.Location = new System.Drawing.Point(330, 26);
            this.btnVelocitaLenta.Name = "btnVelocitaLenta";
            this.btnVelocitaLenta.Size = new System.Drawing.Size(80, 26);
            this.btnVelocitaLenta.TabIndex = 4;
            this.btnVelocitaLenta.Text = "Lenta";
            this.btnVelocitaLenta.UseVisualStyleBackColor = false;
            this.btnVelocitaLenta.Click += new System.EventHandler(this.btnVelocitaLenta_Click);
            // 
            // btnVelocitaMedia
            // 
            this.btnVelocitaMedia.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnVelocitaMedia.FlatAppearance.BorderSize = 0;
            this.btnVelocitaMedia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVelocitaMedia.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnVelocitaMedia.Location = new System.Drawing.Point(420, 26);
            this.btnVelocitaMedia.Name = "btnVelocitaMedia";
            this.btnVelocitaMedia.Size = new System.Drawing.Size(80, 26);
            this.btnVelocitaMedia.TabIndex = 5;
            this.btnVelocitaMedia.Text = "Media";
            this.btnVelocitaMedia.UseVisualStyleBackColor = false;
            this.btnVelocitaMedia.Click += new System.EventHandler(this.btnVelocitaMedia_Click);
            // 
            // btnVelocitaVeloce
            // 
            this.btnVelocitaVeloce.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.btnVelocitaVeloce.FlatAppearance.BorderSize = 0;
            this.btnVelocitaVeloce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVelocitaVeloce.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.btnVelocitaVeloce.Location = new System.Drawing.Point(510, 26);
            this.btnVelocitaVeloce.Name = "btnVelocitaVeloce";
            this.btnVelocitaVeloce.Size = new System.Drawing.Size(80, 26);
            this.btnVelocitaVeloce.TabIndex = 6;
            this.btnVelocitaVeloce.Text = "Veloce";
            this.btnVelocitaVeloce.UseVisualStyleBackColor = false;
            this.btnVelocitaVeloce.Click += new System.EventHandler(this.btnVelocitaVeloce_Click);
            // 
            // groupQueue
            // 
            this.groupQueue.Controls.Add(this.listQueue);
            this.groupQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupQueue.Location = new System.Drawing.Point(3, 116);
            this.groupQueue.Name = "groupQueue";
            this.groupQueue.BackColor = System.Drawing.Color.White;
            this.groupQueue.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.groupQueue.Size = new System.Drawing.Size(499, 368);
            this.groupQueue.TabIndex = 1;
            this.groupQueue.TabStop = false;
            this.groupQueue.Text = "Coda richieste";
            // 
            // listQueue
            // 
            this.listQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colUser,
            this.colBook,
            this.colTime,
            this.colSource});
            this.listQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listQueue.FullRowSelect = true;
            this.listQueue.GridLines = true;
            this.listQueue.HideSelection = false;
            this.listQueue.Location = new System.Drawing.Point(3, 16);
            this.listQueue.Name = "listQueue";
            this.listQueue.BackColor = System.Drawing.Color.White;
            this.listQueue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listQueue.Size = new System.Drawing.Size(493, 349);
            this.listQueue.TabIndex = 0;
            this.listQueue.UseCompatibleStateImageBehavior = false;
            this.listQueue.View = System.Windows.Forms.View.Details;
            // 
            // colId
            // 
            this.colId.Text = "ID";
            this.colId.Width = 50;
            // 
            // colUser
            // 
            this.colUser.Text = "Utente";
            this.colUser.Width = 120;
            // 
            // colBook
            // 
            this.colBook.Text = "Libro";
            this.colBook.Width = 180;
            // 
            // colTime
            // 
            this.colTime.Text = "Ora";
            this.colTime.Width = 80;
            // 
            // colSource
            // 
            this.colSource.Text = "Fonte";
            // 
            // groupCatalog
            // 
            this.groupCatalog.Controls.Add(this.panelBooks);
            this.groupCatalog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCatalog.Location = new System.Drawing.Point(508, 116);
            this.groupCatalog.Name = "groupCatalog";
            this.groupCatalog.BackColor = System.Drawing.Color.White;
            this.groupCatalog.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.groupCatalog.Size = new System.Drawing.Size(499, 368);
            this.groupCatalog.TabIndex = 2;
            this.groupCatalog.TabStop = false;
            this.groupCatalog.Text = "Libri disponibili";
            // 
            // panelBooks
            // 
            this.panelBooks.BackColor = System.Drawing.Color.FromArgb(250, 250, 252);
            this.panelBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBooks.Location = new System.Drawing.Point(3, 16);
            this.panelBooks.Name = "panelBooks";
            this.panelBooks.Size = new System.Drawing.Size(493, 349);
            this.panelBooks.TabIndex = 0;
            // 
            // groupLog
            // 
            this.tableLayoutMain.SetColumnSpan(this.groupLog, 2);
            this.groupLog.Controls.Add(this.listLog);
            this.groupLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupLog.Location = new System.Drawing.Point(3, 490);
            this.groupLog.Name = "groupLog";
            this.groupLog.BackColor = System.Drawing.Color.White;
            this.groupLog.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.groupLog.Size = new System.Drawing.Size(1004, 196);
            this.groupLog.TabIndex = 3;
            this.groupLog.TabStop = false;
            this.groupLog.Text = "Log lavorazioni";
            // 
            // listLog
            // 
            this.listLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listLog.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.listLog.FormattingEnabled = true;
            this.listLog.Location = new System.Drawing.Point(3, 16);
            this.listLog.Name = "listLog";
            this.listLog.BackColor = System.Drawing.Color.White;
            this.listLog.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.listLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listLog.Size = new System.Drawing.Size(998, 177);
            this.listLog.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblQueueCount,
            this.lblProcessedCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 689);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.statusStrip.Size = new System.Drawing.Size(1010, 22);
            this.statusStrip.TabIndex = 1;
            // 
            // lblQueueCount
            // 
            this.lblQueueCount.Name = "lblQueueCount";
            this.lblQueueCount.Size = new System.Drawing.Size(58, 17);
            this.lblQueueCount.Text = "In coda: 0";
            // 
            // lblProcessedCount
            // 
            this.lblProcessedCount.Margin = new System.Windows.Forms.Padding(20, 3, 0, 2);
            this.lblProcessedCount.Name = "lblProcessedCount";
            this.lblProcessedCount.Size = new System.Drawing.Size(68, 17);
            this.lblProcessedCount.Text = "Elaborate: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1010, 711);
            this.Controls.Add(this.tableLayoutMain);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(945, 681);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca - Gestione Prestiti";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutMain.ResumeLayout(false);
            this.tableLayoutControls.ResumeLayout(false);
            this.groupActions.ResumeLayout(false);
            this.groupActions.PerformLayout();
            this.groupQueue.ResumeLayout(false);
            this.groupCatalog.ResumeLayout(false);
            this.groupLog.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutControls;
        private System.Windows.Forms.GroupBox groupActions;
        private System.Windows.Forms.Button btnToggleSimulation;
        private System.Windows.Forms.Button btnAddRequest;
        private System.Windows.Forms.Label lblVelocita;
        private System.Windows.Forms.Button btnVelocitaLenta;
        private System.Windows.Forms.Button btnVelocitaMedia;
        private System.Windows.Forms.Button btnVelocitaVeloce;
        private System.Windows.Forms.Label lblSimulationStatus;
        private System.Windows.Forms.GroupBox groupQueue;
        private System.Windows.Forms.ListView listQueue;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colUser;
        private System.Windows.Forms.ColumnHeader colBook;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colSource;
        private System.Windows.Forms.GroupBox groupCatalog;
        private System.Windows.Forms.FlowLayoutPanel panelBooks;
        private System.Windows.Forms.GroupBox groupLog;
        private System.Windows.Forms.ListBox listLog;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblQueueCount;
        private System.Windows.Forms.ToolStripStatusLabel lblProcessedCount;
    }
}
