Imports Disar.data

Public Class FormOrdenesDeTrabajo

    Private Sub FormOrdenesDeTrabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Llena()
        LlenaOrdenes()
    End Sub

    Sub Llena()
        Dim db As New ClsBitacoraEventos
        CmbVehiculo.DataSource = db.TodosVehiculosRep
        CmbVehiculo.ValueMember = "Nº"
        CmbVehiculo.DisplayMember = "DESCRIPCIÓN"
    End Sub

    Sub LlenaOrdenes()
        Dim db As New ClsOrdenTrabajoVehicular
        ComboOrden.DataSource = db.TodasOrdenesCombo
        ComboOrden.ValueMember = "OrdenID"
        ComboOrden.DisplayMember = "OrdenNombre"
    End Sub

    Private Sub BtnNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNueva.Click
        FrmNuevaOrdenTrabajo.ShowDialog()
    End Sub

    Private Sub CmbVehiculo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbVehiculo.SelectedIndexChanged, ComboOrden.SelectedValueChanged, Desde.ValueChanged, Hasta.ValueChanged
        ActualizarDatos()
    End Sub

    Sub ActualizarDatos()
        Dim db As New ClsOrdenTrabajoVehicular
        If CmbVehiculo.SelectedIndex = 0 Then
            If ComboOrden.SelectedIndex = 0 Then
                Try
                    DataDatos.DataSource = db.MuestraORdenes(Desde.Value, Hasta.Value)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVer.Click
        Dim db As New ClsOrdenTrabajoVehicular

        Try
            FrmVerOrdenTrabajo.DataDatos.DataSource = db.MuestraTareasPorOrden(DataDatos.CurrentRow.Cells(0).Value)
            FrmVerOrdenTrabajo.NumeroDeOrden.Text = DataDatos.CurrentRow.Cells(0).Value
            FrmVerOrdenTrabajo.TextVehiculo.Text = DataDatos.CurrentRow.Cells(1).Value
            FrmVerOrdenTrabajo.TextKilometraje.Text = DataDatos.CurrentRow.Cells(2).Value
            FrmVerOrdenTrabajo.Orden.Text = DataDatos.CurrentRow.Cells(4).Value
            FrmVerOrdenTrabajo.FechaIngreso.Text = DataDatos.CurrentRow.Cells(5).Value
            FrmVerOrdenTrabajo.HoraIngreso.Text = DataDatos.CurrentRow.Cells(6).Value
            FrmVerOrdenTrabajo.FechaSalida.Text = DataDatos.CurrentRow.Cells(7).Value
            FrmVerOrdenTrabajo.HoraSalida.Text = DataDatos.CurrentRow.Cells(8).Value
            FrmVerOrdenTrabajo.TextAsignado.Text = DataDatos.CurrentRow.Cells(9).Value
        Catch ex As Exception
        End Try
        Try
            Dim dt As New DataTable
            dt = db.MuestraObservaciones(DataDatos.CurrentRow.Cells(0).Value)
            FrmVerOrdenTrabajo.TextObservaciones.Text = dt(0)(0)
        Catch ex As Exception
        End Try
        Try
            FrmVerOrdenTrabajo.ShowDialog()
        Catch ex As Exception
        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVrs.Click
        FormPreventivoCorrectivo.ShowDialog()
    End Sub

    
    Private Sub DataDatos_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataDatos.KeyDown
        If e.KeyCode = Keys.Delete Then
            Dim a = MsgBox("¿Está seguro que desea eliminar el mantenimiento seleccionado?", MsgBoxStyle.YesNo, "Eliminar y registrar bitácora")
            If a = MsgBoxResult.Yes Then
                Dim db As New ClsOrdenTrabajoVehicular
                db.EliminaOrden(DataDatos.CurrentRow.Cells(0).Value, _Inicio.lblUsuario.Text)
                ActualizarDatos()
            End If
        End If
    End Sub

 
    Private Sub ACT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ACT.Click
        ActualizarDatos()
    End Sub
End Class