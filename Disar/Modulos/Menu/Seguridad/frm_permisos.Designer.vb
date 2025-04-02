<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_permisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_permisos))
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_usuario = New System.Windows.Forms.TextBox
        Me.permisos_reportes = New System.Windows.Forms.CheckedListBox
        Me.tabc_perfiles = New System.Windows.Forms.TabControl
        Me.tc_reportes = New System.Windows.Forms.TabPage
        Me.mol_reportes = New System.Windows.Forms.CheckBox
        Me.tc_supply = New System.Windows.Forms.TabPage
        Me.mol_supply = New System.Windows.Forms.CheckBox
        Me.permisos_supply = New System.Windows.Forms.CheckedListBox
        Me.tc_contabilidad = New System.Windows.Forms.TabPage
        Me.mol_contabilidad = New System.Windows.Forms.CheckBox
        Me.permisos_contabilidad = New System.Windows.Forms.CheckedListBox
        Me.tc_inventarios = New System.Windows.Forms.TabPage
        Me.mol_inventarios = New System.Windows.Forms.CheckBox
        Me.permisos_inventarios = New System.Windows.Forms.CheckedListBox
        Me.tc_almacen = New System.Windows.Forms.TabPage
        Me.mol_almacen = New System.Windows.Forms.CheckBox
        Me.permisos_almacen = New System.Windows.Forms.CheckedListBox
        Me.tc_pdse = New System.Windows.Forms.TabPage
        Me.mol_pdse = New System.Windows.Forms.CheckBox
        Me.permisos_pdse = New System.Windows.Forms.CheckedListBox
        Me.tc_bonificaciones = New System.Windows.Forms.TabPage
        Me.mol_bonificaciones = New System.Windows.Forms.CheckBox
        Me.permisos_bonificaciones = New System.Windows.Forms.CheckedListBox
        Me.tc_configuracion = New System.Windows.Forms.TabPage
        Me.mol_configuracion = New System.Windows.Forms.CheckBox
        Me.permisos_configuracion = New System.Windows.Forms.CheckedListBox
        Me.tc_monitoreo = New System.Windows.Forms.TabPage
        Me.mol_monitoreo = New System.Windows.Forms.CheckBox
        Me.permisos_monitoreo = New System.Windows.Forms.CheckedListBox
        Me.tc_adicionales = New System.Windows.Forms.TabPage
        Me.mol_adicionales = New System.Windows.Forms.CheckBox
        Me.permisos_adicionales = New System.Windows.Forms.CheckedListBox
        Me.btn_aceptar = New System.Windows.Forms.Button
        Me.btn_cancelar = New System.Windows.Forms.Button
        Me.tabc_perfiles.SuspendLayout()
        Me.tc_reportes.SuspendLayout()
        Me.tc_supply.SuspendLayout()
        Me.tc_contabilidad.SuspendLayout()
        Me.tc_inventarios.SuspendLayout()
        Me.tc_almacen.SuspendLayout()
        Me.tc_pdse.SuspendLayout()
        Me.tc_bonificaciones.SuspendLayout()
        Me.tc_configuracion.SuspendLayout()
        Me.tc_monitoreo.SuspendLayout()
        Me.tc_adicionales.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario:"
        '
        'txt_usuario
        '
        Me.txt_usuario.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.txt_usuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txt_usuario.Location = New System.Drawing.Point(177, 5)
        Me.txt_usuario.Name = "txt_usuario"
        Me.txt_usuario.ReadOnly = True
        Me.txt_usuario.Size = New System.Drawing.Size(420, 20)
        Me.txt_usuario.TabIndex = 1
        '
        'permisos_reportes
        '
        Me.permisos_reportes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_reportes.Enabled = False
        Me.permisos_reportes.FormattingEnabled = True
        Me.permisos_reportes.Location = New System.Drawing.Point(6, 21)
        Me.permisos_reportes.Name = "permisos_reportes"
        Me.permisos_reportes.Size = New System.Drawing.Size(684, 544)
        Me.permisos_reportes.TabIndex = 2
        '
        'tabc_perfiles
        '
        Me.tabc_perfiles.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.tabc_perfiles.Controls.Add(Me.tc_reportes)
        Me.tabc_perfiles.Controls.Add(Me.tc_supply)
        Me.tabc_perfiles.Controls.Add(Me.tc_contabilidad)
        Me.tabc_perfiles.Controls.Add(Me.tc_inventarios)
        Me.tabc_perfiles.Controls.Add(Me.tc_almacen)
        Me.tabc_perfiles.Controls.Add(Me.tc_pdse)
        Me.tabc_perfiles.Controls.Add(Me.tc_bonificaciones)
        Me.tabc_perfiles.Controls.Add(Me.tc_configuracion)
        Me.tabc_perfiles.Controls.Add(Me.tc_monitoreo)
        Me.tabc_perfiles.Controls.Add(Me.tc_adicionales)
        Me.tabc_perfiles.Location = New System.Drawing.Point(13, 31)
        Me.tabc_perfiles.Name = "tabc_perfiles"
        Me.tabc_perfiles.SelectedIndex = 0
        Me.tabc_perfiles.Size = New System.Drawing.Size(704, 656)
        Me.tabc_perfiles.TabIndex = 5
        '
        'tc_reportes
        '
        Me.tc_reportes.Controls.Add(Me.mol_reportes)
        Me.tc_reportes.Controls.Add(Me.permisos_reportes)
        Me.tc_reportes.Location = New System.Drawing.Point(4, 22)
        Me.tc_reportes.Name = "tc_reportes"
        Me.tc_reportes.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_reportes.Size = New System.Drawing.Size(696, 630)
        Me.tc_reportes.TabIndex = 0
        Me.tc_reportes.Text = "Reportes"
        Me.tc_reportes.UseVisualStyleBackColor = True
        '
        'mol_reportes
        '
        Me.mol_reportes.AutoSize = True
        Me.mol_reportes.Location = New System.Drawing.Point(6, 4)
        Me.mol_reportes.Name = "mol_reportes"
        Me.mol_reportes.Size = New System.Drawing.Size(102, 17)
        Me.mol_reportes.TabIndex = 3
        Me.mol_reportes.Text = "Habilitar Modulo"
        Me.mol_reportes.UseVisualStyleBackColor = True
        '
        'tc_supply
        '
        Me.tc_supply.Controls.Add(Me.mol_supply)
        Me.tc_supply.Controls.Add(Me.permisos_supply)
        Me.tc_supply.Location = New System.Drawing.Point(4, 22)
        Me.tc_supply.Name = "tc_supply"
        Me.tc_supply.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_supply.Size = New System.Drawing.Size(696, 634)
        Me.tc_supply.TabIndex = 1
        Me.tc_supply.Text = "Supply Chain"
        Me.tc_supply.UseVisualStyleBackColor = True
        '
        'mol_supply
        '
        Me.mol_supply.AutoSize = True
        Me.mol_supply.Location = New System.Drawing.Point(6, 4)
        Me.mol_supply.Name = "mol_supply"
        Me.mol_supply.Size = New System.Drawing.Size(102, 17)
        Me.mol_supply.TabIndex = 5
        Me.mol_supply.Text = "Habilitar Modulo"
        Me.mol_supply.UseVisualStyleBackColor = True
        '
        'permisos_supply
        '
        Me.permisos_supply.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_supply.Enabled = False
        Me.permisos_supply.FormattingEnabled = True
        Me.permisos_supply.Location = New System.Drawing.Point(6, 21)
        Me.permisos_supply.Name = "permisos_supply"
        Me.permisos_supply.Size = New System.Drawing.Size(684, 604)
        Me.permisos_supply.TabIndex = 4
        '
        'tc_contabilidad
        '
        Me.tc_contabilidad.Controls.Add(Me.mol_contabilidad)
        Me.tc_contabilidad.Controls.Add(Me.permisos_contabilidad)
        Me.tc_contabilidad.Location = New System.Drawing.Point(4, 22)
        Me.tc_contabilidad.Name = "tc_contabilidad"
        Me.tc_contabilidad.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_contabilidad.Size = New System.Drawing.Size(696, 630)
        Me.tc_contabilidad.TabIndex = 2
        Me.tc_contabilidad.Text = "Contabilidad"
        Me.tc_contabilidad.UseVisualStyleBackColor = True
        '
        'mol_contabilidad
        '
        Me.mol_contabilidad.AutoSize = True
        Me.mol_contabilidad.Location = New System.Drawing.Point(6, 4)
        Me.mol_contabilidad.Name = "mol_contabilidad"
        Me.mol_contabilidad.Size = New System.Drawing.Size(102, 17)
        Me.mol_contabilidad.TabIndex = 6
        Me.mol_contabilidad.Text = "Habilitar Modulo"
        Me.mol_contabilidad.UseVisualStyleBackColor = True
        '
        'permisos_contabilidad
        '
        Me.permisos_contabilidad.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_contabilidad.Enabled = False
        Me.permisos_contabilidad.FormattingEnabled = True
        Me.permisos_contabilidad.Location = New System.Drawing.Point(6, 21)
        Me.permisos_contabilidad.Name = "permisos_contabilidad"
        Me.permisos_contabilidad.Size = New System.Drawing.Size(684, 604)
        Me.permisos_contabilidad.TabIndex = 5
        '
        'tc_inventarios
        '
        Me.tc_inventarios.Controls.Add(Me.mol_inventarios)
        Me.tc_inventarios.Controls.Add(Me.permisos_inventarios)
        Me.tc_inventarios.Location = New System.Drawing.Point(4, 22)
        Me.tc_inventarios.Name = "tc_inventarios"
        Me.tc_inventarios.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_inventarios.Size = New System.Drawing.Size(696, 630)
        Me.tc_inventarios.TabIndex = 3
        Me.tc_inventarios.Text = "Inventarios"
        Me.tc_inventarios.UseVisualStyleBackColor = True
        '
        'mol_inventarios
        '
        Me.mol_inventarios.AutoSize = True
        Me.mol_inventarios.Location = New System.Drawing.Point(6, 4)
        Me.mol_inventarios.Name = "mol_inventarios"
        Me.mol_inventarios.Size = New System.Drawing.Size(102, 17)
        Me.mol_inventarios.TabIndex = 7
        Me.mol_inventarios.Text = "Habilitar Modulo"
        Me.mol_inventarios.UseVisualStyleBackColor = True
        '
        'permisos_inventarios
        '
        Me.permisos_inventarios.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_inventarios.Enabled = False
        Me.permisos_inventarios.FormattingEnabled = True
        Me.permisos_inventarios.Location = New System.Drawing.Point(6, 21)
        Me.permisos_inventarios.Name = "permisos_inventarios"
        Me.permisos_inventarios.Size = New System.Drawing.Size(684, 604)
        Me.permisos_inventarios.TabIndex = 6
        '
        'tc_almacen
        '
        Me.tc_almacen.Controls.Add(Me.mol_almacen)
        Me.tc_almacen.Controls.Add(Me.permisos_almacen)
        Me.tc_almacen.Location = New System.Drawing.Point(4, 22)
        Me.tc_almacen.Name = "tc_almacen"
        Me.tc_almacen.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_almacen.Size = New System.Drawing.Size(696, 630)
        Me.tc_almacen.TabIndex = 4
        Me.tc_almacen.Text = "Almacen"
        Me.tc_almacen.UseVisualStyleBackColor = True
        '
        'mol_almacen
        '
        Me.mol_almacen.AutoSize = True
        Me.mol_almacen.Location = New System.Drawing.Point(6, 4)
        Me.mol_almacen.Name = "mol_almacen"
        Me.mol_almacen.Size = New System.Drawing.Size(102, 17)
        Me.mol_almacen.TabIndex = 8
        Me.mol_almacen.Text = "Habilitar Modulo"
        Me.mol_almacen.UseVisualStyleBackColor = True
        '
        'permisos_almacen
        '
        Me.permisos_almacen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_almacen.Enabled = False
        Me.permisos_almacen.FormattingEnabled = True
        Me.permisos_almacen.Location = New System.Drawing.Point(6, 21)
        Me.permisos_almacen.Name = "permisos_almacen"
        Me.permisos_almacen.Size = New System.Drawing.Size(684, 604)
        Me.permisos_almacen.TabIndex = 7
        '
        'tc_pdse
        '
        Me.tc_pdse.Controls.Add(Me.mol_pdse)
        Me.tc_pdse.Controls.Add(Me.permisos_pdse)
        Me.tc_pdse.Location = New System.Drawing.Point(4, 22)
        Me.tc_pdse.Name = "tc_pdse"
        Me.tc_pdse.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_pdse.Size = New System.Drawing.Size(696, 634)
        Me.tc_pdse.TabIndex = 5
        Me.tc_pdse.Text = "PDSE"
        Me.tc_pdse.UseVisualStyleBackColor = True
        '
        'mol_pdse
        '
        Me.mol_pdse.AutoSize = True
        Me.mol_pdse.Location = New System.Drawing.Point(6, 4)
        Me.mol_pdse.Name = "mol_pdse"
        Me.mol_pdse.Size = New System.Drawing.Size(102, 17)
        Me.mol_pdse.TabIndex = 9
        Me.mol_pdse.Text = "Habilitar Modulo"
        Me.mol_pdse.UseVisualStyleBackColor = True
        '
        'permisos_pdse
        '
        Me.permisos_pdse.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_pdse.Enabled = False
        Me.permisos_pdse.FormattingEnabled = True
        Me.permisos_pdse.Location = New System.Drawing.Point(6, 21)
        Me.permisos_pdse.Name = "permisos_pdse"
        Me.permisos_pdse.Size = New System.Drawing.Size(684, 619)
        Me.permisos_pdse.TabIndex = 8
        '
        'tc_bonificaciones
        '
        Me.tc_bonificaciones.Controls.Add(Me.mol_bonificaciones)
        Me.tc_bonificaciones.Controls.Add(Me.permisos_bonificaciones)
        Me.tc_bonificaciones.Location = New System.Drawing.Point(4, 22)
        Me.tc_bonificaciones.Name = "tc_bonificaciones"
        Me.tc_bonificaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_bonificaciones.Size = New System.Drawing.Size(696, 630)
        Me.tc_bonificaciones.TabIndex = 6
        Me.tc_bonificaciones.Text = "Bonificaciones"
        Me.tc_bonificaciones.UseVisualStyleBackColor = True
        '
        'mol_bonificaciones
        '
        Me.mol_bonificaciones.AutoSize = True
        Me.mol_bonificaciones.Location = New System.Drawing.Point(6, 4)
        Me.mol_bonificaciones.Name = "mol_bonificaciones"
        Me.mol_bonificaciones.Size = New System.Drawing.Size(102, 17)
        Me.mol_bonificaciones.TabIndex = 10
        Me.mol_bonificaciones.Text = "Habilitar Modulo"
        Me.mol_bonificaciones.UseVisualStyleBackColor = True
        '
        'permisos_bonificaciones
        '
        Me.permisos_bonificaciones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_bonificaciones.Enabled = False
        Me.permisos_bonificaciones.FormattingEnabled = True
        Me.permisos_bonificaciones.Location = New System.Drawing.Point(6, 21)
        Me.permisos_bonificaciones.Name = "permisos_bonificaciones"
        Me.permisos_bonificaciones.Size = New System.Drawing.Size(684, 604)
        Me.permisos_bonificaciones.TabIndex = 9
        '
        'tc_configuracion
        '
        Me.tc_configuracion.Controls.Add(Me.mol_configuracion)
        Me.tc_configuracion.Controls.Add(Me.permisos_configuracion)
        Me.tc_configuracion.Location = New System.Drawing.Point(4, 22)
        Me.tc_configuracion.Name = "tc_configuracion"
        Me.tc_configuracion.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_configuracion.Size = New System.Drawing.Size(696, 630)
        Me.tc_configuracion.TabIndex = 7
        Me.tc_configuracion.Text = "Configuracion"
        Me.tc_configuracion.UseVisualStyleBackColor = True
        '
        'mol_configuracion
        '
        Me.mol_configuracion.AutoSize = True
        Me.mol_configuracion.Location = New System.Drawing.Point(6, 4)
        Me.mol_configuracion.Name = "mol_configuracion"
        Me.mol_configuracion.Size = New System.Drawing.Size(102, 17)
        Me.mol_configuracion.TabIndex = 11
        Me.mol_configuracion.Text = "Habilitar Modulo"
        Me.mol_configuracion.UseVisualStyleBackColor = True
        '
        'permisos_configuracion
        '
        Me.permisos_configuracion.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_configuracion.Enabled = False
        Me.permisos_configuracion.FormattingEnabled = True
        Me.permisos_configuracion.Location = New System.Drawing.Point(6, 21)
        Me.permisos_configuracion.Name = "permisos_configuracion"
        Me.permisos_configuracion.Size = New System.Drawing.Size(684, 589)
        Me.permisos_configuracion.TabIndex = 10
        '
        'tc_monitoreo
        '
        Me.tc_monitoreo.Controls.Add(Me.mol_monitoreo)
        Me.tc_monitoreo.Controls.Add(Me.permisos_monitoreo)
        Me.tc_monitoreo.Location = New System.Drawing.Point(4, 22)
        Me.tc_monitoreo.Name = "tc_monitoreo"
        Me.tc_monitoreo.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_monitoreo.Size = New System.Drawing.Size(696, 630)
        Me.tc_monitoreo.TabIndex = 8
        Me.tc_monitoreo.Text = "Monitoreo"
        Me.tc_monitoreo.UseVisualStyleBackColor = True
        '
        'mol_monitoreo
        '
        Me.mol_monitoreo.AutoSize = True
        Me.mol_monitoreo.Location = New System.Drawing.Point(6, 4)
        Me.mol_monitoreo.Name = "mol_monitoreo"
        Me.mol_monitoreo.Size = New System.Drawing.Size(102, 17)
        Me.mol_monitoreo.TabIndex = 13
        Me.mol_monitoreo.Text = "Habilitar Modulo"
        Me.mol_monitoreo.UseVisualStyleBackColor = True
        '
        'permisos_monitoreo
        '
        Me.permisos_monitoreo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_monitoreo.Enabled = False
        Me.permisos_monitoreo.FormattingEnabled = True
        Me.permisos_monitoreo.Location = New System.Drawing.Point(6, 21)
        Me.permisos_monitoreo.Name = "permisos_monitoreo"
        Me.permisos_monitoreo.Size = New System.Drawing.Size(684, 574)
        Me.permisos_monitoreo.TabIndex = 12
        '
        'tc_adicionales
        '
        Me.tc_adicionales.Controls.Add(Me.mol_adicionales)
        Me.tc_adicionales.Controls.Add(Me.permisos_adicionales)
        Me.tc_adicionales.Location = New System.Drawing.Point(4, 22)
        Me.tc_adicionales.Name = "tc_adicionales"
        Me.tc_adicionales.Padding = New System.Windows.Forms.Padding(3)
        Me.tc_adicionales.Size = New System.Drawing.Size(696, 630)
        Me.tc_adicionales.TabIndex = 9
        Me.tc_adicionales.Text = "Funciones Adicionales"
        Me.tc_adicionales.UseVisualStyleBackColor = True
        '
        'mol_adicionales
        '
        Me.mol_adicionales.AutoSize = True
        Me.mol_adicionales.Location = New System.Drawing.Point(6, 4)
        Me.mol_adicionales.Name = "mol_adicionales"
        Me.mol_adicionales.Size = New System.Drawing.Size(102, 17)
        Me.mol_adicionales.TabIndex = 5
        Me.mol_adicionales.Text = "Habilitar Modulo"
        Me.mol_adicionales.UseVisualStyleBackColor = True
        '
        'permisos_adicionales
        '
        Me.permisos_adicionales.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.permisos_adicionales.Enabled = False
        Me.permisos_adicionales.FormattingEnabled = True
        Me.permisos_adicionales.Location = New System.Drawing.Point(6, 21)
        Me.permisos_adicionales.Name = "permisos_adicionales"
        Me.permisos_adicionales.Size = New System.Drawing.Size(684, 544)
        Me.permisos_adicionales.TabIndex = 4
        '
        'btn_aceptar
        '
        Me.btn_aceptar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_aceptar.Image = Global.Disar.My.Resources.Resources.img_aceptar
        Me.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_aceptar.Location = New System.Drawing.Point(128, 693)
        Me.btn_aceptar.Name = "btn_aceptar"
        Me.btn_aceptar.Size = New System.Drawing.Size(88, 45)
        Me.btn_aceptar.TabIndex = 6
        Me.btn_aceptar.Text = "Aceptar"
        Me.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_aceptar.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btn_cancelar.Image = Global.Disar.My.Resources.Resources.img_cancelar
        Me.btn_cancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_cancelar.Location = New System.Drawing.Point(509, 693)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(88, 45)
        Me.btn_cancelar.TabIndex = 6
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'frm_permisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 746)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptar)
        Me.Controls.Add(Me.tabc_perfiles)
        Me.Controls.Add(Me.txt_usuario)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_permisos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Permisos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tabc_perfiles.ResumeLayout(False)
        Me.tc_reportes.ResumeLayout(False)
        Me.tc_reportes.PerformLayout()
        Me.tc_supply.ResumeLayout(False)
        Me.tc_supply.PerformLayout()
        Me.tc_contabilidad.ResumeLayout(False)
        Me.tc_contabilidad.PerformLayout()
        Me.tc_inventarios.ResumeLayout(False)
        Me.tc_inventarios.PerformLayout()
        Me.tc_almacen.ResumeLayout(False)
        Me.tc_almacen.PerformLayout()
        Me.tc_pdse.ResumeLayout(False)
        Me.tc_pdse.PerformLayout()
        Me.tc_bonificaciones.ResumeLayout(False)
        Me.tc_bonificaciones.PerformLayout()
        Me.tc_configuracion.ResumeLayout(False)
        Me.tc_configuracion.PerformLayout()
        Me.tc_monitoreo.ResumeLayout(False)
        Me.tc_monitoreo.PerformLayout()
        Me.tc_adicionales.ResumeLayout(False)
        Me.tc_adicionales.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_usuario As System.Windows.Forms.TextBox
    Friend WithEvents permisos_reportes As System.Windows.Forms.CheckedListBox
    Friend WithEvents tabc_perfiles As System.Windows.Forms.TabControl
    Friend WithEvents tc_reportes As System.Windows.Forms.TabPage
    Friend WithEvents tc_supply As System.Windows.Forms.TabPage
    Friend WithEvents tc_contabilidad As System.Windows.Forms.TabPage
    Friend WithEvents tc_inventarios As System.Windows.Forms.TabPage
    Friend WithEvents tc_almacen As System.Windows.Forms.TabPage
    Friend WithEvents tc_pdse As System.Windows.Forms.TabPage
    Friend WithEvents tc_bonificaciones As System.Windows.Forms.TabPage
    Friend WithEvents tc_configuracion As System.Windows.Forms.TabPage
    Friend WithEvents permisos_supply As System.Windows.Forms.CheckedListBox
    Friend WithEvents permisos_contabilidad As System.Windows.Forms.CheckedListBox
    Friend WithEvents permisos_inventarios As System.Windows.Forms.CheckedListBox
    Friend WithEvents permisos_almacen As System.Windows.Forms.CheckedListBox
    Friend WithEvents permisos_pdse As System.Windows.Forms.CheckedListBox
    Friend WithEvents permisos_bonificaciones As System.Windows.Forms.CheckedListBox
    Friend WithEvents permisos_configuracion As System.Windows.Forms.CheckedListBox
    Friend WithEvents mol_reportes As System.Windows.Forms.CheckBox
    Friend WithEvents mol_supply As System.Windows.Forms.CheckBox
    Friend WithEvents mol_contabilidad As System.Windows.Forms.CheckBox
    Friend WithEvents mol_inventarios As System.Windows.Forms.CheckBox
    Friend WithEvents mol_almacen As System.Windows.Forms.CheckBox
    Friend WithEvents mol_pdse As System.Windows.Forms.CheckBox
    Friend WithEvents mol_bonificaciones As System.Windows.Forms.CheckBox
    Friend WithEvents mol_configuracion As System.Windows.Forms.CheckBox
    Friend WithEvents btn_aceptar As System.Windows.Forms.Button
    Friend WithEvents btn_cancelar As System.Windows.Forms.Button
    Friend WithEvents tc_monitoreo As System.Windows.Forms.TabPage
    Friend WithEvents mol_monitoreo As System.Windows.Forms.CheckBox
    Friend WithEvents permisos_monitoreo As System.Windows.Forms.CheckedListBox
    Friend WithEvents tc_adicionales As System.Windows.Forms.TabPage
    Friend WithEvents mol_adicionales As System.Windows.Forms.CheckBox
    Friend WithEvents permisos_adicionales As System.Windows.Forms.CheckedListBox
End Class
