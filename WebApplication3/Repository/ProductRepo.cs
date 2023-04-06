using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication3.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication3.Repository
{
    public class ProductRepo
    {
       
      
       

        //For Add Data into Product Table
        public bool AddProduct(ProductFirst product)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand("AddProductdata", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ProductName", product.ProductName);
            sqlCommand.Parameters.AddWithValue("@Catagory_CId", product.Catagory_CId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;



        }
        //For Delete Product Data By Id
        public bool DeleteProduct(int? id)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand("DeleteProductdata", sqlConnection);
           
            sqlCommand.Parameters.AddWithValue("@PId", id);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }
        //insted of CatagoryId using this i find Catagoryname
        //For Get Total Data Of Product
        public List<GetProduct> GetProductData()
        {
            List<GetProduct> productlist = new List<GetProduct>();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);

            SqlCommand sqlCommand = new SqlCommand("GetProduct", sqlConnection);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                GetProduct product = new GetProduct();
                product.PId = Convert.ToInt32(dataReader["PId"]);
                product.ProductName = Convert.ToString(dataReader["ProductName"]);
                product.Catagory_CId = Convert.ToInt32(dataReader["Catagory_CId"]);
                product.CatagoryName = Convert.ToString(dataReader["CatagoryName"]);

                productlist.Add(product);
            }
            dataReader.Close();
            sqlConnection.Close();

            return productlist;
        }

       
      
        

        //For Get Product Data By Id
        public ProductFirst GetProductById(int? id)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);

            ProductFirst product = new ProductFirst();
            //SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand("GetProductdataById", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@PId", id);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while(dataReader.Read())
            {
                product.PId = Convert.ToInt32(dataReader["PId"]);
                product.ProductName = Convert.ToString(dataReader["ProductName"]);
                product.Catagory_CId = Convert.ToInt32(dataReader["Catagory_CId"]);

            }
            dataReader.Close();
            sqlConnection.Close();
            return product;
        }

        //For Update Product Table Data
        public bool UpdateProduct(ProductFirst product)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["NimapInfotech"].ConnectionString);

            //SqlConnection sqlConnection = new SqlConnection();
            SqlCommand sqlCommand = new SqlCommand("UpdateProductdata", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ProductName", product.ProductName);
            sqlCommand.Parameters.AddWithValue("@Catagory_CId", product.Catagory_CId);
            sqlCommand.Parameters.AddWithValue("@PId", product.PId);
            sqlConnection.Open();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return true;
        }
    }
}
