using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Net;
using System.IO;
using Ionic.Zip;

/// <summary>
/// Summary description for DownloadWebService
/// </summary>
[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class DownloadWebService : System.Web.Services.WebService {

    public DownloadWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }

    [WebMethod]
    public void Download(string searchName, string sUrlList)
    {
        List<string> urlList = new List<string>();
        while (sUrlList.Contains(";;"))
        {
            urlList.Add(sUrlList.Substring(0, sUrlList.IndexOf(";;")));
            sUrlList = sUrlList.Substring(sUrlList.IndexOf(";;") + 2);
        }

        //for (int i = 0, ii = urlList.Count; i < ii; i++)
        //{
        //    string hreflink = "http://www.adamcarolla.com/wp-content/gallery/cache/7678__150x_04-linsanity.jpg";

        //    //byte[] ba = DownloadData(hreflink);
        //    WebRequest req = WebRequest.Create(hreflink);
        //    WebResponse response = req.GetResponse();
        //    Stream stream = response.GetResponseStream();

        //    using (var zip = new ZipFile("test2"))
        //    {
        //        zip.Name = "Test";
        //        zip.Comment = "test3";
        //        zip.AddEntry("test1.jpg", stream);
        //        zip.Save(Response.OutputStream);
        //    }
        //}
    }
    
}
