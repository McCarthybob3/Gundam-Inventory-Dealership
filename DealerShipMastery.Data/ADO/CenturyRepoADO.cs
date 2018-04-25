using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.ADO
{
    public class CenturyRepoADO
    {
        public List<Models.TableModels.Century> GetAll()
        {
            List<Models.TableModels.Century> list = new List<Models.TableModels.Century>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CenturySelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Models.TableModels.Century currentRow = new Models.TableModels.Century();
                        currentRow.CenturyID = (int)rdr["CenturyID"];
                        currentRow.CenturyName = rdr["CenturyName"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}
