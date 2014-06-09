using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BugProject
{
   public class SQLDatabaseHelper
   {
       public DataTable GetDataTable(string queryString)
       {
           var dataTable = new DataTable();
           try
           {
               var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDataBase"].ConnectionString);
               connection.Open();
               var cmd = new SqlCommand(queryString, connection);
               SqlDataReader reader = cmd.ExecuteReader();
               dataTable.Load(reader);
               connection.Close();
           }
           catch (Exception e)
           {
               throw new Exception(e.Message);
           }
           return dataTable;
       }

       public int ExecuteNonQuery(string queryString)
       {
           var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDataBase"].ConnectionString);
           connection.Open();
           var cmd = new SqlCommand(queryString, connection);
           int rowsUpdated = cmd.ExecuteNonQuery();
           connection.Close();
           return rowsUpdated;
       }

       public string ExecuteScalar(string queryString)
       {
           var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDataBase"].ConnectionString);
           connection.Open();
           var cmd = new SqlCommand(queryString, connection);
           object value = cmd.ExecuteScalar();
           connection.Close();
           if (value != null)
           {
               return value.ToString();
           }
           return "";
       }

       public bool Update(String tableName, Dictionary<String, String> data, String where)
       {
           String vals = "";
           Boolean returnCode = true;
           if (data.Count >= 1)
           {
               foreach (KeyValuePair<String, String> val in data)
               {
                   vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
               }
               vals = vals.Substring(0, vals.Length - 1);
           }
           try
           {
               this.ExecuteNonQuery(String.Format("update {0} set {1} where {2};", tableName, vals, where));
           }
           catch
           {
               returnCode = false;
           }
           return returnCode;
       }

       public bool Delete(String tableName, String where)
       {
           Boolean returnCode = true;
           try
           {
               this.ExecuteNonQuery(String.Format("delete from {0} where {1};", tableName, where));
           }
           catch (Exception fail)
           {
               Console.WriteLine(fail.Message);
               returnCode = false;
           }
           return returnCode;
       }

       public bool Insert(String tableName, Dictionary<String, String> data)
       {
           String columns = "";
           String values = "";
           Boolean returnCode = true;
           foreach (KeyValuePair<String, String> val in data)
           {
               columns += String.Format(" {0},", val.Key.ToString());
               values += String.Format(" '{0}',", val.Value);
           }
           columns = columns.Substring(0, columns.Length - 1);
           values = values.Substring(0, values.Length - 1);
           try
           {
               this.ExecuteNonQuery(String.Format("insert into {0}({1}) values({2});", tableName, columns, values));
           }
           catch (Exception fail)
           {
               Console.WriteLine(fail.Message);
               returnCode = false;
           }
           return returnCode;
       }

    }
}


//Query:
/*try
{
	db = new SQLiteDatabase();
	DataTable recipe;
	String query = "select NAME \"Name\", DESCRIPTION \"Description\",";
	query += "PREP_TIME \"Prep Time\", COOKING_TIME \"Cooking Time\"";
	query += "from RECIPE;";
	recipe = db.GetDataTable(query);
	// The results can be directly applied to a DataGridView control
	recipeDataGrid.DataSource = recipe;
	// Or looped through for some other reason
	foreach (DataRow r in recipe.Rows)
	{
		MessageBox.Show(r[0].ToString());
		MessageBox.Show(r[1].ToString());
		MessageBox.Show(r["Prep Time"].ToString());
		MessageBox.Show(r["Cooking Time"].ToString());
	}
}
catch(Exception fail)
{
	String error = "The following error has occurred:\n\n";
	error += fail.Message.ToString() + "\n\n";
	MessageBox.Show(error);
	this.Close();
}


//Insert:
db = new SQLiteDatabase();
Dictionary<String, String> data = new Dictionary<String, String>();
data.Add("NAME", nameTextBox.Text);
data.Add("DESCRIPTION", descriptionTextBox.Text);
data.Add("PREP_TIME", prepTimeTextBox.Text);
data.Add("COOKING_TIME", cookingTimeTextBox.Text);
data.Add("COOKING_DIRECTIONS", "Placeholder");
try
{
		db.Insert("RECIPE", data);
}
catch(Exception crap)
{
	MessageBox.Show(crap.Message);
}


//Update:
db = new SQLiteDatabase();
Dictionary<String, String> data = new Dictionary<String, String>();
DataTable rows;
data.Add("NAME", nameTextBox.Text);
data.Add("DESCRIPTION", descriptionTextBox.Text);
data.Add("PREP_TIME", prepTimeTextBox.Text);
data.Add("COOKING_TIME", cookingTimeTextBox.Text);
try
{
	db.Update("RECIPE", data, String.Format("RECIPE.ID = {0}", this.RecipeID));
}
catch(Exception crap)
{
	MessageBox.Show(crap.Message);
}


//Delete
db = new SQLiteDatabase();
String recipeID = "12";
db.Delete("RECIPE", String.Format("ID = {0}", recipeID));
db.Delete("HAS_INGREDIENT", String.Format("ID = {0}", recipeID));
 
*/