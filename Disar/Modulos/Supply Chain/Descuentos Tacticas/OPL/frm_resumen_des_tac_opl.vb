Imports Disar.data
Imports System.IO

Public Class frm_resumen_des_tac_opl

    Dim conexion As New cls_descuentos_tacticos
    Private Sub frm_resumen_des_tac_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargar_almacenes()
    End Sub

    Sub cargar_almacenes()
        Try
            cmb_almacen.DataSource = conexion.ListarAlmacenes_para_resumen_opl
            cmb_almacen.DisplayMember = "ALMACEN"
            cmb_almacen.ValueMember = "ID"
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_aceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_aceptar.Click
        Try
            grd_listado.DataSource = conexion.reporte_resumen_opl(cmb_fecha_inicial.Value, cmb_fecha_final.Value, cmb_almacen.SelectedValue)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_excel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_excel.Click
        'exportar_fast()
        'Exportar()

        frmGuardarArchivo.Formulario = "Resumen_Descuentos_Tacticos_OPL"

        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Resumen_Descuentos_Tactic " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs,
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)

            '_Line = "Año Anterior"
            'swFile.WriteLine(_Line)
            '_Line = ""

            Dim dt As New DataTable
            Dim db As New ClsClientes

            For Each column As DataGridViewColumn In grd_listado.Columns
                _Line = _Line & column.HeaderText & vbTab
            Next

            swFile.WriteLine(_Line)

            For i = 0 To grd_listado.RowCount - 1
                _Line = ""
                For Each column As DataGridViewColumn In grd_listado.Columns
                    _Line = _Line & grd_listado.Rows(i).Cells(column.Index).Value & vbTab
                Next

                swFile.WriteLine(_Line)

            Next
            _Line = ""
            swFile.WriteLine(_Line)
            swFile.WriteLine(_Line)


            'swFile = System.Text.Encoding.Default
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Sub Exportar()
        Try
            Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            For c As Integer = 0 To grd_listado.Columns.Count - 1
                wSheet.Cells(1, c + 1).value = grd_listado.Columns(c).HeaderText
                wSheet.Cells(1, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                wSheet.Cells(1, c + 1).Font.Bold = True
                wSheet.Cells(1, c + 1).Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White)
                wSheet.Cells(1, c + 1).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black)
            Next
            For r As Integer = 0 To grd_listado.RowCount - 1
                For c As Integer = 0 To grd_listado.Columns.Count - 1
                    wSheet.Cells(r + 2, c + 1).value = grd_listado.Item(c, r).Value
                    wSheet.Cells(r + 2, c + 1).BorderAround(1, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin)
                Next
            Next
            wSheet.Columns.AutoFit()
            excel.Visible = True
            excel.Quit()
        Catch ex As Exception
            MessageBox.Show("Error al Exportar " + ex.ToString, "Problemas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Public Sub exportar_fast()
    '    Try
    '        Dim sData As String = ""



    '        For index As Integer = 0 To grd_listado.Columns.Count - 1
    '            If index = grd_listado.Columns.Count - 1 Then
    '                sData += grd_listado.Columns(index).Name() & vbCr
    '            Else
    '                sData += grd_listado.Columns(index).Name() & vbTab
    '            End If
    '        Next

    '        For index As Integer = 0 To grd_listado.Rows.Count - 1
    '            sData += grd_listado.Rows(index).Cells(0).Value & vbTab & grd_listado.Rows(index).Cells(1).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(2).Value & vbTab & grd_listado.Rows(index).Cells(3).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(4).Value & vbTab & grd_listado.Rows(index).Cells(5).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(6).Value & vbTab & grd_listado.Rows(index).Cells(7).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(8).Value & vbTab & grd_listado.Rows(index).Cells(9).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(10).Value & vbTab & grd_listado.Rows(index).Cells(11).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(12).Value & vbTab & grd_listado.Rows(index).Cells(13).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(14).Value & vbTab & grd_listado.Rows(index).Cells(15).Value & vbTab _
    '            & grd_listado.Rows(index).Cells(16).Value & vbCr

    '        Next

    '        Clipboard.Clear()
    '        Clipboard.SetText(sData)

    '        Dim excel As New Microsoft.Office.Interop.Excel.ApplicationClass
    '        Dim wBook As Microsoft.Office.Interop.Excel.Workbook
    '        Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
    '        wBook = excel.Workbooks.Add()
    '        wSheet = wBook.ActiveSheet()

    '        wSheet.Range("A1").Select()
    '        wSheet.Paste()

    '        Clipboard.Clear()
    '        excel.Visible = True
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
End Class