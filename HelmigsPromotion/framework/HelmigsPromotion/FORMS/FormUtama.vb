Public Class FormUtama
    Private stSQL As String
    Private isStarted As Boolean
    Private Sub FormUtama_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Try
            'Dim isKeluar As Integer
            'isKeluar = myCShowMessage.GetUserResponse("Apakah anda yakin ingin keluar??", "KONFIRMASI")

            'If (isKeluar = 6) Then
            '    Application.Exit()
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormUtama_FormClosed Error")
        End Try
    End Sub

    Private Sub FormUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            'Note: You shouldn't change the system-wide settings through your application. This one below to change the settings only in your application.
            Application.CurrentCulture = New Globalization.CultureInfo("en-US")

            Call GetUserRight()

            'Dim myDataTablePic As New DataTable
            'Call myCDBConnection.OpenConn(CONN_.dbLokal)
            'stSQL = "SELECT file_name, extension " &
            '       "FROM (T_ImgRes) " &
            '       "WHERE (dipakai = True);"
            'myDataTablePic = myCDBOperation.GetDataTableUsingReader(CONN_.dbLokal, CONN_.comm, CONN_.reader, stSQL, "T_ImgRes")
            'Call myCDBConnection.CloseConn(CONN_.dbLokal)
            'If (myDataTablePic.Rows.Count > 0) Then
            '    Me.BackgroundImage = Image.FromFile("ImgRes/" & myDataTablePic.Rows(0).Item("file_name") & "." & myDataTablePic.Rows(0).Item("extension"))
            '    Me.BackgroundImageLayout = ImageLayout.Stretch
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormUtama_Load Error")
        End Try
    End Sub

    Private Sub FormUtama_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Try
            If Not (isStarted) Then
                USER_.T_USER_RIGHT = New DataTable
                isStarted = True
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormUtama_Activated Error")
        End Try
    End Sub

    Private Sub GetUserRight()
        Try
            'Dim myDataTableMenuAvailable As New DataTable
            Dim foundRows As DataRow()

            If (USER_.isSuperuser) Then
                'Kalau superuser bisa akses semua
            Else
                'Kalau bukan superuser
                stSQL = "SELECT u.formname,f.menucode, f.groupmenucode, u.melihat, u.menambah, u.memperbaharui, u.menghapus
                        FROM " & CONN_.schemaPromotion & ".msformlist as f INNER JOIN " & CONN_.schemaPromotion & ".msuserright as u ON f.formname = u.formname
                        WHERE (((u.userid)='" & myCStringManipulation.SafeSqlLiteral(USER_.username) & "') AND ((f.block)='False'))
                        ORDER BY f.groupmenucode ASC;"
                USER_.T_USER_RIGHT = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_UserRights")

                For i As Integer = 0 To mnStripUtama.Items.Count - 1
                    foundRows = USER_.T_USER_RIGHT.Select("groupmenucode='" & mnStripUtama.Items(i).Name & "'")
                    If (foundRows.Length = 0) Then
                        mnStripUtama.Items(i).Visible = False
                    Else
                        mnStripUtama.Items(i).Visible = True
                    End If
                    Dim toolScriptItem As ToolStripItemCollection = (CType(mnStripUtama.Items(i), ToolStripMenuItem)).DropDownItems
                    For Each menuItem As ToolStripItem In toolScriptItem
                        foundRows = USER_.T_USER_RIGHT.Select("menucode='" & menuItem.Name & "'")
                        If (foundRows.Length = 0) Then
                            menuItem.Visible = False
                        Else
                            menuItem.Visible = True
                        End If
                    Next
                Next

                mnExit.Visible = True
                mnLogout.Visible = True
            End If

            'SEMENTARA UNTUK PAYROLL TIDAK ADA YANG BISA AKSES
            'If (USER_.username = "Yusak") Then
            '    mnGroupPayroll.Visible = True
            'Else
            '    mnGroupPayroll.Visible = False
            'End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetUserRight Error")
        End Try
    End Sub

    Private Sub mnLogout_Click(sender As Object, e As EventArgs) Handles mnLogout.Click
        Try
            'Dim frmLogin As New FormLogin()
            Me.Hide()
            'Me.Dispose()
            FormLogin.Activate()
            FormLogin.Show()
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "mnLogout_Click Error")
        End Try
    End Sub

    Private Sub mnExit_Click(sender As Object, e As EventArgs) Handles mnExit.Click
        Try
            Dim isKeluar As Integer
            isKeluar = myCShowMessage.GetUserResponse("Apakah anda yakin ingin keluar??", "KONFIRMASI")

            If (isKeluar = 6) Then
                Application.Exit()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "mnExit_click Error")
        End Try
    End Sub

    Private Sub mnGenerateMasterKodePromosi_Click(sender As Object, e As EventArgs) Handles mnGenerateMasterKuponUndian.Click
        Dim frmGenerateMasterKodePromosi As New FormGenerateMasterKuponUndian.FormGenerateMasterKuponUndian(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaPromotion, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString)
        Call myCFormManipulation.GoToForm(Me, frmGenerateMasterKodePromosi)
    End Sub

    Private Sub mnDataKonsumen_Click(sender As Object, e As EventArgs) Handles mnDataKonsumen.Click
        Dim frmInputDataKonsumen As New FormInputDataKonsumen.FormInputDataKonsumen(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaPromotion, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString)
        Call myCFormManipulation.GoToForm(Me, frmInputDataKonsumen)
    End Sub
End Class
