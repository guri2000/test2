using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
public partial class PopUp : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["p"] != null)
            {
                switch (Request.QueryString["p"].ToString())
                {

                    case "drr":

                        Response.Redirect("newdrr.aspx");
                        break;
                    case "sass":
                        Response.Redirect("newsassessment.aspx");
                        break;
                    case "rec":
                        Response.Redirect("newreceipt.aspx");
                        break;
                    case "auditdocs":
                        String Str32323 = Convert.ToString(Session["servername1"]);
                        string[] str422233 = Str32323.Split(':');
                        Response.Redirect("http://" + str422233[0] + ":8989/audt_docs.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&uip=" + str422233[0] + "&fileno=" + Request.QueryString["file"] + "&fsn=" + Request.QueryString["fsn"]);
                        //Response.Redirect("newqafollowup.aspx");
                        break;

                    //Response.Redirect("newqafollowup.aspx");

                    case "qafol":
                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=" + Session["qafno"] + "&type=A");
                        break;
						
					 case "qafol0":
                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "");
                        break;	
				
 case "smslinkenq":
                        Response.Redirect("smsinterface_new.aspx?enqid=" + Request.QueryString["enqid"].ToString() + "&zbaid=" + Int32.Parse(Session["ZxCurrzbaid"].ToString()) + "&empno=" + Session["ZxCurrEmpno"].ToString());
                        break;


 case "maillinkenq":
                         String Str30000 = Convert.ToString(Session["servername1"]);
                         string[] str40000 = Str30000.Split(':');
                         Response.Redirect("http://" +  Convert.ToString(str40000[0]) + ":8989/send_email_enq.aspx?enqid=" + Request.QueryString["enqid"].ToString() + "&zbaid=" + Int32.Parse(Session["ZxCurrzbaid"].ToString()) + "&emp=" + Session["ZxCurrEmpno"].ToString());
                        break;
		
                    case "qafol1":
                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=" + Request.QueryString["qafno"] + "&type=A");

                        //Response.Redirect("newqafollowup.aspx");
                        break;
                    case "medianews":
                        Response.Redirect("http://" + Session["servername"] + "/media/news.aspx?dash=" + Request.QueryString["dash"].ToString());

                        //Response.Redirect("newqafollowup.aspx");
                        break;
                    case "qafolc":
                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=0&FSN=" + Session["fsninter"] + "&TYPE=C");

                        //Response.Redirect("newqafollowup.aspx");
                        break;

                    case "chgpwd":
                        Response.Redirect("http://" + Session["servername"] + "/change-password.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "");
                        //Response.Redirect("newqafollowup.aspx");
                        break;


                    case "voucherdetail":
                        Response.Redirect("http://" + Session["servername"] + "/voucherdetails.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&vouchno=" + Request.QueryString["vouchno"].ToString() + "");

                        //Response.Redirect("newqafollowup.aspx");
                        break;

                    case "assformslink":
                        String Str323 = Convert.ToString(Session["servername1"]);
                        string[] str423 = Str323.Split(':');
                        Response.Redirect("http://" + str423[0] + ":8989/AssessmentForm.aspx?empid=" + Session["ZxCurrEmpno"] + "&zbaid=" + Session["ZxCurrzbaid"] + "&uip=" + str423[0]);
                        //Response.Redirect("newqafollowup.aspx");
                        break;

					   case "shrturl":
                        String Str3230245 = Convert.ToString(Session["servername1"]);
                        string[] str4235797 = Str3230245.Split(':');
                        Response.Redirect("http://" + str4235797[0] + ":2792/frmGetShortUrl.aspx?enqid=-1&sndtyp=F&mstemp=" + Session["ZxCurrEmpno"] + "&empid=" + Session["ZxCurrEmpno"] + "&bid=" + Session["ZxCurrzbaid"] + "&uip=" + str4235797[0]);
                        //Response.Redirect("newqafollowup.aspx");
                        break;	
						
                    case "consformslink":
                        String Str3231 = Convert.ToString(Session["servername1"]);
                        string[] str4231 = Str3231.Split(':');
                        Response.Redirect("http://" + str4231[0] + ":8989/counslingform.aspx?empid=" + Session["ZxCurrEmpno"] + "&zbaid=" + Session["ZxCurrzbaid"] + "&uip=" + str4231[0]);
                        //Response.Redirect("newqafollowup.aspx");
                        break;
                    case "ircase":
                        String Str3232 = Convert.ToString(Session["servername1"]);
                        string[] str4232 = Str3232.Split(':');
                        Response.Redirect("http://" + str4232[0] + ":8989/irinfo.aspx?empid=" + Session["ZxCurrEmpno"] + "&zbaid=" + Session["ZxCurrzbaid"] + "&fno=" + Request.QueryString["fno"].ToString() + "&tid=" + Request.QueryString["tid"].ToString() + "&imm=" + Request.QueryString["imm"].ToString() + "&cntry=" + Request.QueryString["cntry"].ToString() + "&uip=" + str4232[0]);
                        //Response.Redirect("newqafollowup.aspx");
                        break;

                    case "retentiondocs":
                        Response.Redirect("http://" + Session["servername"] + "/retentiondocs.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&fileno=" + Request.QueryString["fno"].ToString() + "");
                        break;


                    case "uploaddocsbyid":
                        String Str32321 = Convert.ToString(Session["servername1"]);
                        string[] str42321 = Str32321.Split(':');
                        Response.Redirect("http://" + str42321[0] + ":778/uploadotherdocsbyid.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&fileno=" + Request.QueryString["fno"].ToString() + "&GRPCOD=" + Request.QueryString["code"].ToString());
                        break;

                    case "creciept":
                        Response.Redirect("otherrecipts.aspx");

                        break;


                    case "followcl":


                        string str22 = "";
                        str22 = "wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=0&FSN=" + Request.QueryString["fsn"].ToString() + "&TYPE=C";

                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=0&FSN=" + Request.QueryString["fsn"].ToString() + "&TYPE=C");

                        //Response.Redirect("newqafollowup.aspx");
                        break;



                    case "myq":
                        Response.Redirect("newqa.aspx");
                        break;

                    case "newact":
                        if (Session["leadActionType"].ToString() != "Grid")
                        {

                            string enqid = Request.QueryString["enqid"].ToString();
                            Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                            if (Session["leadsEnqID"] == null)
                            {

                                Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                                Response.Redirect("newactionchoice.aspx");
                            }
                            else
                            {
                                Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                                Response.Redirect("newactionchoice.aspx");

                            }
                        }
                        else
                        {

                            Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                            Response.Redirect("newactionchoice.aspx");
                        }
                        break;

                    case "newact1":
                        Session["ZxCurrEmpno"] = Request.QueryString["empid"].ToString();
                        Session["ZxCurrzbaid"] = Request.QueryString["zbaid"].ToString();
                        Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                        Response.Redirect("newactionchoice.aspx");

                        break;
                    case "lawrcpt":
                        Session["servername1"] = Request.QueryString["uip"].ToString().Replace(":776", ":778");
                        Session["ZxCurrEmpno"] = Request.QueryString["empid"].ToString();
                        Session["ZxCurrzbaid"] = Request.QueryString["zbaid"].ToString();
                        Session["CURRDATE"] = DateTime.Now;
                        if (Request.QueryString["rtype"] == "L")
                        {
                            Response.Redirect("laywer_receipt.aspx");
                        }
                        else if (Request.QueryString["rtype"] == "C")
                        {
                            Response.Redirect("Ciisretainer.aspx");
                        }


                        break;


                    case "sndurl":
                        String Str3 = Convert.ToString(Session["servername1"]);
                        string[] str4 = Str3.Split(':');
                        Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                        Session["selectedENQID"] = Request.QueryString["enqid"].ToString();

                        Response.Redirect("http://" + str4[0] + ":8989/emaileditor.aspx?enqid=" + Session["leadsEnqID"] + "&zbaid=" + Session["ZxCurrzbaid"] + "&empid=" + Session["ZxCurrEmpno"]);
                        break;

                    case "onlteam":
                        String Strt3 = Convert.ToString(Session["servername1"]);
                        string[] strt4 = Strt3.Split(':');

                        Response.Redirect("http://" + strt4[0] + ":8989/onlreporting_team.aspx?zbaid=" + Session["ZxCurrzbaid"] + "&empno=" + Session["ZxCurrEmpno"]);
                        break;

                   case "onlHelp":
                        String Strh3 = Convert.ToString(Session["servername1"]);
                        string[] strh4 = Strh3.Split(':');

                        Response.Redirect("http://" + strh4[0] + ":8989/support_master.aspx?bid=" + Session["ZxCurrzbaid"] + "&empno=" + Session["ZxCurrEmpno"]);
                        break;


                    case "notification":
                        String Str31 = Convert.ToString(Session["servername1"]);
                        string[] str41 = Str31.Split(':');
                        Session["notsts"] = Request.QueryString["q"].ToString();
                        Session["notid"] = Request.QueryString["id"].ToString();
                        if (Request.QueryString["q"].Contains("all"))
                        {
                            Response.Redirect("http://" + str41[0] + ":8989/zaxisnotificationall.aspx?sts=" + Session["notsts"] + "&wempno=" + Session["ZxCurrEmpno"] + "&zbaid=" + Session["ZxCurrzbaid"]);

                        }
                        else
                        {
                            Response.Redirect("http://" + str41[0] + ":8989/zaxisnotification.aspx?sts=" + Session["notsts"] + "&notid=" + Session["notid"] + "&wempno=" + Session["ZxCurrEmpno"] + "&zbaid=" + Session["ZxCurrzbaid"]);

                        }
                        break;


                    case "leadactionEnqFollowChoice":
                        Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                        Session["selectedENQID"] = Request.QueryString["enqid"].ToString();
                        Response.Redirect("newleadaction.aspx?enqid=" + Session["leadsEnqID"].ToString());
                        break;

					   case "leadactionEnqFollowChoice1":
					    Session["ZxCurrEmpno"] = Request.QueryString["empid"].ToString();
                        Session["ZxCurrzbaid"] = Request.QueryString["zbaid"].ToString();
						 Session["EmpName"] =    Request.QueryString["enm"].ToString();
                        Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                        Session["selectedENQID"] = Request.QueryString["enqid"].ToString();
                        Response.Redirect("newleadaction.aspx?enqid=" + Session["leadsEnqID"].ToString());
                        break;	
						
						
                    case "leadactionConvToAppChoice":
                        // Response.Redirect("http://121.0.0.222/assessmentresult.aspx");
                        Response.Redirect("http://" + Session["servername"] + "/assessmentresult.aspx?wfn=" + Session["fileno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wempno=" + Session["ZxCurrEmpno"]);

                        break;

                    case "foeres":
                        Response.Redirect("newfoereport.aspx");
                        break;
                    case "foe":
                        Response.Redirect("http://" + Session["servername"] + "/FOENEW.aspx?wzbaid=" + Session["ZxCurrzbaid"] + "&wempno=" + Session["ZxCurrEmpno"] + "&ip=" + Session["servername"]);
                        break;
                    case "foeapp":
                        Response.Redirect("http://" + Session["servername"] + "/FOENEW.aspx?wzbaid=" + Session["ZxCurrzbaid"] + "&wempno=" + Session["ZxCurrEmpno"] + "&ip=" + Session["servername"] + "&tid=" + Request.QueryString["id"] + "&sid=" + Request.QueryString["sid"]);
                        break;
                    case "fapp":
                        Response.Redirect("newfappointment.aspx");
                        break;
                    case "fagr":

                        Response.Redirect("http://" + Session["servername1"] + "/fee_agreement_update2.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"]);
                        break;
                    case "invoice":
                        String Str = Convert.ToString(Session["servername1"]);
                        string[] str1 = Str.Split(':');

                        Response.Redirect("http://" + str1[0] + ":8989/invoice.aspx?zbaid=" + Session["ZxCurrzbaid"] + "&empid=" + Session["ZxCurrEmpno"]);
                        break;

					 case "drr_ques":
                        String Strdrr_ques = Convert.ToString(Session["servername1"]);
                        string[] str1drr_ques = Strdrr_ques.Split(':');

                        Response.Redirect("http://" + str1drr_ques[0] + ":8989/Questionaire.aspx?zbaid=" + Session["ZxCurrzbaid"] + "&empid=" + Session["ZxCurrEmpno"] + "&fileno="+ Request.QueryString["fno"] +"&grp=" + Request.QueryString["grp"] + "&qcls="+ Request.QueryString["qcls"] );
                        break;	
						
					 case "agrdual":

                        Response.Redirect("dualagroption.aspx?zbaid=" + Session["ZxCurrzbaid"] + "&empno=" + Session["ZxCurrEmpno"]);
                        break;	
						
                    case "frsh":

                        Response.Redirect("http://" + Session["servername1"] + "/fee_agreement_update2.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"]);
                        break;
				    case "busass":

					String uiprahul123 =  Convert.ToString(Session["servername1"]).Replace(":778","");
					
                       Response.Redirect("http://" + Session["servername1"] + "/bassosiate/AssociateMaster.aspx?bid=" + Session["ZxCurrzbaid"] + "&empNO=" + Session["ZxCurrEmpno"] + "&acs=A&typ=B&uip=" + uiprahul123) ;

                        break;
					case "frsh5":

					    String uiprahul=  Convert.ToString(Session["servername1"]).Replace(":778",":1010").Replace(".79:1010",".5:1010");
					
					       if (Request.QueryString["imm"] != null)
                        {
							 Response.Redirect("http://" + uiprahul + "/fee_agreement_update4.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"] +"&imm=" + Convert.ToString(Request.QueryString["imm"]) + "&uip=" + uiprahul);
						}
						else
						{
							 Response.Redirect("http://" + uiprahul + "/fee_agreement_update4.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"] +"&uip=" + uiprahul);
						}
					
                       
                        break;	
						
                    case "exst":

                        Response.Redirect("http://" + Session["servername1"] + "/fresh_fee_agreement_update2.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"]);
                        break;
                    case "fact":

                        Response.Redirect("http://" + Session["servername"] + "/FieldActivityNew.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "");
                        break;

                    case "dv":
                        Response.Redirect("newdviewer.aspx");
                        break;
                    case "dfr":

                        //Response.Redirect("http://121.0.0.222/branchModule/dfr_Updates.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"]);
                        Response.Redirect("http://" + Session["servername1"] + "/branchModule/dfr_Updates.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"]);
                        break;

                    case "dfrtef":
                      //  Response.Redirect("http://" + Session["servername1"] + "/branchModule/dfr_Updates.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"] + "&fileno=" + Request.QueryString["fno"].ToString() + "&pmod=TEP");
                        Response.Redirect("dfr_Updates.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"] + "&fileno=" + Request.QueryString["fno"].ToString() + "&pmod=TEP");
                        break;



                    case "crs":

                        //Response.Redirect("http://121.0.0.222/branchModule/dfr_Updates.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"]);

                        string sss = "http://" + Session["servername"] + "/crs.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"];
                        Response.Redirect("http://" + Session["servername"] + "/crs.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"] + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"]);
                        break;


                    case "ass":
                        Response.Redirect("newassessment.aspx");
                        break;

                    case "appool":

                        if (Session["appoolwfno"] != null)
                        {

                            if (Request.QueryString["wfn"] != null)
                            {
                                Response.Redirect("http://" + Session["servername"] + "/assessmentresult.aspx?wfn=" + Request.QueryString["wfn"].ToString() + "&wzbaid=" + Session["ZxCurrzbaid"], false);
                            }
                            else
                            {
                                Response.Redirect("http://" + Session["servername"] + "/assessmentresult.aspx?wzbaid=" + Session["ZxCurrzbaid"] + "", false);
                            }

                        }
                        else
                        {
                            if (Request.QueryString["wfn"] != null)
                            {
                                Response.Redirect("http://" + Session["servername"] + "/assessmentresult.aspx?wfn=" + Request.QueryString["wfn"].ToString() + "&wzbaid=" + Session["ZxCurrzbaid"], false);

                            }
                            else
                            {

                                Response.Redirect("http://" + Session["servername"] + "/assessmentresult.aspx?wzbaid=" + Session["ZxCurrzbaid"] + "", false);
                            }
                            //Response.Redirect("http://121.0.0.222/assessmentresult.aspx", false);

                        }
                        break;

                    case "clientinteraction":
                        {

                            Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx");

                        }
                        break;
                    case "alloc":
                        Response.Redirect("newallocation.aspx");
                        break;

                    case "search":
                        Response.Redirect("http://" + Session["servername"] + "/searchassistance.aspx?visitorid=2&parent=1&wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "");
                        break;
                    case "crttech":
                        Response.Redirect("http://" + Convert.ToString(Session["servername1"]).Replace(":778",":890") + "/createtechprf.aspx?&fileno=" + Request.QueryString["fno"].ToString() + "&wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&uip=" + Session["servername"] + "&typ=B");
                        break;
                    case "chktech":
                        Response.Redirect("chktech.aspx?&fno=" + Request.QueryString["fno"].ToString() + "&wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&uip=" + Session["servername"] + "&typ=B");
                        break;
                    case "search2":
                        Response.Redirect("http://" + Session["servername"] + "/searchassistance.aspx?visitorid=3&parent=1&wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "");
                        break;

                    case "enq":
                        Response.Redirect("http://" + Session["servername"] + "/enqcard.aspx?enqid=" + Int32.Parse(Request.QueryString["enqid"].ToString()) + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wempno=" + Session["ZxCurrEmpno"] + "");
                        break;

					 case "enqadtn":
                        Response.Redirect("http://" + Session["servername"] + "/adtnqstncmp.aspx?enqid=" + Int32.Parse(Request.QueryString["enqid"].ToString()) + "&branchid=" + Session["ZxCurrzbaid"] + "");
                        break;	
						
						
						
                    case "leadscsp":
                        Response.Redirect("customsearchpopup.aspx");
                        break;


                    case "aclientcsp":
                        Response.Redirect("aclientscustomsearchpopup.aspx");
                        break;


                    case "myqacsp":
                        Response.Redirect("myqacustomsearchpopup.aspx");
                        break;

                    case "apoolcsp":
                        Response.Redirect("applicantpoolcustomsearchpopup.aspx");
                        break;

                    case "clientssearch":
                        Response.Redirect("activeclientssearchpopup.aspx");
                        break;
                    //passcsp
                    case "passcsp":
                        Response.Redirect("passessmentsearchpopup.aspx");
                        break;

                    case "leadaction":
                        Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                        Response.Redirect("newleadaction.aspx");
                        break;

					  case "leadaction1":
					    Session["ZxCurrEmpno"] = Request.QueryString["empid"].ToString();
                        Session["ZxCurrzbaid"] = Request.QueryString["zbaid"].ToString();
						 Session["EmpName"] =    Request.QueryString["enm"].ToString();
                        Session["leadsEnqID"] = Request.QueryString["enqid"].ToString();
                        Response.Redirect("newleadaction.aspx");
                        break;	
						
						
						
                    case "qafollowup":
                        Session["qafno"] = Request.QueryString["fno"].ToString();
                        Session["OpenedAs"] = Request.QueryString["openedas"].ToString();
                        Session["OpenedFor"] = Request.QueryString["openedfor"].ToString();
                        Session["OpenedFrom"] = Request.QueryString["openedfrom"].ToString();
                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=" + Session["qafno"] + "&type=A");

                        //  Response.Redirect("newqafollowup.aspx");
                        break;
						
					 case "qafollowup1":
					    Session["ZxCurrEmpno"] = Request.QueryString["empid"].ToString();
                        Session["ZxCurrzbaid"] = Request.QueryString["zbaid"].ToString();
                        Session["qafno"] = Request.QueryString["fno"].ToString();
                        Session["OpenedAs"] = Request.QueryString["openedas"].ToString();
                        Session["OpenedFor"] = Request.QueryString["openedfor"].ToString();
                        Session["OpenedFrom"] = Request.QueryString["openedfrom"].ToString();
                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=" + Session["qafno"] + "&type=A");

                        //  Response.Redirect("newqafollowup.aspx");
                        break;


                    case "addnewqafollowup":
                        Session["qafno"] = "";
                        Session["OpenedAs"] = Request.QueryString["openedas"].ToString();
                        Session["OpenedFor"] = Request.QueryString["openedfor"].ToString();
                        Response.Redirect("http://" + Session["servername"] + "/ClientInteraction1.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&wfileno=" + Session["qafno"] + "&type=A");

                        // Response.Redirect("newqafollowup.aspx");
                        break;
					
                   case "qaapplicant12":
				         Session["ZxCurrEmpno"] = Request.QueryString["empid"].ToString();
                        Session["ZxCurrzbaid"] = Request.QueryString["zbaid"].ToString();
                        Session["qaappfno"] = Request.QueryString["fno"].ToString();
                        //Response.Redirect("MyQAApplicantInfo.aspx");
                        Response.Redirect("Myclientinfo.aspx?cype=A");
                        break;					
						
                    case "qaapplicant":
                        Session["qaappfno"] = Request.QueryString["fno"].ToString();
                        //Response.Redirect("MyQAApplicantInfo.aspx");
                        Response.Redirect("Myclientinfo.aspx?cype=A");
                        break;

                    case "enqqa":
                        Session["qaappfno"] = Request.QueryString["enqid"].ToString();
                        //Response.Redirect("MyQAApplicantInfo.aspx");
                        Response.Redirect("Myclientinfo.aspx?cype=E");
                        break;

                    case "activeclient":
                        Session["qaappfno"] = Request.QueryString["fno"].ToString();
                        Response.Redirect("Myclientinfo.aspx?cype=C");
                        break;
                    case "dfrapplicant":
                        Session["qaappfno"] = Request.QueryString["fno"].ToString();
                        Response.Redirect("MydfrApplicant.aspx");
                        break;


                    case "addnewcity":

                        Response.Redirect("addnewcity.aspx");

                        break;

                    case "addnewcountry":

                        Response.Redirect("addnewcountry.aspx");

                        break;

                    case "cbranch":

                        Response.Redirect("changebranchpop2.aspx");

                        break;
                    case "cfeeagr":

                        Response.Redirect("Changefeagrpop2.aspx");

                        break;
                    case "drr_new":
                        if (Request.QueryString["fno"] != null)
                        {
                            Response.Redirect("http://" + Session["servername1"] + "/drrwebpage.aspx?CurrEmpNo=" + Session["ZxCurrEmpno"] + "&CurrZbaid=" + Session["ZxCurrzbaid"] + "&fileno=" + Request.QueryString["fno"].ToString());
                        }
                        else
                        {
                            Response.Redirect("http://" + Session["servername1"] + "/drrwebpage.aspx?CurrEmpNo=" + Session["ZxCurrEmpno"] + "&CurrZbaid=" + Session["ZxCurrzbaid"] + "");

                        }
                        break;
                    case "drr_new1":
                        if (Request.QueryString["fno"] != null)
                        {
                            Response.Redirect("http://" + Session["servername1"] + "/drrwebpage.aspx?CurrEmpNo=" + Session["ZxCurrEmpno"] + "&CurrZbaid=" + Session["ZxCurrzbaid"] + "&fileno=" + Request.QueryString["fno"].ToString() + "&mode=1");
                        }
                        else
                        {
                            Response.Redirect("http://" + Session["servername1"] + "/drrwebpage.aspx?CurrEmpNo=" + Session["ZxCurrEmpno"] + "&CurrZbaid=" + Session["ZxCurrzbaid"] + "&mode=1");

                        }
                        break;
                    case "revokedrr":
                        if (Request.QueryString["fno"] != null)
                        {
                            Response.Redirect("revokedrr.aspx?CurrEmpNo=" + Session["ZxCurrEmpno"] + "&CurrZbaid=" + Session["ZxCurrzbaid"] + "&fileno=" + Request.QueryString["fno"].ToString() + "&mode=1");
                        }
                        break;

                    case "mdregister":
                        Response.Redirect("http://" + Session["servername"] + "/mail_records.aspx?wzbaid=" + Session["ZxCurrzbaid"] + "&wempno=" + Session["ZxCurrEmpno"]);

                        break;


                    case "assresult":
                        Response.Redirect("http://" + Session["servername"] + "/assessresultstatus.aspx?wfn=" + Request.QueryString["appfno"].ToString() + "&wempno=" + Session["ZxCurrEmpno"]);

                        break;

                    case "viewplan":
                        Response.Redirect("http://" + Session["servername"] + "/viewplandetail.aspx?payplan=" + Request.QueryString["payplan"].ToString() + "&wempno=" + Session["ZxCurrEmpno"]);

                        break;
                    case "query":
                        Response.Redirect("databasequery.aspx?queryof=" + Request.QueryString["queryof"].ToString() + "");

                        break;

                    case "pendingAss":

                        Response.Redirect("http://" + Session["servername"] + "/ScanForm.aspx?wfn=" + Request.QueryString["passfno"].ToString() + "&wzbaid=" + Request.QueryString["passbraid"].ToString() + "&wempno=" + Request.QueryString["passEmpId"].ToString() + "&servername=" + Session["servername"] + "");

                        break;


                    case "leaveworkflow":

                        Response.Redirect("leaveapplication.aspx");

                        break;


                    case "levessearch":

                        Response.Redirect("lworkflowsearchpopup.aspx");

                        break;

                    case "gatepass":

                        Response.Redirect("http://" + Session["servername"] + "/FrmGatePass.aspx?wempno=" + Session["ZxCurrEmpno"].ToString() + "&wzbaid=" + Int32.Parse(Session["ZxCurrzbaid"].ToString()) + "&lempn=" + Session["ZxCurrEmpno"].ToString());

                        break;

                    case "leaveform":

                        if (Session["userchkleaves"] == null)
                        {
                            Session["userchkleaves"] = Session["ZxCurrEmpno"].ToString();
                        }
                        Response.Redirect("http://" + Session["servername"] + "/Default3.aspx?wempno=" + Session["ZxCurrEmpno"].ToString() + "&wzbaid=" + Int32.Parse(Session["ZxCurrzbaid"].ToString()) + "&lempn=" + Session["userchkleaves"].ToString());

                        break;

                    case "general":
                        Response.Redirect("http://" + Session["servername"] + "/ScanForm.aspx?wfn=" + Request.QueryString["fno"].ToString() + "&wzbaid=" + Int32.Parse(Session["ZxCurrzbaid"].ToString()) + "&wempno=" + Session["ZxCurrEmpno"].ToString() + "&servername=" + Session["servername"] + "");

                        break;

                    case "qaallocation":
                        Response.Redirect("http://" + Session["servername"] + "/Enq_QA_App_Allocation.aspx?wzbaid=" + Int32.Parse(Session["ZxCurrzbaid"].ToString()) + "&wempno=" + Session["ZxCurrEmpno"].ToString());

                        break;


                    case "leaveauth":
                        Response.Redirect("http://" + Session["servername1"] + "/leave_auth_updtaed.aspx?wzbaid=" + Int32.Parse(Session["ZxCurrzbaid"].ToString()) + "&wempno=" + Session["ZxCurrEmpno"].ToString());

                        break;



                    case "appointsearch":
                        Response.Redirect("AppointmentSearchPopup.aspx");

                        break;


                    case "fixappoint":
                        Response.Redirect("fixnewappointment.aspx");

                        break;

                    case "smslink":

                        Response.Redirect("smsinterface.aspx?fileno=" + Request.QueryString["fno"].ToString() + "");

                        break;
                    case "smslink1":

                        Response.Redirect("smsinterface.aspx?fsn=" + Request.QueryString["fno"].ToString() + "");

                        break;
                    case "drr_new_pendingdoc":
                        if (Request.QueryString["fno"] != null)
                        {
                            Response.Redirect("http://" + Session["servername1"] + "/UploadDocumentDrrPending.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&fileno=" + Request.QueryString["fno"].ToString());
                        }

                        break;
                    case "drr_new_incorrect":
                        if (Request.QueryString["fno"] != null)
                        {
                            Response.Redirect("http://" + Session["servername1"] + "/documentviewer.aspx?wempno=" + Session["ZxCurrEmpno"] + "&wzbaid=" + Session["ZxCurrzbaid"] + "&fileno=" + Request.QueryString["fno"].ToString());
                        }

                        break;

                    case "appoolgenform":
                        if (Request.QueryString["wfn"] != null)
                        {
                            Response.Redirect("http://" + Session["servername"] + "/ScanForm.aspx?wfn=" + Request.QueryString["wfn"].ToString() + "&wzbaid=" + Session["ZxCurrzbaid"].ToString() + "&wempno=" + Session["sElectedEmPID"].ToString() + "&servername=" + Session["servername"] + "");
                        }

                        break;

                    case "appoolstuform":
                        if (Request.QueryString["wfn"] != null)
                        {

                            string getst = Session["ZxCurrzbaid"].ToString();

                            string getst2 = Session["sElectedEmPID"].ToString();
                            getst = "http://" + Session["servername"] + "/studentform.aspx?wfn=" + Request.QueryString["wfn"].ToString() + "&wzbaid=" + Session["ZxCurrzbaid"].ToString() + "&wempno=" + Session["sElectedEmPID"].ToString() + "";
                            Response.Redirect("http://" + Session["servername"] + "/studentform.aspx?wfn=" + Request.QueryString["wfn"].ToString() + "&wzbaid=" + Session["ZxCurrzbaid"].ToString() + "&wempno=" + Session["sElectedEmPID"].ToString() + "");
                        }

                        break;

                    case "immclass":
                        //if (Request.QueryString["wfn"] != null)
                        //{
                        Response.Redirect("ActiveImmclassPopUp.aspx");
                        //}

                        break;









                    case "travelexpenses":
                        //if (Request.QueryString["wfn"] != null)
                        //{
                        Response.Redirect("travelexpenses.aspx");
                        //}

                        break;


                    case "tadaexpenses":
                        //if (Request.QueryString["wfn"] != null)
                        //{
                        Response.Redirect("http://" + Session["servername"] + "/tadapage.aspx?ZxCurrzbaid=" + Session["ZxCurrzbaid"].ToString() + "&ZxCurrEmpno=" + Session["ZxCurrEmpno"].ToString() + "");
                        //}

                        break;

                    case "levesemail":

                        break;
                    case "leaveDetail":
                        Response.Redirect("http://" + Session["servername"] + "/leaveDcard.aspx?empidvar=" + Session["ZxCurrEmpno"].ToString() + "&translv=" + Request.QueryString["leaveid"] + "");

                        break;

                    case "documentsupload":
                        Response.Redirect("http://" + Session["servername1"] + "/RetentionDocs.aspx?wzbaid=" + Session["ZxCurrzbaid"] + "&wempno=" + Session["ZxCurrEmpno"] + "&fileno=" + Request.QueryString["fno"].ToString() + "");

                        break;


                    case "receiptcancel":
                        Response.Redirect("receiptcancel.aspx?fileno=" + Request.QueryString["fileno"] + "&empno=" + Session["ZxCurrEmpno"] + "&vouchno=" + Request.QueryString["vouchno"] + "&branch=" + Session["ZxCurrzbaid"] + "");

                        break;
                    case "receiptcanceldbt":
                        Response.Redirect("http://" + Session["servername1"] + "/receiptcancel.aspx?fileno=" + Request.QueryString["fileno"] + "&empno=" + Session["ZxCurrEmpno"] + "&vouchno=" + Request.QueryString["vouchno"] + "&branch=" + Session["ZxCurrzbaid"] + "&mod=dbtnot");

                        break;

                    case "receiptcancelnew":
                        Response.Redirect("http://" + Session["servername1"] + "/receiptcancel.aspx?fileno=" + Request.QueryString["fileno"] + "&empno=" + Session["ZxCurrEmpno"] + "&vouchno=" + Request.QueryString["vouchno"] + "&branch=" + Session["ZxCurrzbaid"] + "");

                        break;
                    default:

                        break;

                }

            }
        }
        catch (Exception ex)
        {
            ShowMessage("error", ex.Message);
        }
    }

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
        }



    }

    #endregion


    public bool DoPageExists(string _fname)
    {
        bool _Exists = true;


        DirectoryInfo d = new DirectoryInfo(Server.MapPath("."));
        FileInfo[] infos = d.GetFiles("c*");
        foreach (FileInfo f in infos)
        {
            string _fn = f.ToString();
            if (_fn.Contains(_fname))
            {
                _Exists = true;

            }

        }

        return _Exists;

    }
}