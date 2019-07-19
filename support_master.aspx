<%@ Page Title="" Language="VB" AutoEventWireup="false" CodeFile="support_master.aspx.vb" Inherits="_Default" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="css/font-awesome.min.css" />
    <link rel="stylesheet" type="text/css" href="css/nwlead-bootstrap.min.css" />

    <script src="scripts/jquery-1.11.1.min.js" type="text/javascript"></script>
 <script type="text/javascript" src="source/jquery.fancybox.js?v=2.1.5"></script>
    <link rel="stylesheet" type="text/css" href="source/jquery.fancybox.css?v=2.1.5" media="screen" />
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-buttons.css?v=1.0.5" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-buttons.js?v=1.0.5"></script>
    <link rel="stylesheet" type="text/css" href="source/helpers/jquery.fancybox-thumbs.css?v=1.0.7" />
    <script type="text/javascript" src="source/helpers/jquery.fancybox-thumbs.js?v=1.0.7"></script>
    <script type="text/javascript" src="source/helpers/jquery.fancybox-media.js?v=1.0.6"></script>


    <style type="text/css">
        *
        {
            font-size: 10px;
        }
        .rgHeader {
         font-size: 10px !important;
}
        
        .form-control
        {
            height: 25px !important;
            padding: 0px 6px !important;
            font-size: 12px !important;
            border-radius: 2px;
            box-shadow: none;
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
        
        .container-fluid {

    padding: 0px 0px !important;

}
        .accordion-toggle:hover
        {
            text-decoration: none;
        }
        .accordion-toggle:focus
        {
            text-decoration: none;
        }
        .glyphicon
        {
            float: right;
            font-size: 12px !important;
            font-weight: 400 !important;
            color: #fff;
        }
        .accordion-toggle
        {
            display: block;
            padding: 0px 0;
            font-size: 10px;
            font-weight: 400;
            color: #fff !important;
        }
     
        
        .accordion-toggle.tran
        {
            display: inline !important;
        }
        .refresh-icon
        {
            float: right;
            font-size: 15px;
            padding: 0 10px 0 0;
            color: #fff !important;
        }
        .Profile-page .panel-heading
        {
            color: #fff;
            background-color: #286090;
            border-color: #204d74;
            text-align: left;
            font-size: 10px;
            padding: 1px 5px;
        }
        .panel
        {
            margin-bottom: 0;
        }
        #RadGrid15_GridData
        {
            height: 110px !important;
        }
        .header-title1
        {
            padding: 0 0 0 0px;
        }
        .col-md-3.select-box1 
        {
            width: 23% !important;
}

.panel-body.bg {

   background-color: #ffffff;

}
.col-md-9.select-box5
{
    width: 77% !important;
}
.header-title {
    margin: 0 !important;
    width: 100%;
}
.glyphicon {

    color: #3c945a !important;
}
.control-label-width {
    width: 8%;
    float: left;
    font-weight:400 !important;
    margin:0 !important;
}
.control-width {

    float: left;

}
.control-label-width1 {
width: 18%;
    float: left;
    font-weight:400 !important;
    margin: 3px 0 0 0 !important;
}
.control-width1 {

    width: 72%;
    float: left;
}
.rcTable.rcSingle {

    width: 100% !important;

}

.control-label-width5 {

    width: 17%;
    float: left;
    font-weight: 400 !important;
    margin: 3px 0 0 0 !important;

}
.control-label-width5.month-one {
    width: 25% !important;
}
.control-width5 {
width: 72%;
float: left;
}
html body .riSingle .riTextBox[type="text"] {

    border-radius: 2px;
    border: 1px solid #ccc;
    font-size: 10px;
}
.panel-body {

    padding: 0 !important;

}
 .fa.fa-plus-square {

    font-size: 24px;
    color: #13a830;
    margin: -1px 0 0 0;

}
.fa.fa-search {

    font-size: 11px;
    color: #fff;

}
#lnkgo {

    padding: 4px;
    background-color: #286090;
    border-radius: 4px;

    border: 1px solid #1d5381;
    display: block;
    width: 21px;

}
#ddlbrn {

    width: 100%;
    height: 21px;
    border: 1px solid #ccc;
    border-radius: 2px;

}
#ddlcal 
{
     width: 100%;
    height: 21px;
    border: 1px solid #ccc;
    border-radius: 2px;
}
#RadGrid1_GridData {
height:407px !important;
}
#RadMonthYearPicker1_wrapper {

    width: 135px !important;

}
.panel-default {
 border-color: #f0f0f0 !important;
}
.RadCalendar {

    display: inline-table !important;
   
}
.row.bg-color {

    background-color: #286090;
    padding: 2px 9px;

}
.panel-heading {

    font-weight: 700;

}
#lblhd {

    color: #fff;
    font-weight: 700;

}
.col-xs-1.search {

    width: 20px;

}
#lblhd {

    color: #181616;
    font-weight: 700;
    vertical-align: middle;
    display: block;
    height: 27px;
    display: flex;
    align-items: center;
    font-size: 11px;

}
.fa.fa-trash-o {

    color: #e31919 !important;

}
.fa.fa-eye {

    color: #2c9917 !important;

}
.col-xs-1.search.re 
{
   width: 88px !important;
}
#lnkadd:hover 
{
  text-decoration:none !important;  
}
#lnkadd {
    padding: 3px 6px;
    background-color: #e04040;
    color: #fff;
    border-radius: 2px;
    float: right;
    margin-right: 8px;
}


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
.fa.fa-wrench {
    color: #2252ac !important;
    font-size: 12px !important;
}
 .fa.fa-commenting-o {
    color: #d71b12 !important;
    font-size: 12px !important;

}
.rgHeader {
    white-space: nowrap !important;
}
#ddlsta {
    height: 20px;
    border-radius: 2px;
    border: 1px solid #ccc;
}
#btngo
{
    background-color: #286090;
padding: 4px 5px;
color: #fff;
border-radius: 2px;
}
.width-sel {
    font-weight: 400;
  margin: 2px 0 0 0px;
    width: 80px;
    float: left;
}
.row {
    margin-right: 0 !important;
    margin-left: 0 !important;
}
.left-right.bg11 {
    color: #f00;
    float: right;
    width: auto;
    margin: 2px 0 0 0;
}
.badge a
{
     color: #fff !important;
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
                 width: 900,
                 height: 460,
                 padding: 0,
                 openEffect: 'elastic',
                 openSpeed: 500,
                 type: 'iframe',
                 closeEffect: 'elastic',
                 closeSpeed: 500,
                 autoSize: false,
                 closeClick: true

  });
              $('.pop8').fancybox({
                 width: 800,
                 height: 500,
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
                 height: 390,
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
                 width: 600,
                 height: 453,
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
<script type = "text/javascript">
function Confirm1() {
return confirm("Are you sure you want to revoke entry?")
}
</script>
</head>
<body onload ="HideProgress();">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
    </telerik:RadWindowManager>
    <div id="loading">
        <div id="loadingimage" style="color:white; font-size: 17px; line-height: 55px; font-family: verdana;
            text-align: center;">
            <img src="Images/loading1.gif" width="20px" height="20px" />
        </div>
    </div>
    <div class="Profile-page">
        <div class="container-fluid">
            <div class="row" style="margin: 0 !important;">
                <div class="col-xs-12 left-right" style="padding: 0px 0 0 3px;">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                           <i class="fa fa-book" aria-hidden="true"></i>  Support Ticket
                         </div>
                    <div class="panel-body bg">
                    <div class="row" style=" padding: 5px 0 5px 6px !important;" >
                      <div class="col-xs-4 col-sm-4" style="padding: 0px 0 0 2px;" id="top1" runat="server" visible="true">
                                  
                                    <div class="control-width9" >
                                   <label class="width-sel">Choose Status: </label> 
                                     <asp:DropDownList ID="ddlsta" AppendDataBoundItems="true" class="span12" runat="server" Visible ="true">      
                                     <asp:ListItem Text="" Value="select a value"></asp:ListItem>                                                      
                                        </asp:DropDownList>
                                        <asp:LinkButton ID="btngo" runat="server" Text="Go"></asp:LinkButton>

                                    </div>

                                    
                                    </div>

  
   <div class="col-xs-1 search re" style="float:right; padding: 0px 0 0 3px; margin-right: 8px;">
 <asp:LinkButton ID="lnkadd" runat="server"  class="pop8" ToolTip="New Ticket"   > <i class="fa fa-plus" aria-hidden="true"></i> New Ticket
        </asp:LinkButton>
                </div> 
                 <div class="col-xs-3 left-right bg11" style="padding: 0px 0 0 0px;">
       NOTE: TAT allotted is as per the working hours. 
        </div>
         </div>

  <div class="row">
            <div class="col-md-8" style=" padding: 5px 0 5px 6px !important;background-color: #f5f2f2;"   >			
                       <table width="100%" style="" >
                       <tr><td width="15%">
                        Ticket Inititated
                       </td>
                       <td width="5%">
                       <span style="background-color: #000;color: #fff !important;" class="badge"><asp:LinkButton ID="lbl3500" runat="server" Text ="0" CommandArgument ="3500" ></asp:LinkButton></span>
                       </td>
                       <td width="15%">
                       Ticket Acknowledged
                       </td>
                      <td width="5%">
                      <span style="background-color: #1b51a6;color: #fff !important;" class="badge">
                      <asp:LinkButton ID="lbl3501" runat="server" Text ="0"  CommandArgument ="3501"></asp:LinkButton></span></td>
                      <td width="15%">
                      Ticket Re-opened
                       </td>
                       <td width="5%"><span style="background-color: #b0211c;color: #fff !important;" class="badge">  <asp:LinkButton ID="lbl3507" runat="server" Text ="0" CommandArgument ="3507"> </asp:LinkButton></span> </td>
                       </tr>
                       <tr>
                       <td height="3px">
                        </td></tr>
                       <tr>
                       <td width="15%">
                       Work in-Process
                       </td>
                       <td width="5%">
                       <span style="background-color: #1b51a7;color: #fff !important;" class="badge">
                       <asp:LinkButton ID="lbl3502" runat="server" Text ="0" CommandArgument ="3502"></asp:LinkButton></span></td>
                       
                       <td width="15%">
                     Task Completed and Ticket Closed
                       </td>
                       <td width="5%">
                       <span style="background-color: #3fa310;color: #fff !important;" class="badge">
                       <asp:LinkButton ID="LBL3508" runat="server" Text ="0" CommandArgument ="3508"></asp:LinkButton></span></td>

                           <td width="15%">
                   Ticket Forwarded to next individual
                       </td>
                      <td width="5%">
                      
                      <span style="background-color: #b01c9b;color: #fff !important;" class="badge">
                      <asp:LinkButton ID="lbl3506" runat="server" Text ="0" CommandArgument ="3506"></asp:LinkButton>
                      </span>
                      </td>
                       </tr>
                       <tr>
                       <td height="3px">
                        </td></tr>

                           <tr>
                       <td width="15%">
                      Ticket Assigned.
                       </td>
                      
                       <td width="5%">
                       <span style="background-color: #ec9d11;color: #fff !important;" class="badge">
                       <asp:LinkButton ID="lbl3505" runat="server" Text ="0" CommandArgument ="3505"></asp:LinkButton></span></td>
                       
                       <td width="15%">
                     Delivberables Submitted
                       </td>
                      <td width="5%">
                      <span style="background-color: #042b0f;color: #fff !important;" class="badge">
                      <asp:LinkButton ID="lbl3509" runat="server" Text ="0" CommandArgument ="3509"></asp:LinkButton></span></td>

                           <td width="15%">
                  TAT Extended
                       </td>
                      <td width="5%"><span style="background-color: #eb1515;color: #fff !important;" class="badge"><asp:LinkButton ID="lbl3510" runat="server" Text ="0" CommandArgument ="3510"></asp:LinkButton></span></td>
                       </tr>
                       </table>
                           
                        
                       
                        </div></div>
            

<div class="row" style="margin: 0 !important; padding: 0px !important; ">
 <div class="col-xs-12 left-right bg" style="padding: 0px 0 0 0px;">
                    
 <telerik:RadGrid ID="RadGrid1" EnableViewState="true"  RenderMode="Lightweight"  Skin="Office2007"    CSSClass="table table-bordered" 
            AllowPaging="true" Height="490" CellSpacing="0" GridLines="none"   AllowFilteringByColumn ="false" 
             AllowSorting="true" ShowHeader="true"       runat="server"  PageSize="100"  >
              <GroupingSettings CaseSensitive="false" />
              <MasterTableView   DataKeyNames="TICKETID"  NoMasterRecordsText="No records to display" CommandItemDisplay="Top"  >
               <NoRecordsTemplate>
      <div>
        No records to display</div>
    </NoRecordsTemplate>
              <CommandItemTemplate >
                <b>List of Tickets : <asp:Label ID="lblcnt" runat="server"></asp:Label></b>
                            <div style="padding: 1px 5px;float:right;">
               <asp:LinkButton ID="LinkButton2" Visible="true" runat="server" CommandName="Rebind" ToolTip="Refresh"  ><img style="border:0px;vertical-align:middle;" alt="" src="Images/reload20x20.png"/></asp:LinkButton>
                  </div>
                </CommandItemTemplate>
              <Columns>

             <telerik:GridTemplateColumn UniqueName="edt" HeaderText=""    ItemStyle-Wrap="false" AllowFiltering="false" HeaderStyle-Width="90px" ItemStyle-Width="90px">                                                   
                            <ItemTemplate>                             
                               
         <%--   <asp:LinkButton ID="LinkButton1" runat="server" border="0"  CommandName="revoke"  OnClientClick="if (! Confirm1()) return false;" ToolTip ="Revoke">
                                 
                                 <i class="fa fa-trash-o" aria-hidden="true" style="font-size:14px !important;"></i>

                                 </asp:LinkButton>&nbsp;&nbsp;--%>

                                  <asp:ImageButton  ID="lnkindicator" runat="server" />      &nbsp;
                              <asp:LinkButton ID="lnkdownload" runat="server"  Text="Documents"  class="pop5"  ToolTip="View Document"><i class="fa fa-eye" aria-hidden="true" style="font-size:14px !important;"></i>

                             </asp:LinkButton>&nbsp;


                               <asp:LinkButton ID="lnkcomm" runat="server"  Text="Documents"  class="pop3"  ToolTip="Add Communication">  <i class="fa fa-commenting-o" aria-hidden="true" style="color:Fuchsia"></i>
                             </asp:LinkButton>&nbsp;
                               <asp:LinkButton ID="lnkedit" runat="server"  Text="Documents"  class="pop8"  ToolTip="Update Record"> <i class="fa fa-wrench" aria-hidden="true"></i>
                             </asp:LinkButton>

 
							</ItemTemplate>
        </telerik:GridTemplateColumn>



                        <telerik:GridTemplateColumn UniqueName="vwcmn" HeaderText="REMARKS"    ItemStyle-Wrap="false" AllowFiltering="false" HeaderStyle-Width="90px" ItemStyle-Width="90px">                                                   
                            <ItemTemplate>     
                             <asp:LinkButton ID="lnkview" runat="server"  Text="View Remarks"  class="pop2"  ToolTip="View Remarks"> </asp:LinkButton>
                               
                            </ItemTemplate>

                        </telerik:GridTemplateColumn>

                           <telerik:GridTemplateColumn HeaderStyle-Width="120px" ItemStyle-Width="120px" AllowFiltering="false" HeaderText="Rating" UniqueName="Rating">
                                        <ItemTemplate>
                                              <telerik:RadRating RenderMode="Lightweight" ID="RadRating1" runat="server" AutoPostBack="false" Value='<%# Convert.ToDouble(Eval("STARRATING")) %>'
                                Precision="Exact" ReadOnly="true">
                            </telerik:RadRating>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

            
                       </Columns>
                      <PagerStyle AlwaysVisible="true"  PageSizeControlType="RadComboBox"  Mode="NextPrevAndNumeric" PageSizeLabelText="Display Rows: " PageSizes="5,10,25,50,100,250" ></PagerStyle>                 
                   </MasterTableView>
                  
                  <ItemStyle Wrap="false" CssClass="font"/> 
                  <AlternatingItemStyle Wrap="false" CssClass="font"/>
                 <HeaderStyle Font-Size="12px" Font-Names="Arial"  Font-Bold="true"  />

                      <clientsettings allowkeyboardnavigation="True"  >
                                                            <Selecting AllowRowSelect="True" />                                                        
           <Resizing AllowColumnResize="True"   AllowRowResize="false" ResizeGridOnColumnResize="false" ClipCellContentOnResize ="false"  EnableRealTimeResize="false" AllowResizeToFit="true" />               
              <Scrolling AllowScroll="true"  SaveScrollPosition="True" UseStaticHeaders="true" />
            </clientsettings>



            </telerik:RadGrid>

</div>  
</div>
<div class="row" style="margin: 0 !important; padding: 0px !important; ">
             
        </div>
            </div>
                </div>
            </div>
            </div>
     
                            
        </div>
    </div>
    </form>
  
</body>
</html>
