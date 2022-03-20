using System.Data;
using System.Data.SqlClient;
using RSA.Connection;
using RSA.Domain;
using RSA.Repository.Interface;

namespace RSA.Repository
{
    public class EncryptedTextRepository : IEncryptedTextRepository
    {
        public InsertReturn InsertText(string text)
        {
            var sqlString = new SQLConnection();
            SqlConnection conn = new SqlConnection(sqlString.SQLConnectionString());
            var ret = new InsertReturn();

            try
            {
                conn.Open();
                
                var query = "INSERT INTO EncryptedText(Text) OUTPUT INSERTED.IdText VALUES(@Text)";
                SqlCommand comando = new(query, conn);
                comando.Parameters.Add(new SqlParameter("@Text", text));
                comando.Parameters.Add("@ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                var obj = comando.ExecuteScalar();

                if (obj != null)
                {
                    ret.UUID = Int32.Parse(obj.ToString());
                    ret.pkcs8 = null;
                }

                conn.Close();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return ret;

        }

        public SelectReturn SelectText(int id)
        {
            var sqlString = new SQLConnection();
            SqlConnection conn = new SqlConnection(sqlString.SQLConnectionString());
            var ret = new SelectReturn();

            try
            {
                conn.Open();

                var query = "SELECT Text FROM EncryptedText WHERE IdText = @id";
                SqlCommand comando = new(query, conn);
                comando.Parameters.Add(new SqlParameter("@id", id));
                var obj = comando.ExecuteScalar();

                if (obj != null)
                {
                    ret.encryptedText = obj.ToString();
                }

                conn.Close();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return ret;

        }

    }
}