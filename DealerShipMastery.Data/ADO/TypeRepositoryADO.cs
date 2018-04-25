using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerShipMastery.Data.Interfaces;
using DealerShipMastery.Models.TableModels;
using System.Data.SqlClient;

namespace DealerShipMastery.Data.ADO
{
    public class TypeRepositoryADO : ITypeRepository
    {
        public List<Models.TableModels.Type> GetAll()
        {
            List<Models.TableModels.Type> list = new List<Models.TableModels.Type>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TypeSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Models.TableModels.Type currentRow = new Models.TableModels.Type();
                        currentRow.TypeID = (int)rdr["TypeID"];
                        currentRow.Name = rdr["TypeName"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}
