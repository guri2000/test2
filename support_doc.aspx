<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="support_doc.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
<title></title>
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0">

<script type="text/javascript" src="source/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>
    <script type="text/javascript" src="source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>

        <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="css/nwlead-bootstrap.min.css" />

<style type="text/css">
    .form-horizontal .control-group{border: 0px !important; border-top: 0px !important;}
    .validationposition {

    position: relative;
    margin-bottom: 0px;
    font-size: 11px;

}
.RadGrid_Office2007 .rgHeader, .RadGrid_Office2007 th.rgResizeCol, .RadGrid_Office2007 

.rgHeaderWrapper {


    background: none !important;
        background-color: rgba(0, 0, 0, 0);
    background-color: #eaeaea !important;

}
.RadGrid_Office2007 .rgInfoPart {
    color:#000 !important;
}
.RadGrid_Office2007 .rgPager {
   color:#000 !important;
}
.RadGrid_Office2007 {
    border: 1px solid #c2bebe !important;
    margin: 0 !important;
}
.rgHeader a
{
    color:#000 !important;
 
 }
.rgHeader
{
    color:#000 !important;
 
 }
 .panel-body {
    padding: 0;
}

.RadGrid_Office2007 .rgPager {

    background: none;
 
    color: #131414;
       background: none !important;
        background-color: rgba(0, 0, 0, 0);
    background-color: #eaeaea !important;

}
.RadGrid .rgFilterRow td {

    padding-top: 0 !important;
    padding-bottom: 0 !important;
    background-color: #f5f5f5 !important;

}
.grid-one {
    margin-bottom: 5px !important;
    border: none !important;
}

.RadGrid_Office2007 .rgInfoPart {

    color: #141415;

}
/*Page Layout*/
.panel-default-one > .panel-heading-one {
    color: #fff;
    background-color: #1f589b !important;
    border-color: #1f589b !important;
}
.panel-default {
    margin: -3px 0 0 0 !important;

}
</style>

<script type="text/javascript">

     
            $(document).ready(function callfancy() {
                    
                  
                    $('.fancybox').fancybox({
                        width: screen.width*60/100,
                        height: screen.height*90/100,
                        padding: 5,

                        openEffect: 'elastic',
                        openSpeed: 500,
                        type: 'iframe',
                        closeEffect: 'elastic',
                        closeSpeed: 500,
                        autoSize: false,
                        closeClick: true,

                        helpers: {
                            overlay: {
                                closeClick: true,
                                opacity: 0.4, // or the opacity you want 
                                // or your preferred hex color value
                            } // overlay 
                        }

                    });
             });
  $('.pop2').fancybox({
                 width: screen.width*95/100,
                 height: screen.height*95/100,
                 padding: 0,

                 openEffect: 'elastic',
                 openSpeed: 500,
                 type: 'iframe',
                 closeEffect: 'elastic',
                 closeSpeed: 500,
                 autoSize: false,
                 closeClick: true

             });
              $('.pop').fancybox({
                        width: screen.width*25/100,
                        height: screen.height*50/100,
                        padding: 5,

                        openEffect: 'elastic',
                        openSpeed: 500,
                        type: 'iframe',
                        closeEffect: 'elastic',
                        closeSpeed: 500,
                        autoSize: false,
                        closeClick: true,

                        helpers: {
                            overlay: {
                                closeClick: true,
                                opacity: 0.4, // or the opacity you want 
                                // or your preferred hex color value
                            } // overlay 
                        }

                    });
          $('.pop3').fancybox({
                 width: 500,
                 height: 200,
                 padding: 0,

                 openEffect: 'elastic',
                 openSpeed: 500,
                 type: 'iframe',
                 closeEffect: 'elastic',
                 closeSpeed: 500,
                 autoSize: false,
                 closeClick: true

             });
    </script>
<style>
        #loading
        {
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0;
            left: 0;
            background: #000;
            opacity: 0.6;
            filter: alpha(opacity=40);
            z-index: 999;
            overflow: hidden;
        }
        
        
        #loading #loadingimage
        {
            height: 20px;
            left: 30%;
            position: fixed;
            top: 40%;
            width: 610px;
            z-index: 1000;
        }
        
        *:first-child + html #loading
        {
            width: 100%;
            height: 100%;
            position: fixed;
            top: 0;
            left: 0;
            background: #000;
            opacity: 0.6;
            filter: alpha(opacity=40);
            z-index: 999;
            overflow: hidden;
        }
        
        *:first-child + html #loading #loadingimage
        {
            position: fixed;
            width: 600px;
            height: 20px;
            left: 32%;
            top: 50%;
            margin-left: -10px;
            margin-top: -10px;
            z-index: 1000;
        }
       
 

    </style>
    <script type="text/javascript">

        function ShowProgress() {
            var loadingdiv = document.getElementById("loading");
            loadingdiv.style.visibility = 'visible';

        }

        function HideProgress() {
            var loadingdiv = document.getElementById("loading");
            loadingdiv.style.visibility = 'hidden';
        }


</script>



<style>
    .RadGrid_Default .rgCommandRow a {
    color: #fff !important;
    text-decoration: none;
}

select
{ width: 100% !important;}
 .RadPicker
     {
         width:100% !important;
     }
     
          .RadPicker table.rcTable {
width:100% !important;

}
     
</style>


<style>
    .RadGrid_Default .rgCommandRow a {
    color: #fff !important;
    text-decoration: none;
}
.modal {
    position: fixed;
    top: 3%;
    left: 5%;
    right:5%;
    z-index: 1050;
    width: 50%;
    height:300px;
    margin-left: 0px;
    background-color: #FFF;
    border: 1px solid rgba(0, 0, 0, 0.3);
    border-radius: 6px;
    outline: 0px none;
    box-shadow: 0px 3px 7px rgba(0, 0, 0, 0.3);
    background-clip: padding-box;
   
}
.modal-body{max-height: 300px !important; padding: 0px !important; overflow-y: hidden !important;}
.RadPicker
     {
         width:100% !important;
     }
     .RadPicker table.rcTable {
width:100% !important;

}
  .panel-heading-one {

 border-bottom: 1px solid transparent;
 border-top-left-radius: 3px;
 border-top-right-radius: 3px;
 border-bottom: 1px solid #bab7b7;
   
} 

.panel-heading-one {
    height: 23px !important;
}

 .RadWindow .rwDialogPopup {
    margin: 16px;
    color: black;
    padding: 28px 0px 39px 50px !important;

}

 .span1-one {
    margin: 0 0 0 16px !important;
    width: 18%;
}
   


.span1-one p
{
       margin: 0;
    width: 100%;
    display: block;
        overflow: hidden;
}
.span1-one p
{
       margin: 0;
    width: 100%;
    display: block;
        overflow: hidden;
}
.name
{
    display: block;
    float: left;
        margin: 0 5px 0 0px;
}
.name label {
    line-height: 16px;
  
}
#status
{
       font-weight: 600;
    color: red;
}
.left-side
{
    display: block;
    float: left;
    width: 13%;
    overflow: hidden;
}

.right-side
{
    display: block;
    float: left;
    width: 86%;
    overflow: hidden;
}
.span1-one.width-two {
    width: 26%;
}
.panel-heading-one h5 
{
    color:#fff !important;
    padding: 6px 10px !important;
}
.panel-body-one {
    padding: 0 !important;
    width: 100% !important;
}
.panel-one {

    margin-bottom: 0px !important;
}
select, textarea, input[type="text"], input[type="password"], input[type="datetime"], input[type="datetime-local"], input[type="date"], input[type="month"], input[type="time"], input[type="week"], input[type="number"], input[type="email"], input[type="url"], input[type="search"], input[type="tel"], input[type="color"], .uneditable-input {
 
    height: 26px !important;
  
}
html body .riSingle .riTextBox[type="text"] {
       height: 26px !important;
  
}
.control-width {
    padding: 0 !important;
}
.RadGrid .rgFilterBox {
    height: 15px !important;
}
#rbbudget input {

    float: left;
    margin: 3px 10px 0px 0;

}
#rbbudget label {

    float: left;

}
.panel-heading {
    padding: 3px 10px !important;
    color: #fff;
background-color: #286090 !important;
border-color: #204d74 !important;
}
.panel-heading h5 {
 
    color: #fff;
    margin: 0;

}.row {

    margin-right: 0;
    margin-left: 0;
 
}
.span1-one {
    margin: 0 0 0 16px !important;
    width: 18%;
}
 .container-fluid
        {
            padding: 0 5px 0 5px !important;
        }
        *
        {
            font-size:11px !important;
        }
        .panel {
    margin-bottom: 2px !important;
        }
        label {

    margin-bottom: 0px !important;
    font-weight: 400 !important;
}
#txtdoc {
    border-radius: 2px;
    border: 1px solid #ccc;
    width: 100%;
}
#RadGrid1_GridData {
height: 181px !important;
}
.panel-heading.fixed-width {
    position: fixed;
    width: 98.7%;
    z-index: 999;
    height: 20px;
}
.panel-body.fixedon {

    padding: 20px 0 0 0 !important;

}
.fa.fa-download {

    color: #1285af !important;

}
</style>
</head>
<body onload="HideProgress();">
  <form id="Form1"  runat="server" method="post" class="form-horizontal" >
  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
     <asp:ValidationSummary ID="vs" ValidationGroup="basicdetails1" ShowMessageBox="true" ShowSummary="false" runat="server" />
<div id="loading">
        <div id="loadingimage" style="color:white; font-size: 17px; line-height: 55px; font-family: verdana;
            text-align: center;">
            <img src="Images/loading1.gif" width="20px" height="20px" />
        </div>
    </div>
 <div class="row" style="display:none;">
<div class="span12">
<span id="error" style="color: Red; display: none"> ~ ` ! ^ & ( ) _ { } [ ] | \ : ; " < > ? Special Characters not allowed</span>
</div></div>

<div class="row" style="padding: 2px 0px 0px 0px !important;">
  <div class="col-md-12" style="padding: 0 !important;">
     <div class="container-fluid"> 
    <div class="panel panel-default">
     
<div class="panel-heading fixed-width"><h5><i class="fa fa-upload" aria-hidden="true"></i>
 <asp:Label id="lblhead" runat="server" text="Upload Dcouments"> </asp:Label> <img style="width: 5.3%; float: right; margin-top: -4px;" src="images/zaxis.png"/></h5></div>
        <div class="panel-body fixedon">
     <div class="span1-one width-name-btn" style="position: absolute; right: 0; width: 6%;right: 24px;
width: 10%;text-align: right;top: 24px;" id="row1"  runat="server">
                    
            
               <asp:Button ID="Button1" Visible="false" class="btn btn-success"  runat="server" Text="Save" />
               <asp:ImageButton  ID="ImageButton1"  OnClientClick=" ShowProgress();"  Enabled="true"   runat="server"  
                   ImageUrl="~/images/save20x20.png" Height="20" Width="20" ToolTip ="Save"  />
               <asp:ImageButton ID="Button2"    runat="server" ToolTip="Reset" 
                 ImageUrl="~/images/reload20x20.png"   CausesValidation="False" />

         
                   
                </div>

<div class="row" id="row2" runat="server" style="margin-top: 25px;  margin-bottom: 6px;">
<div class="col-md-12" style="padding: 0 !important;">
<div class="col-xs-6 col-sm-4" style="display:none">
                                <label class="control-label-width" >
                                    Type of document:  <span style="color:Red;">*</span></label>
                                <div class="control-label-width">
                                    <asp:TextBox ID="txtdoc"  
                                         class="span12" placeholder="Type of doc" runat="server" MaxLength="40"
                                        onblur="textBoxOnBlur(this);"></asp:TextBox>
										  <br /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                  runat="server" InitialValue="" ValidationGroup="basicdetails" ErrorMessage="Type of doc required" ControlToValidate="txtdoc" 
                    ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                                </div>
                            
                           </div>
						   
						   
						 <div class="col-xs-6 col-sm-4">
                                <label class="control-label-width" >
                                    Browse (upload document): </label>
                                <div class="control-label-width">
                         <asp:FileUpload ID="fupl" runat="server" />
										 
                                </div>
                           
                           </div>

                         
                        </div>
            


        </div>
      </div>
     
    </div>
     </div>
      </div></div>
<div class="row">
  <div class="col-md-12" style="padding-left: 5px !important; padding-right: 5px !important;">
    

     <telerik:RadGrid ID="RadGrid1" EnableViewState="true"   Skin="Office2007" PageSize="50"   CSSClass="table table-bordered" 
            AllowPaging="True" CellSpacing="0" GridLines="none"  
             AllowSorting="True" ShowHeader="true"     AllowFilteringByColumn="false"  runat="server" Height="269" >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView   DataKeyNames="fid"  NoMasterRecordsText="No records to display" CommandItemDisplay="Top" >
               <NoRecordsTemplate>
      <div>
        No records to display</div>
    </NoRecordsTemplate>
              <CommandItemTemplate >
                             <div style="padding: 1px 5px;float:right;">
               <asp:LinkButton ID="LinkButton4" Visible="true" runat="server" CommandName="refresh" ToolTip="Refresh" ><img style="border:0px;vertical-align:middle;" alt="" src="Images/reload20x20.png"/></asp:LinkButton>
                  </div>
                 
                     
                    
                </CommandItemTemplate>
              

               

                        <Columns>
                         
            
                      
                      <telerik:GridTemplateColumn UniqueName="doc"  HeaderText="DOWNLOAD">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkdownload" runat="server" ToolTip="Download" Text="" CommandName="download" CssClass="cls-res" ><i class="fa fa-download" aria-hidden="true" style="font-size:14px !important;"></i></asp:LinkButton>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>

                       

                     
                        </Columns>
          
                      <PagerStyle AlwaysVisible="true"  PageSizeControlType="RadComboBox"  Mode="NextPrevAndNumeric" PageSizeLabelText="Display Rows: " PageSizes="5,10,25,50,100,250" ></PagerStyle>                 
                   </MasterTableView>
                  
                  <ItemStyle Wrap="false" CssClass="font"/> 
                  <AlternatingItemStyle Wrap="false" CssClass="font"/>
                 <HeaderStyle Font-Size="12px" Font-Names="Arial"  Font-Bold="true"  />
                      <clientsettings allowkeyboardnavigation="True" reordercolumnsonclient="False">
                                                            <Selecting AllowRowSelect="True" />
                                                            <Resizing AllowColumnResize="true" ResizeGridOnColumnResize="true" ClipCellContentOnResize="True"
                                                                EnableRealTimeResize="False" AllowResizeToFit="true" />
                                                            <Scrolling AllowScroll="true" UseStaticHeaders="True" SaveScrollPosition="True" />
                                                        </clientsettings>
            </telerik:RadGrid>
   
            </div>         
            </div>






    
   

    </form>
    
 <script type="text/javascript">

     function isNumberKey(evt) {
         var charCode = (evt.which) ? evt.which : evt.keyCode;
         if (charCode > 31 && (charCode < 48 || charCode > 57)) {
             return false;
         }
         return true;
     }
     function limitCharLengthAddress(txtArea) {
         if (txtArea.value.length > 15) {
             txtArea.value = txtArea.value.substring(0, 15);
         }
     }
     function limitLengthAddress(txtArea) {
         if (txtArea.value.length > 11) {
             txtArea.value = txtArea.value.substring(0, 11);
         }
     }
     function ValidateEmail(evt) {
         var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
         if (evt.value.match(mailformat)) {
             document.getElementById("emlerror").style.display = ret ? "none" : "inline";
             return mailformat;
         }

     }  
         </script>
     
    <script type="text/javascript">
        var specialKeys = new Array();
        specialKeys.push(8); //Backspace
        specialKeys.push(32); //Space
        specialKeys.push(9); //Tab
        specialKeys.push(46); //Delete
        specialKeys.push(36); //Home
        specialKeys.push(35); //End
        specialKeys.push(37); //Left
        specialKeys.push(39); //Right
        function IsAlphaNumeric(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric1(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error1").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric2(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error2").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric3(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error3").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric4(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error4").style.display = ret ? "none" : "inline";
            return ret;
        }
        function IsAlphaNumeric5(e) {
            var keyCode = e.keyCode == 0 ? e.charCode : e.keyCode;
            var ret = ((keyCode >= 48 && keyCode <= 57) || (keyCode == 32) || (keyCode >= 35 && keyCode <= 38) || (keyCode >= 42 && keyCode <= 47) || (keyCode >= 64 && keyCode <= 90) || (keyCode >= 97 && keyCode <= 122) || (specialKeys.indexOf(e.keyCode) != -1 && e.charCode != e.keyCode));
            document.getElementById("error5").style.display = ret ? "none" : "inline";
            return ret;
        }
    </script>
</body>
</html>

