using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// Summary description for Image
/// <summary>
public class Image
{
    #region Declarations
    private int m_ImageID;
    private string m_Src;
    private string m_ImgUrl;
    private int m_Width;
    private int m_Height;
    private string m_SearchTerm;
    #endregion //Declarations

    #region Properties
    public int ImageID
    {
        get { return m_ImageID; }
        set { m_ImageID = value; }
    }
    public string Src
    {
        get { return m_Src; }
        set { m_Src = value; }
    }
    public string ImgUrl
    {
        get { return m_ImgUrl; }
        set { m_ImgUrl = value; }
    }
    public string ShortImgUrl
    {
        get
        {
            string returnString = ImgUrl;
            if (returnString.Contains("www."))
            {
                returnString = returnString.Substring(returnString.IndexOf("www.") + 4);
            }
            if (returnString.Contains("//"))
            {
                returnString = returnString.Substring(returnString.IndexOf("//") + 2);
            }
            if (returnString.Contains(".com"))
            {
                return returnString.Substring(0, returnString.IndexOf(".com") + 4);
            }
            if (returnString.Contains(".net"))
            {
                return returnString.Substring(0, returnString.IndexOf(".net") + 4);
            }
            else if (returnString.Length > 20)
            {
                return returnString.Substring(0, 20);
            }
            return returnString;
        }
    }
    public int Width
    {
        get { return m_Width; }
        set { m_Width = value; }
    }
    public int Height
    {
        get { return m_Height; }
        set { m_Height = value; }
    }
    public string SearchTerm
    {
        get { return m_SearchTerm; }
        set { m_SearchTerm = value; }
    }
    #endregion //Properties

    #region Constructors
    private Image()
    {
        m_ImageID = 0;
        m_Src = "";
        m_ImgUrl = "";
        m_Width = 0;
        m_Height = 0;
        m_SearchTerm = "";
    }
    private Image(int imageID, string src, string imgUrl, int width, int height, string searchTerm)
    {
        m_ImageID = imageID;
        m_Src = src;
        m_ImgUrl = imgUrl;
        m_Width = width;
        m_Height = height;
        m_SearchTerm = searchTerm;
    }
    #endregion //Constructors

    #region Factory Methods
    public static Image LoadNew()
    {
        return new Image();
    }
    public static Image LoadNew(int imageID, string src, string imgUrl, int width, int height, string searchTerm)
    {
        return new Image(imageID, src, imgUrl, width, height, searchTerm);
    }
    public static Image LoadByID(int imageID)
    {
        return LoadAll(imageID, null, null, null, null, null)[0];
    }
    public static List<Image> LoadAll()
    {
        return LoadAll(null, null, null, null, null, null);
    }
    public static List<Image> LoadAll(int? imageID, string src, string imgUrl, int? width, int? height, string searchTerm)
    {
        List<Image> all = new List<Image>();
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            conn = new SqlConnection(connection);
            conn.Open();

            SqlCommand cmdGet = new SqlCommand("Image_Get", conn);
            cmdGet.CommandType = CommandType.StoredProcedure;
            cmdGet.Parameters.Add(new SqlParameter("@ImageID", SqlDbType.Int));
            cmdGet.Parameters["@ImageID"].Value = imageID;
            cmdGet.Parameters.Add(new SqlParameter("@Src", SqlDbType.VarChar, 255));
            cmdGet.Parameters["@Src"].Value = src;
            cmdGet.Parameters.Add(new SqlParameter("@ImgUrl", SqlDbType.VarChar, 255));
            cmdGet.Parameters["@ImgUrl"].Value = imgUrl;
            cmdGet.Parameters.Add(new SqlParameter("@Width", SqlDbType.Int));
            cmdGet.Parameters["@Width"].Value = width;
            cmdGet.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int));
            cmdGet.Parameters["@Height"].Value = height;
            cmdGet.Parameters.Add(new SqlParameter("@SearchTerm", SqlDbType.VarChar, 255));
            cmdGet.Parameters["@SearchTerm"].Value = searchTerm;

            rdr = cmdGet.ExecuteReader();

            int IMAGEID = rdr.GetOrdinal("ImageID");
            int SRC = rdr.GetOrdinal("Src");
            int IMGURL = rdr.GetOrdinal("ImgUrl");
            int WIDTH = rdr.GetOrdinal("Width");
            int HEIGHT = rdr.GetOrdinal("Height");
            int SEARCHTERM = rdr.GetOrdinal("SearchTerm");

            while (rdr.Read())
            {
                all.Add(new Image(rdr.IsDBNull(IMAGEID) ? 0 : rdr.GetInt32(IMAGEID),
                    rdr.IsDBNull(SRC) ? "" : rdr.GetString(SRC),
                    rdr.IsDBNull(IMGURL) ? "" : rdr.GetString(IMGURL),
                    rdr.IsDBNull(WIDTH) ? 0 : rdr.GetInt32(WIDTH),
                    rdr.IsDBNull(HEIGHT) ? 0 : rdr.GetInt32(HEIGHT),
                    rdr.IsDBNull(SEARCHTERM) ? "" : rdr.GetString(SEARCHTERM)
                ));
            }
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (rdr != null)
            {
                rdr.Close();
            }
        }

        return all;
    }
    #endregion //Factory Methods

    #region Data Management
    public void Save()
    {
        string suffix = "";
        SqlParameter draftParameter = new SqlParameter("@ImageID", SqlDbType.Int);
        if (m_ImageID != 0)
        {
            suffix = "Upd";
            draftParameter.Value = m_ImageID;
        }
        else
        {
            suffix = "Ins";
            draftParameter.Direction = ParameterDirection.Output;
        }

        string proc = "Image_" + suffix;

        SqlConnection conn = null;
        string connection = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        conn = new SqlConnection(connection);

        SqlCommand cmd = new SqlCommand(proc, conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add(draftParameter);

        cmd.Parameters.Add(new SqlParameter("@ImageID", SqlDbType.Int));
        cmd.Parameters["@ImageID"].Value = m_ImageID;
        cmd.Parameters.Add(new SqlParameter("@Src", SqlDbType.VarChar, 255));
        cmd.Parameters["@Src"].Value = m_Src;
        cmd.Parameters.Add(new SqlParameter("@ImgUrl", SqlDbType.VarChar, 255));
        cmd.Parameters["@ImgUrl"].Value = m_ImgUrl;
        cmd.Parameters.Add(new SqlParameter("@Width", SqlDbType.Int));
        cmd.Parameters["@Width"].Value = m_Width;
        cmd.Parameters.Add(new SqlParameter("@Height", SqlDbType.Int));
        cmd.Parameters["@Height"].Value = m_Height;
        cmd.Parameters.Add(new SqlParameter("@SearchTerm", SqlDbType.VarChar, 255));
        cmd.Parameters["@SearchTerm"].Value = m_SearchTerm;

        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();

        if (suffix == "Ins")
        {
            m_ImageID = (Int32)cmd.Parameters["@ImageID"].Value;
        }
    }
    #endregion //Data Management
}
