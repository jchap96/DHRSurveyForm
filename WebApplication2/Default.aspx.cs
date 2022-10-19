using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Data;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // Trying out Database connection 
            //var connectFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            //using (SqlConnection dbConnection = new SqlConnection(connectFromConfiguration.ConnectionString))
            //{
            //    try
            //    {
            //        dbConnection.Open();
            //       // ltConnectionMessage.Text = "Connection successful";
            //    }
            //    catch (SqlException ex)
            //    {
            //       // ltConnectionMessage.Text = "Connection failed" + ex.Message;
            //    }
            //    finally
            //    {
            //        dbConnection.Close();
            //        dbConnection.Dispose();
            //    }
            //}


        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
           
            
            // Regex variables to validate in server 
            Regex name_regexp =  new Regex(@"[A-Za-z]{2,17}");
            Regex phone_regexp = new Regex(@"[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$");

            // Values from the form 
            string first_name = firstName.Text;
            string last_name = lastName.Text;
            string phone = phoneNum.Text;
            string[] dropdowns = new string[] { Dropdownlist1.SelectedValue, Dropdownlist2.SelectedValue, Dropdownlist3.SelectedValue, Dropdownlist4.SelectedValue, Dropdownlist5.SelectedValue };

            // Array if errors are found on the form 
            string[] errors = new string[] { "Invalid name or empty", "Invalid phone number", "Please fill the assesment"};
            bool error_flag = false;
            ErrorName.Text = "";
            ErrorOptions.Text = "";
            ErrorPhone.Text = "";
            //Checks if the phone, first_name and last_name are valid with regex 

            var regex_first_name =name_regexp.Match(first_name);
            var regex_last_name = name_regexp.Match(last_name);
            var regex_phone = phone_regexp.Match(phone);
          

            // Checks if the regex matches the first and last name 
            if (regex_first_name.Value == "" || regex_last_name.Value == "")
            {
                error_flag = true;
                ErrorName.Text = errors[0]; 
            }
             
            // Checks if the regex returned something for the phone input 
            // If it did parse the special characters form the phone 
            if (regex_phone.Value == "")
            {
                ErrorPhone.Text = errors[1];
                error_flag = true; 
            }
            else
            {
                phone = Regex.Replace(phone, "[^0-9]", "");
            }
            //Checks if the Survey is missing filled inputs 
            for (int i= 0; i< 5; i++)
            {
                if (Convert.ToInt32(dropdowns[i]) <= 0)
                {

                    ErrorOptions.Text = errors[2];
                    error_flag = true;
                }
            }
          
          
            if(error_flag == false)
            {
                //Creates a connection for database, creates a command, and sanitizes values to prevent Injection 
                SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
                SqlCommand sqlComm = conn.CreateCommand();
                sqlComm.CommandText = @"INSERT INTO users VALUES (@first,@last,@phone,@datetime,@q1,@q2,@q3,@q4,@q5);";
                //sqlComm.Parameters.Add("@id", SqlDbType.Int).Value = id;
                sqlComm.Parameters.Add("@first", SqlDbType.VarChar).Value = first_name;
                sqlComm.Parameters.Add("@last", SqlDbType.VarChar).Value = last_name;
                sqlComm.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
                sqlComm.Parameters.Add("@datetime", SqlDbType.DateTime).Value = DateTime.Now;
                for (int i = 1; i < 6; i++)
                {
                    string question = $"@q{@i}";
                    sqlComm.Parameters.Add(question, SqlDbType.VarChar).Value = dropdowns[i - 1];
                }

                // try catch to see if there are any errors with the query executed
                // closes the connection at the end 
                try
                {
                    conn.Open();
                    sqlComm.ExecuteNonQuery();
                    conn.Close();
                }

                catch (SqlException ex)
                {
                    ltConnectionMessage.Text = "Connection failed" + ex.Message;
                }

                finally
                {
                    conn.Close();
                    conn.Dispose();
                }

                Context.Response.Redirect("/Thankyou.aspx");
            }

       
    
        }
    }
}