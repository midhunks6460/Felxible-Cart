using backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Shop : ControllerBase
    {
        private readonly IConfiguration _configuration;

        //constructor
        public Shop(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("ProductList")]

        public Response GetAllProducts()
        { 
            List<Products> listproducts=new List<Products>();
            SqlConnection connection=new SqlConnection(_configuration.GetConnectionString("ShoppingCon").ToString());
            SqlDataAdapter da=new SqlDataAdapter("Select * from tableProducts;", connection);
            DataTable dt=new  DataTable();
            da.Fill(dt);

            Response response=new Response();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                { 
                    Products products = new Products();
                    products.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    products.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    products.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    products.ActualPrice = Convert.ToDecimal(dt.Rows[i]["ActualPrice"]);
                    products.DiscountedPrice = Convert.ToDecimal(dt.Rows[i]["DiscountedPrice"]);
                    listproducts.Add(products);
                }
                if (listproducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.listproducts = listproducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Data Found";
                    response.listproducts = null;
                }
            }
            
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listproducts = null;
            }
            return response;

        }


        [HttpPost]
        [Route("AddProduct")]

        public Response AddProduct(Products products)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ShoppingCon").ToString());

            Response response = new Response();

            if (products.ID > 0)
            { 
                SqlCommand cmd=new SqlCommand("Insert into Cart(ProductId) VALUES('"+products.ID+"')", connection);
                connection.Open();
                int i=cmd.ExecuteNonQuery();
                connection.Close();
                if (i > 0)
                { 
                    response.StatusCode=200;
                    response.StatusMessage = "Item Added";
                }
                else 
                { 
                    response.StatusCode = 200;
                    response.StatusMessage = "Item Added";
                }
            }
            else
            {
                response.StatusCode = 200;
                response.StatusMessage = "No Item Found";
            }

            return response;
        }



        [HttpGet]
        [Route("ProductListCart")]

        public Response ProductListCart()
        {
            List<Products> listproducts = new List<Products>();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("ShoppingCon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("Select P.ID,P.Name,P.Image,P.ActualPrice,P.DiscountedPrice from Cart C inner join tableProducts P on C.ID=P.ID;", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Response response = new Response();

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Products products = new Products();
                    products.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    products.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    products.Image = Convert.ToString(dt.Rows[i]["Image"]);
                    products.ActualPrice = Convert.ToDecimal(dt.Rows[i]["ActualPrice"]);
                    products.DiscountedPrice = Convert.ToDecimal(dt.Rows[i]["DiscountedPrice"]);
                    listproducts.Add(products);
                }
                if (listproducts.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.listproducts = listproducts;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "No Data Found";
                    response.listproducts = null;
                }
            }

            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No Data Found";
                response.listproducts = null;
            }
            return response;

        }
    }
}
