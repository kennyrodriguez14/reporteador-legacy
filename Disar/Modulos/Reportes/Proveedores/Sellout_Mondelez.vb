Imports Disar.data
Imports System.IO

Public Class Sellout_Mondelez
    Dim conexion As New cls_sell_out_general
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If ComboBox1.Text = "Anterior" Then
            frmGuardarArchivo.Formulario = "sell_out_mondelez"
        Else
            frmGuardarArchivo.Formulario = "sell_out_mondelez2"
        End If

        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try
            If ComboBox1.Text = "Anterior" Then
                GridGeneral.DataSource = conexion.Mondelez(f1.Value.Date, f2.Value.Date)
            Else
                GridGeneral.DataSource = conexion.ArchivosMondelez(f1.Value.Date, f2.Value.Date, "SO_NUEVO")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Sell_Out_Mondelez" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs,
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With GridGeneral

                _Line = .Columns(0).HeaderText & vbTab &
                            .Columns(1).HeaderText & vbTab &
                            .Columns(2).HeaderText & vbTab &
                            .Columns(3).HeaderText & vbTab &
                            .Columns(4).HeaderText & vbTab &
                            .Columns(5).HeaderText & vbTab &
                            .Columns(6).HeaderText & vbTab &
                            .Columns(7).HeaderText & vbTab &
                            .Columns(8).HeaderText & vbTab &
                            .Columns(9).HeaderText & vbTab &
                            .Columns(10).HeaderText & vbTab &
                            .Columns(11).HeaderText & vbTab &
                            .Columns(12).HeaderText & vbTab &
                            .Columns(13).HeaderText & vbTab

                swFile.WriteLine(_Line)

                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab &
                            .Rows(i).Cells(1).Value & vbTab &
                            .Rows(i).Cells(2).Value & vbTab &
                            .Rows(i).Cells(3).Value & vbTab &
                            .Rows(i).Cells(4).Value & vbTab &
                            .Rows(i).Cells(5).Value & vbTab &
                            .Rows(i).Cells(6).Value & vbTab &
                            .Rows(i).Cells(7).Value & vbTab &
                            .Rows(i).Cells(8).Value & vbTab &
                            .Rows(i).Cells(9).Value & vbTab &
                            .Rows(i).Cells(10).Value & vbTab &
                            .Rows(i).Cells(11).Value & vbTab &
                            .Rows(i).Cells(12).Value & vbTab &
                            .Rows(i).Cells(13).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub exportarTXT2(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Sell_Out_Mondelez" & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs,
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With GridGeneral

                _Line = .Columns(0).HeaderText & vbTab &
                            .Columns(1).HeaderText & vbTab &
                            .Columns(2).HeaderText & vbTab &
                            .Columns(3).HeaderText & vbTab &
                            .Columns(4).HeaderText & vbTab &
                            .Columns(5).HeaderText & vbTab &
                            .Columns(6).HeaderText & vbTab &
                            .Columns(7).HeaderText & vbTab &
                            .Columns(8).HeaderText & vbTab &
                            .Columns(9).HeaderText & vbTab &
                            .Columns(10).HeaderText & vbTab &
                            .Columns(11).HeaderText & vbTab &
                            .Columns(12).HeaderText & vbTab &
                            .Columns(13).HeaderText & vbTab &
                            .Columns(14).HeaderText & vbTab &
                            .Columns(15).HeaderText & vbTab &
                            .Columns(16).HeaderText & vbTab &
                            .Columns(17).HeaderText & vbTab &
                            .Columns(18).HeaderText & vbTab &
                            .Columns(19).HeaderText & vbTab &
                            .Columns(20).HeaderText & vbTab &
                            .Columns(21).HeaderText & vbTab &
                            .Columns(22).HeaderText & vbTab &
                            .Columns(23).HeaderText & vbTab &
                            .Columns(24).HeaderText & vbTab
                swFile.WriteLine(_Line)

                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab &
                            .Rows(i).Cells(1).Value & vbTab &
                            .Rows(i).Cells(2).Value & vbTab &
                            .Rows(i).Cells(3).Value & vbTab &
                            .Rows(i).Cells(4).Value & vbTab &
                            .Rows(i).Cells(5).Value & vbTab &
                            .Rows(i).Cells(6).Value & vbTab &
                            .Rows(i).Cells(7).Value & vbTab &
                            .Rows(i).Cells(8).Value & vbTab &
                            .Rows(i).Cells(9).Value & vbTab &
                            .Rows(i).Cells(10).Value & vbTab &
                            .Rows(i).Cells(11).Value & vbTab &
                            .Rows(i).Cells(12).Value & vbTab &
                            .Rows(i).Cells(13).Value & vbTab &
                            .Rows(i).Cells(14).Value & vbTab &
                            .Rows(i).Cells(15).Value & vbTab &
                            .Rows(i).Cells(16).Value & vbTab &
                            .Rows(i).Cells(17).Value & vbTab &
                            .Rows(i).Cells(18).Value & vbTab &
                            .Rows(i).Cells(19).Value & vbTab &
                            .Rows(i).Cells(20).Value & vbTab &
                            .Rows(i).Cells(21).Value & vbTab &
                            .Rows(i).Cells(22).Value & vbTab &
                            .Rows(i).Cells(23).Value & vbTab &
                            .Rows(i).Cells(24).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmGuardarArchivo.Formulario = "sell_out_mondelez_archivos"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Sub exportarArchivosMondelez(ByVal Ruta As String)

        Dim dtNombres As New DataTable
        Dim db As New cls_sell_out_general

        Dim dt1 As New DataTable
        Dim dt2 As New DataTable

        dtNombres = db.ArchivosMondelez(f1.Value, f2.Value, "NOMBRES")

        Dim Nombre1 As String
        Nombre1 = dtNombres.Rows(0)(0)
        Dim Nombre2 As String
        Nombre2 = dtNombres.Rows(1)(0)

        dt1 = db.ArchivosMondelez(f1.Value, f2.Value, "TAB1")
        dt2 = db.ArchivosMondelez(f1.Value, f2.Value, "TAB2")


        Dim sFile1 As String = Ruta & "\" & Nombre1
        Dim _Line1 As String = Nothing

        Dim sFile2 As String = Ruta & "\" & Nombre2
        Dim _Line2 As String = Nothing

        Try
            If File.Exists(sFile1) = True Then
                My.Computer.FileSystem.DeleteFile(sFile1, FileIO.UIOption.OnlyErrorDialogs,
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile1, True, System.Text.Encoding.Default)


            With dt1
                For i = 0 To .Rows.Count - 1
                    _Line1 = .Rows(i)(0)
                    swFile.WriteLine(_Line1)
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            'Process.Start(sFile1)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            If File.Exists(sFile2) = True Then
                My.Computer.FileSystem.DeleteFile(sFile2, FileIO.UIOption.OnlyErrorDialogs,
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile2, True, System.Text.Encoding.Default)

            With dt2
                For i = 0 To .Rows.Count - 1
                    _Line2 = .Rows(i)(0)
                    swFile.WriteLine(_Line2)
                Next
            End With
            'swFile = System.Text.Encoding.Default
            swFile.Close()
            'Process.Start(sFile1)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub Sellout_Mondelez_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        f1.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            f2.Value = Today
        Else
            f2.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub
End Class