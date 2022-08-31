<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUtama))
        Me.mnStripUtama = New System.Windows.Forms.MenuStrip()
        Me.mnGroupMaster = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnGenerateMasterKuponUndian = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnKonsumen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnDataKonsumen = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnStripUtama.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnStripUtama
        '
        Me.mnStripUtama.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnGroupMaster, Me.mnKonsumen, Me.mnLogout, Me.mnExit})
        Me.mnStripUtama.Location = New System.Drawing.Point(0, 0)
        Me.mnStripUtama.Name = "mnStripUtama"
        Me.mnStripUtama.Size = New System.Drawing.Size(902, 24)
        Me.mnStripUtama.TabIndex = 2
        Me.mnStripUtama.Text = "MenuStrip1"
        '
        'mnGroupMaster
        '
        Me.mnGroupMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnGenerateMasterKuponUndian})
        Me.mnGroupMaster.Name = "mnGroupMaster"
        Me.mnGroupMaster.Size = New System.Drawing.Size(63, 20)
        Me.mnGroupMaster.Text = "MASTER"
        '
        'mnGenerateMasterKuponUndian
        '
        Me.mnGenerateMasterKuponUndian.Name = "mnGenerateMasterKuponUndian"
        Me.mnGenerateMasterKuponUndian.Size = New System.Drawing.Size(239, 22)
        Me.mnGenerateMasterKuponUndian.Text = "Generate Master Kupon Undian"
        '
        'mnKonsumen
        '
        Me.mnKonsumen.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnDataKonsumen})
        Me.mnKonsumen.Name = "mnKonsumen"
        Me.mnKonsumen.Size = New System.Drawing.Size(83, 20)
        Me.mnKonsumen.Text = "KONSUMEN"
        '
        'mnDataKonsumen
        '
        Me.mnDataKonsumen.Name = "mnDataKonsumen"
        Me.mnDataKonsumen.Size = New System.Drawing.Size(158, 22)
        Me.mnDataKonsumen.Text = "Data Konsumen"
        '
        'mnLogout
        '
        Me.mnLogout.Name = "mnLogout"
        Me.mnLogout.Size = New System.Drawing.Size(68, 20)
        Me.mnLogout.Text = "LOG OUT"
        '
        'mnExit
        '
        Me.mnExit.Name = "mnExit"
        Me.mnExit.Size = New System.Drawing.Size(41, 20)
        Me.mnExit.Text = "EXIT"
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 450)
        Me.Controls.Add(Me.mnStripUtama)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.mnStripUtama
        Me.Name = "FormUtama"
        Me.Text = "FORM UTAMA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.mnStripUtama.ResumeLayout(False)
        Me.mnStripUtama.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents mnStripUtama As MenuStrip
    Friend WithEvents mnGroupMaster As ToolStripMenuItem
    Friend WithEvents mnLogout As ToolStripMenuItem
    Friend WithEvents mnExit As ToolStripMenuItem
    Friend WithEvents mnGenerateMasterKuponUndian As ToolStripMenuItem
    Friend WithEvents mnKonsumen As ToolStripMenuItem
    Friend WithEvents mnDataKonsumen As ToolStripMenuItem
End Class
