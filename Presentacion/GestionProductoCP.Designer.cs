
namespace ProyectoPrueba.Vistas
{
    partial class GestionProductoCP
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
            this.cmbEditar = new System.Windows.Forms.Button();
            this.cmbListar = new System.Windows.Forms.Button();
            this.cmbElimin = new System.Windows.Forms.Button();
            this.txcNomPro = new System.Windows.Forms.TextBox();
            this.txcDesPro = new System.Windows.Forms.TextBox();
            this.txnPrePro = new System.Windows.Forms.TextBox();
            this.txnStoPro = new System.Windows.Forms.TextBox();
            this.txnIdePro = new System.Windows.Forms.TextBox();
            this.cmbInsert = new System.Windows.Forms.Button();
            this.grdProd = new System.Windows.Forms.DataGridView();
            this.lblIdePro = new System.Windows.Forms.Label();
            this.lblNomPro = new System.Windows.Forms.Label();
            this.lblDesPro = new System.Windows.Forms.Label();
            this.lblPrePro = new System.Windows.Forms.Label();
            this.lblStoPro = new System.Windows.Forms.Label();
            this.cmbLimpiar = new System.Windows.Forms.Button();
            this.lblIdeSed = new System.Windows.Forms.Label();
            this.txnIdeSed = new System.Windows.Forms.TextBox();
            this.txnColIdePro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnColNomPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txcColDesPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnColPrePro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tnColStoPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtColFecPro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txnColIdeSed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEditar
            // 
            this.cmbEditar.Location = new System.Drawing.Point(542, 88);
            this.cmbEditar.Name = "cmbEditar";
            this.cmbEditar.Size = new System.Drawing.Size(75, 23);
            this.cmbEditar.TabIndex = 1;
            this.cmbEditar.Text = "Actualizar";
            this.cmbEditar.UseVisualStyleBackColor = true;
            this.cmbEditar.Click += new System.EventHandler(this.cmbEditar_Click);
            // 
            // cmbListar
            // 
            this.cmbListar.Location = new System.Drawing.Point(633, 88);
            this.cmbListar.Name = "cmbListar";
            this.cmbListar.Size = new System.Drawing.Size(75, 23);
            this.cmbListar.TabIndex = 2;
            this.cmbListar.Text = "Mostrar";
            this.cmbListar.UseVisualStyleBackColor = true;
            this.cmbListar.Click += new System.EventHandler(this.cmbListar_Click);
            // 
            // cmbElimin
            // 
            this.cmbElimin.Location = new System.Drawing.Point(542, 141);
            this.cmbElimin.Name = "cmbElimin";
            this.cmbElimin.Size = new System.Drawing.Size(75, 23);
            this.cmbElimin.TabIndex = 3;
            this.cmbElimin.Text = "Eliminar";
            this.cmbElimin.UseVisualStyleBackColor = true;
            this.cmbElimin.Click += new System.EventHandler(this.cmbElimin_Click);
            // 
            // txcNomPro
            // 
            this.txcNomPro.Location = new System.Drawing.Point(201, 67);
            this.txcNomPro.Name = "txcNomPro";
            this.txcNomPro.Size = new System.Drawing.Size(288, 20);
            this.txcNomPro.TabIndex = 4;
            // 
            // txcDesPro
            // 
            this.txcDesPro.Location = new System.Drawing.Point(201, 93);
            this.txcDesPro.Name = "txcDesPro";
            this.txcDesPro.Size = new System.Drawing.Size(288, 20);
            this.txcDesPro.TabIndex = 5;
            // 
            // txnPrePro
            // 
            this.txnPrePro.Location = new System.Drawing.Point(201, 119);
            this.txnPrePro.Name = "txnPrePro";
            this.txnPrePro.Size = new System.Drawing.Size(288, 20);
            this.txnPrePro.TabIndex = 6;
            // 
            // txnStoPro
            // 
            this.txnStoPro.Location = new System.Drawing.Point(201, 143);
            this.txnStoPro.Name = "txnStoPro";
            this.txnStoPro.Size = new System.Drawing.Size(288, 20);
            this.txnStoPro.TabIndex = 7;
            // 
            // txnIdePro
            // 
            this.txnIdePro.Enabled = false;
            this.txnIdePro.Location = new System.Drawing.Point(201, 41);
            this.txnIdePro.Name = "txnIdePro";
            this.txnIdePro.Size = new System.Drawing.Size(288, 20);
            this.txnIdePro.TabIndex = 9;
            // 
            // cmbInsert
            // 
            this.cmbInsert.Location = new System.Drawing.Point(542, 36);
            this.cmbInsert.Name = "cmbInsert";
            this.cmbInsert.Size = new System.Drawing.Size(75, 23);
            this.cmbInsert.TabIndex = 11;
            this.cmbInsert.Text = "Insertar";
            this.cmbInsert.UseVisualStyleBackColor = true;
            this.cmbInsert.Click += new System.EventHandler(this.cmbInsert_Click);
            // 
            // grdProd
            // 
            this.grdProd.AllowUserToOrderColumns = true;
            this.grdProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txnColIdePro,
            this.txnColNomPro,
            this.txcColDesPro,
            this.txnColPrePro,
            this.tnColStoPro,
            this.txtColFecPro,
            this.txnColIdeSed});
            this.grdProd.Location = new System.Drawing.Point(12, 208);
            this.grdProd.Name = "grdProd";
            this.grdProd.RowHeadersWidth = 51;
            this.grdProd.Size = new System.Drawing.Size(754, 230);
            this.grdProd.TabIndex = 12;
            this.grdProd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProd_CellContentClick);
            // 
            // lblIdePro
            // 
            this.lblIdePro.AutoSize = true;
            this.lblIdePro.Location = new System.Drawing.Point(160, 44);
            this.lblIdePro.Name = "lblIdePro";
            this.lblIdePro.Size = new System.Drawing.Size(16, 13);
            this.lblIdePro.TabIndex = 13;
            this.lblIdePro.Text = "Id";
            // 
            // lblNomPro
            // 
            this.lblNomPro.AutoSize = true;
            this.lblNomPro.Location = new System.Drawing.Point(140, 73);
            this.lblNomPro.Name = "lblNomPro";
            this.lblNomPro.Size = new System.Drawing.Size(44, 13);
            this.lblNomPro.TabIndex = 14;
            this.lblNomPro.Text = "Nombre";
            // 
            // lblDesPro
            // 
            this.lblDesPro.AutoSize = true;
            this.lblDesPro.Location = new System.Drawing.Point(121, 100);
            this.lblDesPro.Name = "lblDesPro";
            this.lblDesPro.Size = new System.Drawing.Size(63, 13);
            this.lblDesPro.TabIndex = 15;
            this.lblDesPro.Text = "Descripcion";
            // 
            // lblPrePro
            // 
            this.lblPrePro.AutoSize = true;
            this.lblPrePro.Location = new System.Drawing.Point(138, 122);
            this.lblPrePro.Name = "lblPrePro";
            this.lblPrePro.Size = new System.Drawing.Size(37, 13);
            this.lblPrePro.TabIndex = 16;
            this.lblPrePro.Text = "Precio";
            // 
            // lblStoPro
            // 
            this.lblStoPro.AutoSize = true;
            this.lblStoPro.Location = new System.Drawing.Point(138, 146);
            this.lblStoPro.Name = "lblStoPro";
            this.lblStoPro.Size = new System.Drawing.Size(35, 13);
            this.lblStoPro.TabIndex = 17;
            this.lblStoPro.Text = "Stock";
            // 
            // cmbLimpiar
            // 
            this.cmbLimpiar.Location = new System.Drawing.Point(633, 34);
            this.cmbLimpiar.Name = "cmbLimpiar";
            this.cmbLimpiar.Size = new System.Drawing.Size(75, 23);
            this.cmbLimpiar.TabIndex = 18;
            this.cmbLimpiar.Text = "Limpiar";
            this.cmbLimpiar.UseVisualStyleBackColor = true;
            this.cmbLimpiar.Click += new System.EventHandler(this.cmbLimpiar_Click);
            // 
            // lblIdeSed
            // 
            this.lblIdeSed.AutoSize = true;
            this.lblIdeSed.Location = new System.Drawing.Point(138, 174);
            this.lblIdeSed.Name = "lblIdeSed";
            this.lblIdeSed.Size = new System.Drawing.Size(46, 13);
            this.lblIdeSed.TabIndex = 20;
            this.lblIdeSed.Text = "ID Sede";
            // 
            // txnIdeSed
            // 
            this.txnIdeSed.Location = new System.Drawing.Point(201, 171);
            this.txnIdeSed.Name = "txnIdeSed";
            this.txnIdeSed.Size = new System.Drawing.Size(288, 20);
            this.txnIdeSed.TabIndex = 19;
            // 
            // txnColIdePro
            // 
            this.txnColIdePro.DataPropertyName = "pnIdePro";
            this.txnColIdePro.HeaderText = "Id";
            this.txnColIdePro.Name = "txnColIdePro";
            // 
            // txnColNomPro
            // 
            this.txnColNomPro.DataPropertyName = "pcNomPro";
            this.txnColNomPro.HeaderText = "Nombre";
            this.txnColNomPro.Name = "txnColNomPro";
            // 
            // txcColDesPro
            // 
            this.txcColDesPro.DataPropertyName = "pcDesPro";
            this.txcColDesPro.HeaderText = "Descripcion";
            this.txcColDesPro.Name = "txcColDesPro";
            // 
            // txnColPrePro
            // 
            this.txnColPrePro.DataPropertyName = "pnPrePro";
            this.txnColPrePro.HeaderText = "Precio";
            this.txnColPrePro.Name = "txnColPrePro";
            // 
            // tnColStoPro
            // 
            this.tnColStoPro.DataPropertyName = "pnStoPro";
            this.tnColStoPro.HeaderText = "Stock";
            this.tnColStoPro.Name = "tnColStoPro";
            // 
            // txtColFecPro
            // 
            this.txtColFecPro.DataPropertyName = "ptFecPro";
            this.txtColFecPro.HeaderText = "Fecha";
            this.txtColFecPro.Name = "txtColFecPro";
            // 
            // txnColIdeSed
            // 
            this.txnColIdeSed.DataPropertyName = "pnIdeSed";
            this.txnColIdeSed.HeaderText = "ID Sede";
            this.txnColIdeSed.Name = "txnColIdeSed";
            // 
            // GestionProductoCP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 450);
            this.Controls.Add(this.lblIdeSed);
            this.Controls.Add(this.txnIdeSed);
            this.Controls.Add(this.cmbLimpiar);
            this.Controls.Add(this.lblStoPro);
            this.Controls.Add(this.lblPrePro);
            this.Controls.Add(this.lblDesPro);
            this.Controls.Add(this.lblNomPro);
            this.Controls.Add(this.lblIdePro);
            this.Controls.Add(this.grdProd);
            this.Controls.Add(this.cmbInsert);
            this.Controls.Add(this.txnIdePro);
            this.Controls.Add(this.txnStoPro);
            this.Controls.Add(this.txnPrePro);
            this.Controls.Add(this.txcDesPro);
            this.Controls.Add(this.txcNomPro);
            this.Controls.Add(this.cmbElimin);
            this.Controls.Add(this.cmbListar);
            this.Controls.Add(this.cmbEditar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GestionProductoCP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión de Productos - invmpro";
            this.Load += new System.EventHandler(this.GestionProductoCP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmbEditar;
        private System.Windows.Forms.Button cmbListar;
        private System.Windows.Forms.Button cmbElimin;
        private System.Windows.Forms.TextBox txcNomPro;
        private System.Windows.Forms.TextBox txcDesPro;
        private System.Windows.Forms.TextBox txnPrePro;
        private System.Windows.Forms.TextBox txnStoPro;
        private System.Windows.Forms.TextBox txnIdePro;
        private System.Windows.Forms.Button cmbInsert;
        private System.Windows.Forms.DataGridView grdProd;
        private System.Windows.Forms.Label lblIdePro;
        private System.Windows.Forms.Label lblNomPro;
        private System.Windows.Forms.Label lblDesPro;
        private System.Windows.Forms.Label lblPrePro;
        private System.Windows.Forms.Label lblStoPro;
        private System.Windows.Forms.Button cmbLimpiar;
        private System.Windows.Forms.Label lblIdeSed;
        private System.Windows.Forms.TextBox txnIdeSed;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColIdePro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColNomPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txcColDesPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColPrePro;
        private System.Windows.Forms.DataGridViewTextBoxColumn tnColStoPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtColFecPro;
        private System.Windows.Forms.DataGridViewTextBoxColumn txnColIdeSed;
    }
}