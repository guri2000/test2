Imports System.Data
Imports System.IO
Imports Telerik.Web.UI
Imports System.Text
Imports System.Environment
Imports System.Globalization
Imports System.Data.OracleClient

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim clas As rahulcpm.commonclass = New rahulcpm.commonclass()

    Dim qry As String
    Dim dt As DataTable
    Dim sydate As String
    Dim agntid As Int32
    Dim msg As String
    Dim fsn As String
    Dim Empno As String
    Dim tid As String   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            filldll()
           
            Empno = Convert.ToString(Request.QueryString("empno"))

            If Convert.ToString(Request.QueryString("empno")) = "" Or Convert.ToString(Request.QueryString("bid")) = "" Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>User session has been expired. User needs to Re-login to access this application.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                ImageButton1.Enabled = False
                Button2.Enabled = False
                Exit Sub
            Else


            End If

            If Convert.ToString(Request.QueryString("typ")) = "edit" Then
                fillRecord()
            Else
                createdtfile()
                bindgrid()

            End If

        Else
            ' ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideProgress();", True)


        End If


    End Sub


    Private Sub fillRecord()
        pnl1.Enabled = False
        ddlProd.Enabled = False
        ddltyp.Enabled = False
        fuprw.Visible = False
        fuprw2.Visible = False
        pnl2.Visible = True
        Button1.Text = "Update"

        dtExp.SelectedDate = Date.Today.ToString("dd-MMM-yyyy")
        dtExp.MinDate = Date.Today.ToString("dd-MMM-yyyy")

        qry = "select * from TT.support_ticket where ticketid='" & Convert.ToString(Request.QueryString("sid")) & "'"
        dt = clas.getdata(qry, "tt")
        lblhd.Text = "Update Ticket"
        ddlemp()


        'If dt Is Nothing Then
        '    Exit Sub
        'End If
        If dt.Rows.Count > 0 Then
            lnk_ref.Visible = True
            lnkadd_sub.Visible = True
            lnkadd_sub.Attributes.Add("href", "submod_add.aspx?modid=" & Convert.ToString(dt.Rows(0)("moduleid")))

            txtrem.Text = Convert.ToString(dt.Rows(0)("descr"))

            txttime.Text = Convert.ToString(dt.Rows(0)("tat"))


            ' txtrply.Text = Convert.ToString(dt.Rows(0)("SUBMODULE"))            

            Dim qry2 = "select  SUBID id,SUBMOD_DESCR Description  from tt.SUPPORT_SUBMODMAST where SUBMDSTATUS='A' and moduleid='" & Convert.ToString(dt.Rows(0)("moduleid")) & "'"
            Dim dt2 As New DataTable
            dt2 = clas.getdata(qry2, "tt")
            bindfromdt(ddlsubmod, "", dt2, "", "Description", "id", "dropdown", True)

            If ddltyp.Items.FindByValue(Convert.ToString(dt.Rows(0)("TRNSSCOPE"))) IsNot Nothing Then
                ddltyp.Items.FindByValue(Convert.ToString(dt.Rows(0)("TRNSSCOPE"))).Selected = True
            End If

            If ddlProd.Items.FindByValue(Convert.ToString(dt.Rows(0)("moduleid"))) IsNot Nothing Then
                ddlProd.Items.FindByValue(Convert.ToString(dt.Rows(0)("moduleid"))).Selected = True
            End If

            If ddlsubmod.Items.FindByValue(Convert.ToString(dt.Rows(0)("SUBMODULE"))) IsNot Nothing Then
                ddlsubmod.Items.FindByValue(Convert.ToString(dt.Rows(0)("SUBMODULE"))).Selected = True
            End If
       



            If ddlstatus.Items.FindByValue(Convert.ToString(dt.Rows(0)("status"))) IsNot Nothing Then
                ddlstatus.Items.FindByValue(Convert.ToString(dt.Rows(0)("status"))).Selected = True
            End If

            If ddlassign.Items.FindByValue(Convert.ToString(dt.Rows(0)("assignto"))) IsNot Nothing Then
                ddlassign.Items.FindByValue(Convert.ToString(dt.Rows(0)("assignto"))).Selected = True
            End If



            If Convert.ToString(dt.Rows(0)("expenddt")) <> "" Then
                'binddates(dtExp, "", Date.Today.AddYears().ToString("dd-MMM-yyyy"), date1.ToString("dd-MMM-yyyy"), True)
                If DateTime.Now > CDate(dt.Rows(0)("expenddt")) Then
                    dtExp.MinDate = Convert.ToString(dt.Rows(0)("expenddt"))
                Else
                    dtExp.MinDate = DateTime.Now
                End If

                dtExp.SelectedDate = Convert.ToString(dt.Rows(0)("expenddt"))
            End If
            ViewState("ASSIGNDATE") = Convert.ToString(dt.Rows(0)("ASSIGNDATE"))



        Else
            ImageButton1.Enabled = False
            Button2.Enabled = False
        End If




    End Sub

    Private Sub ddlemp()
        Dim qry = "select  empno,name||' ('|| Branch ||' - '|| EmpDesignation ||')' Name from tt.employees where active='T' AND DEPTCODE=15 order by name"

        Dim dt1 As New DataTable

        dt1 = clas.getdata(qry, "tt")
        ddlassign.DataValueField = "empno"
        ddlassign.DataTextField = "name"
        ddlassign.DataSource = dt1
        ddlassign.DataBind()


    End Sub

    Protected Sub binddates(ByVal cntl As Control, ByVal seldate As String, ByVal mindate As String, ByVal maxdate As String, ByVal enbl As Boolean)

        Dim cnrl1 As RadDatePicker = TryCast(cntl, RadDatePicker)
        If Not seldate.Trim = "" Then
            cnrl1.SelectedDate = seldate
        Else
            '  cnrl1.SelectedDate = Date.Today.ToString("dd-MMM-yyyy")
        End If
        If Not mindate.Trim = "" Then
            cnrl1.MinDate = mindate
        Else
            cnrl1.MinDate = Date.Today.ToString("dd-MMM-yyyy")
        End If
        If Not maxdate.Trim = "" Then
            cnrl1.MaxDate = maxdate
        Else
            cnrl1.MaxDate = Date.Today.ToString("dd-MMM-yyyy")
        End If
        cnrl1.Enabled = enbl
    End Sub



    Private Sub filldll()
        qry = "select  id , modulename Description  from tt.support_module where status='A' "
        dt = clas.getdata(qry, "tt")
        bindfromdt(ddlProd, "", dt, "", "Description", "id", "dropdown", True)

       
        qry = "select a.TECHSPFLG,b.deptcode from  tt.user_master a,tt.employees b where a.empno=b.empno and a.empno='" & Convert.ToString(Request.QueryString("empno")) & "'"
        dt = Nothing
        dt = clas.getdata(qry, "tt")
        If dt.Rows.Count > 0 Then
            ViewState("tflag") = Convert.ToString(dt.Rows(0)("TECHSPFLG"))
            ViewState("deptcode") = Convert.ToString(dt.Rows(0)("deptcode"))
        Else
            ViewState("tflag") = "N"
        End If

        If ViewState("tflag") = "Y" Then
            qry = "select statcd id ,statdescr Description from tt.ipdocstatus where scope=3505 and active='Y' "
        Else
            qry = "select statcd id ,statdescr Description  from tt.ipdocstatus where scope=3505 and active='Y' and statcd not in (3505,3506,3507,3508,3509) "
        End If

        dt = clas.getdata(qry, "tt")
        bindfromdt(ddlstatus, "", dt, "", "Description", "id", "dropdown", True)

        'qry = "select vid id ,vname Description from tt.BR_vendormaster where branch='" & Convert.ToString(Request.QueryString("bid")) & "'"
        'dt = clas.getdata(qry, "tt")
        'bindfromdt(ddlParty, "", dt, "", "Description", "id", "dropdown", True)


        'qry = "selecT currcode id,descr Description from tt.CURRENCYMASTER"


    End Sub



    Protected Sub bindfromdt(ByVal cntl As Control, ByVal filquery As String, ByVal sdt As DataTable, ByVal selval As String, ByVal disptxt As String, ByVal dispval As String, ByVal cntltyp As String, ByVal enbl As Boolean)
        Dim dv As DataView = New DataView()
        dv = sdt.DefaultView

        If cntltyp = "dropdown" Then
            Dim cnt As DropDownList = TryCast(cntl, DropDownList)
            cnt.ClearSelection()
            cnt.Items.Clear()
            cnt.DataSource = Nothing
            cnt.DataBind()
            cnt.AppendDataBoundItems = True
            Dim itm As ListItem = New ListItem("Select Value", "")
            cnt.Items.Add(itm)
            cnt.DataSource = dv
            cnt.DataTextField = disptxt
            cnt.DataValueField = dispval
            cnt.DataBind()
            If selval.Length > 0 AndAlso selval.Trim() <> "" Then cnt.Items.FindByValue(selval).Selected = True
            cnt.Enabled = enbl
            cnt.AppendDataBoundItems = False
        ElseIf cntltyp = "radcombo" Then
            Dim cnt As RadComboBox = TryCast(cntl, RadComboBox)
            cnt.ClearSelection()
            cnt.Items.Clear()
            cnt.DataSource = Nothing
            cnt.DataBind()
            cnt.DataSource = dv
            cnt.DataTextField = disptxt
            cnt.DataValueField = dispval
            cnt.DataBind()
            If selval.Length > 0 AndAlso selval.Trim() <> "" Then cnt.Items.FindItemByValue(selval).Selected = True
            cnt.Enabled = enbl
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click, ImageButton1.Click


    
    
        Dim filename1 As String
        Dim nid
        Dim str1 As String
        Dim i As Int32
        Dim str As StringBuilder = New StringBuilder
        Dim expdt As String = ""
        Dim invdt As String = ""
        Dim paydt As String = ""

        If txtrem.Text <> "" Then
            txtrem.Text = txtrem.Text.Replace("'", "").Replace("""", "").Replace("%", "").Replace("+", "").Replace("&", "").Trim
        End If

        If txtAsgRem.Text <> "" Then
            txtAsgRem.Text = txtAsgRem.Text.Replace("'", "").Replace("""", "").Replace("%", "").Replace("+", "").Replace("&", "").Trim
        End If

        If dtExp.SelectedDate IsNot Nothing Then
            expdt = CDate(dtExp.SelectedDate).ToString("dd-MMM-yyyy hh:mm:ss tt")
        End If





        If Button1.Text = "Update" Then

            If ddlstatus.SelectedValue = "" Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Defining Status is mandatory requirement.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                Exit Sub
            End If

            If ddlPrior.SelectedValue = "" Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Defining priority is mandatory requirement.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                Exit Sub
            End If
            If txtAsgRem.Text.Trim = "" Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Remarks is mandatory requirement.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                Exit Sub
            End If



            If Not (ddlstatus.SelectedValue = "3508" And ddlassign.SelectedValue = "") Then
                If ddlassign.SelectedValue = "" Then
                    RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Defining 'Assign To' is mandatory requirement.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                    Exit Sub
                End If

                If txttime.Text.Trim = "" Then
                    RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Defining Timeframe is mandatory requirement.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                    Exit Sub
                End If

                If Convert.ToInt32(txttime.Text) <= 0 Then
                    RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Invalid Time (TAT) given in the field.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                    Exit Sub
                End If

            End If


            'If ddlstatus.SelectedValue = "3503" And ddlassign.SelectedValue = "" Then
            '  str.Append(" update  tt.support_ticket set status='" & ddlstatus.SelectedValue & "', SUBMODULE= '" & ddlsubmod.SelectedValue & "', ackby='" & Convert.ToString(Request.QueryString("empno")) & "', LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate")
            ' str.Append(" where ticketid= " & Convert.ToString(Request.QueryString("sid")))
            'Else
            '    If ViewState("ASSIGNDATE").ToString.Length > 1 Then
            ' str.Append(" update  tt.support_ticket set status='" & ddlstatus.SelectedValue & "',EXPENDDT= to_date('" & expdt & "','dd-Mon-yyyy hh:mi:ss am'),tat='" & txttime.Text.Trim & "', SUBMODULE= '" & ddlsubmod.SelectedValue & "',ASSIGNTO= '" & ddlassign.SelectedValue & "', ackby='" & Convert.ToString(Request.QueryString("empno")) & "', ASSIGNDATE=sysdate,LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate")
            'str.Append(" where ticketid= " & Convert.ToString(Request.QueryString("sid")))
            'Else

            '        End If
            '        End If

            str.Append(" update  tt.support_ticket set status='" & ddlstatus.SelectedValue & "',EXPENDDT= to_date('" & expdt & "','dd-Mon-yyyy hh:mi:ss am'),tat='" & txttime.Text.Trim & "', SUBMODULE= '" & ddlsubmod.SelectedValue & "',ASSIGNTO= '" & ddlassign.SelectedValue & "', ackby='" & Convert.ToString(Request.QueryString("empno")) & "', ASSIGNDATE=sysdate,LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate,SENSITIVE='" & ddlPrior.SelectedValue & "'")
            str.Append(" where ticketid= " & Convert.ToString(Request.QueryString("sid")))



        Else

            If txtrem.Text.Trim = "" Then
                RadWindowManager1.RadAlert("<div style=color:red;> Defining value for Description field is mandatory requirement. </div>", 300, 150, "Validation Success", Nothing)
                Exit Sub
            End If


            nid = clas.getMaxID("select tt.support_ticket_seq.nextval from dual")

            Dim dtfile As New DataTable
            dtfile = ViewState("dtfile")


            If dtfile IsNot Nothing Then
                Dim n = dtfile.Rows.Count
                For i = 0 To n - 1
                    '( FID, TKID, FILENAME,keyedby,keyedon ) values(tt.support_doc_seq.nextval , '" & Request.QueryString("sid") & "','" & fileName & "','" & Request.QueryString("empno") & "',sysdate)"
                    str1 = "insert into tt.support_doc (fid,tkid,FILENAME,keyedon,keyedby) values "
                    str1 += " ( tt.support_doc_seq.nextval,'" & nid & "','" & dtfile.Rows(i)("filename") & "',sysdate,'" & Request.QueryString("empno") & "')"
                    clas.ExecuteNonQuery(str1.ToString())
                Next
            End If

            If dtfile IsNot Nothing Then
                Dim n = dtfile.Rows.Count
                If n = 0 Then
                    If fupl.HasFile = True Then

                        Dim fileName As String = Path.GetFileName(fupl.PostedFile.FileName).ToLower()

                        If fileName = "" Then
                            RadWindowManager1.RadAlert("<div style=color:green;>Please Browse and attache required file. </div>", 300, 150, "Validation Success", Nothing)
                            Exit Sub

                        Else

                            If fileName.Contains("%") Or fileName.Contains("'") Or fileName.Contains("""") Or fileName.Contains("&") Then
                                RadWindowManager1.RadAlert("<div style=color:red;> Given attachment name is not a valid name as per MS-Windows. </div>", 300, 150, "Validation Success", Nothing)
                                Exit Sub
                            End If

                            fileName = Replace(fileName.Replace("""", "").Replace("%", "").Replace("&", "").Replace("+", ""), "'", "")

                            Dim actfileName As String = fileName

                            Dim ext As String = Path.GetExtension(fupl.PostedFile.FileName)
                            '  Dim ext As String = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
                            Dim fileSize As Long = fupl.PostedFile.ContentLength
                            If ext.ToLower.Contains(".exe") Or ext.ToLower.Contains(".bat") Then
                                RadWindowManager1.RadAlert("<div style=color:Red;> Invalid File format. </div>", 300, 150, "Validation Error", Nothing)
                                Exit Sub
                            End If

                            If fileSize < 20045728 Then


                                fileName = fileName.Replace(" ", "_")

                                Dim FileNM1 As String() = fileName.Split(".")
                                Dim datestr As String = String.Format("{0:ddMMMyyyyHmmss}", DateTime.Now)
                                fileName = FileNM1(0) & datestr & ext

                                Dim Path As String = (Server.MapPath("TicketSuppdoc/") + fileName)
                                fupl.PostedFile.SaveAs(Path)

                                Dim client_ip As String = Request.UserHostAddress()
                                Dim Browser_Name As String = Request.Browser.Browser.ToString & " " & Request.Browser.Version.ToString


                            Else
                                RadWindowManager1.RadAlert("<div style=color:Red;> Attachment file size should not exceeed allotted limited of 20 MB. </div>", 300, 150, "Validation Error", Nothing)
                                Exit Sub
                        End If

                        Dim str2 = "insert into tt.support_doc (fid,tkid,FILENAME,keyedon,keyedby) values "
                        str2 += " ( tt.support_doc_seq.nextval,'" & nid & "','" & fileName & "',sysdate,'" & Request.QueryString("empno") & "')"
                        clas.ExecuteNonQuery(str2.ToString())


                        End If
                    End If

                End If

            End If



            If ddlProd.SelectedValue = "" Then
                RadWindowManager1.RadAlert("<div style=color:Red;> Defining Product Description is mandatory requirement at this stage of the process. </div>", 300, 150, "Validation Error", Nothing)
                Exit Sub
            End If


            str.Append("insert into tt.support_ticket (TICKETID,MODULEID,DESCR,STATUS,TICKETRAISEDBY,TICKETRAISEDON,keyedin,KEYEDBY,KEYEDIP,SUBMODULE,TRNSSCOPE) values ")
            str.Append(" ( '" & nid & "','" & ddlProd.SelectedValue & "','" & txtrem.Text & "','3500', '" & Convert.ToString(Request.QueryString("empno")) & "',sysdate,sysdate, '" & Convert.ToString(Request.QueryString("empno")) & "','" & HttpContext.Current.Request.UserHostAddress & "' , '" & ddlsubmod.SelectedValue & "' , '" & ddltyp.SelectedValue & "' )")

            End If



            If str.ToString().Length > 0 Then
                Dim rah As Int32 = clas.ExecuteNonQuery(str.ToString())


                If rah = 0 Then

                    Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                    Err_Msg = Err_Msg.Replace(vbCr, "")
                    Err_Msg = Err_Msg.Replace(vbLf, "")

                    If Err_Msg.Trim().Length > 0 Then

                        RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System encountered some unhandled exception: " & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)

                        Exit Sub
                    End If

                Else
                    '  lnk.Attributes.Add("href", "daybook_doc.aspx?tid=" & tid)

                    If Button1.Text <> "Update" Then

                        RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Support Ticket Initiated successfully</div></li></ul>", 300, 150, "Validation Success", Nothing)
                    Else

                        RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Transaction done successfully</div></li></ul>", 300, 150, "Validation Success", Nothing)
                    End If




                    createdtfile()
                    bindgrid()
                    ' RadGrid1.Rebind()
                    If Button1.Text <> "Update" Then
                        clear()
                    Else
                        If txtAsgRem.Text.Trim.Length > 0 Then
                            qry = "insert into TT.SUPPORT_COMMENT (ACTID,TKID,ACTBY,ACTDT,REMARKS,TKTSTATUS ) values "
                            qry += " (TT.SUPPORT_COMMEN_seq.nextval,'" & Convert.ToString(Request.QueryString("sid")) & "','" & Convert.ToString(Request.QueryString("empno")) & "',sysdate,'" & txtAsgRem.Text.Trim & "','" & ddlstatus.SelectedValue & "')"
                            Dim k = clas.ExecuteNonQuery(qry)
                        End If
                    End If

                End If

            End If



    End Sub





    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear()

    End Sub



    Private Sub clear()
        txtrem.Text = String.Empty
        txtsub.Text = String.Empty
        '  txtrply.Text = String.Empty
        ddlProd.ClearSelection()


    End Sub



    Private Sub uploadfile()

        If fupl.HasFile = True Then

            Dim fileName As String = Path.GetFileName(fupl.PostedFile.FileName).ToLower()

            If fileName = "" Then
                RadWindowManager1.RadAlert("<div style=color:green;>Please Browse and attache required file. </div>", 300, 150, "Validation Success", Nothing)
                Exit Sub

            Else

                If fileName.Contains("%") Or fileName.Contains("'") Or fileName.Contains("""") Or fileName.Contains("&") Then
                    RadWindowManager1.RadAlert("<div style=color:red;> Given attachment name is not a valid name as per MS-Windows. </div>", 300, 150, "Validation Success", Nothing)
                    Exit Sub
                End If

                fileName = Replace(fileName.Replace("""", "").Replace("%", "").Replace("&", "").Replace("+", ""), "'", "")

                Dim actfileName As String = fileName

                Dim ext As String = Path.GetExtension(fupl.PostedFile.FileName)
                '  Dim ext As String = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
                Dim fileSize As Long = fupl.PostedFile.ContentLength
                If fileSize < 20045728 Then
                    If ext.ToLower.Contains(".zip") Or ext.ToLower.Contains(".rar") Then
                        fileName = fileName.Replace(" ", "_")

                        Dim FileNM1 As String() = fileName.Split(".")
                        Dim datestr As String = String.Format("{0:ddMMMyyyyHmmss}", DateTime.Now)
                        fileName = FileNM1(0) & datestr & ext

                        Dim Path As String = (Server.MapPath("TicketSuppdoc/") + fileName)
                        fupl.PostedFile.SaveAs(Path)

                        Dim client_ip As String = Request.UserHostAddress()
                        Dim Browser_Name As String = Request.Browser.Browser.ToString & " " & Request.Browser.Version.ToString
                    End If

                Else
                    RadWindowManager1.RadAlert("<div style=color:Red;> Attachment file size should not exceeed allotted limited of 20 MB. </div>", 300, 150, "Validation Error", Nothing)
                    Exit Sub
                End If



            End If
        End If

    End Sub


    Protected Sub lnkaddfile_Click(sender As Object, e As System.EventArgs) Handles lnkaddfile.Click
        Dim filename1 As String
        Dim str1 As String
        If fupl.HasFile = True Then

            filename1 = Path.GetFileName(fupl.PostedFile.FileName).ToLower()

            If filename1 = "" Then
                RadWindowManager1.RadAlert("<div style=color:green;> Please Brwose the required attachment. </div>", 300, 150, "Validation Success", Nothing)
                Exit Sub
            Else

                If filename1.Contains("%") Or filename1.Contains("'") Or filename1.Contains("""") Or filename1.Contains("&") Then
                    RadWindowManager1.RadAlert("<div style=color:red;> Invalid File Name. </div>", 300, 150, "Validation Success", Nothing)
                    Exit Sub
                End If

                filename1 = Replace(filename1.Replace("""", "").Replace("%", "").Replace("&", "").Replace("+", ""), "'", "")

                Dim actfileName As String = filename1

                Dim ext As String = Path.GetExtension(fupl.PostedFile.FileName)
                '  Dim ext As String = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
                If ext.ToLower.Contains(".exe") Or ext.ToLower.Contains(".bat") Then
                    RadWindowManager1.RadAlert("<div style=color:Red;> Invalid File format. </div>", 300, 150, "Validation Error", Nothing)
                    Exit Sub
                End If
                Dim fileSize As Long = fupl.PostedFile.ContentLength
                If fileSize < 20045728 Then

                    filename1 = filename1.Replace(" ", "_")

                    Dim FileNM1 As String() = filename1.Split(".")
                    Dim datestr As String = String.Format("{0:ddMMMyyyyHmmss}", DateTime.Now)
                    filename1 = FileNM1(0) & datestr & ext

                    Dim Path As String = (Server.MapPath("TicketSuppdoc/") + filename1)
                    fupl.PostedFile.SaveAs(Path)
                

                Else
                    RadWindowManager1.RadAlert("<div style=color:Red;> Document should not contain file size more than 20 MB. </div>", 300, 150, "Validation Error", Nothing)
                    Exit Sub
                End If

            End If


            Dim dttmp = New DataTable()

            If ViewState("dtfile") IsNot Nothing Then
                dttmp = ViewState("dtfile")
            Else

            End If

            Dim cnt = 0
            If ViewState("dtfile") IsNot Nothing Then
                dttmp = ViewState("dtfile")
                cnt = dttmp.Rows.Count
                cnt = cnt + 1
                dttmp.Rows.Add(cnt, filename1)
                ViewState("dtfile") = dttmp
            Else
                ViewState("dtfile") = dttmp
            End If

            bindgrid()

        Else
            RadWindowManager1.RadAlert("<div style=color:Red;> Please select  file to upload </div>", 300, 150, "Validation Error", Nothing)
            Exit Sub
        End If




    End Sub

    Private Sub createdtfile()
        Dim dttmp = New DataTable()
        Dim dcID = New DataColumn("ID", GetType(Int32))
        Dim dcName = New DataColumn("FileName", GetType(String))
        dttmp.Columns.Add(dcID)
        dttmp.Columns.Add(dcName)
        ViewState("dtfile") = Nothing
        ViewState("dtfile") = dttmp
    End Sub

    Private Sub bindgrid()
        RadGrid1.DataSource = ViewState("dtfile")
        RadGrid1.DataBind()
    End Sub

    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "revoke" Then
            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)


            Dim dt As DataTable = CType(ViewState("dtfile"), DataTable)
            Dim rowsToDelete As List(Of DataRow) = New List(Of DataRow)()

            For Each row As DataRow In dt.Rows

                If row("id") = item.GetDataKeyValue("id").ToString Then
                    rowsToDelete.Add(row)
                End If
            Next

            For Each row As DataRow In rowsToDelete
                dt.Rows.Remove(row)
            Next

            dt.AcceptChanges()

            ViewState("dtfile") = dt

            bindgrid()
            RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Revoked Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
        ElseIf e.CommandName = "download" Then
            If TypeOf e.Item Is GridDataItem Then
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)

                Dim fname = item("FileName").Text


                If fname.Trim().Length > 0 Then

                    If File.Exists(Server.MapPath("~/TicketSuppdoc/" & fname)) = True Then
                        Response.ContentType = "application/octet-stream"
                        Response.AppendHeader("Content-Disposition", "attachment;filename=" & fname)
                        Response.TransmitFile(Server.MapPath("~/TicketSuppdoc/" & fname))
                        Response.End()
                    Else
                        RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System is unable to found any document for download...</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                        Exit Sub
                    End If

                Else
                    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System is unable to found any document for download.</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                    Exit Sub
                End If

            End If


        End If
    End Sub





    Protected Sub RadGrid2_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid2.ItemCommand
        If e.CommandName = "Filter" Then



        ElseIf e.CommandName = "download" Then
            If TypeOf e.Item Is GridDataItem Then
                Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)

                Dim fname As String = clas.ExecuteScalar("select filename from  tt.support_doc where fid= '" & item.GetDataKeyValue("fid").ToString() & "'")


                If fname.Trim().Length > 0 Then

                    If File.Exists(Server.MapPath("~/TicketSuppdoc/" & fname)) = True Then
                        Response.ContentType = "application/octet-stream"
                        Response.AppendHeader("Content-Disposition", "attachment;filename=" & fname)
                        Response.TransmitFile(Server.MapPath("~/TicketSuppdoc/" & fname))
                        Response.End()
                    Else
                        RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System is unable to found any document for download...</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                        Exit Sub
                    End If

                Else
                    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System is unable to found any document for download.</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                    Exit Sub
                End If

            End If

        End If
    End Sub

    Protected Sub RadGrid2_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid2.ItemDataBound
        RadGrid2.MasterTableView.GetColumn("FID").ItemStyle.Width = 0
        RadGrid2.MasterTableView.GetColumn("FID").HeaderStyle.Width = 0
        RadGrid2.MasterTableView.GetColumn("TKID").ItemStyle.Width = 0
        RadGrid2.MasterTableView.GetColumn("TKID").HeaderStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("FILEPATH").ItemStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("FILEPATH").HeaderStyle.Width = 0



    End Sub




    Protected Sub RadGrid2_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource

        qry = "SELECT FID, TKID,tkid TickedID, FILENAME FROM TT.SUPPORT_DOC where tkid='" & Request.QueryString("sid") & "'"
        dt = clas.getdata(qry, "QR")
        RadGrid2.DataSource = dt
    End Sub

    Protected Sub dtExp_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles dtExp.SelectedDateChanged
        If dtExp.SelectedDate Is Nothing Then
            Exit Sub
        End If
        Dim Dt1 As DateTime = dtExp.SelectedDate
        Dim Dt2 As DateTime = DateTime.Now

        Dim totalminutes As Int32 = (Dt1 - Dt2).TotalMinutes
        txttime.Text = totalminutes.ToString
        TXTTIME1.Value = totalminutes.ToString
    End Sub

    Protected Sub ddlProd_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlProd.SelectedIndexChanged
        qry = "select  SUBID id,SUBMOD_DESCR Description  from tt.SUPPORT_SUBMODMAST where SUBMDSTATUS='A' and moduleid='" & ddlProd.SelectedValue & "'"
        dt = clas.getdata(qry, "tt")
        bindfromdt(ddlsubmod, "", dt, "", "Description", "id", "dropdown", True)

    End Sub


    Protected Sub lnk_ref_Click(sender As Object, e As System.EventArgs) Handles lnk_ref.Click
        Dim qry2 = "select  SUBID id,SUBMOD_DESCR Description  from tt.SUPPORT_SUBMODMAST where SUBMDSTATUS='A' and moduleid='" & ddlProd.SelectedValue & "'"
        Dim dt2 As New DataTable
        dt2 = clas.getdata(qry2, "tt")
        bindfromdt(ddlsubmod, "", dt2, "", "Description", "id", "dropdown", True)
    End Sub

    Protected Sub ddltyp_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddltyp.SelectedIndexChanged
        If ddltyp.SelectedValue = "H" Then
            qry = "select  id , modulename Description  from tt.support_module where status='A' and  mod_group='H'"
        Else
            qry = "select  id , modulename Description  from tt.support_module where status='A' and mod_group='A' "
        End If

        dt = clas.getdata(qry, "tt")
        bindfromdt(ddlProd, "", dt, "", "Description", "id", "dropdown", True)
    End Sub

End Class