Imports Disar.data
Imports System.IO

Public Class frm_libro_ventas
    Dim conexion As New cls_libro_ventas
    Private Sub frm_libro_ventas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmb_tipo.SelectedItem = "Ventas"
        cargar_sucursal()
    End Sub

    Sub cargar_sucursal()
        Try
            cmbSucursal.DataSource = conexion.listar_ventas("disar", "sucursales", Now.Date, Now.Date, 1)
            cmbSucursal.ValueMember = "ID"
            cmbSucursal.DisplayMember = "DESCR"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub cargar_almacen()
        Try
            cmb_almacen.DataSource = conexion.listar_ventas(cmbSucursal.SelectedValue, "almacenes", Now.Date, Now.Date, 1)
            cmb_almacen.ValueMember = "ID"
            cmb_almacen.DisplayMember = "DESCR"
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmbSucursal_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSucursal.SelectedIndexChanged
        Try
            cargar_almacen()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            grd_ventas.DataSource = conexion.listar_ventas(cmbSucursal.SelectedValue, cmb_tipo.SelectedItem, _
                                                           cmb_F1.Value, cmb_f2.Value, cmb_almacen.SelectedValue)

            Dim conexion_bita As New cls_bitacora_reporteador
            conexion_bita.RegistraBitacora(Now, _Inicio.lblUsuario.Text, "Genero Libro de Ventas", "Contabilidad", _
                                      "Fecha del reporte: " + cmb_F1.Value.Date + "-" + cmb_f2.Value.Date + " Tipo: " + _
                                      cmb_tipo.SelectedItem + " Almacen: " + cmb_almacen.SelectedValue.ToString)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_exportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exportar.Click
        'Exportar()
        frmGuardarArchivo.Formulario = "libro_ventas"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Libro_De_Ventas" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With grd_ventas

                For index As Integer = 0 To grd_ventas.Columns.Count - 1
                    If (index = grd_ventas.Columns.Count - 1) Then
                        _Line += .Columns(index).HeaderText
                    Else
                        _Line += .Columns(index).HeaderText & vbTab
                    End If
                Next

                '_Line = .Columns(0).HeaderText & vbTab & _
                '            .Columns(1).HeaderText & vbTab & _
                '            .Columns(2).HeaderText & vbTab & _
                '            .Columns(3).HeaderText & vbTab & _
                '            .Columns(4).HeaderText & vbTab & _
                '            .Columns(5).HeaderText & vbTab & _
                '            .Columns(6).HeaderText & vbTab & _
                '            .Columns(7).HeaderText & vbTab & _
                '            .Columns(8).HeaderText & vbTab & _
                '            .Columns(9).HeaderText & vbTab & _
                '            .Columns(10).HeaderText & vbTab & _
                '            .Columns(11).HeaderText & vbTab & _
                '            .Columns(12).HeaderText & vbTab & _
                '            .Columns(13).HeaderText & vbTab & _
                '            .Columns(14).HeaderText & vbTab & _
                '            .Columns(15).HeaderText & vbTab & _
                '            .Columns(16).HeaderText & vbTab & _
                '            .Columns(17).HeaderText & vbTab & _
                '            .Columns(18).HeaderText & vbTab & _
                '            .Columns(19).HeaderText & vbTab & _
                '            .Columns(20).HeaderText & vbTab & _
                '            .Columns(21).HeaderText & vbTab & _
                '            .Columns(22).HeaderText & vbTab & _
                '            .Columns(23).HeaderText & vbTab & _
                '            .Columns(24).HeaderText & vbTab & _
                '            .Columns(25).HeaderText & vbTab & _
                '            .Columns(26).HeaderText

                swFile.WriteLine(_Line)
                _Line = ""
                For i = 0 To .RowCount - 1
                    For index As Integer = 0 To .Columns.Count - 1
                        If (index = .Columns.Count - 1) Then
                            Dim Carga As String = ""
                            If Not IsDBNull(.Rows(i).Cells(index).Value) Then
                                Carga = .Rows(i).Cells(index).Value
                            End If
                            _Line += Carga
                        Else
                            If index = 1 Then
                                Dim Carga As String = ""
                                If Not IsDBNull(.Rows(i).Cells(index).Value) Then
                                    Carga = "'" & .Rows(i).Cells(index).Value
                                End If
                                'If .Rows(i).Cells(index).Value = "" Then
                                '_Line += "" & vbTab
                                'Else
                                _Line += Carga & vbTab
                                'End If
                            Else
                                Dim Carga As String = ""
                                If Not IsDBNull(.Rows(i).Cells(index).Value) Then
                                    Carga = .Rows(i).Cells(index).Value
                                End If
                                _Line += Carga & vbTab
                            End If
                        End If
                    Next

                    '_Line = .Rows(i).Cells(0).Value & vbTab & _
                    '        .Rows(i).Cells(1).Value & vbTab & _
                    '        .Rows(i).Cells(2).Value & vbTab & _
                    '        .Rows(i).Cells(3).Value & vbTab & _
                    '        .Rows(i).Cells(4).Value & vbTab & _
                    '        .Rows(i).Cells(5).Value & vbTab & _
                    '        .Rows(i).Cells(6).Value & vbTab & _
                    '        .Rows(i).Cells(7).Value & vbTab & _
                    '        .Rows(i).Cells(8).Value & vbTab & _
                    '        .Rows(i).Cells(9).Value & vbTab & _
                    '        .Rows(i).Cells(10).Value & vbTab & _
                    '        .Rows(i).Cells(11).Value & vbTab & _
                    '        .Rows(i).Cells(12).Value & vbTab & _
                    '        .Rows(i).Cells(13).Value & vbTab & _
                    '        .Rows(i).Cells(14).Value & vbTab & _
                    '        .Rows(i).Cells(15).Value & vbTab & _
                    '        .Rows(i).Cells(16).Value & vbTab & _
                    '        .Rows(i).Cells(17).Value & vbTab & _
                    '        .Rows(i).Cells(18).Value & vbTab & _
                    '        .Rows(i).Cells(19).Value & vbTab & _
                    '        .Rows(i).Cells(20).Value & vbTab & _
                    '        .Rows(i).Cells(21).Value & vbTab & _
                    '        .Rows(i).Cells(22).Value & vbTab & _
                    '        .Rows(i).Cells(23).Value & vbTab & _
                    '        .Rows(i).Cells(24).Value & vbTab & _
                    '        .Rows(i).Cells(25).Value & vbTab & _
                    '                    .Rows(i).Cells(26).Value

                    swFile.WriteLine(_Line)
                    _Line = ""
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Sub Exportar()
    '    Try
    '        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
    '        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
    '        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
    '        wBook = excel.Workbooks.Add()
    '        wSheet = wBook.ActiveSheet()

    '        For c As Integer = 0 To grd_ventas.Columns.Count - 1
    '            wSheet.Cells(1, c + 1).value = grd_ventas.Columns(c).HeaderText
    '        Next
    '        For r As Integer = 0 To grd_ventas.RowCount - 1
    '            For c As Integer = 0 To grd_ventas.Columns.Count - 1

    '                If c = 1 Then
    '                    wSheet.Cells(r + 2, c + 1).value = "'" + grd_ventas.Item(c, r).Value
    '                Else
    '                    wSheet.Cells(r + 2, c + 1).value = grd_ventas.Item(c, r).Value
    '                End If
    '            Next
    '        Next
    '        wSheet.Columns.AutoFit()
    '        excel.Visible = True
    '        excel.Quit()
    '    Catch ex As Exception
    '        MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub
End Class