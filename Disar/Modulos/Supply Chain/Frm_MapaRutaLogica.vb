Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports GMap.NET.MapProviders
Imports GMap.NET
Imports GMap.NET.WindowsForms
Imports GMap.NET.WindowsForms.Markers

Imports System.Drawing.Imaging
Imports System.Drawing.Printing

Public Class Frm_MapaRutaLogica

    Dim Overlay2 As New GMapOverlay("Ruta")
    Dim markersOverlay As New GMapOverlay("markers")
    Dim routesOverlay As New GMapOverlay("routes")
    Dim Contador As Integer = 0
    Dim Estilo As Integer = 1
    Public Lect As Integer = 0

    Dim PosXLabel As Integer
    Dim PosYLabel As Integer
    Dim PruebaX As Integer = -100
    Dim PruebaY As Integer = -100

    Private Sub Frm_MapaRutaLogica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Lect = 0
        CargaMapa()
    End Sub

    Sub CargaMapa()
        Contador = 0
        Try
            mapa.Overlays.Clear()
        Catch
        End Try

        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly
        mapa.DragButton = MouseButtons.Left
        mapa.CanDragMap = True
        mapa.MapProvider = GMapProviders.GoogleMap
        mapa.MinZoom = 0
        mapa.MaxZoom = 24
        mapa.Zoom = 15
        mapa.AutoScroll = True

        Dim lat As Double, lon As Double
        Dim points As New List(Of PointLatLng)()

        Try
            lat = Convert.ToDouble(Frm_RutaLogica.YAlmacen)
            lon = Convert.ToDouble(Frm_RutaLogica.XAlmacen)
            Dim ptll As New PointLatLng(Frm_RutaLogica.YAlmacen, Frm_RutaLogica.XAlmacen)
            Dim marker As New GMarkerGoogle(ptll, My.Resources.CD)
            marker.ToolTipText = Convert.ToString("Centro de Distribución")
            marker.ToolTip.Fill = Brushes.Black
            marker.ToolTip.Foreground = Brushes.White
            marker.ToolTip.Stroke = Pens.Black
            marker.ToolTip.TextPadding = New Size(20, 20)
            markersOverlay.Markers.Add(marker)
            points.Add(New PointLatLng(Frm_RutaLogica.YAlmacen, Frm_RutaLogica.XAlmacen))
            mapa.Position = New PointLatLng(Frm_RutaLogica.YAlmacen, Frm_RutaLogica.XAlmacen)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        For Each row As DataGridViewRow In Frm_RutaLogica.DataOrden.Rows
            Try
                lat = Convert.ToDouble(row.Cells(4).Value)
                lon = Convert.ToDouble(row.Cells(3).Value)
                Dim ptll As New PointLatLng(row.Cells(4).Value, row.Cells(3).Value)
                Dim marker As New GMarkerGoogle(ptll, GMarkerGoogleType.blue_dot)
                marker.ToolTipText = Convert.ToString(row.Cells(0).Value).Trim() + " " + Convert.ToString(row.Cells(2).Value)
                marker.ToolTip.Fill = Brushes.Black
                marker.ToolTip.Foreground = Brushes.White
                marker.ToolTip.Stroke = Pens.Black
                marker.ToolTip.TextPadding = New Size(20, 20)
                markersOverlay.Markers.Add(marker)
                points.Add(New PointLatLng(row.Cells(4).Value, row.Cells(3).Value))
                mapa.Position = New PointLatLng(row.Cells(4).Value, row.Cells(3).Value)
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        Next

        Try
            mapa.Overlays.Add(markersOverlay)
        Catch ex As Exception
            'MsgBox("1 " & ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try

            Dim ptllInicio As PointLatLng = New PointLatLng(Frm_RutaLogica.YAlmacen, Frm_RutaLogica.XAlmacen)
            Dim ptllFinal As PointLatLng = New PointLatLng(Frm_RutaLogica.DataOrden.Rows(0).Cells(4).Value, Frm_RutaLogica.DataOrden.Rows(0).Cells(3).Value)

            If Contador = 0 Then
            Else
                ptllInicio = New PointLatLng(Frm_RutaLogica.DataOrden.Rows(Contador - 1).Cells(4).Value, Frm_RutaLogica.DataOrden.Rows(Contador - 1).Cells(3).Value)
                ptllFinal = New PointLatLng(Frm_RutaLogica.DataOrden.Rows(Contador).Cells(4).Value, Frm_RutaLogica.DataOrden.Rows(Contador).Cells(3).Value)
            End If


            '' ''MsgBox("1: " & Frm_RutaLogica.DataOrden.Rows(0).Cells(4).Value & " " & Frm_RutaLogica.DataOrden.Rows(0).Cells(3).Value & vbNewLine & "2: " & Frm_RutaLogica.YAlmacen & " " & Frm_RutaLogica.XAlmacen)

            '' ''pointsRuta.Add(New PointLatLng(Frm_RutaLogica.YAlmacen, Frm_RutaLogica.XAlmacen))
            '' ''pointsRuta.Add(New PointLatLng(Frm_RutaLogica.DataOrden.Rows(0).Cells(4).Value, Frm_RutaLogica.DataOrden.Rows(0).Cells(3).Value))
            '' ''mp = New MapRoute(pointsRuta, "R")

            Dim Direccion As New GDirections
            Dim ruta = GMapProviders.GoogleMap.GetDirections(Direccion, ptllInicio, ptllFinal, False, False, False, False, True)

            Dim r As New GMapRoute(Direccion.Route, "Ruta1")


            Dim routesOverlay As New GMapOverlay("routes")

            routesOverlay.Routes.Add(r)

            mapa.Overlays.Add(routesOverlay)

            mapa.Position = New PointLatLng(ptllFinal.Lat, ptllFinal.Lng)
            Contador += 1

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim puntoini As New PointLatLng()
        Dim puntofin As New PointLatLng()
        Overlay2.Routes.Clear()
        For Each marcaact As GMapMarker In markersOverlay.Markers
            puntoini = marcaact.Position
            If puntofin.Lng = 0 Then
                puntofin = marcaact.Position
            Else
                haceruta(puntofin, puntoini)
                puntofin = puntoini
            End If
        Next
        mapa.Position = New PointLatLng(Frm_RutaLogica.YAlmacen, Frm_RutaLogica.XAlmacen)
    End Sub

    Private Sub haceruta(ByVal origen As PointLatLng, ByVal destino As PointLatLng)
        'Dim rutapoint As New List(Of PointLatLng)()
        'rutapoint.Add(origen)
        'rutapoint.Add(destino)

        Dim ptllInicio As PointLatLng = New PointLatLng(origen.Lat, origen.Lng)
        Dim ptllFinal As PointLatLng = New PointLatLng(destino.Lat, destino.Lng)

        '' ''MsgBox("1: " & Frm_RutaLogica.DataOrden.Rows(0).Cells(4).Value & " " & Frm_RutaLogica.DataOrden.Rows(0).Cells(3).Value & vbNewLine & "2: " & Frm_RutaLogica.YAlmacen & " " & Frm_RutaLogica.XAlmacen)

        '' ''pointsRuta.Add(New PointLatLng(Frm_RutaLogica.YAlmacen, Frm_RutaLogica.XAlmacen))
        '' ''pointsRuta.Add(New PointLatLng(Frm_RutaLogica.DataOrden.Rows(0).Cells(4).Value, Frm_RutaLogica.DataOrden.Rows(0).Cells(3).Value))
        '' ''mp = New MapRoute(pointsRuta, "R")
        Dim Direccion As New GDirections
        Dim ruta = GMapProviders.GoogleMap.GetDirections(Direccion, ptllInicio, ptllFinal, False, False, False, False, True)

        Try
            Dim r As New GMapRoute(Direccion.Route, "Ruta1")
            routesOverlay.Routes.Add(r)

            mapa.Overlays.Add(routesOverlay)

        Catch ex As Exception
        End Try
        'Dim ruta0 As New GMapRoute(rutapoint, "Nombre")
        'Dim ruta As New GMapRoute(rutapoint, ruta0.Name)
        'Overlay2.Routes.Add(ruta)
        'mapa.Overlays.Add(Overlay2)
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Try
            CargaMapa()
        Catch
        End Try
    End Sub

    Private Sub EstiloGoogleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstiloGoogleToolStripMenuItem.Click
        mapa.MapProvider = GMapProviders.GoogleMap
    End Sub

    Private Sub EstiloSatéliteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstiloSatéliteToolStripMenuItem.Click
        mapa.MapProvider = GMapProviders.GoogleChinaSatelliteMap
    End Sub

    Private Sub EstiloCalleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EstiloCalleToolStripMenuItem.Click
        mapa.MapProvider = GMapProviders.BingMap
    End Sub

    Private Sub HíbridoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HíbridoToolStripMenuItem.Click
        mapa.MapProvider = GMapProviders.GoogleChinaHybridMap
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        Frm_RutaLogica.BringToFront()
        Lect = 0
    End Sub
 
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton6.Click
        GuardaImagen.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp"
        GuardaImagen.ShowDialog()
        If GuardaImagen.FileName <> "" Then
            GuardarPanelComoJpg(PanelIMG, GuardaImagen.FileName)
        End If
    End Sub

    Private Sub GuardarPanelComoJpg(ByVal panel As Panel, ByVal ruta As String)
        Dim rect As Rectangle = panel.ClientRectangle
        Dim jpg As New Bitmap(rect.Width, rect.Height)
        panel.DrawToBitmap(jpg, rect)
        jpg.Save(ruta, ImageFormat.Jpeg)

    End Sub

    Private Sub ToolStripButton7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton7.Click
        If Estilo = 1 Then
            'Dim Numero As Integer = 1
            For Each marker As GMarkerGoogle In markersOverlay.Markers
                marker.ToolTip.Fill = Brushes.White
                marker.ToolTip.Foreground = Brushes.Black
                marker.ToolTip.Stroke = Pens.Black
                marker.ToolTip.TextPadding = New Size(2, 10)
                marker.ToolTipMode = MarkerTooltipMode.Always
                marker.ToolTip.Font = New Font(FontFamily.GenericSansSerif, _
            7.0F, FontStyle.Regular)
                'Dim label1 As New Label
                'label1.Name = "L" & Numero
                'Numero += 1
                'label1.AutoSize = True
                'label1.Text = marker.ToolTipText
                'mapa.Controls.Add(label1)
                'label1.Location = New Point(marker.LocalPosition.X, marker.LocalPosition.Y)
                'label1.BringToFront()
                'AsignarEventos(Me)
            Next
            Estilo = 0
        Else
            For Each marker As GMarkerGoogle In markersOverlay.Markers
                marker.ToolTip.Fill = Brushes.Black
                marker.ToolTip.Foreground = Brushes.White
                marker.ToolTip.Stroke = Pens.Black
                marker.ToolTip.TextPadding = New Size(20, 10)
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Next
            Estilo = 1
        End If
    End Sub

    Private Sub PictureCer(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureAcerca.Click
        mapa.Zoom += 1
    End Sub

    Private Sub PictureLej(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureAleja.Click
        mapa.Zoom -= 1
    End Sub

    Private Sub mapa_OnMarkerClick(ByVal item As GMap.NET.WindowsForms.GMapMarker, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mapa.OnMarkerClick
        'If item.ToolTipMode = MarkerTooltipMode.Always Then
        '    item.ToolTipMode = MarkerTooltipMode.OnMouseOver
        'Else
        '    item.ToolTipMode = MarkerTooltipMode.Always
        'End If
        item.ToolTip.Offset = New Point(PruebaX, PruebaY)
    End Sub

    Private Sub mapa_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mapa.MouseClick
        Dim AX As Decimal = e.X - (mapa.Width / 2)
        Dim AY As Decimal = e.Y - (mapa.Height / 2)
        ''Dim AX As Decimal = mapa.FromLocalToLatLng(e.X, e.Y).Lng
        ''Dim AY As Decimal = mapa.FromLocalToLatLng(e.X, e.Y).Lng
        PruebaX = AX
        PruebaY = AY
    End Sub

    Private Sub GoogleAlternativoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GoogleAlternativoToolStripMenuItem.Click
        mapa.MapProvider = GMapProviders.GoogleChinaMap
    End Sub

    'Public _x, _y As Integer
    'Public Movimiento As Boolean


    'Private Sub Control_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    _x = e.X
    '    _y = e.Y
    '    If e.Button = MouseButtons.Left Then
    '        Movimiento = True
    '    End If
    'End Sub

    'Private Sub Control_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If Movimiento Then
    '        CType(sender, Control).Left = e.X + CType(sender, Control).Left - _x
    '        CType(sender, Control).Top = e.Y + CType(sender, Control).Top - _y
    '    End If
    'End Sub

    'Private Sub Control_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    Movimiento = False
    'End Sub

    'Public Sub AsignarEventos(ByVal _Controles As Control)

    '    Dim Controles As Control

    '    For Each Controles In _Controles.Controls
    '        AddHandler Controles.MouseDown, AddressOf Control_MouseDown
    '        AddHandler Controles.MouseMove, AddressOf Control_MouseMove
    '        AddHandler Controles.MouseUp, AddressOf Control_MouseUp
    '        AsignarEventos(Controles)
    '    Next
    'End Sub


End Class
