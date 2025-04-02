<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompletaMovPapeleria
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCompletaMovPapeleria))
        Me.BtnGuardar = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.DataDatos = New System.Windows.Forms.DataGridView
        Me.TextDepartamento = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextSolicitante = New System.Windows.Forms.TextBox
        Me.TextFecha = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboAlmacen = New System.Windows.Forms.TextBox
        Me.TextID_Depto = New System.Windows.Forms.TextBox
        Me.TextNickSolicitante = New System.Windows.Forms.TextBox
        Me.TextID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.Location = New System.Drawing.Point(688, 366)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(129, 29)
        Me.BtnGuardar.TabIndex = 16
        Me.BtnGuardar.Text = "Completar Movimientos"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(489, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Almacén:"
        '
        'DataDatos
        '
        Me.DataDatos.AllowUserToAddRows = False
        Me.DataDatos.AllowUserToDeleteRows = False
        Me.DataDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataDatos.Location = New System.Drawing.Point(20, 128)
        Me.DataDatos.Name = "DataDatos"
        Me.DataDatos.ReadOnly = True
        Me.DataDatos.Size = New System.Drawing.Size(797, 230)
        Me.DataDatos.TabIndex = 14
        '
        'TextDepartamento
        '
        Me.TextDepartamento.Enabled = False
        Me.TextDepartamento.Location = New System.Drawing.Point(214, 67)
        Me.TextDepartamento.Name = "TextDepartamento"
        Me.TextDepartamento.Size = New System.Drawing.Size(257, 20)
        Me.TextDepartamento.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(489, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Fecha de Solicitud:"
        '
        'TextSolicitante
        '
        Me.TextSolicitante.Enabled = False
        Me.TextSolicitante.Location = New System.Drawing.Point(214, 41)
        Me.TextSolicitante.Name = "TextSolicitante"
        Me.TextSolicitante.Size = New System.Drawing.Size(257, 20)
        Me.TextSolicitante.TabIndex = 11
        '
        'TextFecha
        '
        Me.TextFecha.Enabled = False
        Me.TextFecha.Location = New System.Drawing.Point(592, 41)
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.Size = New System.Drawing.Size(154, 20)
        Me.TextFecha.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Departamento:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Solicitante:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextID)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextNickSolicitante)
        Me.GroupBox1.Controls.Add(Me.ComboAlmacen)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextID_Depto)
        Me.GroupBox1.Controls.Add(Me.TextSolicitante)
        Me.GroupBox1.Controls.Add(Me.TextFecha)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextDepartamento)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(819, 98)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'ComboAlmacen
        '
        Me.ComboAlmacen.Enabled = False
        Me.ComboAlmacen.Location = New System.Drawing.Point(592, 67)
        Me.ComboAlmacen.Name = "ComboAlmacen"
        Me.ComboAlmacen.Size = New System.Drawing.Size(154, 20)
        Me.ComboAlmacen.TabIndex = 18
        '
        'TextID_Depto
        '
        Me.TextID_Depto.Enabled = False
        Me.TextID_Depto.Location = New System.Drawing.Point(115, 67)
        Me.TextID_Depto.Name = "TextID_Depto"
        Me.TextID_Depto.Size = New System.Drawing.Size(93, 20)
        Me.TextID_Depto.TabIndex = 18
        '
        'TextNickSolicitante
        '
        Me.TextNickSolicitante.Enabled = False
        Me.TextNickSolicitante.Location = New System.Drawing.Point(115, 41)
        Me.TextNickSolicitante.Name = "TextNickSolicitante"
        Me.TextNickSolicitante.Size = New System.Drawing.Size(93, 20)
        Me.TextNickSolicitante.TabIndex = 19
        '
        'TextID
        '
        Me.TextID.Enabled = False
        Me.TextID.Location = New System.Drawing.Point(115, 15)
        Me.TextID.Name = "TextID"
        Me.TextID.Size = New System.Drawing.Size(93, 20)
        Me.TextID.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "ID Solicitud:"
        '
        'FrmCompletaMovPapeleria
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 408)
        Me.Controls.Add(Me.BtnGuardar)
        Me.Controls.Add(Me.DataDatos)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmCompletaMovPapeleria"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Completar Movimiento Papelería"
        CType(Me.DataDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DataDatos As System.Windows.Forms.DataGridView
    Friend WithEvents TextDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents TextFecha As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboAlmacen As System.Windows.Forms.TextBox
    Friend WithEvents TextID_Depto As System.Windows.Forms.TextBox
    Friend WithEvents TextNickSolicitante As System.Windows.Forms.TextBox
    Friend WithEvents TextID As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
