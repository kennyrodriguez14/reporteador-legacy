Imports Disar.data

Public Class FrmLiquidacionesGuardadas

    Dim db As New ClsEfectividad

    Dim FechaFacturacion As Date
    Dim Depto As Integer = 5

    Dim Empresa As String = "SAN RAFAEL"
    Dim Almacen As Integer = 1
    Dim Total As Decimal
    Dim VariasLiq As Boolean
    Public Empre As Integer = 0


    Dim style As Microsoft.Office.Interop.Excel.Style


    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Try
            'Empresa = ComboBox1.Text
            DataLiquidaciones.DataSource = db.CargaLiquidaciones(DateTimePicker1.Value, DateTimePicker2.Value, Empre, ComboBox1.Text)
            DataLiquidaciones.Columns(1).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataLiquidaciones_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataLiquidaciones.CellDoubleClick
        Btn_EnviarGastos.PerformClick()
    End Sub

    Private Sub FrmLiquidacionesGuardadas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Empre = _Inicio.Almacen
        Liquidaciones.BringToFront()
        BtnGenerar.PerformClick()
    End Sub

    Private Sub TextVehiculo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextVehiculo.KeyDown
        If e.KeyCode = Keys.Enter Then
            CargaPorcentaje()
        End If
    End Sub

    Sub CargaPorcentaje()
        DataPorcentajes.DataSource = db.Porcentaje(Fecha.Text, TextVehiculo.Text)
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Liquidaciones.BringToFront()
        DataPorcentajes.DataSource = Nothing
    End Sub

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim dtEmpleado As New DataTable
        For Each column As DataGridViewColumn In DataPorcentajes.Columns
            dtEmpleado.Columns.Add(column.HeaderText)
        Next
        For Each row As DataGridViewRow In DataPorcentajes.Rows
            dtEmpleado.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value)
        Next
        'DataPorcentajes.DataSource = Nothing
        'MsgBox("Vacio")
        'DataPorcentajes.DataSource = dtEmpleado
        'MsgBox("Lleno")
        Dim Alimentacion As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(0).Cells("Autorizado a CC").Value) Then
            Alimentacion += DataGastos.Rows(0).Cells("Autorizado a CC").Value
        End If
        If Not IsDBNull(DataGastos.Rows(1).Cells("Autorizado a CC").Value) Then
            Alimentacion += DataGastos.Rows(1).Cells("Autorizado a CC").Value
        End If
        If Not IsDBNull(DataGastos.Rows(3).Cells("Autorizado a CC").Value) Then
            Alimentacion += DataGastos.Rows(3).Cells("Autorizado a CC").Value
        End If
        Dim SubTotalHotel As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(4).Cells("Autorizado a CC").Value) Then
            SubTotalHotel = DataGastos.Rows(4).Cells("Autorizado a CC").Value
        End If
        Dim ISV15HOTEL As Decimal = 0
        Dim VALORISV15 As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(5).Cells("Autorizado a CC").Value) Then
            VALORISV15 = DataGastos.Rows(5).Cells("Autorizado a CC").Value
            ISV15HOTEL = 15
        End If
        Dim ISV4HOTEL As Decimal = 0
        Dim VALORISV4 As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(6).Cells("Autorizado a CC").Value) Then
            VALORISV4 = DataGastos.Rows(6).Cells("Autorizado a CC").Value
            ISV4HOTEL = 4
        End If
        Dim Trans As Decimal = 0

        If Not IsDBNull(DataGastos.Rows(2).Cells("Autorizado a CC").Value) Then
            Trans += DataGastos.Rows(2).Cells("Autorizado a CC").Value
        End If
        Dim ImpMunicipal As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(7).Cells("Autorizado a CC").Value) Then
            ImpMunicipal = DataGastos.Rows(7).Cells("Autorizado a CC").Value
        End If
        Dim ImpGuerra As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(8).Cells("Autorizado a CC").Value) Then
            ImpGuerra = DataGastos.Rows(8).Cells("Autorizado a CC").Value
        End If
        Dim Peaje As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(9).Cells("Autorizado a CC").Value) Then
            Peaje = DataGastos.Rows(9).Cells("Autorizado a CC").Value
        End If
        Dim RepLlantas As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(10).Cells("Autorizado a CC").Value) Then
            RepLlantas = DataGastos.Rows(10).Cells("Autorizado a CC").Value
        End If
        Dim RengLlantas As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(11).Cells("Autorizado a CC").Value) Then
            RengLlantas = DataGastos.Rows(11).Cells("Autorizado a CC").Value
        End If
        Dim Lubricantes As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(12).Cells("Autorizado a CC").Value) Then
            Lubricantes = DataGastos.Rows(12).Cells("Autorizado a CC").Value
        End If
        Dim Combustible As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(13).Cells("Autorizado a CC").Value) Then
            Combustible = DataGastos.Rows(13).Cells("Autorizado a CC").Value
        End If
        Dim Trocos As Decimal = 0
        If Not IsDBNull(DataGastos.Rows(14).Cells("Autorizado a CC").Value) Then
            Trocos = DataGastos.Rows(14).Cells("Autorizado a CC").Value
        End If
        Dim Vehiculares As Decimal = 0
        Dim Fila As Integer = 15
        If FechaFacturacion >= "01/11/2018" Then
            Fila = 16
            If Not IsDBNull(DataGastos.Rows(15).Cells("Autorizado a CC").Value) Then
                Vehiculares = DataGastos.Rows(15).Cells("Autorizado a CC").Value
            End If
        Else
            Fila = 15
        End If

        Dim Otros As Decimal = 0
        If DataGastos.RowCount > Fila Then
            For Each row As DataGridViewRow In DataGastos.Rows
                If row.Index >= Fila Then
                    If Not IsDBNull(row.Cells("Autorizado a CC").Value) Then
                        Otros += row.Cells("Autorizado a CC").Value
                    End If
                End If
            Next
        End If

        Dim s = db.ins_gasto_entrega(_Inicio.lblUsuario.Text, dtEmpleado, Empresa, Depto, Almacen, FechaFacturacion, Ruta.Text, Alimentacion, SubTotalHotel + VALORISV15 + VALORISV4, TextVehiculo.Text, Trans, ImpMunicipal, ImpGuerra, Peaje, RepLlantas, PrecioComb.Text, RengLlantas, ISV15HOTEL, Lubricantes, Combustible, Trocos, Otros, Total, VALORISV4, VALORISV15, SubTotalHotel, Entregador.Text, Identidad.Text, Vehiculares)
        If s = "correcto" Then
            MsgBox("Se enviaron los costos exitosamente")
            Liquidaciones.BringToFront()
            BtnGenerar.PerformClick()
        Else
            MsgBox(s)
        End If
    End Sub

    Private Sub DataGastos_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGastos.CellEndEdit
        If Not IsDBNull(DataGastos.CurrentRow.Cells("ValorTotal").Value) Then
            If DataGastos.CurrentRow.Cells("Autorizado a CC").Value > DataGastos.CurrentRow.Cells("ValorTotal").Value Then
                MsgBox("El valor aprobado excede el gasto ingresado por el entregador. Se establecerá el valor del entregador como aprobado")
                DataGastos.CurrentRow.Cells("Autorizado a CC").Value = DataGastos.CurrentRow.Cells("ValorTotal").Value
            End If
        Else
            DataGastos.CurrentRow.Cells("Autorizado a CC").Value = DBNull.Value
        End If
        Try
            Dim TotalEnviar As Decimal
            TotalEnviar = 0
            For Each row As DataGridViewRow In DataGastos.Rows
                TotalEnviar += row.Cells("Autorizado a CC").Value
            Next
            Total = TotalEnviar
            TotalGastos.Text = TotalEnviar
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_EnviarGastos.Click
        If DataLiquidaciones.RowCount > 0 Then
            Dim Contador As Integer = 0
            Total = DataLiquidaciones.CurrentRow.Cells("Total de Gastos").Value
            Dim Ent As String = DataLiquidaciones.CurrentRow.Cells("Entregador").Value
            Dim Valido As Boolean = True
            For Each row As DataGridViewRow In DataLiquidaciones.Rows
                If row.Cells("Entregador").Value = Ent Then
                    Contador += 1
                End If
            Next
            If Contador > 1 Then
                Dim a = MsgBox("Hay más de una liquidación para el entregador seleccionado. ¿Desea unir los gastos para enviar a Centro de Costos?", MsgBoxStyle.YesNo)
                Valido = False
                If a = MsgBoxResult.Yes Then
                    Valido = True
                    VariasLiq = True
                End If
            Else
                VariasLiq = False
                Valido = True
            End If

            If DataLiquidaciones.CurrentRow.Cells("GASTOS").Value = "SIN REVISAR" Then
                If Valido = True Then
                    Dim dtAs As New DataTable
                    Try
                        dtAs.Rows.Clear()
                    Catch ex As Exception
                    End Try
                    dtAs = db.CargaArqueo(DataLiquidaciones.CurrentRow.Cells(0).Value)
                    Try
                        Fecha.Text = DataLiquidaciones.CurrentRow.Cells("Fecha").Value
                        NumeroLiquidacion.Text = DataLiquidaciones.CurrentRow.Cells(0).Value
                        Identidad.Text = DataLiquidaciones.CurrentRow.Cells("Identidad").Value
                        Entregador.Text = DataLiquidaciones.CurrentRow.Cells("Entregador").Value
                        Tipo.Text = DataLiquidaciones.CurrentRow.Cells("Tipo de Liquidación").Value
                        EntregadorNombre.Text = DataLiquidaciones.CurrentRow.Cells("Entregador ").Value
                        FechaFacturacion = DataLiquidaciones.CurrentRow.Cells("Fecha de Facturación").Value
                        Ruta.Text = DataLiquidaciones.CurrentRow.Cells("Ruta").Value
                        TotalGastos.Text = Val(DataLiquidaciones.CurrentRow.Cells("Total de Gastos").Value).ToString
                        NumeroDeposito.Text = dtAs(0)(13)
                        TotalArqueo.Text = dtAs(0)(14)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    Try
                        If VariasLiq = False Then
                            DataGastos.DataSource = db.CargaCostos(DataLiquidaciones.CurrentRow.Cells(0).Value)
                        Else
                            DataGastos.DataSource = db.CargaCostosVarios(Fecha.Text, Val(Entregador.Text))
                        End If
                        For Each column As DataGridViewColumn In DataGastos.Columns
                            column.SortMode = DataGridViewColumnSortMode.NotSortable
                            column.ReadOnly = True
                        Next
                        DataGastos.Columns("Autorizado a CC").ReadOnly = False
                        Dim TotalEnviar As Decimal
                        TotalEnviar = 0
                        For Each row As DataGridViewRow In DataGastos.Rows
                            TotalEnviar += row.Cells("Autorizado a CC").Value
                        Next
                        Total = TotalEnviar
                        TotalGastos.Text = TotalEnviar
                    Catch ex As Exception
                    End Try
                    Try
                        Dim dt As New DataTable
                        dt = db.CargaVehiculo(Entregador.Text, FechaFacturacion)
                        TextVehiculo.Text = dt(0)(0)
                        CargaPorcentaje()
                    Catch ex As Exception
                    End Try
                    Try
                        Dim dtDatosEmpleado As New DataTable
                        dtDatosEmpleado = db.DatosEntregador(Identidad.Text)
                        Depto = dtDatosEmpleado(0)(1)
                        Empresa = dtDatosEmpleado(0)(2)
                        Almacen = dtDatosEmpleado(0)(3)
                        'MsgBox(Empresa & vbNewLine & Almacen & vbNewLine & Departamento)
                    Catch ex As Exception
                    End Try
                    Try
                        Dim dtComb As New DataTable
                        dtComb = db.precios_combustible(Almacen)
                        PrecioComb.Text = dtComb(0)(0)
                    Catch ex As Exception
                    End Try
                    Gastos.BringToFront()
                End If
            Else
                MsgBox("No se pueden cargar gastos de esta liquidación porque ya fueron enviados a Centro de Costos")
            End If
        End If
    End Sub

    Private Sub Btn_QuitarLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_QuitarLiquidacion.Click
        If DataLiquidaciones.RowCount > 0 Then
            Dim db As New ClsEfectividad

            Dim A = MsgBox("Está seguro que desea quitar la liquidación Nº " & DataLiquidaciones.CurrentRow.Cells(0).Value & " del listado?", MsgBoxStyle.YesNo, "Eliminar liquidación")

            If A = MsgBoxResult.Yes Then
                Dim x = db.EliminaLiquidacion(DataLiquidaciones.CurrentRow.Cells(0).Value, _Inicio.lblUsuario.Text)
                If x = "s" Then
                    BtnGenerar.PerformClick()
                End If
            End If
        End If
    End Sub


    Private Sub BtnExportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExportar.Click
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "Resumen"

            style = wSheet.Application.ActiveWorkbook.Styles.Add("Reportes")
            style.Font.Bold = True
            style.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
            style.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            style.Font.Size = 11
            style.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter


            wSheet.Cells.Range("A1:D1").Merge()
            wSheet.Cells.Range("A1:D1").Borders.LineStyle = BorderStyle.FixedSingle
            wSheet.Cells.Range("A1:D1").Value = "Resumen de Liquidaciones " & DateTimePicker1.Value
            wSheet.Cells.Range("A1:D1").Style = "Reportes"


            For c As Integer = 0 To DataLiquidaciones.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataLiquidaciones.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).Style = "Reportes"
            Next
            For r As Integer = 0 To DataLiquidaciones.RowCount - 1
                For c As Integer = 0 To DataLiquidaciones.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataLiquidaciones.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        DateTimePicker2.Value = DateTimePicker1.Value
    End Sub

     
   
End Class