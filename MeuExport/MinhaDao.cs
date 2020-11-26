using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace MeuExport
{
    public class MinhaDao
    {
        static string connectionString = @"Data Source=localhost;Persist Security Info=True;User ID=sa;Password=sa@123456789";
        SqlConnection sqlConnection = new SqlConnection(connectionString);

        // Conectar no Banco e inicializar Dataset
        public DataSet _GetDataSet(string sSqlCommand)
        {

            DataSet dsRetailProduct = new DataSet();
            
            try
            {
                using (SqlConnection _oCn = new SqlConnection())
                {
                    _oCn.ConnectionString = connectionString;

                    _oCn.Open();

                    SqlDataAdapter _Sqlda = new SqlDataAdapter(sSqlCommand, _oCn);

                    _Sqlda.SelectCommand.CommandTimeout = 0;
                    _Sqlda.Fill(dsRetailProduct);
                }


            }
            catch (Exception e)
            {
                string msgErro = e.Message.ToString();
            }
            return dsRetailProduct;
        }

        public void _ExecuteNonQuery(string sSqlCommand)
        {
            try
            {
                using (SqlConnection _oCn = new SqlConnection())
                {
                    _oCn.ConnectionString = connectionString;

                    _oCn.Open();

                    SqlCommand cmd = new SqlCommand(sSqlCommand, _oCn);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                }

            }
            catch (Exception e)
            {
                string msgErro = e.Message.ToString();
            }
        }

    }
}
