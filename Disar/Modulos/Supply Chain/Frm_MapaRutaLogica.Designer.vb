<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_MapaRutaLogica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_MapaRutaLogica))
        Me.mapa = New GMap.NET.WindowsForms.GMapControl
        Me.Barra = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripDropDownButton
        Me.EstiloGoogleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GoogleAlternativoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HíbridoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EstiloSatéliteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EstiloCalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.PanelIMG = New System.Windows.Forms.Panel
        Me.PictureAleja = New System.Windows.Forms.PictureBox
        Me.PictureAcerca = New System.Windows.Forms.PictureBox
        Me.GuardaImagen = New System.Windows.Forms.SaveFileDialog
        Me.Barra.SuspendLayout()
        Me.PanelIMG.SuspendLayout()
        CType(Me.PictureAleja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureAcerca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mapa
        '
        Me.mapa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.mapa.Bearing = 0.0!
        Me.mapa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.mapa.CanDragMap = False
        Me.mapa.EmptyTileColor = System.Drawing.Color.AliceBlue
        Me.mapa.GrayScaleMode = False
        Me.mapa.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow
        Me.mapa.LevelsKeepInMemmory = 5
        Me.mapa.Location = New System.Drawing.Point(3, 3)
        Me.mapa.MarkersEnabled = True
        Me.mapa.MaxZoom = 2
        Me.mapa.MinZoom = 2
        Me.mapa.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter
        Me.mapa.Name = "mapa"
        Me.mapa.NegativeMode = False
        Me.mapa.PolygonsEnabled = True
        Me.mapa.RetryLoadTile = 0
        Me.mapa.RoutesEnabled = True
        Me.mapa.ScaleMode = GMap.NET.WindowsForms.ScaleModes.[Integer]
        Me.mapa.SelectedAreaFillColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.mapa.ShowTileGridLines = False
        Me.mapa.Size = New System.Drawing.Size(896, 728)
        Me.mapa.TabIndex = 10
        Me.mapa.Zoom = 0
        '
        'Barra
        '
        Me.Barra.AutoSize = False
        Me.Barra.Dock = System.Windows.Forms.DockStyle.Left
        Me.Barra.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator1, Me.ToolStripButton2, Me.ToolStripSeparator2, Me.ToolStripButton3, Me.ToolStripSeparator3, Me.ToolStripButton4, Me.ToolStripSeparator4, Me.ToolStripButton5, Me.ToolStripSeparator5, Me.ToolStripButton6, Me.ToolStripSeparator6, Me.ToolStripButton7, Me.ToolStripSeparator7})
        Me.Barra.Location = New System.Drawing.Point(0, 0)
        Me.Barra.Name = "Barra"
        Me.Barra.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.Barra.Size = New System.Drawing.Size(103, 746)
        Me.Barra.TabIndex = 11
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = Global.Disar.My.Resources.Resources.CD
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(101, 48)
        Me.ToolStripButton1.Text = "Siguiente ruta"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.ToolTipText = "Genera la siguiente ruta a seguir desde el punto actual"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(101, 6)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.Image = Global.Disar.My.Resources.Resources.Map_32x32
        Me.ToolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(101, 48)
        Me.ToolStripButton2.Text = "Generar ruta completa"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton2.ToolTipText = "Genera todas las rutas a seguir para completar todos los puntos de entrega"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(101, 6)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton3.Image = Global.Disar.My.Resources.Resources.Gnome_Window_Close_32
        Me.ToolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(101, 48)
        Me.ToolStripButton3.Text = "Limpiar recorrido"
        Me.ToolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton3.ToolTipText = "Limpia las rutas del mapa"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(101, 6)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EstiloGoogleToolStripMenuItem, Me.GoogleAlternativoToolStripMenuItem, Me.HíbridoToolStripMenuItem, Me.EstiloSatéliteToolStripMenuItem, Me.EstiloCalleToolStripMenuItem})
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton4.Image = Global.Disar.My.Resources.Resources.Map_hand_drawn_32
        Me.ToolStripButton4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(101, 48)
        Me.ToolStripButton4.Text = "Cambiar estilo mapa"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton4.ToolTipText = "Cambiar estilo del mapa"
        '
        'EstiloGoogleToolStripMenuItem
        '
        Me.EstiloGoogleToolStripMenuItem.Name = "EstiloGoogleToolStripMenuItem"
        Me.EstiloGoogleToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EstiloGoogleToolStripMenuItem.Text = "Google"
        '
        'GoogleAlternativoToolStripMenuItem
        '
        Me.GoogleAlternativoToolStripMenuItem.Name = "GoogleAlternativoToolStripMenuItem"
        Me.GoogleAlternativoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.GoogleAlternativoToolStripMenuItem.Text = "Google Alternativo"
        '
        'HíbridoToolStripMenuItem
        '
        Me.HíbridoToolStripMenuItem.Name = "HíbridoToolStripMenuItem"
        Me.HíbridoToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.HíbridoToolStripMenuItem.Text = "Satélite con etiquetas"
        '
        'EstiloSatéliteToolStripMenuItem
        '
        Me.EstiloSatéliteToolStripMenuItem.Name = "EstiloSatéliteToolStripMenuItem"
        Me.EstiloSatéliteToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EstiloSatéliteToolStripMenuItem.Text = "Satélite sin etiquetas"
        '
        'EstiloCalleToolStripMenuItem
        '
        Me.EstiloCalleToolStripMenuItem.Name = "EstiloCalleToolStripMenuItem"
        Me.EstiloCalleToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.EstiloCalleToolStripMenuItem.Text = "Calle"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(101, 6)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton5.Image = Global.Disar.My.Resources.Resources.img_punto_reorden
        Me.ToolStripButton5.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(101, 48)
        Me.ToolStripButton5.Text = "Cambiar orden de punto"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton5.ToolTipText = "Cambiar el orden de los puntos de entrega"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(101, 6)
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton6.Image = Global.Disar.My.Resources.Resources.Picture_Add_32
        Me.ToolStripButton6.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(101, 48)
        Me.ToolStripButton6.Text = "Obtener Imagen"
        Me.ToolStripButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(101, 6)
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Font = New System.Drawing.Font("Segoe UI", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton7.Image = Global.Disar.My.Resources.Resources.Document_Mark_As_Final_32
        Me.ToolStripButton7.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton7.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(101, 48)
        Me.ToolStripButton7.Text = "Mostrar/Ocultar nombre"
        Me.ToolStripButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton7.ToolTipText = "Mostrar/Ocultar etiquetas con códigos y nombres de clientes"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(101, 6)
        '
        'PanelIMG
        '
        Me.PanelIMG.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelIMG.Controls.Add(Me.PictureAleja)
        Me.PanelIMG.Controls.Add(Me.PictureAcerca)
        Me.PanelIMG.Controls.Add(Me.mapa)
        Me.PanelIMG.Location = New System.Drawing.Point(99, 5)
        Me.PanelIMG.Name = "PanelIMG"
        Me.PanelIMG.Size = New System.Drawing.Size(902, 734)
        Me.PanelIMG.TabIndex = 12
        '
        'PictureAleja
        '
        Me.PictureAleja.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureAleja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureAleja.Image = Global.Disar.My.Resources.Resources.Bullet_Toggle_Minus_32
        Me.PictureAleja.Location = New System.Drawing.Point(862, 47)
        Me.PictureAleja.Name = "PictureAleja"
        Me.PictureAleja.Size = New System.Drawing.Size(28, 29)
        Me.PictureAleja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureAleja.TabIndex = 11
        Me.PictureAleja.TabStop = False
        '
        'PictureAcerca
        '
        Me.PictureAcerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureAcerca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureAcerca.Image = Global.Disar.My.Resources.Resources.Badge_plus_32
        Me.PictureAcerca.Location = New System.Drawing.Point(862, 12)
        Me.PictureAcerca.Name = "PictureAcerca"
        Me.PictureAcerca.Size = New System.Drawing.Size(28, 29)
        Me.PictureAcerca.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureAcerca.TabIndex = 11
        Me.PictureAcerca.TabStop = False
        '
        'Frm_MapaRutaLogica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 746)
        Me.Controls.Add(Me.PanelIMG)
        Me.Controls.Add(Me.Barra)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Frm_MapaRutaLogica"
        Me.Text = "Mapa Ruta Lógica"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Barra.ResumeLayout(False)
        Me.Barra.PerformLayout()
        Me.PanelIMG.ResumeLayout(False)
        CType(Me.PictureAleja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureAcerca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents mapa As GMap.NET.WindowsForms.GMapControl
    Friend WithEvents Barra As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents EstiloGoogleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstiloSatéliteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstiloCalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HíbridoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton6 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PanelIMG As System.Windows.Forms.Panel
    Friend WithEvents GuardaImagen As System.Windows.Forms.SaveFileDialog
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PictureAleja As System.Windows.Forms.PictureBox
    Friend WithEvents PictureAcerca As System.Windows.Forms.PictureBox
    Friend WithEvents GoogleAlternativoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
