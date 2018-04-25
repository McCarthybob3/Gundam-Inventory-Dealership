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
   public class PurchaseRepoADO
    {

        public IEnumerable<Purchase_Type> GetAll()
        {
            List<Purchase_Type> list = new List<Purchase_Type>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("PurchaseSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cn.Open();
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Purchase_Type currentRow = new Purchase_Type();
                        currentRow.TypeId = (int)rdr["TypeID"];
                        currentRow.Type = rdr["Type"].ToString();
                       
                        list.Add(currentRow);
                    }
                }
            }
            return list;
        }

        public void Insert(Sale_Info Sale, string user)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SaleInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@PurchaseID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

  

                cmd.Parameters.AddWithValue("@InventoryNumber", Sale.InventoryNumber);
                cmd.Parameters.AddWithValue("@UserID", user);
                cmd.Parameters.AddWithValue("@SerialNumber", Sale.SerialNumber);
                cmd.Parameters.AddWithValue("@Type", Sale.TypeID);
                cmd.Parameters.AddWithValue("@Name", Sale.Name);
                cmd.Parameters.AddWithValue("@Email", Sale.Email);
                cmd.Parameters.AddWithValue("@Phone", Sale.Phone);
                cmd.Parameters.AddWithValue("@Street1", Sale.Street1);
                cmd.Parameters.AddWithValue("@Street2", Sale.Street2);
                cmd.Parameters.AddWithValue("@City", Sale.City);
                cmd.Parameters.AddWithValue("@ZipCode", Sale.ZipCode);
                cmd.Parameters.AddWithValue("@StateID", Sale.StateID);
                cmd.Parameters.AddWithValue("@TypeID", Sale.Type);
                cmd.Parameters.AddWithValue("@Price", Sale.Price);




                cn.Open();

                cmd.ExecuteNonQuery();




            }
        }
    }
}
