using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerShipMastery.Data.Interfaces;
using DealerShipMastery.Models.TableModels;
using System.Data.SqlClient;
using System.Data;


namespace DealerShipMastery.Data.ADO
{
    public class StateRepositoryADO : IStateRepository
    {
        public List<State> GetAll()
        {
            List<State> list = new List<State>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("StatesSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        State currentRow = new State();
                        currentRow.StateID =  rdr["StateID"].ToString();
                        currentRow.Name = rdr["StateAb"].ToString();
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }
    }
}
