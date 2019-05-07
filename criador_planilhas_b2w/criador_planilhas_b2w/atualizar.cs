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
            objCnx.ConnectionString = "Server=localhost;Database=teste;User=root;Pwd=T34ka3yn##@@Swell";

            try
            {
                objCnx.Open();

                string strSql = "Select * from teste where tipo ='venda'";
                objCmd.Connection = objCnx;
                objCmd.CommandText = strSql;
                objDados = objCmd.ExecuteReader();
                while (objDados.Read())
                {
                    dgvDados.Rows.Add(objDados.GetString(0), objDados.GetString(1), objDados.GetString(2), objDados.GetString(3), objDados.GetString(4), objDados.GetString(5), objDados.GetString(6), objDados.GetString(7), objDados.GetString(8), objDados.GetString(9));
                }

                objCnx.Close();
            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvDados_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                nomelivro = dgvDados.Rows[dgvDados.SelectedRows[0].Index].Cells[0].Value.ToString();
            }
            catch (Exception)
            {
                return;
            }
            if (nomelivro != "")
            {
                try
                {
                    objCnx.Open();
                    string strSql = "Select livro from cadlivro Where titulo =  '" + nomelivro + "'";
                    objCmd.Connection = objCnx;
                    objCmd.CommandText = strSql;
                    objDados = objCmd.ExecuteReader();
                    while (objDados.Read())
                    {
                        lerDados(objDados, 0);

                    }
                    objCnx.Close();
                }
                catch (Exception erro)
                {
                    return;
                }
            }
        }
    }
}
