using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        string CS = "data source=.; database=Northwind;integrated security=SSPI";
        protected void Page_Load(object sender, EventArgs e)
        {
           

            SqlConnection con = new SqlConnection(CS);
                            
                con.Open();
                Label1.Text = "All info about the employee with ID 8";
                SqlCommand cmd1 = new SqlCommand("select * from employees where EmployeeID=8", con);             
                GridView1.DataSource = cmd1.ExecuteReader();
                GridView1.DataBind();
                con.Close();

                con.Open();
                Label2.Text = "The list of first and last names of the employees from London";
                SqlCommand cmd2 = new SqlCommand("select FirstName,LastName from employees where City='London'", con);           
                GridView2.DataSource = cmd2.ExecuteReader();
                GridView2.DataBind();
                con.Close();

                con.Open();
                Label3.Text = "The list of first and last names of the employees whose first name begins with letter A";
                SqlCommand cmd3 = new SqlCommand("select FirstName,LastName from employees where FirstName like 'A%' ", con);
                GridView3.DataSource = cmd3.ExecuteReader();
                GridView3.DataBind();
                con.Close();

                con.Open();
                Label4.Text = "The list of first, last names and ages of the employees whose age is greater than 55. The result should be sorted by last name";
                SqlCommand cmd4 = new SqlCommand("select FirstName,LastName ,(CURRENT_TIMESTAMP-BirthDate)as ages from employees where (CURRENT_TIMESTAMP-BirthDate) > 55 order by LastName", con);
                GridView4.DataSource = cmd4.ExecuteReader();
                GridView4.DataBind();
                con.Close();

                con.Open();
                Label5.Text = "The count of employees from London";
                SqlCommand cmd5 = new SqlCommand("select count(*) from employees where city='London'", con);
                GridView5.DataSource = cmd5.ExecuteReader();
                GridView5.DataBind();
                con.Close();
          
                con.Open();
                Label6.Text = "The greatest, the smallest and the average age among the employees from London";
                SqlCommand cmd6 = new SqlCommand(" SELECT city,CONVERT(datetime,avg(CONVERT(INT, BirthDate)))as AVG,CONVERT(datetime,max(CONVERT(INT, BirthDate)))as MAX,CONVERT(datetime,min(CONVERT(INT, BirthDate)))as MIN from employees where city='London' group by city", con);
                GridView6.DataSource = cmd6.ExecuteReader();
                GridView6.DataBind();
                con.Close();

                con.Open();
                Label7.Text = "The greatest, the smallest and the average age of the employees for each city";
                SqlCommand cmd7 = new SqlCommand(" SELECT CONVERT(datetime,avg(CONVERT(INT, BirthDate)))as AVG,CONVERT(datetime,max(CONVERT(INT, BirthDate)))as MAX,CONVERT(datetime,min(CONVERT(INT, BirthDate)))as MIN from employees", con);
                GridView7.DataSource = cmd7.ExecuteReader();
                GridView7.DataBind();
                con.Close();

                con.Open();
                Label8.Text = "The greatest, the smallest and the average age of the employees for each city";
                SqlCommand cmd8 = new SqlCommand(" SELECT CONVERT(datetime,avg(CONVERT(INT, BirthDate)))as AVG,CONVERT(datetime,max(CONVERT(INT, BirthDate)))as MAX,CONVERT(datetime,min(CONVERT(INT, BirthDate)))as MIN from employees", con);
                GridView8.DataSource = cmd8.ExecuteReader();
                GridView8.DataBind();
                con.Close();

            con.Open();
            Label9.Text = "First, last names and dates of birth of the employees who celebrate their birthdays this month";
            SqlCommand cmd9 = new SqlCommand("select FirstName,LastName,BirthDate from employees where MONTH(BirthDate)=MONTH(GETDATE())", con);
            GridView9.DataSource = cmd9.ExecuteReader();
            GridView9.DataBind();
            con.Close();

            con.Open();
            Label10.Text = "First and last names of the employees who used to serve orders shipped to Madrid";
            SqlCommand cmd10 = new SqlCommand("select distinct FirstName,LastName,shipcity from employees inner join orders on employees.EmployeeID=orders.EmployeeID where shipcity='Madrid'", con);
            GridView10.DataSource = cmd10.ExecuteReader();
            GridView10.DataBind();
            con.Close();

            con.Open();
            Label11.Text = "First and last names of the employees who used to serve orders shipped to Madrid";
            SqlCommand cmd11 = new SqlCommand("select distinct FirstName,LastName,shipcity from employees inner join orders on employees.EmployeeID=orders.EmployeeID where shipcity='Madrid'", con);
            GridView11.DataSource = cmd11.ExecuteReader();
            GridView11.DataBind();
            con.Close();

            con.Open();
            Label12.Text = "The count of orders made by each customer from France";
            SqlCommand cmd12 = new SqlCommand("select count(*) from orders inner join customers on orders.shipcountry = customers.country where customers.country='France'", con);
            GridView12.DataSource = cmd12.ExecuteReader();
            GridView12.DataBind();
            con.Close();

            con.Open();
            Label13.Text = "The list of french customers’ names who used to order non-french products";
            SqlCommand cmd13 = new SqlCommand("select distinct ContactName from Customers left join Orders on Customers.country <> Orders.ShipCountry where country='France'", con);
            GridView13.DataSource = cmd13.ExecuteReader();
            GridView13.DataBind();
            con.Close();

            con.Open();
            Label14.Text = "The total ordering sum calculated for each country of customer";
            SqlCommand cmd14 = new SqlCommand("select count(orders.shipcountry),customers.country from orders inner join customers on orders.shipcountry=customers.country group by customers.country", con);
            GridView14.DataSource = cmd14.ExecuteReader();
            GridView14.DataBind();
            con.Close();

            con.Open();
            Label15.Text = "The list of cities where employees and customers are from and where orders have been made to. Duplicates should be eliminated.";
            SqlCommand cmd15 = new SqlCommand("SELECT distinct Orders.shipcity FROM((Orders INNER JOIN Customers ON Orders.shipcity = Customers.city) INNER JOIN employees ON Orders.shipcity = employees.city)", con);
            GridView15.DataSource = cmd15.ExecuteReader();
            GridView15.DataBind();
            con.Close();     
        }
        private void GetDatafromDB()
        {
            SqlConnection con = new SqlConnection(CS);
            string strSelectQuery = "select * from Employees";
            SqlDataAdapter da = new SqlDataAdapter(strSelectQuery,con);

            DataSet ds = new DataSet();
            da.Fill(ds,"tblEmployees");

            ds.Tables["tblEmployees"].PrimaryKey = new DataColumn[] { ds.Tables["tblEmployees"].Columns["EmployeeID"] };
            Cache.Insert("DATASET",ds,null,DateTime.Now.AddHours(24),System.Web.Caching.Cache.NoSlidingExpiration);

            gvEmployees.DataSource = ds;
            gvEmployees.DataBind();

            lbMessage.Text = "Data loaded from database";
        }

        private void GetDataFromCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                gvEmployees.DataSource = ds;
                gvEmployees.DataBind();
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetDatafromDB();
        }

        protected void gvEmployees_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void gvEmployees_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["tblEmployees"].Rows.Find(e.Keys["EmployeeID"]);
                dr["LastName"] = e.NewValues["LastName"];
                dr["FirstName"] = e.NewValues["FirstName"];
                dr["Title"] = e.NewValues["Title"];
                dr["TitleOfCourtesy"] = e.NewValues["TitleOfCourtesy"];
                dr["BirthDate"] = e.NewValues["BirthDate"];
                dr["HireDate"] = e.NewValues["HireDate"];
                dr["Address"] = e.NewValues["Address"];
                dr["City"] = e.NewValues["City"];
                dr["Region"] = e.NewValues["Region"];
                dr["PostalCode"] = e.NewValues["PostalCode"];
                dr["Country"] = e.NewValues["Country"];
                dr["HomePhone"] = e.NewValues["HomePhone"];
                dr["Extension"] = e.NewValues["Extension"];
                dr["Photo"] = e.NewValues["Photo"];
                dr["Notes"] = e.NewValues["Notes"];
                dr["ReportsTo"] = e.NewValues["ReportsTo"];
                dr["PhotoPath"] = e.NewValues["PhotoPath"];
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                gvEmployees.EditIndex = -1;
                GetDataFromCache();
            }
        }
       
        protected void gvEmployees_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployees.EditIndex = -1;
            GetDataFromCache();
        }

        protected void gvEmployees_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                DataRow dr = ds.Tables["tblEmployees"].Rows.Find(e.Keys["EmployeeID"]);
                dr.Delete();

                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            
                GetDataFromCache();
            }
        }

        protected void btnUpdateDB_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(CS);
            string strSelectQuery = "select * from Employees";
            SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);

            DataSet ds = (DataSet)Cache["DATASET"];
            string strUpdateCommand = "update Employees set LastName=@LastName,FirstName=@FirstName,Title=@Title,TitleOfCourtesy=@TitleOfCourtesy,BirthDate=@BirthDate,HireDate=@HireDate,Address=@Address,City=@City,Region=@Region,PostalCode=@PostalCode,Country=@Country,HomePhone=@HomePhone,Extension=@Extension,Photo=@Photo,Notes=@Notes,ReportsTo=@ReportsTo,PhotoPath=@PhotoPath where EmployeeID=@EmployeeID";
            SqlCommand updateCommand = new SqlCommand(strUpdateCommand,con);
            updateCommand.Parameters.Add("@LastName",SqlDbType.NVarChar,20,"LastName");
            updateCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 10, "FirstName");
            updateCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 30, "Title");
            updateCommand.Parameters.Add("@TitleOfCourtesy", SqlDbType.NVarChar, 20, "TitleOfCourtesy");
            updateCommand.Parameters.Add("@BirthDate", SqlDbType.DateTime,0, "BirthDate");
            updateCommand.Parameters.Add("@HireDate", SqlDbType.DateTime, 0, "HireDate");
            updateCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 60, "Address");
            updateCommand.Parameters.Add("@City", SqlDbType.NVarChar, 15, "City");
            updateCommand.Parameters.Add("@Region", SqlDbType.NVarChar, 15, "Region");
            updateCommand.Parameters.Add("@PostalCode", SqlDbType.NVarChar, 10, "PostalCode");
            updateCommand.Parameters.Add("@Country", SqlDbType.NVarChar, 15, "Country");
            updateCommand.Parameters.Add("@HomePhone", SqlDbType.NVarChar, 24, "HomePhone");
            updateCommand.Parameters.Add("@Extension", SqlDbType.NVarChar,4, "Extension");
            updateCommand.Parameters.Add("@Photo", SqlDbType.Image,0, "Photo");
            updateCommand.Parameters.Add("@Notes", SqlDbType.NText,0, "Notes");
            updateCommand.Parameters.Add("@ReportsTo", SqlDbType.Int, 0, "ReportsTo");
            updateCommand.Parameters.Add("@PhotoPath", SqlDbType.NVarChar, 255, "PhotoPath");
            updateCommand.Parameters.Add("@EmployeeID", SqlDbType.Int,0, "EmployeeID");

            da.UpdateCommand = updateCommand;

            string strDeleteCommand = "Delete from Employees where id=@id";
            SqlCommand deleteCommand = new SqlCommand(strDeleteCommand,con);
            deleteCommand.Parameters.Add("@id",SqlDbType.Int,0,"id");
            da.DeleteCommand = deleteCommand;

            da.Update(ds,"tblEmployees");
            lbMessage.Text = "Database Table Updated";
        }
    }
}