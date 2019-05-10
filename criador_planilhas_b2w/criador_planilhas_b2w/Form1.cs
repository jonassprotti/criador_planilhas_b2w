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

        String ref_pedidoInicial = "";

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
        double valor4 = 0;
        int valorInt = 0;
        int add = 0;
        int j = 0;
        private string path;

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

           
            for (int i = 0; i < lista.Length; i++)
            {
                string linha = lista[i];
                linha = linha.Replace(";", "");

                if (linha.StartsWith("01-") || linha.StartsWith("02-") || linha.StartsWith("03-"))
                {
                    ref_pedidoInicial = linha;
                    break;
                }
            }
            lblDesc.Text = ref_pedidoInicial;
            // This text is added only once to the file.

        }

        private void atualizar()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\desktop\Documents\ProgPlanilhas\teste.txt");

            text = text.Replace("ACOM", ";ACOM");
            text = text.Replace("SUBA", ";SUBA");
            text = text.Replace("SHOP", ";SHOP");

            String[] lista = text.Split(new Char[] { ';' });

            path = @"C:\Users\desktop\Documents\ProgPlanilhas\testeResult.txt";
            if (!File.Exists(path))
            {
                //add++;
                for (int i = add; i < lista.Length; i++)
                {
                    string linha = lista[i];

                    if (linha.StartsWith("01-") && ref_pedidoInicial == "" || linha.StartsWith("02-") && ref_pedidoInicial == "" || linha.StartsWith("03-") && ref_pedidoInicial == "")
                    {
                        ref_pedidoInicial = linha;
                    }
                }
            }
            lblDesc.Text = ref_pedidoInicial;

        }

        private void adicionar()
        {
            

            string text = System.IO.File.ReadAllText(@"C:\Users\desktop\Documents\ProgPlanilhas\teste.txt");

            text = text.Replace("ACOM", ";ACOM");
            text = text.Replace("SUBA", ";SUBA");
            text = text.Replace("SHOP", ";SHOP");

            String[] lista = text.Split(new Char[] { ';' });

            path = @"C:\Users\desktop\Documents\ProgPlanilhas\testeResult.txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                for (int i = add; i < lista.Length; i++)
                {
                    
                    string linha = lista[i];
                    linha = linha.Replace(";", "");

                    if (linha.Trim() == "")
                    {
                        data_estorno = "";
                        add++;
                        continue;
                    }
                    if (linha.StartsWith("ACOM") || linha.StartsWith("SUBA") || linha.StartsWith("SHOP"))
                    {
                        marca = linha;
                        add++;
                        continue;
                    }
                    if (linha.Contains("/") && data_pedido == "")
                    {
                        data_pedido = linha;
                        add++;
                        continue;
                    }
                    if (linha.Contains("/"))
                    {
                        data_estorno = linha;
                        add++;
                        continue;
                    }
                    if (linha.StartsWith("01-") || linha.StartsWith("02-") || linha.StartsWith("03-"))
                    {
                        ref_pedido = linha;
                        add++;
                        continue;
                    }
                    if (linha.StartsWith("107") || linha.StartsWith("269") || linha.StartsWith("350") || linha.StartsWith("268"))
                    {
                        entrega = linha;
                        add++;
                        continue;
                    }
                    if (linha.StartsWith("Estorno") || linha.StartsWith("Venda") || linha.StartsWith("Comissao") ||
                        linha.StartsWith("Frete") || linha.StartsWith("Diferenca") ||
                        linha.StartsWith("Comissao") || linha.StartsWith("IR") || linha.StartsWith("Tarifa"))
                    {
                        tipo = linha;
                        add++;
                        continue;
                    }


                    if (linha.StartsWith("R$") || linha.StartsWith("-R$"))
                    {
                        valor = linha;
                        valorInt++;
                        add++;
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
                        if (valorInt == 4)
                        {
                            valor = valor.Replace("R$", "");
                            valor = valor.Replace("\r", "");
                            valor = valor.Replace("\n", "");
                            valor = valor.Replace(" ", "");
                            valor4 = Convert.ToDouble(valor);
                        }
                    }
                    
                    if (valorInt == 4 && tipo != "Tarifa_Adicional")
                    {
                        //Realiza o calculo e insere o valor da soma
                        double receber = valor1 + valor2 + valor3;
                        String valReceber = "INSERT INTO TESTE VALUES('', '','','','','','','','Receber','" + receber + "')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = valReceber;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();
                        //Insere o imposto de 4% perante o valor a receber
                        double imposto = receber * 0.04;
                        String valorImposto = "INSERT INTO TESTE VALUES('', '','','','','','','','Imposto NF (4%)','" + imposto + "')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = valorImposto;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();
                        //Insere o valor a receber tirando a taxa da NF
                        double sNF = receber - imposto;
                        String valorSNF = "INSERT INTO TESTE VALUES('', '','','','','','','','Receber (-NF)','" + sNF + "')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = valorSNF;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();
                        //Insere o preço de custo
                        String precoCusto = "INSERT INTO TESTE VALUES('', '','','','','','','','Preço de custo','" + txtCusto.Text + "')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = precoCusto;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();
                        //Insere o valor final em R$
                        double final = sNF - Convert.ToDouble(txtCusto.Text);
                        String valorFinal = "INSERT INTO TESTE VALUES('', '','','','','','','','Lucro R$','" + final + "')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = valorFinal;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();

                        //Insere o lucro em %
                        double finalPorc = (sNF / Convert.ToDouble(txtCusto.Text)) - 1;
                        String valorFinalPorc = "INSERT INTO TESTE VALUES('', '','','','','','','','Lucro (%)','" + finalPorc + "%')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = valorFinalPorc;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();


                        //Insere uma linha vázia
                        String sqlnull = "INSERT INTO TESTE VALUES('','','','','','','','','','')";
                        objCmd.Connection = objCnx;
                        objCmd.CommandText = sqlnull;
                        objCnx.Open();
                        objCmd.ExecuteNonQuery();
                        objCnx.Close();

                        //String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "',''," +
                        //       "'','','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                        //objCmd.Connection = objCnx;
                        //objCmd.CommandText = sql;
                        //objCnx.Open();
                        //objCmd.ExecuteNonQuery();
                        //objCnx.Close();


                        data_pedido = "";
                        j++;
                        valorInt = 0;

                        return;
                    }
                    if (valorInt == 4)
                    {
                        try
                        {
                            String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "',''," +
                                "'','','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = sql;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            //Realiza o calculo e insere o valor da soma
                            double receber = valor1 + valor2 + valor3 + valor4;
                            String valReceber = "INSERT INTO TESTE VALUES('', '','','','','','','','Receber','" + receber + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = valReceber;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            //Insere o imposto de 4% perante o valor a receber
                            double imposto = receber * 0.04;
                            String valorImposto = "INSERT INTO TESTE VALUES('', '','','','','','','','Imposto NF (4%)','" + imposto + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = valorImposto;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            //Insere o valor a receber tirando a taxa da NF
                            double sNF = receber - imposto;
                            String valorSNF = "INSERT INTO TESTE VALUES('', '','','','','','','','Receber (-NF)','" + sNF + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = valorSNF;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            //Insere o preço de custo
                            String precoCusto = "INSERT INTO TESTE VALUES('', '','','','','','','','Preço de custo','" + txtCusto.Text + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = precoCusto;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            //Insere o valor final em R$
                            double final = sNF - Convert.ToDouble(txtCusto.Text);
                            String valorFinal = "INSERT INTO TESTE VALUES('', '','','','','','','','Lucro R$','" + final + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = valorFinal;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();

                            //Insere o lucro em %
                            double finalPorc = (sNF / Convert.ToDouble(txtCusto.Text))-1;
                            String valorFinalPorc = "INSERT INTO TESTE VALUES('', '','','','','','','','Lucro (%)','" + finalPorc + "%')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = valorFinalPorc;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();

                            String sqlnull = "INSERT INTO TESTE VALUES('','','','','','','','','','')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = sqlnull;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();


                            data_pedido = "";
                            j++;
                            valorInt = 0;


                            return;

                        }
                        catch (Exception Erro)
                        {
                            MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (valorInt == 1)
                    {
                        try
                        {

                            String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "','" + txtNF.Text + "','" + txtNomeClie.Text + "','" + txtCodProd.Text + "','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = sql;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            data_pedido = "";
                            j++;
                            continue;
                        }

                        catch (Exception Erro)
                        {
                            MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (valorInt == 2)
                    {
                        try
                        {
                            String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "',''," +
                                "'','','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = sql;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            data_pedido = "";
                            j++;
                            continue;
                        }

                        catch (Exception Erro)
                        {
                            MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (valorInt == 3)
                    {
                        try
                        {
                            String sql = "INSERT INTO TESTE VALUES('" + marca + "', '" + data_pedido + "','" + data_estorno + "',''," +
                                "'','','" + ref_pedido + "','" + entrega + "','" + tipo + "','" + valor + "')";
                            objCmd.Connection = objCnx;
                            objCmd.CommandText = sql;
                            objCnx.Open();
                            objCmd.ExecuteNonQuery();
                            objCnx.Close();
                            data_pedido = "";
                            j++;

                            

                            if (tipo != "Frete_B2W_Entrega" || tipo != "Estorno_Frete_B2W_Entrega")
                            {
                                continue;
                            }
                            else
                            {
                               
                                return;
                            }
                            
                        }

                        catch (Exception Erro)
                        {
                            MessageBox.Show("Erro ==> " + Erro.Message, "ADO.NET", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    

                }

                File.WriteAllLines(path, lista, Encoding.UTF8);
            }
        }

        private void BtnProx_Click(object sender, EventArgs e)
        {

            adicionar();
            ref_pedidoInicial = "";
            atualizar();
            valor1 = 0;
            valor2 = 0;
            valor3 = 0;
            valor4 = 0;
        }
    }
}

