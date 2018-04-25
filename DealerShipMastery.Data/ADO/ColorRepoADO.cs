using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.ADO
{
    public class ColorRepoADO
    {
        public List<Models.TableModels.Color> GetAll()
        {
            List<Models.TableModels.Color> list = new List<Models.TableModels.Color>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ColorsSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Models.TableModels.Color currentRow = new Models.TableModels.Color();
                        currentRow.ColorID = (int)rdr["ColorID"];
                        currentRow.Name = rdr["ColorName"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}
