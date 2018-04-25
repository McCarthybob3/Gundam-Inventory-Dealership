using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.ADO
{
    public class ModelRepoADO
    {
        public List<Models.TableModels.Model> GetAll()
        {
            List<Models.TableModels.Model> list = new List<Models.TableModels.Model>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Models.TableModels.Model currentRow = new Models.TableModels.Model();
                        currentRow.ModelID = (int)rdr["ModelID"];
                        currentRow.Name = rdr["ModelName"].ToString();
                        currentRow.User = rdr["User"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public void Insert(string model, string User)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);



                cmd.Parameters.AddWithValue("@ModelName", model);
                cmd.Parameters.AddWithValue("@UserID", User);






                cn.Open();

                cmd.ExecuteNonQuery();




            }
        }
    }
}
