Imports Disar.data
Imports System.Reflection
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports System.IO

Public Class FormMovimientosPapeleria

    Dim AlmacenBienesRecursos As Integer

    Private Sub FormMovimientosPapeleria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargarPendientes()
        GroupPendientes.BringToFront()
    End Sub

    Private Sub BtnFiltrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFiltrar.Click
        Dim db As New ClsPapeleria
        DataMovimientos.DataSource = db.CargarMovimientos(DateTimePicker1.Value, DateTimePicker2.Value, AlmacenBienesRecursos)
    End Sub

    Private Sub ComboAlmacen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAlmacen.SelectedIndexChanged
        If ComboAlmacen.Text = "SPS" Then
            AlmacenBienesRecursos = 4
        ElseIf ComboAlmacen.Text = "SRC" Then
            AlmacenBienesRecursos = 5
        ElseIf ComboAlmacen.Text = "SAB" Then
            AlmacenBienesRecursos = 6
        ElseIf ComboAlmacen.Text = "TGU" Then
            AlmacenBienesRecursos = 16
        ElseIf ComboAlmacen.Text = "SR AGRO SRC" Then
            AlmacenBienesRecursos = 11
        Else
            AlmacenBienesRecursos = -1
        End If
    End Sub

    Private Sub DataPendientes_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataPendientes.CellDoubleClick
        Dim db As New ClsPapeleria
        FrmCompletaMovPapeleria.DataDatos.DataSource = db.CargarPartidas(DataPendientes.CurrentRow.Cells(0).Value)
        FrmCompletaMovPapeleria.TextID.Text = DataPendientes.CurrentRow.Cells(0).Value
        FrmCompletaMovPapeleria.TextNickSolicitante.Text = DataPendientes.CurrentRow.Cells(1).Value
        FrmCompletaMovPapeleria.TextSolicitante.Text = DataPendientes.CurrentRow.Cells(2).Value
        FrmCompletaMovPapeleria.TextFecha.Text = DataPendientes.CurrentRow.Cells(4).Value
        FrmCompletaMovPapeleria.TextID_Depto.Text = DataPendientes.CurrentRow.Cells(7).Value
        FrmCompletaMovPapeleria.TextDepartamento.Text = DataPendientes.CurrentRow.Cells(8).Value
        FrmCompletaMovPapeleria.ComboAlmacen.Text = DataPendientes.CurrentRow.Cells(9).Value
        FrmCompletaMovPapeleria.ShowDialog()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GroupMovimientos.BringToFront()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        GroupPendientes.BringToFront()
        CargarPendientes()
    End Sub

    Sub CargarPendientes()
        Dim db As New ClsPapeleria
        DataPendientes.DataSource = db.CargarMovimientosPendientes
    End Sub

End Class