Imports Disar.data

Public Class FrmNuevoProdMatinal

    Private Sub Cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancelar.Click
        Me.Close()
    End Sub

    Private Sub FrmNuevoProdMatinal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TextCantidad.Text = ""
        TextClave.Text = ""
        TextNombre.Text = ""
        ChkTodos.Checked = False

        Dim db As New ClsProductos

        DataVendedores.DataSource = Nothing
        DataVendedores.Columns.Clear()

        ChkTodos.CheckState = CheckState.Unchecked
        ChkTodos.Visible = True
        Dim dbVendedores As New ClassVendedores
        Dim Data As New DataView
        Dim Data2 As New DataView

        Try
            Data = dbVendedores.CargarVendedores("SAN RAFAEL", "AMBOS")
            If Not (IsNothing(dbVendedores.CargarVendedores("SAN RAFAEL", "AMBOS"))) Then
                DataVendedores.DataSource = Data
                If DataVendedores.ColumnCount = 4 Then
                    Dim chk As New DataGridViewCheckBoxColumn()
                    DataVendedores.Columns.Add(chk)
                    chk.HeaderText = "Agregar"
                    chk.Name = "chk"
                End If
                DataVendedores.Columns(1).Width = 220%
            End If
        Catch ex As Exception
        End Try

        DataProductos.DataSource = db.TodosProductos

    End Sub

    Private Sub Guardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Guardar.Click

        If TextClave.Text <> "" And TextCantidad.Text <> "" Then
            Dim Tipo As String = ""
            If ComboCalculo.Text = "Lempiras" Then
                Tipo = "L"
            ElseIf ComboCalculo.Text = "Cajas" Then
                Tipo = "CJ"
            ElseIf ComboCalculo.Text = "Unidades" Then
                Tipo = "U"
            Else
                Tipo = "Q"
            End If

            Dim db As New ClsProductos
            Try
                For A As Integer = 0 To DataVendedores.RowCount - 1
                    If DataVendedores.Rows(A).Cells("chk").Value = True Then
                        Dim s = db.NuevoRegistro(TextClave.Text, TextNombre.Text, DataVendedores.Rows(A).Cells("Código de Vendedor").Value, TextCantidad.Text, Tipo, DateTimePicker1.Value)
                    End If
                Next
                MsgBox("Registro guardado exitosamente", MsgBoxStyle.Information)
                TextBusca.Text = ""
                TextClave.Text = ""
                TextCantidad.Text = ""
                TextNombre.Text = ""
                ComboCalculo.SelectedIndex = 0
                Try
                    DataVendedores.Columns.Clear()
                Catch ex As Exception
                End Try
                Try
                    DataVendedores.DataSource = Nothing
                Catch ex As Exception
                End Try
                frm_CargaProductoMatinal.actualiza()
                Me.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Else
            MsgBox("No se puede almacenar un registro vacío. Haga doble clic sobre un producto para seleccionarlo y coloque una unidad y una cantidad válidas")
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusca.TextChanged
        Dim db As New ClsProductos
        DataProductos.DataSource = db.FiltraProductos(TextBusca.Text)
    End Sub

    Private Sub DataProductos_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataProductos.CellDoubleClick
        Try
            TextClave.Text = DataProductos.CurrentRow.Cells(0).Value
            TextNombre.Text = DataProductos.CurrentRow.Cells(1).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ChkTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTodos.CheckedChanged
        If ChkTodos.CheckState = CheckState.Checked Then
            For A As Integer = 0 To DataVendedores.RowCount - 1
                DataVendedores.Rows(A).Cells("chk").Value = True
            Next
        Else
            For A As Integer = 0 To DataVendedores.RowCount - 1
                DataVendedores.Rows(A).Cells("chk").Value = False
            Next
        End If
    End Sub

    
    Private Sub TextBox_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles BuscaVend.KeyDown
        If e.KeyCode = Keys.Enter Then
            For Each row As DataGridViewRow In DataVendedores.Rows
                If row.Cells("Código de Vendedor").Value = "   " & BuscaVend.Text Or row.Cells("Nombre").Value.ToString.ToUpper.StartsWith(BuscaVend.Text.ToUpper) = True Then
                    DataVendedores.CurrentCell = DataVendedores(4, row.Index)
                End If
            Next
        End If
    End Sub

  
End Class