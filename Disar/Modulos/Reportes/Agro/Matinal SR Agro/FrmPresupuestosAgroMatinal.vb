Imports Disar.data

Public Class FrmPresupuestosAgroMatinal

    Private Sub DataPantallas_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataPantallas.CellClick
        GroupBox2.Text = " Presupuestos de " & DataPantallas.CurrentRow.Cells(1).Value & " - " & DataVendedores.CurrentRow.Cells(1).Value
        GroupBox2.Visible = True
        ActualizaPresupuestos()
    End Sub

    Private Sub BtnGuardarPresupuestos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        GroupBox2.Visible = False
    End Sub

    Private Sub DataVendedores_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataVendedores.CellClick
        GroupBox2.Visible = False
        ActualizaPantallas(DataVendedores.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub FrmPresupuestosAgroMatinal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActualizaVendedores()
        ComboMes.SelectedIndex = Today.Month - 1
    End Sub

    Sub ActualizaVendedores()
        Dim db As New ClsMatinalAgro
        Try
            DataVendedores.DataSource = db.MuestraVendedores
        Catch ex As Exception
        End Try
    End Sub

    Sub ActualizaPantallas(ByVal Vendedor As String)
        Dim db As New ClsMatinalAgro
        Try
            DataPantallas.DataSource = db.Pantallas(Vendedor)
            DataPantallas.Columns(0).Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAgregarPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarPantalla.Click
        FrmAgregaPantalla.Vendedor = DataVendedores.CurrentRow.Cells(0).Value
        FrmAgregaPantalla.ShowDialog()
    End Sub

    Private Sub BtnDesactivarPantalla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDesactivarPantalla.Click

        If DataPantallas.RowCount > 0 Then
            Dim a = MsgBox("¿Está seguro que desea quitar la pantala de " & DataPantallas.CurrentRow.Cells(1).Value & " del vendedor " & DataVendedores.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.YesNo)
            If a = MsgBoxResult.Yes Then
                Dim db As New ClsMatinalAgro
                Dim s = db.EliminaPantalla(DataPantallas.CurrentRow.Cells(1).Value, DataVendedores.CurrentRow.Cells(0).Value)
                If s = "s" Then
                    ActualizaPantallas(DataVendedores.CurrentRow.Cells(0).Value)
                Else
                    MsgBox(s)
                End If
            End If
        End If

    End Sub

    Sub ActualizaPresupuestos()
        Dim db As New ClsMatinalAgro
        DataMetas.DataSource = db.CargaMetasEditar(DataVendedores.CurrentRow.Cells(0).Value, DataPantallas.CurrentRow.Cells(1).Value, ComboMes.SelectedIndex + 1, NumericUpDown1.Value)
    End Sub

    Private Sub BtnDesactivarPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDesactivarPresupuesto.Click
        Dim db As New ClsMatinalAgro
        Dim a = MsgBox("¿Desea eliminar la meta seleccionada?", MsgBoxStyle.YesNo)
        If a = MsgBoxResult.Yes Then
            Dim s = db.EliminaSegmento(DataPantallas.CurrentRow.Cells(1).Value, DataVendedores.CurrentRow.Cells(0).Value, DataMetas.CurrentRow.Cells(0).Value, ComboMes.SelectedIndex + 1, NumericUpDown1.Value)
            ActualizaPresupuestos()
        End If
    End Sub

    Private Sub ComboMes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMes.SelectedIndexChanged, NumericUpDown1.ValueChanged
        Try
            ActualizaPresupuestos()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnAgregarPresupuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregarPresupuesto.Click
        FrmAgregarSubPantalla.Vendedor.Text = DataVendedores.CurrentRow.Cells(0).Value
        FrmAgregarSubPantalla.Pantalla.Text = DataPantallas.CurrentRow.Cells(1).Value
        FrmAgregarSubPantalla.ShowDialog()
    End Sub
End Class