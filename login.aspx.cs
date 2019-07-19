using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;

public partial class home : System.Web.UI.Page
{
    nsbranch.commonfunctions cf = new nsbranch.commonfunctions();
    string macip = "";
	string IP = "";
    protected void Page_Load(object sender, EventArgs e)
    {
		
	//	 Response.Redirect("Offline.html");
		
        if (Request.QueryString["reason"] == "out")
        {
            radMessageWindow.RadAlert("<div style=color:#D8000C;>You are successfully Logout</div>", 300, 150, "Z-Axis Validation", "reloadpage", "images/success.png");
        }

        if (Request.QueryString["reason"] == "session")
        {
            radMessageWindow.RadAlert("<div style=color:#D8000C;>Zaxis was idle from the last 20+ minutes. As a security measure your session has been terminated.<br> Kindly Re-Login to access.</div>", 300, 150, "Z-Axis Validation", "reloadpage", "images/error.png");
        }

        if (Request.QueryString["logout"] != null)
        {
            if (Convert.ToString(Request.QueryString["logout"]) != "")
            {
                Session["ZxCurrUsrID"] = null;
                Session["ZxCurrEmpno"] = null;
                Session["ZxCurrzbaid"] = null;
                Session["ZxCurrMcIP"] = null;
                Session["ZxCurrUsrGrp"] = null;
                Session["ZxCurrMcNm"] = null;
                Session["ZxCurrsysDt"] = null;
                Session["UN"] = null;
                Session["PW"] = null;
                Session["BR"] = null;
                Session["LastLogin"] = null;
                Session["EmpName"] = null;
                Session["UserLoginTime"] = null;
                Session.Abandon();
                Session.RemoveAll();
                Response.Redirect("login.aspx");
            }

        }
        if (Page.IsPostBack == false)
        {

            HttpBrowserCapabilities bc = cf.browserreq();
            Session["bc"] = bc.Browser;

            IP = cf.remotehostip();
            Session["sessionid"] = Convert.ToString(Session.SessionID);
            if (IP.Contains("121.0.0."))
            {
                pnl_errorcode.Visible = false;
                pnl_login.Visible = true;
                BindBranchesDDL();
            }
            else
            {
                if (bc.Browser == "Firefox")
                {
                    pnl_errorcode.Visible = false;
                    pnl_login.Visible = true;
                    BindBranchesDDL();
                }
                else
                {
                    pnl_login.Visible = true;
                    pnl_errorcode.Visible = false;
                    BindBranchesDDL();
                    //lbl_error_code.Text = "This application is only compatible in Firefox.";
                    //radMessageWindow.RadAlert("<div style=color:#D8000C;>This application is only compatible in Firefox.</div>", 300, 150, "Z-Axis Validation", null, "images/error.png");
                    //return;
                }
            }

            Session["ZxCurrMcIP"] = IP;
           // macip = cf.getmacaddress();
         //   checkuserauth();

        }

    }

    //protected void Page_UnLoad(object sender, EventArgs e)
    //{
    //    cf.pagetracker("Login", Convert.ToString(Session["ZxCurrUsrID"]), Convert.ToString(Session["ZxCurrEmpno"]), Convert.ToString(Session["ZxCurrzbaid"]), "Page UnLoad", Convert.ToString(Session["bc"]));

    //}


    #region BUTTON LOGIN CLICK

    public void checkuserauth()
    {

        long Transid = cf.getdataid("Select max(transid)+1 as ID from webbranch.branchlogin");
        ViewState["authid"] = Transid;
        string str = "insert into webbranch.branchlogin(TRANSID,IP,LOGINSTATUS,requestdt,browsereq,sessionid) values('" + Transid + "','" + Convert.ToString(Session["ZxCurrMcIP"]) + "','F',sysdate,'" + Convert.ToString(Session["bc"]) + "','" + Convert.ToString(Session["sessionid"]) + "')";
        cf.perqry(str);
    }

    protected void btnsub_Click(object sender, EventArgs e)
    {
        string message = "";
        bool _isBranchValid = true;
        try
        {
            if (txtuname.Text.Trim() != "" && txtpwd.Text.Trim() != null)
            {
                DataTable objBranchLoginBranch = new DataTable();
               // objBranchLoginBranch = cf.GetLoginUserBranch(txtuname.Text.Trim());
			    objBranchLoginBranch = cf.GetLoginUserBranch(txtuname.Text.Trim(),ddlBraches.SelectedItem.Value);
                if (objBranchLoginBranch.Rows.Count > 0)
                {

                    Int32 _loginUserBranch = Convert.ToInt32(objBranchLoginBranch.Rows[0][0]);

                    if (_loginUserBranch != Int32.Parse(ddlBraches.SelectedItem.Value))
                    {

                        _isBranchValid = false;
                        radMessageWindow.RadAlert("<div style=color:#D8000C;>Invalid Branch Selection.</div>", 300, 150, "Z-Axis Validation", null, "images/error.png");
                        return;
                    }

                    DataTable dtresult = cf.getserversdata();
                    Session["servername"] = Convert.ToString(dtresult.Rows[0]["value"]);
                    Session["servername1"] = Convert.ToString(dtresult.Rows[0]["value1"]);
                    Session["servername2"] = Convert.ToString(dtresult.Rows[0]["value"]).Replace(":890", ":8989");
                    DataTable dtresult1 = cf.getfileserversdata();
                    Session["fileservername"] = Convert.ToString(dtresult1.Rows[0]["value"]);
                    Session["fileservername1"] = Convert.ToString(dtresult1.Rows[0]["value1"]);
                    Session["fileservername2"] = Convert.ToString(dtresult1.Rows[0]["value"]).Replace(":890", ":887");

                    Boolean authaa = false;
                    if (authaa == false)
                    {
                        DataTable objBranchLoginDetails = new DataTable();
                        objBranchLoginDetails = cf.Login(txtuname.Text.Trim(), txtpwd.Text.Trim(), ddlBraches.SelectedItem.Value.Trim());

                        if (objBranchLoginDetails.Rows.Count > 0)
                        {
                            if (Convert.ToString(objBranchLoginDetails.Rows[0]["USERNAME"]).ToLower() == txtuname.Text.Trim().ToLower() && Convert.ToString(objBranchLoginDetails.Rows[0]["USERPASS"]) == txtpwd.Text.Trim())
                            {
                                if (Convert.ToString(objBranchLoginDetails.Rows[0]["WEBACC"]) == "Y")
                                {

                                    Session["ZxCurrUsrID"] = Convert.ToString(objBranchLoginDetails.Rows[0]["USERID"]);
                                    Session["ZxCurrEmpno"] = Convert.ToString(objBranchLoginDetails.Rows[0]["EMPNO"]);
                                    Session["ZxCurrzbaid"] = Convert.ToString(objBranchLoginDetails.Rows[0]["ZBAID"]);


                                    string IPHost = Dns.GetHostName();

                                    Session["ZxCurrUsrGrp"] = Convert.ToString(objBranchLoginDetails.Rows[0]["GROUPCODE"]);
                                    Session["ZxCurrMcNm"] = IPHost;
                                    Session["ZxCurrsysDt"] = DateTime.Now;
                                    Session["UserDeptCode"] = Convert.ToString(objBranchLoginDetails.Rows[0]["DEPTCODE"]);
                                    Session["ZxCurrCompID"] = Convert.ToString(objBranchLoginDetails.Rows[0]["COMPID"]);

                                    Session["UN"] = Convert.ToString(objBranchLoginDetails.Rows[0]["USERNAME"]);
                                    Session["PW"] = Convert.ToString(objBranchLoginDetails.Rows[0]["USERPASS"]);
                                    Session["BR"] = Convert.ToString(objBranchLoginDetails.Rows[0]["branch"]);
                                    Session["webacs"] = Convert.ToString(objBranchLoginDetails.Rows[0]["WEBACC"]);
                                    Session["userdesgid"] = Convert.ToString(objBranchLoginDetails.Rows[0]["desgid"]);
                                    Session["TCCAdmin"] = Convert.ToString(objBranchLoginDetails.Rows[0]["tcc"]);
                                    Session["DRRAUTH"] = Convert.ToString(objBranchLoginDetails.Rows[0]["drr_auth"]);
                                    Session["DESGLEVEL"] = Convert.ToString(objBranchLoginDetails.Rows[0]["desglevl"]);
                                    Session["CURRDATE"] = Convert.ToString(objBranchLoginDetails.Rows[0]["currdate"]);
                                    Session["FROMDATE"] = Convert.ToString(objBranchLoginDetails.Rows[0]["fromdate"]);
                                    Session["brzone"] = Convert.ToString(objBranchLoginDetails.Rows[0]["brzone"]);
                                    
                                    if (Convert.ToString(Session["userdesgid"]) == "470" || Convert.ToString(Session["userdesgid"]) == "407" || Convert.ToString(Session["userdesgid"]) == "408" || Convert.ToString(Session["userdesgid"]) == "329" || Convert.ToString(Session["userdesgid"]) == "330" || Convert.ToString(Session["userdesgid"]) == "508")
                                    {
                                        Session["userdeptfol"] = "91";
                                    }
                                    else
                                    {
                                        Session["userdeptfol"] = "18";
                                    }
                                    string sql1 = "";
                                    sql1 = "update brvpn.user_master set logintime=sysdate where empno='" + Session["ZxCurrEmpno"].ToString() + "'";
                                    cf.perqry(sql1);
                                    if (objBranchLoginDetails.Rows[0]["logintime"] != null || objBranchLoginDetails.Rows[0]["logintime"] != "")
                                    {
                                        Session["LastLogin"] = Convert.ToString(objBranchLoginDetails.Rows[0]["logintime"]);
                                    }
                                    else
                                    {
                                        Session["LastLogin"] = DBNull.Value;
                                    }
									
									
									
								
	
									Session["LOCALDATE"] = Convert.ToString(objBranchLoginDetails.Rows[0]["gmtmnt"]);
									Session["RRPROC"] = Convert.ToString(objBranchLoginDetails.Rows[0]["RRPROC"]);
                                    Session["EmpName"] = Convert.ToString(objBranchLoginDetails.Rows[0]["name"]);
                                    Session["UserLoginTime"] = DateTime.Now;
                                    message = "Successfully Login";
																		
                                    InsertSuccessLogin(message);
                                    cf.pagetracker("Login", Convert.ToString(Session["ZxCurrUsrID"]), Convert.ToString(Session["ZxCurrEmpno"]), Convert.ToString(Session["ZxCurrzbaid"]), "after Login Load", Convert.ToString(Session["bc"]));

                                    if (Convert.ToString(Session["ZxCurrUsrGrp"]) == "ADMIN")
                                    {

                                        // Response.Redirect("dashboardbranch.aspx");
                                        if (getFeedbackStatus() == true)
                                        {
                                            
											
											//Response.Redirect("dashboardbranch.aspx", false);
											if (Convert.ToString(Session["DESGLEVEL"]) == "7" ||  Convert.ToString(Session["DESGLEVEL"]) == "8")
											{
												
												if (getdsrupdate() == true)
                                                 {
										        	 Response.Redirect("accsheet1.aspx", false);
													// Response.Redirect("dashboardbranch.aspx", false);
										          }
										         else
										          {
													  
													   if (Convert.ToString(Session["RRPROC"])=="Y")
									         	 {
											        if (getrrinfo() == false)
                                                     {
													 Response.Redirect("rr_profile.aspx", false);
												    }
												    else
												     {											 
													  Response.Redirect("dashboardbranch.aspx", false);
												    }
										          }
										          else
										        {
											       Response.Redirect("dashboardbranch.aspx", false); 
										      }
													  
													  
													  
											      //  Response.Redirect("dashboardbranch.aspx", false);
									             }
												
													
											}
										else
											{
												Response.Redirect("dashboardbranch.aspx", false);
												
											}
											
										
											
											
											
                                        }
                                        else
                                        {
                                            Session["pagename"] = "dashboardbranch.aspx";

                                            Response.Redirect("feedbackform.aspx", false);
                                        }
                                    }
                                    else
                                    {

                                        if (getFeedbackStatus() == true)
                                        {
                                           // Response.Redirect("virtualregisterdashboard.aspx", false);
										 //  Response.Redirect("MyLeads.aspx", false);

										 										 
										 if (Convert.ToString(Session["RRPROC"])=="Y")
										 {
											 if (getrrinfo() == false)
                                                 {
													 
										        	Response.Redirect("rr_profile.aspx", false);
												 }
												 else
												 {
													 
													 
													  Response.Redirect("UserDashboard.aspx", false);
												 }
										 }
										 else
										 {
											 Response.Redirect("UserDashboard.aspx", false);
										 }
										 
										      
										 
										 
                                        }
                                        else
                                        {
                                          //  Session["pagename"] = "virtualregisterdashboard.aspx";
										  Session["pagename"] = "MyLeads.aspx";

                                            Response.Redirect("feedbackform.aspx", false);
                                        }


                                    }
                                }
                                else
                                {
                                    radMessageWindow.RadAlert("<div style=color:#D8000C;>You are not authorised to access new branch module. Kindly continue with old pattern. </div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                                    return;
                                }

                            }
                            else
                            {
                                radMessageWindow.RadAlert("<div style=color:#D8000C;>Invalid Login Credentials.</div>", 300, 150, "Z-Axis Validation", null, "Images/error.png");
                                return;
                            }

                        }
                        else
                        {
                            radMessageWindow.RadAlert("<div style=color:#D8000C;>Invalid Login Credentials..</div>", 300, 150, "Z-Axis Validation", null, "Images/error.png");
                            return;
                        }
                    }
                    else
                    {

                        radMessageWindow.RadAlert("<div style=color:#D8000C;>This Machine is not authorized for login into the system</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                        return;
                    }


                }
                else
                {

                    if (_isBranchValid == true)
                    {

                        radMessageWindow.RadAlert("<div style=color:#D8000C;>Invalid Branch Selection.</div>", 300, 150, "Z-Axis Validation", null, "Images/warning.png");
                        return;
                    }

                    if (cf.statusMessage != "")
                    {

                        radMessageWindow.RadAlert("<div style=color: #D8000C;background-color:#FDD5CE;>" + cf.statusMessage.ToString() + "</div>", 300, 150, "Z-Axis Validation", null, "Images/error.png");
                        return;
                    }


                }
            }
            else
            {
                //  message = "Invalid Username";
                // InsertLoginAttempt(message);
                radMessageWindow.RadAlert("<div style=color:#D8000C;>Please Provide Credentials .</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                return;
            }
        }
        catch (Exception ex)
        {
            radMessageWindow.RadAlert("<div style=color: #D8000C;>" + ex.Message + "</div>", 300, 150, "Z-Axis Validation", null, "Images/error.png");

            return;
        }

       
    }

    #endregion

    #region BIND BRANCHES DDL

    public void BindBranchesDDL()
    {
        try
        {

            DataTable dt= new DataTable();
            dt= cf.getactvicebranches();
          
            ddlBraches.DataTextField = "zbaname";
            ddlBraches.DataValueField = "zBAID";

           
           
            if (dt.Rows.Count > 0)
            {
                ddlBraches.DataSource = dt;
                ddlBraches.DataBind();
                ddlBraches.Items.FindByValue("0").Selected = true;
            }
            else
            {


// Response.Write(cf.statusMessage.ToString());

                if (cf.statusMessage != "")
                {
                    if (cf.statusMessage.ToString().Contains("TNS:Connect timeout occurred") == true)
                    {
                        radMessageWindow.RadAlert("<div style=color:#D8000C;>System has an encounter some network problem from your machine. Advise you to Restart Application/ Machine.</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                        return;
                    }
                    else if (cf.statusMessage.ToString().Contains("TNS:no listener") == true)
                    {
                        radMessageWindow.RadAlert("<div style=color:#D8000C;>System has an encounter some network problem from your machine. Advise you to Restart Application/ Machine..</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                        return;
                    }
                    else if (cf.statusMessage.ToString().Contains("connection lost contact") == true)
                    {
                        radMessageWindow.RadAlert("<div style=color:#D8000C;>System has an encounter some network problem from your machine. Advise you to Restart Application/ Machine...</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                        return;
                    }
                    else if (cf.statusMessage.ToString().Contains("TNS:listener does not currently know of service requested in connect descriptor") == true)
                    {
                        radMessageWindow.RadAlert("<div style=color:#D8000C;>System has an encounter some network problem from your machine. Advise you to Restart Application/ Machine....</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                        return;
                    }
                    else
                    {
                        radMessageWindow.RadAlert("<div style=color: #D8000C;background-color:#FDD5CE;>System has an encounter some network problem from your machine. Advise you to Restart Application/ Machine......</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
                        return;
                    }



                }
            }

       }
        catch (Exception ex)
        {
            radMessageWindow.RadAlert("<div style=color:#D8000C;>System has an encounter some network problem from your machine. Advise you to Restart Application/ Machine.......</div>", 300, 150, "Z-Axis Validation", null, "Images/info.png");
            return;
       }



    }

    #endregion
    protected bool getFeedbackStatus()
    {

        return true;


    }
	
protected bool getrr_unack()
    {

	 DataTable dt= new DataTable();
            dt= cf.getdata("select count(*) from TT.BRANCH_PROFILE where leadstat='S' and zbaid='" + Convert.ToString(Session["ZxCurrzbaid"]) + "' and empno='" + Convert.ToString(Session["ZxCurrEmpno"]) + "'") ;
	
	if (Convert.ToInt32(dt.Rows[0][0]) >0 )		
		{
			
		 return true;
			
		}
		else
		{
			 return false;
		}
	


    }

	
	
	 protected bool getdsrupdate()
    {

	 DataTable dt= new DataTable();
         //  dt= cf.getdata("SELECT A.STDT,B.CNT FROM (SELECT TO_CHAR(STDT,'dd-Mon-yy') STDT FROM (SELECT TO_DATE((SELECT MNTHSTDT FROM RAHUL.MNTHFSTDAT),'dd-mon-yyyy') + ROWNUM -1 STDT FROM ALL_OBJECTS WHERE ROWNUM <= TO_DATE(SYSDATE-1,'dd-mon-yyyy')-TO_DATE(((SELECT MNTHSTDT FROM RAHUL.MNTHFSTDAT)),'dd-mon-yyyy')+1)) A,(SELECT TO_CHAR(RETAINDT,'dd-Mon-yy') RTDT,COUNT(*) CNT FROM TT.CREDITED_AMOUNT_ADD WHERE BRANCHID IN ('" + Convert.ToString(Session["ZxCurrzbaid"]) + "') AND MONTH_YEAR= TO_CHAR(SYSDATE,'Mon-yyyy') and CURSTS='A' group by to_char(Retaindt,'dd-Mon-yy') order by 1) b where a.stdt=b.rtdt(+) and b.cnt is null order by 1");
	
	//--- change on  01-Mar-2019 
	
	 dt= cf.getdata("SELECT A.STDT,B.CNT FROM (SELECT TO_DATE('26-Apr-2019', 'dd-Mon-YYYY') - 1 + ROWNUM AS STDT FROM ALL_OBJECTS WHERE TO_DATE('26-Apr-2019', 'dd-Mon-YYYY') - 1 + ROWNUM <= TO_DATE('31-Aug-2019', 'dd-Mon-YYYY')) A,  (SELECT TO_CHAR(RETAINDT,'dd-Mon-yy') RTDT,COUNT(*) CNT FROM TT.CREDITED_AMOUNT_ADD WHERE BRANCHID IN ('" + Convert.ToString(Session["ZxCurrzbaid"]) + "')  AND CURSTS='A' GROUP BY TO_CHAR(RETAINDT,'dd-Mon-yy') ORDER BY 1) B  where a.stdt=b.rtdt(+) and b.cnt is null and a.stdt<sysdate-1 and to_char(a.stdt,'Mon-yyyy') in (select month_year from tt.CREDITED_amount_branch where status is null and cad_id='" + Convert.ToString(Session["ZxCurrzbaid"]) + "') order by 1");
	
	if (dt.Rows.Count>0)		
		{
			
			String txt= " ";
			foreach(DataRow dr in dt.Rows)
{
   
   txt += Convert.ToString(dr["STDT"]) + " ,";
   
}
			
			
			txt= txt.Substring(0, txt.Length - 1);
			
			string str = "INSERT INTO tt.DSR_STOP(TID,ZBAID,EMPNO,KEYEDON,REMARKS,TYP) values(TT.dsrstop_SEQ.nextval,'" + Convert.ToString(Session["ZxCurrzbaid"]) + "','" + Convert.ToString(Session["ZxCurrEmpno"]) + "',sysdate,'" + txt + "','L')";
            cf.perqry(str);
			
			 return true;
			
		}
		else
		{
			 return false;
		}
	
	
	
       


    }
	
	
	
		 protected bool getrrinfo()
    {

	 DataTable dt= new DataTable();
            dt= cf.getdata("select * from TT.BRANCH_PROFILE where  empno='" + Convert.ToString(Session["ZxCurrEmpno"]) + "'") ;
	
	
	if (dt.Rows.Count>0)		
		{
			
		    string str = "update TT.BRANCH_PROFILE set zbaid='" + Convert.ToString(Session["ZxCurrzbaid"]) + "', APPLOGINDT=to_date('" + Convert.ToDateTime(Convert.ToString(Session["LOCALDATE"])).ToString("dd-MMM-yyyy HH:mm:ss") + "','dd-Mon-yyyy hh24:mi:ss'),LSTUPDON=sysdate,LSTUPDBY='" + Convert.ToString(Session["ZxCurrEmpno"]) + "' where  empno='" + Convert.ToString(Session["ZxCurrEmpno"]) + "'" ;
            cf.perqry(str);
			
		//	Response.Write(str);
			 return true;
			
		}
		else
		{
			 return false;
		}
	
	
	
       


    }
	
	
	
	
    //public void getlogin()
    //{

    //    bool _isBranchValid = true;
    //    try
    //    {
    //        if (txtuname.Text.Trim() != "" && txtpwd.Text.Trim() != null)
    //        {
    //            IList<BranchLogin> objBranchLoginBranch = new List<BranchLogin>();
    //            objBranchLoginBranch = objSalesService.GetLoginUserBranch(txtuname.Text.Trim());
    //            Int32 _loginUserBranch = objBranchLoginBranch[0].loginEmpZBAID;

    //            if (_loginUserBranch != Int32.Parse(ddlBraches.SelectedItem.Value))
    //            {
    //                //_isBranchValid = false;
    //                radMessageWindow.RadAlert("<div style=color:#D8000C;>Invalid Branch Selected.</div>", 300, 150, "Z-Axis Validation", null, "images/error.png");
    //                //  Response.Redirect("121.0.0.132/branchmodule/loginpage.aspx?error=Invalid Branch Selected.");
    //            }

    //            IList<BranchLogin> objBranchLoginDetails = new List<BranchLogin>();
    //            objBranchLoginDetails = objSalesService.Login(txtuname.Text.Trim(), txtpwd.Text.Trim(), ddlBraches.SelectedItem.Text.Trim());

    //            if (objBranchLoginDetails.Count > 0)
    //            {
    //                if (objBranchLoginDetails.Rows[0][]loginUserName == txtuname.Text.Trim() && objBranchLoginDetails.Rows[0][]loginPassword == txtpwd.Text.Trim())
    //                {

    //                    if (objBranchLoginDetails.Rows[0][]Webacc == "Y")
    //                    {
    //                        Session["ZxCurrUsrID"] = objBranchLoginDetails.Rows[0][]loginUserID.ToString();
    //                        Session["ZxCurrEmpno"] = objBranchLoginDetails.Rows[0][]loginEmpNo.ToString();
    //                        Session["ZxCurrzbaid"] = objBranchLoginDetails.Rows[0][]loginEmpZBAID.ToString();
    //                        string IPHost = Dns.GetHostName();
    //                        string IP = Dns.GetHostEntry(IPHost).AddressList[0].ToString();

    //                        Session["ZxCurrMcIP"] = IP;
    //                        Session["ZxCurrUsrGrp"] = objBranchLoginDetails.Rows[0][]loginUserGroupCode.ToString();
    //                        Session["ZxCurrMcNm"] = Dns.GetHostName();
    //                        Session["ZxCurrsysDt"] = DateTime.Now;
    //                        Session["UserDeptCode"] = objBranchLoginDetails.Rows[0][]loginEmpDeptCode.ToString();
    //                        Session["ZxCurrCompID"] = objBranchLoginDetails.Rows[0][]loginUserCompID.ToString();

    //                        Session["UN"] = objBranchLoginDetails.Rows[0][]loginUserName.ToString();
    //                        Session["PW"] = objBranchLoginDetails.Rows[0][]loginPassword.ToString();
    //                        Session["BR"] = objBranchLoginDetails.Rows[0][]loginUserBranch.ToString();
    //                        Session["LastLogin"] = objBranchLoginDetails.Rows[0][]loginUserLastLogin.ToString();
    //                        Session["EmpName"] = objBranchLoginDetails.Rows[0][]loginEmpName.ToString();
    //                        Session["UserLoginTime"] = DateTime.Now;
    //                        Session["webacs"] = objBranchLoginDetails.Rows[0][]Webacc;

    //                        if (Session["ZxCurrUsrGrp"].ToString() == "ADMIN" || Session["ZxCurrEmpno"].ToString() == "159" || Session["ZxCurrEmpno"].ToString() == "4344")
    //                        {
    //                            Response.Redirect("dashboardbranch.aspx");
    //                        }
    //                        else
    //                        {
    //                            Response.Redirect("virtualregisterdashboard.aspx");
    //                        }
    //                    }
    //                    else
    //                    {
    //                        radMessageWindow.RadAlert("<div style=color:#D8000C;>You are not authorised to access new branch module. Kindly continue with old pattern. </div>", 300, 150, "Z-Axis Validation", null, "images/error.png");

    //                    }

    //                }

    //                else
    //                {
    //                    radMessageWindow.RadAlert("<div style=color:#D8000C;>Invalid Login Credentials </div>", 300, 150, "Z-Axis Validation", null, "images/error.png");

    //                }
    //            }
    //            else
    //            {

    //                radMessageWindow.RadAlert("<div style=color:#D8000C;>Invalid Login Credentials </div>", 300, 150, "Z-Axis Validation", null, "images/error.png");

    //            }
    //        }
    //        else
    //        {
    //            radMessageWindow.RadAlert("<div style=color:#D8000C;>Please Enter Login Credentials </div>", 300, 150, "Z-Axis Validation", null, "images/error.png");
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        radMessageWindow.RadAlert("<div style=color: #D8000C;>" + ex.Message + "</div>", 300, 150, "Z-Axis Validation", null, "images/error.png");


    //    }

    //    if (objSalesService.statusMessage != "")
    //    {

    //        radMessageWindow.RadAlert("<div style=color: #D8000C;background-color:#FDD5CE;>" + objSalesService.statusMessage.ToString() + "</div>", 300, 150, "Z-Axis Validation", null, "images/error.png");
    //    }

    //}

    public void Page_Error(object sender, EventArgs e)
    {

    }



    public void InsertSuccessLogin(string message)
    {

      String  str = "update webbranch.branchlogin set userid='" + Convert.ToString(Session["ZxCurrUsrID"]) + "',empno='" + Convert.ToString(Session["ZxCurrEmpno"]) + "',logindt=sysdate,branch='" + Convert.ToString(Session["ZxCurrzbaid"]) + "',username='" + txtuname.Text.Replace("'", "''") + "',password='" + txtpwd.Text.Replace("'", "''") + "',loginstatus='T' where sessionid='" + Convert.ToString(Session["sessionid"]) + "' and transid='" + Convert.ToString(ViewState["authid"]) + "'";
        cf.perqry(str);
       
    }
      
}