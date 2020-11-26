using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace MeuExport
{
    class ExemploExport
    { 
        public void Export(string[] args)
        {
            Console.WriteLine("Gerador de CSV");
            // Conectar no Banco
            var connectionString = @"Data Source=localhost;Persist Security Info=True;User ID=sa;Password=sa@123456789";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            //Testar conexão com o banco
            if (sqlConnection.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine();
                Console.WriteLine("Conexão com o banco de dados inativa");
                Console.WriteLine();
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Conexão com o banco de dados ativa");
            Console.WriteLine();

            //Extrair os dados da Tabela

            string sCommSQL = "SELECT TOP(1000)[ID],[NOME],[DOCUMENTO]FROM[BANCODAVYD].[dbo].[GODOFREDO]";
            //DataSet _GetDataSet(string sSqlCommand)
            //{
            //    DataSet dsRetailProduct = new DataSet();

            //    try
            //    {
            //        using (SqlConnection _oCn = new SqlConnection())
            //        {
            //            _oCn.ConnectionString = connectionString;

            //            //_oCn.Open();

            //            SqlDataAdapter _Sqlda = new SqlDataAdapter(sSqlCommand, _oCn);

            //            _Sqlda.SelectCommand.CommandTimeout = 0;
            //            _Sqlda.Fill(dsRetailProduct);
            //        }


            //    }
            //    catch (Exception e)
            //    {
            //        string msgErro = e.Message.ToString();
            //    }
            //    return dsRetailProduct;
            //}


            //Carregar o DataSet e gerar o CSV

            MinhaDao oDao = new MinhaDao();
            DataSet ds = oDao._GetDataSet(sCommSQL.ToString());
            StringBuilder CSV = new StringBuilder();
            double PCT = 0;
            double NrRegistros = 0;
            double CountReg = 0;

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable tb = ds.Tables[0];
                        NrRegistros = ds.Tables[0].Rows.Count;


                        foreach (DataRow row in tb.Rows)
                        {
                            CountReg += 1;
                            PCT = (CountReg / NrRegistros) * 100;

                            Console.WriteLine("+++++ Nº Registros Processados: " + CountReg.ToString() + " de " + NrRegistros + " - Processados " + PCT.ToString("0.00") + "%");

                            for (int i = 0; i < tb.Columns.Count; i++)
                            {
                                CSV.Append(row[i].ToString() + ";");
                                Console.WriteLine(row[i].ToString() + ";");
                            }

                            CSV.Append(Environment.NewLine);
                        }

                        string dataAtual = DateTime.Now.ToString("yyyyMMdd_hhm");

                        if (!System.IO.Directory.Exists(@"C:\Martins"))
                        {
                            System.IO.Directory.CreateDirectory(@"C:\Martins");
                        }

                        string FileName = "";

                        FileName = $"Dados_Consulta_{dataAtual}.csv";

                        string Path = @"C:\Martins\" + FileName;

                        File.WriteAllText(@"C:\Martins\" + FileName, CSV.ToString());

                        Console.WriteLine("+++++ Arquivo CSV gerado com sucesso");

                        Console.WriteLine($"+++++ Arquivo gerado em {Path}");

                        Console.WriteLine("+++++ Pressione qualquer tecla para finalizar.");
                        Console.ReadLine();
                    }
                }

            }

            ////Pedir e receber os dados do usuário
            //Console.WriteLine("Digite seu nome");
            //string nome = Console.ReadLine();
            //Console.WriteLine();
            //Console.WriteLine("O Nome Digitado foi: " + nome);
            //Console.WriteLine();

            //Console.WriteLine("Digite seu CPF ou CNPJ");
            //string documento = Console.ReadLine();
            //Console.WriteLine();
            //Console.WriteLine("O número digitado foi: " + documento);

            //Executar a inserção no banco
            //string sql = @"INSERT INTO [BANCODAVYD].[dbo].[GODOFREDO] (NOME,DOCUMENTO) VALUES ('" + nome + "','" + documento + "')";

            //SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            //cmd.ExecuteNonQuery();
            sqlConnection.Close();



        }
    }
}
