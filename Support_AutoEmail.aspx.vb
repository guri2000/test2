Imports System.Net.Mail
Imports System.Data.OracleClient
Imports System.Data

Partial Class Support_AutoEmail
    Inherits System.Web.UI.Page
    Dim con As New OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings("constr").ToString)
    Dim _DataTable As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim Get_Status_Qry As String = ""
        Dim SqlQry

        SqlQry = "select Support_ID, Module,Process,Name AssignTo,status,assigndate,expenddt,round(Surplus,2)  Surplushrs from ( select ticketid, to_char(keyedin,'ssyydd/mm')||TICKETID||'/M'||submodule"
        SqlQry += " Support_ID,assignto,(select statdescr from tt.ipdocstatus where scope=3505 and statcd=status) status,b.name,(select modulename from TT.support_module where id=MODULEID) Module, (select (submod_descr) from tt.support_submodmast where subid=SUBMODULE) Process, to_char(assigndate,'DD-Mon-yyyy hh24:mi')assigndate ,to_char(EXPENDDT,'DD-Mon-yyyy hh24:mi')EXPENDDT ,"
        SqlQry += "(EXPENDDT-assigndate)*24 as TAT_Hrs, to_char(assigndate + ((EXPENDDT-assigndate)* 0.8),'DD-Mon-yyyy hh24:mi' ) clsoetime,(sysdate-expenddt)*24 Surplus from tt.support_ticket a,tt.employees"
        SqlQry += " b where status not in (3508,3509,3503) and a.assignto=b.empno) where sysdate>to_date(clsoetime,'DD-Mon-yyyy hh24:mi') order by Surplushrs desc"

        'SqlQry = "  select to_char(keyedin,'ssyydd/mm')||TICKETID||'/M'||submodule Support_ID, (select modulename from TT.support_module where id=MODULEID) Module,(select (submod_descr) from tt.support_submodmast where subid=SUBMODULE) Process,'Not Assigned'  AssignTo, (select statdescr from tt.ipdocstatus where scope=3505 and statcd=status) status,null assigndate, null expenddt,null Surplushrs from tt.support_ticket where status=3500 and assignto is null "
   
        Email_HTML(SqlQry, "1")
        SqlQry = ""
        SqlQry = "  select to_char(keyedin,'ssyydd/mm')||TICKETID||'/M'||submodule Support_ID, (select modulename from TT.support_module where id=MODULEID) Module,(select (submod_descr) from tt.support_submodmast where subid=SUBMODULE) Process,'Not Assigned'  AssignTo, (select statdescr from tt.ipdocstatus where scope=3505 and statcd=status) status  from tt.support_ticket where status=3500 and assignto is null "
        Email_HTML(SqlQry, "2")

        lbl1.Text = "Support Escalation mail sent on " & DateTime.Now & " Total Email Sent " & ViewState("cnt")


    End Sub

    Protected Function Get_DataTable(ByVal qry As String) As DataTable
        Dim adp As New OracleDataAdapter(qry, con)
        adp.SelectCommand.CommandType = CommandType.Text
        Dim dt1 As New DataTable
        adp.Fill(dt1)
        Return dt1
    End Function

    Public Sub Email_HTML(ByVal SqlQuery As String, sts As String)

        _DataTable = Get_DataTable(SqlQuery)

        ViewState("cnt") = _DataTable.Rows.Count

        If _DataTable.Rows.Count > 0 Then
            Dim Mail_Body As String = ""


            Dim Mail_Str As StringBuilder = New StringBuilder
            Dim Mail_Str2 As StringBuilder = New StringBuilder
            'Mail_Str.Append("<html><head></head><title></title>")
            'Mail_Str.Append("<body style='font-size:14px;font-family:Times New Roman;'>")
            If _DataTable.Rows.Count = 0 Then
                Exit Sub
            End If
            Mail_Str.Append("<p><b> Date: </b>" & DateTime.Now & " </p>   <br>")

            If sts = "1" Then
                Mail_Str.Append("<table width=80% style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify;>")
                Mail_Str.Append("<tr>")
                Mail_Str.Append(" <td style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify; padding-left:41px;>")
                Mail_Str.Append("Pending tickets which have consumed more than 80% of allotted time.")
                Mail_Str.Append(" </td>")
                Mail_Str.Append(" </tr>")
                Mail_Str.Append(" <tr>")
            Else
                Mail_Str.Append("<table width=80% style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify;>")
                Mail_Str.Append("<tr>")
                Mail_Str.Append(" <td style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify; padding-left:41px;>")
                Mail_Str.Append("Unallotted Pending tickets.")
                Mail_Str.Append(" </td>")
                Mail_Str.Append(" </tr>")
                Mail_Str.Append(" <tr>")

            End If
      

            Mail_Str.Append("<table border=1 style=font-size:12px; line-height:16px; color:#333; font-family:Arial, Helvetica, sans-serif; text-align:justify;>")


            Mail_Str.Append("<tr>")
            For i As Integer = 0 To _DataTable.Columns.Count - 1
                Mail_Str.Append("<td><b>")
                Mail_Str.Append(_DataTable.Columns(i).ColumnName)
                Mail_Str.Append("</b></td>")
            Next
            Mail_Str.Append("</tr>")

            Mail_Str2.Append(Mail_Str)

            For a = 0 To _DataTable.Rows.Count - 1

                Mail_Str2.Append("<tr>")
                For i As Integer = 0 To _DataTable.Columns.Count - 1
                    Mail_Str2.Append("<td>")
                    Mail_Str2.Append(_DataTable.Rows(a)(i).ToString)
                    Mail_Str2.Append("</td>")
                Next
                If (a = 10 Or a = 20 Or a = 30 Or a = 40 Or a = 50 Or a = 60 Or a = 70 Or a = 80 Or a = 90 Or a = 100) Then
                    Mail_Str2.Append("</tr>")
                    Mail_Str2.Append("</table> ")
                    Mail_Str2.Append("</tr>")
                    Mail_Str2.Append("</table>")
                    '  Mail_Str.Append(Mail_Str2)
                    Mail_Body = Mail_Str2.ToString
                    Mail_Body = Mail_Body.Replace("'", "''")
                    Insert_Qry_Automail(Mail_Body)
                    Mail_Str2.Clear()
                    Mail_Str2.Append(Mail_Str)
                End If

            Next
            Mail_Str2.Append("</tr>")
            Mail_Str2.Append("</table> ")
            Mail_Str2.Append("</tr>")
            Mail_Str2.Append("</table>")

         
            Mail_Body = Mail_Str2.ToString
            Mail_Body = Mail_Body.Replace("'", "''")
            Insert_Qry_Automail(Mail_Body)
        End If

    End Sub


    Protected Sub Insert_Qry_Automail(ByVal BodyStr As String)
        Dim Auto_Qry As String = "insert into rahul.autoemail "
        Auto_Qry += " ( ID,MAILSUB,MAILTO,MAILINT,MAILFRM,MAILBCC,MAILCC,MAILRPLYTO,DEPT,PRSN,BODYSTT,BODYTEMP"
        Auto_Qry += " ,MAILATCH,MAILSNDON,STATUS,KEYEDON,ACTSNDON,REMARKS )"
        Auto_Qry += " values ("
        Auto_Qry += " rahul.automail_seq.nextval,'Support Ticket Escalation Mail ' ,'itdept@wwicsgroup.com',"
        Auto_Qry += " 'Support Ticket Escalation ','DoNotReply@wwicsgroup.com','','',null,null,null,"
        Auto_Qry += " '" & BodyStr & "',null,null,sysdate,'I',sysdate,null,null)"
        Dim cmd As New OracleCommand(Auto_Qry, con)
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub

End Class
