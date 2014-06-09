using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace BugProject
{
    public class SentenceDB
    {
        public string[] GetSentence(int peopleId, int typeId)
        {
           string[] result = null;
           try
           {
               var db = new SQLDatabaseHelper();
               DataTable recipe;
               String query = "SELECT * FROM Sentence WHERE (TypeId="+typeId+" AND PeopleId="+peopleId+")";
               recipe = db.GetDataTable(query);
               result = new string[recipe.Rows.Count];
               for (int i = 0; i < recipe.Rows.Count; i++)
               {
                   result[i] = recipe.Rows[i].ItemArray[1].ToString();
               }
               return result;
               /*foreach (DataRow r in recipe.Rows)
               {
                   MessageBox.Show(r["Sentence"].ToString());
               }*/
           }
           catch (Exception fail)
           {
               String error = "The following error has occurred:\n\n";
               error += fail.Message.ToString() + "\n\n";
               return result;
           }
       }
    }
}
