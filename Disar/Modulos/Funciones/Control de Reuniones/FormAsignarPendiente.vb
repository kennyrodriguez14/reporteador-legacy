Imports Disar.data

Public Class FormAsignarPendiente

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Try
            Dim db As New clsReuniones
            Dim dt As New DataTable
            Try
                dt.Columns.Clear()
                dt.Rows.Clear()
            Catch ex As Exception
            End Try
            dt.Columns.Add("Usuario")

            For Each row As DataGridViewRow In DataDatos.Rows
                Dim cellSelecion As DataGridViewCheckBoxCell = TryCast(row.Cells("Asignar"), DataGridViewCheckBoxCell)
                If Convert.ToBoolean(cellSelecion.Value) Then
                    dt.Rows.Add(row.Cells("ID").Value)
                End If
            Next

            Dim s = db.NuevoPendiente(TxtNombreAsignacion.Text, TxtDescripcionAsignacion.Text, TareaID.Text, FrmLlenadoReunion.FechaHora.Text, ComboAsignacion.SelectedValue, ComboAsignacion.SelectedValue, Reunion.Text, CodigoReunion.Text, DateTimePicker1.Value, dt)
            If s = "s" Then
                TxtDescripcionAsignacion.Text = ""
                TxtNombreAsignacion.Text = ""
                TxtSolicitante.Text = ""
                FrmLlenadoReunion.ActualizaPendientes.PerformClick()
                Me.DialogResult = Windows.Forms.DialogResult.OK
            Else
                MsgBox(s)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub TextBusca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBusca.TextChanged
        ComboAsignacion.SelectedIndex = ComboAsignacion.FindString(TextBusca.Text)
    End Sub

    Private Sub FormAsignarPendiente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DB As New clsReuniones
        Dim DT As New DataTable
        DT = DB.Sucursales("")
        For a As Integer = 0 To DT.Rows.Count - 1
            DataSucursales.Rows.Add(DT(a)(1), False)
        Next
    End Sub
End Class