Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OracleClient
Imports System.Configuration
Imports System.Net.Mail

Namespace rahulcpm

    Public Class commonclass
        Dim statmsgs As String = ""

        Dim con As New OracleConnection(System.Configuration.ConfigurationManager.ConnectionStrings("constr").ToString())
        Dim cmd As New OracleCommand

        Public Function getexception() As String
            Return statmsgs
        End Function

        Public Function servermchip() As String
            Return Convert.ToString(HttpContext.Current.Request.ServerVariables("server_name"))
        End Function

        Function UppercaseFirstLetter(ByVal val As String) As String
            ' Test for nothing or empty.
            If String.IsNullOrEmpty(val) Then
                Return val
            End If

            ' Convert to character array.
            Dim array() As Char = val.ToCharArray

            ' Uppercase first character.
            array(0) = Char.ToUpper(array(0))

            ' Return new string.
            Return New String(array)
        End Function


        Public Function getdata(ByVal qry As String, ByVal type As String) As DataTable
            Try


                Dim adp As New OracleDataAdapter(qry, con)
                If type = "sp" Then
                    adp.SelectCommand.CommandType = CommandType.StoredProcedure
                Else
                    adp.SelectCommand.CommandType = CommandType.Text
                End If

                Dim dt1 As New DataTable
                adp.Fill(dt1)
                Return dt1
            Catch ex As Exception
                statmsgs = ""
                If ex.Message.Contains("TNS:listener does not currently know of service requested in connect descriptor") = True Then
                    statmsgs = ex.Message.ToString()
                ElseIf ex.Message.Contains("TNS:Connect timeout occurred") Then
                    statmsgs = ex.Message.ToString()
                Else
                    statmsgs = ex.Message.ToString()
                End If

            End Try

        End Function

        Public Function getserversdata() As DataTable
            Dim uip As String = servermchip()
            Dim str4231() As String = uip.Split(".")
            Dim ipval As String = ""
            If str4231(0) = "localhost" Then
                ipval = "127.0"
            Else
                ipval = str4231(0) & "." & str4231(1)
            End If
            Dim dt = getdata("select value,value1 from phasezero.zaconfig_clone where code in (select code1 from rahul.branch_config where ipsrs='" & ipval & "' and sts='A')", "TX")

            If dt.Rows.Count > 0 Then
                Return dt
            Else
                Dim dt1 = getdata("select value,value1 from phasezero.zaconfig_clone where code='SERVRCHN4'", "TX")
                Return dt1
            End If


        End Function

        'Public Function getdataset(ByVal qry As String, ByVal type As String) As DataSet

        '    Dim adp As New OracleDataAdapter(qry, con)

        '    If type = "sp" Then
        '        adp.SelectCommand.CommandType = CommandType.StoredProcedure
        '    Else
        '        adp.SelectCommand.CommandType = CommandType.Text
        '    End If
        '    adp.SelectCommand.Parameters.Add("refcur", OracleType.Cursor).Direction = ParameterDirection.Output
        '    adp.SelectCommand.Parameters.Add("refcur1", OracleType.Cursor).Direction = ParameterDirection.Output
        '    Dim dt1 As New DataSet
        '    adp.Fill(dt1)
        '    Return dt1
        'End Function

        Public Function ExecuteNonQuery(ByVal qry As String) As Integer
            Dim result As Integer = 0
            Try
                cmd.CommandText = qry
                cmd.Connection = con
                con.Open()
                cmd.ExecuteNonQuery()
                result = 1
                con.Close()
                cmd.Dispose()

            Catch ex As Exception
                statmsgs = ""
                con.Close()
                cmd.Dispose()
                result = 0
                statmsgs = ex.Message.ToString()
            End Try
            Return result
        End Function

        Public Function GetDate() As Date
            Dim RetDate As Nullable(Of Date) = Nothing
            Dim sql As String = "select sysdate from dual"
            Dim dt = getdata(sql, "TX")
            RetDate = dt.Rows(0)(0)
            Return RetDate
        End Function
        Public Function GetStartDate() As Date
            Dim RetDate As Nullable(Of Date) = Nothing
            Dim sql As String = "select * from system.startmnth"
            RetDate = cmd.ExecuteScalar(sql)
            Return RetDate
        End Function

        Public Function GetEndDate() As Date
            Dim RetDate As Nullable(Of Date) = Nothing
            Dim sql As String = "select * from system.endmnth"
            RetDate = cmd.ExecuteScalar(sql)
            Return RetDate
        End Function
        Public Function FirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
            Return New DateTime(sourceDate.Year, sourceDate.Month, 1)
        End Function

        'Get the last day of the month
        Public Function LastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
            Dim lastDay As DateTime = New DateTime(sourceDate.Year, sourceDate.Month, 1)
            Return lastDay.AddMonths(1).AddDays(-1)
        End Function

        Public Function getMaxID(ByVal qry As String) As Int32
            Dim mytable As New DataTable
            Dim da As New OracleDataAdapter(qry, con)
            da.Fill(mytable)
            Return mytable.Rows(0)(0)
        End Function
        Public Function ExecuteScalar(ByVal CommandText As String) As String
            Dim result As String = ""
            Try
                cmd.CommandText = CommandText
                cmd.Connection = con
                con.Open()
                If cmd.ExecuteScalar() IsNot DBNull.Value Then
                    result = cmd.ExecuteScalar()
                End If
                con.Close()
            Catch ex As Exception
                statmsgs = ""
                con.Close()
                cmd.Dispose()
                result = 0
                statmsgs = ex.Message.ToString()
            End Try
            Return result
        End Function


        Public Function sendmail(ByVal subject As String, ByVal body As String, ByVal toeml As String) As Int32

            Try
                Dim objmail As MailMessage = New MailMessage("techsupport@wwicsgroup.com", toeml)
                objmail.Bcc.Add("anuj@wwicsgroup.com")
                objmail.Bcc.Add("rahul.gupta@pinnacleinfoedge.com")
                'objmail.Bcc.Add("anuj@wwicsgroup.com")
                objmail.Subject = subject
                objmail.IsBodyHtml = True
                objmail.Priority = MailPriority.High
                objmail.Body = body
                Dim objsent As SmtpClient = New SmtpClient("121.0.0.219")
                objsent.UseDefaultCredentials = True
                objsent.Credentials = New System.Net.NetworkCredential("salesinfo@wwicsgroup.com", "sales123")
                objsent.Send(objmail)
                Return 1
            Catch ex As Exception
                statmsgs = ""
                statmsgs = ex.Message.ToString()
                Return 0
            End Try

        End Function


        Public Function maillog(ByVal fileno As String, ByVal fsn As String, ByVal mailby As String, ByVal mailfrm As String, ByVal mailsub As String, ByVal mailto As String, ByVal path As String, ByVal tmp As String) As Int32
            Dim logid = getMaxID("Select nvl(max(id),0)+1 as ID from rahul.cpm_maillogs")
            Try
                ExecuteNonQuery("insert into rahul.CPM_MAILLOGS(fileno,fsn,mailby,mailto,mailfrm,mailsub,mailatch,mailon,id,mailmode,mailpath,temppth) values('" & fileno & "','" & fsn & "','" & mailby & "','" & mailto & "','" & mailfrm & "','" & mailsub & "','N',sysdate,'" & logid & "','S','" & path & "','" & tmp & "')")
                Return 1
            Catch ex As Exception
                statmsgs = ""
                statmsgs = ex.Message.ToString()
                Return 0
            End Try
        End Function

        Public Function maillogadmin(ByVal fileno As String, ByVal fsn As String, ByVal mailsub As String, ByVal mailto As String, ByVal path As String, ByVal tmp As String) As Int32
            Dim logid = getMaxID("Select nvl(max(id),0)+1 as ID from rahul.cpm_maillogs")
            Try
                ExecuteNonQuery("insert into rahul.CPM_MAILLOGS(fileno,fsn,mailby,mailto,mailfrm,mailsub,mailatch,mailon,id,mailmode,mailpath,temppth) values('" & fileno & "','" & fsn & "','159','" & mailto & "','salesinfo@wwicsgroup.com','" & mailsub & "','N',sysdate,'" & logid & "','S','" & path & "','" & tmp & "')")
                Return 1
            Catch ex As Exception
                statmsgs = ""
                statmsgs = ex.Message.ToString()
                Return 0
            End Try
        End Function

        Public Function sendmessage1(ByVal text As String, ByVal mbl As String, ByVal empno As String, ByVal zbaid As String) As Int32
            Try
                ExecuteNonQuery("insert into webbranch.mobile_xml(TRANSID,MOBILE,TEXT,CREATIONDT,BROADCASTDATE,CREATEDBY,KEYEDON,CLI,CATEGORY,BRANCH,SMS_SCP) values('0','" & mbl & "','" & text.Replace("'", "") & "',sysdate,sysdate,'" & empno & "',sysdate,'WWICSG','3','" & zbaid & "',1)")
                Return 1
            Catch ex As Exception
                statmsgs = ""
                statmsgs = ex.Message.ToString()
                Return 0
            End Try
        End Function

        Public Function sendmessage(ByVal text As String, ByVal mbl As String) As Int32
            Try
                ExecuteNonQuery("insert into webbranch.mobile_xml(TRANSID,MOBILE,TEXT,CREATIONDT,BROADCASTDATE,CREATEDBY,KEYEDON,CLI,CATEGORY,BRANCH,SMS_SCP) values('0','" & mbl & "','" & text.Replace("'", "") & "',sysdate,sysdate,'159',sysdate,'WWICSG','3','119',1)")
                Return 1
            Catch ex As Exception
                statmsgs = ""
                statmsgs = ex.Message.ToString()
                Return 0
            End Try
        End Function


    End Class



End Namespace