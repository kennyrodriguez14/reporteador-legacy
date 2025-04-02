Imports Disar.data

Public Class FormReunionesPrincipal

    Private Sub FormReunionesPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim db As New clsReuniones
        Dim dt As New DataTable
        Try
            dt = db.NombreUsuario(_Inicio.lblUsuario.Text)
            Usuario.Text = dt(0)(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        CargaReuniones()
        CargaPendientes()

    End Sub

    Sub CargaPendientes()
        Dim db As New clsReuniones
        Try
            DataPendientes.DataSource = db.MuestraPendientesUsuario(_Inicio.lblUsuario.Text)
            DataPendientes.Columns("Asignado").Visible = False
            DataPendientes.Columns("Reunion").Visible = False
            DataPendientes.Columns("Registro").Visible = False
            DataPendientes.Columns("Nom").Visible = False
            DataPendientes.Columns("Tema").Visible = False

            DataPendientes.Columns(1).Frozen = True
            DataPendientes.Columns(1).DividerWidth = 3
            UsuariosXPendiente()
        Catch ex As Exception
        End Try
    End Sub

    Sub UsuariosXPendiente()
        Dim db As New clsReuniones
        Dim dt As New DataTable
        Try
            dt.Rows.Clear()
        Catch ex As Exception
        End Try
        Try
            For Each row As DataGridViewRow In DataPendientes.Rows
                dt = db.UsuariosXPendiente(row.Cells(0).Value)
                row.Cells("Asignado a").Value = ""
                If dt.Rows.Count = 1 Then
                    row.Cells("Asignado a").Value = dt(0)(0)
                Else
                    row.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    For Sabu As Integer = 0 To dt.Rows.Count - 1
                        If Sabu = dt.Rows.Count - 1 Then
                            row.Cells("Asignado a").Value = row.Cells("Asignado a").Value & dt(Sabu)(0)
                        Else
                            row.Cells("Asignado a").Value = row.Cells("Asignado a").Value & dt(Sabu)(0) & vbNewLine
                        End If

                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub CargaReuniones()
        Dim db As New clsReuniones
        DataReuniones.DataSource = db.Reuniones(_Inicio.lblUsuario.Text)
        Try
            DataReuniones.Columns("ID").Visible = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DataReuniones_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataReuniones.CellClick
        Try
            Dim db As New clsReuniones
            DataDetalles.DataSource = db.TemasReunion(DataReuniones.CurrentRow.Cells(0).Value)
            DataParticipantes.DataSource = db.ParticipantesReunion(DataReuniones.CurrentRow.Cells(0).Value)

            DataParticipantes.Columns("ID").Visible = False
            DataDetalles.Columns(0).Visible = False
            DataParticipantes.Columns(2).Visible = False
        Catch ex As Exception
        End Try

    End Sub
 
    Private Sub BtnIniciarReunino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnIniciarReunino.Click
        If DataReuniones.RowCount > 0 Then


            Dim Respuesta = MsgBox("¿Está seguro de iniciar con " & DataReuniones.CurrentRow.Cells(1).Value & "?", MsgBoxStyle.YesNo)
            If Respuesta = MsgBoxResult.Yes Then
                Dim Fecha As DateTime
                Dim db As New clsReuniones
                Dim dt As New DataTable
                dt = db.FechaHora
                Fecha = dt(0)(0)
                FrmLlenadoReunion.Responsable = DataReuniones.CurrentRow.Cells("ID").Value
                Try
                    FrmLlenadoReunion.DataParticipantes.DataSource = Nothing
                    FrmLlenadoReunion.DataParticipantes.Columns.Clear()
                Catch ex As Exception
                End Try
                Try
                    FrmLlenadoReunion.DataDetalles.DataSource = Nothing
                    FrmLlenadoReunion.DataDetalles.Columns.Clear()
                Catch ex As Exception
                End Try

                Dim dte As New DataTable
                dte = db.VerificaReunion(DataReuniones.CurrentRow.Cells(0).Value, Fecha)
                If dte.Rows.Count > 10 Then
                    MsgBox("Ya se ha iniciado esta reunion el día de hoy: " & dte(0)(0))
                Else
                    FrmLlenadoReunion.FechaHora.Text = Fecha.ToString
                    FrmLlenadoReunion.ReunionID.Text = DataReuniones.CurrentRow.Cells(0).Value
                    FrmLlenadoReunion.Reunion.Text = DataReuniones.CurrentRow.Cells(1).Value
                    FrmLlenadoReunion.DataDetalles.DataSource = db.TemasReunion(DataReuniones.CurrentRow.Cells(0).Value)
                    FrmLlenadoReunion.DataParticipantes.DataSource = db.ParticipantesReunion(DataReuniones.CurrentRow.Cells(0).Value)

                    FrmLlenadoReunion.ShowDialog()
                End If
            End If
        End If
    End Sub

    Private Sub MisReunionesAnterioresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MisReunionesAnterioresToolStripMenuItem.Click
        If FormBitacoraReuniones.Visible = True Then
            FormBitacoraReuniones.BringToFront()
        Else
            FormBitacoraReuniones.ShowDialog()
        End If
    End Sub
     
    Private Sub BtnCrearReunion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCrearReunion.Click
        Dim a = MsgBox("¿Está seguro que desea crear un nuevo registro? Asegúrese que la reunión no se encuentre en el listado 'Reuniones en las que se encuentra registrado' y de clic en si para continuar.", MsgBoxStyle.YesNo, "Creación de Nueva Reunión")

        If a = MsgBoxResult.Yes Then
            If FormNuevaReunion.Visible = True Then
                FormNuevaReunion.BringToFront()
            Else
                FormNuevaReunion.ShowDialog()
            End If
        End If
        
    End Sub

    Private Sub BtnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAgregar.Click
        If DataReuniones.RowCount > 0 Then
            FrmAgregarTema.REU = DataReuniones.CurrentRow.Cells(0).Value
            FrmAgregarTema.ShowDialog()
        End If
    End Sub
 
    Private Sub SalirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub mnu_Pendientes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnu_Pendientes.Click
        FrmGestionPendientes.ShowDialog()
    End Sub

     
End Class