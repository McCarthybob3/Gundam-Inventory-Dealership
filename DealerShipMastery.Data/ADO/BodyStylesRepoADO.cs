using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.ADO
{
   public class BodyStylesRepoADO
    {
        public List<Models.TableModels.body_style> GetAll()
        {
            List<Models.TableModels.body_style> list = new List<Models.TableModels.body_style>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Models.TableModels.body_style currentRow = new Models.TableModels.body_style();
                        currentRow.BodyStyleID = (int)rdr["BodyStyleID"];
                        currentRow.Name = rdr["BodyStyleName"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}
