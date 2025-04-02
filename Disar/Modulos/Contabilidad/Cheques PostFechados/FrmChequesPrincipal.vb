Imports Disar.data

Public Class FrmChequesPrincipal


    Private Sub BtnNuevoCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevoCheque.Click
        If FrmNuevoCheque.Visible = True Then
            FrmNuevoCheque.BringToFront()
        Else
            FrmNuevoCheque.MdiParent = _Inicio
            FrmNuevoCheque.Show()
        End If
    End Sub

    Private Sub BtnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAprobar.Click
        If DataCheques.RowCount > 0 Then
            If DataCheques.CurrentRow.Cells("Estado").Value = "Pendiente" Then
                If FrmAceptaCheque.Visible = True Then
                    FrmAceptaCheque.BringToFront()
                Else
                    If FrmAceptaCheque.ShowDialog = Windows.Forms.DialogResult.OK Then
                        BtnBusca.PerformClick()
                    End If
                End If
            Else
                'MsgBox("El estado del depósito ya no puede modificarse", MsgBoxStyle.Critical, "Acceso denegado")
            End If
        End If
    End Sub

    Private Sub BtnRechazarPago_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRechazarPago.Click
        If DataCheques.RowCount > 0 Then
            If DataCheques.CurrentRow.Cells("Estado").Value = "Pendiente" Then
                'Dim a = MsgBox("¿Está seguro que desea rechazar el cheque " & DataCheques.CurrentRow.Cells(0).Value & "?", MsgBoxStyle.YesNo, "Atención")
                'If a = MsgBoxResult.Yes Then
                If FrmRechazaCheque.ShowDialog = Windows.Forms.DialogResult.OK Then
                    BtnBusca.PerformClick()
                End If
                'End If
            Else
                MsgBox("El estado del cheque ya no puede modificarse", MsgBoxStyle.Critical, "Acceso denegado")
            End If

        End If
    End Sub

    Private Sub FrmChequesPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Dock = DockStyle.Fill
        ComboFiltro.Text = "Todos"
        BtnBusca.PerformClick()
    End Sub

    Private Sub BtnBusca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBusca.Click
        Dim db As New ClsCheques
        If ComboFiltro.Text = "Todos" Then
            DataCheques.DataSource = db.Cheques(DateDesde.Value, DateHasta.Value)
        Else
            DataCheques.DataSource = db.ChequesEstado(ComboFiltro.Text, DateDesde.Value, DateHasta.Value)
        End If
        Try
            DataCheques.Columns("Banco_ID").Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DataCheques_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataCheques.CellDoubleClick
        If FrmAceptaCheque.Visible = False Then
            FrmAceptaCheque.MdiParent = _Inicio
            FrmAceptaCheque.Show()
            FrmAceptaCheque.BtnAprobar.Enabled = False
        Else
            FrmAceptaCheque.BringToFront()
        End If
    End Sub

End Class