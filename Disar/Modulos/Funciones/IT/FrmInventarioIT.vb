Imports Disar.data

Public Class FrmInventarioIT

    Private Sub FrmInventarioIT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RadioTod.Checked = True
        Try
            ComboEstado.SelectedItem = "Todo"
            VerEquipos()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub NuevoRegistro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevoRegistro.Click
        If FrmNuevoEquipo.ShowDialog = Windows.Forms.DialogResult.OK Then
            VerEquipos()
        End If
    End Sub

    Sub VerEquipos()
        If RadioTod.Checked = True Then
            If ComboEstado.Text = "Todo" Then
                Try
                    Dim db As New clsInventarioIT
                    DataDatos.DataSource = db.VerTodoEquipo
                    DataDatos.Columns(2).Visible = False
                Catch ex As Exception
                End Try
            Else
                Try
                    Dim db As New clsInventarioIT
                    DataDatos.DataSource = db.VerTodoEquipoPorEstado(ComboEstado.Text)
                    DataDatos.Columns(2).Visible = False
                Catch ex As Exception
                End Try
            End If
            
        Else
            If ComboEstado.Text = "Todo" Then
                Try
                    Dim db As New clsInventarioIT
                    DataDatos.DataSource = db.VerEquipoDisponible
                    DataDatos.Columns(2).Visible = False
                Catch ex As Exception
                End Try
            Else
                Try
                    Dim db As New clsInventarioIT
                    DataDatos.DataSource = db.VerEquipoDisponiblePorEstado(ComboEstado.Text)
                    DataDatos.Columns(2).Visible = False
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        VerEquipos()
    End Sub

    Private Sub BtnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnModificar.Click
        If DataDatos.RowCount > 0 Then
            Try
                FrmDetallesEquipo.Marcas()
                FrmDetallesEquipo.Proveedores()
                FrmDetallesEquipo.Ubicaciones()
                FrmDetallesEquipo.Categorias()
                AsignarValores()
                FrmDetallesEquipo.Numero.Enabled = True
                FrmDetallesEquipo.TextDescripcion.Enabled = True
                FrmDetallesEquipo.ComboCat.Enabled = True
                FrmDetallesEquipo.ComboCat.Enabled = True
                FrmDetallesEquipo.TextSerie.Enabled = True
                FrmDetallesEquipo.TextModelo.Enabled = True
                FrmDetallesEquipo.ComboMarca.Enabled = True
                FrmDetallesEquipo.TextProcesador.Enabled = True
                FrmDetallesEquipo.TextRAM.Enabled = True
                FrmDetallesEquipo.TextDiscoDuro.Enabled = True
                FrmDetallesEquipo.DateFechaCompra.Enabled = True
                FrmDetallesEquipo.DateGarantia.Enabled = True
                FrmDetallesEquipo.TextFactura.Enabled = True
                FrmDetallesEquipo.ComboProveedor.Enabled = True
                FrmDetallesEquipo.TextCosto.Enabled = True
                FrmDetallesEquipo.ComboEstado.Enabled = True
                FrmDetallesEquipo.TextAsignacion.Enabled = True
                FrmDetallesEquipo.TextContacto.Enabled = True
                FrmDetallesEquipo.ComboUbicacion.Enabled = True
                FrmDetallesEquipo.BtnCancelar.Visible = True
                FrmDetallesEquipo.BtnGuardar.Visible = True

                FrmDetallesEquipo.TextSim.Enabled = True
                FrmDetallesEquipo.TextNum.Enabled = True

                FrmDetallesEquipo.ShowDialog()
                
               
            Catch ex As Exception
            End Try
        End If
    End Sub

    Sub AsignarValores()
        FrmDetallesEquipo.Numero.Text = DataDatos.CurrentRow.Cells(0).Value
        FrmDetallesEquipo.TextDescripcion.Text = DataDatos.CurrentRow.Cells(1).Value
        FrmDetallesEquipo.ComboCat.SelectedValue = DataDatos.CurrentRow.Cells(2).Value
        FrmDetallesEquipo.ComboCat.Text = DataDatos.CurrentRow.Cells(3).Value
        FrmDetallesEquipo.TextSerie.Text = DataDatos.CurrentRow.Cells(4).Value
        FrmDetallesEquipo.TextModelo.Text = DataDatos.CurrentRow.Cells(5).Value
        FrmDetallesEquipo.ComboMarca.SelectedValue = DataDatos.CurrentRow.Cells(6).Value
        FrmDetallesEquipo.TextProcesador.Text = DataDatos.CurrentRow.Cells(7).Value
        FrmDetallesEquipo.TextRAM.Text = DataDatos.CurrentRow.Cells(8).Value
        FrmDetallesEquipo.TextDiscoDuro.Text = DataDatos.CurrentRow.Cells(9).Value
        FrmDetallesEquipo.DateFechaCompra.Value = DataDatos.CurrentRow.Cells(10).Value
        FrmDetallesEquipo.DateGarantia.Value = DataDatos.CurrentRow.Cells(11).Value
        FrmDetallesEquipo.TextFactura.Text = DataDatos.CurrentRow.Cells(12).Value
        FrmDetallesEquipo.ComboProveedor.Text = DataDatos.CurrentRow.Cells(13).Value
        FrmDetallesEquipo.TextCosto.Text = DataDatos.CurrentRow.Cells(14).Value
        FrmDetallesEquipo.ComboEstado.SelectedItem = DataDatos.CurrentRow.Cells(15).Value
        FrmDetallesEquipo.TextAsignacion.Text = DataDatos.CurrentRow.Cells(16).Value
        FrmDetallesEquipo.TextContacto.Text = DataDatos.CurrentRow.Cells(17).Value
        FrmDetallesEquipo.ComboUbicacion.Text = DataDatos.CurrentRow.Cells(18).Value
        If Not IsDBNull(DataDatos.CurrentRow.Cells(19).Value) Then
            FrmDetallesEquipo.TextNum.Text = DataDatos.CurrentRow.Cells(19).Value
        End If
        If Not IsDBNull(DataDatos.CurrentRow.Cells(20).Value) Then
            FrmDetallesEquipo.TextSim.Text = DataDatos.CurrentRow.Cells(20).Value
        End If
    End Sub

    Private Sub DataDatos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataDatos.CellDoubleClick
        If DataDatos.RowCount > 0 Then
            Try
                FrmDetallesEquipo.Marcas()
                FrmDetallesEquipo.Proveedores()
                FrmDetallesEquipo.Ubicaciones()
                FrmDetallesEquipo.Categorias()
                AsignarValores()
                FrmDetallesEquipo.Numero.Enabled = False
                FrmDetallesEquipo.TextDescripcion.Enabled = False
                FrmDetallesEquipo.ComboCat.Enabled = False
                FrmDetallesEquipo.ComboCat.Enabled = False
                FrmDetallesEquipo.TextSerie.Enabled = False
                FrmDetallesEquipo.TextModelo.Enabled = False
                FrmDetallesEquipo.ComboMarca.Enabled = False
                FrmDetallesEquipo.TextProcesador.Enabled = False
                FrmDetallesEquipo.TextRAM.Enabled = False
                FrmDetallesEquipo.TextDiscoDuro.Enabled = False
                FrmDetallesEquipo.DateFechaCompra.Enabled = False
                FrmDetallesEquipo.DateGarantia.Enabled = False
                FrmDetallesEquipo.TextFactura.Enabled = False
                FrmDetallesEquipo.ComboProveedor.Enabled = False
                FrmDetallesEquipo.TextCosto.Enabled = False
                FrmDetallesEquipo.ComboEstado.Enabled = False
                FrmDetallesEquipo.TextAsignacion.Enabled = False
                FrmDetallesEquipo.TextContacto.Enabled = False
                FrmDetallesEquipo.ComboUbicacion.Enabled = False
                FrmDetallesEquipo.BtnCancelar.Visible = False
                FrmDetallesEquipo.BtnGuardar.Visible = False

                FrmDetallesEquipo.ShowDialog()
  
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub TextBusqueda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusqueda.TextChanged
        If RadioTod.Checked = True Then
            If ComboEstado.Text = "Todo" Then
                Dim db As New clsInventarioIT
                DataDatos.DataSource = db.FiltroEquipo(ComboEstado.Text, TextBusqueda.Text)
                DataDatos.Columns(2).Visible = False
            Else
                Dim db As New clsInventarioIT
                DataDatos.DataSource = db.FiltroEquipoPorEstado(ComboEstado.Text, TextBusqueda.Text)
                DataDatos.Columns(2).Visible = False
            End If
        Else
            If ComboEstado.Text = "Todo" Then
                Dim db As New clsInventarioIT
                DataDatos.DataSource = db.FiltroEquipoDisponible(TextBusqueda.Text)
                DataDatos.Columns(2).Visible = False
            Else
                Dim db As New clsInventarioIT
                DataDatos.DataSource = db.FiltroEquipoDisponiblePorEstado(ComboEstado.Text, TextBusqueda.Text)
                DataDatos.Columns(2).Visible = False
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If DataDatos.RowCount > 0 Then

            Try
                Dim db As New clsInventarioIT
                Form_HistorialAsignacion.TextBox1.Text = DataDatos.CurrentRow.Cells(0).Value & " " & DataDatos.CurrentRow.Cells(1).Value
                Form_HistorialAsignacion.DataDatos.DataSource = db.FiltrarAsignacionesPorItem(DataDatos.CurrentRow.Cells(0).Value)
                Form_HistorialAsignacion.ShowDialog()
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Frm_Asignaciones.ShowDialog()
    End Sub

    Private Sub Rep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Rep.Click
        FrmRepuestos.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        Exportar()
    End Sub

    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet
            wSheet.Cells.Range("A1:M1").Merge()
            wSheet.Cells.Range("A1:M1").Value = "INVENTARIO DE EQUIPO [SISTEMAS Y TECNOLOGÍA] "
            wSheet.Cells.Range("A1:M1").Font.Color = System.Drawing.ColorTranslator.ToOle(Color.Black)
            wSheet.Cells.Range("A1:M1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter
            wSheet.Cells.Range("A1:M1").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
            wSheet.Cells.Range("A1:M1").Font.Bold = True
            For c As Integer = 0 To DataDatos.Columns.Count - 1
                wSheet.Cells(2, c + 1).value = DataDatos.Columns(c).HeaderText
                wSheet.Cells(2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
            Next
            For r As Integer = 0 To DataDatos.RowCount - 1
                For c As Integer = 0 To DataDatos.Columns.Count - 1
                    wSheet.Cells(r + 3, c + 1).value = DataDatos.Item(c, r).Value
                    wSheet.Cells(r + 3, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error " & ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class