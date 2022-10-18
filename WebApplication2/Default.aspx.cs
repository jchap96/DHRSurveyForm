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
            var connectFromConfiguration = WebConfigurationManager.ConnectionStrings["DBConnection"];
            using (SqlConnection dbConnection = new SqlConnection(connectFromConfiguration.ConnectionString))
            {
                try
                {
                    dbConnection.Open();
                    ltConnectionMessage.Text = "Connection successful";
                }
                catch (SqlException ex)
                {
                    ltConnectionMessage.Text = "Connection failed" + ex.Message;
                }
                finally
                {
                    dbConnection.Close();
                    dbConnection.Dispose();
                }
            }

        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            //Regex name_regexp = @"[A-Za-z]{2,17}";
            //Regex phone_regexp = @"[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
            string first_name = firstName.Text;
            string last_name = lastName.Text;
            string phone = phoneNum.Text;
            string dropDown_one = Dropdownlist1.SelectedValue;
            string dropDown_two = Dropdownlist2.SelectedValue;
            string dropDown_three = Dropdownlist3.SelectedValue;
            string dropDown_four = Dropdownlist4.SelectedValue;
            string dropDown_five = Dropdownlist3.SelectedValue;
            int id = 1;
            //SQL Code to be used when writing a brand new record.



            //SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
            // con.Open();

            // SqlCommand cmd =  new SqlCommand("INSERT INTO users values("+first_name+","+ last_name + ","+ phone + ","+ dropDown_one + ","+dropDown_two+"," + dropDown_three + ","+ dropDown_four+","+dropDown_five+")");

            // cmd.ExecuteNonQuery();
            // con.Close(); 
            //dataCommand.Parameters.AddWithValue("@id", id);
            //dataCommand.Parameters.AddWithValue("@firstname", first_name);
            //dataCommand.Parameters.AddWithValue("@lastname", last_name);
            //dataCommand.Parameters.AddWithValue("@phone", phone);
            //dataCommand.Parameters.AddWithValue("@entry_time", DateTime.Now);
            //dataCommand.Parameters.AddWithValue("@q1", dropDown_one);
            //dataCommand.Parameters.AddWithValue("@q2", dropDown_two);
            //dataCommand.Parameters.AddWithValue("@q3", dropDown_three);
            //dataCommand.Parameters.AddWithValue("@q4", dropDown_four);
            //dataCommand.Parameters.AddWithValue("@q5", dropDown_five);
            //dataConnection.Open();
            //dataCommand.ExecuteNonQuery();
            //dataConnection.Close();


            //var match1= Regex.Match(firstName.Text, name_regexp);
            //var match2 = Regex.Match(lastName.Text, name_regexp);
            //var match3 = Regex.Match(phone.Text, phone_regexp);
            Response.Redirect("Thankyou.aspx");


        }
    }
}