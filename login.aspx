<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="home" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>WWICS: Branch Module</title>
    <link id="favicon" rel="icon" type="image/png" href="images/zax_favicon.png" />
    
    
    <style type='text/css'>
     
        body{background:#fff !important;}
        
        .fullBg
        {
            position: fixed;
            top: 0;
            right: 0;
            overflow: hidden;
        }
        
        
        
        .successbox, .warningbox, .errormsgbox
        {
            font-weight: bold;
            border: 2px solid;
            margin: 10px 0px;
            padding: 15px 10px 15px 70px;
            background-repeat: no-repeat;
            background-position: 10px center;
            width: 600px;
        }
        .successbox
        {
            color: #4F8A10;
            background-color: #EDFCED;
            background-image: url('images/success.png');
        }
        .warningbox
        {
            color: #FFE222;
            background-color: #FAF9C9;
            background-image: url('images/warning.png');
        }
        .errormsgbox
        {
            color: #D8000C;
            background-color: #FDD5CE;
            background-image: url('images/error.png');
        }
        .footer
        {
            background-color: #343739;
            bottom: 0;
            color: #FFFFFF;
            float: left;
            font-family: Sans-Serif;
            font-size: 10px;
            min-width: 1003px;
            text-align: center;
            width: 100%;
            position: fixed;
        }
        
        
        
        
        .login-mainboxTitle
        {
            background: rgba(0, 0, 0, 0.1);
            padding: 5px 30px;
            text-align: center;
            font: 20px/30px opansans;
            color: #272727;
            margin-bottom: 5px;
            position: absolute;
            /*top: 24%;*/
            top:79px;
            left: 0;
            float: left;
            width: 400px;
            z-index:5;
        }
        .login-mainbox
        {
            /*background: rgba(0, 0, 0, 0.1);*/
            background: rgba(0, 0, 0, 0) url("images/login-cred-new-bg.png") no-repeat scroll 0 0;
            padding: 5px;
            /*top: 24%;
            margin-top: 43px;*/
            top:75px;
            left: 0px;
            float: left;
            position: absolute;
            width: 507px;
            z-index:99999;
            height:515px;
        }
        .login-mainbox .label-field01
        {
            text-align: right;
            color: #272727;
            font: 11px/25px opansans;
            padding: 2px 5px 2px 2px;
            float: left;
            width: 20%;
        }
        .login-mainbox .user-field01
        {
            text-align: left;
            color: #fff;
            font: 16px/25px opansans;
            padding: 2px 2px 2px 5px;
            float: left;
            width: 43%;
        }
        .text-field-style01
        {
            border: 1px solid rgba(0, 0, 0, 0.09);
            border-radius: 5px;
            color: #272727;
            font: 12px/20px opansans;
            padding: 6px 6px 6px 29px;
            width: 100%;
            text-shadow: 0 -1px 0 rgba(255, 255, 255, 0.1);
        }
        .dropdown-style01
        {
            /*background: rgba(255, 255, 255, 0.2);
            border: 1px solid #fff;
            border-radius: 5px;
            color: #272727;
            font: 16px/20px opansans;
            padding: 6px 6px 6px 8px;
            width: 100%;*/
            background: rgba(0, 0, 255, 0.09) none repeat scroll 0 0;
    border: 1px solid rgba(0, 0, 0, 0.2);
    border-radius: 5px;
    color: #272727;
    font: 12px/20px opansans;
    padding: 6px 6px 6px 8px;
    width: 100%;
        }
        .login-user-img
        {
            /*background: url(images/login-user-icons.png) no-repeat 8px 6px rgba(255, 255, 255, 0.2);
            width: 22px;
            height: 22px;*/
            background: rgba(0, 0, 255, 0.1) url(images/login-user-icons2.png) no-repeat scroll 6px 4px;
            height: 17px;
            width: 22px;
        }
        .login-passw-img
        {
            background: url(images/login-user-icons2.png) no-repeat 6px -41px rgba(0, 0, 255, 0.09);
            width: 22px;
            height: 17px;
        }
        
        option
        {
            background: rgba(255, 255, 255, 0.1);
            color: #272727;
        }
        .mainbox-sign-btn
        {
            font: 16px/18px opansans;
            color: #fff;
            /*padding: 2px 2px 2px 18px;*/
            padding:0 0 4px 2px;
            text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.1);
            margin: 5px;
            border: 0;
        }
        .login-sign-img
        {
            /*background: url(images/login-user-icons.png) no-repeat 8px -85px #019891;*/
            background: #019891 url("images/login-btn-bg.png") repeat scroll 8px -85px;
            height: 37px;
            width: 115px;
            transition: all 0.3s ease-out 0s;
            cursor: pointer;
        }
        .login-sign-img:hover
        {
            box-shadow: 0 0 10px #fff inset;
        }
        .login-sign-img:active
        {
            box-shadow: 0 0 10px #000 inset;
        }
    </style>

   
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/popfo_style.css" type="text/css" rel="Stylesheet" />


     <style>
    
.LoginBodyDiv .loginBoxCenter02 {
		background: url(images/imageslogin/loginBoxMainPic.jpg) no-repeat scroll left top rgba(0, 0, 0, 0);
		float: left;
		height: 500px;
		position: relative;
		width: 634px;
	}
	.headerDiv {
		height: 62px;
		padding-top: 1px;
		width: 100%;
	}
	.LoginBodyDiv .loginBoxShadowTop {
		background: url(images/imageslogin/loginBoxShadowTop.png) no-repeat scroll left center rgba(0, 0, 0, 0);
		float: left;
		height: 28px;
		margin-top: -20px;
		width: 100%;
	}
	.LoginBodyDiv .loginBoxCenter03 {
		background: url(images/imageslogin/loginpanelBg.png) repeat-y scroll left top rgba(0, 0, 0, 0);
		float: left;
		height: 500px;
		width: 291px;
	}
	.LoginBodyDiv .loginBoxCenterZaxLogo {
		background: url(images/imageslogin/centerZaxLogo_03.png) no-repeat scroll left center rgba(0, 0, 0, 0);
		float: left;
		height: 306px;
		left: 23%;
		position: relative;
		top: 2%;
		width: 367px;
		z-index: 2;
	}
	.headerDiv .titleText {
		float: right;
		font: 27px/31px SEGOEUIL;
		padding: 25px 0 0;
		width: 71%;
	}
	.gallery-float-div{bottom: 0px; position: absolute; width: 100%; height: 302px; z-index:12;}
		.gallery-float-div2{bottom: 0;
    height: 268px;
    position: absolute;
    width: 100%;
    z-index: 12;}
	.imgspacer-link{position:absolute; z-index:15;}
	
	.newfootertxt-over-txt {
    bottom: 0;
    color: #fff;
    float: left;
    font: 10px/15px opansans;
    height: 18px;
    left: 0;
    margin: 0;
    padding-left: 118px;
    position: absolute;
    text-align: left;
    width: 69%;
}

.newfootertxt {
    background: rgba(0, 0, 0, 0) url(images/footer-bg-lft02.png) no-repeat scroll left bottom;
    bottom: 0;
    float: left;
    height: 46px;
    left: 0;
    line-height: 12px;
    margin: 0;
    min-width: 828px;
    padding-left: 5px;
    position: absolute;
    text-align: left;
    width: 100%;
    z-index: 9999;
}
.newfooter {
    bottom: 0;
    color: #ffffff;
    float: left;
    font-family: opansans;
    font-size: 10px;
    min-width: 1003px;
    position: fixed;
    text-align: center;
    width: 100%;
}
	
    </style>
    <script>
      

        function reloadpage() {

            var url = document.URL.substr(0, document.URL.lastIndexOf("?"))

            window.location.href = url;

        }
    </script>

</head>
<body>
 <img src="images/login-new1.jpg" alt="" id="background" />

    <form id="form1" runat="server">
    <asp:ScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ScriptManager>
    <telerik:RadWindowManager ID="radMessageWindow" BackColor="red" runat="server" Style="z-index: 99999;">
    </telerik:RadWindowManager>
    <asp:Panel ID="pnl_login" runat="server" Visible="false">
     
            <div style="width:116px; height:93px; position:absolute; top:0; left:0;">
<img border="0" alt="" src="images/login-new-wwics.png">
</div>
        <div class="login-mainbox">
        <div style="width: 100%; float: left; margin-top: 236px;">
            <div class="label-field01">
                Select Branch</div>
            <div class="user-field01">
                <asp:DropDownList ID="ddlBraches" runat="server" CssClass="dropdown-style01" Width="87%">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Text="*" runat="server"
                    ValidationGroup="login" ControlToValidate="ddlBraches" ErrorMessage="Please select branch"
                    ForeColor="red" InitialValue="0"></asp:RequiredFieldValidator></div>
            <div class="clear">
            </div>
            <div class="label-field01">
                User Name</div>
            <div class="user-field01">
                <asp:TextBox ID="txtuname" runat="server" CssClass="text-field-style01 login-user-img"
                    Width="70%"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="rf" Text="*" runat="server"
                        ValidationGroup="login" ControlToValidate="txtuname" ErrorMessage="Please enter  username"
                        ForeColor="red"></asp:RequiredFieldValidator></div>
            <div class="clear">
            </div>
            <div class="label-field01">
                Password</div>
            <div class="user-field01">
                <asp:TextBox ID="txtpwd" TextMode="Password" runat="server" CssClass="text-field-style01 login-passw-img"
                    Width="70%"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ValidationGroup="login" runat="server" ControlToValidate="txtpwd" ErrorMessage="Please enter password"
                        Text="*" ForeColor="red"></asp:RequiredFieldValidator></div>
            <div class="clear">
            </div>
            <div class="label-field01">
            </div><asp:Label ID="lblmsg" runat="server" CssClass="text"
                    Style="color: #272727; font: 11px/15px opansans; text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.2);">* Login credentials are case sensitive</asp:Label>
            <div class="clear">
            </div>
            <div class="label-field01">
            </div>
            <asp:Button ID="btnsub" runat="server" ValidationGroup="login" Text="Sign-in" CssClass="mainbox-sign-btn login-sign-img"
                OnClick="btnsub_Click" />

                <div class="clear">
            </div>
                <div style="color:#3a5e81; font: 11px/15px opansans; text-shadow: 0px -1px 0px rgba(0, 0, 0, 0.2); width: auto; float: left; margin-top: 5px; padding-left: 37px;" class="text" id="Div1">Forgot password</div>
        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="login" ShowMessageBox="true"
                ShowSummary="false" runat="server" />
        </div>

        <%--  <div class="footer">
            <div class="footertxt">
                Copyright © wwicsgroup.com, All rights reserved<br />
                Designed & Developed By : Pinnacle Infoedge Pvt Ltd</div>
            <div class="footertxt2">
                for Z-aXis database and technical support call +91-0172-6663600 (ext. 486 / 487
                / 222 / 333),<br />
                +91-95010-32184, +91-82880-79424, +91-86990-29110</div>
        </div>--%>
        <%--<div class="newfooter">
            <div class="newfootertxt">
                <div class="newfootertxt-over-txt">
                    <div class="newfootertxt-over-txtTitle">
                        <span class="more-capt">D</span>YNAMIC <span class="more-capt">I</span>NFORMATION
                        <span class="more-capt">M</span>ANAGEMENT <span class="more-capt">S</span>YSTEM</div>
                    for Z-aXis database and technical support call<br />
                    +91-0172-6663600 (ext. 486 / 487 / 222 / 333), +91-95010-32184, +91-82880-79424,
                    +91-86990-2911</div>
            </div>
            <div class="newfootertxt2">
                <div class="newfootertxt2-over-txt">
                    Copyright © wwicsgroup.com, All rights reserved</div>
                <div class="newfootertxt2-over-img">
                </div>
            </div>
        </div>--%>

        
        </div>
        <div class="newfooter">
            <div class="newfootertxt">
                <div class="newfootertxt-over-txt">
                    
                    for Z-aXis database and technical support call
                    +91-0172-6663600 (ext. 486 / 487 / 222 / 333), +91-95010-32184, +91-82880-79424,
                    +91-86990-2911</div>
            </div>
<div style="background:#333333; width:100%; float:left; height:18px;"></div>
            
        </div>

    </asp:Panel>
    <asp:Panel ID="pnl_errorcode" runat="server" Style="text-align: center; vertical-align: middle;
        position: relative;">
        <asp:Label ID="lbl_error_code" runat="server" Style="font-size: 40px; font-weight: bold;
            color: Red;"></asp:Label>
    </asp:Panel>
    </form>
    <script type="text/javascript">
        $(window).load(function () {
            $("#background").fullBg();
        });
    </script>
    <script src="lib/jquery-1.10.1.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="js/jquery.fullbg.min.js"></script>

    
</body>
</html>
