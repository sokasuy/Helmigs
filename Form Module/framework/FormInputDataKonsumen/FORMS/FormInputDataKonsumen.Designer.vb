<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInputDataKonsumen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInputDataKonsumen))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblEntryType = New System.Windows.Forms.Label()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.gbDataEntry = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.lblNomorWa = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboKupon = New System.Windows.Forms.ComboBox()
        Me.lblKategori = New System.Windows.Forms.Label()
        Me.tbAccountInstagram = New System.Windows.Forms.TextBox()
        Me.tbNomorWA = New System.Windows.Forms.TextBox()
        Me.lblAccountInstagram = New System.Windows.Forms.Label()
        Me.gbCariKonsumen = New System.Windows.Forms.GroupBox()
        Me.btnCariKonsumen = New System.Windows.Forms.Button()
        Me.cboKriteriaKonsumen = New System.Windows.Forms.ComboBox()
        Me.dgvCariKonsumen = New System.Windows.Forms.DataGridView()
        Me.tbCariKonsumen = New System.Windows.Forms.TextBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.dgvKupon = New System.Windows.Forms.DataGridView()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.lblCariKategori = New System.Windows.Forms.Label()
        Me.cboCariKategori = New System.Windows.Forms.ComboBox()
        Me.pnlNavigasi = New System.Windows.Forms.Panel()
        Me.btnAddNew = New System.Windows.Forms.Button()
        Me.btnFFBack = New System.Windows.Forms.Button()
        Me.lblRecord = New System.Windows.Forms.Label()
        Me.btnForward = New System.Windows.Forms.Button()
        Me.lblOfPages = New System.Windows.Forms.Label()
        Me.tbRecordPage = New System.Windows.Forms.TextBox()
        Me.btnFFForward = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnExportExcel = New System.Windows.Forms.Button()
        Me.tbNamaSimpan = New System.Windows.Forms.TextBox()
        Me.tbPathSimpan = New System.Windows.Forms.TextBox()
        Me.lblNamaSimpan = New System.Windows.Forms.Label()
        Me.lblSimpanKeDrive = New System.Windows.Forms.Label()
        Me.pnlExportExcel = New System.Windows.Forms.Panel()
        Me.fbdExport = New System.Windows.Forms.FolderBrowserDialog()
        Me.gbDataEntry.SuspendLayout()
        Me.gbCariKonsumen.SuspendLayout()
        CType(Me.dgvCariKonsumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbView.SuspendLayout()
        CType(Me.dgvKupon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigasi.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlExportExcel.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.PowderBlue
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.Location = New System.Drawing.Point(0, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(984, 25)
        Me.lblTitle.TabIndex = 181
        Me.lblTitle.Text = "INPUT DATA KONSUMEN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEntryType
        '
        Me.lblEntryType.AutoSize = True
        Me.lblEntryType.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblEntryType.ForeColor = System.Drawing.Color.Red
        Me.lblEntryType.Location = New System.Drawing.Point(709, 28)
        Me.lblEntryType.Name = "lblEntryType"
        Me.lblEntryType.Size = New System.Drawing.Size(107, 21)
        Me.lblEntryType.TabIndex = 201
        Me.lblEntryType.Text = "INSERT NEW"
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(822, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 200
        '
        'gbDataEntry
        '
        Me.gbDataEntry.Controls.Add(Me.Label1)
        Me.gbDataEntry.Controls.Add(Me.btnCreateNew)
        Me.gbDataEntry.Controls.Add(Me.lblNomorWa)
        Me.gbDataEntry.Controls.Add(Me.btnSimpan)
        Me.gbDataEntry.Controls.Add(Me.Label2)
        Me.gbDataEntry.Controls.Add(Me.cboKupon)
        Me.gbDataEntry.Controls.Add(Me.lblKategori)
        Me.gbDataEntry.Controls.Add(Me.tbAccountInstagram)
        Me.gbDataEntry.Controls.Add(Me.tbNomorWA)
        Me.gbDataEntry.Controls.Add(Me.lblAccountInstagram)
        Me.gbDataEntry.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.gbDataEntry.Location = New System.Drawing.Point(12, 183)
        Me.gbDataEntry.Name = "gbDataEntry"
        Me.gbDataEntry.Size = New System.Drawing.Size(523, 151)
        Me.gbDataEntry.TabIndex = 199
        Me.gbDataEntry.TabStop = False
        Me.gbDataEntry.Text = "DATA ENTRY"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(396, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(12, 15)
        Me.Label1.TabIndex = 217
        Me.Label1.Text = "*"
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnCreateNew.Image = CType(resources.GetObject("btnCreateNew.Image"), System.Drawing.Image)
        Me.btnCreateNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateNew.Location = New System.Drawing.Point(270, 94)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(120, 54)
        Me.btnCreateNew.TabIndex = 7
        Me.btnCreateNew.Text = "BUAT BARU"
        Me.btnCreateNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'lblNomorWa
        '
        Me.lblNomorWa.AutoSize = True
        Me.lblNomorWa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblNomorWa.Location = New System.Drawing.Point(39, 43)
        Me.lblNomorWa.Name = "lblNomorWa"
        Me.lblNomorWa.Size = New System.Drawing.Size(73, 15)
        Me.lblNomorWa.TabIndex = 216
        Me.lblNomorWa.Text = "Nomor WA :"
        '
        'btnSimpan
        '
        Me.btnSimpan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.Location = New System.Drawing.Point(396, 94)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 54)
        Me.btnSimpan.TabIndex = 8
        Me.btnSimpan.Text = "SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(421, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(12, 15)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "*"
        '
        'cboKupon
        '
        Me.cboKupon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKupon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKupon.FormattingEnabled = True
        Me.cboKupon.IntegralHeight = False
        Me.cboKupon.Location = New System.Drawing.Point(126, 65)
        Me.cboKupon.Name = "cboKupon"
        Me.cboKupon.Size = New System.Drawing.Size(153, 23)
        Me.cboKupon.TabIndex = 6
        '
        'lblKategori
        '
        Me.lblKategori.AutoSize = True
        Me.lblKategori.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblKategori.Location = New System.Drawing.Point(42, 68)
        Me.lblKategori.Name = "lblKategori"
        Me.lblKategori.Size = New System.Drawing.Size(78, 15)
        Me.lblKategori.TabIndex = 210
        Me.lblKategori.Text = "Kode Kupon :"
        '
        'tbAccountInstagram
        '
        Me.tbAccountInstagram.Location = New System.Drawing.Point(126, 16)
        Me.tbAccountInstagram.Name = "tbAccountInstagram"
        Me.tbAccountInstagram.Size = New System.Drawing.Size(289, 23)
        Me.tbAccountInstagram.TabIndex = 4
        '
        'tbNomorWA
        '
        Me.tbNomorWA.Location = New System.Drawing.Point(126, 41)
        Me.tbNomorWA.Name = "tbNomorWA"
        Me.tbNomorWA.Size = New System.Drawing.Size(264, 23)
        Me.tbNomorWA.TabIndex = 5
        '
        'lblAccountInstagram
        '
        Me.lblAccountInstagram.AutoSize = True
        Me.lblAccountInstagram.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.lblAccountInstagram.Location = New System.Drawing.Point(6, 19)
        Me.lblAccountInstagram.Name = "lblAccountInstagram"
        Me.lblAccountInstagram.Size = New System.Drawing.Size(114, 15)
        Me.lblAccountInstagram.TabIndex = 214
        Me.lblAccountInstagram.Text = "Account Instagram :"
        '
        'gbCariKonsumen
        '
        Me.gbCariKonsumen.Controls.Add(Me.btnCariKonsumen)
        Me.gbCariKonsumen.Controls.Add(Me.cboKriteriaKonsumen)
        Me.gbCariKonsumen.Controls.Add(Me.dgvCariKonsumen)
        Me.gbCariKonsumen.Controls.Add(Me.tbCariKonsumen)
        Me.gbCariKonsumen.Location = New System.Drawing.Point(12, 28)
        Me.gbCariKonsumen.Name = "gbCariKonsumen"
        Me.gbCariKonsumen.Size = New System.Drawing.Size(523, 149)
        Me.gbCariKonsumen.TabIndex = 202
        Me.gbCariKonsumen.TabStop = False
        Me.gbCariKonsumen.Text = "CARI KONSUMEN"
        '
        'btnCariKonsumen
        '
        Me.btnCariKonsumen.Location = New System.Drawing.Point(372, 19)
        Me.btnCariKonsumen.Name = "btnCariKonsumen"
        Me.btnCariKonsumen.Size = New System.Drawing.Size(75, 23)
        Me.btnCariKonsumen.TabIndex = 3
        Me.btnCariKonsumen.Text = "CARI"
        Me.btnCariKonsumen.UseVisualStyleBackColor = True
        '
        'cboKriteriaKonsumen
        '
        Me.cboKriteriaKonsumen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteriaKonsumen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteriaKonsumen.FormattingEnabled = True
        Me.cboKriteriaKonsumen.IntegralHeight = False
        Me.cboKriteriaKonsumen.Location = New System.Drawing.Point(6, 19)
        Me.cboKriteriaKonsumen.Name = "cboKriteriaKonsumen"
        Me.cboKriteriaKonsumen.Size = New System.Drawing.Size(159, 21)
        Me.cboKriteriaKonsumen.TabIndex = 1
        '
        'dgvCariKonsumen
        '
        Me.dgvCariKonsumen.AllowUserToAddRows = False
        Me.dgvCariKonsumen.AllowUserToDeleteRows = False
        Me.dgvCariKonsumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCariKonsumen.Location = New System.Drawing.Point(6, 47)
        Me.dgvCariKonsumen.Name = "dgvCariKonsumen"
        Me.dgvCariKonsumen.Size = New System.Drawing.Size(511, 96)
        Me.dgvCariKonsumen.TabIndex = 217
        '
        'tbCariKonsumen
        '
        Me.tbCariKonsumen.Location = New System.Drawing.Point(171, 19)
        Me.tbCariKonsumen.Name = "tbCariKonsumen"
        Me.tbCariKonsumen.Size = New System.Drawing.Size(195, 20)
        Me.tbCariKonsumen.TabIndex = 2
        '
        'btnKeluar
        '
        Me.btnKeluar.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(802, 98)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 54)
        Me.btnKeluar.TabIndex = 14
        Me.btnKeluar.Text = "KELUAR"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'gbView
        '
        Me.gbView.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.dgvKupon)
        Me.gbView.Controls.Add(Me.lblSorting)
        Me.gbView.Controls.Add(Me.cboSortingType)
        Me.gbView.Controls.Add(Me.cboSortingCriteria)
        Me.gbView.Controls.Add(Me.lblCariKategori)
        Me.gbView.Controls.Add(Me.cboCariKategori)
        Me.gbView.Controls.Add(Me.pnlNavigasi)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 340)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(960, 370)
        Me.gbView.TabIndex = 202
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
        '
        'dgvKupon
        '
        Me.dgvKupon.AllowUserToAddRows = False
        Me.dgvKupon.AllowUserToDeleteRows = False
        Me.dgvKupon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvKupon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvKupon.Location = New System.Drawing.Point(659, 67)
        Me.dgvKupon.Name = "dgvKupon"
        Me.dgvKupon.Size = New System.Drawing.Size(295, 263)
        Me.dgvKupon.TabIndex = 185
        '
        'lblSorting
        '
        Me.lblSorting.AutoSize = True
        Me.lblSorting.Location = New System.Drawing.Point(432, 22)
        Me.lblSorting.Name = "lblSorting"
        Me.lblSorting.Size = New System.Drawing.Size(46, 13)
        Me.lblSorting.TabIndex = 184
        Me.lblSorting.Text = "Sorting :"
        '
        'cboSortingType
        '
        Me.cboSortingType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSortingType.FormattingEnabled = True
        Me.cboSortingType.Location = New System.Drawing.Point(557, 40)
        Me.cboSortingType.Name = "cboSortingType"
        Me.cboSortingType.Size = New System.Drawing.Size(91, 21)
        Me.cboSortingType.TabIndex = 13
        '
        'cboSortingCriteria
        '
        Me.cboSortingCriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSortingCriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSortingCriteria.FormattingEnabled = True
        Me.cboSortingCriteria.IntegralHeight = False
        Me.cboSortingCriteria.Location = New System.Drawing.Point(435, 40)
        Me.cboSortingCriteria.Name = "cboSortingCriteria"
        Me.cboSortingCriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboSortingCriteria.TabIndex = 12
        '
        'lblCariKategori
        '
        Me.lblCariKategori.AutoSize = True
        Me.lblCariKategori.Location = New System.Drawing.Point(3, 22)
        Me.lblCariKategori.Name = "lblCariKategori"
        Me.lblCariKategori.Size = New System.Drawing.Size(52, 13)
        Me.lblCariKategori.TabIndex = 178
        Me.lblCariKategori.Text = "Kategori :"
        '
        'cboCariKategori
        '
        Me.cboCariKategori.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCariKategori.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCariKategori.FormattingEnabled = True
        Me.cboCariKategori.IntegralHeight = False
        Me.cboCariKategori.Location = New System.Drawing.Point(6, 40)
        Me.cboCariKategori.Name = "cboCariKategori"
        Me.cboCariKategori.Size = New System.Drawing.Size(109, 21)
        Me.cboCariKategori.TabIndex = 9
        '
        'pnlNavigasi
        '
        Me.pnlNavigasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlNavigasi.Controls.Add(Me.btnAddNew)
        Me.pnlNavigasi.Controls.Add(Me.btnFFBack)
        Me.pnlNavigasi.Controls.Add(Me.lblRecord)
        Me.pnlNavigasi.Controls.Add(Me.btnForward)
        Me.pnlNavigasi.Controls.Add(Me.lblOfPages)
        Me.pnlNavigasi.Controls.Add(Me.tbRecordPage)
        Me.pnlNavigasi.Controls.Add(Me.btnFFForward)
        Me.pnlNavigasi.Controls.Add(Me.btnBack)
        Me.pnlNavigasi.Location = New System.Drawing.Point(6, 334)
        Me.pnlNavigasi.Name = "pnlNavigasi"
        Me.pnlNavigasi.Size = New System.Drawing.Size(425, 29)
        Me.pnlNavigasi.TabIndex = 172
        '
        'btnAddNew
        '
        Me.btnAddNew.Enabled = False
        Me.btnAddNew.Location = New System.Drawing.Point(280, 3)
        Me.btnAddNew.Name = "btnAddNew"
        Me.btnAddNew.Size = New System.Drawing.Size(31, 23)
        Me.btnAddNew.TabIndex = 169
        Me.btnAddNew.Text = ">*"
        Me.btnAddNew.UseVisualStyleBackColor = True
        '
        'btnFFBack
        '
        Me.btnFFBack.Location = New System.Drawing.Point(56, 3)
        Me.btnFFBack.Name = "btnFFBack"
        Me.btnFFBack.Size = New System.Drawing.Size(31, 23)
        Me.btnFFBack.TabIndex = 164
        Me.btnFFBack.Text = "<<"
        Me.btnFFBack.UseVisualStyleBackColor = True
        '
        'lblRecord
        '
        Me.lblRecord.AutoSize = True
        Me.lblRecord.Location = New System.Drawing.Point(2, 8)
        Me.lblRecord.Name = "lblRecord"
        Me.lblRecord.Size = New System.Drawing.Size(38, 13)
        Me.lblRecord.TabIndex = 163
        Me.lblRecord.Text = "Page :"
        '
        'btnForward
        '
        Me.btnForward.Location = New System.Drawing.Point(206, 3)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(31, 23)
        Me.btnForward.TabIndex = 167
        Me.btnForward.Text = ">"
        Me.btnForward.UseVisualStyleBackColor = True
        '
        'lblOfPages
        '
        Me.lblOfPages.AutoSize = True
        Me.lblOfPages.Location = New System.Drawing.Point(317, 8)
        Me.lblOfPages.Name = "lblOfPages"
        Me.lblOfPages.Size = New System.Drawing.Size(65, 13)
        Me.lblOfPages.TabIndex = 170
        Me.lblOfPages.Text = "Of : x Pages"
        '
        'tbRecordPage
        '
        Me.tbRecordPage.Location = New System.Drawing.Point(130, 5)
        Me.tbRecordPage.Name = "tbRecordPage"
        Me.tbRecordPage.Size = New System.Drawing.Size(70, 20)
        Me.tbRecordPage.TabIndex = 166
        Me.tbRecordPage.Text = "1"
        Me.tbRecordPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnFFForward
        '
        Me.btnFFForward.Location = New System.Drawing.Point(243, 3)
        Me.btnFFForward.Name = "btnFFForward"
        Me.btnFFForward.Size = New System.Drawing.Size(31, 23)
        Me.btnFFForward.TabIndex = 168
        Me.btnFFForward.Text = ">>"
        Me.btnFFForward.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(93, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(31, 23)
        Me.btnBack.TabIndex = 165
        Me.btnBack.Text = "<"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(243, 40)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(186, 20)
        Me.tbCari.TabIndex = 11
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(659, 10)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 14
        Me.btnTampilkan.Text = "TAMPILKAN"
        Me.btnTampilkan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTampilkan.UseVisualStyleBackColor = True
        '
        'lblCari
        '
        Me.lblCari.AutoSize = True
        Me.lblCari.Location = New System.Drawing.Point(118, 24)
        Me.lblCari.Name = "lblCari"
        Me.lblCari.Size = New System.Drawing.Size(45, 13)
        Me.lblCari.TabIndex = 132
        Me.lblCari.Text = "Kriteria :"
        '
        'cboKriteria
        '
        Me.cboKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboKriteria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboKriteria.FormattingEnabled = True
        Me.cboKriteria.IntegralHeight = False
        Me.cboKriteria.Location = New System.Drawing.Point(121, 40)
        Me.cboKriteria.Name = "cboKriteria"
        Me.cboKriteria.Size = New System.Drawing.Size(116, 21)
        Me.cboKriteria.TabIndex = 10
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 67)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(647, 263)
        Me.dgvView.TabIndex = 130
        '
        'btnBrowse
        '
        Me.btnBrowse.Image = CType(resources.GetObject("btnBrowse.Image"), System.Drawing.Image)
        Me.btnBrowse.Location = New System.Drawing.Point(277, 6)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(24, 24)
        Me.btnBrowse.TabIndex = 204
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnExportExcel
        '
        Me.btnExportExcel.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnExportExcel.Image = CType(resources.GetObject("btnExportExcel.Image"), System.Drawing.Image)
        Me.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportExcel.Location = New System.Drawing.Point(306, 8)
        Me.btnExportExcel.Name = "btnExportExcel"
        Me.btnExportExcel.Size = New System.Drawing.Size(120, 54)
        Me.btnExportExcel.TabIndex = 206
        Me.btnExportExcel.Text = "EXCEL"
        Me.btnExportExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportExcel.UseVisualStyleBackColor = True
        '
        'tbNamaSimpan
        '
        Me.tbNamaSimpan.Location = New System.Drawing.Point(101, 36)
        Me.tbNamaSimpan.Name = "tbNamaSimpan"
        Me.tbNamaSimpan.Size = New System.Drawing.Size(199, 20)
        Me.tbNamaSimpan.TabIndex = 205
        '
        'tbPathSimpan
        '
        Me.tbPathSimpan.Location = New System.Drawing.Point(101, 8)
        Me.tbPathSimpan.Name = "tbPathSimpan"
        Me.tbPathSimpan.Size = New System.Drawing.Size(172, 20)
        Me.tbPathSimpan.TabIndex = 203
        '
        'lblNamaSimpan
        '
        Me.lblNamaSimpan.AutoSize = True
        Me.lblNamaSimpan.Location = New System.Drawing.Point(16, 39)
        Me.lblNamaSimpan.Name = "lblNamaSimpan"
        Me.lblNamaSimpan.Size = New System.Drawing.Size(79, 13)
        Me.lblNamaSimpan.TabIndex = 208
        Me.lblNamaSimpan.Text = "Nama Simpan :"
        '
        'lblSimpanKeDrive
        '
        Me.lblSimpanKeDrive.AutoSize = True
        Me.lblSimpanKeDrive.Location = New System.Drawing.Point(4, 11)
        Me.lblSimpanKeDrive.Name = "lblSimpanKeDrive"
        Me.lblSimpanKeDrive.Size = New System.Drawing.Size(91, 13)
        Me.lblSimpanKeDrive.TabIndex = 207
        Me.lblSimpanKeDrive.Text = "Simpan ke Drive :"
        '
        'pnlExportExcel
        '
        Me.pnlExportExcel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlExportExcel.Controls.Add(Me.tbPathSimpan)
        Me.pnlExportExcel.Controls.Add(Me.btnBrowse)
        Me.pnlExportExcel.Controls.Add(Me.lblSimpanKeDrive)
        Me.pnlExportExcel.Controls.Add(Me.btnExportExcel)
        Me.pnlExportExcel.Controls.Add(Me.lblNamaSimpan)
        Me.pnlExportExcel.Controls.Add(Me.tbNamaSimpan)
        Me.pnlExportExcel.Location = New System.Drawing.Point(541, 262)
        Me.pnlExportExcel.Name = "pnlExportExcel"
        Me.pnlExportExcel.Size = New System.Drawing.Size(435, 72)
        Me.pnlExportExcel.TabIndex = 209
        '
        'FormInputDataKonsumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(984, 716)
        Me.Controls.Add(Me.pnlExportExcel)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.gbCariKonsumen)
        Me.Controls.Add(Me.lblEntryType)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbDataEntry)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInputDataKonsumen"
        Me.Text = "FORM INPUT DATA KONSUMEN"
        Me.gbDataEntry.ResumeLayout(False)
        Me.gbDataEntry.PerformLayout()
        Me.gbCariKonsumen.ResumeLayout(False)
        Me.gbCariKonsumen.PerformLayout()
        CType(Me.dgvCariKonsumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        CType(Me.dgvKupon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigasi.ResumeLayout(False)
        Me.pnlNavigasi.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlExportExcel.ResumeLayout(False)
        Me.pnlExportExcel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblEntryType As Label
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents gbDataEntry As GroupBox
    Friend WithEvents lblNomorWa As Label
    Friend WithEvents btnCreateNew As Button
    Friend WithEvents tbNomorWA As TextBox
    Friend WithEvents lblAccountInstagram As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents tbAccountInstagram As TextBox
    Friend WithEvents cboKupon As ComboBox
    Friend WithEvents lblKategori As Label
    Friend WithEvents btnSimpan As Button
    Friend WithEvents btnKeluar As Button
    Friend WithEvents dgvCariKonsumen As DataGridView
    Friend WithEvents tbCariKonsumen As TextBox
    Friend WithEvents cboKriteriaKonsumen As ComboBox
    Friend WithEvents gbCariKonsumen As GroupBox
    Friend WithEvents gbView As GroupBox
    Friend WithEvents lblSorting As Label
    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents cboSortingCriteria As ComboBox
    Friend WithEvents lblCariKategori As Label
    Friend WithEvents cboCariKategori As ComboBox
    Friend WithEvents pnlNavigasi As Panel
    Friend WithEvents btnAddNew As Button
    Friend WithEvents btnFFBack As Button
    Friend WithEvents lblRecord As Label
    Friend WithEvents btnForward As Button
    Friend WithEvents lblOfPages As Label
    Friend WithEvents tbRecordPage As TextBox
    Friend WithEvents btnFFForward As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents btnCariKonsumen As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvKupon As DataGridView
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnExportExcel As Button
    Friend WithEvents tbNamaSimpan As TextBox
    Friend WithEvents tbPathSimpan As TextBox
    Friend WithEvents lblNamaSimpan As Label
    Friend WithEvents lblSimpanKeDrive As Label
    Friend WithEvents pnlExportExcel As Panel
    Friend WithEvents fbdExport As FolderBrowserDialog
End Class
