Imports Disar.data

Public Class FrmAceptaCheque

    Public Cheque As String
    Public ClienteClave As String
    Public Monto As Decimal
    Dim Celda As Integer
    Dim Valida As String = "S"
    Public Nombre As String

    Private Sub FrmAceptaCheque_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LCliente.Text = "Cliente: " & FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Nombre Cliente").Value
        LMonto.Text = "Monto del depósito: " & FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Monto").Value
        LCheque.Text = "Nº de Documento: " & FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Nº de Documento").Value

        Nombre = FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Nombre Cliente").Value
        ClienteClave = FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Clave Cliente").Value
        Monto = FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Monto").Value
        Cheque = FrmChequesPrincipal.DataCheques.CurrentRow.Cells("Nº de Documento").Value
        Dim db As New ClsCheques
        Carga.DataSource = db.CargaFacturasPorCheque(Cheque, FrmChequesPrincipal.DataCheques.CurrentRow.Cells("N Banco").Value)
        DataFacturas.Rows.Clear()
        For Each row As DataGridViewRow In Carga.Rows
            DataFacturas.Rows.Add(row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(2).Value - row.Cells(3).Value)
        Next

        Dim dt As New DataTable
        dt = db.DetallesBanco(FrmChequesPrincipal.DataCheques.CurrentRow.Cells("N Banco").Value, "SAN RAFAEL")
        Cuenta.Text = dt(0)(3)
        NumeroBan.Text = dt(0)(4)

        Dim DTC As New DataTable
        DTC = db.DetallesCliente(ClienteClave)
        Almacen.Text = DTC(0)(0)


        If DataFacturas.RowCount = 1 Then
            DataFacturas.Rows(0).Cells(4).Value = Monto
            DataFacturas.Rows(0).Cells(4).Style.ForeColor = Color.DarkBlue
            DataFacturas.Rows(0).Cells(4).Style.Font = New Font(DataFacturas.Font, FontStyle.Bold)
            DataFacturas.Rows(0).Cells(4).ReadOnly = True
        ElseIf DataFacturas.RowCount > 0 Then
            Dim M As Decimal = Monto / DataFacturas.RowCount
            For Each row As DataGridViewRow In DataFacturas.Rows
                row.Cells("colPago").Value = M
                row.Cells("colPago").Style.ForeColor = Color.DarkBlue
                row.Cells("colPago").Style.Font = New Font(DataFacturas.Font, FontStyle.Bold)
            Next
        End If
    End Sub

    Private Sub BtnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAprobar.Click
        If Valida = "S" Then
            Try
                Dim db As New ClsCheques
                Dim dt As New DataTable

                dt.Columns.Add("Documento")
                dt.Columns.Add("Monto")
                dt.Columns.Add("Abonos")
                dt.Columns.Add("Saldo")
                dt.Columns.Add("Pago")

                Dim Cta As String = ""
                Dim Tip_Pol As String = ""
                'MsgBox(N_Almacen.Text)

                Cta = "110400100000000000004"

                If Almacen.Text = 2 Then
                    Tip_Pol = "Ig"
                ElseIf Almacen.Text = 1 Then
                    Tip_Pol = "Yv"
                ElseIf Almacen.Text = 3 Then
                    Tip_Pol = "Jc"
                ElseIf Almacen.Text = 4 Then
                    Tip_Pol = "TI"
                End If

                Dim dt_contabilizar As New DataTable
                dt_contabilizar.Columns.Add("CUENTA")
                dt_contabilizar.Columns.Add("VALOR")
                dt_contabilizar.Columns.Add("TIPO")

                Dim suma As Decimal
                suma = 0
                For Each row As DataGridViewRow In DataFacturas.Rows
                    suma += row.Cells(4).Value
                Next

                Dim fila As DataRow
                'Cuenta 1
                fila = dt_contabilizar.NewRow
                fila("CUENTA") = Cta
                fila("VALOR") = suma
                fila("TIPO") = "H"
                dt_contabilizar.Rows.Add(fila)

                'Cuenta Banco
                fila = dt_contabilizar.NewRow
                fila("CUENTA") = "110200700000000000004"
                fila("VALOR") = suma
                fila("TIPO") = "D"
                dt_contabilizar.Rows.Add(fila)
                For Each row As DataGridViewRow In DataFacturas.Rows
                    If Val(row.Cells(4).Value) > 0 Then
                        dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value)
                    End If
                Next

                Dim s As String = db.AceptaCheque(Cheque, _Inicio.lblUsuario.Text, dt, Today.Date, NumeroBan.Text, "08", dt_contabilizar, Today.Date.Month, Today.Date.Year, Tip_Pol, Nombre, Cheque, suma, NumeroBan.Text)
                If s = "SI" Then
                    MsgBox("El depósito se envió exitosamente", MsgBoxStyle.Information, "Depósito Enviado")
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                Else
                    MsgBox(s)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Las cantidades en el monto del depósito y los pagos a realizar no concuerdan. Verifique las cantidades ingresadas e intente nuevamente.", MsgBoxStyle.Critical, "Operación denegada")
        End If
    End Sub

    Private Sub DataFacturas_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataFacturas.CellEndEdit
        Dim suma As Decimal
        suma = 0
        For Each row As DataGridViewRow In DataFacturas.Rows
            suma += row.Cells(4).Value
        Next
        If suma <> Monto Then
            Valida = "N"
        Else
            Valida = "S"
        End If
    End Sub

    Private Sub DataFacturas_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles DataFacturas.CellBeginEdit
        Celda = DataFacturas.CurrentRow.Index
    End Sub
End Class