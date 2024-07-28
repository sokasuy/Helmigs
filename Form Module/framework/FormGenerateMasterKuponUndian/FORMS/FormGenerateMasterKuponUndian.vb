Public Class FormGenerateMasterKuponUndian

    Private isDataPrepared As Boolean
    Private stSQL As String
    Private isNew As Boolean
    Private isExist As Boolean
    Private myDataTableDGV As New DataTable
    Private myBindingTableDGV As New BindingSource
    Private updateString As String
    Private newValues As String
    Private newFields As String
    Private banyakPages As Integer
    Private logRecordPage As Integer
    Private mCari As String
    Private cmbDgvHapusButton As New DataGridViewButtonColumn()
    Private cmbDgvEditButton As New DataGridViewButtonColumn()
    Private cekTambahButton(1) As Boolean
    Private arrDefValues(3) As String
    Private tableName(1) As String

    Private myDataTableCboKategori As New DataTable
    Private myBindingKategori As New BindingSource
    Private myDataTableCboCariKategori As New DataTable
    Private myBindingCariKategori As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource

    Private isCboPrepared As Boolean

    Public Sub New(_dbType As String, _schemaTmp As String, _schemaPromotion As String, _ConnMain As Object, _username As String, _superuser As Boolean, _dtTableUserRights As DataTable, _addNewValues As String, _addNewFields As String, _addUpdateString As String)
        Try
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            isDataPrepared = False
            With CONN_
                .dbType = _dbType
                .dbMain = _ConnMain
                .schemaTmp = _schemaTmp
                .schemaPromotion = _schemaPromotion
            End With
            With USER_
                .username = _username
                .isSuperuser = _superuser
                .T_USER_RIGHT = _dtTableUserRights
            End With
            With ADD_INFO_
                .newValues = _addNewValues
                .newFields = _addNewFields
                .updateString = _addUpdateString
            End With
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormGenerateMasterKuponUndian Error")
        End Try
    End Sub

    Private Sub FormGenerateMasterKuponUndian_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormGenerateMasterKuponUndian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"KODE", "PERIODE"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 1

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnGenerateKupon, clbUserRight, "load")

            stSQL = "SELECT produk FROM " & CONN_.schemaPromotion & ".msmasterkuponundian GROUP BY produk ORDER BY produk;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableCboCariKategori, myBindingCariKategori, cboCariKategori, "T_" & cboCariKategori.Name, "produk", "produk", isCboPrepared)

            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'msmasterkuponundian' and column_name NOT IN('accountinstagram','created_at','updated_at') ORDER BY column_name ASC;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableColumnNames, myBindingColumnNames, cboSortingCriteria, "T_" & cboSortingCriteria.Name, "column_name", "column_name", isCboPrepared)

            arrCbo = {"ASC", "DESC"}
            cboSortingType.Items.AddRange(arrCbo)
            cboSortingType.SelectedIndex = 0

            tableName(0) = CONN_.schemaPromotion & ".msmasterkuponundian"

            gbGenerateKuponUndian.Enabled = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormGenerateMasterKuponUndian_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormGenerateMasterKuponUndian_KeyDown(sender As Object, e As KeyEventArgs) Handles tbBanyakDigit.KeyDown, tbBanyaknya.KeyDown, btnGenerateKupon.KeyDown, cboCariKategori.KeyDown, cboKriteria.KeyDown, tbCari.KeyDown, cboSortingCriteria.KeyDown, cboSortingType.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbBanyakDigit) Then
                    Call btnGenerateKupon_Click(btnGenerateKupon, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormGenerateMasterKuponUndian_KeyDown Error")
        End Try
    End Sub

    Private Sub btnGenerateKupon_Click(sender As Object, e As EventArgs) Handles btnGenerateKupon.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim strPrefix As String
            Dim kodeKomplit As String
            Dim produk As String
            Dim periode As String

            Dim mCountAddZero As Integer
            Dim zeroNumber As String
            Dim digitLength As String
            Dim hurufAcak As String

            Dim queryBuilder As New Text.StringBuilder
            queryBuilder.Clear()

            digitLength = tbBanyakDigit.Text
            strPrefix = "HV"

            produk = "HELMIGS CAN"
            periode = Now.Year & "/" & Now.Month

            For i As UShort = 1 To Integer.Parse(tbBanyaknya.Text)
                'Application.DoEvents()
                kodeKomplit = Nothing

                hurufAcak = myCStringManipulation.GenerateRandomString(1)
                'Call myCMiscFunction.Wait(2)
                Threading.Thread.Sleep(10)
                kodeKomplit = strPrefix & hurufAcak

                mCountAddZero = digitLength - i.ToString.Length
                zeroNumber = Nothing

                For a As Integer = 0 To mCountAddZero - 1
                    zeroNumber &= "0"
                Next a
                hurufAcak = myCStringManipulation.GenerateRandomString(1)
                'Call myCMiscFunction.Wait(2)
                Threading.Thread.Sleep(10)
                kodeKomplit &= zeroNumber & i & hurufAcak

                newValues = "'" & myCStringManipulation.SafeSqlLiteral(kodeKomplit) & "','" & myCStringManipulation.SafeSqlLiteral(produk) & "','" & myCStringManipulation.SafeSqlLiteral(periode) & "'," & ADD_INFO_.newValues
                newFields = "kupon,produk,periode," & ADD_INFO_.newFields
                queryBuilder.Append(myCStringManipulation.QueryBuilder("insert", tableName(0), newValues, newFields))
            Next

            If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                Call myCShowMessage.ShowInfo("Insert data master kupon promosi berhasil!")
            Else
                Call myCShowMessage.ShowWarning("Insert data master kupon undian gagal!")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnGenerateKupon_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, _contentView As String, Optional gantiKriteria As Boolean = False, Optional sortingCols As String = Nothing, Optional sortingType As String = Nothing)
        Try
            Dim mSelectedCriteria As String
            Dim mGroupCriteria As String = Nothing

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

            isDataPrepared = False
            'If (contentView = "Fingerprint") Then
            If (cboCariKategori.SelectedIndex <> -1) Then
                mGroupCriteria &= " AND (tbl.produk='" & myCStringManipulation.SafeSqlLiteral(cboCariKategori.SelectedValue) & "')"
            End If

            stSQL = "SELECT tbl.kupon,tbl.produk,tbl.periode,tbl.terpakai,tbl.created_at,tbl.updated_at 
                    FROM " & tableName(0) & " as tbl 
                    WHERE (tbl." & cboKriteria.SelectedItem & " like '%" & myCStringManipulation.SafeSqlLiteral(tbCari.Text) & "%')" & mGroupCriteria & "
                    ORDER BY " & IIf(IsNothing(sortingCols), "tbl.rid ASC", sortingCols & " " & sortingType) & ";"
            myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
            myBindingTable.DataSource = myDataTable

            With dgvView
                .DataSource = myBindingTable
                .ReadOnly = True

                .Columns("kupon").Frozen = True
                .Columns("produk").Frozen = True
                .Columns("periode").Frozen = True

                .EnableHeadersVisualStyles = False
                For i As Integer = 0 To .Columns.Count - 1
                    If (.Columns(i).Frozen) Then
                        .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                    End If
                Next

                For a As Integer = 0 To myDataTable.Columns.Count - 1
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                    .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                Next

                .Columns("kupon").Width = 125
                .Columns("produk").Width = 200
                .Columns("periode").Width = 100
                .Columns("terpakai").Width = 80

                For i As Short = 0 To dgvView.Columns.Count - 1
                    If (.Columns(i).ReadOnly) Then
                        .Columns(i).DefaultCellStyle.BackColor = Color.Gainsboro
                    End If
                Next

                .Font = New Font("Arial", 8, FontStyle.Regular)
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
            End With
            'End If

            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(dgvView, dgvView.Rows.Count)
            dgvView.RowHeadersWidth = 70

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGV Error")
        Finally
            Call myCDBConnection.CloseConn(myConn, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Try
            mCari = myCStringManipulation.SafeSqlLiteral(tbCari.Text, 1)
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, myDataTableDGV, myBindingTableDGV, mCari, "", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Try
            Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus Data Master Kupon Undian?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
            If (isConfirm = DialogResult.Yes) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0),, CONN_.dbType)

                Call myCShowMessage.ShowInfo("Data Master Kupon Undian berhasil dihapus")
            Else
                Call myCShowMessage.ShowInfo("Penghapusan Data Master Kupon Undian dibatalkan oleh user")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnHapus_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class

Public Class Container : Implements IDisposable

    Private disposedValue As Boolean

    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects)
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override finalizer
            ' TODO: set large fields to null
            disposedValue = True
        End If
    End Sub

    ' ' TODO: override finalizer only if 'Dispose(disposing As Boolean)' has code to free unmanaged resources
    ' Protected Overrides Sub Finalize()
    '     ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
    '     Dispose(disposing:=False)
    '     MyBase.Finalize()
    ' End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code. Put cleanup code in 'Dispose(disposing As Boolean)' method
        Dispose(disposing:=True)
        GC.SuppressFinalize(Me)
    End Sub
End Class
