using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;



namespace Greenshades
{
    public partial class Employee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Employee ID provided
            if (Request.QueryString["id"] != null)
            {
                int intEmployee_ID = Convert.ToInt32(Request.QueryString["id"]);
                EmployeeDetails myEmployee = new EmployeeDetails();

                

                //EmployeeDetails myEmployee = new EmployeeDetails(intEmployee_ID, "John", "JOnes", "Janitor", 1, "jjones@gmail.com", "8001234567", "8009876543", "8007771111");

                try
                {
                     myEmployee = EmployeeDB.GetEmployeeDetails(intEmployee_ID);
                }
                catch (SQLiteException ex)
                {

                    Response.Write("<script>alert('Exception: " + ex.Message + "')</script>");
                }
           
                lblEmployee_ID.Text = myEmployee.ID.ToString();
                txtEmployee_FName.Text = myEmployee.FirstName.ToString();
                txtEmployee_LName.Text = myEmployee.LastName.ToString();
                txtEmployee_JobTitle.Text = myEmployee.JobTitle.ToString();
                txtEmployeeContact_Email.Text = myEmployee.ContactEmail.ToString();
                txtEmployeeContact_HomePhone.Text = myEmployee.ContactHomePhone.ToString();
                txtEmployeeContact_CellPhone.Text = myEmployee.ContactCellPhone.ToString();
                txtEmployeeContact_Fax.Text = myEmployee.ContactFax.ToString();

            }
            else
            {
                // No ID provided, new entry
                this.btnEditEmployee.Visible = false;
                this.btnDeleteEmployee.Visible = false;                
            }


        }

        protected void btnEditEmployee_serverClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnBack_serverClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnDeleteEmployee_serverClick(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}