Imports Disar.data

Public Class FrmNuevoCheque

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Dim s = MsgBox("¿Desea cancelar el registro?", MsgBoxStyle.YesNo, "Atención")
        If s = MsgBoxResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnFactura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFactura.Click

        If FrmBuscaFacturas.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim estado As Integer = 1

            For Each row As DataGridViewRow In DataFacturas.Rows
                If row.Cells(0).Value = FrmBuscaFacturas.Fact Then
                    estado = 0
                    Exit For
                Else
                    estado = 1
                End If
            Next

            If estado = 1 Then
                DataFacturas.Rows.Add(FrmBuscaFacturas.Fact, FrmBuscaFacturas.Fecha, FrmBuscaFacturas.Monto, FrmBuscaFacturas.Abonos, FrmBuscaFacturas.Saldo)
            Else
                MsgBox("La factura ya se encuentra agregada al listado", MsgBoxStyle.Information, "Atención")
            End If

        End If

    End Sub

    Private Sub BtnCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCliente.Click
        If FrmBuscaClientes.ShowDialog = Windows.Forms.DialogResult.OK Then
            BtnFactura.Visible = True
            TxtClienteClave.Text = FrmBuscaClientes.ID
            TxtClienteNombre.Text = FrmBuscaClientes.Nombre
        End If
    End Sub

    Private Sub DataFacturas_RowsAdded(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DataFacturas.RowsAdded
        EvaluaFilas()
    End Sub

    Private Sub DataFacturas_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataFacturas.RowsRemoved
        EvaluaFilas()
    End Sub

    Sub EvaluaFilas()
        If DataFacturas.RowCount > 0 Then
            BtnCliente.Enabled = False
        Else
            BtnCliente.Enabled = True
        End If
    End Sub

    Private Sub FrmNuevoCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarCombo()
    End Sub

    Sub LlenarCombo()
        Dim db As New ClsCheques
        ComboBanco.DataSource = db.Bancos
        ComboBanco.ValueMember = "Clave"
        ComboBanco.DisplayMember = "Banco"

    End Sub

    Private Sub ComboBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBanco.SelectedIndexChanged
        Dim db As New ClsCheques
        TxtCuenta.Text = ""

        Try
            Dim dt As New DataTable
            dt = db.DetallesBanco(ComboBanco.SelectedValue, "SAN RAFAEL")
            TxtCuenta.Text = dt(0)(3)
            TxtNumeroBanco.Text = dt(0)(4)
        Catch ex As Exception

        End Try
        

    End Sub

    Private Sub BtnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAceptar.Click
        If TxtNumeroCheque.Text <> "" And TxtNumeroCheque.Text <> " " Then
            If DataFacturas.RowCount > 0 Then
                Dim dt As New DataTable
                Try

                    For Each column As DataGridViewColumn In DataFacturas.Columns
                        dt.Columns.Add(column.HeaderText)
                    Next
                    For Each row As DataGridViewRow In DataFacturas.Rows
                        dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value)
                    Next
                Catch ex As Exception
                    MsgBox("Error: " & ex.Message)
                End Try

                Try
                    Dim db As New ClsCheques
                    Dim Guarda As String
                    Guarda = db.NuevoCheque(TxtNumeroCheque.Text, _Inicio.lblUsuario.Text, ComboBanco.Text, ComboBanco.SelectedValue, TxtCuenta.Text, DateTimePicker1.Value.Date, Val(TxtMonto.Text), TxtClienteClave.Text, dt, TxtNumeroBanco.Text, "SAN RAFAEL")
                    If Guarda = "SI" Then
                        MsgBox("Registro de depósito completado", MsgBoxStyle.Information, "Aviso")
                        Me.Close()
                    Else
                        MsgBox(Guarda)
                    End If
                Catch ex As Exception
                    MsgBox("Error al guardar el depósito: " & ex.Message, MsgBoxStyle.Critical, "Atención")
                End Try
            Else
                MsgBox("Debe registrar al menos una factura para poder almacenar el depósito", MsgBoxStyle.Information, "Aviso")
            End If
        Else
            MsgBox("Debe registrar un número de depósito", MsgBoxStyle.Information, "Aviso")
        End If
    End Sub

    Private Sub BtnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnQuitar.Click
        If DataFacturas.RowCount > 0 Then
            DataFacturas.Rows.RemoveAt(DataFacturas.CurrentRow.Cells(0).Value)
        End If
    End Sub
End Class