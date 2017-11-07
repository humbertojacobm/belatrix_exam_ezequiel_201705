using Belatrix.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Belatrix.DAL
{
    public class DALLog
    {
        public Result CreateLog(Log _prmInput )
        {
            Result _Result = new Result();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {

                    connection.Open();
                    
                    SqlCommand Command = new SqlCommand("BelatrixTCreateLog", connection);
                    Command.CommandType = CommandType.StoredProcedure;

                    Command.Parameters.Add(new SqlParameter() { ParameterName= "@prmMessage", SqlDbType=SqlDbType.VarChar, Size=8000, Value=_prmInput.Message });
                    Command.Parameters.Add(new SqlParameter() { ParameterName = "@CodeT", Value = _prmInput.CodeT, DbType = DbType.String, Size = 10 });

                    Command.ExecuteNonQuery();

                    _Result.Code = (int)Enumerates.Result.Success;

                }
            }
            catch (Exception ex)
            {
                _Result.Code = (int)Enumerates.Result.Error;
                _Result.ErrorMessage = ex.Message;
            }

            return _Result;
        }
    }
}
