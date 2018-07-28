using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CulinaryApplication.Controllers
{
    public class RecipeDataAccesLayer
    {
        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Recipes;User ID=ASPNET;pwd=kulinarna;Trusted_Connection=True;MultipleActiveResultSets=true";

        //View Details
        public IEnumerable<Recipe> GetAllRecipes()
        {
            List<Recipe> lstrecipe = new List<Recipe>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllRecipes", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Recipe recipe = new Recipe();

                    recipe.ID = Convert.ToInt32(rdr["RecipeId"]);
                    recipe.Name = rdr["Name"].ToString();
                    recipe.Products = rdr["Products"].ToString();
                    recipe.Time = Convert.ToInt32(rdr["Time"]);
                    recipe.Difficulty = Convert.ToInt32(rdr["Difficulty"]);
                    recipe.Rating = Convert.ToInt32(rdr["Rating"]);

                    lstrecipe.Add(recipe);
                }
                con.Close();
            }
            return lstrecipe;
        }
        //To Add new Recipe record    
        public void AddRecipe(Recipe recipe)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddRecipe", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", recipe.Name);
                cmd.Parameters.AddWithValue("@Products", recipe.Products);
                cmd.Parameters.AddWithValue("@Time", recipe.Time);
                cmd.Parameters.AddWithValue("@Difficulty", recipe.Difficulty);
                cmd.Parameters.AddWithValue("@Rating", recipe.Rating);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To Update the records of a particluar Recipe  
        public void UpdateRecipe(Recipe recipe)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateRecipe", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RecipeId", recipe.ID);
                cmd.Parameters.AddWithValue("@Name", recipe.Name);
                cmd.Parameters.AddWithValue("@Products", recipe.Products);
                cmd.Parameters.AddWithValue("@Time", recipe.Time);
                cmd.Parameters.AddWithValue("@Difficulty", recipe.Difficulty);
                cmd.Parameters.AddWithValue("@Rating", recipe.Rating);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Get the details of a particular Recipe  
        public Recipe GetRecipeData(int? ID)
        {
            Recipe recipe = new Recipe();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM tblRecipe WHERE RecipeId= " + ID;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    recipe.ID = Convert.ToInt32(rdr["RecipeId"]);
                    recipe.Name = rdr["Name"].ToString();
                    recipe.Products = rdr["Products"].ToString();
                    recipe.Time = Convert.ToInt32(rdr["Time"]);
                    recipe.Difficulty = Convert.ToInt32(rdr["Difficulty"]);
                    recipe.Rating = Convert.ToInt32(rdr["Rating"]);
                }
            }
            return recipe;
        }

        //To Delete the record on a particular Recipe  
        public void DeleteRecipe(int? ID)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteRecipe", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@RecipeId", ID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
