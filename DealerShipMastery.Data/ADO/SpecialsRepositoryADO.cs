using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerShipMastery.Data.Interfaces;
using DealerShipMastery.Models.TableModels;

namespace DealerShipMastery.Data.ADO
{
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public IEnumerable<Special> GetAll()
        {
            List<Special> list = new List<Special>();


            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialsAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                   
                    while (rdr.Read())
                    {
                        Special _Special = new Special();
                        _Special.Title = rdr["Title"].ToString();
                        _Special.Description = rdr["Description"].ToString();

                        list.Add(_Special);

                    }
                 
                }
            
            }
            return list;
        }

        public void Insert(string Title, string Content)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SpecialInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@SpecialID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);



                cmd.Parameters.AddWithValue("@Title", Title);
                cmd.Parameters.AddWithValue("@Description", Content);






                cn.Open();

                cmd.ExecuteNonQuery();




            }
        }
    }
}
