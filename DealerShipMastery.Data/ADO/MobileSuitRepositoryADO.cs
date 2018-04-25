using DealerShipMastery.Data.Interfaces;
using DealerShipMastery.Models.QueryModels;
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
    public class MobileSuitRepositoryADO : IMobileSuitRepository
    {
        
       

        public void Delete(int MobileSuitId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitDelete", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@InventoryNumber", MobileSuitId);


                cn.Open();

                cmd.ExecuteNonQuery();



            }
        }

        public IEnumerable<Mobile_Suit_Search_Result> GetBroken()
        {
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();
            

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectBroken", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                   
                    while (rdr.Read())
                    {
                        Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.InventoryNumber = (int)rdr["InventoryNumber"];
                        MobileSuit.Featured = (bool)rdr["Featured"];
                        MobileSuit.MakeId = (int)rdr["MakeId"];
                        MobileSuit.ModelId = (int)rdr["ModelId"];


                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }

                }

            }
            return list;
        }

        public Mobile_Suit GetById(int MobileSuitId)
        {
            Mobile_Suit MobileSuit = new Mobile_Suit();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelect", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InventoryNumber", MobileSuitId);
                cn.Open();

             
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        
                        MobileSuit.SerialNumber= rdr["SerialNumber"].ToString();
                        MobileSuit.TypeID = (int)rdr["TypeID"];
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.CenturyID = (int)rdr["CenturyID"];
                        MobileSuit.MakeModelID = (int)rdr["MakeModelID"];
                        MobileSuit.BodyStyleID = (int)rdr["BodyStyleID"];
                        MobileSuit.WeaponID=(int)rdr["WeaponID"];
                        MobileSuit.ColorID= (int)rdr["ColorID"];
                        MobileSuit.Interior = (int)rdr["Interior"];
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.Description = rdr["Description"].ToString();
                        if(rdr["Image"] != DBNull.Value)
                        MobileSuit.Image = rdr["Image"].ToString();
                        MobileSuit.UserID = rdr["UserID"].ToString();
                        MobileSuit.InventoryNumber = MobileSuitId;
                    }
                }
            }
            
            return MobileSuit;

        }

        public IEnumerable<Mobile_Suit_Search_Result> GetByMake(string MakeName)
        {
          
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectByMake", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MakeID", MakeName);
                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.Featured = (bool)rdr["Featured"];
                        

                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }
                }

            }
            return list;
        }

        public IEnumerable<Mobile_Suit_Search_Result> GetByModel(string ModelName)
        {
          
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectByModel", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ModelID", ModelName);
                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.Featured = (bool)rdr["Featured"];


                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }
                }

            }
            return list;
        }

        public IEnumerable<Mobile_Suit_Search_Result> GetByPrice(int Price)
        {
            
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectByPrice", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Price", Price);
                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.Featured = (bool)rdr["Featured"];


                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }
                }

            }
            return list;
        }

        public IEnumerable<Mobile_Suit_Search_Result> GetByYear(int Year)
        {
            Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectByYear", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Year", Year);
                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.Featured = (bool)rdr["Featured"];


                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }
                }

            }
            return list;
        }

        public IEnumerable<Mobile_Suit_Search_Result> GetCustom()
        {
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();


            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectCustom", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                   
                    while (rdr.Read())
                    {
                        Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.InventoryNumber = (int)rdr["InventoryNumber"];
                        MobileSuit.Featured = (bool)rdr["Featured"];
                        MobileSuit.MakeId = (int)rdr["MakeId"];
                        MobileSuit.ModelId = (int)rdr["ModelId"];


                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }

                }

            }
            return list;
        }

        public Detail_Result GetDetails(int MobileSuitId)
        {
            Detail_Result MobileSuit = new Detail_Result();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectDetails", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@InventoryNumber", MobileSuitId);
                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.Description = rdr["Description"].ToString();
                        MobileSuit.InventoryNumber = MobileSuitId;
                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();


                    }
                }
               
            }
            return MobileSuit;
        }

        public IEnumerable<Mobile_Suit_Search_Result> GetMassProduced()
        {
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();


            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectMassProduced", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                 
                    while (rdr.Read())
                    {
                        Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.InventoryNumber = (int)rdr["InventoryNumber"];
                        MobileSuit.Featured = (bool)rdr["Featured"];
                        MobileSuit.MakeId = (int)rdr["MakeId"];
                        MobileSuit.ModelId = (int)rdr["ModelId"];


                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }

                }

            }
            return list;
        }

        public IEnumerable<Mobile_Suit_Search_Result> GetAll()
        {
            List<Mobile_Suit_Search_Result> list = new List<Mobile_Suit_Search_Result>();


            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectAll", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        Mobile_Suit_Search_Result MobileSuit = new Mobile_Suit_Search_Result();
                        MobileSuit.Name = rdr["Name"].ToString();
                        MobileSuit.SerialNumber = rdr["SerialNumber"].ToString();
                        MobileSuit.Type = rdr["TypeName"].ToString();
                        MobileSuit.Year = (int)rdr["Year"];
                        MobileSuit.Century = rdr["CenturyName"].ToString();
                        MobileSuit.Make = rdr["MakeName"].ToString();
                        MobileSuit.Model = rdr["ModelName"].ToString();
                        MobileSuit.BodyStyle = rdr["BodyStyleName"].ToString();
                        MobileSuit.Weapon = rdr["WeaponName"].ToString();
                        MobileSuit.Color = rdr["ColorName"].ToString();
                        MobileSuit.Interior = rdr["Interior"].ToString();
                        MobileSuit.MSRP = (int)rdr["MSRP"];
                        MobileSuit.SalePrice = (int)rdr["SalePrice"];
                        MobileSuit.InventoryNumber = (int)rdr["InventoryNumber"];
                        MobileSuit.Featured = (bool)rdr["Featured"];
                        MobileSuit.MakeId = (int)rdr["MakeId"];
                        MobileSuit.ModelId = (int)rdr["ModelId"];


                        if (rdr["Image"] != DBNull.Value)
                            MobileSuit.Image = rdr["Image"].ToString();

                        list.Add(MobileSuit);
                    }

                }

            }
            return list;
        }

        public IEnumerable<Featured_Item> GetRecent()
        {

            List<Featured_Item> list = new List<Featured_Item>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitSelectRecent", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cn.Open();


                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Featured_Item row = new Featured_Item();

                        row.InventoryNumber = (int)rdr["InventoryNumber"];

                        row.Make = rdr["MakeName"].ToString();
                        row.Model = rdr["ModelName"].ToString();
                        row.Name = rdr["Name"].ToString();
                        row.SalePrice = (int)rdr["SalePrice"];
                        if (rdr["Image"] != DBNull.Value)
                            row.Image = rdr["Image"].ToString();

                        list.Add(row);


                    }
                  
                }
                
            }
            return list;
        }

        public IEnumerable<Featured_Item> Search(MobileSuitSearchParameters parameters)
        {
            List<Featured_Item> listings = new List<Featured_Item>();
   
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 12 InventoryNumber,[Name],MA.MakeName,MO.ModelName,SerialNumber,UserID,MS.MakeModelID,TypeID,[BodyStyleID],[Year],[CenturyID],WeaponID,ColorID,Interior,MSRP,SalePrice, [Description], [Image], [Creation Date], Featured FROM [Mobile Suit] MS    Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID  INNER JOIN Make MA on MM.MakeID = MA.MakeID INNER JOIN Model MO on MM.ModelID = MO.ModelID Where 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinRate.HasValue)
                {
                    query += "AND SalePrice >= @MinRate ";
                    cmd.Parameters.AddWithValue("@MinRate", parameters.MinRate.Value);
                }

                if (parameters.MaxRate.HasValue)
                {
                    query += "AND SalePrice <= @MaxRate ";
                    cmd.Parameters.AddWithValue("@MaxRate", parameters.MaxRate.Value);
                }

                if (!string.IsNullOrEmpty(parameters.Make))
                {
                    query += "AND MA.MakeId= @Make ";
                    cmd.Parameters.AddWithValue("@Make", parameters.Make);
                }

                if (!string.IsNullOrEmpty(parameters.Model))
                {
                    query += "AND MO.ModelId = @Model ";
                    cmd.Parameters.AddWithValue("@Model", parameters.Model);
                }
                query += "AND TypeID = @TypeID ";
                cmd.Parameters.AddWithValue("@TypeID", parameters.TypeId);

                query += "ORDER BY [Creation Date] DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Featured_Item row = new Featured_Item();

                        row.InventoryNumber = (int)dr["InventoryNumber"];
                        row.Make = dr["MakeName"].ToString();
                        row.Model = dr["ModelName"].ToString();
                        row.SalePrice = (int)dr["SalePrice"];
                        row.Name = dr["Name"].ToString();

                        if (dr["Image"] != DBNull.Value)
                            row.Image = dr["Image"].ToString();

                        listings.Add(row);
                    }
                }
            }

            return listings;
        }

        public void Insert(Mobile_Suit MobileSuit)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitInsert", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@InventoryNumber", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SerialNumber", MobileSuit.SerialNumber);
                cmd.Parameters.AddWithValue("@TypeID", MobileSuit.TypeID);
                cmd.Parameters.AddWithValue("@Name", MobileSuit.Name);
                cmd.Parameters.AddWithValue("@Year", MobileSuit.Year);
                cmd.Parameters.AddWithValue("@CenturyID", MobileSuit.CenturyID);
                cmd.Parameters.AddWithValue("@MakeModelID", MobileSuit.MakeModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", MobileSuit.BodyStyleID);
                cmd.Parameters.AddWithValue("@WeaponID", MobileSuit.WeaponID);
                cmd.Parameters.AddWithValue("@ColorID", MobileSuit.ColorID);
                cmd.Parameters.AddWithValue("@Interior", MobileSuit.Interior);
                cmd.Parameters.AddWithValue("@MSRP", MobileSuit.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", MobileSuit.SalePrice);
                cmd.Parameters.AddWithValue("@Description", MobileSuit.Description);
                cmd.Parameters.AddWithValue("@Image", MobileSuit.Image);
                cmd.Parameters.AddWithValue("@UserID", MobileSuit.UserID);
                cmd.Parameters.AddWithValue("@Featured", MobileSuit.Featured);





                cn.Open();

                cmd.ExecuteNonQuery();

                MobileSuit.InventoryNumber = (int)param.Value;
               
            }
        }

        public void Update(Mobile_Suit MobileSuit)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MobileSuitUpdate", cn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;



                cmd.Parameters.AddWithValue("@InventoryNumber", MobileSuit.InventoryNumber);

                cmd.Parameters.AddWithValue("@SerialNumber", MobileSuit.SerialNumber);
                cmd.Parameters.AddWithValue("@TypeID", MobileSuit.TypeID);
                cmd.Parameters.AddWithValue("@Name", MobileSuit.Name);
                cmd.Parameters.AddWithValue("@Year", MobileSuit.Year);
                cmd.Parameters.AddWithValue("@CenturyID", MobileSuit.CenturyID);
                cmd.Parameters.AddWithValue("@MakeModelID", MobileSuit.MakeModelID);
                cmd.Parameters.AddWithValue("@BodyStyleID", MobileSuit.BodyStyleID);
                cmd.Parameters.AddWithValue("@WeaponID", MobileSuit.WeaponID);
                cmd.Parameters.AddWithValue("@ColorID", MobileSuit.ColorID);
                cmd.Parameters.AddWithValue("@Interior", MobileSuit.Interior);
                cmd.Parameters.AddWithValue("@MSRP", MobileSuit.MSRP);
                cmd.Parameters.AddWithValue("@SalePrice", MobileSuit.SalePrice);
                cmd.Parameters.AddWithValue("@Description", MobileSuit.Description);
                cmd.Parameters.AddWithValue("@Image", MobileSuit.Image);
                cmd.Parameters.AddWithValue("@UserID", MobileSuit.UserID);
                cmd.Parameters.AddWithValue("@Featured", MobileSuit.Featured);




                cn.Open();

                cmd.ExecuteNonQuery();

               

            }
        }


        public IEnumerable<Featured_Item> SaleSearch(MobileSuitSearchParametersSales parameters)
        {
            List<Featured_Item> listings = new List<Featured_Item>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                string query = "SELECT TOP 12 InventoryNumber,[Name],MA.MakeName,MO.ModelName,SerialNumber,UserID,MS.MakeModelID,TypeID,[BodyStyleID],[Year],[CenturyID],WeaponID,ColorID,Interior,MSRP,SalePrice, [Description], [Image], [Creation Date], Featured FROM [Mobile Suit] MS    Inner Join MakeModel MM on MS.MakeModelID = MM.MakeModelID  INNER JOIN Make MA on MM.MakeID = MA.MakeID INNER JOIN Model MO on MM.ModelID = MO.ModelID Where 1=1";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;

                if (parameters.MinRate.HasValue)
                {
                    query += "AND SalePrice >= @MinRate ";
                    cmd.Parameters.AddWithValue("@MinRate", parameters.MinRate.Value);
                }

                if (parameters.MaxRate.HasValue)
                {
                    query += "AND SalePrice <= @MaxRate ";
                    cmd.Parameters.AddWithValue("@MaxRate", parameters.MaxRate.Value);
                }

                if (!string.IsNullOrEmpty(parameters.Make))
                {
                    query += "AND MA.MakeId= @Make ";
                    cmd.Parameters.AddWithValue("@Make", parameters.Make);
                }

                if (!string.IsNullOrEmpty(parameters.Model))
                {
                    query += "AND MO.ModelId = @Model ";
                    cmd.Parameters.AddWithValue("@Model", parameters.Model);
                }
             
                query += "ORDER BY [Creation Date] DESC";
                cmd.CommandText = query;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Featured_Item row = new Featured_Item();

                        row.InventoryNumber = (int)dr["InventoryNumber"];
                        row.Make = dr["MakeName"].ToString();
                        row.Model = dr["ModelName"].ToString();
                        row.SalePrice = (int)dr["SalePrice"];
                        row.Name = dr["Name"].ToString();

                        if (dr["Image"] != DBNull.Value)
                            row.Image = dr["Image"].ToString();

                        listings.Add(row);
                    }
                }
            }

            return listings;
        }
    }
}
