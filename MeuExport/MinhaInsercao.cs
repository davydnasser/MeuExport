using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MeuExport
{
    class MinhaInsercao
    {
        MinhaDao oDao = new MinhaDao();
        public void InsertSql()
        {
            //Pedir e receber os dados do usuário
            Console.WriteLine("Digite seu nome");
            string nome = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("O Nome Digitado foi: " + nome);
            Console.WriteLine();

            Console.WriteLine("Digite seu CPF ou CNPJ");
            string documento = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("O número digitado foi: " + documento);

            //Executar a inserção no banco

            oDao._ExecuteNonQuery("INSERT INTO [BANCODAVYD].[dbo].[GODOFREDO] (NOME,DOCUMENTO) VALUES ('" + nome + "','" + documento + "')");
            
        }
    }
}
