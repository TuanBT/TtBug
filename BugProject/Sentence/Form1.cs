using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sentence
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvSentence.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            FillAllCombobox();
        }

        private void btnPrefresh_Click(object sender, EventArgs e)
        {
            ShowData(getIDType(cbbType.Text), getIDPeople(cbbPeople.Text), getIDPeople(cbbAuthor.Text));
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Insert(txtSentence.Text, getIDType(cbbType.Text), getIDPeople(cbbPeople.Text),
                  getIDPeople(cbbAuthor.Text));
            ShowData(getIDType(cbbType.Text), getIDPeople(cbbPeople.Text), getIDPeople(cbbAuthor.Text));
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowsIndex = dgvSentence.CurrentRow.Index;
            Update((int)dgvSentence.Rows[rowsIndex].Cells["ID"].Value, txtSentence.Text, getIDType(cbbType.Text), getIDPeople(cbbPeople.Text),
                   getIDPeople(cbbAuthor.Text));
            ShowData(getIDType(cbbType.Text), getIDPeople(cbbPeople.Text), getIDPeople(cbbAuthor.Text));
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int rowsIndex = dgvSentence.CurrentRow.Index;
            Delete((int)dgvSentence.Rows[rowsIndex].Cells["ID"].Value);
            ShowData(getIDType(cbbType.Text), getIDPeople(cbbPeople.Text), getIDPeople(cbbAuthor.Text));
        }

        private void dgvSentence_SelectionChanged(object sender, EventArgs e)
        {
            int rowsIndex = dgvSentence.CurrentRow.Index;
            txtSentence.Text = dgvSentence.Rows[rowsIndex].Cells["Câu"].Value.ToString();
            cbbType.Text = dgvSentence.Rows[rowsIndex].Cells["Kiểu câu"].Value.ToString();
            cbbPeople.Text = dgvSentence.Rows[rowsIndex].Cells["Viết cho"].Value.ToString();
            try
            {
                cbbAuthor.Text = getStringPeople((int)dgvSentence.Rows[rowsIndex].Cells["Người viết"].Value);
            }
            catch (Exception)
            {
                cbbAuthor.Text = "";
            }
            lblCount.Text = txtSentence.Text.Length.ToString();
        }

        private void txtSentence_TextChanged(object sender, EventArgs e)
        {
            int count = txtSentence.Text.Length;
            lblCount.Text = count.ToString();
            if(count>48)
            {
                lblCount.ForeColor = Color.Red;
                lblCount.BackColor = Color.Yellow;
            }
            else
            {
                lblCount.ForeColor = Color.Black;
                lblCount.BackColor = SystemColors.Control;
            }
        }

        public void ShowData(int type, int people, int author)
        {
            try
            {
                var db = new SQLDatabaseHelper();
                DataTable recipe;
                String query =
                    "SELECT  s.ID,s.Sentence AS 'Câu',t.Description AS 'Kiểu câu',p.RealName AS 'Viết cho',s.Author AS 'Người viết' " +
                    "FROM Sentence s, TypeSentence t, People p " +
                    "WHERE (s.TypeId = t.ID AND s.PeopleId = p.ID";
                if (type != 0)
                {
                    query += " AND s.TypeId =" + type;
                }
                if (people != 0)
                {
                    query += " AND s.PeopleId =" + people;
                }
                if (author != 0)
                {
                    query += " AND s.Author =" + author;
                }
                query += ")";
                recipe = db.GetDataTable(query);
                dgvSentence.DataSource = recipe;
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
            }
        }

        public void FillAllCombobox()
        {
            try
            {
                var db = new SQLDatabaseHelper();
                DataTable recipe;
                String query = "SELECT * FROM TypeSentence";
                recipe = db.GetDataTable(query);
                if (recipe != null)
                {
                    foreach (DataRow r in recipe.Rows)
                    {
                        cbbType.Items.Add(r["Description"].ToString());
                    }
                }
                query = "SELECT * FROM People";
                recipe = db.GetDataTable(query);
                if (recipe != null)
                {
                    foreach (DataRow r in recipe.Rows)
                    {
                        cbbPeople.Items.Add(r["RealName"].ToString());
                        cbbAuthor.Items.Add(r["RealName"].ToString());
                    }
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
            }
        }

        public int getIDType(string str)
        {
            if(str=="")
            {
                return 0;
            }
            int result = 1;
            try
            {
                var db = new SQLDatabaseHelper();
                DataTable recipe;
                String query = "SELECT * FROM TypeSentence WHERE Description LIKE N'%" + str + "%'";
                recipe = db.GetDataTable(query);
                if (recipe != null)
                {
                    foreach (DataRow r in recipe.Rows)
                    {
                        result = (int)r["ID"];
                    }
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
            }
            return result;
        }

        public int getIDPeople(string str)
        {
            if(str=="")
            {
                return 0;
            }
            int result = 1;
            try
            {
                var db = new SQLDatabaseHelper();
                DataTable recipe;
                String query = "SELECT * FROM People WHERE RealName LIKE N'%" + str + "%'";
                recipe = db.GetDataTable(query);
                if (recipe != null)
                {
                    foreach (DataRow r in recipe.Rows)
                    {
                        result = (int)r["ID"];
                    }
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
            }
            return result;
        }

        public string getStringTypeSentence(int Id)
        {

            string result = "";
            try
            {
                var db = new SQLDatabaseHelper();
                DataTable recipe;
                String query = "SELECT * FROM TypeSentence WHERE ID =" + Id;
                recipe = db.GetDataTable(query);
                if (recipe != null)
                {
                    foreach (DataRow r in recipe.Rows)
                    {
                        result = (string)r["Décription"];
                    }
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
            }
            return result;
        }

        public string getStringPeople(int Id)
        {
           
            string result = "";
            try
            {
                var db = new SQLDatabaseHelper();
                DataTable recipe;
                String query = "SELECT * FROM People WHERE ID ="+Id;
                recipe = db.GetDataTable(query);
                if (recipe != null)
                {
                    foreach (DataRow r in recipe.Rows)
                    {
                        result = (string)r["RealName"];
                    }
                }
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
            }
            return result;
        }

        public bool Update(int sentenceId,string sentence,int typeId,int peopleId, int author)
        {
            var db = new SQLDatabaseHelper();
            var data = new Dictionary<String, String>();
           // DataTable rows;
            data.Add("Sentence", sentence);
            data.Add("TypeId", typeId.ToString());
            data.Add("PeopleId", peopleId.ToString());
            data.Add("Author", peopleId.ToString());
            try
            {
                db.Update("Sentence", data, String.Format("ID = {0}", sentenceId));
                return true;
            }
            catch (Exception crap)
            {
                return false;
            }
        }

        public bool Insert(string sentence,int typeId,int peopleId, int author)
        {
            var db = new SQLDatabaseHelper();
            var data = new Dictionary<String, String>();
            data.Add("Sentence", sentence);
            data.Add("TypeId", typeId.ToString());
            data.Add("PeopleId", peopleId.ToString());
            data.Add("Author", peopleId.ToString());
            try
            {
                db.Insert("Sentence", data);
                return true;
            }
            catch (Exception crap)
            {
                MessageBox.Show(crap.Message);
                return false;
            }
        }

        public bool Delete(int sentenceId)
        {
            var db = new SQLDatabaseHelper();
            try
            {
                db.Delete("Sentence", String.Format("ID = {0}", sentenceId));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //db.Delete("HAS_INGREDIENT", String.Format("ID = {0}", sentenceId));
        }


    }
}
