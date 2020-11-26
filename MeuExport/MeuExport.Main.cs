using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace MeuExport
{
    class MeuExport
    {
        static void Main(string[] args)
        {
            //Verificar a conexão com o banco de dados.
            Console.WriteLine("+++++ Verificando conexão com o banco de dados");
            Console.WriteLine("+++++");

            if (!CheckConnect())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("+++++ Erro na conexão, favor solicitar liberação de acesso para seu endereço IP!");
                Console.WriteLine("+++++");
                return;
            }

            Console.WriteLine("+++++ Conexão realizada com sucesso!");
            Console.WriteLine("+++++");

            MinhaInsercao _oMi = new MinhaInsercao();
            _oMi.InsertSql();
        }

        //Metodo de verificação de conexão e consulta no banco de dados
        private static bool CheckConnect()
        {
            MinhaDao oDao = new MinhaDao();
            try
            {
                DataSet connect = oDao._GetDataSet("SELECT TOP 1 * FROM [BANCODAVYD].[dbo].[GODOFREDO]");
                if (connect != null)
                {
                    if (connect.Tables.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch
            {
                return false;
            }
        }        

    }
}
