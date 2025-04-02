Imports Disar.data

Public Class FormPreventivoCorrectivo

    Private Sub BtnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGenerar.Click
        Dim db As New ClsOrdenTrabajoVehicular
        If CmbVehiculo.Text = " TODOS" Then
            DataDatos.DataSource = db.DetallePreventivoVSCorrectivo(Desde.Value, Hasta.Value)
        Else
            DataDatos.DataSource = db.DetallePreventivoVSCorrectivoFiltro(Desde.Value, Hasta.Value, CmbVehiculo.SelectedValue)
        End If
        Calculos()
    End Sub

    Private Sub FormPreventivoCorrectivo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llena()
    End Sub

    Sub Llena()
        Dim db As New ClsBitacoraEventos
        CmbVehiculo.DataSource = db.TodosVehiculosRep
        CmbVehiculo.ValueMember = "Nº"
        CmbVehiculo.DisplayMember = "DESCRIPCIÓN"
    End Sub

    Sub Calculos()
        Try
            Dim Total As Integer = DataDatos.RowCount
            TextTotalMantenimientos.Text = Total
            Dim TotalPreventivos As Integer = 0
            Dim TotalCorrectivos As Integer = 0
            For Each row As DataGridViewRow In DataDatos.Rows
                If Not IsDBNull(row.Cells(11).Value) Then
                    If row.Cells(11).Value = "Preventivo" Then
                        TotalPreventivos += 1
                    Else
                        TotalCorrectivos += 1
                    End If
                End If
            Next
            TextCorrectivos.Text = TotalCorrectivos
            TextPreventivos.Text = TotalPreventivos
            TextPorcentajeCorrectivos.Text = Math.Round((TotalCorrectivos / Total) * 100, 2) & " %"
            TextPorcentajePreventivos.Text = Math.Round((TotalPreventivos / Total) * 100, 2) & " %"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class