<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormGenerateMasterKuponUndian
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGenerateMasterKuponUndian))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnGenerateKupon = New System.Windows.Forms.Button()
        Me.lblBanyakDigit = New System.Windows.Forms.Label()
        Me.tbBanyakDigit = New System.Windows.Forms.TextBox()
        Me.gbView = New System.Windows.Forms.GroupBox()
        Me.lblSorting = New System.Windows.Forms.Label()
        Me.cboSortingType = New System.Windows.Forms.ComboBox()
        Me.cboSortingCriteria = New System.Windows.Forms.ComboBox()
        Me.lblCariKategori = New System.Windows.Forms.Label()
        Me.cboCariKategori = New System.Windows.Forms.ComboBox()
        Me.tbCari = New System.Windows.Forms.TextBox()
        Me.btnTampilkan = New System.Windows.Forms.Button()
        Me.lblCari = New System.Windows.Forms.Label()
        Me.cboKriteria = New System.Windows.Forms.ComboBox()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.clbUserRight = New System.Windows.Forms.CheckedListBox()
        Me.btnHapus = New System.Windows.Forms.Button()
        Me.tbBanyaknya = New System.Windows.Forms.TextBox()
        Me.lblSebanyak = New System.Windows.Forms.Label()
        Me.gbGenerateKuponUndian = New System.Windows.Forms.GroupBox()
        Me.gbView.SuspendLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbGenerateKuponUndian.SuspendLayout()
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
        Me.lblTitle.Size = New System.Drawing.Size(800, 25)
        Me.lblTitle.TabIndex = 180
        Me.lblTitle.Text = "GENERATE MASTER KUPON UNDIAN"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnGenerateKupon
        '
        Me.btnGenerateKupon.Location = New System.Drawing.Point(357, 7)
        Me.btnGenerateKupon.Name = "btnGenerateKupon"
        Me.btnGenerateKupon.Size = New System.Drawing.Size(120, 54)
        Me.btnGenerateKupon.TabIndex = 3
        Me.btnGenerateKupon.Text = "GENERATE KUPON"
        Me.btnGenerateKupon.UseVisualStyleBackColor = True
        '
        'lblBanyakDigit
        '
        Me.lblBanyakDigit.AutoSize = True
        Me.lblBanyakDigit.Location = New System.Drawing.Point(7, 15)
        Me.lblBanyakDigit.Name = "lblBanyakDigit"
        Me.lblBanyakDigit.Size = New System.Drawing.Size(73, 13)
        Me.lblBanyakDigit.TabIndex = 183
        Me.lblBanyakDigit.Text = "Banyak Digit :"
        '
        'tbBanyakDigit
        '
        Me.tbBanyakDigit.Location = New System.Drawing.Point(86, 12)
        Me.tbBanyakDigit.Name = "tbBanyakDigit"
        Me.tbBanyakDigit.Size = New System.Drawing.Size(75, 20)
        Me.tbBanyakDigit.TabIndex = 1
        Me.tbBanyakDigit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbView
        '
        Me.gbView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbView.Controls.Add(Me.lblSorting)
        Me.gbView.Controls.Add(Me.cboSortingType)
        Me.gbView.Controls.Add(Me.cboSortingCriteria)
        Me.gbView.Controls.Add(Me.lblCariKategori)
        Me.gbView.Controls.Add(Me.cboCariKategori)
        Me.gbView.Controls.Add(Me.tbCari)
        Me.gbView.Controls.Add(Me.btnTampilkan)
        Me.gbView.Controls.Add(Me.lblCari)
        Me.gbView.Controls.Add(Me.cboKriteria)
        Me.gbView.Controls.Add(Me.dgvView)
        Me.gbView.Location = New System.Drawing.Point(12, 98)
        Me.gbView.Name = "gbView"
        Me.gbView.Size = New System.Drawing.Size(780, 370)
        Me.gbView.TabIndex = 192
        Me.gbView.TabStop = False
        Me.gbView.Text = "VIEW"
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
        Me.cboSortingType.TabIndex = 14
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
        Me.cboSortingCriteria.TabIndex = 13
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
        Me.cboCariKategori.TabIndex = 10
        '
        'tbCari
        '
        Me.tbCari.Location = New System.Drawing.Point(243, 40)
        Me.tbCari.Name = "tbCari"
        Me.tbCari.Size = New System.Drawing.Size(186, 20)
        Me.tbCari.TabIndex = 12
        '
        'btnTampilkan
        '
        Me.btnTampilkan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnTampilkan.Image = CType(resources.GetObject("btnTampilkan.Image"), System.Drawing.Image)
        Me.btnTampilkan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTampilkan.Location = New System.Drawing.Point(654, 11)
        Me.btnTampilkan.Name = "btnTampilkan"
        Me.btnTampilkan.Size = New System.Drawing.Size(120, 54)
        Me.btnTampilkan.TabIndex = 15
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
        Me.cboKriteria.TabIndex = 11
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Location = New System.Drawing.Point(6, 67)
        Me.dgvView.Name = "dgvView"
        Me.dgvView.Size = New System.Drawing.Size(768, 296)
        Me.dgvView.TabIndex = 130
        '
        'clbUserRight
        '
        Me.clbUserRight.BackColor = System.Drawing.SystemColors.Info
        Me.clbUserRight.Enabled = False
        Me.clbUserRight.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.clbUserRight.FormattingEnabled = True
        Me.clbUserRight.Items.AddRange(New Object() {"Melihat", "Menambah", "Memperbaharui", "Menghapus"})
        Me.clbUserRight.Location = New System.Drawing.Point(692, 28)
        Me.clbUserRight.Name = "clbUserRight"
        Me.clbUserRight.Size = New System.Drawing.Size(100, 64)
        Me.clbUserRight.TabIndex = 197
        '
        'btnHapus
        '
        Me.btnHapus.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnHapus.Image = CType(resources.GetObject("btnHapus.Image"), System.Drawing.Image)
        Me.btnHapus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnHapus.Location = New System.Drawing.Point(483, 7)
        Me.btnHapus.Name = "btnHapus"
        Me.btnHapus.Size = New System.Drawing.Size(120, 54)
        Me.btnHapus.TabIndex = 4
        Me.btnHapus.Text = "HAPUS"
        Me.btnHapus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnHapus.UseVisualStyleBackColor = True
        '
        'tbBanyaknya
        '
        Me.tbBanyaknya.Location = New System.Drawing.Point(246, 16)
        Me.tbBanyaknya.Name = "tbBanyaknya"
        Me.tbBanyaknya.Size = New System.Drawing.Size(105, 20)
        Me.tbBanyaknya.TabIndex = 2
        Me.tbBanyaknya.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSebanyak
        '
        Me.lblSebanyak.AutoSize = True
        Me.lblSebanyak.Location = New System.Drawing.Point(174, 19)
        Me.lblSebanyak.Name = "lblSebanyak"
        Me.lblSebanyak.Size = New System.Drawing.Size(66, 13)
        Me.lblSebanyak.TabIndex = 199
        Me.lblSebanyak.Text = "Banyaknya :"
        '
        'gbGenerateKuponUndian
        '
        Me.gbGenerateKuponUndian.Controls.Add(Me.tbBanyaknya)
        Me.gbGenerateKuponUndian.Controls.Add(Me.btnHapus)
        Me.gbGenerateKuponUndian.Controls.Add(Me.lblBanyakDigit)
        Me.gbGenerateKuponUndian.Controls.Add(Me.tbBanyakDigit)
        Me.gbGenerateKuponUndian.Controls.Add(Me.btnGenerateKupon)
        Me.gbGenerateKuponUndian.Controls.Add(Me.lblSebanyak)
        Me.gbGenerateKuponUndian.Location = New System.Drawing.Point(12, 28)
        Me.gbGenerateKuponUndian.Name = "gbGenerateKuponUndian"
        Me.gbGenerateKuponUndian.Size = New System.Drawing.Size(674, 64)
        Me.gbGenerateKuponUndian.TabIndex = 198
        Me.gbGenerateKuponUndian.TabStop = False
        Me.gbGenerateKuponUndian.Text = "Generate Kupon Undian"
        '
        'FormGenerateMasterKuponUndian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(800, 475)
        Me.Controls.Add(Me.gbGenerateKuponUndian)
        Me.Controls.Add(Me.clbUserRight)
        Me.Controls.Add(Me.gbView)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormGenerateMasterKuponUndian"
        Me.Text = "FORM GENERATE MASTER KUPON UNDIAN"
        Me.gbView.ResumeLayout(False)
        Me.gbView.PerformLayout()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbGenerateKuponUndian.ResumeLayout(False)
        Me.gbGenerateKuponUndian.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents btnGenerateKupon As Button
    Friend WithEvents lblBanyakDigit As Label
    Friend WithEvents tbBanyakDigit As TextBox
    Friend WithEvents gbView As GroupBox
    Friend WithEvents lblSorting As Label
    Friend WithEvents cboSortingType As ComboBox
    Friend WithEvents cboSortingCriteria As ComboBox
    Friend WithEvents lblCariKategori As Label
    Friend WithEvents cboCariKategori As ComboBox
    Friend WithEvents tbCari As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lblCari As Label
    Friend WithEvents cboKriteria As ComboBox
    Friend WithEvents dgvView As DataGridView
    Friend WithEvents clbUserRight As CheckedListBox
    Friend WithEvents btnHapus As Button
    Friend WithEvents tbBanyaknya As TextBox
    Friend WithEvents lblSebanyak As Label
    Friend WithEvents gbGenerateKuponUndian As GroupBox
End Class
