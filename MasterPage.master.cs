using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.OracleClient;
using System.Configuration;
using System.Data;
using System.Web.Services;
using Telerik.Web.UI;
public partial class MasterPage : System.Web.UI.MasterPage
{
   
        nsbranch.commonfunctions cf = new nsbranch.commonfunctions();

        #region SELECTED ACCORDIAN PANE PROPERTY

        public Int32 _AccordianSelectedIndex
        {
            get
            {
                return Accordion1.SelectedIndex;
            }
            set
            {
                Accordion1.SelectedIndex = value;
            }
        }

        #endregion

        #region SELECTED ACCORDIAN PANE PROPERTY

        public Boolean  _visible_hide
        {
            get
            {
               
                return left_pane.Visible;
            }
            set
            {
                left_pane.Visible = value;
            }
        }

        #endregion


         
        #region TOP IMAGE PROPERTY

        public string _topHeadingImage
        {
            get
            {
                return imgTopHeading.Src;
            }
            set
            {
                imgTopHeading.Src = value;
            }
        }

        #endregion


        #region TOP QUERY PROPERTY

        public string _topHeaderQuery
        {
            get
            {
                return lnkTopHeaderQuery.HRef;
            }
            set
            {
                lnkTopHeaderQuery.HRef = value;
            }
        }

        #endregion
        //lnkTopHeaderQuery



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
          
            if (Session["ZxCurrzbaid"] == null)
            {
                Response.Redirect("logout.aspx");

            }

            
            #region AUTHENTICATE LOGIN

           // if (Session["UN"] == null || Session["PW"] == null)
          //  {
               // Response.Redirect("login.aspx?authentication=failed");
           // }

            #endregion

            #region CHECK CURRENT LOGIN SESSION TIME

            if (Session["TotalSession"] != null)
            {
               // lblUserSession.Text = Session["TotalSession"].ToString();

            }

            #endregion
			
			if (Page.IsPostBack == false)
            {
			
            
            #region SET LAST LOGIN TIME OF USER
            if (Session["LastLogin"] != null)
            {
                try
                {
                    DateTime lblLastLoginValue = DateTime.Parse(Convert.ToString(Session["LastLogin"]));
                    lblLastLogin.Text = lblLastLoginValue.ToString("dd-MMM-yyyy hh:mm:ss");
                }
                catch (Exception ex)
                {

                }


            }

            #endregion

            #region SET LOGO TOOLTIP INFO

            StringBuilder _logoToolTipInfo = new StringBuilder();
            if (Session["ZxCurrUsrID"] != null)
            {


                _logoToolTipInfo.Append("User ID : " + Convert.ToString(Session["ZxCurrUsrID"]));
                _logoToolTipInfo.Append("\n");
                _logoToolTipInfo.Append("User Group : " + Convert.ToString(Session["ZxCurrUsrGrp"]));
                _logoToolTipInfo.Append("\n");
                _logoToolTipInfo.Append("Emp. No. : " + Convert.ToString(Session["ZxCurrEmpno"]));
                _logoToolTipInfo.Append("\n");
                _logoToolTipInfo.Append("Branch ID : " + Convert.ToString(Session["ZxCurrzbaid"]));
                _logoToolTipInfo.Append("\n");
                _logoToolTipInfo.Append("Data Server : " + Convert.ToString(Session["servername"]));
                _logoToolTipInfo.Append("\n");
                _logoToolTipInfo.Append("File Server : " + Convert.ToString(Session["fileservername2"]));
                _logoToolTipInfo.Append("\n");
            }
            imgZaxisLogo.ToolTip = _logoToolTipInfo.ToString();


            #endregion


            #region SET ACTIVE BRANCH

            lblActiveBranch.Text = GetActiveBranchName(Convert.ToString(Session["ZxCurrzbaid"]));
          //  lbcurrlogin.Text= Session["UserLoginTime"].ToString();

            #endregion
			}

            if (Page.IsPostBack==false)
            {

                #region SET TOP MENU POPUPS

                //  lnkAnchorChangeBranch.Attributes.Add("onclick", "var Mleft = (screen.width/2)-(296/2);var Mtop = (screen.height/2)-(355/2);window.open('popup.aspx?p=cbranch',null,'left=\'+Mleft+\',top=\'+Mtop+\', height=310, width= 300, status=no, resizable= no, scrollbars= yes, toolbar= no,location= yes, menubar= no');");
                lnkAnchorChangeBranch.HRef = "popup.aspx?p=cbranch";
                cissretainer.HRef = "popup.aspx?p=creciept";

                //cissretainer.HRef = "Ciisretainer.aspx";
                //a1.Attributes.Add("onclick", "var Mleft = (screen.width/2)-(1024/2);var Mtop = (screen.height/2)-(550/2);window.open('popup.aspx?p=fagr',null,'left=\'+Mleft+\',top=\'+Mtop+\', height=550, width= 1024, status=no, resizable= no, scrollbars= yes, toolbar= no,location= yes, menubar= no');");
                //  a1.HRef = "popup.aspx?p=cfeeagr";

                //a2.Attributes.Add("onclick", "var Mleft = (screen.width/2)-(1024/2);var Mtop = (screen.height/2)-(550/2);window.open('popup.aspx?p=search2',null,'left=\'+Mleft+\',top=\'+Mtop+\', height=550, width= 1024, status=no, resizable= no, scrollbars= yes, toolbar= no,location= yes, menubar= no');");
                a2.HRef = "popup.aspx?p=search2";

                //   A3.Attributes.Add("onclick", "var Mleft = (screen.width/2)-(1024/2);var Mtop = (screen.height/2)-(550/2);window.open('popup.aspx?p=immclass',null,'left=\'+Mleft+\',top=\'+Mtop+\', height=370, width= 400, status=no, resizable= no, scrollbars= yes, toolbar= no,location= yes, menubar= no');");
                A3.HRef = "popup.aspx?p=immclass";
                A6.HRef = "popup.aspx?p=qafol0";

                #endregion
               
                if (Session["ZxCurrUsrGrp"].ToString() == "ADMIN")
                {
                    lnkAnchorChangeBranch.Visible = true;
                    BindTransactionPagesList();
                   
                   // BindAnalyticsPagesList();
                    dashlnk.Attributes.Add("href", "Dashboardbranch.aspx");
                }
                else
                {
                    lnkAnchorChangeBranch.Visible = false;
                 //   ab_transaction.HRef = "TransactionPageErrornew.aspx";
                 //   a5_Analytics.HRef = "TransactionPageErrornew.aspx";
                    dashlnk.Attributes.Add("href", "UserDashBoard.aspx");
                }
            
                     BindToolsPagesList();
                    BindReportsPagesList();
                
                a5_Utilities.HRef = "virtuallibrary.aspx";
                      BindVirtualRegisterPreSalesPagesList();
             //   BindVirtualRegisterPostSalesPagesList();
              //  BindDicrepanciesPagesList();
               //for notification
              //  getCounter();
                if (Session["ZxCurrzbaid"].ToString() == "119" || Session["ZxCurrzbaid"].ToString() == "11")
                {
                    panelpay.Attributes.Add("style", "display:block");
                  
                }
                else
                {
                    panelpay.Attributes.Add("style", "display:none");
                   

                }


                if (Session["ZxCurrEmpno"].ToString() == "159")
                {
                   
                    paneladmtest.Attributes.Add("style", "display:block");

                }
                else
                {
                    paneladmtest.Attributes.Add("style", "display:none");
                    
                }

              //  string saas = Session["ZxCurrzbaid"].ToString();
               // string asas = Session["ZxCurrEmpno"].ToString();
                //A31.HRef = "http://121.0.0.132/branchModule/PaymentPlan.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"].ToString() + "&ZxCurrEmpno=" + Session["sElectedEmPID"].ToString() + "";

                // A31.HRef = "http://121.0.0.132/branchModule/PaymentPlan.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"].ToString() + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"].ToString() + "";

                A31.HRef = "PaymentPlan.aspx";
                A76.HRef = "FrontOffice.aspx";

                altwind.HRef = "http://" + Session["servername"] + "/branchModule/chklistbranchalert.aspx?bid=" + Session["ZxCurrzbaid"].ToString() + "&eid=" + Session["ZxCurrEmpno"].ToString() + "&sip=" + Session["ZxCurrMcIP"] + "&uip=" + Session["servername"] + "";
            
            }

           

               
                if (Page.IsPostBack == false)
                {
                    getoffemlmethod("F");
					

					    if (Convert.ToString(Session["ZxCurrUsrGrp"]) == "ADMIN")
                    {
                        if (Convert.ToString(Session["DESGLEVEL"]) == "7" || Convert.ToString(Session["DESGLEVEL"]) == "8")
                        {
                            if (getdsrupdate() == true)
                            {
                                Response.Redirect("accsheet1.aspx", false);
                                //Response.Redirect("dashboardbranch.aspx", false);
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
														 if (getrr_unack() == true)
                                                     {
													 
										              	Response.Redirect("rr_unack.aspx", false);
												    }
														
														
													}
												
										          
										 
												  }
									
								}
							
                        }
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
														 if (getrr_unack() == true)
                                                     {
													 
										              	Response.Redirect("rr_unack.aspx", false);
												    }
														
														
													}
												
										          
										 
												  }
												
											}
					
					
					
										
					
					
                }
            }
            catch (Exception ex)
            {

            }
        }

        

        #region BIND TRANSACTION PAGES LIST GRID

        public void BindTransactionPagesList()
        {
            DataTable objTransactionMenuPages = new DataTable();
            objTransactionMenuPages = cf.GetMenuPages(1);
            gvTransactions.DataSource = objTransactionMenuPages;
            gvTransactions.DataBind();

            if (cf.statusMessage != "")
            {

                ShowMessage("error", cf.statusMessage);
            }



        }
        #endregion
        
        #region BIND TOOLS PAGES LIST GRID
        public void BindToolsPagesList()
        {
           DataTable objToolsMenuPages = new DataTable();
            objToolsMenuPages = cf.GetMenuPages(82);
            gvTools.DataSource = objToolsMenuPages;
            gvTools.DataBind();

            if (cf.statusMessage != "")
            {

                ShowMessage("error", cf.statusMessage);
            }



        }


        #endregion
        
        #region BIND ANALYTICS PAGES LIST GRID
        //public void BindAnalyticsPagesList()
        //{
        //   DataTable objAnalyticsMenuPages = new DataTable();
        //    objAnalyticsMenuPages = cf.GetMenuPages(83);
        //    gvAnalytics.DataSource = objAnalyticsMenuPages;
        //    gvAnalytics.DataBind();

        //    if (cf.statusMessage != "")
        //    {

        //        ShowMessage("error", cf.statusMessage);
        //    }



        //}

        #endregion

        #region BIND REPORTS PAGES LIST GRID

        public void BindReportsPagesList()
        {
           DataTable objReportsMenuPages = new DataTable();
            objReportsMenuPages = cf.GetMenuPages(9);
            gvReports.DataSource = objReportsMenuPages;
            gvReports.DataBind();

            if (cf.statusMessage != "")
            {

                ShowMessage("error", cf.statusMessage);
            }



        }
        #endregion

        #region BIND VIRTUAL REGISTER PRE-SALES PAGES  LIST GRID

        public void BindVirtualRegisterPreSalesPagesList()
        {
         //   myvirtual_register.HRef = "VirtualRegisterDashBoard.aspx";
           DataTable objVirtualRegisterMenuPages = new DataTable();
            objVirtualRegisterMenuPages = cf.GetMenuPages(62);
            gvVirtualRegister.DataSource = objVirtualRegisterMenuPages;
            gvVirtualRegister.DataBind();

            if (cf.statusMessage != "")
            {

                ShowMessage("error", cf.statusMessage);
            }



        }
        #endregion


        #region BIND VIRTUAL REGISTER POST-SALES PAGES  LIST GRID

        //public void BindVirtualRegisterPostSalesPagesList()
        //{
        //   DataTable objVirtualRegisterPostSalesMenuPages = new DataTable();
        //    objVirtualRegisterPostSalesMenuPages = cf.GetMenuPages(84);
        //    gvVirtualRegisterPostSales.DataSource = objVirtualRegisterPostSalesMenuPages;
        //    gvVirtualRegisterPostSales.DataBind();

        //    if (cf.statusMessage != "")
        //    {

        //        ShowMessage("error", cf.statusMessage);
        //    }



        //}
        #endregion


        #region BIND DISCREPANCIES PAGES LIST GRID
        //public void BindDicrepanciesPagesList()
        //{
        //   DataTable objDiscrepanciesMenuPages = new DataTable();
        //    objDiscrepanciesMenuPages = cf.GetMenuPages(85);
        //    gvDiscrepancies.DataSource = objDiscrepanciesMenuPages;
        //    gvDiscrepancies.DataBind();

        //    if (cf.statusMessage != "")
        //    {

        //        ShowMessage("error", cf.statusMessage);
        //    }



        //}

        #endregion

        //#region BIND Viru PAGES LIST GRID
        //public void BindDicrepanciesPagesList()
        //{
        //   DataTable objDiscrepanciesMenuPages = new DataTable();
        //    objDiscrepanciesMenuPages = objSalesService.GetMenuPages(85);
        //    gvDiscrepancies.DataSource = objDiscrepanciesMenuPages;
        //    gvDiscrepancies.DataBind();

        //    if (objSalesService.statusMessage != "")
        //    {

        //        ShowMessage("error", objSalesService.statusMessage);
        //    }



        //}

        //#endregion

        #region SALES GRID ROW DATA BOUND
        protected void gvSales_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
        #endregion
        
        #region TRANSACTION GRID ROW DATA BOUND

        protected void gvTransactions_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        #endregion
               
        #region REPORTS GRID ROW DATA BOUND

        protected void gvReports_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        #endregion
     
        #region VIRTUAL REGISTER GRID ROW DATA BOUND

        protected void gvVirtualRegister_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lnkmsg = new LinkButton();
                LinkButton lnk = new LinkButton();
                lnkmsg = (LinkButton)e.Row.FindControl("lnkBtnPageName");
                lnk = (LinkButton)e.Row.FindControl("lnkno");
                LinkButton lnkhide = new LinkButton();
                string lsDataKeyValue = gvVirtualRegister.DataKeys[e.Row.RowIndex].Values[0].ToString();
                if (!string.IsNullOrEmpty(lsDataKeyValue))
                {
                  

                    if (lsDataKeyValue.ToString() == "A")
                    {

                        lnkmsg.Visible = true;
                        lnk.Visible = false;
                    }
                    else
                    {
                        lnkmsg.Visible = false;
                        lnk.Visible = true;
                    }

                }
            }
        }

        #endregion

        #region SHOW MESSAGE

        public void ShowMessage(string _msgType, string _msgContent)
        {


            switch (_msgType)
            {
                case "error":
                    radMessage.Title = "Exception";
                    radMessage.Text = _msgContent;
                    radMessage.VisibleOnPageLoad = true;
                    break;
                case "inner":
                    radMessage.Title = "Inner Exception";
                    radMessage.Text = _msgContent;
                    radMessage.VisibleOnPageLoad = true;
                    break;
                default:
                    break;
            }



        }

        #endregion
        
        #region LOGIN USER TIME REFRESH

        //protected void tmrSession_Tick(object sender, EventArgs e)
        //{
            

        //    DateTime start = DateTime.Parse(Session["UserLoginTime"].ToString());
        //    DateTime now = DateTime.Now;
        //    TimeSpan totalLoginSession = now.Subtract(start);
        //    lblUserSession.Text = totalLoginSession.Hours.ToString() + " Hrs  " + totalLoginSession.Minutes.ToString() + " Mins  " + totalLoginSession.Seconds.ToString()+" Secs";
        //    Session["TotalSession"] = lblUserSession.Text;

        //}

        #endregion


        #region GET ACTIVE BRANCH NAME

        public string GetActiveBranchName(string _activeBranchID)
        {
            string _branchName = string.Empty;
            DataTable dtresult = cf.getdata("select zbaname from phasezero.zba_master where zbaid=" + _activeBranchID + "");
            _branchName = dtresult.Rows[0]["zbaname"].ToString();
            
            return _branchName;

        }

        #endregion


        protected void getCounter()
        {

            string _branchName = string.Empty;
            DataTable mytablealert = cf.getdata("select COUNT(*) from shankar.brnomalert");
            hf_notification.Value = Convert.ToString(Convert.ToInt32(mytablealert.Rows[0][0]) - 1);
           

        }

    //[System.Web.Services.WebMethod(EnableSession = true)]
    //public static string GetCurrentTime(Int32 count)
    //{
    //    //' Return "Hello The Current Time is: " & DateTime.Now.ToString()


    //    DataTable mytable = new DataTable();
    //    string str = null;
    //    OracleCommand cmd = new OracleCommand();
    //    OracleConnection con = new OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings["constr"].ToString());
    //    OracleDataReader dr = default(OracleDataReader);
    //    OracleDataReader dr1 = default(OracleDataReader);
    //    DataSet ds = new DataSet();
    //    str = "select * from shankar.brnomalert";
    //    cmd.CommandText = str;
    //    cmd.Connection = con;
    //    if (con.State == ConnectionState.Closed)
    //    {
    //        con.Open();
    //    }
    //    dr = cmd.ExecuteReader();
    //    DataTable mytablealert = new DataTable();
    //    mytablealert.Load(dr);
    //    mytablealert.TableName = "alert_query";
    //    ds.Tables.Add(mytablealert);
    //    dr.Close();
    //    dr.Dispose();

    //    try
    //    {

    //        str = null;
    //        str = ds.Tables["alert_query"].Rows[count - 1]["numquery"].ToString ();
    //        cmd.CommandText = str;
    //        cmd.Connection = con;
    //        dr1 = cmd.ExecuteReader();

    //        mytable.Load(dr1);
    //        mytable.TableName = "result";
    //        dr1.Close();
    //        dr1.Dispose();
    //        if (Convert.ToInt32 (mytable.Rows[0][0]) > 0)
    //        {

    //            return ds.Tables[0].Rows[count - 1][2] + " " + Convert.ToString(mytable.Rows[0][0]);
    //            //Dim result As New List(Of results)
    //            //result.Add(ds.Tables(0).Rows(count - 1)(2) + " " + Convert.ToString(mytable.Rows(0)(0)))
    //            //result.Add(ds.Tables(0).Rows(0)(4))
    //            //Return result

    //        }
    //        else
    //        {
    //            return "reset";
    //        }
                
              

    //    }
    //    catch (Exception ex)
    //    {
    //        return "reset";
    //    }
           
    //    con.Close();
    //    cmd.Dispose();
            
    //}

        protected void btnverify_Click(object sender, ImageClickEventArgs e)
        {
            vrfoffeml();
        }
        protected void btnupd_Click(object sender, ImageClickEventArgs e)
        {
            vrfoffeml();
        }
        private void vrfoffeml()
        {
            if (txtoffeml.Text.Length > 0)
            {
                if ((txtoffeml.Text.Contains("@wwicsgroup.com") == true) || (txtoffeml.Text.Contains("@pinnacleinfoedge.com") == true) || (txtoffeml.Text.Contains("@gsbc.biz") == true) || (txtoffeml.Text.Contains("@immigrationwwics.com") == true))
                {
                    Int32 i = updoffeml();
                    if (i == 1)
                    {
                        radMessage.Text = "you are sucessfully verified your official email id";
                        radMessage.Show();
                    }
                    else
                    {
                        radMessage.Text = "There is some problem, please try later or call IT Department ";
                        radMessage.Show();
                    }

                }
                else
                {
                    radMessage.Text = "Not valid official Email id, please enter only official email id";
                    radMessage.Show();
                    getoffemlmethod("F");
                    txtoffeml.Text = "";
                }
            }
            else
            {
                radMessage.Text = "please enter official email id";
                radMessage.Show();
                getoffemlmethod("F");
                txtoffeml.Text = "";

            }
        }

        protected void btnnotverify_Click(object sender, ImageClickEventArgs e)
        {
            lbloffeml.Visible = false;
            Paneleml.Visible = true;
            btnnotverify.Visible = false;
            btnverify.Visible = false;
            getoffemlmethod("T");
        }

        private void getoffemlmethod(string vrf)
        {
            
            String offeml = GetOfficialEmail(Session["ZxCurrEmpno"].ToString(),vrf);
            if (offeml != "")
            {
                lblmsg.Text = "Hello '" + Session["EmpName"] + "',  please verify your official Email ID";
                lbloffeml.Text = offeml;
                txtoffeml.Text = offeml;
                ModalPopupExtender1.Show();
            }
        }
        public Int32 updoffeml()
        {
            try
            {

                cf.perqry("update rajeev.tbemp set offemail='" + txtoffeml.Text + "', offemlvrf='T', offemlvrfdat=sysdate where empno='" + Session["ZxCurrEmpno"] + "'");
     
                return 1;
            }
            catch (Exception ex)
            {

                return 0;
            }
        }

        protected void lnkeml_Click(object sender, EventArgs e)
        {
             getoffemlmethod("T");
        }
        #region GET OFFICIAL EMIAL

		
	
		
		
        public string GetOfficialEmail(string _activeEmp, String _vrf)
        {
            string _offeml = string.Empty;
            String str="";
             if (_vrf == "F")
                    {
                        str="select nvl(offemail,'abc') offemail from rajeev.tbemp where empno=" + _activeEmp + " and offemlvrf is null";
                    }
                    else
                    {
                        str="select nvl(offemail,'abc') offemail from rajeev.tbemp where empno=" + _activeEmp + "";
                    }
           
            try
            {

                DataTable dtresult = cf.getdata(str);
                _offeml = dtresult.Rows[0]["offemail"].ToString();

            }

            catch (Exception ex)
            {

            }

            return _offeml;

        }

        #endregion

			 protected bool getdsrupdate()
    {

	        DataTable dt= new DataTable();
           //    dt= cf.getdata("SELECT A.STDT,B.CNT FROM (SELECT TO_CHAR(STDT,'dd-Mon-yy') STDT FROM (SELECT TO_DATE((SELECT MNTHSTDT FROM RAHUL.MNTHFSTDAT),'dd-mon-yyyy') + ROWNUM -1 STDT FROM ALL_OBJECTS WHERE ROWNUM <= TO_DATE(SYSDATE-1,'dd-mon-yyyy')-TO_DATE(((SELECT MNTHSTDT FROM RAHUL.MNTHFSTDAT)),'dd-mon-yyyy')+1)) A,(SELECT TO_CHAR(RETAINDT,'dd-Mon-yy') RTDT,COUNT(*) CNT FROM TT.CREDITED_AMOUNT_ADD WHERE BRANCHID IN ('" + Convert.ToString(Session["ZxCurrzbaid"]) + "') AND MONTH_YEAR= TO_CHAR(SYSDATE,'Mon-yyyy') and CURSTS='A' group by to_char(Retaindt,'dd-Mon-yy') order by 1) b where a.stdt=b.rtdt(+) and b.cnt is null order by 1");
	
	//--- change on  01-Mar-2019 
	
	// dt= cf.getdata("SELECT A.STDT,B.CNT FROM (SELECT TO_DATE('01-Feb-2019', 'dd-Mon-YYYY') - 1 + ROWNUM AS STDT FROM ALL_OBJECTS WHERE TO_DATE('01-Feb-2019', 'dd-Mon-YYYY') - 1 + ROWNUM <= TO_DATE('25-Mar-2019', 'dd-Mon-YYYY')) A,  (SELECT TO_CHAR(RETAINDT,'dd-Mon-yy') RTDT,COUNT(*) CNT FROM TT.CREDITED_AMOUNT_ADD WHERE BRANCHID IN ('" + Convert.ToString(Session["ZxCurrzbaid"]) + "')  AND CURSTS='A' GROUP BY TO_CHAR(RETAINDT,'dd-Mon-yy') ORDER BY 1) B  where a.stdt=b.rtdt(+) and b.cnt is null and a.stdt<sysdate-1 order by 1");
	
	// dt= cf.getdata("SELECT A.STDT,B.CNT FROM (SELECT TO_DATE('26-Apr-2019', 'dd-Mon-YYYY') - 1 + ROWNUM AS STDT FROM ALL_OBJECTS WHERE TO_DATE('26-Apr-2019', 'dd-Mon-YYYY') - 1 + ROWNUM <= TO_DATE('25-Jun-2019', 'dd-Mon-YYYY')) A,  (SELECT TO_CHAR(RETAINDT,'dd-Mon-yy') RTDT,COUNT(*) CNT FROM TT.CREDITED_AMOUNT_ADD WHERE BRANCHID IN ('" + Convert.ToString(Session["ZxCurrzbaid"]) + "')  AND CURSTS='A' GROUP BY TO_CHAR(RETAINDT,'dd-Mon-yy') ORDER BY 1) B  where a.stdt=b.rtdt(+) and b.cnt is null and a.stdt<sysdate-1 order by 1");
	
	dt= cf.getdata("SELECT A.STDT,B.CNT FROM (SELECT TO_DATE('26-Apr-2019', 'dd-Mon-YYYY') - 1 + ROWNUM AS STDT FROM ALL_OBJECTS WHERE TO_DATE('26-Apr-2019', 'dd-Mon-YYYY') - 1 + ROWNUM <= TO_DATE('31-Aug-2019', 'dd-Mon-YYYY')) A,  (SELECT TO_CHAR(RETAINDT,'dd-Mon-yy') RTDT,COUNT(*) CNT FROM TT.CREDITED_AMOUNT_ADD WHERE BRANCHID IN ('" + Convert.ToString(Session["ZxCurrzbaid"]) + "')  AND CURSTS='A' GROUP BY TO_CHAR(RETAINDT,'dd-Mon-yy') ORDER BY 1) B  where a.stdt=b.rtdt(+) and b.cnt is null and a.stdt<sysdate-1 and to_char(a.stdt,'Mon-yyyy') in (select month_year from tt.CREDITED_amount_branch where status is null and cad_id='" + Convert.ToString(Session["ZxCurrzbaid"]) + "') order by 1");
	
	
	if (dt.Rows.Count>0)		
		{
			
				String txt= " ";
			foreach(DataRow dr in dt.Rows)
{
   
   txt += Convert.ToString(dr["STDT"]) + " ,";
   
}
			
			
			txt= txt.Substring(0, txt.Length - 1);
			
			string str = "INSERT INTO tt.DSR_STOP(TID,ZBAID,EMPNO,KEYEDON,REMARKS,TYP) values(TT.dsrstop_SEQ.nextval,'" + Convert.ToString(Session["ZxCurrzbaid"]) + "','" + Convert.ToString(Session["ZxCurrEmpno"]) + "',sysdate,'" + txt + "','B')";
            cf.perqry(str);
			
			
			
			 return true;
			
		}
		else
		{
			 return false;
		}
	
	
	
       


    }
		
		
		
		
        public void GetNotifications(string _activeEmp)
        {
           

            try
            {
                   DataTable dtresult = cf.getdata("select * from RAHUL.ZXAISNOTIFIACTIONS where zxntfempnofor=" + _activeEmp + "");
               
                    DataView view = new DataView(dtresult);
                    view.RowFilter = "ZREADSTAT='P'";
                    DataTable dtresuklt2 = view.ToTable();
                    notification_count.InnerText = dtresuklt2.Rows.Count.ToString();
                   
                    ddllist.DataSource = dtresult;
                    ddllist.DataBind();
                

            }

            catch (Exception ex)
            {

            }



        }


        public string TimeAgo1(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;
                return String.Format("about {0} {1} ago",
                years, years == 1 ? "year" : "years");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return String.Format("about {0} {1} ago",
                months, months == 1 ? "month" : "months");
            }
            if (span.Days > 0)
                return String.Format("about {0} {1} ago",
                span.Days, span.Days == 1 ? "day" : "days");
            if (span.Hours > 0)
                return String.Format("about {0} {1} ago",
                span.Hours, span.Hours == 1 ? "hour" : "hours");
            if (span.Minutes > 0)
                return String.Format("about {0} {1} ago",
                span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            if (span.Seconds > 5)
                return String.Format("about {0} seconds ago", span.Seconds);
            if (span.Seconds <= 5)
                return "just now";
            return string.Empty;
        }

        protected void ddllist_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                System.Web.UI.HtmlControls.HtmlAnchor lnkform = (System.Web.UI.HtmlControls.HtmlAnchor)e.Item.FindControl("notherf");

                DataRowView drv = e.Item.DataItem as DataRowView;
                if (drv != null)
                {
                    string sts = drv.Row[5].ToString();
                    if (sts == "P")
                    {
                        e.Item.CssClass = "altrow";
                        lnkform.Attributes.Add("href", "popup.aspx?p=notification&q=R&id=" + drv.Row[0].ToString());
                    }
                    else
                    {
                        e.Item.CssClass = "itmrow";
                        lnkform.Attributes.Add("href", "popup.aspx?p=notification&q=A&id=" + drv.Row[0].ToString());
                    }
                    
                }


            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GetNotifications(Session["ZxCurrEmpno"].ToString());
        }
        //public void Page_Error(object sender, EventArgs e)
        //{
        //    Exception objErr = Server.GetLastError().GetBaseException();
        //    string err = "<b>Error Caught in Page_Error event</b><hr><br>" +
        //    "<br><b>Error in: </b>" + Request.Url.ToString() +
        //    "<br><b>Error Message: </b>" + objErr.Message.ToString() +
        //    "<br><b>Stack Trace:</b><br>" +
        //    objErr.StackTrace.ToString();
        //    // Response.Write(err.ToString());
        //    Server.ClearError();
        //    radMessageWindow.RadAlert("<div style=color: #D8000C;background-color:#FDD5CE;>" + err + "</div>", 300, 150, "Z-Axis Validation", null, "images/error.png");
        //} 
     
        
		 protected bool getrrinfo()
    {

	 DataTable dt= new DataTable();
            dt= cf.getdata("select * from TT.BRANCH_PROFILE where empno='" + Convert.ToString(Session["ZxCurrEmpno"]) + "'") ;
	
	
	if (dt.Rows.Count>0)		
		{
			
		    string str = "update TT.BRANCH_PROFILE set  zbaid='" + Convert.ToString(Session["ZxCurrzbaid"]) + "', APPLOGINDT=to_date('" + Convert.ToDateTime(Convert.ToString(Session["LOCALDATE"])).ToString("dd-MMM-yyyy HH:mm:ss") + "','dd-Mon-yyyy hh24:mi:ss') where zbaid='" + Convert.ToString(Session["ZxCurrzbaid"]) + "' and empno='" + Convert.ToString(Session["ZxCurrEmpno"]) + "'" ;
            cf.perqry(str);
			
		//	Response.Write(str);
			 return true;
			
		}
		else
		{
			 return false;
		}
	
	
	
       


    }
	
	protected bool getrr_unack()
    {

	 DataTable dt1= new DataTable();
	 String reqsql= "select count(*) cnt from TT.BRANCH_PROFILE where leadstat='S'  and empno='" + Convert.ToString(Session["ZxCurrEmpno"]) + "'";
            dt1= cf.getdata(reqsql) ;
	
	 Int32 cntset = Convert.ToInt32(Convert.ToString(dt1.Rows[0][0]));
//Response.Write(reqsql);
//Response.Write(cntset);
            if (cntset > 0)		
		{
			
		 return true;
			
		}
		else
		{
		return false;
		}
	


    }
	

    
}
