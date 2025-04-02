<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_perfil_usuario
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas por Proveedor")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Archivos")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("General")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Colgate", New System.Windows.Forms.TreeNode() {TreeNode2, TreeNode3})
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Alcon Mascotas")
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Colombina")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sell Out", New System.Windows.Forms.TreeNode() {TreeNode4, TreeNode5, TreeNode6})
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cajas de Livsmart")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Livsmart", New System.Windows.Forms.TreeNode() {TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Quala")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Disar")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("SR Agro")
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sell Out General", New System.Windows.Forms.TreeNode() {TreeNode11, TreeNode12})
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode7, TreeNode9, TreeNode10, TreeNode13})
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Vendedores")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Distribuidora San Rafael")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Agro")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pivot Ventas")
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Consultar Bitacora")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detalle Contado/Credito")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Comisiones")
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Incumplimientos")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Detalle de Descuentos")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Reportes", New System.Windows.Forms.TreeNode() {TreeNode14, TreeNode15, TreeNode16, TreeNode17, TreeNode18, TreeNode19, TreeNode20, TreeNode21, TreeNode22, TreeNode23})
        Dim TreeNode25 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Supply Chain")
        Dim TreeNode26 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contabilidad")
        Dim TreeNode27 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Inventarios")
        Dim TreeNode28 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Almacen")
        Dim TreeNode29 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("PDSE")
        Dim TreeNode30 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bonificaciones")
        Dim TreeNode31 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Configuraciones")
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.TreeView1 = New System.Windows.Forms.TreeView
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Modulo"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(13, 30)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(253, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Location = New System.Drawing.Point(15, 57)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "1.1.1"
        TreeNode1.Text = "Ventas por Proveedor"
        TreeNode2.Name = "1.1.2.1.1"
        TreeNode2.Text = "Archivos"
        TreeNode3.Name = "1.1.2.1.2"
        TreeNode3.Text = "General"
        TreeNode4.Name = "1.1.2.1"
        TreeNode4.Text = "Colgate"
        TreeNode5.Name = "1.1.2.2"
        TreeNode5.Text = "Alcon Mascotas"
        TreeNode6.Name = "1.1.2.3"
        TreeNode6.Text = "Colombina"
        TreeNode7.Name = "1.1.2"
        TreeNode7.Text = "Sell Out"
        TreeNode8.Name = "1.1.3.1"
        TreeNode8.Text = "Cajas de Livsmart"
        TreeNode9.Name = "1.1.3"
        TreeNode9.Text = "Livsmart"
        TreeNode10.Name = "1.1.4"
        TreeNode10.Text = "Quala"
        TreeNode11.Name = "1.1.5.1"
        TreeNode11.Text = "Disar"
        TreeNode12.Name = "1.1.5.2"
        TreeNode12.Text = "SR Agro"
        TreeNode13.Name = "1.1.5"
        TreeNode13.Text = "Sell Out General"
        TreeNode14.Name = "1.1"
        TreeNode14.Text = "Proveedores"
        TreeNode15.Name = "1.2"
        TreeNode15.Text = "Vendedores"
        TreeNode16.Name = "1.3"
        TreeNode16.Text = "Distribuidora San Rafael"
        TreeNode17.Name = "1.4"
        TreeNode17.Text = "Agro"
        TreeNode18.Name = "1.5"
        TreeNode18.Text = "Pivot Ventas"
        TreeNode19.Name = "1.6"
        TreeNode19.Text = "Consultar Bitacora"
        TreeNode20.Name = "1.7"
        TreeNode20.Text = "Detalle Contado/Credito"
        TreeNode21.Name = "1.8"
        TreeNode21.Text = "Comisiones"
        TreeNode22.Name = "1.9"
        TreeNode22.Text = "Incumplimientos"
        TreeNode23.Name = "1.10"
        TreeNode23.Text = "Detalle de Descuentos"
        TreeNode24.Name = "1"
        TreeNode24.Text = "Reportes"
        TreeNode25.Name = "2"
        TreeNode25.Text = "Supply Chain"
        TreeNode26.Name = "3"
        TreeNode26.Text = "Contabilidad"
        TreeNode27.Name = "4"
        TreeNode27.Text = "Inventarios"
        TreeNode28.Name = "5"
        TreeNode28.Text = "Almacen"
        TreeNode29.Name = "7"
        TreeNode29.Text = "PDSE"
        TreeNode30.Name = "8"
        TreeNode30.Text = "Bonificaciones"
        TreeNode31.Name = "9"
        TreeNode31.Text = "Configuraciones"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode24, TreeNode25, TreeNode26, TreeNode27, TreeNode28, TreeNode29, TreeNode30, TreeNode31})
        Me.TreeView1.Size = New System.Drawing.Size(406, 395)
        Me.TreeView1.TabIndex = 3
        '
        'frm_perfil_usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 829)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frm_perfil_usuario"
        Me.Text = "frm_perfil_usuario"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
End Class
