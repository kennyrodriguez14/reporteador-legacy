Imports Disar.data

Public Class frm_permisos
    Public cod_usu As Integer
    Public name_usu As String

    Dim dt_datosux As New DataTable
    Dim dt_reportes As New DataTable
    Dim dt_supply_chain As New DataTable
    Dim dt_contabilidad As New DataTable
    Dim dt_inventarios As New DataTable
    Dim dt_almacen As New DataTable
    Dim dt_PDSE As New DataTable
    Dim dt_bonificaciones As New DataTable
    Dim dt_configuracion As New DataTable
    Dim dt_monitoreo As New DataTable
    Dim dt_adicionales As New DataTable

    Private Sub mol_reportes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_reportes.CheckedChanged
        If mol_reportes.Checked = True Then
            permisos_reportes.Enabled = True
        Else
            permisos_reportes.Enabled = False
        End If
    End Sub

    Private Sub mol_supply_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_supply.CheckedChanged
        If mol_supply.Checked = True Then
            permisos_supply.Enabled = True
        Else
            permisos_supply.Enabled = False
        End If
    End Sub

    Private Sub mol_contabilidad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_contabilidad.CheckedChanged
        If mol_contabilidad.Checked = True Then
            permisos_contabilidad.Enabled = True
        Else
            permisos_contabilidad.Enabled = False
        End If
    End Sub

    Private Sub mol_inventarios_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_inventarios.CheckedChanged
        If mol_inventarios.Checked = True Then
            permisos_inventarios.Enabled = True
        Else
            permisos_inventarios.Enabled = False
        End If
    End Sub

    Private Sub mol_almacen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_almacen.CheckedChanged
        If mol_almacen.Checked = True Then
            permisos_almacen.Enabled = True
        Else
            permisos_almacen.Enabled = False
        End If
    End Sub

    Private Sub mol_pdse_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_pdse.CheckedChanged
        If mol_pdse.Checked = True Then
            permisos_pdse.Enabled = True
        Else
            permisos_pdse.Enabled = False
        End If
    End Sub

    Private Sub mol_bonificaciones_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_bonificaciones.CheckedChanged
        If mol_bonificaciones.Checked = True Then
            permisos_bonificaciones.Enabled = True
        Else
            permisos_bonificaciones.Enabled = False
        End If
    End Sub

    Private Sub mol_configuracion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_configuracion.CheckedChanged
        If mol_configuracion.Checked = True Then
            permisos_configuracion.Enabled = True
        Else
            permisos_configuracion.Enabled = False
        End If
    End Sub
    Private Sub mol_adicionales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_adicionales.CheckedChanged

        If mol_adicionales.Checked = True Then
            permisos_adicionales.Enabled = True
        Else
            permisos_adicionales.Enabled = False
        End If
    End Sub

    Private Sub frm_permisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            txt_usuario.Text = name_usu

            Dim conexion As New clsSeguridad
            dt_datosux = conexion.datosux(cod_usu)
            dt_reportes = conexion.Permisos(cod_usu, "Reportes")
            dt_supply_chain = conexion.Permisos(cod_usu, "Supply Chain")
            dt_contabilidad = conexion.Permisos(cod_usu, "contabilidad")
            dt_inventarios = conexion.Permisos(cod_usu, "Inventarios")
            dt_almacen = conexion.Permisos(cod_usu, "Almacen")
            dt_PDSE = conexion.Permisos(cod_usu, "PDSE")
            dt_bonificaciones = conexion.Permisos(cod_usu, "Bonificaciones")
            dt_configuracion = conexion.Permisos(cod_usu, "Configuracion")
            dt_monitoreo = conexion.Permisos(cod_usu, "Monitoreo")
            dt_adicionales = conexion.Permisos(cod_usu, "Funciones Adicionales")


            If dt_datosux.Rows(0)(0) = "1" Then
                mol_reportes.Checked = True
            End If
            If dt_datosux.Rows(0)(1) = "1" Then
                mol_supply.Checked = True
            End If
            If dt_datosux.Rows(0)(2) = "1" Then
                mol_contabilidad.Checked = True
            End If
            If dt_datosux.Rows(0)(3) = "1" Then
                mol_inventarios.Checked = True
            End If
            If dt_datosux.Rows(0)(4) = "1" Then
                mol_almacen.Checked = True
            End If
            If dt_datosux.Rows(0)(5) = "1" Then
                mol_pdse.Checked = True
            End If
            If dt_datosux.Rows(0)(6) = "1" Then
                mol_bonificaciones.Checked = True
            End If
            If dt_datosux.Rows(0)(7) = "1" Then
                mol_configuracion.Checked = True
            End If
            If dt_datosux.Rows(0)(8) = "1" Then
                mol_monitoreo.Checked = True
            End If
            If Not IsDBNull(dt_datosux.Rows(0)("M12")) Then
                If dt_datosux.Rows(0)("M12") = "1" Then
                    mol_adicionales.Checked = True
                End If
            End If

            For index As Integer = 0 To dt_reportes.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_reportes.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_reportes.Items.Add(dt_reportes.Rows(index)(2), estado)
            Next

            For index As Integer = 0 To dt_supply_chain.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_supply_chain.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_supply.Items.Add(dt_supply_chain.Rows(index)(2), estado)
            Next

            For index As Integer = 0 To dt_contabilidad.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_contabilidad.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_contabilidad.Items.Add(dt_contabilidad.Rows(index)(2), estado)
            Next

            For index As Integer = 0 To dt_inventarios.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_inventarios.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_inventarios.Items.Add(dt_inventarios.Rows(index)(2), estado)
            Next

            For index As Integer = 0 To dt_almacen.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_almacen.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_almacen.Items.Add(dt_almacen.Rows(index)(2), estado)
            Next

            For index As Integer = 0 To dt_PDSE.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_PDSE.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_pdse.Items.Add(dt_PDSE.Rows(index)(2), estado)
            Next

            For index As Integer = 0 To dt_bonificaciones.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_bonificaciones.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_bonificaciones.Items.Add(dt_bonificaciones.Rows(index)(2), estado)
            Next

            For index As Integer = 0 To dt_configuracion.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_configuracion.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_configuracion.Items.Add(dt_configuracion.Rows(index)(2), estado)
            Next


            For index As Integer = 0 To dt_monitoreo.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_monitoreo.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_monitoreo.Items.Add(dt_monitoreo.Rows(index)(2), estado)
            Next


            For index As Integer = 0 To dt_adicionales.Rows.Count - 1
                Dim estado As Boolean

                If Convert.ToString(dt_adicionales.Rows(index)(4)) = "1" Then
                    estado = True
                Else
                    estado = False
                End If
                permisos_adicionales.Items.Add(dt_adicionales.Rows(index)(2), estado)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_cancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        Me.Close()
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            Dim reportes As Integer = 0, logistica As Integer = 0, contabilidad As Integer = 0, inventarios As Integer = 0
            Dim almacen As Integer = 0, pdse As Integer = 0, bonificaciones As Integer = 0, configuracion As Integer = 0, monitoreo As Integer, adicionales As Integer

            Dim conexion As New clsSeguridad

            If mol_reportes.Checked = True Then
                reportes = 1
            End If
            If mol_almacen.Checked = True Then
                almacen = 1
            End If
            If mol_bonificaciones.Checked = True Then
                bonificaciones = 1
            End If
            If mol_configuracion.Checked = True Then
                configuracion = 1
            End If
            If mol_contabilidad.Checked = True Then
                contabilidad = 1
            End If
            If mol_inventarios.Checked = True Then
                inventarios = 1
            End If
            If mol_pdse.Checked = True Then
                pdse = 1
            End If
            If mol_supply.Checked = True Then
                logistica = 1
            End If
            If mol_monitoreo.Checked = True Then
                monitoreo = 1
            End If
            If mol_adicionales.Checked = True Then
                adicionales = 1
            End If
            conexion.clear_perfil(cod_usu)
            conexion.actualizar_perfil(cod_usu, reportes, logistica, contabilidad, inventarios, almacen, pdse, bonificaciones, configuracion, monitoreo, adicionales)

            For index As Integer = 0 To permisos_reportes.Items.Count - 1
                If permisos_reportes.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_reportes.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_almacen.Items.Count - 1
                If permisos_almacen.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_almacen.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_bonificaciones.Items.Count - 1
                If permisos_bonificaciones.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_bonificaciones.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_configuracion.Items.Count - 1
                If permisos_configuracion.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_configuracion.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_contabilidad.Items.Count - 1
                If permisos_contabilidad.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_contabilidad.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_inventarios.Items.Count - 1
                If permisos_inventarios.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_inventarios.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_pdse.Items.Count - 1
                If permisos_pdse.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_PDSE.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_supply.Items.Count - 1
                If permisos_supply.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_supply_chain.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_monitoreo.Items.Count - 1
                If permisos_monitoreo.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_monitoreo.Rows(index)(0))
                End If
            Next

            For index As Integer = 0 To permisos_adicionales.Items.Count - 1
                If permisos_adicionales.GetItemChecked(index) Then
                    conexion.asignar_perfil(cod_usu, dt_adicionales.Rows(index)(0))
                End If
            Next

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub mol_monitoreo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mol_monitoreo.CheckedChanged
        If mol_monitoreo.Checked = True Then
            permisos_monitoreo.Enabled = True
        Else
            permisos_monitoreo.Enabled = False
        End If
    End Sub


End Class