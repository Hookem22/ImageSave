using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Facebook : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string searchTerm = SearchTextBox.Text;
        Response.Redirect("~/?s=" + searchTerm);
    }

    protected void DownloadButton_Click(object sender, EventArgs e)
    {
    }
}