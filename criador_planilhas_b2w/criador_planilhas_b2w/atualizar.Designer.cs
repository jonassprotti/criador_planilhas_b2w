namespace criador_planilhas_b2w
{
    partial class atualizar
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
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_extorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.marca,
            this.data_pedido,
            this.data_extorno,
            this.nf,
            this.cliente,
            this.produto,
            this.ref_pedido,
            this.entrega,
            this.tipo,
            this.valor});
            this.dgvDados.Location = new System.Drawing.Point(12, 56);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.Size = new System.Drawing.Size(1077, 382);
            this.dgvDados.TabIndex = 0;
//            this.dgvDados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDados_CellContentClick);
            this.dgvDados.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvDados_MouseDoubleClick);
            // 
            // marca
            // 
            this.marca.HeaderText = "Marca";
            this.marca.Name = "marca";
            // 
            // data_pedido
            // 
            this.data_pedido.HeaderText = "Data de pedido";
            this.data_pedido.Name = "data_pedido";
            // 
            // data_extorno
            // 
            this.data_extorno.HeaderText = "Data de Estorno";
            this.data_extorno.Name = "data_extorno";
            // 
            // nf
            // 
            this.nf.HeaderText = "Nota Fiscal";
            this.nf.Name = "nf";
            // 
            // cliente
            // 
            this.cliente.HeaderText = "Cliente";
            this.cliente.Name = "cliente";
            // 
            // produto
            // 
            this.produto.HeaderText = "Produto";
            this.produto.Name = "produto";
            // 
            // ref_pedido
            // 
            this.ref_pedido.HeaderText = "Ref. Pedido";
            this.ref_pedido.Name = "ref_pedido";
            // 
            // entrega
            // 
            this.entrega.HeaderText = "Entrega";
            this.entrega.Name = "entrega";
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            // 
            // atualizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 451);
            this.Controls.Add(this.dgvDados);
            this.Name = "atualizar";
            this.Text = "atualizar";
            this.Load += new System.EventHandler(this.atualizar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.DataGridViewTextBoxColumn marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn data_extorno;
        private System.Windows.Forms.DataGridViewTextBoxColumn nf;
        private System.Windows.Forms.DataGridViewTextBoxColumn cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
    }
}