Imports Disar.data

Public Class frm_horas_trabajo
    Dim conexion As New cls_horas_Trabajo
    Dim Clase As New cls_reporte_carga
    Private Sub frm_horas_trabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cargar_Almacen()
        cargar()
    End Sub

    Sub cargar()
        Try
            grdHoras.DataSource = conexion.dia(cmbFecha.Value.Date)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub Cargar_Almacen()
        cmbAlmacen.DataSource = Clase.getAlmacen(0, 0, "CONSUMO", Now, "", "ALM", 1)
        cmbAlmacen.ValueMember = "ID"
        cmbAlmacen.DisplayMember = "ALMACEN"
    End Sub

    Private Sub btnEntrada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrada.Click
        Try
            conexion.Entrada(cmbFecha.Value.Date, Now, cmbAlmacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cargar()
    End Sub

    Private Sub btnSalida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalida.Click
        Try
            If cmbAlmacen.SelectedValue = 1 Then
                conexion.Salida(grdHoras.Rows(0).Cells(1).Value, Now, cmbAlmacen.SelectedValue)
            ElseIf cmbAlmacen.SelectedValue = 2 Then
                conexion.Salida(grdHoras.Rows(0).Cells(1).Value, Now, cmbAlmacen.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        cargar()
    End Sub

    Private Sub cmbFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFecha.ValueChanged
        cargar()
    End Sub


End Class