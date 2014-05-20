using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using Ionic.Zip;
using System.Web.UI.HtmlControls;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string searchTerm = Request.QueryString["s"];
            if (searchTerm != null && searchTerm != "")
            {
                SearchTextBox.Text = searchTerm;
                SearchButton_Click(null, null);
            }
            SearchTextBox.Attributes.Add("onkeypress", "return ReturnPress(event,'" + SearchButton.ClientID + "')");
        }
    }
    protected void SearchButton_Click(object sender, EventArgs e)
    {
        //string searchTerm = SearchTextBox.Text;
        //searchTerm = searchTerm.Replace(" ", "+");
        //string bingUrl = "http://www.bing.com/images/search?q=" + searchTerm;

        //string html = GetPageHTML(bingUrl);
        //List<Image> imageList = new List<Image>();
        //string downloadText = "";
        //int i = 0;
        //while (html.Contains("imgurl"))// && i < 20)
        //{
        //    Image image = Image.LoadNew();
        //    image.ImageID = i;
        //    html = html.Substring(html.IndexOf("imgurl") + 13);
        //    if (!html.Contains("&quot"))
        //    {
        //        break;
        //    }
        //    image.ImgUrl = html.Substring(0, html.IndexOf("&quot"));
        //    downloadText += html.Substring(0, html.IndexOf("&quot")) + ";;";

        //    html = html.Substring(html.IndexOf("w:&quot;") + 8);
        //    int width = 0;
        //    if (int.TryParse(html.Substring(0, html.IndexOf("&")), out width))
        //    {
        //        image.Width = width;
        //    }

        //    html = html.Substring(html.IndexOf("h:&quot;") + 8);
        //    int height = 0;
        //    if (int.TryParse(html.Substring(0, html.IndexOf("&")), out height))
        //    {
        //        image.Height = height;
        //    }

        //    html = html.Substring(html.IndexOf("src=") + 5);
        //    image.Src = html.Substring(0, html.IndexOf("&amp"));

        //    imageList.Add(image);
        //    i++;
        //}

        //if (imageList.Count < 20)
        //{
        //    bingUrl = "https://www.google.com/search?q=" + searchTerm + "&tbm=isch";
        //    html = GetPageHTML(bingUrl);

        //    while (html.Contains("imgurl"))// && i < 20)
        //    {
        //        Image image = Image.LoadNew();
        //        image.ImageID = i;
        //        html = html.Substring(html.IndexOf("imgurl") + 7);
        //        image.ImgUrl = html.Substring(0, html.IndexOf("&amp;"));
        //        downloadText += html.Substring(0, html.IndexOf("&amp;")) + ";;";

        //        html = html.Substring(html.IndexOf("&amp;h=") + 7);
        //        int height = 0;
        //        if (int.TryParse(html.Substring(0, html.IndexOf("&")), out height))
        //        {
        //            image.Height = height;
        //        }

        //        html = html.Substring(html.IndexOf("&amp;w=") + 7);
        //        int width = 0;
        //        if (int.TryParse(html.Substring(0, html.IndexOf("&")), out width))
        //        {
        //            image.Width = width;
        //        }

        //        html = html.Substring(html.IndexOf("src=") + 5);
        //        image.Src = html.Substring(0, html.IndexOf("\">"));

        //        imageList.Add(image);
        //        i++;
        //    }
        //}

        string searchTerm = SearchTextBox.Text;
        searchTerm = searchTerm.Replace(" ", "+");
        string googleUrl = "https://www.google.com/search?q=" + searchTerm + "&tbm=isch";

        string html = GetPageHTML(googleUrl);
        List<Image> imageList = new List<Image>();
        string downloadText = "";
        int i = 0;
        while (html.Contains("imgurl"))// && i < 20)
        {
            Image image = Image.LoadNew();
            image.ImageID = i;
            html = html.Substring(html.IndexOf("imgurl") + 7);
            image.ImgUrl = html.Substring(0, html.IndexOf("&amp;"));
            downloadText += html.Substring(0, html.IndexOf("&amp;")) + ";;";

            html = html.Substring(html.IndexOf("&amp;h=") + 7);
            int height = 0;
            if (int.TryParse(html.Substring(0, html.IndexOf("&")), out height))
            {
                image.Height = height;
            }

            html = html.Substring(html.IndexOf("&amp;w=") + 7);
            int width = 0;
            if (int.TryParse(html.Substring(0, html.IndexOf("&")), out width))
            {
                image.Width = width;
            }

            html = html.Substring(html.IndexOf("src=") + 5);
            image.Src = html.Substring(0, html.IndexOf("\">"));

            imageList.Add(image);
            i++;
        }

        DownloadTextBox.Text = downloadText;

        ImageRepeater.DataSource = imageList;
        ImageRepeater.DataBind();

        startContent.Visible = false;
        left.Visible = true;
        right.Visible = true;

        left.Attributes.Add("class", "");

        Email email = Email.LoadNew("search@gallerysave.com", "williamallenparks@gmail.com", "Gallery Save Search", searchTerm);
        email.Send();
    }

    private static string GetPageHTML(string strURL)
    {
        try
        {
            // the html retrieved from the page
            string strResult;
            System.Net.WebResponse objResponse;
            System.Net.WebRequest objRequest = System.Net.HttpWebRequest.Create(strURL);
            objResponse = objRequest.GetResponse();
            // the using keyword will automatically dispose the object 
            // once complete
            using (System.IO.StreamReader sr =
            new System.IO.StreamReader(objResponse.GetResponseStream()))
            {
                strResult = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return strResult;
        }
        catch
        {
            //TODO Send email or something
            return "";
        }
    }

    public static bool saveImageByUrlToDisk(string url, string filename, out string imageType)
    {
        imageType = "";

        WebResponse response = null;
        Stream remoteStream = null;
        StreamReader readStream = null;
        try
        {
            WebRequest request = WebRequest.Create(url);
            if (request != null)
            {
                response = request.GetResponse();
                if (response != null)
                {
                    remoteStream = response.GetResponseStream();


                    // analyze image type, image extension
                    string content_type = response.Headers["Content-type"];

                    imageType = content_type;

                    if (content_type == "image/jpeg" || content_type == "image/jpg")
                    {
                        imageType = "jpg";
                    }
                    else if (content_type == "image/png")
                    {
                        imageType = "png";
                    }
                    else if (content_type == "image/gif")
                    {
                        imageType = "gif";
                    }
                    else
                    {
                        imageType = "";

                        return false;
                    }

                    readStream = new StreamReader(remoteStream);

                    Stream fw = File.Open(filename, FileMode.Create);

                    //
                    byte[] buf = new byte[256];
                    int count = remoteStream.Read(buf, 0, 256);
                    while (count > 0)
                    {
                        fw.Write(buf, 0, count);

                        count = remoteStream.Read(buf, 0, 256);
                    }

                    fw.Close();
                }
            }
        }
        finally
        {
            if (response != null) response.Close();
            if (remoteStream != null) remoteStream.Close();
        }

        return true;
    }

    protected void Test1Button_Click(object sender, EventArgs e)
    {
        string hreflink = "http://www.adamcarolla.com/wp-content/gallery/cache/7678__150x_04-linsanity.jpg";

        //byte[] ba = DownloadData(hreflink);
        WebRequest req = WebRequest.Create(hreflink);
        WebResponse response = req.GetResponse();
        Stream stream = response.GetResponseStream();

        using (var zip = new ZipFile("test2"))
        {
            zip.Name = "Test";
            zip.Comment = "test3";
            zip.AddEntry("test1.jpg", stream);
            zip.Save(Response.OutputStream);
        }



            //Uri uri = new Uri(hreflink);
            //string filename = Path.GetFileName(uri.LocalPath);

            //byte[] byteArray = File.ReadAllBytes(filename);

            //HttpContext.Current.Response.ClearContent();
            //HttpContext.Current.Response.Clear();
            //HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + "test.jpg");
            //HttpContext.Current.Response.ContentType = "jpg";
            ////HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + "test.zip");
            ////HttpContext.Current.Response.ContentType = "application/zip";
            //HttpContext.Current.Response.BinaryWrite(ba);
            //HttpContext.Current.Response.End();


        }

    private byte[] DownloadData(string Url)
    {
        string empty = string.Empty;
        return DownloadData(Url, out empty);
    }

    private byte[] DownloadData(string Url, out string responseUrl)
    {
        byte[] downloadedData = new byte[0];
        try
        {
            //Get a data stream from the url  
            WebRequest req = WebRequest.Create(Url);
            WebResponse response = req.GetResponse();
            Stream stream = response.GetResponseStream();

            responseUrl = response.ResponseUri.ToString();

            //Download in chuncks  
            byte[] buffer = new byte[1024];

            //Get Total Size  
            int dataLength = (int)response.ContentLength;

            //Download to memory  
            //Note: adjust the streams here to download directly to the hard drive  
            MemoryStream memStream = new MemoryStream();
            while (true)
            {
                //Try to read the data  
                int bytesRead = stream.Read(buffer, 0, buffer.Length);

                if (bytesRead == 0)
                {
                    break;
                }
                else
                {
                    //Write the downloaded data  
                    memStream.Write(buffer, 0, bytesRead);
                }
            }

            //Convert the downloaded stream to a byte array  
            downloadedData = memStream.ToArray();

            //Clean up  
            stream.Close();
            memStream.Close();
        }
        catch (Exception)
        {
            responseUrl = string.Empty;
            return new byte[0];
        }

        return downloadedData;
    }




    protected void DownloadButton_Click(object sender, EventArgs e)
    {
        string searchTerm = SearchTextBox.Text;
        string sUrlList = DownloadTextBox.Text;
        List<string> urlList = new List<string>();
        while (sUrlList.Contains(";;"))
        {
            urlList.Add(sUrlList.Substring(0, sUrlList.IndexOf(";;")));
            sUrlList = sUrlList.Substring(sUrlList.IndexOf(";;") + 2);
        }

        Response.Clear();
        Response.BufferOutput = false;
        Response.ContentType = "application/zip";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + searchTerm + ".zip");

        using (var zip = new ZipFile())
        {
            for (int i = 0, ii = urlList.Count; i < ii; i++)
            {
                string hreflink = urlList[i].ToString();

                try
                {
                    WebRequest req = WebRequest.Create(hreflink);
                    WebResponse response = req.GetResponse();
                    Stream stream = response.GetResponseStream();

                    string content_type = response.Headers["Content-type"];
                    string imageType = content_type;

                    if (content_type == "image/jpeg" || content_type == "image/jpg")
                    {
                        imageType = ".jpg";
                    }
                    else if (content_type == "image/png")
                    {
                        imageType = ".png";
                    }
                    else if (content_type == "image/gif")
                    {
                        imageType = ".gif";
                    }
                    else
                    {
                        continue;
                    }

                    zip.AddEntry(searchTerm + (i + 1).ToString() + imageType, stream);
                }
                catch
                {
                }
            }

            zip.Save(Response.OutputStream);
        }

        Response.Close();
        Response.End();
    }
}
