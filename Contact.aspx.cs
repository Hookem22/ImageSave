using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SearchTextBox.Attributes.Add("onkeypress", "return ReturnPress(event,'" + SearchButton.ClientID + "')");
        }
    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string searchTerm = SearchTextBox.Text;
        Response.Redirect("~/?s=" + searchTerm);
    }

    protected void SendButton_Click(object sender, EventArgs e)
    {
        string body = "";

        body += "Contact Name: " + NameTextBox.Text + "<br />";
        body += "Contact Email: " + EmailTextBox.Text + "<br />";
        body += BodyTextBox.Text;

        Email email = Email.LoadNew("contact@gallerysave.com", "williamallenparks@gmail.com", "Gallery Save Contact", body);
        email.Send();

        ThanksLabel.Text = "Your email has been sent. Thanks for your feedback.";
    }
}
