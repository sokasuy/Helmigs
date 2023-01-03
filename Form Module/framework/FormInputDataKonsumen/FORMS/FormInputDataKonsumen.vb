Public Class FormInputDataKonsumen
    Private isDataPrepared As Boolean
    Private stSQL As String
    Private isNew As Boolean
    Private isExist As Boolean
    Private myDataTableDGV As New DataTable
    Private myBindingTableDGV As New BindingSource
    Private myDataTableDGVKonsumen As New DataTable
    Private myBindingTableDGVKonsumen As New BindingSource
    Private myDataTableDGVKupon As New DataTable
    Private myBindingTableDGVKupon As New BindingSource
    Private updateString As String
    Private newValues As String
    Private newFields As String
    Private banyakPages As Integer
    Private logRecordPage As Integer
    Private mCari As String
    Private cmbDgvHapusKonsumenButton As New DataGridViewButtonColumn()
    Private cmbDgvHapusKuponButton As New DataGridViewButtonColumn()
    Private cmbDgvEditButton As New DataGridViewButtonColumn()
    Private cmbDgvAttachmentButton As New DataGridViewButtonColumn()
    Private cekTambahButton(3) As Boolean
    Private arrDefValues(3) As String
    Private tableName(1) As String

    Private myDataTableCboKategori As New DataTable
    Private myBindingKategori As New BindingSource
    Private myDataTableCboCariKategori As New DataTable
    Private myBindingCariKategori As New BindingSource
    Private myDataTableColumnNames As New DataTable
    Private myBindingColumnNames As New BindingSource
    Private myDataTableCboKupon As New DataTable
    Private myBindingKupon As New BindingSource

    Private enableSubForm(1) As Boolean
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
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "New FormInputDataKonsumen Error")
        End Try
    End Sub

    Private Sub FormInputDataKonsumen_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me)
    End Sub

    Private Sub FormInputDataKonsumen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            isNew = True
            Dim arrCbo() As String
            arrCbo = {"ACCOUNT INSTAGRAM", "NOMOR WA"}
            cboKriteriaKonsumen.Items.AddRange(arrCbo)
            cboKriteriaKonsumen.SelectedIndex = 0

            arrCbo = {"ACCOUNT INSTAGRAM", "NOMOR WA", "KUPON"}
            cboKriteria.Items.AddRange(arrCbo)
            cboKriteria.SelectedIndex = 0

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Call myCFormManipulation.SetCheckListBoxUserRights(clbUserRight, USER_.isSuperuser, Me.Name, USER_.T_USER_RIGHT)
            Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "load")
            'BUAT FORM YANG DIAKSES DARI GRID
            If USER_.isSuperuser Then
                'Kalau superuser, maka di enable semua
                For i As Integer = 0 To enableSubForm.Count - 1
                    enableSubForm(i) = True
                Next
            Else
                'Kalau bukan superuser aja yang di cek
                Dim foundRows As DataRow()
                'ATTACHMENT
                foundRows = USER_.T_USER_RIGHT.Select("formname='FormAttachmentKonsumen'")
                If (foundRows.Length = 0) Then
                    enableSubForm(0) = False
                Else
                    enableSubForm(0) = True
                End If
            End If

            stSQL = "SELECT column_name FROM INFORMATION_SCHEMA. COLUMNS WHERE TABLE_NAME = 'mskonsumen' and column_name NOT IN('created_at','updated_at') ORDER BY column_name ASC;"
            Call myCDBOperation.SetCbo_(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, myDataTableColumnNames, myBindingColumnNames, cboSortingCriteria, "T_" & cboSortingCriteria.Name, "column_name", "column_name", isCboPrepared)

            arrCbo = {"ASC", "DESC"}
            cboSortingType.Items.AddRange(arrCbo)
            cboSortingType.SelectedIndex = 0

            tableName(0) = CONN_.schemaPromotion & ".mskonsumen"
            tableName(1) = CONN_.schemaPromotion & ".msmasterkuponundian"

            Call SetCboKupon(CONN_.dbMain, CONN_.comm, CONN_.reader)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormInputDataKonsumen_Load Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FormInputDataKonsumen_KeyDown(sender As Object, e As KeyEventArgs) Handles cboKriteriaKonsumen.KeyDown, tbCariKonsumen.KeyDown, btnCariKonsumen.KeyDown, tbAccountInstagram.KeyDown, tbNomorWA.KeyDown, cboKupon.KeyDown, btnSimpan.KeyDown, btnKeluar.KeyDown, btnAddNew.KeyDown, cboKriteria.KeyDown, tbCari.KeyDown, btnTampilkan.KeyDown
        Try
            If (e.KeyCode = Keys.Enter) Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, True)
                If (sender Is tbCariKonsumen) Then
                    Call btnCariKonsumen_Click(btnCariKonsumen, e)
                End If
                If (sender Is cboKupon) Then
                    Call btnSimpan_Click(btnSimpan, e)
                End If
                If (sender Is tbCari) Then
                    Call btnTampilkan_Click(btnTampilkan, e)
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "FormInputDataKonsumen_KeyDown Error")
        End Try
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Call myCFormManipulation.CloseMyForm(Me.Owner, Me, False)
    End Sub

    Private Sub SetDGV(myConn As Object, myComm As Object, myReader As Object, offSet As Integer, ByRef _dgv As DataGridView, ByRef myDataTable As DataTable, ByRef myBindingTable As BindingSource, mKriteria As String, _contentView As String, Optional gantiKriteria As Boolean = False, Optional sortingCols As String = Nothing, Optional sortingType As String = Nothing)
        Try
            Dim batas As Integer
            Dim mJumlah As Integer
            Dim mSelectedCriteria As String
            Dim mGroupCriteria As String = Nothing

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(myConn)

            mSelectedCriteria = cboKriteria.SelectedItem.ToString.Replace(" ", "")
            mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

            isDataPrepared = False
            If (_contentView = "CARI KONSUMEN") Then
                stSQL = "SELECT tbl.accountinstagram,tbl.nomorwa 
                        FROM " & tableName(0) & " as tbl 
                        WHERE (upper(tbl." & mSelectedCriteria & ") like '%" & mKriteria.ToUpper & "%')
                        ORDER BY tbl.accountinstagram ASC;"
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
                myBindingTable.DataSource = myDataTable

                With _dgv
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next

                    .Columns("accountinstagram").HeaderText = "INSTAGRAM"
                    .Columns("nomorwa").HeaderText = "WA"

                    .Columns("accountinstagram").Width = 200
                    .Columns("nomorwa").Width = 150

                    For i As Short = 0 To _dgv.Columns.Count - 1
                        If (.Columns(i).ReadOnly) Then
                            .Columns(i).DefaultCellStyle.BackColor = Color.Gainsboro
                        End If
                    Next

                    .Font = New Font("Arial", 7, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With


                ''untuk menampilkan auto number pada rowHeaders
                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(_dgv, _dgv.Rows.Count)
                _dgv.RowHeadersWidth = 70
            ElseIf (_contentView = "LIHAT DATA") Then
                'If (cboCariKategori.SelectedIndex <> -1) Then
                '    mGroupCriteria = " AND (tbl.kategori='" & myCStringManipulation.SafeSqlLiteral(cboCariKategori.SelectedValue) & "')"
                'End If

                If (gantiKriteria) Then
                    Dim tempSisa As Integer
                    'Dim tampTotalRecords As Integer
                    banyakPages = 0
                    mKriteria = IIf(IsNothing(mKriteria), "", mKriteria)

                    'stSQL = "SELECT count(*) FROM " & tableName(0) & " as tbl INNER JOIN " & tableName(1) & " as tbl2 on tbl.accountinstagram=tbl2.accountinstagram WHERE ((upper(" & IIf(mSelectedCriteria.ToLower = "kupon", "tbl2.", "tbl.") & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%'));"
                    stSQL = "SELECT count(*) FROM (SELECT DISTINCT (tbl.accountinstagram ) as accountig FROM " & tableName(0) & " as tbl INNER JOIN " & tableName(1) & " as tbl2 on tbl.accountinstagram=tbl2.accountinstagram WHERE ((upper(" & IIf(mSelectedCriteria.ToLower = "kupon", "tbl2.", "tbl.") & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%'))) as subtbl;"
                    mJumlah = Integer.Parse(myCDBOperation.GetDataIndividual(myConn, myComm, myReader, stSQL))

                    If (mJumlah > 10) Then
                        banyakPages = mJumlah / 10
                    Else
                        banyakPages = 1
                    End If
                    tempSisa = mJumlah Mod 10
                    If (tempSisa < 5 And tempSisa > 0 And mJumlah > 10) Then
                        'karena 5 ke atas dibulatkan ke atas
                        'misal 15/10 hasilnya adalah 2
                        'sedangkan kalau 14/10 hasilnya adalah 1
                        'jadi kalau sisanya kurang dari 5, maka halaman ditambah 1
                        banyakPages = banyakPages + 1
                    End If
                    gantiKriteria = False
                End If
                lblOfPages.Text = "Of: " & banyakPages & " Pages"

                If (mJumlah - offSet < 0) Then
                    If (mJumlah <> 0) Then
                        batas = mJumlah Mod 10
                    Else
                        Call myCShowMessage.ShowWarning("Belum ada data tersedia", "Perhatian")
                        batas = 10
                    End If
                Else
                    batas = 10
                End If

                'stSQL = "SELECT rid,nik,nama,accountinstagram,kupon,nomorwa,created_at,updated_at " &
                '        "FROM ( " &
                '            "SELECT sub.rid,sub.nik,sub.nama,sub.accountinstagram,sub.nomorwa,sub.kupon,sub.created_at,sub.updated_at " &
                '            "FROM ( " &
                '                "SELECT tbl.rid,tbl.nik,tbl.nama,tbl.accountinstagram,tbl.nomorwa,tbl2.kupon,tbl.created_at,tbl2.updated_at " &
                '                "FROM " & tableName(0) & " as tbl INNER JOIN " & tableName(1) & " as tbl2 on tbl.accountinstagram=tbl2.accountinstagram " &
                '                "WHERE ((upper(" & IIf(mSelectedCriteria.ToLower = "kupon", "tbl2.", "tbl.") & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & mGroupCriteria & " " &
                '                "ORDER BY " & IIf(IsNothing(sortingCols), "(case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC ", sortingCols & " " & sortingType) & " " &
                '                "LIMIT " & offSet &
                '                ") sub " &
                '            "ORDER BY " & IIf(IsNothing(sortingCols), "(case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC ", sortingCols & " " & IIf(sortingType = "ASC", "DESC", "ASC")) & " " &
                '            "LIMIT " & batas &
                '        ") subOrdered " &
                '        "ORDER BY " & IIf(IsNothing(sortingCols), "(case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC ", sortingCols & " " & sortingType) & ";"
                stSQL = "SELECT rid,nik,nama,accountinstagram,nomorwa,jumlahkupon,created_at,updated_at " &
                        "FROM ( " &
                            "SELECT sub.rid,sub.nik,sub.nama,sub.accountinstagram,sub.nomorwa,sub.jumlahkupon,sub.created_at,sub.updated_at " &
                            "FROM ( " &
                                "SELECT tbl.rid,tbl.nik,tbl.nama,tbl.accountinstagram,tbl.nomorwa,count(tbl2.kupon) as jumlahkupon,tbl.created_at,tbl.updated_at " &
                                "FROM " & tableName(0) & " as tbl INNER JOIN " & tableName(1) & " as tbl2 on tbl.accountinstagram=tbl2.accountinstagram " &
                                "WHERE ((upper(" & IIf(mSelectedCriteria.ToLower = "kupon", "tbl2.", "tbl.") & mSelectedCriteria & ") LIKE '%" & mKriteria.ToUpper & "%')) " & mGroupCriteria & " " &
                                "GROUP BY tbl.rid,tbl.nik,tbl.nama,tbl.accountinstagram,tbl.nomorwa,tbl.created_at,tbl.updated_at " &
                                "ORDER BY " & IIf(IsNothing(sortingCols), "(case when tbl.updated_at is null then tbl.created_at else tbl.updated_at end) DESC, tbl.rid DESC ", sortingCols & " " & sortingType) & " " &
                                "LIMIT " & offSet &
                                ") sub " &
                            "ORDER BY " & IIf(IsNothing(sortingCols), "(case when sub.updated_at is null then sub.created_at else sub.updated_at end) ASC, sub.rid ASC ", sortingCols & " " & IIf(sortingType = "ASC", "DESC", "ASC")) & " " &
                            "LIMIT " & batas &
                        ") subOrdered " &
                        "ORDER BY " & IIf(IsNothing(sortingCols), "(case when subOrdered.updated_at is null then subOrdered.created_at else subOrdered.updated_at end) DESC, subOrdered.rid DESC ", sortingCols & " " & sortingType) & ";"

                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
                myBindingTable.DataSource = myDataTable

                With _dgv
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    .Columns("rid").Visible = False
                    .Columns("nik").Visible = False
                    .Columns("nama").Visible = False

                    .Columns("rid").Frozen = True
                    .Columns("nik").Frozen = True
                    .Columns("nama").Frozen = True
                    .Columns("accountinstagram").Frozen = True
                    .Columns("jumlahkupon").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next

                    .Columns("accountinstagram").Width = 110
                    .Columns("jumlahkupon").Width = 60
                    .Columns("nomorwa").Width = 90

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next

                    .Columns("accountinstagram").HeaderText = "INSTAGRAM"
                    .Columns("nomorwa").HeaderText = "WA"
                    .Columns("jumlahkupon").HeaderText = "JML KUPON"

                    .Columns("created_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"
                    .Columns("updated_at").DefaultCellStyle.Format = "dd-MMM-yyyy HH:mm:ss"

                    .Font = New Font("Arial", 8, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With

                With cmbDgvEditButton
                    If Not (cekTambahButton(0)) Then
                        .HeaderText = "EDIT"
                        .Name = "edit"
                        .Text = "Edit"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = _dgv.Columns("jumlahkupon").Index + 1
                        _dgv.Columns.Add(cmbDgvEditButton)
                        _dgv.Columns("edit").Width = 70
                        cekTambahButton(0) = True
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Memperbaharui"))
                        '.Frozen = True
                    End If
                    .HeaderCell.Style.BackColor = Color.Lime
                End With

                With cmbDgvAttachmentButton
                    If Not (cekTambahButton(2)) Then
                        .HeaderText = "ATTACHMENT"
                        .Name = "attachment"
                        .Text = "Attachment"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = _dgv.Columns("edit").DisplayIndex + 1
                        dgvView.Columns.Add(cmbDgvAttachmentButton)
                        dgvView.Columns("attachment").Width = 90
                        cekTambahButton(2) = True
                        .Visible = enableSubForm(0)
                    End If
                    .HeaderCell.Style.BackColor = Color.Yellow
                End With

                With cmbDgvHapusKonsumenButton
                    If Not (cekTambahButton(1)) Then
                        .HeaderText = "HAPUS"
                        .Name = "delete"
                        .Text = "Hapus Record"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = _dgv.ColumnCount
                        _dgv.Columns.Add(cmbDgvHapusKonsumenButton)
                        _dgv.Columns("delete").Width = 100
                        cekTambahButton(1) = True
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                    End If
                    .HeaderCell.Style.BackColor = Color.LightSalmon
                End With

                ''untuk menampilkan auto number pada rowHeaders
                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(_dgv, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
                _dgv.RowHeadersWidth = 70

                'atur warna selang seling datagrid
                Call myCDataGridViewManipulation.SetDGVColour(_dgv)

                'ATUR PANEL NAVIGASI
                If (tbRecordPage.Text = 1) Then
                    'di awal sendiri
                    btnFFBack.Enabled = False
                    btnBack.Enabled = False
                    If (banyakPages > 1) Then
                        btnFFForward.Enabled = True
                        btnForward.Enabled = True
                    Else
                        btnFFForward.Enabled = False
                        btnForward.Enabled = False
                    End If
                ElseIf (tbRecordPage.Text > 1) Then
                    'di tengah2 halaman record
                    btnBack.Enabled = True
                    If (tbRecordPage.Text < banyakPages) Then
                        btnFFBack.Enabled = True
                        btnFFForward.Enabled = True
                        btnForward.Enabled = True
                    Else
                        btnFFBack.Enabled = True
                        btnFFForward.Enabled = False
                        btnForward.Enabled = False
                    End If
                End If
            ElseIf (_contentView = "LIHAT KUPON") Then
                stSQL = "SELECT tbl.kupon,tbl.produk,tbl.periode
                        FROM " & tableName(1) & " as tbl 
                        WHERE (upper(tbl.accountinstagram) like '%" & mKriteria.ToUpper & "%')
                        ORDER BY tbl.rid ASC;"
                myDataTable = myCDBOperation.GetDataTableUsingReader(myConn, myComm, myReader, stSQL, "TBL " & lblTitle.Text)
                myBindingTable.DataSource = myDataTable

                With _dgv
                    .DataSource = myBindingTable
                    .ReadOnly = True

                    .Columns("kupon").Frozen = True

                    .EnableHeadersVisualStyles = False
                    For i As Integer = 0 To .Columns.Count - 1
                        If (.Columns(i).Frozen) Then
                            .Columns(i).HeaderCell.Style.BackColor = Color.Moccasin
                        End If
                    Next

                    .Columns("kupon").Width = 125
                    .Columns("produk").Width = 150
                    .Columns("periode").Width = 150

                    For a As Integer = 0 To myDataTable.Columns.Count - 1
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = myDataTable.Columns(a).ColumnName.ToUpper
                        .Columns(myDataTable.Columns(a).ColumnName).HeaderText = .Columns(myDataTable.Columns(a).ColumnName).HeaderText.Replace("_", " ")
                    Next

                    .Font = New Font("Arial", 7, FontStyle.Regular)
                    .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False
                End With

                With cmbDgvHapusKuponButton
                    If Not (cekTambahButton(3)) Then
                        .HeaderText = "HAPUS"
                        .Name = "delete"
                        .Text = "Hapus Record"
                        .UseColumnTextForButtonValue = True
                        .DisplayIndex = _dgv.ColumnCount
                        _dgv.Columns.Add(cmbDgvHapusKuponButton)
                        _dgv.Columns("delete").Width = 100
                        cekTambahButton(3) = True
                        .Visible = clbUserRight.GetItemChecked(clbUserRight.Items.IndexOf("Menghapus"))
                    End If
                    .HeaderCell.Style.BackColor = Color.LightSalmon
                End With

                ''untuk menampilkan auto number pada rowHeaders
                Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithoutPaging(_dgv, _dgv.Rows.Count)
                _dgv.RowHeadersWidth = 70

                'atur warna selang seling datagrid
                Call myCDataGridViewManipulation.SetDGVColour(_dgv)
            End If

            isDataPrepared = True
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "SetDGV Error")
        Finally
            Call myCDBConnection.CloseConn(myConn, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvView_Sorted(sender As Object, e As EventArgs) Handles dgvView.Sorted
        Try
            ''untuk menampilkan auto number pada rowHeaders
            Call myCDataGridViewManipulation.AutoNumberRowsForGridViewWithPaging(dgvView, (Integer.Parse(tbRecordPage.Text) - 1) * 10)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_Sorted Error")
        End Try
    End Sub

    Private Sub btnTampilkan_Click(sender As Object, e As EventArgs) Handles btnTampilkan.Click
        Try
            mCari = myCStringManipulation.SafeSqlLiteral(tbCari.Text, 1)
            tbRecordPage.Text = 1
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, dgvView, myDataTableDGV, myBindingTableDGV, mCari, "LIHAT DATA", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnTampilkan_Click Error")
        End Try
    End Sub

    Private Sub btnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        Try
            isNew = True
            lblEntryType.Text = "INSERT NEW"
            isDataPrepared = True

            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Call SetCboKupon(CONN_.dbMain, CONN_.comm, CONN_.reader)
            cboKupon.Enabled = True
            tbAccountInstagram.ReadOnly = False
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCreateNew_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) - 1 > 0) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) - 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, dgvView, myDataTableDGV, myBindingTableDGV, mCari, "LIHAT DATA", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        Try
            If (Integer.Parse(tbRecordPage.Text) + 1 <= banyakPages) Then
                tbRecordPage.Text = Integer.Parse(tbRecordPage.Text) + 1
                logRecordPage = tbRecordPage.Text
                Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, Integer.Parse(tbRecordPage.Text) * 10, dgvView, myDataTableDGV, myBindingTableDGV, mCari, "LIHAT DATA", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFBack_Click(sender As Object, e As EventArgs) Handles btnFFBack.Click
        Try
            tbRecordPage.Text = 1
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, dgvView, myDataTableDGV, myBindingTableDGV, mCari, "LIHAT DATA", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFBack_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub btnFFForward_Click(sender As Object, e As EventArgs) Handles btnFFForward.Click
        Try
            tbRecordPage.Text = banyakPages
            logRecordPage = tbRecordPage.Text
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, banyakPages * 10, dgvView, myDataTableDGV, myBindingTableDGV, mCari, "LIHAT DATA", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnFFForward_Click Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub tbRecordPage_GotFocus(sender As Object, e As EventArgs) Handles tbRecordPage.GotFocus
        Try
            logRecordPage = tbRecordPage.Text
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_GotFocus Error")
        End Try
    End Sub

    Private Sub tbRecordPage_Validated(sender As Object, e As EventArgs) Handles tbRecordPage.Validated
        Try
            If (IsNumeric(tbRecordPage.Text)) Then
                Dim temp As Integer
                temp = Integer.Parse(tbRecordPage.Text)
                If (temp > 0 And temp <= banyakPages) Then
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, temp * 10, dgvView, myDataTableDGV, myBindingTableDGV, mCari, "LIHAT DATA", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                    logRecordPage = tbRecordPage.Text
                Else
                    Call myCShowMessage.ShowWarning("Tidak ada record pada halaman tersebut!", "Perhatian")
                    tbRecordPage.Text = logRecordPage
                End If
            Else
                Call myCShowMessage.ShowWarning("Inputan harus berupa angka saja", "Perhatian")
                tbRecordPage.Text = logRecordPage
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbRecordPage_Validated Error")
            tbRecordPage.Text = logRecordPage
        End Try
    End Sub

    Private Sub dgvView_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvView.CellMouseDown
        Try
            'if di bawah ditambahkan pada 3 feb 2012 agar bisa pilih full row lebih dari 1,
            'karena kalau tidak ada if dibawah maka apabila sudah pilih full row pakai klik kiri
            'anggap saja mau pilih 3 full row, lalu di klik kanan, maka hanya row terakhir yang akan terpilih
            'oleh karena itu diberi if row yang dipilih tidak lebih dari 1, jadi klw milih banyak, fungsi di dalam if tidak akan dijalankan
            'dengan kata lain pada kasus ini klik kanan hanya untuk menampilkan konteks menu.
            'singkatnya, kalau sudah ada full row yang terpilih, maka fungsi di event ini tidak akan dijalankan
            If Not (dgvView.SelectedRows.Count > 1) Then
                'fungsi ini ditujukan agar user bisa memilih cell dengan klik kanan juga
                If e.Button = MouseButtons.Right Then
                    If e.ColumnIndex = -1 = False And e.RowIndex = -1 = False Then
                        'kondisi ini untuk kalau user meng-klik kanan dalam area dgv bukan di header2nya
                        dgvView.ClearSelection()
                        dgvView.CurrentCell = dgvView.Item(e.ColumnIndex, e.RowIndex)
                        dgvView.Rows(e.RowIndex).Selected = True
                    Else
                        'kondisi ini untuk kalau user mengklik di header dgv nya
                        'selected cell sebelumnya di clear dulu
                        dgvView.ClearSelection()
                        'untuk mindah pointer
                        dgvView.CurrentCell = dgvView.Item(1, e.RowIndex)
                        'untuk select 1 baris penuh
                        dgvView.Rows(e.RowIndex).Selected = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellMouseDown Error")
        End Try
    End Sub

    Private Sub dgvView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellContentClick
        Try
            If (dgvView.RowCount > 0) Then
                If (e.RowIndex = -1) Then
                    Exit Sub
                End If

                If (e.ColumnIndex = dgvView.Columns("delete").Index) Then
                    Me.Cursor = Cursors.WaitCursor
                    Call myCDBConnection.OpenConn(CONN_.dbMain)

                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(1), "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("accountinstagram").Value) & "'")
                    If Not isExist Then
                        Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data konsumen " & dgvView.CurrentRow.Cells("accountinstagram").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                        If (isConfirm = DialogResult.Yes) Then
                            Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)

                            'Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(1), "terpakai='False',accountinstagram=Null," & ADD_INFO_.updateString, "kupon='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("kupon").Value) & "'")

                            'Dim cekBanyaknya As Integer
                            'cekBanyaknya = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(1), "Count", "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("accountinstagram").Value) & "'", CONN_.dbType)
                            'If (cekBanyaknya > 1) Then
                            '    'Jika ada lebih dari 1 kupon yang dimiliki oleh account instagram sebelumnya, maka data konsumen tidak akan dihapus, tidak akan dilakukan apapun
                            'Else
                            '    'Jika hanya 1 kupon yang dimiliki oleh account instagram yang lama, maka data konsumen akan dihapus
                            '    queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableName(0), "",, "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(1)) & "'"))
                            'End If
                            'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                            'Call myCShowMessage.ShowDeletedMsg("Data di master general dengan keterangan " & dgvView.CurrentRow.Cells("keterangan").Value & " untuk kategori " & dgvView.CurrentRow.Cells("kategori").Value)
                            Call SetCboKupon(CONN_.dbMain, CONN_.comm, CONN_.reader)
                            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, dgvView, myDataTableDGV, myBindingTableDGV, mCari, "LIHAT DATA", True, IIf(cboSortingCriteria.SelectedIndex = -1, Nothing, cboSortingCriteria.SelectedValue), cboSortingType.SelectedItem)
                        Else
                            Call myCShowMessage.ShowInfo("Penghapusan data konsumen " & dgvView.CurrentRow.Cells("accountinstagram").Value & " untuk kupon " & dgvView.CurrentRow.Cells("kupon").Value)
                        End If
                    Else
                        Call myCShowMessage.ShowWarning("Konsumen " & dgvView.CurrentRow.Cells("accountinstagram").Value & " memiliki kupon aktif!" & ControlChars.NewLine & "Konsumen tidak dapat dihapus")
                    End If
                ElseIf (e.ColumnIndex = dgvView.Columns("attachment").Index) Then
                    Dim frmAttachmentKaryawan As New FormAttachmentKonsumen.FormAttachmentKonsumen(CONN_.dbType, CONN_.schemaTmp, CONN_.schemaPromotion, CONN_.dbMain, USER_.username, USER_.isSuperuser, USER_.T_USER_RIGHT, ADD_INFO_.newValues, ADD_INFO_.newFields, ADD_INFO_.updateString, Me.Name, dgvView.CurrentRow.Cells("nik").Value, dgvView.CurrentRow.Cells("nama").Value, dgvView.CurrentRow.Cells("accountinstagram").Value)
                    Call myCFormManipulation.GoToForm(Me.MdiParent, frmAttachmentKaryawan)
                ElseIf (e.ColumnIndex = dgvView.Columns("edit").Index) Then
                    isNew = False
                    lblEntryType.Text = "EDIT"
                    isDataPrepared = False
                    Call myCFormManipulation.ResetForm(gbDataEntry)
                    Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "edit")

                    For i As Integer = 0 To arrDefValues.Count - 1
                        arrDefValues(i) = Nothing
                    Next

                    'RecID
                    arrDefValues(0) = dgvView.CurrentRow.Cells("rid").Value
                    'Account Instagram
                    If Not IsDBNull(dgvView.CurrentRow.Cells("accountinstagram").Value) Then
                        tbAccountInstagram.Text = dgvView.CurrentRow.Cells("accountinstagram").Value
                        arrDefValues(1) = dgvView.CurrentRow.Cells("accountinstagram").Value
                        tbAccountInstagram.ReadOnly = True
                    End If
                    'Kode
                    If Not IsDBNull(dgvView.CurrentRow.Cells("nomorwa").Value) Then
                        tbNomorWA.Text = dgvView.CurrentRow.Cells("nomorwa").Value
                        arrDefValues(2) = dgvView.CurrentRow.Cells("nomorwa").Value
                    End If
                    'Kupon
                    'If Not IsDBNull(dgvView.CurrentRow.Cells("kupon").Value) Then
                    'cboKupon.Text = dgvView.CurrentRow.Cells("kupon").Value
                    'arrDefValues(3) = dgvView.CurrentRow.Cells("kupon").Value
                    'For i As Integer = 0 To cboKupon.Items.Count - 1
                    '    If (DirectCast(cboKupon.Items(i), DataRowView).Item("kupon") = dgvView.CurrentRow.Cells("kupon").Value) Then
                    '        cboKupon.SelectedIndex = i
                    '        arrDefValues(3) = dgvView.CurrentRow.Cells("kupon").Value
                    '    End If
                    'Next
                    cboKupon.Enabled = False
                    'End If
                    isDataPrepared = True
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellContentClick Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        Try
            If (Trim(tbAccountInstagram.Text).Length > 0 And Trim(tbNomorWA.Text).Length > 0) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)
                If isNew Then
                    'CREATE NEW
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'")
                    If Not isExist Then
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(1), "kupon='" & myCStringManipulation.SafeSqlLiteral(cboKupon.SelectedValue) & "' AND terpakai='True'")
                        If Not isExist Then
                            'CREATE NEW
                            newValues = "'-','-','-','" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'," & ADD_INFO_.newValues
                            newFields = "nik,nama,alamat,accountinstagram," & ADD_INFO_.newFields
                            If (Trim(tbNomorWA.Text).Length > 0) Then
                                newValues &= ",'" & myCStringManipulation.SafeSqlLiteral(tbNomorWA.Text) & "'"
                                newFields &= ",nomorwa"
                            End If
                            Call myCDBOperation.InsertData(CONN_.dbMain, CONN_.comm, tableName(0), newValues, newFields)

                            'UPDATE KE mskuponnya
                            Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(1), "terpakai='True',accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'," & ADD_INFO_.updateString, "kupon='" & myCStringManipulation.SafeSqlLiteral(cboKupon.SelectedValue) & "' AND terpakai='False'")

                            Call myCShowMessage.ShowSavedMsg("Data konsumen " & Trim(tbAccountInstagram.Text))

                            Call SetCboKupon(CONN_.dbMain, CONN_.comm, CONN_.reader)
                            Call btnTampilkan_Click(sender, e)
                            'Call myCFormManipulation.ResetForm(gbDataEntry)
                            Call btnCreateNew_Click(sender, e)
                        Else
                            'Kupon tersebut sudah terpakai
                            Call myCShowMessage.ShowWarning("Kupon " & cboKupon.SelectedValue & " sudah terpakai!")
                            Call SetCboKupon(CONN_.dbMain, CONN_.comm, CONN_.reader)
                        End If
                    Else
                        'Kalau account Instagramnya sudah ada, maka cukup update kuponnya aja
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(0), ADD_INFO_.updateString, "accountinstagram ='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'")
                        Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(1), "terpakai='True',accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'," & ADD_INFO_.updateString, "kupon='" & myCStringManipulation.SafeSqlLiteral(cboKupon.SelectedValue) & "' AND terpakai='False'")

                        Call myCShowMessage.ShowSavedMsg("Kupon " & cboKupon.SelectedValue & " berhasil ditambahkan ke konsumen " & Trim(tbAccountInstagram.Text))

                        cboKupon.SelectedIndex = -1
                        Call SetCboKupon(CONN_.dbMain, CONN_.comm, CONN_.reader)
                        Call btnTampilkan_Click(sender, e)
                        Call btnCreateNew_Click(sender, e)
                        dgvView.CurrentCell = dgvView.Item(0, 0)
                        dgvView.Rows(0).Selected = True
                        Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, dgvKupon, myDataTableDGVKupon, myBindingTableDGVKupon, myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("accountinstagram").Value), "LIHAT KUPON", True)
                    End If
                Else
                    'UDPATE
                    'Dim foundRows() As DataRow
                    Dim queryBuilder As New Text.StringBuilder
                    updateString = Nothing
                    'foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0) & " AND kupon='" & arrDefValues(3) & "'")
                    'foundRows = myDataTableDGV.Select("rid=" & arrDefValues(0))
                    queryBuilder.Clear()
                    If (arrDefValues(1) <> Trim(tbAccountInstagram.Text)) Then
                        'PER 29 AGUSTUS 2022 ACCOUNT INSTAGRAM TIDAK BOLEH DI EDIT
                        isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'")
                        If Not isExist Then
                            updateString &= IIf(IsNothing(updateString), "", ",") & "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'"
                            'If (foundRows.Length > 0) Then
                            '    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("accountinstagram") = Trim(tbAccountInstagram.Text)
                            'End If
                        Else
                            Dim cekBanyaknya As Integer
                            cekBanyaknya = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(1), "Count", "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(1)) & "'", CONN_.dbType)
                            If (cekBanyaknya > 1) Then
                                'Jika ada lebih dari 1 kupon yang dimiliki oleh account instagram sebelumnya, maka data konsumen tidak akan dihapus, tidak akan dilakukan apapun
                            Else
                                'Jika hanya 1 kupon yang dimiliki oleh account instagram yang lama, maka data akan dihapus
                                queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableName(0), "",, "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(1)) & "'"))
                            End If
                        End If
                        queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(1), "terpakai='True',accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'",, "kupon='" & arrDefValues(3) & "' AND terpakai='True' AND accountinstagram='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(1)) & "'"))
                    End If
                    If (arrDefValues(2) <> Trim(tbNomorWA.Text)) Then
                        updateString &= IIf(IsNothing(updateString), "", ",") & "nomorwa=" & IIf(Trim(tbNomorWA.Text).Length = 0, "Null", "'" & myCStringManipulation.SafeSqlLiteral(tbNomorWA.Text) & "'")
                        'If (foundRows.Length > 0) Then
                        '    myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("nomorwa") = Trim(tbNomorWA.Text)
                        'End If
                    End If
                    'If (arrDefValues(3) <> cboKupon.SelectedValue) Then
                    '   KUPON TIDAK BOLEH DI EDIT!!
                    '    'Jika kuponnya juga diganti
                    '    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(1), "kupon='" & myCStringManipulation.SafeSqlLiteral(cboKupon.SelectedValue) & "' AND terpakai='True' AND accountinstagram<>'" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'")
                    '    If Not isExist Then
                    '        queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(1), "terpakai='False',accountinstagram=Null",, "kupon='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(3)) & "'"))
                    '        queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(1), "terpakai='True',accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'",, "kupon='" & myCStringManipulation.SafeSqlLiteral(cboKupon.SelectedValue) & "' AND terpakai='True' AND accountinstagram='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(1)) & "'"))
                    '        If (foundRows.Length > 0) Then
                    '            myDataTableDGV.Rows(myDataTableDGV.Rows.IndexOf(foundRows(0))).Item("kupon") = cboKupon.SelectedValue
                    '        End If
                    '    Else
                    '        Call myCShowMessage.ShowWarning("Sudah ada data di master konsumen, konsumen lain yang menggunakan kupon " & cboKupon.SelectedValue & " !!")
                    '        'Kuponnya dikembalikan ke sebelumnya, hanya dilakukan pengecekkan apakah account instagramnya diganti, kalau tidak diganti, maka tidak perlu dilakukan apapun
                    '        If (arrDefValues(1) <> Trim(tbAccountInstagram.Text)) Then
                    '            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(1), "terpakai='True',accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'",, "kupon='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(3)) & "'"))
                    '        End If
                    '    End If
                    'End If

                    If Not IsNothing(updateString) Or queryBuilder.Length > 0 Then
                        If Not IsNothing(updateString) Then
                            updateString &= "," & ADD_INFO_.updateString
                            queryBuilder.Append(myCStringManipulation.QueryBuilder("update", tableName(0), updateString,, "rid=" & arrDefValues(0)))
                        End If
                        If myCDBOperation.TransactionData(CONN_.dbMain, CONN_.comm, CONN_.transaction, queryBuilder.ToString) Then
                            Call myCShowMessage.ShowUpdatedMsg("Data konsumen " & Trim(tbAccountInstagram.Text) & " dengan kupon " & cboKupon.SelectedValue)
                        Else
                            Call myCShowMessage.ShowWarning("Data gagal diupdate!!")
                        End If
                        Call myCFormManipulation.ResetForm(gbDataEntry)
                        Call btnTampilkan_Click(sender, e)
                        Call btnCreateNew_Click(sender, e)
                    Else
                        Call myCShowMessage.ShowInfo("Tidak ada data yang dirubah dan perlu dilakukan update ke server")
                    End If
                End If
                Call myCFormManipulation.SetButtonSimpanAvailabilty(btnSimpan, clbUserRight, "save")
            Else
                Call myCShowMessage.ShowWarning("Lengkapi dulu semua fields yang bertanda bintang (*) !")
                tbAccountInstagram.Focus()
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnSimpan_Click Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub btnCariKonsumen_Click(sender As Object, e As EventArgs) Handles btnCariKonsumen.Click
        Try
            mCari = myCStringManipulation.SafeSqlLiteral(tbCariKonsumen.Text, 1)
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, dgvCariKonsumen, myDataTableDGVKonsumen, myBindingTableDGVKonsumen, mCari, "CARI KONSUMEN", True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnCariKonsumen_Click Error")
        End Try
    End Sub

    Private Sub dgvCariKonsumen_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCariKonsumen.CellContentDoubleClick
        Try
            If (dgvCariKonsumen.RowCount > 0) Then
                If (e.RowIndex = -1) Then
                    Exit Sub
                End If

                With dgvCariKonsumen
                    'Account Instagram
                    If Not IsDBNull(.CurrentRow.Cells("accountinstagram").Value) Then
                        tbAccountInstagram.Text = .CurrentRow.Cells("accountinstagram").Value
                    End If
                    'Kode
                    If Not IsDBNull(.CurrentRow.Cells("nomorwa").Value) Then
                        tbNomorWA.Text = .CurrentRow.Cells("nomorwa").Value
                    End If
                End With

                Call btnCreateNew_Click(sender, e)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvCariKonsumen_CellContentClick Error")
        End Try
    End Sub

    Private Sub SetCboKupon(_conn As Object, _comm As Object, _reader As Object)
        Try
            stSQL = "SELECT kupon FROM " & tableName(1) & " WHERE terpakai='False' and accountinstagram is null ORDER BY rid;"
            Call myCDBOperation.SetCbo_(_conn, _comm, _reader, stSQL, myDataTableCboKupon, myBindingKupon, cboKupon, "T_" & cboCariKategori.Name, "kupon", "kupon", isCboPrepared, True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "GetKupon Error")
        End Try
    End Sub

    Private Sub cboFields_Validated(sender As Object, e As EventArgs) Handles cboKupon.Validated
        Try
            If (isDataPrepared) Then
                If (Trim(sender.Text).Length = 0) Then
                    sender.SelectedIndex = -1
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "cboFields_Validated Error")
        End Try
    End Sub

    Private Sub tbAutoCapital_Validated(sender As Object, e As EventArgs) Handles tbAccountInstagram.Validated, tbNomorWA.Validated
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            sender.text = sender.text.ToString.ToUpper

            If (sender Is tbAccountInstagram) Then
                If (isNew) And Trim(tbNomorWA.Text).Length = 0 Then
                    tbNomorWA.Clear()
                    tbNomorWA.Text = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "nomorwa", tableName(0),, "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'", CONN_.dbType)
                End If
                'If Not (isNew) Then
                '    arrDefValues(0) = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0),, "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'", CONN_.dbType)
                '    arrDefValues(1) = Trim(tbAccountInstagram.Text)
                '    arrDefValues(2) = Trim(tbNomorWA.Text)
                '    arrDefValues(3) = cboKupon.Text
                'End If
            ElseIf (sender Is tbNomorWA) Then
                If (isNew) Then
                    'tbAccountInstagram.Clear()
                    'tbAccountInstagram.Text = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "accountinstagram", tableName(0),, "nomorwa='" & myCStringManipulation.SafeSqlLiteral(tbNomorWA.Text) & "'", CONN_.dbType)
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "nomorwa='" & myCStringManipulation.SafeSqlLiteral(tbNomorWA.Text) & "' AND accountinstagram<>'" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'")
                    If isExist Then
                        Dim tmpInstagram As String
                        tmpInstagram = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "accountinstagram", tableName(0),, "nomorwa='" & myCStringManipulation.SafeSqlLiteral(tbNomorWA.Text) & "' AND accountinstagram<>'" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'", CONN_.dbType)
                        If (Trim(tbAccountInstagram.Text).Length > 0) Then
                            Call myCShowMessage.ShowWarning("Nomor WA " & Trim(tbNomorWA.Text) & " sudah terdaftar di akun instagram " & tmpInstagram)
                            tbNomorWA.Clear()
                        Else
                            tbAccountInstagram.Text = tmpInstagram
                        End If
                    End If
                Else
                    isExist = myCDBOperation.IsExistRecords(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(0), "nomorwa='" & myCStringManipulation.SafeSqlLiteral(tbNomorWA.Text) & "' AND accountinstagram<>'" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'")
                    If isExist Then
                        Dim tmpInstagram As String
                        tmpInstagram = myCDBOperation.GetSpecificRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "accountinstagram", tableName(0),, "nomorwa='" & myCStringManipulation.SafeSqlLiteral(tbNomorWA.Text) & "' AND accountinstagram<>'" & myCStringManipulation.SafeSqlLiteral(tbAccountInstagram.Text) & "'", CONN_.dbType)
                        Call myCShowMessage.ShowWarning("Nomor WA " & Trim(tbNomorWA.Text) & " sudah terdaftar di akun instagram " & tmpInstagram)
                        tbNomorWA.Text = arrDefValues(3)
                    End If
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbAutoCapital_Validated Error")
        Finally
            Me.Cursor = Cursors.Default
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
        End Try
    End Sub

    Private Sub dgvKupon_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvKupon.CellContentClick
        Try
            If (e.ColumnIndex = dgvKupon.Columns("delete").Index) Then
                Me.Cursor = Cursors.WaitCursor
                Call myCDBConnection.OpenConn(CONN_.dbMain)

                Dim isConfirm = myCShowMessage.GetUserResponse("Apakah mau menghapus data kupon " & dgvKupon.CurrentRow.Cells("kupon").Value & " untuk konsumen " & dgvView.CurrentRow.Cells("accountinstagram").Value & "?" & ControlChars.NewLine & "Data yang sudah dihapus tidak dapat dikembalikan lagi!")
                If (isConfirm = DialogResult.Yes) Then
                    Call myCDBOperation.UpdateData(CONN_.dbMain, CONN_.comm, tableName(1), "terpakai='False',accountinstagram=Null," & ADD_INFO_.updateString, "kupon='" & myCStringManipulation.SafeSqlLiteral(dgvKupon.CurrentRow.Cells("kupon").Value) & "'")

                    'Dim cekBanyaknya As Integer
                    'cekBanyaknya = myCDBOperation.GetFormulationRecord(CONN_.dbMain, CONN_.comm, CONN_.reader, "rid", tableName(1), "Count", "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("accountinstagram").Value) & "'", CONN_.dbType)
                    'If (cekBanyaknya > 1) Then
                    '    'Jika ada lebih dari 1 kupon yang dimiliki oleh account instagram sebelumnya, maka data konsumen tidak akan dihapus, tidak akan dilakukan apapun
                    'Else
                    '    'Jika hanya 1 kupon yang dimiliki oleh account instagram yang lama, maka data konsumen akan dihapus
                    '    queryBuilder.Append(myCStringManipulation.QueryBuilder("delete", tableName(0), "",, "accountinstagram='" & myCStringManipulation.SafeSqlLiteral(arrDefValues(1)) & "'"))
                    'End If
                    'Call myCDBOperation.DelDbRecords(CONN_.dbMain, CONN_.comm, tableName(0), "rid=" & dgvView.CurrentRow.Cells("rid").Value, CONN_.dbType)
                    'Call myCShowMessage.ShowDeletedMsg("Data di master general dengan keterangan " & dgvView.CurrentRow.Cells("keterangan").Value & " untuk kategori " & dgvView.CurrentRow.Cells("kategori").Value)
                    Call SetCboKupon(CONN_.dbMain, CONN_.comm, CONN_.reader)
                    mCari = myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("accountinstagram").Value)
                    Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, dgvKupon, myDataTableDGVKupon, myBindingTableDGVKupon, mCari, "LIHAT KUPON", True)

                    dgvView.CurrentRow.Cells("jumlahkupon").Value = dgvView.CurrentRow.Cells("jumlahkupon").Value - 1
                    'Call btnTampilkan_Click(btnTampilkan, e)
                    'Dim foundRows As DataRow()
                    'foundRows = myDataTableDGVKonsumen.Select("accountinstagram='" & Trim(dgvView.CurrentRow.Cells("accountinstagram").Value) & "'")
                Else
                    Call myCShowMessage.ShowInfo("Penghapusan data konsumen " & dgvView.CurrentRow.Cells("accountinstagram").Value & " untuk kupon " & dgvKupon.CurrentRow.Cells("kupon").Value)
                End If
                Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvKupon_CellContentClick Error")
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvView_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellClick
        Try
            Call SetDGV(CONN_.dbMain, CONN_.comm, CONN_.reader, 10, dgvKupon, myDataTableDGVKupon, myBindingTableDGVKupon, myCStringManipulation.SafeSqlLiteral(dgvView.CurrentRow.Cells("accountinstagram").Value), "LIHAT KUPON", True)
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "dgvView_CellClick Error")
        End Try
    End Sub

    Private Sub tbPathSimpan_Click(sender As System.Object, e As System.EventArgs) Handles tbPathSimpan.Click
        Try
            fbdExport.ShowDialog()
            'di cek apakah char terakhir pada string path adalah \ atw gak
            'klw gak, maka harus dikasih \, kalau sudah ada, misal kalau user pilih lokasi di C:\, maka tidak ditambahi \ lagi
            If (fbdExport.SelectedPath.Length > 0) Then
                If (fbdExport.SelectedPath.Chars(fbdExport.SelectedPath.Count - 1) <> "\") Then
                    tbPathSimpan.Text = fbdExport.SelectedPath & "\"
                Else
                    tbPathSimpan.Text = fbdExport.SelectedPath
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "tbPathSimpan_Click Error")
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Try
            fbdExport.ShowDialog()
            'di cek apakah char terakhir pada string path adalah \ atw gak
            'klw gak, maka harus dikasih \, kalau sudah ada, misal kalau user pilih lokasi di C:\, maka tidak ditambahi \ lagi
            If (fbdExport.SelectedPath.Length > 0) Then
                If (fbdExport.SelectedPath.Chars(fbdExport.SelectedPath.Count - 1) <> "\") Then
                    tbPathSimpan.Text = fbdExport.SelectedPath & "\"
                Else
                    tbPathSimpan.Text = fbdExport.SelectedPath
                End If
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error: " & ex.Message, "btnBrowse_Click Error")
        End Try
    End Sub

    Private Sub btnCetakExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExportExcel.Click
        Try
            Me.Cursor = Cursors.WaitCursor
            Call myCDBConnection.OpenConn(CONN_.dbMain)

            Dim b As String
            Dim xlspath As String
            Dim xlsfilename As String
            Dim myDataTableExcel As New DataTable
            Dim sheetName As String

            xlspath = tbPathSimpan.Text
            b = tbNamaSimpan.Text

            If (xlspath.Length > 0) Then
                xlsfilename = xlspath & b & "_" & Format(Now(), "ddMMMyyyy")
                sheetName = "Kupon_" & Format(Now(), "ddMMMyyyy")

                stSQL = "SELECT tbl.rid,tbl.nik,tbl.nama,tbl.accountinstagram,tbl.nomorwa,subtbl.jumlahkupon,tbl2.kupon,tbl.created_at,tbl.updated_at 
		                FROM promotion.mskonsumen AS tbl 
		                INNER JOIN promotion.msmasterkuponundian AS tbl2 ON tbl.accountinstagram = tbl2.accountinstagram 
		                INNER JOIN (SELECT tbl.accountinstagram,tbl.nomorwa,COUNT ( tbl2.kupon ) AS jumlahkupon
			                FROM promotion.mskonsumen AS tbl INNER JOIN promotion.msmasterkuponundian AS tbl2 ON tbl.accountinstagram = tbl2.accountinstagram 
			                WHERE	( ( UPPER ( tbl.accountinstagram ) LIKE'%%' ) ) 
			                GROUP BY tbl.accountinstagram,tbl.nomorwa
			                ORDER BY( CASE WHEN tbl.updated_at IS NULL THEN tbl.created_at ELSE tbl.updated_at END ) DESC,tbl.rid DESC) as subtbl on subtbl.accountinstagram=tbl.accountinstagram		
		                WHERE	( ( UPPER ( tbl.accountinstagram ) LIKE'%%' ) ) 
		                GROUP BY tbl.rid,tbl.nik,tbl.nama,tbl.accountinstagram,tbl.nomorwa,subtbl.jumlahkupon,tbl2.kupon,tbl.created_at,tbl.updated_at 
		                ORDER BY ( CASE WHEN tbl.updated_at IS NULL THEN tbl.created_at ELSE tbl.updated_at END ) DESC,	tbl.rid DESC;"
                myDataTableExcel = myCDBOperation.GetDataTableUsingReader(CONN_.dbMain, CONN_.comm, CONN_.reader, stSQL, "T_DetailPromotion")

                Call myCFileIO.PopulateSheet(myDataTableExcel, xlsfilename, sheetName)

                'Call myCFileIO.ExportDataGridViewToExcel(dgvView, xlsfilename, "EXPORT EXCEL")

                Call myCShowMessage.ShowInfo(" Export ke excel sukses, dengan nama " & xlsfilename & ".xls", "Export Complete")
            Else
                Call myCShowMessage.ShowWarning("Silahkan pilih terlebih dahulu lokasi untuk menyimpan file", "Perhatian")
            End If
        Catch ex As Exception
            Call myCShowMessage.ShowErrMsg("Pesan Error:  " & ex.Message, "btnCetakExcel_Click Error")
        Finally
            Call myCDBConnection.CloseConn(CONN_.dbMain, -1)
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class
