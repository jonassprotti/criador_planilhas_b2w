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
using MySql.Data.MySqlClient;

namespace criador_planilhas_b2w
{
    public partial class atualizar : Form
    {
        private MySqlConnection objCnx = new MySqlConnection(); //Conexão
        private MySqlCommand objCmd = new MySqlCommand();//Comandos de linguagem
        private MySqlDataReader objDados; //Leitura de dados

        public atualizar()
        {
            InitializeComponent();
        }

        private void atualizar_Load(object sender, EventArgs e)
        {

        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            
        }
    }
}
