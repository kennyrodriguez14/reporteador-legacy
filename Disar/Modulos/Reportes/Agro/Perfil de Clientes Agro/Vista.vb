Imports Disar.data
Imports System.Math

Public Class Vista

    Dim Pro As New ClsFunciones
    Dim StatusDevoluciones As Boolean
    Dim StatusDetalle As Boolean

    Private Sub Vista_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Generó perfil de cliente Agro", "REPORTES", _
                                      "Fecha: " & DateTime.Now)
        Catch ex As Exception
        End Try
        Try
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(0).Value) Then
                TextClaveCliente.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(0).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(1).Value) Then
                TextNombreCliente.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(1).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(3).Value) Then
                TextUbicacion.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(3).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(4).Value) Then
                TextIDRTN.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(4).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(5).Value) Then
                TextListas.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(5).Value
            End If

            Dim Balanceados As Char = Clientes_Agro.DataClientes.CurrentRow.Cells(5).Value.ToString.Chars(0)
            Dim Mascotas As Char = Clientes_Agro.DataClientes.CurrentRow.Cells(5).Value.ToString.Chars(1)
            Dim Fertilizantes As Char = Clientes_Agro.DataClientes.CurrentRow.Cells(5).Value.ToString.Chars(2)
            Dim sacos As Char = Clientes_Agro.DataClientes.CurrentRow.Cells(5).Value.ToString.Chars(3)
            Dim Otros As Char = Clientes_Agro.DataClientes.CurrentRow.Cells(5).Value.ToString.Chars(4)

            TextListas.Text = (vbNewLine & "Balanceados: " & vbTab & Balanceados & vbNewLine & "Mascotas: " & vbTab & vbTab & Mascotas & vbNewLine & "Fertilizantes: " & vbTab & Fertilizantes & vbNewLine & "Sacos: " & vbTab & vbTab & sacos & vbNewLine & "Insumos: " & vbTab & vbTab & Otros)

            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(6).Value) Then
                TextDia.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(6).Value
            End If

            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(9).Value) Then
                TextVendedor.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(9).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(10).Value) Then
                TextCultivos.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(10).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(11).Value) Then
                TextManzanas.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(11).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(12).Value) Then
                TextTipoGranja.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(12).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(13).Value) Then
                TextAnimales.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(13).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(14).Value) Then
                TextTieneMascota.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(14).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(15).Value) Then
                TextAgroservicio.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(15).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(16).Value) Then
                TextPorque.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(16).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(17).Value) Then
                TextMarcas.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(17).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(18).Value) Then
                TextBox1.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(18).Value
            End If
            If Not IsDBNull(Clientes_Agro.DataClientes.CurrentRow.Cells(19).Value) Then
                TextBox2.Text = Clientes_Agro.DataClientes.CurrentRow.Cells(19).Value
            End If
            Actualiza()
            CantidadFact.Value = DataCompras.RowCount
            DataCompras.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7)
            DataCompras.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7)
            DataDetalles.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7)
            DataDetalles.DefaultCellStyle.Font = New Font("Microsoft Sans Serif", 7)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
    End Sub

    Private Sub DataCompras_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataCompras.CellClick, DataCompras.CellEnter
        Dim StatusCancelada As String = "E"
        Try
            DataCancela.DataSource = Pro.BuscaDevoluciones(DataCompras.CurrentRow.Cells(7).Value)
            StatusCancelada = DataCancela.CurrentRow.Cells(2).Value
        Catch ex As Exception

        End Try
        Try
            DataDetalles.DataSource = Nothing
            DataDetalles.Columns.Clear()
            DataDetalles.DataSource = Pro.BuscaDetalles(DataCompras.CurrentRow.Cells(0).Value)

            Dim CantidadDevuelta As New DataGridViewTextBoxColumn
            CantidadDevuelta.Name = "CANTIDAD DEVUELTA"
            DataDetalles.Columns.Add(CantidadDevuelta)

            Dim ImporteDevuelto As New DataGridViewTextBoxColumn
            ImporteDevuelto.Name = "IMPORTE TOTAL DEVOLUCION"
            DataDetalles.Columns.Add(ImporteDevuelto)

            Dim TOTALDESPUESDEVOLUCION As New DataGridViewTextBoxColumn
            TOTALDESPUESDEVOLUCION.Name = "TOTAL ANTES DE ISV"
            DataDetalles.Columns.Add(TOTALDESPUESDEVOLUCION)

            StatusDetalle = False
            For a As Integer = 0 To DataDetalles.RowCount - 1

                Dim Descuento As Decimal = DataDetalles.Rows(a).Cells(5).Value * (DataDetalles.Rows(a).Cells(9).Value / 100)
                DataDetalles.Rows(a).Cells(10).Value = (DataDetalles.Rows(a).Cells(5).Value - Descuento) + DataDetalles.Rows(a).Cells(8).Value
                Try
                    DataDevolucionDetalles.DataSource = Pro.BuscaDevolucionesProducto(DataCompras.CurrentRow.Cells(7).Value, DataDetalles.Rows(a).Cells(0).Value)

                    If DataDevolucionDetalles.RowCount > 0 Then
                        If StatusCancelada = "E" Then
                            StatusDetalle = True
                            DataDetalles.Rows(a).Cells(11).Value = DataDevolucionDetalles.Rows(0).Cells(2).Value
                            Dim ImpuestoDevuelto As Decimal = DataDevolucionDetalles.Rows(0).Cells(1).Value
                            Dim SubtotalDevuelto As Decimal = DataDetalles.Rows(a).Cells(4).Value * DataDetalles.Rows(a).Cells(11).Value
                            Dim DescuentoDevuelto As Decimal = SubtotalDevuelto * (DataDetalles.Rows(a).Cells(9).Value / 100)
                            Dim TotalDevuelto As Decimal = (SubtotalDevuelto - DescuentoDevuelto) + ImpuestoDevuelto
                            DataDetalles.Rows(a).Cells(12).Value = TotalDevuelto

                            Dim CantidadRestante As Decimal = DataDetalles.Rows(a).Cells(3).Value - DataDetalles.Rows(a).Cells(11).Value
                            Dim Subtotalrestante As Decimal = CantidadRestante * DataDetalles.Rows(a).Cells(4).Value
                            Dim DescuentoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(9).Value / 100)
                            Dim ImpuestoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(7).Value / 100)
                            Dim TotalRestante As Decimal = (Subtotalrestante - DescuentoRestante) + ImpuestoRestante
                            Dim TOTAL As Decimal = (TotalRestante - ImpuestoRestante)
                            DataDetalles.Rows(a).Cells(13).Value = TOTAL
                        Else
                            DataDetalles.Rows(a).Cells(11).Value = 0
                            DataDetalles.Rows(a).Cells(12).Value = 0
                            Dim CantidadRestante As Decimal = DataDetalles.Rows(a).Cells(3).Value - DataDetalles.Rows(a).Cells(11).Value
                            Dim Subtotalrestante As Decimal = CantidadRestante * DataDetalles.Rows(a).Cells(4).Value
                            Dim DescuentoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(9).Value / 100)
                            Dim ImpuestoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(7).Value / 100)
                            Dim TotalRestante As Decimal = (Subtotalrestante - DescuentoRestante) + ImpuestoRestante
                            Dim TOTAL As Decimal = (TotalRestante - ImpuestoRestante)
                            DataDetalles.Rows(a).Cells(13).Value = TOTAL
                        End If
                        Dim Rojo As Color = Color.Red
                        For Each cel As DataGridViewCell In DataDetalles.Rows(a).Cells
                            cel.Style.ForeColor = Rojo
                        Next
                    Else

                        DataDetalles.Rows(a).Cells(11).Value = 0
                        DataDetalles.Rows(a).Cells(12).Value = 0
                        Dim CantidadRestante As Decimal = DataDetalles.Rows(a).Cells(3).Value - DataDetalles.Rows(a).Cells(11).Value
                        Dim Subtotalrestante As Decimal = CantidadRestante * DataDetalles.Rows(a).Cells(4).Value
                        Dim DescuentoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(9).Value / 100)
                        Dim ImpuestoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(7).Value / 100)
                        Dim TotalRestante As Decimal = (Subtotalrestante - DescuentoRestante) + ImpuestoRestante
                        Dim TOTAL As Decimal = (TotalRestante - ImpuestoRestante)
                        DataDetalles.Rows(a).Cells(13).Value = TOTAL

                    End If
                Catch ex As Exception
                    DataDetalles.Rows(a).Cells(11).Value = 0
                    DataDetalles.Rows(a).Cells(12).Value = 0
                    Dim CantidadRestante As Decimal = DataDetalles.Rows(a).Cells(3).Value - DataDetalles.Rows(a).Cells(11).Value
                    Dim Subtotalrestante As Decimal = CantidadRestante * DataDetalles.Rows(a).Cells(4).Value
                    Dim DescuentoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(9).Value / 100)
                    Dim ImpuestoRestante As Decimal = Subtotalrestante * (DataDetalles.Rows(a).Cells(7).Value / 100)
                    Dim TotalRestante As Decimal = (Subtotalrestante - DescuentoRestante) + ImpuestoRestante
                    Dim TOTAL As Decimal = (TotalRestante - ImpuestoRestante)
                    DataDetalles.Rows(a).Cells(13).Value = TOTAL
                End Try
            Next

            DataDetalles.Columns(6).Visible = False
            DataDetalles.Columns(7).Visible = False
            DataDetalles.Columns(8).Visible = False
            DataDetalles.Columns(9).Visible = False

            DataDetalles.Columns(11).Visible = StatusDetalle
            DataDetalles.Columns(12).Visible = StatusDetalle
            Dim Style As New DataGridViewCellStyle
            Style.Font = New Font(DataDetalles.Font, FontStyle.Bold)
            TOTALDESPUESDEVOLUCION.DefaultCellStyle = Style


        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Aviso")
        End Try
        Try
            For i = 0 To DataDetalles.Columns.Count - 1
                DataDetalles.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i
        Catch
        End Try

    End Sub

    Private Sub CantidadFact_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CantidadFact.ValueChanged
        Try
            Actualiza()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Sub Actualiza()
        DataCompras.DataSource = Nothing
        DataCompras.Columns.Clear()
        If GroupFacturas.Visible = True Then
            DataCompras.DataSource = Pro.BuscaFacturas(TextClaveCliente.Text, CantidadFact.Value)
            CantidadFact.Focus()
        Else
            DataCompras.DataSource = Pro.BuscaFacturasRangoFecha(TextClaveCliente.Text, DateDesde.Value, DateHasta.Value)
        End If


        Dim Columna As New DataGridViewTextBoxColumn
        Columna.Name = "TOTAL IMPORTE DEVOLUCION"
        DataCompras.Columns.Add(Columna)

        Dim Columna2 As New DataGridViewTextBoxColumn
        Columna2.Name = "TOTAL ANTES DE ISV"
        DataCompras.Columns.Add(Columna2)

        StatusDevoluciones = False

        For a As Integer = 0 To DataCompras.RowCount - 1
            Try
                DataDevolucion.DataSource = Pro.BuscaDevoluciones(DataCompras.Rows(a).Cells(7).Value)
                If DataDevolucion.RowCount > 0 Then
                    DataCompras.Rows(a).Cells(8).Value = DataDevolucion.CurrentRow.Cells(0).Value
                    Dim ImporteDevolucion As Decimal = DataDevolucion.CurrentRow.Cells(0).Value
                    Dim ImpuestoDevolucion As Decimal = DataDevolucion.CurrentRow.Cells(1).Value
                    DataDevolucion.DataSource = Nothing
                    DataCompras.Rows(a).Cells(9).Value = (DataCompras.Rows(a).Cells(6).Value - DataCompras.Rows(a).Cells(3).Value) - (ImporteDevolucion - ImpuestoDevolucion)
                    StatusDevoluciones = True
                Else
                    DataCompras.Rows(a).Cells(8).Value = 0
                    DataCompras.Rows(a).Cells(9).Value = DataCompras.Rows(a).Cells(6).Value - DataCompras.Rows(a).Cells(3).Value
                End If
            Catch ex As Exception

            End Try
            If IsDBNull(DataCompras.Rows(a).Cells(7).Value) Then
                DataCompras.Rows(a).Cells(8).Value = 0
                DataCompras.Rows(a).Cells(9).Value = DataCompras.Rows(a).Cells(6).Value - DataCompras.Rows(a).Cells(3).Value
            End If
        Next
        Dim total As Decimal = 0

        For a As Integer = 0 To DataCompras.RowCount - 1
            total = DataCompras.Rows(a).Cells(9).Value + total
            TextFecha.Text = DataCompras.Rows(a).Cells(1).Value
        Next

        Dim Style As New DataGridViewCellStyle
        Style.Font = New Font(DataCompras.Font, FontStyle.Bold)
        Columna2.DefaultCellStyle = Style
        TextTotalFacturas.Text = Format(Round(total, 2), "##,##00.00")
        Try
            DataCompras.Columns(7).Visible = StatusDevoluciones
            Columna.Visible = StatusDevoluciones
        Catch
        End Try
        Try
            For i = 0 To DataCompras.Columns.Count - 1
                DataCompras.Columns.Item(i).SortMode = DataGridViewColumnSortMode.Programmatic
            Next i
        Catch
        End Try
    End Sub

    Private Sub BtnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDetalle.Click

        Dim Balanceados As Decimal = 0
        Dim Mascotas As Decimal = 0
        Dim Fertilizantes As Decimal = 0
        Dim Sacos As Decimal = 0
        Dim Insumos As Decimal = 0
        Dim Especificar As Decimal = 0

        Dim NotasCredito As Decimal = 0
        Progress.Value = 0
        Progress.Maximum = DataCompras.RowCount
        For a As Integer = 0 To DataCompras.RowCount - 1
            Progress.Value += 1
            DataCompras.CurrentCell = DataCompras(0, a)
            '''''
            Try
                DataDevolucionDetalles.DataSource = Pro.BuscaDevolucionesProducto(DataCompras.Rows(a).Cells(7).Value, DataDetalles.Rows(a).Cells(0).Value)
                If DataDevolucionDetalles.RowCount > 0 Then

                Else

                End If
            Catch ex As Exception
                NotasCredito += DataCompras.Rows(a).Cells(8).Value
            End Try
            '''''
            For b As Integer = 0 To DataDetalles.RowCount - 1


                If Not IsDBNull(DataDetalles.Rows(b).Cells(2).Value) Then

                    If DataDetalles.Rows(b).Cells(2).Value = "BALANCEADOS" Then
                        Balanceados += DataDetalles.Rows(b).Cells(13).Value
                    ElseIf DataDetalles.Rows(b).Cells(2).Value = "MASCOTAS" Then
                        Mascotas += DataDetalles.Rows(b).Cells(13).Value
                    ElseIf DataDetalles.Rows(b).Cells(2).Value = "FERTILIZANTES" Then
                        Fertilizantes += DataDetalles.Rows(b).Cells(13).Value
                    ElseIf DataDetalles.Rows(b).Cells(2).Value = "SACOS" Then
                        Sacos += DataDetalles.Rows(b).Cells(13).Value
                    ElseIf DataDetalles.Rows(b).Cells(2).Value = "INSUMOS" Then
                        Insumos += DataDetalles.Rows(b).Cells(13).Value
                    Else
                        Especificar += DataDetalles.Rows(b).Cells(13).Value
                    End If
                Else
                    Especificar += DataDetalles.Rows(b).Cells(13).Value
                End If
            Next
        Next

        'For x As Integer = 0 To DataCompras.RowCount - 1
        '    Try
        '        DataCompras.CurrentCell = DataCompras(0, x)
        '        DataDevolucionDetalles.DataSource = Pro.BuscaDevolucionesProducto(DataCompras.Rows(x).Cells(7).Value, DataDetalles.Rows(x).Cells(0).Value)
        '        If DataDevolucionDetalles.RowCount > 0 Then

        '        Else

        '        End If
        '    Catch ex As Exception
        '        NotasCredito += DataCompras.Rows(x).Cells(8).Value
        '    End Try
        'Next
        Try
            DataCompras.CurrentCell = DataCompras(0, 0)
            DetallesFactura.Close()
            DetallesFactura.Show()
            DetallesFactura.TextBalanceados.Text = Format(Round(Balanceados, 2), "##,##00.00")
            DetallesFactura.TextMascotas.Text = Format(Round(Mascotas, 2), "##,##00.00")
            DetallesFactura.TextFertilizantes.Text = Format(Round(Fertilizantes, 2), "##,##00.00")
            DetallesFactura.TextSacos.Text = Format(Round(Sacos, 2), "##,##00.00")
            DetallesFactura.TextInsumos.Text = Format(Round(Insumos, 2), "##,##00.00")
            DetallesFactura.TextNoEspecificado.Text = Format(Round(Especificar, 2), "##,##00.00")

            DetallesFactura.TextCredito.Text = Format(Round(NotasCredito, 2), "##,##00.00")

            DetallesFactura.CodigoCliente.Text = LTrim(TextClaveCliente.Text)
            DetallesFactura.NombreCliente.Text = TextNombreCliente.Text
            If GroupFacturas.Visible = True Then
                DetallesFactura.FechaFacturas.Text = TextFecha.Text
            Else
                DetallesFactura.FechaFacturas.Text = DateDesde.Value.Date & "    Hasta: " & DateHasta.Value.Date
            End If
            DetallesFactura.TextTotal.Text = Format(Round((Balanceados + Mascotas + Fertilizantes + Sacos + Insumos + Especificar - NotasCredito), 2), "##,##00.00")
            DetallesFactura.Aceptar.Focus()
        Catch
        End Try

    End Sub

    Private Sub DataDetalles_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDetalles.CellDoubleClick
        ProductoDetalles.Close()
        ProductoDetalles.Show()
        ProductoDetalles.CodigoCliente.Text = LTrim(TextClaveCliente.Text)
        ProductoDetalles.NombreCliente.Text = TextNombreCliente.Text
        ProductoDetalles.Producto.Text = DataDetalles.CurrentRow.Cells(1).Value
        If GroupFechas.Visible = True Then
            ProductoDetalles.DataGridView1.DataSource = Pro.MuestraDetalleUnProducto(DataDetalles.CurrentRow.Cells(0).Value, TextClaveCliente.Text, DateDesde.Value, DateHasta.Value)
        Else
            ProductoDetalles.DataGridView1.DataSource = Pro.MuestraDetalleUnProducto(DataDetalles.CurrentRow.Cells(0).Value, TextClaveCliente.Text, TextFecha.Text, Now)
        End If
        ProductoDetalles.DataGridView1.Columns(2).Visible = False
        ProductoDetalles.DataGridView1.Columns(3).Visible = False
        Dim CantidadTotal As Decimal = 0
        Dim Total As Decimal = 0
        For a As Integer = 0 To ProductoDetalles.DataGridView1.RowCount - 1
            CantidadTotal += ProductoDetalles.DataGridView1.Rows(a).Cells(4).Value
            Total += ProductoDetalles.DataGridView1.Rows(a).Cells(8).Value
        Next
        ProductoDetalles.TextCantidad.Text = Round(CantidadTotal, 2)
        ProductoDetalles.TextTotal.Text = Format(Round(Total, 2), "##,##00.00")

        Dim Diferencia As Double
        Diferencia = DateDiff(DateInterval.DayOfYear, ProductoDetalles.DataGridView1.Rows(ProductoDetalles.DataGridView1.RowCount - 1).Cells(1).Value, ProductoDetalles.DataGridView1.Rows(0).Cells(1).Value)
        Dim Ultima As Double = DateDiff(DateInterval.DayOfYear, ProductoDetalles.DataGridView1.Rows(0).Cells(1).Value, Now)
        Dim Compras As Double
        Compras = Diferencia / (ProductoDetalles.DataGridView1.RowCount - 1)
        ProductoDetalles.PromedioVenta.Text = "Promedio: 1 compra cada " & Round(Compras) & " días."
        ProductoDetalles.UltimaCompra.Text = "Última compra hace " & Ultima & " días."
    End Sub

    Private Sub BtnFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltro.Click
        If BtnFiltro.Text = "Filtrar Por Fechas" Then
            BtnFiltro.Text = "Filtrar Últimas Facturas"
            GroupFechas.Visible = True
            GroupFacturas.Visible = False
            LabelDesde.Visible = False
            TextFecha.Visible = False
        Else
            BtnFiltro.Text = "Filtrar Por Fechas"
            GroupFechas.Visible = False
            GroupFacturas.Visible = True
            LabelDesde.Visible = True
            TextFecha.Visible = True
        End If
    End Sub

    Private Sub BtnFiltroFechas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltroFechas.Click
        Actualiza()
    End Sub

End Class