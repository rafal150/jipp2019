using System;
using System.Data;
using System.Data.SqlClient;
using lab1.logic;
using lab1.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab1;
namespace lab1.web
{
    public partial class DataGridExample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Model1 context = new Model1())
            {
                SqlDataAdapter sde = new SqlDataAdapter("Select * from student", context);
                DataSet ds = new DataSet();
                sde.Fill(ds);
                DataGrid.DataSource = ds;
                DataGrid.DataBind();
            }
        }
    }
}


