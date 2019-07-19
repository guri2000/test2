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
                RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Seesion expired retry.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                ImageButton1.Enabled = False
                Button2.Enabled = False

                Exit Sub
            Else


            End If

            If Convert.ToString(Request.QueryString("typ")) = "edit" Then
                ' fillRecord()
            Else


            End If

        Else
            ' ClientScript.RegisterStartupScript(Me.GetType(), "alert", "HideProgress();", True)




        End If


    End Sub






    Private Sub fillRecord()
        'qry = "select * from TT.BR_DAYBOOK where BRTRID=" & Convert.ToString(Request.QueryString("tid"))
        'dt = clas.getdata(qry, "tt")    
        'If dt.Rows.Count > 0 Then
        '    Dim date1 As DateTime
        '    If Convert.ToString(dt.Rows(0)("APPDATE")) <> "" Then
        '        DateTime.TryParse(Convert.ToString(dt.Rows(0)("APPDATE")), date1)
        '        binddates(dt_approval, "", Date.Today.AddYears(-5).ToString("dd-MMM-yyyy"), date1.ToString("dd-MMM-yyyy"), True)
        '        dt_approval.SelectedDate = Convert.ToString(dt.Rows(0)("APPDATE"))
        '    End If


        '    If Convert.ToString(dt.Rows(0)("INVDT")) <> "" Then
        '        DateTime.TryParse(Convert.ToString(dt.Rows(0)("INVDT")), date1)
        '        binddates(dt_inv, "", Date.Today.AddYears(-5).ToString("dd-MMM-yyyy"), date1.ToString("dd-MMM-yyyy"), True)

        '        dt_inv.SelectedDate = Convert.ToString(dt.Rows(0)("INVDT"))
        '    End If


        'Else
        '    ImageButton1.Enabled = False
        '    Button2.Enabled = False
        '    lnk.Enabled = False
        'End If


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
        'binddates(dt_approval, "", Date.Today.AddYears(-5).ToString("dd-MMM-yyyy"), Date.Today.ToString("dd-MMM-yyyy"), True)


        qry = "select TECHSPFLG  from tt.user_master   where empno='" & Convert.ToString(Request.QueryString("empno")) & "'"
        dt = clas.getdata(qry, "tt")
        Dim dt1 As New DataTable
        dt1 = clas.getdata("  select deptcode from  tt.employees  where empno='" & Convert.ToString(Request.QueryString("empno")) & "'", "tt")

        If dt.Rows.Count > 0 Then
            ViewState("tflag") = Convert.ToString(dt.Rows(0)("TECHSPFLG"))
            ViewState("deptcode") = Convert.ToString(dt1.Rows(0)("deptcode"))
        Else
            ViewState("tflag") = "N"           
            ViewState("deptcode") = Convert.ToString(dt1.Rows(0)("deptcode"))
        End If


        If ViewState("deptcode") = "15" And ViewState("tflag") = "Y" Then
            qry = "select statcd id ,statdescr Description from tt.ipdocstatus where scope=3505 and active='Y' and statcd  in (3507,3508) "         

        ElseIf ViewState("deptcode") = "15" Then
            qry = "select statcd id ,statdescr Description from tt.ipdocstatus where scope=3505 and active='Y' and statcd in (3509,3510,3502) "

        Else
            qry = "select statcd id ,statdescr Description from tt.ipdocstatus where scope=3505 and active='Y' and statcd in (3507,3508) "

        End If

        dt = clas.getdata(qry, "tt")
        bindfromdt(ddlstatus, "", dt, "", "Description", "id", "dropdown", True)

        lblticket.Text = Convert.ToString(Request.QueryString("sid"))
        'qry = "select vid id ,vname Description from tt.BR_vendormaster where branch='" & Convert.ToString(Request.QueryString("bid")) & "'"
        'dt = clas.getdata(qry, "tt")
        'bindfromdt(ddlParty, "", dt, "", "Description", "id", "dropdown", True)


        If ViewState("deptcode") = "15" And ViewState("tflag") = "Y" Then


        ElseIf ViewState("deptcode") = "15" Then


        Else
            ddlstatus.Enabled = False
            ddlstatus.Items.FindByValue("3508").Selected = True

            fupl.Enabled = False
            Divrating.Visible = True
        End If
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



        If txtrem.Text <> "" Then
            txtrem.Text = txtrem.Text.Replace("'", "").Replace("""", "").Replace("%", "").Replace("+", "").Replace("&", "")
        End If

        If ddlstatus.SelectedValue = "" Then            
            RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Defining Status is mandatory requirement.</div></li></ul>", 300, 150, "Validation Error", Nothing)
            Exit Sub
        End If

        If txtrem.Text.Trim = "" Then
            RadWindowManager1.RadAlert("<ul><li><div style=color:red;>Remarks is required </div></li></ul>", 300, 100, "Validation Failure", Nothing)
            Exit Sub
        End If

        If RadRating1.Visible = True And RadRating1.Value = 0 Then
            RadWindowManager1.RadAlert("<ul><li><div style=color:red;>Rating is required </div></li></ul>", 300, 100, "Validation Failure", Nothing)
            Exit Sub
        End If


        Dim i As Int32


        Dim str As StringBuilder = New StringBuilder


        Dim expdt As String = ""

        '   If dtExp.SelectedDate IsNot Nothing Then
        '    expdt = CDate(dtExp.SelectedDate).ToString("dd-MMM-yyyy")
        'End If





        If Button1.Text = "Update" Then

            'str.Append(" update TT.SUPPORT_COMMENT  set PARTYID='" & ddlParty.SelectedValue & "',APPDATE= '" & appdt & "',EXPHEADID= '" & ddlExpe.SelectedValue & "',EXPDATE= '" & expdt & "',INVDT= '" & invdt & "',INVAMT='" & txtinvAmt.Text.Trim & "',RECTDATE= '" & recdt & "',Paydt= '" & paydt & "',PARTYGSTNO='" & txtGst.Text.Trim & "',PAYSTATUS='" & paystatus & "',LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate,remarks='" & txtrem.Text & "',TRNSCURR='" & curr & "' ,sub='" & txtsub.Text & "', catid='" & ddlImm.SelectedValue & "'")
            'str.Append(" where BRTRID= " & Convert.ToString(Request.QueryString("tid")))

        Else
            Dim fileName As String
            If fupl.HasFile = True Then

                fileName = Path.GetFileName(fupl.PostedFile.FileName).ToLower()

                If fileName = "" Then
                    RadWindowManager1.RadAlert("<div style=color:green;> Please browse your required file. </div>", 300, 150, "Validation Success", Nothing)
                    Exit Sub

                Else

                    If fileName.Contains("%") Or fileName.Contains("'") Or fileName.Contains("""") Or fileName.Contains("&") Then
                        RadWindowManager1.RadAlert("<div style=color:red;> Invalid File Name. </div>", 300, 150, "Validation Success", Nothing)
                        Exit Sub
                    End If

                    fileName = Replace(fileName.Replace("""", "").Replace("%", "").Replace("&", "").Replace("+", ""), "'", "")

                    Dim actfileName As String = fileName

                    Dim ext As String = Path.GetExtension(fupl.PostedFile.FileName)
                    '  Dim ext As String = Path.GetExtension(FileUpload1.PostedFile.FileName).ToLower()
                    Dim fileSize As Long = fupl.PostedFile.ContentLength
                    ' If fileSize < 5145728 Then
                    ' If ext.ToLower.Contains(".jpg") Or ext.ToLower.Contains(".JPG") Or ext.ToLower.Contains(".png") Or ext.ToLower.Contains(".PNG") Then
                    If ext.ToLower.Contains(".exe") Or ext.ToLower.Contains(".bat") Then
                        RadWindowManager1.RadAlert("<div style=color:Red;> Invalid File format. </div>", 300, 150, "Validation Error", Nothing)
                        Exit Sub
                    Else
                        fileName = fileName.Replace(" ", "_")

                        Dim FileNM1 As String() = fileName.Split(".")
                        Dim datestr As String = String.Format("{0:ddMMMyyyyHmmss}", DateTime.Now)
                        fileName = FileNM1(0) & datestr & ext

                        Dim Path As String = (Server.MapPath("TicketSuppdoc/") + fileName)
                        fupl.PostedFile.SaveAs(Path)



                        qry = "insert into TT.support_doc ( FID, TKID, FILENAME,KEYEDBY,KEYEDON ) values(tt.support_doc_seq.nextval , '" & Request.QueryString("sid") & "','" & fileName & "','" & Request.QueryString("empno") & "',SYSDATE )"
                        Dim J = clas.ExecuteNonQuery(qry.ToString())
                        If J = 1 Then
                            '  RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Document Uploaded Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                            RadGrid1.Rebind()
                        Else

                            Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                            Err_Msg = Err_Msg.Replace(vbCr, "")
                            Err_Msg = Err_Msg.Replace(vbLf, "")
                            RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                            'Exit Sub
                        End If


                    End If

                    ' Else
                    '  RadWindowManager1.RadAlert("<div style=color:Red;> Document should not contain file size more than 5 MB. </div>", 300, 150, "Validation Error", Nothing)
                    '    Exit Sub
                    '  End If

                End If

            End If






            str.Append("insert into TT.SUPPORT_COMMENT (ACTID,TKID,ACTBY,ACTDT,REMARKS,TKTSTATUS ) values ")
            str.Append(" (TT.SUPPORT_COMMEN_seq.nextval,'" & Convert.ToString(Request.QueryString("sid")) & "','" & Convert.ToString(Request.QueryString("empno")) & "',sysdate,'" & txtrem.Text.Trim & "','" & ddlstatus.SelectedValue & "')")


        End If

        If str.ToString().Length > 0 Then
            Dim rah As Int32 = clas.ExecuteNonQuery(str.ToString())
            If rah = 0 Then

                Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                Err_Msg = Err_Msg.Replace(vbCr, "")
                Err_Msg = Err_Msg.Replace(vbLf, "")

                If Err_Msg.Trim().Length > 0 Then

                    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)

                    Exit Sub
                End If

            Else

                Dim qry

                If txtext.Text.Trim.Length > 0 Then
                    qry = " update tt.support_ticket set EXTENDTIME='" & txtext.Text.Trim & "' where TICKETID='" & Convert.ToString(Request.QueryString("sid")) & "'"
                    Dim chk = clas.ExecuteNonQuery(qry)
                    If chk = 0 Then

                        Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                        Err_Msg = Err_Msg.Replace(vbCr, "")
                        Err_Msg = Err_Msg.Replace(vbLf, "")

                        If Err_Msg.Trim().Length > 0 Then

                            RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)

                            Exit Sub
                        End If
                    End If
                End If

                '   If ddlstatus.SelectedValue = "3508" Then
                'qry = " update tt.support_ticket set status= , STARRATING='" & RadRating1.Value & "', LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate where TICKETID='" & Convert.ToString(Request.QueryString("sid")) & "'"
                'clas.ExecuteNonQuery(qry)
                'ElseIf ddlstatus.SelectedValue = "3507" Then
                'qry = " update tt.support_ticket set status=3500 where TICKETID='" & Convert.ToString(Request.QueryString("sid")) & "'"
                'clas.ExecuteNonQuery(qry)
                'ElseIf ddlstatus.SelectedValue = "3509" Then
                'qry = " update tt.support_ticket set status=3509 where TICKETID='" & Convert.ToString(Request.QueryString("sid")) & "'"
                'clas.ExecuteNonQuery(qry)
                'ElseIf ddlstatus.SelectedValue = "3510" Then
                'qry = " update tt.support_ticket set status=3510 where TICKETID='" & Convert.ToString(Request.QueryString("sid")) & "'"

                qry = " update tt.support_ticket set status='" & ddlstatus.SelectedValue & "' , STARRATING='" & RadRating1.Value & "', LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate where TICKETID='" & Convert.ToString(Request.QueryString("sid")) & "'"
                Dim chk1 = clas.ExecuteNonQuery(qry)

                If chk1 = 0 Then

                    Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                    Err_Msg = Err_Msg.Replace(vbCr, "")
                    Err_Msg = Err_Msg.Replace(vbLf, "")

                    If Err_Msg.Trim().Length > 0 Then

                        RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)

                        Exit Sub
                    End If
                End If


                RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Transaction Done Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)



                If Button1.Text <> "Update" Then
                    clear()

                End If

                End If

        End If



    End Sub





    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear()

    End Sub



    Private Sub clear()
        txtrem.Text = String.Empty
        'txtGst.Text = String.Empty
        'txtsub.Text = String.Empty
        'txtinvAmt.Text = String.Empty
        'txtrem.Text = String.Empty


    End Sub






   

    Public Sub bindGrid()

        'dt = New DataTable()
        'Dim con As New OracleConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
        'Dim adp As New OracleDataAdapter

        'If con IsNot Nothing AndAlso con.State = ConnectionState.Closed Then
        '    con.Open()
        'End If

        'adp = New OracleDataAdapter("tt.BR_ACCT_PKG.SELECT_DAYBOOKDTL", con)
        'adp.SelectCommand.CommandType = CommandType.StoredProcedure

        'adp.SelectCommand.Parameters.Add("CUR_DATASET", OracleType.Cursor).Direction = ParameterDirection.Output
        '' adp.SelectCommand.Parameters.Add("MNTH", OracleType.DateTime).Value = IIf(Convert.ToDateTime(dtExp.SelectedDate).ToString("dd-MMM-yyyy") Is Nothing, CDate(DateTime.Now.ToString("dd-MMM-yyyy")), Convert.ToDateTime(dtExp.SelectedDate).ToString("dd-MMM-yyyy"))
        'adp.SelectCommand.Parameters.Add("MNTH", OracleType.DateTime).Value = Convert.ToDateTime(dtExp.SelectedDate).ToString("dd-MMM-yyyy")

        'adp.SelectCommand.Parameters.Add("BID", OracleType.Number).Value = Convert.ToString(Request.QueryString("bid"))


        'adp.SelectCommand.Parameters.Add("MNTHSCP", OracleType.Char).Value = "C"

        'adp.SelectCommand.Parameters.Add("CDt1", OracleType.DateTime).Value = DateTime.Now
        'adp.SelectCommand.Parameters.Add("cdt2", OracleType.DateTime).Value = DateTime.Now
        'adp.Fill(dt)

        'Dim dv As DataView = dt.DefaultView
        'dv.RowFilter = "[Expense Dt]='" & CDate(dtExp.SelectedDate).ToString("dd-MMM-yyyy") & "'"

        'RadGrid1.DataSource = dv
        'con.Close()
    End Sub

   
 
    Protected Sub ddlstatus_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddlstatus.SelectedIndexChanged
        If ddlstatus.SelectedValue = "3510" Then
            extrow.Visible = True 'extend time row for developer
        Else
            extrow.Visible = False
        End If

        If ddlstatus.SelectedValue = "3508" Then
            If ViewState("tflag") <> "Y" Then
                Divrating.Visible = True
            End If
        Else
            Divrating.Visible = False
        End If

    End Sub




    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
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

    Protected Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        RadGrid1.MasterTableView.GetColumn("FID").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("FID").HeaderStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("TKID").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("TKID").HeaderStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("FILEPATH").ItemStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("FILEPATH").HeaderStyle.Width = 0



    End Sub




    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        qry = "SELECT FID, TKID,tkid TickedID, FILENAME FROM TT.SUPPORT_DOC where tkid='" & Request.QueryString("sid") & "'"
        dt = clas.getdata(qry, "QR")
        RadGrid1.DataSource = dt
    End Sub

    Protected Sub RadGrid1_PreRender(sender As Object, e As System.EventArgs) Handles RadGrid1.PreRender
        'Dim column As GridColumn = TryCast(RadGrid1.MasterTableView.GetColumnSafe("doc"), GridColumn)
        'column.OrderIndex = RadGrid1.MasterTableView.RenderColumns.Length
        'RadGrid1.MasterTableView.Rebind()
    End Sub



End Class