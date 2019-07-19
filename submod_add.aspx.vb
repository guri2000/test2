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
            'filldll()
            'Empno = Convert.ToString(Request.QueryString("empno"))

            'If Convert.ToString(Request.QueryString("empno")) = "" Or Convert.ToString(Request.QueryString("bid")) = "" Then
            '    RadWindowManager1.RadAlert("<ul><li><div style=color:Red;>Seesion expired retry.</div></li></ul>", 300, 150, "Validation Error", Nothing)
            '    ImageButton1.Enabled = False
            '    Button2.Enabled = False

            '    Exit Sub
            'Else


            'End If

            'If Convert.ToString(Request.QueryString("typ")) = "edit" Then
            '    ' fillRecord()
            'Else


            'End If

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



        If txtmod.Text <> "" Then
            txtmod.Text = txtmod.Text.Replace("'", "").Replace("""", "").Replace("%", "").Replace("+", "").Replace("&", "")
        End If

      


        Dim i As Int32


        Dim str As StringBuilder = New StringBuilder


     



        If Button1.Text = "Update" Then

            'str.Append(" update TT.SUPPORT_COMMENT  set PARTYID='" & ddlParty.SelectedValue & "',APPDATE= '" & appdt & "',EXPHEADID= '" & ddlExpe.SelectedValue & "',EXPDATE= '" & expdt & "',INVDT= '" & invdt & "',INVAMT='" & txtinvAmt.Text.Trim & "',RECTDATE= '" & recdt & "',Paydt= '" & paydt & "',PARTYGSTNO='" & txtGst.Text.Trim & "',PAYSTATUS='" & paystatus & "',LASTUPDATEBY='" & Convert.ToString(Request.QueryString("empno")) & "',LASTUPDATEON=sysdate,remarks='" & txtrem.Text & "',TRNSCURR='" & curr & "' ,sub='" & txtsub.Text & "', catid='" & ddlImm.SelectedValue & "'")
            'str.Append(" where BRTRID= " & Convert.ToString(Request.QueryString("tid")))

        Else


            qry = "insert into TT.SUPPORT_SUBMODMAST ( subid,MODULEID,SUBMOD_DESCR, SUBMDSTATUS ) values(tt.support_doc_seq.nextval , '" & Request.QueryString("modid") & "','" & txtmod.Text & "','A' )"
                        Dim J = clas.ExecuteNonQuery(qry.ToString())
                        If J = 1 Then
                RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Transaction done successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)

                        Else

                            Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                            Err_Msg = Err_Msg.Replace(vbCr, "")
                            Err_Msg = Err_Msg.Replace(vbLf, "")
                            RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                            'Exit Sub
                        End If



        End If







    End Sub





    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear()

    End Sub



    Private Sub clear()
        txtmod.Text = String.Empty
    End Sub




  

End Class