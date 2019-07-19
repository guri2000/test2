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
    Dim chk As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then

            If Convert.ToString(Request.QueryString("empno")) = "" Or Convert.ToString(Request.QueryString("bid")) = "" Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Seesion expired retry.</div></li></ul>", 300, 150, "Validation Error", Nothing)
                lnkadd.Visible = False
                RadGrid1.Enabled = False

                Exit Sub
            End If
            filldll()

        End If
        lnkadd.Attributes.Add("href", "support_add.aspx?empno=" & Convert.ToString(Request.QueryString("empno")) & "&bid=" & Convert.ToString(Request.QueryString("bid")))

 
    End Sub


    Private Sub filldll()


        '  qry = "select a.TECHSPFLG,b.deptcode from  tt.user_master a,tt.employees b where a.empno=b.empno(+) and a.empno='" & Convert.ToString(Request.QueryString("empno")) & "'"
        qry = "select TECHSPFLG  from tt.user_master   where empno='" & Convert.ToString(Request.QueryString("empno")) & "'"
        dt = clas.getdata(qry, "tt")
        Dim dt1 As New DataTable
        dt1 = clas.getdata("  select deptcode from  tt.employees  where empno='" & Convert.ToString(Request.QueryString("empno")) & "'", "tt")
        If dt.Rows.Count > 0 Then
            If (Convert.ToString(dt.Rows(0)("TECHSPFLG"))) = "Y" Then
                ViewState("tflag") = Convert.ToString(dt.Rows(0)("TECHSPFLG"))
                ViewState("deptcode") = Convert.ToString(dt1.Rows(0)("deptcode"))

            Else

                ViewState("tflag") = "N"
                ViewState("deptcode") = Convert.ToString(dt1.Rows(0)("deptcode"))
            End If
        Else

            ViewState("tflag") = "N"
            If dt1.Rows.Count > 0 Then
                ViewState("deptcode") = Convert.ToString(dt1.Rows(0)("deptcode"))
            End If

            End If

            qry = "select statcd id ,statdescr Description from tt.ipdocstatus where scope=3505 and active='Y' "
            dt = clas.getdata(qry, "tt")

            bindfromdt(ddlsta, "", dt, "", "Description", "id", "dropdown", True)


    End Sub


    Protected Sub RadGrid1_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid1.ItemDataBound
        RadGrid1.MasterTableView.GetColumn("MODULEID").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("MODULEID").HeaderStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("STATUSid").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("STATUSid").HeaderStyle.Width = 0

        RadGrid1.MasterTableView.GetColumn("TICKETRAISEDBYid").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("TICKETRAISEDBYid").HeaderStyle.Width = 0

        RadGrid1.MasterTableView.GetColumn("ACKBYid").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("ACKBYid").HeaderStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("ASSIGNTOid").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("ASSIGNTOid").HeaderStyle.Width = 0


        RadGrid1.MasterTableView.GetColumn("TICKETID").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("TICKETID").HeaderStyle.Width = 0


        RadGrid1.MasterTableView.GetColumn("STARRATING").ItemStyle.Width = 0
        RadGrid1.MasterTableView.GetColumn("STARRATING").HeaderStyle.Width = 0




        '  RadGrid1.MasterTableView.GetColumn("BRANCHID").ItemStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("BRANCHID").HeaderStyle.Width = 0

        'RadGrid1.MasterTableView.GetColumn("PARTYID").ItemStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("PARTYID").HeaderStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("TRNSTATUS").ItemStyle.Width = 0
        'RadGrid1.MasterTableView.GetColumn("TRNSTATUS").HeaderStyle.Width = 0


        ''     RadGrid1.MasterTableView.GetColumn("FWDTOLAW").Visible = False
        ''RadGrid1.MasterTableView.GetColumn("stage_id").Visible = False


        If (TypeOf e.Item Is GridDataItem) Then
            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)

            Dim btnico As LinkButton = DirectCast(item.FindControl("lnkdownload"), LinkButton)

            Dim btnedit As LinkButton = DirectCast(item.FindControl("lnkedit"), LinkButton)
            Dim btncomm As LinkButton = DirectCast(item.FindControl("lnkcomm"), LinkButton)

            Dim btnview As LinkButton = DirectCast(item.FindControl("lnkview"), LinkButton)

            Dim btnrating As RadRating = DirectCast(item.FindControl("RadRating1"), RadRating)

            Dim btnindicator As ImageButton = DirectCast(item.FindControl("lnkindicator"), ImageButton)
            Dim commandItem As GridCommandItem = DirectCast(RadGrid1.MasterTableView.GetItems(GridItemType.CommandItem)(0), GridCommandItem)
            Dim CommandLabel As Label = DirectCast(commandItem.FindControl("lblcnt"), Label)
            CommandLabel.Text = RadGrid1.MasterTableView.Items.Count + 1


            'If btnrating.Value > 3 Then
            '    btnrating.Attributes.Add("color", "red")
            'Else

            'End If

            btnedit.Attributes.Add("href", "support_add.aspx?typ=edit&sid=" + Convert.ToString(item.GetDataKeyValue("TICKETID")) + "&empno=" + Convert.ToString(Request.QueryString("empno")) + "&bid=" + Convert.ToString(Request.QueryString("bid")))
            btnico.Attributes.Add("href", "support_doc.aspx?src=1&sid=" + Convert.ToString(item.GetDataKeyValue("TICKETID")) + "&empno=" + Convert.ToString(Request.QueryString("empno")) + "&bid=" + Convert.ToString(Request.QueryString("bid")))
            btncomm.Attributes.Add("href", " support_comments.aspx?sid=" + Convert.ToString(item.GetDataKeyValue("TICKETID")) + "&empno=" + Convert.ToString(Request.QueryString("empno")) + "&bid=" + Convert.ToString(Request.QueryString("bid")))



            btnview.Attributes.Add("href", " support_view.aspx?sid=" + Convert.ToString(item.GetDataKeyValue("TICKETID")) + "&empno=" + Convert.ToString(Request.QueryString("empno")) + "&bid=" + Convert.ToString(Request.QueryString("bid")) + "&supid=" + Convert.ToString(item("Support ID").Text))

            If ViewState("tflag") = "Y" Then
                btnedit.Visible = True
            Else
                btnedit.Visible = False
            End If

            If item("STATUSid").Text = "3508" Then
                btncomm.Visible = True
                If ViewState("tflag") <> "Y" Then
                    btnico.Visible = False
                End If

                If item("STARRATING").Text > 0 And ViewState("tflag") <> "Y" Then
                    btncomm.Visible = False
                End If

            Else

                If ViewState("deptcode") = "15" Then


                Else
                    btncomm.Style.Add("opacity", "0")
                    btncomm.Attributes.Add("href", "#")
                    btncomm.Enabled = False
                    btncomm.Style.Add("cursor", "auto")

                End If

            End If

            btnindicator.Attributes.Add("title", item("Status").Text)

            If item("STATUSid").Text = "3510" Then 'TAT
                btnindicator.Attributes.Add("src", "images\icons\bullet_red.png")
            ElseIf item("STATUSid").Text = "3509" Then 'Deleiverable
                btnindicator.Attributes.Add("src", "images\icons\bullet_orange.png")
            ElseIf item("STATUSid").Text = "3508" Then 'Closed
                btnindicator.Attributes.Add("src", "images\icons\bullet_green.png")
            ElseIf item("STATUSid").Text = "3507" Then 'Reopen
                btnindicator.Attributes.Add("src", "images\icons\bullet_red.png")
            ElseIf item("STATUSid").Text = "3505" Then 'assign
                btnindicator.Attributes.Add("src", "images\icons\bullet_yellow.png")
            ElseIf item("STATUSid").Text = "3506" Then 'Re-assign
                btnindicator.Attributes.Add("src", "images\icons\bullet_pink.png")
            ElseIf item("STATUSid").Text = "3500" Then 'initiated
                btnindicator.Attributes.Add("src", "images\icons\bullet_black.png")
            Else
                btnindicator.Attributes.Add("src", "images\icons\bullet_blue.png")
            End If


            For Each cell As TableCell In e.Item.Cells
                cell.Attributes.Add("title", cell.Text)
            Next


            '    item.Cells(7).ToolTip = "Date at which expenditure is made"
            '    item.Cells(8).ToolTip = "Selected category out of Skilled/Business/Education"
            '    item.Cells(9).ToolTip = "Type of expenditure created by user"
            '    item.Cells(10).ToolTip = "Expenditure  amount"
            '    item.Cells(11).ToolTip = "Short Description"
            '    item.Cells(12).ToolTip = "Name of third party vendor"
            '    item.Cells(13).ToolTip = "Date at which approval is received"
            '    item.Cells(14).ToolTip = "Date at which invoice is created"
            '    item.Cells(15).ToolTip = "Date at which receipt is created"
            '    item.Cells(16).ToolTip = "Date at which payment is made"
            '    item.Cells(17).ToolTip = "Status of payment"

            '    item.Cells(18).ToolTip = "Date at which entry is keyedin"
            '    item.Cells(19).ToolTip = "Name of the person who has created the entry"
            '    item.Cells(20).ToolTip = "Good and Services Tax No"
            '    item.Cells(21).ToolTip = "Remarks"


        End If


    End Sub



    Protected Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        bindGrid()
        summary()

    End Sub



    Public Sub bindGrid()
        If Convert.ToString(Request.QueryString("empno")) = "" Then
            Exit Sub
        End If

        dt = New DataTable()
        Dim con As New OracleConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
        Dim adp As New OracleDataAdapter

        If con IsNot Nothing AndAlso con.State = ConnectionState.Closed Then
            con.Open()
        End If

        adp = New OracleDataAdapter("tt.SUPPORT_PKG.select_Rec", con)
        adp.SelectCommand.CommandType = CommandType.StoredProcedure

        adp.SelectCommand.Parameters.Add("CUR_DATASET", OracleType.Cursor).Direction = ParameterDirection.Output

        'adp.SelectCommand.Parameters.Add("MNTH", OracleType.DateTime).Value = RadMonthYearPicker1.SelectedDate
        adp.SelectCommand.Parameters.Add("TICKETID", OracleType.Number).Value = 0

        adp.Fill(dt)
        RadGrid1.DataSource = dt

        'If Convert.ToString(Request.QueryString("empno")) = "159" Then
        '    RadGrid1.DataSource = dt
        'Else

        If ViewState("deptcode") = "15" And ViewState("tflag") = "Y" Then
            Dim dataView As DataView = dt.DefaultView
            If ddlsta.SelectedValue <> "" Then

                DataView.RowFilter = "statusid='" & ddlsta.SelectedValue & "'"
                RadGrid1.DataSource = DataView
                RadGrid1.DataSource = dt
            Else
                DataView.RowFilter = "statusid <> 3508 "
                RadGrid1.DataSource = DataView
                RadGrid1.DataSource = dt
            End If

        ElseIf ViewState("deptcode") = "15" Then
            Dim dataView As DataView = dt.DefaultView

            If ddlsta.SelectedValue <> "" Then

                dataView.RowFilter = "(ASSIGNTOid='" & Convert.ToString(Request.QueryString("empno")) & "' or  TICKETRAISEDBYID='" & Convert.ToString(Request.QueryString("empno")) & "') and statusid='" & ddlsta.SelectedValue & "'"
            Else
                dataView.RowFilter = "(ASSIGNTOid='" & Convert.ToString(Request.QueryString("empno")) & "' or  TICKETRAISEDBYID='" & Convert.ToString(Request.QueryString("empno")) & "') and statusid<>3508"
            End If


            RadGrid1.DataSource = dataView
        Else
            Dim dataView As DataView = dt.DefaultView
            If ddlsta.SelectedValue <> "" Then
                dataView.RowFilter = "(TICKETRAISEDBYID='" & Convert.ToString(Request.QueryString("empno")) & "' and statusid='" & ddlsta.SelectedValue & "') "
            Else
                dataView.RowFilter = "TICKETRAISEDBYID='" & Convert.ToString(Request.QueryString("empno")) & "' and statusid<>3508"
            End If
            RadGrid1.DataSource = dataView
        End If





        con.Close()

    End Sub



    Protected Sub RadGrid1_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid1.ItemCommand
        If e.CommandName = "Filter" Then

        ElseIf e.CommandName = "Rebind" Then

            RadGrid1.Rebind()

        ElseIf e.CommandName = "revoke" Then

            Dim item As GridDataItem = DirectCast(e.Item, GridDataItem)
            qry = "update TT.support_ticket set active='N',LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate where TICKETID='" & item.GetDataKeyValue("TICKETID") & "'"

            Dim i = clas.ExecuteNonQuery(qry)
            If i = 0 Then

                Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                Err_Msg = Err_Msg.Replace(vbCr, "")
                Err_Msg = Err_Msg.Replace(vbLf, "")

                If Err_Msg.Trim().Length > 0 Then

                    RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)

                    Exit Sub
                End If

            Else
                '  lnk.Attributes.Add("href", "daybook_doc.aspx?tid=" & tid)
                RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Revoked Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                RadGrid1.Rebind()

            End If

        ElseIf e.CommandName = "export" Then
            If RadGrid1.MasterTableView.Items.Count > 0 Then
                RadGrid1.ExportSettings.ExportOnlyData = True
                RadGrid1.ExportSettings.IgnorePaging = True
                RadGrid1.ExportSettings.OpenInNewWindow = True
                Dim caption As String = "Summary Sheet  "
                RadGrid1.MasterTableView.Caption = caption & " on " & Date.Now.ToString("dd-MMM-yyyy HH:mm:ss")
                RadGrid1.ExportSettings.FileName = caption.Replace(" ", "_") & "_on_" & Date.Now.ToString("dd-MMM-yyyy HH:mm:ss")
                RadGrid1.MasterTableView.ExportToExcel()

            End If
        End If
    End Sub

    Protected Sub RadGrid1_PreRender(sender As Object, e As System.EventArgs) Handles RadGrid1.PreRender
        If Page.IsPostBack = False Then
            Dim column As GridColumn = TryCast(RadGrid1.MasterTableView.GetColumnSafe("vwcmn"), GridColumn)
            Dim column1 As GridColumn = TryCast(RadGrid1.MasterTableView.GetColumnSafe("Rating"), GridColumn)
            column.OrderIndex = RadGrid1.MasterTableView.RenderColumns.Length - 1
            column1.OrderIndex = RadGrid1.MasterTableView.RenderColumns.Length - 7
            RadGrid1.MasterTableView.Rebind()
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



    Private Sub binddates()
        'Dim dt1 As Date
        'Dim sdt As Date
        'Dim edt As Date

        'RadDatePicker1.SelectedDate = Nothing
        'RadDatePicker2.SelectedDate = Nothing


        'dt1 = RadMonthYearPicker1.SelectedDate.ToString()
        'edt = New DateTime(dt1.Year, dt1.Month, 1).AddMonths(1).AddDays(-1)

        'If ddlcal.SelectedValue = "C" Then
        '    sdt = New DateTime(dt1.Year, dt1.Month, 1)
        'Else
        '    sdt = New DateTime(dt1.Year, dt1.Month, 1).AddMonths(-1)
        'End If


        'RadDatePicker1.MinDate = sdt
        'RadDatePicker2.MinDate = sdt

        'RadDatePicker1.MaxDate = edt
        'RadDatePicker2.MaxDate = edt

    End Sub


    Protected Sub btngo_Click(sender As Object, e As System.EventArgs) Handles btngo.Click
        RadGrid1.Rebind()
    End Sub

    Private Sub summary()
        Dim con As New OracleConnection(ConfigurationManager.ConnectionStrings("constr").ConnectionString)
        Dim adp As New OracleDataAdapter
        Dim dt1 As New DataTable
        If con IsNot Nothing AndAlso con.State = ConnectionState.Closed Then
            con.Open()
        End If


        adp = New OracleDataAdapter("tt.SUPPORT_PKG.select_summary", con)
        adp.SelectCommand.CommandType = CommandType.StoredProcedure

        If ViewState("deptcode") = "15" And ViewState("tflag") = "Y" Then

            adp.SelectCommand.Parameters.Add("CUR_DATASET", OracleType.Cursor).Direction = ParameterDirection.Output
            adp.SelectCommand.Parameters.Add("empno", OracleType.Number).Value = Convert.ToString(Request.QueryString("empno"))
            adp.SelectCommand.Parameters.Add("typ", OracleType.Char).Value = "S"
            adp.Fill(dt1)
        ElseIf ViewState("deptcode") = "15" Then
            adp.SelectCommand.Parameters.Add("CUR_DATASET", OracleType.Cursor).Direction = ParameterDirection.Output
            adp.SelectCommand.Parameters.Add("empno", OracleType.Number).Value = Convert.ToString(Request.QueryString("empno"))
            adp.SelectCommand.Parameters.Add("typ", OracleType.Char).Value = "D"
            adp.Fill(dt1)
        Else
            adp.SelectCommand.Parameters.Add("CUR_DATASET", OracleType.Cursor).Direction = ParameterDirection.Output
            adp.SelectCommand.Parameters.Add("empno", OracleType.Number).Value = Convert.ToString(Request.QueryString("empno"))
            adp.SelectCommand.Parameters.Add("typ", OracleType.Char).Value = "U"
            adp.Fill(dt1)

        End If

        For Each dr As DataRow In dt1.Rows
            If dr("statusid") = "3500" Then
                lbl3500.Text = dr("count")
            ElseIf dr("statusid") = "3501" Then
                lbl3501.Text = dr("count")
            ElseIf dr("statusid") = "3502" Then
                lbl3502.Text = dr("count")

            ElseIf dr("statusid") = "3505" Then
                lbl3505.Text = dr("count")
            ElseIf dr("statusid") = "3506" Then
                lbl3506.Text = dr("count")
            ElseIf dr("statusid") = "3507" Then
                lbl3507.Text = dr("count")
            ElseIf dr("statusid") = "3508" Then
                LBL3508.Text = dr("count")

            ElseIf dr("statusid") = "3509" Then
                lbl3509.Text = dr("count")
            ElseIf dr("statusid") = "3510" Then
                lbl3510.Text = dr("count")

            End If
        Next

    End Sub


    Protected Sub SetStatus(sender As Object, e As System.EventArgs) Handles lbl3500.Click, lbl3501.Click, lbl3502.Click, lbl3505.Click, lbl3506.Click, lbl3507.Click, LBL3508.Click, lbl3509.Click, lbl3510.Click

        Dim btn As LinkButton = sender

        If ddlsta.Items.FindByValue(btn.CommandArgument) IsNot Nothing Then
            ddlsta.ClearSelection()
            ddlsta.Items.FindByValue(btn.CommandArgument).Selected = True
        End If
        RadGrid1.Rebind()


    End Sub
End Class

