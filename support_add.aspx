<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="support_add.aspx.vb" Inherits="_Default" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html>
<html lang="en">
<head id="Head1" runat="server">
<title></title>
<meta charset="UTF-8" />
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<script src="scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
<script type="text/javascript" src="source/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>
    <script type="text/javascript" src="source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>
    <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="css/nwlead-bootstrap.min.css" />
   <script type="text/javascript" src="js/bootstrap.min.js"></script>
 

<style type="text/css">
    .form-horizontal .control-group{border: 0px !important; border-top: 0px !important;}
    .validationposition {

    position: relative;
    margin-bottom: 0px;
    font-size: 11px;

}
.fa.fa-download {
    color: #2c9917 !important;
}

.fa.fa-trash-o {
    color: #e31919 !important;
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
#ddlPrior {
    width: 50% !important;
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
             $('.pop6').fancybox({
                 width: screen.width*45/100,
                 height: 100,
                 padding: 0,

                 openEffect: 'elastic',
                 openSpeed: 500,
                 type: 'iframe',
                 closeEffect: 'elastic',
                 closeSpeed: 500,
                 autoSize: false,
                 closeClick: true

             });


                  $('.pop5').fancybox({
                 width: screen.width*65/100,
                 height: screen.height*51/100,
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
                  width: screen.width*100/100,
                        height: screen.height*100/100,
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
       
 .tooltip-inner {
  background-color:#f1b454 !important;
  border:1px solid#c48015;
  color: #000;
  text-align:left;
  width:auto;
}


.tooltip.left .tooltip-arrow {
  border-left-color: #f1b454;
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

        function Confirm1() {
            return confirm("Are you sure you want to revoke entry?")
        }

</script>




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
.panel-heading {
    padding: 3px 10px !important;
    color: #fff;
background-color: #286090 !important;
border-color: #204d74 !important;
}
.panel-heading h5 {
 
    color: #fff;
    margin: 0;

}

.RadGrid_Office2007 .rgHeader, .RadGrid_Office2007 th.rgResizeCol, .RadGrid_Office2007 .rgHeaderWrapper
        {
            background: none !important;
            background-color: rgba(0, 0, 0, 0);
            background-color: #eaeaea !important;
        }
        .RadGrid_Office2007 .rgInfoPart
        {
            color: #000 !important;
        }
        .RadGrid_Office2007 .rgPager
        {
            color: #000 !important;
        }
        .RadGrid_Office2007
        {
            border: 1px solid #c2bebe !important;
            margin: 0 !important;
        }
        .rgHeader a
        {
            color: #000 !important;
        }
        .rgHeader
        {
            color: #000 !important;
        }
        .panel-body
        {
            padding: 0;
        }
        
        .RadGrid_Office2007 .rgPager
        {
            background: none;
            color: #131414;
            background: none !important;
            background-color: rgba(0, 0, 0, 0);
            background-color: #eaeaea !important;
        }
        .grid-one
        {
            margin-bottom: 5px !important;
            border: none !important;
        }
        
        .RadGrid_Office2007 .rgInfoPart
        {
            color: #141415;
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
select {
 height: 22px;
    border-radius: 2px;
    border: 1px solid #ccc;
    width:100% !important;
}
html body .riSingle .riTextBox[type="text"] {
  width: 100%;
    border-radius: 2px;
    border: 1px solid #ccc;

}
.control-label-width {
    margin-bottom: 0;
    font-weight: 400;
    width: 98%;
    float: left;
}

.control-label-width1
{ margin-bottom: 0;
    font-weight: 400;
   width: 42.5%;
    float: left; }
.control-width {
    width: 94%;
    float: left;
}
.control-width1 {

    width: 52%;
    float: left;

}
.row {

    margin-right: 0;
    margin-left: 0;
   

    margin-bottom: 6px !important;


}
#txtGst {
    border: 1px solid #ccc;
    height: 22px;
    border-radius: 2px;
    width: 100%;
}
#txtinvAmt {
    border: 1px solid #ccc;
    height: 22px;
    border-radius: 2px;
    width: 100%;
}
.panel-body {

    padding:0 !important;
}

.control-width.expen {

    width: 117px;
    float: left;

}
.control-label-width.expen {

    width: 42.4%;
    float: left;

}
.fa.fa-plus-square {
    font-size: 15px !important;
    color: #13a830;
}
.fa.fa-refresh
{
    font-size: 15px !important;
    color: #13a830;
}
.left-position {
    overflow: hidden;
    width: 67px;
    padding: 2px 0 0 11px;
}
.panel-heading {

    font-weight: 700;

}
.col-xs-6.col-sm-6.date-pick {

    padding-right: 0;

}
#txtsub {

    width: 100%;
    border: 1px solid #ccc;
    border-radius: 2px;
    height: 22px;

}
.fa.fa-info-circle {
    font-size: 16px !important;
    padding: 3px 0 0 4px;
}

.tooltip-inner {
  background-color:#f1b454 !important;
  border:1px solid#c48015;
  color: #000;
  text-align:left;
  width:auto;
}


.tooltip.left .tooltip-arrow {
  border-left-color: #f1b454;
}
.panel-heading.fixed-width {
    position: fixed;
    width: 98.7%;
    z-index: 999;
    height: 20px;
    top: 0px;
}
.panel-body.fixedon {

    padding: 20px 0 0 0 !important;

}
.text-demo:hover .collapse
{
display:block;
}
#lnkref
{
margin-left: -8px;
}
.tab-one
{
        border: 1px solid #db6f6f !important;
}
.tab-one td
{
        border: 1px solid #db6f6f !important;
}
.tab-one tr
{
        border: 1px solid #db6f6f !important;
}

#lbl1 {

    color: #f20f0f;
    font-weight: 700;
    text-shadow: none;

}
#lbl2 {
  color: #f20f0f;
    font-weight: 700;
    text-shadow: none;
}
.control-width.date-clos {
    width: 100%;
}
.RadGrid .rgHeader{
    padding-top: 0px !important;
    padding-bottom: 0px !important;
 }
 input[type="file"] {

    display: block;
    float: left;
}
.fa.fa-plus-circle {
    font-size: 17px !important;
    color: #f00 !important;
}
#RadGrid1_GridData 
{
    height:79px !important;
}
#RadGrid2_GridData 
{
      height:88px !important;
}
.control-label-width.sta {
    width: 8%;
    margin-top: 3px;
}
.control-width.stat {
    width: 38%;
}
.control-width.assi {
    width: 83%;
}
.control-label-width.assi {
    width: 50%;
}
.panel-default {

    border-color: #ddd;
    margin: 0;

}
.control-width.assi.onw {
    width: 95%;
}
#txtmod {

    width: 86%;
    border: 1px solid #ccc;
    border-radius: 2px;
    height: 24px;

}
#txttime {

    width: 63%;

}
</style>

</head>
<body >
<%--onload="HideProgress();"--%>
  <form id="Form1"  runat="server" method="post" class="form-horizontal" >
  <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
          <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
     <asp:ValidationSummary ID="vs" ValidationGroup="basicdetails" ShowMessageBox="true" ShowSummary="false" runat="server" />

<%--<div id="loading">
        <div id="loadingimage" style="color:white; font-size: 17px; line-height: 55px; font-family: verdana;
            text-align: center;">
            <img src="Images/loading1.gif" width="20px" height="20px" />
        </div>
    </div>--%>
 <div class="row" style="display:none;">
<div class="span12">
<span id="error" style="color: Red; display: none"> ~ ` ! ^ & ( ) _ { } [ ] | \ : ; " < > ? Special Characters not allowed</span>
</div></div>

 
<div class="row" style="padding: 0px 0px 0px 0px !important;">
  <div class="col-md-12 col-sm-12" style="padding: 0 !important;">
  <div class="col-md-12 col-sm-12" style="padding: 0 !important;">
   <div class="container-fluid"> 
    <div class="panel panel-default" style="">
       <div class="panel-heading fixed-width"><h5> <i class="fa fa-book" aria-hidden="true"></i> <asp:Label ID="lblhd" runat="server" Text=" Add Support Ticket"  ></asp:Label> <img style="width: 5.3%; float: right; margin-top: -3px;" src="images/zaxis.png"/></h5></div>

       
       
        <div class="panel-body fixedon">
        <div class="row" style="margin:0 0 0 0px !important;">
    <div class="col-md-12">	
      <div class="span1-one width-name-btn" style=" width: 6%;
width: 10%;text-align: right; float: right; margin-top: 2px !important;">
                    
            
               <asp:Button ID="Button1" Visible="false" class="btn btn-success"  runat="server" Text="Save" />
               <asp:ImageButton  ID="ImageButton1"  OnClientClick="if(Page_ClientValidate('basicdetails')) ShowProgress();"  Enabled="true"   runat="server"  
                   ImageUrl="~/images/save20x20.png" Height="20" Width="20" ToolTip ="Save"  />
               <asp:ImageButton ID="Button2"    runat="server" ToolTip="Reset" 
                 ImageUrl="~/images/reload20x20.png"   CausesValidation="False" />

         
                   
                </div></div></div>
 

  <div class="row" style="margin-top:0px;">
    <div class="col-md-12">	                             
                                    <label class="control-label-width">
                                      Scope of Ticket: <span style="color: Red;">*</span></label>
                                    <div class="control-width">
                                        <asp:DropDownList ID="ddltyp" style="width: 50% !important;"  runat="server" AutoPostBack="true"    >
                                         <asp:ListItem Text="Select a value" Value="">  </asp:ListItem>
                                         <asp:ListItem Text="New Component/Feature required in Application" Value="N">  </asp:ListItem>
                                         <asp:ListItem Text="Software Related Issue in App" Value="B">  </asp:ListItem>
                                         <asp:ListItem Text="Network/Hardware Related Issue." Value="H">  </asp:ListItem>
                                     
                                        </asp:DropDownList>

                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validationposition"
                                            runat="server" InitialValue="" ValidationGroup="basicdetails" ErrorMessage="Type of request required"
                                            ControlToValidate="ddltyp" ForeColor="Red" Display="none"></asp:RequiredFieldValidator>
                                    </div>
                            
                         							
			  <a data-toggle="tooltip" data-placement="left" title="Choose type of request"><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>
                        
                        
                        </div></div>




 <div class="row" style="margin-top:0px;">
    <div class="col-md-12">	                             
                                    <label class="control-label-width">
                                     	Module in which above scope is applicable: <span style="color: Red;">*</span></label>
                                    <div class="control-width">
                                   
                                        <asp:DropDownList ID="ddlProd" style="width: 50% !important;" AppendDataBoundItems="true"  runat="server" AutoPostBack="true"    >
                                         <asp:ListItem Text="Select a value" Value="">  </asp:ListItem>
                                     

                                        </asp:DropDownList>

                                       

                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="validationposition"
                                            runat="server" InitialValue="" ValidationGroup="basicdetails" ErrorMessage="Product required"
                                            ControlToValidate="ddlProd" ForeColor="Red" Display="none"></asp:RequiredFieldValidator>
                                    </div>
                            
                         							
			  <a data-toggle="tooltip" data-placement="left" title="Choose Module"><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>
                        
                        
                        </div></div>



 <div class="row" style="margin-top:0px;">
    <div class="col-md-12">	                             
                                    <label class="control-label-width">
                                       Sub Module/Component of selected option: <span style="color: Red;">*</span></label>
                                    <div class="control-width">
                                   
                                        <asp:DropDownList ID="ddlsubmod" style="width: 50% !important;" AppendDataBoundItems="true"  runat="server"  >
                                         <asp:ListItem Text="Select a value" Value="">  </asp:ListItem>
                                     
                                        </asp:DropDownList>

                                        
                                        <asp:LinkButton ID="lnkadd_sub" runat ="server" class="pop6" Visible ="false" ToolTip="Add new" > Add </asp:LinkButton>
                                         &nbsp; <asp:LinkButton ID="lnk_ref" runat ="server" Visible ="false" ToolTip ="Refresh"> Refresh </asp:LinkButton>
                                        
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="validationposition"
                                            runat="server" InitialValue="" ValidationGroup="basicdetails" ErrorMessage="Sub Module required"
                                            ControlToValidate="ddlsubmod" ForeColor="Red" Display="none"></asp:RequiredFieldValidator>
                                    </div>
                            
                         							
			  <a data-toggle="tooltip" data-placement="left" title="Choose Sub Module"><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>
                        
                        
                        </div></div>

   <asp:Panel ID="pnl1" runat="server">

    <div class="row" style="margin-top:10px;display:none" >
    <div class="col-md-12">		
  		
                       
                               
                                    <label class="control-label-width">
                                        Subject: <span style="color: Red;">*</span></label>
                                    <div class="control-width">
                                         <asp:TextBox ID="txtsub" runat="server" onblur="textBoxOnBlur(this);"  class="span12" MaxLength="49" placeholder=" Short Description"></asp:TextBox>
<%--
                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="validationposition"
                                        runat="server" ErrorMessage="Subject required" ControlToValidate="txtsub" ValidationGroup="basicdetails"
                                        ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                    </div>                                                      
                          	
                           <a data-toggle="tooltip" data-placement="left" title="Support ticket subject."><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>
  
                        </div></div>
         <div class="row" >
<div class="col-md-12" style="">
						   
<label class="control-label-width" >
                               Elaborate your query with descriptive text:
                                    </label>
                                <div class="control-width">
                                   
										   <asp:TextBox ID="txtrem" runat="server" placeholder="Description" class="" style="height: 101px !important;resize:none; width: 100%;border-radius: 2px;border: 1px solid #ccc;" onkeypress="return isAdd(event);" TextMode="MultiLine" MaxLength="3000" >
                                           </asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="validationposition"
                                        runat="server" ErrorMessage="Description required" ControlToValidate="txtrem" ValidationGroup="basicdetails"
                                        ForeColor="Red" Display="none"></asp:RequiredFieldValidator>

                                </div>
                                <a data-toggle="tooltip" data-placement="left" title="Description of issue."><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>

                                <br />
                           
                                        
                        </div>
            

        </div>
           
    

 <div class="row"  id="fuprw" runat="server">
<div class="col-md-12" style="">
						   
            <label class="control-label-width" >
                                Attach supporting documents i.e. screen shot or any other documentary evidence to understand your query in-depth<span style="color:#ff0000;">(Doc Limit - 20MB )</span>
                                    </label>
                                <div class="control-width">
                                   
										 <%--  <asp:LinkButton ID="lnk" runat="server" Enabled ="true" ToolTip="Upload documents" class="pop3" > Click here to upload documents</asp:LinkButton>
--%>
                                            <asp:FileUpload ID="fupl" runat="server" />       
                                            <asp:LinkButton ID="lnkaddfile" runat="server" style="float:left;font-size:16px;" ToolTip="Click on Add to upload"> <i class="fa fa-plus-circle" aria-hidden="true"></i>
 Click here to attach file</asp:LinkButton>       
                                             <br />                              
                                          <%--  <asp:FileUpload ID="fup2" runat="server" />

                                            <asp:FileUpload ID="fup3" runat="server" />
                                            <asp:FileUpload ID="fup4" runat="server" />
                                            <asp:FileUpload ID="fup5" runat="server" />--%>

                                </div>      
                                 <a data-toggle="tooltip" data-placement="left" title="Attach Screenshot of error"><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>                        
                         
                        </div>
                    
            


           

        </div>

          <div class="row" id="fuprw2" runat="server">
             <div class="col-md-12" style="padding: 0px;">

             <telerik:RadGrid ID="RadGrid1" EnableViewState="true"   Skin="Office2007"    CSSClass="table table-bordered" 
            AllowPaging="true" CellSpacing="0" GridLines="none"   Height ="130px" 
             AllowSorting="false" ShowHeader="true"     AllowFilteringByColumn="false"  runat="server"  PageSize="100"  >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView   DataKeyNames="id"  NoMasterRecordsText="No records to display" CommandItemDisplay="Top" >
               <NoRecordsTemplate>
      <div>
        No records to display</div>
    </NoRecordsTemplate>
              <CommandItemTemplate >
                            <div style="padding: 1px 5px;float:right;display:none">
               <asp:LinkButton ID="LinkButton2" Visible="true" runat="server" CommandName="Rebind" ToolTip="Refresh"  ><img style="border:0px;vertical-align:middle;" alt="" src="Images/reload20x20.png"/></asp:LinkButton>
                  </div>
                </CommandItemTemplate>
              <Columns>

             <telerik:GridTemplateColumn UniqueName="edt" HeaderText=""    ItemStyle-Wrap="false" AllowFiltering="false" HeaderStyle-Width="90px" ItemStyle-Width="90px">                                                   
                            <ItemTemplate>                             
                               
            <asp:LinkButton ID="LinkButton1" runat="server" border="0"  CommandName="revoke"  OnClientClick="if (! Confirm1()) return false;" ToolTip ="Revoke">
                                 
                                 <i class="fa fa-trash-o" aria-hidden="true" style="font-size:14px !important;"></i>

                                 </asp:LinkButton>&nbsp;&nbsp;
  <asp:LinkButton ID="LinkButton3" runat="server" ToolTip="Download" Text="" CommandName="download" CssClass="cls-res" ><i class="fa fa-download" aria-hidden="true" style="font-size:14px !important;"></i></asp:LinkButton>


<%-- 
  <asp:LinkButton ID="lnkedit" runat="server"  Text="Documents"  class="pop2"  ToolTip="Update Record"> <i class="fa fa-wrench" aria-hidden="true"></i>
--%>

 </asp:LinkButton>
 
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

        </asp:Panel>

        <asp:Panel ID="pnl2" runat="server" Visible="false">


          <div class="row" style="margin-top:10px;">
    <div class="col-md-12">		
  		
                                    <label class="control-label-width sta">
                                        Status: <span style="color: Red;">*</span></label>
                                    <div class="control-width stat">
                   
                                                            <asp:DropDownList ID="ddlstatus" AppendDataBoundItems="true"  runat="server"  >
                                                            <asp:ListItem Text="Select a value" Value="">  </asp:ListItem>
                                                            <asp:ListItem Text="Acknowledge" Value="A">  </asp:ListItem>
                                                            <asp:ListItem Text="Complete" Value="C">  </asp:ListItem>                                                            
                                                            </asp:DropDownList>

                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="validationposition"
                                                                runat="server" InitialValue="" ValidationGroup="basicdetails1" ErrorMessage="STatus required"
                                                                ControlToValidate="ddlstatus" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                     
                                         

                                    </div>     
                                    
                                            <a style="float: right;

margin-right: 22px;"data-toggle="tooltip" data-placement="left"  title="Current status of the ticket."><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>                                                 
                    
                        </div></div>

                          <div class="row" style="margin-top:10px;">
    <div class="col-xs-5 col-sm-5">		
  		
                                    <label class="control-label-width assi">
                                        Assign to: <span style="color: Red;">*</span></label>
                                    <div class="control-width assi">
                  
                                                            <asp:DropDownList ID="ddlassign" AppendDataBoundItems="true"  runat="server"  >
                                                            <asp:ListItem Text="Select a value" Value="">  </asp:ListItem>
                                                           </asp:DropDownList>

                                                       <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                                                                runat="server" InitialValue="" ValidationGroup="basicdetails1" ErrorMessage="Assign to required"
                                                                ControlToValidate="ddlassign" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                    
                                                

                                    </div>                                                      
                     <a data-toggle="tooltip" data-placement="left" title=" Select name of whom you want to assign the task."><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>
                        </div>
                        
                          <div class="col-xs-7 col-sm-7">		
  		
                                    <label class="control-label-width assi" style="width: 90.5%;">
                                        Priority: <span style="color: Red;">*</span></label>
                                    <div class="control-width assi">
                  
                                                            <asp:DropDownList ID="ddlPrior" AppendDataBoundItems="true"  runat="server"  >
                                                            <asp:ListItem Text="Select a value" Value="">  </asp:ListItem>
                                                            <asp:ListItem Text="Normal" Value="N" Selected >  </asp:ListItem>
                                                            <asp:ListItem Text="Hypersensitive" Value="H">  </asp:ListItem>
                                                           </asp:DropDownList>

                                                       <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                                                                runat="server" InitialValue="" ValidationGroup="basicdetails1" ErrorMessage="Assign to required"
                                                                ControlToValidate="ddlassign" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                    
                                                

                                    </div>                                                      
                     <a data-toggle="tooltip" data-placement="left" title="Choose job priority."><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>
                        </div>
                        
                        
                        </div>

                        

                           <div class="row" style="margin-top:10px; " >
<div class="col-xs-12 col-sm-12" style="padding:0 !important;">	
<div class="col-xs-5 col-sm-5">		
<label class="control-label-width">
                                       Expected Close Date: <span style="color: Red;">*</span></label>
                                   
                                    <div class="control-width  date-clos">

                                       <telerik:RadDateTimePicker ID="dtExp" runat="server" style="width:100% !important;"  AutoPostBackControl="Both"  TimeView-Interval="00:30">
                                        <DateInput
        DateFormat="dd-MMM-yyyy hh:mm tt"
        DisplayDateFormat="dd-MMM-yyyy hh:mm tt"  >
    </DateInput>
    
      </telerik:RadDateTimePicker>


                                    
</div>
                                        

          
                          	
                            
                        </div>


                          
    <div class="col-xs-5 col-sm-5">		
  		
                                    <label class="control-label-width">
                                        TAT (In minutes): <span style="color: Red;">*</span></label>
                              
                     <div class="control-width">
                                        <asp:HiddenField ID="TXTTIME1" runat="server" />
                                                         <asp:TextBox ID="txttime" runat="server" onkeypress="return isNumberKey(event)"   MaxLength="8" Enabled="false" ></asp:TextBox>

                                                       <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                                                                runat="server" InitialValue="" ValidationGroup="basicdetails1" ErrorMessage="Assign to required"
                                                                ControlToValidate="ddlassign" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                        </div>
                                         

                                                                                 
                    
</div>
</div>
</div>
<div class="row" style="margin-top:10px;">
<div class="col-md-12">		
  		
                                    <label class="control-label-width assi">
                                        Remarks:<span style="color: Red;">*</span></label>
                                    <div class="control-width assi onw">
                  
                                                    <asp:TextBox ID="txtAsgRem" runat="server" placeholder="Remarks" class="" style="height: 101px !important;resize:none; width: 100%;border-radius: 2px;border: 1px solid #ccc;" onkeypress="return isAdd(event);" TextMode="MultiLine" MaxLength="3000" >
                                           </asp:TextBox>         

                                                       <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="validationposition"
                                                                runat="server" InitialValue="" ValidationGroup="basicdetails1" ErrorMessage="Assign to required"
                                                                ControlToValidate="ddlassign" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>--%>
                                                    
                                                

                                    </div>                                                      
                     <a data-toggle="tooltip" data-placement="left" title=" Select name of whom you want to assign the task."><i class="fa fa-info-circle" aria-hidden="true"></i>
</a>
                        </div></div>

     

   <div class="row">
  <div class="col-md-12" style="padding-left: 5px !important; padding-right: 5px !important;">
    

     <telerik:RadGrid ID="RadGrid2" EnableViewState="true"   Skin="Office2007" PageSize="50"   CSSClass="table table-bordered" 
            AllowPaging="True" CellSpacing="0" GridLines="none" 
             AllowSorting="True" ShowHeader="true"     AllowFilteringByColumn="false"  runat="server" Height="165" >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView   DataKeyNames="fid"  NoMasterRecordsText="No records to display" CommandItemDisplay="Top" >
               <NoRecordsTemplate>
      <div>
        No records to display</div>
    </NoRecordsTemplate>
              <CommandItemTemplate>
                             <div style="padding: 1px 5px;float:right;">
               <asp:LinkButton ID="LinkButton4" Visible="true" runat="server" CommandName="refresh" ToolTip="Refresh" ><img style="border:0px;vertical-align:middle;" alt="" src="Images/reload20x20.png"/></asp:LinkButton>
                  </div>
                 
                     
                    
                </CommandItemTemplate>
              

               

                        <Columns>
                         
            
                      
                      <telerik:GridTemplateColumn UniqueName="doc"  HeaderText="DOWNLOAD" HeaderStyle-Width="80" >
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



        </asp:Panel>


      </div>

       <div class="modal hide" id="addnewrecord">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    ×</button>
                                <h3>
                                    Add Sub module</h3>
                            </div>
                            <div class="modal-body">
                                <asp:TextBox ID="txtsubmod1" runat ="server"> </asp:TextBox>
                                <asp:Button ID="btn1" runat="server" Text="Submit"   />
                            </div>
                        </div>
    

    </div>
  </div>
  </div>
  
  <%--
    <div class="col-md-6 col-sm-6" style="padding: 0 7px 0px 0 !important;">
  <h3 style="margin: 24px 0 0 0;padding: 3px 0 3px 5px;background-color: #286090;color: #fff; ">Support Ticket</h3>
  <telerik:RadGrid ID="RadGrid1" EnableViewState="true"   Skin="Office2007"    CSSClass="table table-bordered" 
            AllowPaging="false" CellSpacing="0" GridLines="none"   height ="450"
             AllowSorting="TRUE" ShowHeader="true"     AllowFilteringByColumn="false"  runat="server"  >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView   DataKeyNames="BRTRID"  NoMasterRecordsText="No records to display" CommandItemDisplay="Top" >
               <NoRecordsTemplate>
      <div>
        No records to display</div>
    </NoRecordsTemplate>
              <CommandItemTemplate >
                            <div style="padding: 1px 5px;float:right;">
               <asp:LinkButton ID="LinkButton2" Visible="true" runat="server" CommandName="Rebind" ToolTip="Refresh"  ><img style="border:0px;vertical-align:middle;" alt="" src="Images/reload20x20.png"/></asp:LinkButton>
                  </div>
                </CommandItemTemplate>
              <Columns>
            
               <telerik:GridTemplateColumn UniqueName="edt" HeaderText=""    ItemStyle-Wrap="false" AllowFiltering="false" HeaderStyle-Width="50px" ItemStyle-Width="50px">                                                   
                            <ItemTemplate>                             
                                <asp:LinkButton ID="btnedit" runat="server" border="0" Text ="Edit"  class="pop2" Visible ="false" > <i class="fa fa-pencil-square-o" aria-hidden="true" style="font-size:14px !important;"></i>
 </asp:LinkButton>&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton1" runat="server" border="0"  CommandName="revoke"  OnClientClick="if (! Confirm1()) return false;" ToolTip ="Revoke">
                                 
                                 <i class="fa fa-trash-o" aria-hidden="true" style="font-size:14px !important;"></i>

                                 </asp:LinkButton>&nbsp;


  <asp:LinkButton ID="lnkdownload" runat="server"  Text="Documents"  class="pop5"  ToolTip="View Document"> <i class="fa fa-download" aria-hidden="true" style="font-size:14px !important;"></i>
 </asp:LinkButton>
 
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
--%>
  </div></div>



</form>
    <script>
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
</script>

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

