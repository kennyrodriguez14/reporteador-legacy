Imports Disar.data
Imports System.IO

Public Class Inventarios_OPL
    Dim Conexion As New cls_inventarios

    Sub Cargar()
        Try
            '   _gridInventarios.Columns.Clear()
            _gridInventarios.DataSource = Conexion.GenerarDatosOPL(txtCodigo.Text, txtCodigo.Text.ToUpper, cmbsucursal.SelectedItem, cmbTbusqueda.SelectedItem)
        Catch ex As Exception
            MsgBox("Error al cargar los datos " + ex.ToString)
        End Try
    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Cargar()
        OcultarCampos()
    End Sub

    Sub OcultarCampos()

        If cmbsucursal.Text <> "SR_AGRO" Then
            _gridInventarios.Columns("PALETIZADO SP").Visible = False
            _gridInventarios.Columns("PALETIZADO SR").Visible = False
            _gridInventarios.Columns("PALETIZADO SABA").Visible = False

            _gridInventarios.Columns("UBICACION TEGUS").Visible = False
            _gridInventarios.Columns("UBICACION SABA").Visible = False
            _gridInventarios.Columns("UBICACION SRC").Visible = False
            _gridInventarios.Columns("UBICACION SPS").Visible = False
        End If

        If cmbsucursal.Text = "SRC" Then
            _gridInventarios.Columns("PALETIZADO SR").Visible = True
            _gridInventarios.Columns("UBICACION SRC").Visible = True

        ElseIf cmbsucursal.Text = "SPS" Then
            _gridInventarios.Columns("PALETIZADO SP").Visible = True
            _gridInventarios.Columns("UBICACION SPS").Visible = True

        ElseIf cmbsucursal.Text = "Saba" Then
            _gridInventarios.Columns("PALETIZADO SABA").Visible = True
            _gridInventarios.Columns("UBICACION SABA").Visible = True

        ElseIf cmbsucursal.Text = "Tegucigalpa" Then
            _gridInventarios.Columns("UBICACION TEGUS").Visible = True
        End If

    End Sub

    Private Sub cmbTbusqueda_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTbusqueda.SelectedIndexChanged
        If cmbTbusqueda.SelectedItem = "TODOS" Then
            txtCodigo.Enabled = False
            txtCodigo.Visible = False
            txtCodigo.Text = ""
        Else
            txtCodigo.Enabled = True
            txtCodigo.Visible = True
            txtCodigo.Text = ""
        End If
    End Sub

    Private Sub ExportarAExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportarAExcelToolStripMenuItem.Click
        Paste()
    End Sub


    Sub Paste()
        Try
            Dim sData As String = ""
            Dim filePath As String
            filePath = My.Computer.FileSystem.SpecialDirectories.Desktop

            For col As Integer = 0 To _gridInventarios.Columns.Count - 1
                If cmbsucursal.Text = "SRC" And (col = 12) Then
                    col = col + 1
                ElseIf (cmbsucursal.Text = "SRC") And (col = 16 Or col = 17 Or col = 19) Then
                    '    'Nada src'
                ElseIf (cmbsucursal.Text = "SPS") And (col = 11 Or col = 13 Or col = 16 Or col = 17 Or col = 18) Then
                    '    'Nada Sps
                ElseIf (cmbsucursal.Text = "Saba") And (col = 11 Or col = 12 Or col = 16 Or col = 19 Or col = 18) Then
                    '    'Nada Saba
                ElseIf (cmbsucursal.Text = "Tegucigalpa") And (col = 11 Or col = 12 Or col = 13 Or col = 17 Or col = 18 Or col = 19) Then
                    '    'Nada Saba
                Else
                    sData += _gridInventarios.Columns.Item(col).Name & vbTab
                End If
                If col = _gridInventarios.Columns.Count - 1 Then
                    sData += vbCr
                End If
            Next
            For index As Integer = 0 To _gridInventarios.Rows.Count - 1

                For col2 As Integer = 0 To _gridInventarios.Columns.Count - 1
                    If cmbsucursal.Text = "SRC" And (col2 = 12) Then
                        col2 = col2 + 1
                    ElseIf (cmbsucursal.Text = "SRC") And (col2 = 16 Or col2 = 17 Or col2 = 19) Then
                        '    'Nada src'
                    ElseIf (cmbsucursal.Text = "SPS") And (col2 = 11 Or col2 = 13 Or col2 = 16 Or col2 = 17 Or col2 = 18) Then
                        '    'Nada Sps
                    ElseIf (cmbsucursal.Text = "Saba") And (col2 = 11 Or col2 = 12 Or col2 = 16 Or col2 = 19 Or col2 = 18) Then
                        '    'Nada Saba
                    ElseIf (cmbsucursal.Text = "Tegucigalpa") And (col2 = 11 Or col2 = 12 Or col2 = 13 Or col2 = 17 Or col2 = 18 Or col2 = 19) Then
                        '    'Nada Saba
                    Else
                        sData += _gridInventarios.Rows(index).Cells(col2).Value & vbTab
                    End If
                Next
                sData += vbCr
            Next

            Clipboard.Clear()
            Clipboard.SetText(sData)
            Dim oExcel As Object
            Dim oBook As Object
            oExcel = CreateObject("Excel.Application")
            oBook = oExcel.Workbooks.Add
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            Dim sFile As String = filePath & "\Inventario" & cmbsucursal.Text.ToString & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls"

            wSheet = oBook.Worksheets(1)

            wSheet.Range("A2").Select()
            wSheet.Paste()

            wSheet.Paste()
            wSheet.Cells.Range("A3:A10000").NumberFormat = "@"

            Clipboard.Clear()
            'Save the Workbook and Quit Excel
            oBook.SaveAs(sFile)
            oExcel.Quit()
            MsgBox("Docuemnto exportado en escritorio")
            'oExcel.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Inventarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbsucursal.SelectedItem = "SPS"
        cmbTbusqueda.SelectedItem = "TODOS"
    End Sub

    Private Sub CerrarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        _btnGenerar.PerformClick()
    End Sub


End Class