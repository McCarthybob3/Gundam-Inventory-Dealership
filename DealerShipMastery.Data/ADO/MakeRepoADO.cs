using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.ADO
{
   public class MakeRepoADO
    {

        public IEnumerable<Models.TableModels.Make> GetAll()
        {
            List<Models.TableModels.Make> list = new List<Models.TableModels.Make>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Models.TableModels.Make currentRow = new Models.TableModels.Make();
                        currentRow.MakeID = (int)rdr["MakeID"];
                        currentRow.Name = rdr["MakeName"].ToString();
                        currentRow.User = rdr["User"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
        public void Insert(string make, string User)
        {
           
                using (var cn = new SqlConnection(Settings.GetConnectionString()))
                {
                    SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@MakeID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);



                cmd.Parameters.AddWithValue("@MakeName", make);
                cmd.Parameters.AddWithValue("@UserID", User);





                cn.Open();

                    cmd.ExecuteNonQuery();

                  

                
            }
        }
    }
}
