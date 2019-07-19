Imports System.Data
Imports System.IO
Imports Telerik.Web.UI
Imports System.Text
Imports System.Environment

Partial Class _Default
    Inherits System.Web.UI.Page
    Dim clas As rahulcpm.commonclass = New rahulcpm.commonclass()

    Dim qry As String
    Dim dt As DataTable
    Dim sydate As String
    Dim agntid As Int32
    Dim msg As String
    Dim fsn As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then           
            ' binddates(dt_update, Date.Today.ToString("dd-MMM-yyyy"), Date.Today.ToString("dd-MMM-yyyy"), Date.Today.AddDays(15).ToString("dd-MMM-yyyy"), True)

            If Convert.ToString(Request.QueryString("src")) = "1" Then
                ' row2.Visible = False
                'row1.Visible = False
                lblhead.Text = "View/Upload Documents"
            End If

        Else

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

        If (TypeOf e.Item Is GridDataItem) Then
            For Each cell As TableCell In e.Item.Cells
                cell.Attributes.Add("title", cell.Text)
            Next

        End If
        
    End Sub



   
    Protected Sub RadGrid1_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
       
        qry = "SELECT FID, TKID, FILENAME, ( select  name||' ('|| Branch ||' - '|| EmpDesignation ||')' Name from tt.employees where empno=keyedby )keyedby,to_char(keyedon,'dd-Mon-yyyy HH24:MI:SS') Keyedon FROM TT.SUPPORT_DOC where tkid='" & Request.QueryString("sid") & "' order by FID desc"
        dt = clas.getdata(qry, "QR")
        RadGrid1.DataSource = dt
    End Sub

    Protected Sub RadGrid1_PreRender(sender As Object, e As System.EventArgs) Handles RadGrid1.PreRender
        'Dim column As GridColumn = TryCast(RadGrid1.MasterTableView.GetColumnSafe("doc"), GridColumn)
        'column.OrderIndex = RadGrid1.MasterTableView.RenderColumns.Length
        'RadGrid1.MasterTableView.Rebind()
    End Sub


    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click, ImageButton1.Click
        Dim fileName As String

        'If txtdoc.Text <> "" Then
        '    txtdoc.Text = txtdoc.Text.Replace("'", "").Replace("""", "").Replace("%", "").Replace("+", "").Replace("&", "").Trim
        'End If

        'If txtdoc.Text.Trim = "" Then
        '    RadWindowManager1.RadAlert("<div style=color:green;> Type of document required. </div>", 300, 150, "Validation Success", Nothing)
        '    Exit Sub
        'End If

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
                If fileSize < 20045728 Then

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
                        qry = "insert into TT.support_doc ( FID, TKID, FILENAME,keyedby,keyedon ) values(tt.support_doc_seq.nextval , '" & Request.QueryString("sid") & "','" & fileName & "','" & Request.QueryString("empno") & "',sysdate)"
                        Dim i = clas.ExecuteNonQuery(qry.ToString())
                        If i = 1 Then

                            RadWindowManager1.RadAlert("<ul><li><div style=color:green;> Document Uploaded Successfully </div></li></ul>", 300, 150, "Validation Success", Nothing)
                            RadGrid1.Rebind()
                            clear()
                            Exit Sub
                        Else

                            Dim Err_Msg As String = clas.getexception().Replace(vbCrLf, "")
                            Err_Msg = Err_Msg.Replace(vbCr, "")
                            Err_Msg = Err_Msg.Replace(vbLf, "")
                            RadWindowManager1.RadAlert("<ul><li><div style=color:red;>System found some exception:" & Err_Msg & "</div></li></ul>", 300, 100, "Validation Exception Failure", Nothing)
                        End If

                        'Else
                        '    RadWindowManager1.RadAlert("<div style=color:Red;> Please upload jpg/png format. </div>", 300, 150, "Validation Error", Nothing)
                        '    Exit Sub
                    End If

                Else
                    RadWindowManager1.RadAlert("<div style=color:Red;> Document should not contain file size more than 20 MB. </div>", 300, 150, "Validation Error", Nothing)
                    Exit Sub
                End If

            End If

        End If





    End Sub





    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        clear()

    End Sub

    'Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
    '    RadGrid1.Rebind()

    'End Sub


    Private Sub clear()
        ' TextBox1.Text = String.Empty        

        txtdoc.Text = String.Empty
    End Sub





   
End Class
