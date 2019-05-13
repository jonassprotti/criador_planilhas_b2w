using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace criador_planilhas_b2w
{
    public partial class inicial : Form
    {
        public inicial()
        {
            InitializeComponent();
        }

        private void btnSel_Click(object sender, EventArgs e)
        {
            opDialog.Filter = "All files (*.*)|*.*";

            opDialog.Title = "Selecione o arquivo";

            opDialog.ShowDialog(); //Abrindo caixa de dialogo
            try
            {
                if (!String.IsNullOrEmpty(opDialog.FileName))

                {
                    System.IO.Directory.CreateDirectory(@"C:\Users\desktop\Documents\ProgPlanilhas");
                    System.IO.File.Copy(opDialog.FileName, @"C:\Users\desktop\Documents\ProgPlanilhas\teste.csv");
                    System.IO.File.Copy(@"C:\Users\desktop\Documents\ProgPlanilhas\teste.csv", @"C:\Users\desktop\Documents\ProgPlanilhas\teste.txt");

                }
            }catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }






            Form1 Menu = new Form1();
            Menu.Show();
            this.Visible = false;

        }
    }
}
