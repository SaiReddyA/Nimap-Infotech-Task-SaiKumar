using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication3.Repository
{
    public class CatagoryRepo 
    {
       
       

        //For Adding Data In to Catagory table
        public bool AddCatagory(CatagoryFirst Catagory)
        {
                SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("AddCatagory", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CatagoryName", Catagory.CatagoryName);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        //For Delete Catagory Data By Id
        public bool DeleteCatagory(int? id)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("DeleteCatagory", sqlConnection);

            sqlCommand.Parameters.AddWithValue("@CId", id);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }

        //For Get Total Catagory Data
        public List<CatagoryFirst> GetCatagory()
        {
            List<CatagoryFirst> catagorylist = new List<CatagoryFirst>();

            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("GetCatagory", sqlConnection);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                CatagoryFirst catagory = new CatagoryFirst();
                catagory.CId = Convert.ToInt32(dataReader["CId"]);
                catagory.CatagoryName = Convert.ToString(dataReader["CatagoryName"]);

                catagorylist.Add(catagory);
            }
            dataReader.Close();
            sqlConnection.Close();
            return catagorylist;

        }
        //For Get CatagoryData By Id
        public CatagoryFirst GetCatagoryById(int? id)
        {
            CatagoryFirst catagory = new CatagoryFirst();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("GetByIdCatagory", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CId", id);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                catagory.CId = Convert.ToInt32(dataReader["CId"]);
                catagory.CatagoryName = Convert.ToString(dataReader["CatagoryName"]);

            }
            dataReader.Close();
            sqlConnection.Close();

            return catagory;
        }
        //For Updating Catagory Details
        public bool UpdateCatagory(CatagoryFirst Catagory)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);
            SqlCommand sqlCommand = new SqlCommand("UpdateCatagory", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@CId", Catagory.CId);
            sqlCommand.Parameters.AddWithValue("@CatagoryName", Catagory.CatagoryName);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }
    }
}