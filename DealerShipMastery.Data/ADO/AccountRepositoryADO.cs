using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DealerShipMastery.Data.Interfaces;
using DealerShipMastery.Models.QueryModels;
using DealerShipMastery.Models.TableModels;

namespace DealerShipMastery.Data.ADO
{
    public class AccountRepositoryADO : IAccountRepository
    {
        public void DeleteContact(int ContactID)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsDelete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@ContactID", ContactID);


                cn.Open();

                cmd.ExecuteNonQuery();



            }
        }

        //public IEnumerable<ContactRequest> GetAllContacts(int ContactID)
        //{

        //}

        public void RemoveContact(string userId, int InventoryNumber)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public Contact GetContact(int ContactID)
        {
            Contact MobileSuit = new Contact();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsSelect", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ContactID", ContactID);
                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {

                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.Email = rdr["Email"].ToString();
                        MobileSuit.Message = rdr["Message"].ToString();
                        MobileSuit.Phone = rdr["Phone"].ToString();
                    

                    }
                }
            }

            return MobileSuit;

        }


        public void InsertContactDirect(string userId, int InventoryNumber)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsertDirect", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //SqlParameter param = new SqlParameter("@ContactID", SqlDbType.Int);
                //param.Direction = ParameterDirection.Output;

                //cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
                cmd.Parameters.AddWithValue("@UserId", userId);
  

                cn.Open();

                cmd.ExecuteNonQuery();


            }
        }

        public void InsertContact(Contact contact)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsertContactPage", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                //cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
                //cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@ContactEmail", contact.Email);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
                cmd.Parameters.AddWithValue("@ContactName", contact.Name);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);


                cn.Open();

                cmd.ExecuteNonQuery();

               contact.ContactID = (int)param.Value;

            }
        }

        public void InsertContactSelect(Contact contact, int InventoryNumber)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsInsertByUser", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@ContactID", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
                cmd.Parameters.AddWithValue("@ContactEmail", contact.Email);
                cmd.Parameters.AddWithValue("@Message", contact.Message);
                cmd.Parameters.AddWithValue("@ContactName", contact.Name);
                cmd.Parameters.AddWithValue("@Phone", contact.Phone);


                cn.Open();

                cmd.ExecuteNonQuery();

                contact.ContactID = (int)param.Value;

            }
        }

        public bool IsContact(string userId, int InventoryNumber)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ContactsSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
                cmd.Parameters.AddWithValue("@UserId", userId);

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    return dr.Read();
                }
            }
        }
    }
}
