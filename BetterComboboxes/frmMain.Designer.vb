<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.btnAddPilots = New System.Windows.Forms.Button()
        Me.btnUpdatePilots = New System.Windows.Forms.Button()
        Me.btnUpdatePassengers = New System.Windows.Forms.Button()
        Me.btnAddPassengers = New System.Windows.Forms.Button()
        Me.btnShowPassengers = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddPilots
        '
        Me.btnAddPilots.Location = New System.Drawing.Point(12, 12)
        Me.btnAddPilots.Name = "btnAddPilots"
        Me.btnAddPilots.Size = New System.Drawing.Size(776, 74)
        Me.btnAddPilots.TabIndex = 0
        Me.btnAddPilots.Text = "Add Pilots"
        Me.btnAddPilots.UseVisualStyleBackColor = True
        '
        'btnUpdatePilots
        '
        Me.btnUpdatePilots.Location = New System.Drawing.Point(12, 92)
        Me.btnUpdatePilots.Name = "btnUpdatePilots"
        Me.btnUpdatePilots.Size = New System.Drawing.Size(776, 74)
        Me.btnUpdatePilots.TabIndex = 1
        Me.btnUpdatePilots.Text = "Update Pilots"
        Me.btnUpdatePilots.UseVisualStyleBackColor = True
        '
        'btnUpdatePassengers
        '
        Me.btnUpdatePassengers.Location = New System.Drawing.Point(12, 252)
        Me.btnUpdatePassengers.Name = "btnUpdatePassengers"
        Me.btnUpdatePassengers.Size = New System.Drawing.Size(776, 74)
        Me.btnUpdatePassengers.TabIndex = 3
        Me.btnUpdatePassengers.Text = "Update Passengers"
        Me.btnUpdatePassengers.UseVisualStyleBackColor = True
        '
        'btnAddPassengers
        '
        Me.btnAddPassengers.Location = New System.Drawing.Point(12, 172)
        Me.btnAddPassengers.Name = "btnAddPassengers"
        Me.btnAddPassengers.Size = New System.Drawing.Size(776, 74)
        Me.btnAddPassengers.TabIndex = 2
        Me.btnAddPassengers.Text = "Add Passengers"
        Me.btnAddPassengers.UseVisualStyleBackColor = True
        '
        'btnShowPassengers
        '
        Me.btnShowPassengers.Location = New System.Drawing.Point(12, 332)
        Me.btnShowPassengers.Name = "btnShowPassengers"
        Me.btnShowPassengers.Size = New System.Drawing.Size(776, 74)
        Me.btnShowPassengers.TabIndex = 4
        Me.btnShowPassengers.Text = "Show Passengers"
        Me.btnShowPassengers.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnShowPassengers)
        Me.Controls.Add(Me.btnUpdatePassengers)
        Me.Controls.Add(Me.btnAddPassengers)
        Me.Controls.Add(Me.btnUpdatePilots)
        Me.Controls.Add(Me.btnAddPilots)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddPilots As Button
    Friend WithEvents btnUpdatePilots As Button
    Friend WithEvents btnUpdatePassengers As Button
    Friend WithEvents btnAddPassengers As Button
    Friend WithEvents btnShowPassengers As Button
End Class
