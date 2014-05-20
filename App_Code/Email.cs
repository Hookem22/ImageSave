using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Net.Mail;

/// <summary>
/// Summary description for Email
/// <summary>
public class Email
{
    #region Declarations
    private string m_MessageFrom;
    private string m_MessageTo;
    private string m_Subject;
    private string m_Body;

    public static bool EmailOnSignup = true;
    public static bool EmailOnDeposit = true;
    public static bool EmailOn100or50Draft = true;
    #endregion //Declarations

    #region Properties
    public string MessageFrom
    {
        get { return m_MessageFrom; }
        set { m_MessageFrom = value; }
    }
    public string MessageTo
    {
        get { return m_MessageTo; }
        set { m_MessageTo = value; }
    }
    public string Subject
    {
        get { return m_Subject; }
        set { m_Subject = value; }
    }
    public string Body
    {
        get { return m_Body; }
        set { m_Body = value; }
    }
    #endregion //Properties

    #region Constructors
    private Email()
    {
        m_MessageFrom = "";
        m_MessageTo = "";
        m_Subject = "";
        m_Body = "";
    }
    private Email(string messageFrom, string messageTo, string subject, string body)
    {
        m_MessageFrom = messageFrom;
        m_MessageTo = messageTo;
        m_Subject = subject;
        m_Body = body;
    }
    #endregion //Constructors

    #region Factory Methods
    public static Email LoadNew()
    {
        return new Email();
    }
    public static Email LoadNew(string messageFrom, string messageTo, string subject, string body)
    {
        return new Email(messageFrom, messageTo, subject, body);
    }
    #endregion

    public void Send()
    {
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(m_MessageFrom);
            message.To.Add(new MailAddress(m_MessageTo));
            message.Subject = m_Subject;
            message.Body = m_Body;
            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.sendgrid.net");
            smtp.Credentials = new System.Net.NetworkCredential("drafterparty", "emmitt22");
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.Send(message);
        }
        catch
        {
        }
        //SmtpClient smtp = new SmtpClient("mail.olive.arvixe.com");
        //smtp.Credentials = new System.Net.NetworkCredential("will@neighborbillparks.com", "emmitt22");
        //smtp.Port = 25;
        //smtp.EnableSsl = false;
        //smtp.Send(message);
    }
}
