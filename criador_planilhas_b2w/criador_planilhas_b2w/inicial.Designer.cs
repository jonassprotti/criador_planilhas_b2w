namespace criador_planilhas_b2w
{
    partial class inicial
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
            this.btnSel = new System.Windows.Forms.Button();
            this.opDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnSel
            // 
            this.btnSel.Location = new System.Drawing.Point(124, 63);
            this.btnSel.Name = "btnSel";
            this.btnSel.Size = new System.Drawing.Size(161, 60);
            this.btnSel.TabIndex = 0;
            this.btnSel.Text = "Selecione a planilha";
            this.btnSel.UseVisualStyleBackColor = true;
            this.btnSel.Click += new System.EventHandler(this.btnSel_Click);
            // 
            // opDialog
            // 
            this.opDialog.FileName = "openFileDialog1";
            // 
            // inicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 181);
            this.Controls.Add(this.btnSel);
            this.Name = "inicial";
            this.Text = "inicial";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSel;
        private System.Windows.Forms.OpenFileDialog opDialog;
    }
}