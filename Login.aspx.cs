using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading.Tasks;

namespace csharp_interview_test
{
    public partial class Login : System.Web.UI.Page
    {
        private FileLogger _logger;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "Username and password are required";
                return;
            }

            if(username == "admin" && password == "1234")
            {
                lblMessage.Text = "Login Successfully";
                await _logger.LogAsync($"User '{username}' logged in successfully");
            }

            else
            {
                lblMessage.Text = "Invalid credentials";
                await _logger.LogAsync($"Failed login attempt for username '{username}'.");
            }
        }
    }
}