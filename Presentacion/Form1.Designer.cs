
namespace ProyectoPrueba.Vistas
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
            this.cmbEditar = new System.Windows.Forms.Button();
            this.cmbListar = new System.Windows.Forms.Button();
            this.cmbElimin = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmbInsert = new System.Windows.Forms.Button();
            this.grdProd = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbEditar
            // 
            this.cmbEditar.Location = new System.Drawing.Point(510, 90);
            this.cmbEditar.Name = "cmbEditar";
            this.cmbEditar.Size = new System.Drawing.Size(75, 23);
            this.cmbEditar.TabIndex = 1;
            this.cmbEditar.Text = "Actualizar";
            this.cmbEditar.UseVisualStyleBackColor = true;
            this.cmbEditar.Click += new System.EventHandler(this.cmbEditar_Click);
            // 
            // cmbListar
            // 
            this.cmbListar.Location = new System.Drawing.Point(510, 120);
            this.cmbListar.Name = "cmbListar";
            this.cmbListar.Size = new System.Drawing.Size(75, 23);
            this.cmbListar.TabIndex = 2;
            this.cmbListar.Text = "Mostrar";
            this.cmbListar.UseVisualStyleBackColor = true;
            this.cmbListar.Click += new System.EventHandler(this.cmbListar_Click);
            // 
            // cmbElimin
            // 
            this.cmbElimin.Location = new System.Drawing.Point(510, 149);
            this.cmbElimin.Name = "cmbElimin";
            this.cmbElimin.Size = new System.Drawing.Size(75, 23);
            this.cmbElimin.TabIndex = 3;
            this.cmbElimin.Text = "Eliminar";
            this.cmbElimin.UseVisualStyleBackColor = true;
            this.cmbElimin.Click += new System.EventHandler(this.cmbElimin_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(201, 67);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(220, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(201, 93);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(220, 20);
            this.txtDescrip.TabIndex = 5;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(201, 119);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(220, 20);
            this.txtPrecio.TabIndex = 6;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(201, 143);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(220, 20);
            this.txtStock.TabIndex = 7;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(201, 41);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(220, 20);
            this.txtId.TabIndex = 9;
            // 
            // cmbInsert
            // 
            this.cmbInsert.Location = new System.Drawing.Point(510, 61);
            this.cmbInsert.Name = "cmbInsert";
            this.cmbInsert.Size = new System.Drawing.Size(75, 23);
            this.cmbInsert.TabIndex = 11;
            this.cmbInsert.Text = "Insertar";
            this.cmbInsert.UseVisualStyleBackColor = true;
            this.cmbInsert.Click += new System.EventHandler(this.cmbInsert_Click);
            // 
            // grdProd
            // 
            this.grdProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProd.Location = new System.Drawing.Point(12, 208);
            this.grdProd.Name = "grdProd";
            this.grdProd.Size = new System.Drawing.Size(654, 230);
            this.grdProd.TabIndex = 12;
            this.grdProd.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdProd_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Descripcion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Stock";
            // 
            // cmbLimpiar
            // 
            this.cmbLimpiar.Location = new System.Drawing.Point(591, 61);
            this.cmbLimpiar.Name = "cmbLimpiar";
            this.cmbLimpiar.Size = new System.Drawing.Size(75, 23);
            this.cmbLimpiar.TabIndex = 18;
            this.cmbLimpiar.Text = "Limpiar";
            this.cmbLimpiar.UseVisualStyleBackColor = true;
            this.cmbLimpiar.Click += new System.EventHandler(this.cmbLimpiar_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 450);
            this.Controls.Add(this.cmbLimpiar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdProd);
            this.Controls.Add(this.cmbInsert);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescrip);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cmbElimin);
            this.Controls.Add(this.cmbListar);
            this.Controls.Add(this.cmbEditar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmbEditar;
        private System.Windows.Forms.Button cmbListar;
        private System.Windows.Forms.Button cmbElimin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button cmbInsert;
        private System.Windows.Forms.DataGridView grdProd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmbLimpiar;
    }
}
