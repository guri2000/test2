Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Services
Imports System.Web.Script.Services
'using System.Collections.Generic;
Imports System.IO
Imports System.Text
Imports System.Data
Imports System.Data.OracleClient
Imports System.Configuration
Imports System.Web.UI.WebControls
Imports System.Text.RegularExpressions
Imports System.Net

'Imports System.Web.UI.DataVisualization.Charting
''' <summary>
''' Class Added by Rohit 
''' </summary>
''' 

Namespace WWICS

    Public Class Pinnacle

        Private Shared con As OracleConnection

        Private Shared cmd As OracleCommand

        Private Shared adp As OracleDataAdapter

        Private Shared conStr As String = ConfigurationManager.ConnectionStrings("constr").ConnectionString

#Region "Data"

        Public Shared Function getDataTable(ByVal strSql As String) As DataTable
            Dim dt As DataTable = New DataTable
            Try
                adp = New OracleDataAdapter(strSql, conStr)
                adp.Fill(dt)
            Catch ex As Exception
                Return dt
            Finally
                adp.Dispose()
            End Try

            Return dt
        End Function
        Public Shared Function excecuteNonQuery(ByVal procedureName As String, ByVal coll() As OracleParameter) As String
            Dim res As String = ""
            Try


                con = New OracleConnection(conStr)
                'OracleParameterCollection col = new OracleParameterCollection();
                'col = coll;
                If (con.State = ConnectionState.Closed) Then
                    con.Open()
                End If

                cmd = New OracleCommand(procedureName, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddRange(coll)
                'cmd.Parameters.AddRange(coll.ToArray());
                res = Convert.ToString(cmd.ExecuteNonQuery)

                
            Catch ex As Exception
                res = ex.Message.Replace("" & vbLf, "")
                Return res
            Finally
                If (Not (cmd) Is Nothing) Then
                    cmd.Dispose()
                End If

                If (con.State = ConnectionState.Open) Then
                    con.Close()
                End If

            End Try

            Return res
        End Function
        Public Shared Function getDataTable(ByVal procedureName As String, ByVal coll() As OracleParameter) As DataTable
            Dim tbl As New DataTable
            Try
                con = New OracleConnection(conStr)
                'OracleParameterCollection col = new OracleParameterCollection();
                'col = coll;
                If (con.State = ConnectionState.Closed) Then
                    con.Open()
                End If

                cmd = New OracleCommand(procedureName, con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddRange(coll)
                adp = New OracleDataAdapter(cmd)
                adp.Fill(tbl)
            Catch ex As Exception
                Return tbl
            Finally
                If (Not (cmd) Is Nothing) Then
                    cmd.Dispose()
                End If

                If (con.State = ConnectionState.Open) Then
                    con.Close()
                End If

            End Try

            Return tbl
        End Function
        Public Shared Function showMessage(ByVal message As String, ByVal owner As Control, ByVal hidePopup As Boolean, ByVal refreshParent As Boolean)
            Dim page As Page = TryCast(owner, Page)
            If page Is Nothing Then
                'Exit Function
            End If
            Dim str = "alert('" + message + "');"
            If (hidePopup = True) Then
                str += "parent.$.fancybox.close();"
            End If
            If (refreshParent = True) Then
                str += "parent.window.location.reload(true);"
            End If
            page.ClientScript.RegisterStartupScript(page.GetType(), "AlertMessageBox", str, True)
            'page.ClientScript.RegisterStartupScript(page.GetType(), "Message", "<script type='text/javascript'>" + message + "</script>", False)
        End Function
        Public Shared Function getDataSet(ByVal strSql As String) As DataSet
            Dim ds As DataSet = New DataSet
            Try
                adp = New OracleDataAdapter(strSql, conStr)
                adp.Fill(ds)
            Catch ex As Exception
                Return ds
            Finally
                adp.Dispose()
            End Try

            Return ds
        End Function

        Public Shared Sub bindListBox(ByVal strSql As String, ByVal lst As ListBox)
            Dim dt As DataTable = New DataTable
            Try
                adp = New OracleDataAdapter(strSql, conStr)
                adp.Fill(dt)
                lst.DataValueField = dt.Columns(0).ColumnName.ToString
                lst.DataTextField = dt.Columns(1).ColumnName.ToString
                lst.DataSource = dt
                lst.DataBind()
            Catch ex As Exception

            Finally
                adp.Dispose()
            End Try

        End Sub

        Public Overloads Shared Sub bindDDL(ByVal strSql As String, ByVal ddl As DropDownList)
            Dim dt As DataTable = New DataTable
            Try
                adp = New OracleDataAdapter(strSql, conStr)
                adp.Fill(dt)
                ddl.DataValueField = dt.Columns(0).ColumnName.ToString
                ddl.DataTextField = dt.Columns(1).ColumnName.ToString
                ddl.DataSource = dt
                ddl.DataBind()
                ddl.Items.Insert(0, New ListItem("Select", "-1"))
            Catch ex As Exception

            Finally
                adp.Dispose()
            End Try

        End Sub

        Public Overloads Shared Sub bindDDL(ByVal strSql As String, ByVal ddl As DropDownList, ByVal TotalParameter As Int32)
            Dim dt As DataTable = New DataTable
            Dim defValue As String = String.Empty
            Try
                adp = New OracleDataAdapter(strSql, conStr)
                adp.Fill(dt)
                ddl.DataValueField = dt.Columns(0).ColumnName.ToString
                ddl.DataTextField = dt.Columns(1).ColumnName.ToString
                ddl.DataSource = dt
                ddl.DataBind()
                defValue = "-1"
                If (TotalParameter > 2) Then
                    Dim i As Int32 = 2
                    Do While (i < TotalParameter)
                        defValue = (defValue + "#-1")
                        i = (i + 1)
                    Loop

                End If

                ddl.Items.Insert(0, New ListItem("Select", defValue))
            Catch ex As Exception

            Finally
                adp.Dispose()
            End Try

        End Sub

        Public Overloads Shared Sub bindDDL(ByVal strSql As String, ByVal ddl As DropDownList, ByVal selectText As String)
            Dim dt As DataTable = New DataTable
            Try
                adp = New OracleDataAdapter(strSql, conStr)
                adp.Fill(dt)
                ddl.DataValueField = dt.Columns(0).ColumnName.ToString
                ddl.DataTextField = dt.Columns(1).ColumnName.ToString
                ddl.DataSource = dt
                ddl.DataBind()
                ddl.Items.Insert(0, New ListItem(selectText, "-1"))
            Catch ex As Exception

            Finally
                adp.Dispose()
            End Try

        End Sub

        Public Shared Function excecuteNonQuery(ByVal strSql As String) As Int32
            Dim res As Int32 = 0
            Try
                con = New OracleConnection(conStr)
                If (con.State = ConnectionState.Closed) Then
                    con.Open()
                End If

                cmd = New OracleCommand(strSql, con)
                res = Convert.ToInt32(cmd.ExecuteNonQuery)
            Catch ex As Exception
                Return res
            Finally
                If (Not (cmd) Is Nothing) Then
                    cmd.Dispose()
                End If

                If (con.State = ConnectionState.Open) Then
                    con.Close()
                End If

            End Try

            Return res
        End Function

        Public Shared Function excecuteNonQueryGetPk(ByVal strSql As String, ByVal idCol As String) As Int32
            Dim res As Int32 = 0
            Try
                con = New OracleConnection(conStr)
                If (con.State = ConnectionState.Closed) Then
                    con.Open()
                End If

                strSql = (strSql + (" RETURNING " _
                            + (idCol + " INTO :my_id_param")))
                '"; SELECT SCOPE_IDENTITY();";
                cmd = New OracleCommand(strSql, con)
                cmd.CommandType = CommandType.Text
                Dim outputParameter As OracleParameter = New OracleParameter("my_id_param", OracleType.Number)
                outputParameter.Direction = ParameterDirection.Output
                cmd.Parameters.Add(outputParameter)
                cmd.ExecuteNonQuery()
                res = Convert.ToInt32(outputParameter.Value)
            Catch ex As Exception
                Return res
            Finally
                If (Not (cmd) Is Nothing) Then
                    cmd.Dispose()
                End If

                If (con.State = ConnectionState.Open) Then
                    con.Close()
                End If

            End Try

            Return res
        End Function

        Public Shared Function excecuteScalar(ByVal strSql As String) As String
            Dim res As String = String.Empty
            Try
                con = New OracleConnection(conStr)
                If (con.State = ConnectionState.Closed) Then
                    con.Open()
                End If

                cmd = New OracleCommand(strSql, con)
                res = Convert.ToString(cmd.ExecuteScalar)
            Catch ex As Exception
                Return res
            Finally
                If (Not (cmd) Is Nothing) Then
                    cmd.Dispose()
                End If

                If (con.State = ConnectionState.Open) Then
                    con.Close()
                End If

            End Try

            Return res
        End Function
#End Region
#Region "Validation"

        Public Shared Function EmailIsValid(ByVal emailAddress As String) As Boolean
            Dim ValidEmailRegex As Regex = Pinnacle.CreateValidEmailRegex
            Dim isValid As Boolean = ValidEmailRegex.IsMatch(emailAddress)
            Return isValid
        End Function

        Private Shared Function CreateValidEmailRegex() As Regex
            Dim validEmailPattern As String = ("^(?!\.)(""""([^""""\r\\]|\\[""""\r\\])*""""|" + ("([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + "@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$"))
            Return New Regex(validEmailPattern, RegexOptions.IgnoreCase)
        End Function

        Public Shared Function IsNumeric(ByVal input As String) As Int32
            Dim res As Int32 = 0
            Try
                If Int32.TryParse(input, res) Then
                    res = Convert.ToInt32(input)
                End If

            Catch ex As System.Exception
                Return res
            End Try

            Return res
        End Function
#End Region
#Region "String Manipulation"



        Public Shared Function removeNewLineFromString(ByVal data As String) As String
            Return Regex.Replace(data, "\t|\n|\r", "")
        End Function

        Public Shared Function toSubstring(ByVal str As String, ByVal len As Int32) As String
            Dim res As String = String.Empty
            If (str.Length < len) Then
                res = str
            Else
                res = str.Substring(0, len)
            End If

            Return res
        End Function
#End Region
        Public Shared Function getIPMachine() As String          
            Return System.Net.Dns.GetHostEntry(Dns.GetHostName()).AddressList(2).ToString()
        End Function

        Public Shared Function getComputerName() As String
            Return System.Net.Dns.GetHostName()
        End Function
        '#Region "Charts"

        '        Public Shared Sub BindPieChartrec(ByVal ChartName As Chart, ByVal Query As String, ByVal NoDataString As String)
        '            Dim dataTable As DataTable = Pinnacle.getDataTable(Query)
        '            If (dataTable.Rows.Count > 0) Then
        '                Dim x() As String = New String((dataTable.Rows.Count) - 1) {}
        '                Dim y() As Integer = New Integer((dataTable.Rows.Count) - 1) {}
        '                Dim i As Integer = 0
        '                Do While (i < dataTable.Rows.Count)
        '                    x(i) = dataTable.Rows(i)(1).ToString
        '                    y(i) = Convert.ToInt32(dataTable.Rows(i)(2))
        '                    i = (i + 1)
        '                Loop

        '                ChartName.Series(0).Url = "javascript:ShowPopUpDialog('ViewChartDetails.aspx');"
        '                ChartName.Series(0).ToolTip = "#VALX : #VALY"
        '                'ChartName.Series[0].ChartType = SeriesChartType.Pie;
        '                ChartName.Series(0).Points.DataBindXY(x, y)
        '                ChartName.Series(0)("PieLabelStyle") = "Disabled"
        '                'ChartName.Series[0].Enabled = true;
        '                'ChartName.Visible = true;
        '                ChartName.Legends(0).Enabled = True
        '                ChartName.DataSource = dataTable
        '                ChartName.Series(0).PostBackValue = "#VALX"
        '                HttpContext.Current.Session("val") = "#VALX"
        '                ChartName.DataBind()
        '            Else
        '                Dim dt As DataTable = New DataTable
        '                dt.Columns.Add("vstaus")
        '                dt.Columns.Add("descrip")
        '                dt.Columns.Add("countt")
        '                Dim dd As DataRow = dt.NewRow
        '                dd("vstaus") = 0
        '                dd("descrip") = NoDataString
        '                dd("countt") = 0
        '                dt.Rows.Add(dd)
        '                dt.AcceptChanges()
        '                Dim x() As String = New String((dt.Rows.Count) - 1) {}
        '                Dim y() As Integer = New Integer((dt.Rows.Count) - 1) {}
        '                Dim i As Integer = 0
        '                Do While (i < dt.Rows.Count)
        '                    x(i) = dt.Rows(i)(1).ToString
        '                    y(i) = Convert.ToInt32(dt.Rows(i)(2))
        '                    i = (i + 1)
        '                Loop

        '                'ChartName.Series[0].Url = "javascript:ShowPopUpDialog('ViewChartDetails.aspx');";
        '                'ChartName.Series[0].ToolTip = "#VALX, #VALY";
        '                '''/ChartName.Series[0].ChartType = SeriesChartType.Pie;
        '                'ChartName.Series[0].Points.DataBindXY(x, y);
        '                'ChartName.Series[0]["PieLabelStyle"] = "Disabled";
        '                '''/ChartName.Series[0].Enabled = true;
        '                '''/ChartName.Visible = true;
        '                'ChartName.Legends[0].Enabled = true;
        '                'ChartName.DataSource = dt;
        '                'ChartName.Series[0].PostBackValue = "#VALX";
        '                'HttpContext.Current.Session["val"] = "#VALX";
        '                'ChartName.DataBind();
        '                ChartName.DataSource = dt
        '                ChartName.Series(0).EmptyPointStyle.Color = System.Drawing.Color.Green
        '                ChartName.Series(0).XValueMember = "descrip"
        '                ChartName.Series(0).YValueMembers = "countt"
        '                ChartName.DataBind()
        '            End If

        '        End Sub
        '#End Region
#Region "Dates"

        Public Shared Function getCurrentDate() As String
            Dim res As String
            Try
                res = Pinnacle.excecuteScalar("SELECT CURRENT_TIMESTAMP FROM DUAL")
            Catch ex As Exception
                res = DateTime.Now.ToString
                Return res
            End Try

            Return res
        End Function
#End Region
    End Class
End Namespace