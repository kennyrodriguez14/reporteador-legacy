Imports Disar.data
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

Public Class FrmArmadoRutas

    Dim markersOverlay As New GMapOverlay("markers")
    Dim markersOverlayClientes As New GMapOverlay("markers")

    Dim routesOverlay As New GMapOverlay("routes")

    Dim Estilo As Integer = 1

    Dim PosXLabel As Integer
    Dim PosYLabel As Integer

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        If TextX.Text = "" Or TextY.Text = "" Then
            MsgBox("Primero debe dar doble clic sobre un punto del mapa para obtener el listado de clientes en esa zona")
        Else
            Try
                markersOverlayClientes.Markers.Clear()
            Catch
            End Try
            ObtieneClientes()
            CargaMapa()
        End If
    End Sub

    Sub CargaMapa()
        GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly
        mapa.DragButton = MouseButtons.Left
        mapa.CanDragMap = True
        mapa.MapProvider = GMapProviders.GoogleMap
        mapa.MinZoom = 0
        mapa.MaxZoom = 24
        mapa.Zoom = 8
        mapa.AutoScroll = False

        Dim lat As Double, lon As Double
        Dim points As New List(Of PointLatLng)()

        For Each row As DataGridViewRow In DataClientes.Rows
            Try
                lat = Convert.ToDouble(row.Cells(3).Value)
                lon = Convert.ToDouble(row.Cells(4).Value)
                Dim ptll As New PointLatLng(row.Cells(3).Value, row.Cells(4).Value)
                Dim marker As New GMarkerGoogle(ptll, GMarkerGoogleType.blue_dot)
                marker.ToolTipText = Convert.ToString(row.Cells(0).Value).Trim() + " " + Convert.ToString(row.Cells(1).Value)
                marker.ToolTip.Fill = Brushes.Black
                marker.ToolTip.Foreground = Brushes.White
                marker.ToolTip.Stroke = Pens.Black
                marker.ToolTip.TextPadding = New Size(20, 20)
                markersOverlayClientes.Markers.Add(marker)
                points.Add(New PointLatLng(row.Cells(3).Value, row.Cells(4).Value))
                mapa.Position = New PointLatLng(row.Cells(3).Value, row.Cells(4).Value)
            Catch ex As Exception
                'MsgBox(ex.Message)
            End Try
        Next

        Try
            mapa.Overlays.Add(markersOverlayClientes)
        Catch ex As Exception
        End Try
    End Sub
     
    Sub ObtieneClientes()

        Try
            DataDatos.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            DataDatos.Columns.Clear()
        Catch ex As Exception
        End Try
        Try
            DataClientes.Rows.Clear()
        Catch ex As Exception
        End Try

        Dim db As New ClsBitacoraEventos
        DataDatos.DataSource = db.RClientesPorFecha(DateFecha.Value)

        Dim Columna6 As New DataGridViewTextBoxColumn
        Columna6.Name = "Agregado"
        Columna6.HeaderText = "Agregado"

        Dim Columna7 As New DataGridViewTextBoxColumn
        Columna7.Name = "Distancia"
        Columna7.HeaderText = "Distancia KM"

        DataDatos.Columns.Add(Columna6)
        DataDatos.Columns.Add(Columna7)

        Dim X As Decimal = TextX.Text
        Dim Y As Decimal = TextY.Text

        Dim RadioTierraKm As Decimal = 6378.137
        Dim PuntoAnterior As String = ""

        Dim X2 As Decimal
        Dim Y2 As Decimal

        For Each row As DataGridViewRow In DataDatos.Rows

            Try
                If Not IsDBNull(row.Cells("CAMPLIB14").Value) Then
                    X2 = row.Cells("CAMPLIB14").Value
                Else
                    X2 = "0"
                End If

                If Not IsDBNull(row.Cells("CAMPLIB15").Value) Then
                    Y2 = row.Cells("CAMPLIB15").Value
                Else
                    Y2 = "0"
                End If


                Dim GradoARad = Math.PI / 180

                Dim Latitud1 As Decimal = Y * GradoARad
                Dim Latitud2 As Decimal = Y2 * GradoARad
                Dim Longitud1 As Decimal = X * GradoARad
                Dim Longitud2 As Decimal = X2 * GradoARad

                Dim dLongitud As Decimal = Longitud2 - Longitud1

                Dim distancia = Math.Acos(Math.Sin(Latitud1) * Math.Sin(Latitud2) + Math.Cos(Latitud1) * Math.Cos(Latitud2) * Math.Cos(dLongitud)) * RadioTierraKm

                row.Cells("Distancia").Value = distancia

                If distancia <= Val(TextKM.Text) Then
                    DataClientes.Rows.Add(row.Cells("CVE_CLIE").Value, row.Cells("NOMBRE").Value, row.Cells("CALLE").Value, row.Cells("CAMPLIB15").Value, row.Cells("CAMPLIB14").Value)
                End If

            Catch
            End Try
        Next
        Try
            TextCantidadClientes.Text = DataClientes.RowCount
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmArmadoRutas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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
        mapa.Zoom = 8
        mapa.AutoScroll = False
        mapa.Position = New PointLatLng(15.526565, -88.017814)
    End Sub

    Private Sub mapa_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mapa.MouseDoubleClick
        Try
            mapa.Overlays.Clear()
        Catch
        End Try

        TextY.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lat
        TextX.Text = mapa.FromLocalToLatLng(e.X, e.Y).Lng
        Dim lat As Decimal
        Dim lon As Decimal
        Try
            lat = Convert.ToDouble(TextY.Text)
            lon = Convert.ToDouble(TextX.Text)
            Dim ptll As New PointLatLng(lat, lon)
            Dim marker As New GMarkerGoogle(ptll, GMarkerGoogleType.green_dot)
            marker.ToolTipText = Convert.ToString("Punto Creado")
            marker.ToolTip.Fill = Brushes.Black
            marker.ToolTip.Foreground = Brushes.White
            marker.ToolTip.Stroke = Pens.Black
            marker.ToolTip.TextPadding = New Size(20, 20)
            markersOverlay.Markers.Clear()
            markersOverlay.Markers.Add(marker)
            mapa.Position = New PointLatLng(lat, lon)

            mapa.Overlays.Add(markersOverlay)
            mapa.Position = New PointLatLng(lat, lon)
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Etiquetas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Etiquetas.Click
        If Estilo = 1 Then
            For Each marker As GMarkerGoogle In markersOverlayClientes.Markers
                marker.ToolTip.Fill = Brushes.White
                marker.ToolTip.Foreground = Brushes.Black
                marker.ToolTip.Stroke = Pens.Black
                marker.ToolTip.TextPadding = New Size(5, 5)
                marker.ToolTipMode = MarkerTooltipMode.Always
                marker.ToolTip.Font = New Font(FontFamily.GenericSansSerif, _
            7.0F, FontStyle.Regular)
            Next
            Estilo = 0
        Else
            For Each marker As GMarkerGoogle In markersOverlayClientes.Markers
                marker.ToolTip.Fill = Brushes.Black
                marker.ToolTip.Foreground = Brushes.White
                marker.ToolTip.Stroke = Pens.Black
                marker.ToolTip.TextPadding = New Size(20, 10)
                marker.ToolTipMode = MarkerTooltipMode.OnMouseOver
            Next
            Estilo = 1
        End If
    End Sub

    Private Sub ComboEstilo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEstilo.SelectedIndexChanged
        If ComboEstilo.Text = "Google" Then
            mapa.MapProvider = GMapProviders.GoogleMap
        End If
        If ComboEstilo.Text = "Google Alternativo" Then
            mapa.MapProvider = GMapProviders.GoogleChinaMap
        End If
        If ComboEstilo.Text = "Satélite con etiquetas" Then
            mapa.MapProvider = GMapProviders.GoogleChinaSatelliteMap
        End If
        If ComboEstilo.Text = "Satélite sin etiquetas" Then
            mapa.MapProvider = GMapProviders.GoogleChinaHybridMap
        End If
        If ComboEstilo.Text = "Calle" Then
            mapa.MapProvider = GMapProviders.BingMap
        End If
    End Sub

    Private Sub DataClientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataClientes.CellDoubleClick
        Dim lat As Decimal
        Dim Lon As Decimal
        Try
            lat = Convert.ToDouble(DataDatos.CurrentRow.Cells(3).Value)
            Lon = Convert.ToDouble(DataDatos.CurrentRow.Cells(4).Value)
            mapa.Position = New PointLatLng(lat, Lon)
        Catch ex As Exception
        End Try

    End Sub
End Class