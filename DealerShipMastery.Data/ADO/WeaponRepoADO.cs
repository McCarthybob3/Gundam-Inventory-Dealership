using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.ADO
{
    public class WeaponRepoADO
    {
        public List<Models.TableModels.Weapon> GetAll()
        {
            List<Models.TableModels.Weapon> list = new List<Models.TableModels.Weapon>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("WeaponsSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Models.TableModels.Weapon currentRow = new Models.TableModels.Weapon();
                        currentRow.WeaponID = (int)rdr["WeaponID"];
                        currentRow.WeaponName = rdr["WeaponName"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}
