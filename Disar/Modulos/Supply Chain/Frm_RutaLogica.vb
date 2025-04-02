Imports System.Text
Imports Disar.data

Public Class Frm_RutaLogica

    Dim style As Microsoft.Office.Interop.Excel.Style

    Public XAlmacen As Decimal
    Public YAlmacen As Decimal

    Private dragBoxFromMouseDown As Rectangle
    Private rowIndexFromMouseDown As Integer
    Private rowIndexOfItemUnderMouseToDrop As Integer

    Private Sub Frm_RutaLogica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboEMPRESA.Items.Clear()
        If _Inicio.SANRAFAEL = 1 Then
            ComboEMPRESA.Items.Add("SAN RAFAEL")
        End If
        If _Inicio.DIMOSA = 1 Then
            ComboEMPRESA.Items.Add("DIMOSA")
        End If
        ComboEMPRESA.SelectedIndex = 0
        LlenaVendedores()
    End Sub

    Sub LlenaVendedores()
        Try
            Dim db As New ClsBitacoraEventos
            ComboVendedores.DataSource = db.Entregadores
            ComboVendedores.ValueMember = "Codigo"
            ComboVendedores.DisplayMember = "Nombre"
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnRuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRuta.Click
        'Try
        '    Dim conexion_bita As New cls_bitacora_reporteador
        '    conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó Ruta Lógica de Entregador: " & ComboVendedores.Text & " Fecha: " & DFecha.Value, "Supply Chain", _
        '                              "Fecha: " & DateTime.Now)
        'Catch ex As Exception
        'End Try

        Try
            DataDatosFiltrados.Rows.Clear()
            DataOrden.Rows.Clear()
        Catch ex As Exception
        End Try

        Try
            DataDatosFiltrados.Columns.Clear()
            DataOrden.Columns.Clear()
        Catch ex As Exception
        End Try

        Dim db As New ClsBitacoraEventos
        If ComboEMPRESA.Text = "SAN RAFAEL" Then
            DataDatosFiltrados.DataSource = db.RClientesRuta(ComboVendedores.SelectedValue, DFecha.Value)
        Else
            DataDatosFiltrados.DataSource = db.RClientesRutaDIMOSA(ComboVendedores.SelectedValue, DFecha.Value)
        End If


        Dim Columna6 As New DataGridViewTextBoxColumn
        Columna6.Name = "Agregado"
        Columna6.HeaderText = "Agregado"

        Dim Columna7 As New DataGridViewTextBoxColumn
        Columna7.Name = "Distancia"
        Columna7.HeaderText = "Distancia KM"

        For Each column As DataGridViewColumn In DataDatosFiltrados.Columns
            DataOrden.Columns.Add(column.HeaderText, column.HeaderText)
        Next

        DataDatosFiltrados.Columns.Add(Columna6)
        DataDatosFiltrados.Columns.Add(Columna7)

        Dim X As Decimal = 0
        Dim Y As Decimal = 0

        Dim RadioTierraKm As Decimal = 6378.137
        Dim PuntoAnterior As String = ""
        Try
            If DataDatosFiltrados.Rows(0).Cells(5).Value = 2 Then
                PuntoAnterior = "Almacén SRC"
                X = -88.761963
                Y = 14.787648
            End If
            If DataDatosFiltrados.Rows(0).Cells(5).Value = 1 Then
                PuntoAnterior = "Almacén SPS"
                X = -88.017814
                Y = 15.526565
            End If
            If DataDatosFiltrados.Rows(0).Cells(5).Value = 3 Then
                PuntoAnterior = "Almacén Tocoa"
                X = -85.999195
                Y = 15.658746
            End If
            If DataDatosFiltrados.Rows(0).Cells(5).Value = 4 Then
                PuntoAnterior = "Almacén Tegucigalpa"
                X = -87.174509
                Y = 14.113541
            End If
            XAlmacen = X
            YAlmacen = Y
        Catch ex As Exception
        End Try

        Dim X2 As Decimal
        Dim Y2 As Decimal

        Dim A1 As String = ""
        Dim A2 As String = ""
        Dim A3 As String = ""
        Dim A4 As String = ""
        Dim A5 As String = ""
        Dim A6 As String = ""
        Dim Dist As String = ""

        For i As Integer = 0 To DataDatosFiltrados.RowCount - 1
            Dim Menor As Decimal = 10000000
            Dim NewX As Decimal
            Dim NewY As Decimal

            If i > 0 Then
                X = NewX
                Y = NewY
            End If

            For Each row As DataGridViewRow In DataDatosFiltrados.Rows

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

                    If distancia <= Menor And row.Cells("Agregado").Value <> "Si" Then
                        Menor = distancia
                        A1 = row.Cells(0).Value
                        A2 = row.Cells(1).Value
                        If Not IsDBNull(row.Cells(2).Value) Then
                            A3 = row.Cells(2).Value
                        Else
                            A3 = "0"
                        End If
                        If Not IsDBNull(row.Cells(3).Value) Then
                            A4 = row.Cells(3).Value
                        Else
                            A4 = "0"
                        End If

                        If Not IsDBNull(row.Cells(4).Value) Then
                            A5 = row.Cells(4).Value
                        Else
                            A5 = "0"
                        End If

                        If Not IsDBNull(row.Cells("CALLE").Value) Then
                            A6 = row.Cells("CALLE").Value
                        Else
                            A6 = "0"
                        End If

                        If Not IsDBNull(row.Cells("CAMPLIB14").Value) Then
                            NewX = row.Cells("CAMPLIB14").Value
                        Else
                            NewX = "0"
                        End If

                        If Not IsDBNull(row.Cells("CAMPLIB15").Value) Then
                            NewY = row.Cells("CAMPLIB15").Value
                        Else
                            NewY = "0"
                        End If

                        Dist = row.Cells("Distancia").Value

                    End If

                Catch ex As Exception
                    'MsgBox(ex.Message, MsgBoxStyle.Information, "Error al cargar info")
                End Try
            Next

            For Each row As DataGridViewRow In DataDatosFiltrados.Rows
                If row.Cells(0).Value = A1 Then
                    row.Cells("Agregado").Value = "Si"
                End If
            Next

            Try
                DataOrden.Rows.Add(A1, A2, A3, A4, A5, Math.Round(Convert.ToDecimal(Dist), 2) & " KM de " & PuntoAnterior, A6)
            Catch ex As Exception
                DataOrden.Rows.Add(A1, A2, A3, A4, A5, "", A6)
            End Try

            PuntoAnterior = A3
        Next
        Try
            If DataOrden.Rows.Count > 0 Then
                For r As Integer = 0 To DataOrden.RowCount - 1
                    Me.DataOrden.Rows(r).HeaderCell.Value = (r + 1).ToString()
                    DataOrden.Rows(r).Cells(1).Value = Chr((r + 1))
                Next
            End If
        Catch ex As Exception
        End Try
        For Each col As DataGridViewColumn In DataOrden.Columns
            col.SortMode = DataGridViewColumnSortMode.NotSortable
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
        Try
            DataOrden.Columns(1).HeaderText = "Num"
            DataOrden.Columns(1).Visible = False
            DataOrden.Columns(0).HeaderText = "ID Cliente"
            DataOrden.Columns(2).HeaderText = "Cliente"
            DataOrden.Columns(6).HeaderText = "Dirección"
            DataOrden.Columns(5).HeaderText = "Distancia (Línea Recta)"
            DataOrden.Columns(3).HeaderText = "Longitud"
            DataOrden.Columns(4).HeaderText = "Latitud"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If ComboOrden.Text = "Más cercano primero" Then
        Else
            DataOrden.Sort(DataOrden.Columns(1), System.ComponentModel.ListSortDirection.Descending)
        End If
    End Sub

    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        If DataOrden.RowCount > 0 Then
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Estilo")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SteelBlue)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter

            wSheet.Cells.Range("A1:G1").Merge()
            wSheet.Cells.Range("A1:G1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:G1").Value = " RUTA LÓGICA DE ENTREGA - " & ComboVendedores.Text & ": " & DFecha.Text
            wSheet.Cells.Range("A1:G1").Style = "Estilo"

            For c As Integer = 0 To DataOrden.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataOrden.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Estilo"
            Next

            For r As Integer = 0 To DataOrden.RowCount - 1
                For c As Integer = 0 To DataOrden.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataOrden.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                    wSheet.Cells(r + 3, c + 1).VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
                    'wSheet.Cells(r + 3, c + 1).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                Next
            Next

            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMapa.Click
        If DataOrden.RowCount > 0 Then
            Dim d As New Frm_MapaRutaLogica
            d.MdiParent = _Inicio
            d.Show()
        End If
    End Sub

    Private Sub DataOrden_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DataOrden.DragDrop
        ' The mouse locations are relative to the screen, so they must be
        ' converted to client coordinates.
        Dim clientPoint As Point = DataOrden.PointToClient(New Point(e.X, e.Y))
        ' Get the row index of the item the mouse is below.
        rowIndexOfItemUnderMouseToDrop = DataOrden.HitTest(clientPoint.X, clientPoint.Y).RowIndex

        If rowIndexOfItemUnderMouseToDrop = -1 Then Exit Sub

        If e.Effect = DragDropEffects.Move Then
            Dim rowToMove As DataGridViewRow
            rowToMove = TryCast(e.Data.GetData(GetType(DataGridViewRow)), DataGridViewRow)
            DataOrden.Rows.RemoveAt(rowIndexFromMouseDown)
            DataOrden.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove)
        End If
    End Sub

    Private Sub DataOrden_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles DataOrden.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    Private Sub DataOrden_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataOrden.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then

            If rowIndexFromMouseDown = -1 Then Exit Sub

            Try
                ' If the mouse moves outside the rectangle, start the drag.
                If dragBoxFromMouseDown <> Rectangle.Empty AndAlso Not dragBoxFromMouseDown.Contains(e.X, e.Y) Then
                    ' Proceed with the drag and drop, passing in the list item.                   
                    Dim dropEffect As DragDropEffects = sender.DoDragDrop(DataOrden.Rows(rowIndexFromMouseDown), DragDropEffects.Move)
                End If
            Catch ex As Exception
                ex.Data.Clear()
            End Try

        End If
    End Sub

    Private Sub DataOrden_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataOrden.MouseDown
        ' Get the index of the item the mouse is below.
        rowIndexFromMouseDown = sender.HitTest(e.X, e.Y).RowIndex

        If rowIndexFromMouseDown = -1 Then Exit Sub
        If rowIndexFromMouseDown <> -1 Then
            ' Remember the point where the mouse down occurred.

            ' The DragSize indicates the size that the mouse can move
            ' before a drag event should be started.               
            Dim dragSize As Size = SystemInformation.DragSize

            ' Create a rectangle using the DragSize, with the mouse position being
            ' at the center of the rectangle.
            dragBoxFromMouseDown = New Rectangle(New Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize)
        Else
            ' Reset the rectangle if the mouse is not over an item in the ListBox.
            dragBoxFromMouseDown = Rectangle.Empty
        End If

    End Sub

    Private Sub BtnSubir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSubir.Click
        Try
            Dim X = DataOrden.CurrentRow.Index
            Dim P0 As String = DataOrden.CurrentRow.Cells(0).Value
            Dim P1 As String = DataOrden.CurrentRow.Cells(1).Value
            Dim P2 As String = DataOrden.CurrentRow.Cells(2).Value
            Dim P3 As String = DataOrden.CurrentRow.Cells(3).Value
            Dim P4 As String = DataOrden.CurrentRow.Cells(4).Value
            Dim P5 As String = DataOrden.CurrentRow.Cells(5).Value
            Dim P6 As String = DataOrden.CurrentRow.Cells(6).Value
            Dim Enc As String = DataOrden.CurrentRow.HeaderCell.Value

            DataOrden.Rows.RemoveAt(X)
            DataOrden.Rows.Insert(X - 1, P0, P1, P2, P3, P4, P5, P6)
            Me.DataOrden.Rows(X - 1).HeaderCell.Value = Enc

            DataOrden.CurrentCell = DataOrden(0, X - 1)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnBajar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBajar.Click
        Try
            Dim X = DataOrden.CurrentRow.Index
            Dim P0 As String = DataOrden.CurrentRow.Cells(0).Value
            Dim P1 As String = DataOrden.CurrentRow.Cells(1).Value
            Dim P2 As String = DataOrden.CurrentRow.Cells(2).Value
            Dim P3 As String = DataOrden.CurrentRow.Cells(3).Value
            Dim P4 As String = DataOrden.CurrentRow.Cells(4).Value
            Dim P5 As String = DataOrden.CurrentRow.Cells(5).Value
            Dim P6 As String = DataOrden.CurrentRow.Cells(6).Value
            Dim Enc As String = DataOrden.CurrentRow.HeaderCell.Value

            DataOrden.Rows.RemoveAt(X)
            DataOrden.Rows.Insert(X + 1, P0, P1, P2, P3, P4, P5, P6)
            Me.DataOrden.Rows(X + 1).HeaderCell.Value = Enc

            DataOrden.CurrentCell = DataOrden(0, X + 1)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataOrden_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataOrden.CellDoubleClick
        Try
            Frm_MapaRutaLogica.Focus()
            Me.SendToBack()
            Frm_MapaRutaLogica.WindowState = FormWindowState.Maximized
            Frm_MapaRutaLogica.Lect = 1
        Catch ex As Exception
        End Try
    End Sub

End Class