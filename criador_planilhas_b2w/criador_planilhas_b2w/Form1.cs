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
    public partial class Form1 : Form
    {
        private MySqlConnection objCnx = new MySqlConnection(); //Conexão
        private MySqlCommand objCmd = new MySqlCommand();//Comandos de linguagem
        private MySqlDataReader objDados; //Leitura de dados

        String marca = "";
        String data_pedido = "";
        String data_estorno = "";
        String ref_pedido = "";
        String entrega = "";
        String tipo = "";
        String valor = "";

        double valor1 = 0;
        double valor2 = 0;
        double valor3 = 0;
        int valorInt = 0;

        int j = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            objCnx.ConnectionString = "Server=localhost;Database=teste;User=root;Pwd=T34ka3yn##@@Swell";

            string text = System.IO.File.ReadAllText(@"C:\Users\desktop\Documents\ProgPlanilhas\teste.txt");

            text = text.Replace("ACOM", ";ACOM");
            text = text.Replace("SUBA", ";SUBA");
            text = text.Replace("SHOP", ";SHOP");
            String[] lista = text.Split(new Char[] { ';' });

            string path = @"C:\Users\desktop\Documents\ProgPlanilhas\testeResult.txt";

            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                for (int i = 0; i < lista.Length; i++)
                {
                    string linha = lista[i];
                    linha = linha.Replace(";", "");

                    if (linha.Trim() == "")
                    {
                        data_estorno = "";
                        continue;
                    }
                    if (linha.StartsWith("ACOM") || linha.StartsWith("SUBA") || linha.StartsWith("SHOP"))
                    {
                        marca = linha;
                        continue;
                    }
                    if (linha.Contains("/") && data_pedido == "")
                    {
                        data_pedido = linha;
                        continue;
                    }
                    if (linha.Contains("/"))
                    {
                        data_estorno = linha;
                        continue;
                    }
                    if (linha.StartsWith("01-") || linha.StartsWith("02-") || linha.StartsWith("03-"))
                    {
                        ref_pedido = linha;
                        continue;
                    }
                    if (linha.StartsWith("107") || linha.StartsWith("269") || linha.StartsWith("350"))
                    {
                        entrega = linha;
                        continue;
                    }
                    if (linha.StartsWith("Estorno") || linha.StartsWith("Venda") || linha.StartsWith("Comissao") ||
                        linha.StartsWith("Frete") || linha.StartsWith("Tarifa") || linha.StartsWith("Diferenca") ||
                        linha.StartsWith("Comissao") || linha.StartsWith("IR"))
                    {
                        tipo = linha;
                        continue;
                    }
                    if (linha.StartsWith("R$") || linha.StartsWith("-R$"))
                    {
                        valor = linha;
                        valorInt++;
                        if (valorInt == 1)
                        {
                            valor = valor.Replace("R$", "");
                            valor = valor.Replace("\r", "");
                            valor = valor.Replace("\n", "");
                            valor = valor.Replace(" ", "");
                            valor1 = Convert.ToDouble(valor);
                        }
                        if (valorInt == 2)
                        {
                            valor = valor.Replace("R$", "");
                            valor = valor.Replace("\r", "");
                            valor = valor.Replace("\n", "");
                            valor = valor.Replace(" ", "");
                            valor2 = Convert.ToDouble(valor);
                        }
                        if (valorInt == 3)
                        {
                            valor = valor.Replace("R$", "");
                            valor = valor.Replace("\r", "");
                            valor = valor.Replace("\n", "");
                            valor = valor.Replace(" ", "");
                            valor3 = Convert.ToDouble(valor);
                        }
                        lblNumPed.Text = "Dê o NF, nome do cliente, código do produto e preço de custo, referente ao pedido nº " + ref_pedido;
                    }
                    try
                    {
                        String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "','" + txtnf.Text + "'," +
                            "'" + txtClie.Text + "','" + txtCodProd.Text + "','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = sql;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();
                        data_pedido = "";
                        j++;
                    }
                    catch (Exception Erro)
                    {
                        MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //if (valorInt == 3)
                    //{
                    //    try
                    //    {
                    //        String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "','" + txtnf.Text + "'," +
                    //            "'" + txtClie.Text + "','" + txtCodProd.Text + "','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                    //        objCmd.Connection = objCnx;
                    //        objCmd.CommandText = sql;
                    //        objCnx.Open();
                    //        objCmd.ExecuteNonQuery();
                    //        objCnx.Close();
                    //        data_pedido = "";
                    //        j++;
                    //        valorInt = 0;
                    //    }
                    //    catch (Exception Erro)
                    //    {
                    //        MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                }
                File.WriteAllLines(path, lista, Encoding.UTF8);
            }
        }
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "','" + txtnf.Text + "'," +
                    "'" + txtClie.Text + "','" + txtCodProd.Text + "','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                objCmd.Connection = objCnx;
                objCmd.CommandText = sql;
                objCnx.Open();
                objCmd.ExecuteNonQuery();
                objCnx.Close();
                data_pedido = "";
                j++;

            }
            catch (Exception Erro)
            {
                MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
