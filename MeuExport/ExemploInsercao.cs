using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace MeuExport
{
    class ExemploInsercao
    {
        public static void Insercao(string[] args)
        {
            Console.Title = "Meu Export";
            Console.WriteLine("Console de incercao de dados");
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
            string sql = @"INSERT INTO [BANCODAVYD].[dbo].[GODOFREDO] (NOME,DOCUMENTO) VALUES ('" + nome + "','" + documento + "')";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}
