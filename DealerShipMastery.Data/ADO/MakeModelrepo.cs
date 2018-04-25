using DealerShipMastery.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DealerShipMastery.Data.ADO
{
    public class MakeModelrepo
    {
        public List<MakeModel> GetAll()
        {


            List<MakeModel> list = new List<MakeModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeModelSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        MakeModel currentRow = new MakeModel();
                        currentRow.MakeID = (int)rdr["MakeID"];
                        currentRow.ModelID = (int)rdr["ModelID"];
                        currentRow.MakeModelID = (int)rdr["MakeModelID"];
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }


        public MakeModel GetByBoth(int make, int model)
        {
            MakeModel list = new MakeModel();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeModelBoth", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeID", make);
                cmd.Parameters.AddWithValue("@ModelID", model);
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                   
                        list.MakeID = (int)rdr["MakeID"];
                        list.ModelID = (int)rdr["ModelID"];
                        list.MakeModelID = (int)rdr["MakeModelID"];
                      
                    }

                }
                return list;

            }
        }

        public int Insert(int make, int model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeModelInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@MakeModelID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeID", make);
                cmd.Parameters.AddWithValue("@ModelID", model);






                cn.Open();

                cmd.ExecuteNonQuery();

               return (int)param.Value;

            }
        }



    }
}

    







