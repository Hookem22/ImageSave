<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" EnableEventValidation="false" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<script type="text/javascript">    var _sf_startpt = (new Date()).getTime()</script>
    <title>Save Image Galleries</title>
<meta name="description" content="Search and Download Images with one click" />
<meta name="keywords" content="Image gallery, Images Save, Download Images" />
        <link rel="stylesheet" href="Base.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="Default.css" type="text/css" media="screen" />
        <link rel="stylesheet" href="Start.css" type="text/css" media="screen" />
<script type="text/javascript">

    var _gaq = _gaq || [];
    _gaq.push(['_setAccount', 'UA-24529778-1']);
    _gaq.push(['_trackPageview']);

    (function () {
        var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
        ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
        var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
    })();

</script>
  <script type="text/javascript" src="Default.js?c=3"></script>    
  <script type="text/javascript" src="Start.js?c=3"></script> 
  <script type="text/javascript" >
      function searchClick() {

          document.getElementById("startContent").className = "noShow";
          document.getElementById("left").className = "";
          document.getElementById('SearchButton').click(); 
      }
  </script> 
</head>
<body>
    <form id="form1" runat="server">
                    <div id="fb-root"></div>
                        <script>
                            window.fbAsyncInit = function () {
                                FB.init({
                                    appId: '241164329270990', // App ID
                                    //channelURL: '//WWW.drafterparty.COM/channel.html', // Channel File
                                    status: true, // check login status
                                    cookie: true, // enable cookies to allow the server to access the session
                                    oauth: true, // enable OAuth 2.0
                                    xfbml: true  // parse XFBML
                                });

                                // Additional initialization code here
                            };

                            // Load the SDK Asynchronously
                            (function (d) {
                                var js, id = 'facebook-jssdk'; if (d.getElementById(id)) { return; }
                                js = d.createElement('script'); js.id = id; js.async = true;
                                js.src = "//connect.facebook.net/en_US/all.js";
                                d.getElementsByTagName('head')[0].appendChild(js);
                            } (document));
                        </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">   
    </asp:ScriptManager>
        <div id="globalheader">
            <span style="margin-left:15px; font-size: 2em; font-weight: bold; float: left; font-family: 'Lucida Grande', 'Lucida Sans Unicode', Helvetica, Arial, Verdana, sans-serif;">Gallery Save</span>  
            <span style="margin-left: 100px; float: left;">                 
                <asp:TextBox ID="SearchTextBox" Font-Size="18px" runat="server" Width="298px"></asp:TextBox>&nbsp;&nbsp;
                <span class="lightBlueButton" onclick="searchClick()">    
                    <span class="buttonSpan" style="padding-left: 27px;">Search</span></span>
                <asp:Button ID="SearchButton" runat="server" CssClass="noShow" Text="Search" onclick="SearchButton_Click" />&nbsp;&nbsp;
            </span>
        </div>

        <div id="bodyDiv">
        <div id="startContent" runat="server" style="margin: 40px 0 40px 140px;" >
            <div class="imageDiv" style="font-size: 1.3em; font-weight: bold;">
                <asp:Image ImageUrl="~/Pictures/search.png" runat="server" DescriptionUrl="Search"></asp:Image>
                  <br /><br /><span style="margin-top: 10px; display: block;">Search for Images </span> 
                </div>
              <div class="imageDiv" style="font-size: 1.3em; font-weight: bold;">
                <asp:Image ImageUrl="~/Pictures/mouseCheck.png" runat="server" DescriptionUrl="Select"></asp:Image>
                  <br /><br /><span style="margin-top: 20px; display: block;"> Select to Download </span>
                </div>
              <div class="imageDiv" style="font-size: 1.3em; font-weight: bold;">
                <asp:Image ImageUrl="~/Pictures/download.png" runat="server" DescriptionUrl="Download"></asp:Image>
                  <br /><br /><span style="margin-top: 41px; display: block;">Save All</span>
                </div>
              </div>

        <div runat="server" id="left" class="noShow">  
            <span class="lightBlueButton" onclick="document.getElementById('DownloadButton').click(); return false;">    
                <span class="buttonSpan" >Download</span></span>  <br /><br />     
                <asp:Button ID="DownloadButton" runat="server" CssClass="noShow" Text="Search" onclick="DownloadButton_Click" />     
                
                <div class="checkBoxSelected" onclick="SelectAll();">
                    Select All
                </div>
                <div class="checkBoxNotSelected" style="color: #222;" onclick="UnselectAll();">
                    Unselect All
                </div><br />
            <ul class="sideBarTable">
                <li>
                    <a class="sideBarTableHeader">Images<span></span></a>
                </li>
                <li>
                    <a href="Facebook.aspx">Facebook<span></span></a>
                </li>
            </ul>
        </div>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
      <Triggers>
        <asp:AsyncPostBackTrigger ControlID="SearchButton" EventName="click" />
      </Triggers>
      <ContentTemplate>
        <div runat="server" id="right" visible="false">
        <asp:Repeater ID="ImageRepeater" runat="server">
            <ItemTemplate>
                <div class="imageDiv">
                    <div id="checkBoxDiv" runat="server" class="checkBoxSelected" onclick='<%# DataBinder.Eval(Container.DataItem, "ImageID", "CheckChanged({0}, this.className)")%>'>
                    Selected
                    </div>
                    <div id="coverDiv" runat="server" class="">
                    </div>
                    <asp:Image ID="Image" CssClass="imageSelected" ImageUrl='<%# DataBinder.Eval(Container.DataItem, "Src")%>' runat="server" DescriptionUrl='<%# DataBinder.Eval(Container.DataItem, "ImgUrl")%>'></asp:Image>
                      
                    <span>
                    <a target="_blank" href='<%# DataBinder.Eval(Container.DataItem, "ImgUrl")%>'><%# DataBinder.Eval(Container.DataItem, "ShortImgUrl")%></a><br />
                    <%# DataBinder.Eval(Container.DataItem, "Width")%> x <%# DataBinder.Eval(Container.DataItem, "Height")%>
                    </span>
                      
                </div>
                    
                </ItemTemplate>
            </asp:Repeater>
            <asp:TextBox ID="DownloadTextBox" CssClass="noShow" runat="server"></asp:TextBox>
  
        </div>
      </ContentTemplate>
    </asp:UpdatePanel>

        <div style="clear:both; height:10px;"></div>
    </div>
    <div style="margin: 0 auto; width: 900px">
                <div class="footer">
                    <ul class="footerPiped">
                        <li>&copy; 2012 Gallery Save</li>
                        <li><a href="#">Home</a></li>
                        <li><a href="Contact.aspx">Contact</a></li>
                    </ul>
                    <div style="clear: both;"></div>
                </div>
            </div>
        
        <asp:Label ID="NumberStartingDrafts" runat="server" CssClass="noShow" Text=""></asp:Label>
        <asp:TextBox ID="userIDTextBox" CssClass="noShow" runat="server"></asp:TextBox>
        <asp:Label ID="LeagueSelectedHidden" runat="server" CssClass="noShow" Text=""></asp:Label>
    








    
    </form>
    <script type="text/javascript">
        var _sf_async_config = { uid: 26622, domain: "drafterparty.com" };
        (function () {
            function loadChartbeat() {
                window._sf_endpt = (new Date()).getTime();
                var e = document.createElement('script');
                e.setAttribute('language', 'javascript');
                e.setAttribute('type', 'text/javascript');
                e.setAttribute('src',
       (("https:" == document.location.protocol) ? "https://a248.e.akamai.net/chartbeat.download.akamai.com/102508/" : "http://static.chartbeat.com/") +
       "js/chartbeat.js");
                document.body.appendChild(e);
            }
            var oldonload = window.onload;
            window.onload = (typeof window.onload != 'function') ?
     loadChartbeat : function () { oldonload(); loadChartbeat(); };
        })();

</script>
<script type="text/javascript">
    var clicky_site_ids = clicky_site_ids || [];
    clicky_site_ids.push(66554219);
    (function () {
        var s = document.createElement('script');
        s.type = 'text/javascript';
        s.async = true;
        s.src = '//static.getclicky.com/js';
        (document.getElementsByTagName('head')[0] || document.getElementsByTagName('body')[0]).appendChild(s);
    })();
</script>
</body>
</html>

