Imports Disar.data
Imports System.IO
Public Class frm_sell_out_general_proveedor
    Dim style As Microsoft.Office.Interop.Excel.Style
    Dim conexion As New cls_sell_out_general
    Private Sub frm_sell_out_general_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbEmpresa.Items.Clear()
            If _Inicio.SANRAFAEL = 1 Then
                cmbEmpresa.Items.Add("CONSUMO")
            End If
            If _Inicio.AGRO = 1 Then
                cmbEmpresa.Items.Add("SR AGRO")
            End If
            If _Inicio.DIMOSA = 1 Then
                cmbEmpresa.Items.Add("DIMOSA")
            End If
        Catch ex As Exception

        End Try
        cmbEmpresa.SelectedIndex = 0

        llenar_cmb()
    End Sub

    Sub llenar_cmb()
        If cmbEmpresa.Text = "CONSUMO" Then
            cmb_linea.DataSource = conexion.Llenar_cmb()
            cmb_linea.ValueMember = "ID"
            cmb_linea.DisplayMember = "PROVEEDOR"
        ElseIf cmbEmpresa.Text = "SR AGRO" Then
            cmb_linea.DataSource = conexion.Llenar_cmb_agro()
            cmb_linea.ValueMember = "ID"
            cmb_linea.DisplayMember = "PROVEEDOR"
        ElseIf cmbEmpresa.Text = "DIMOSA" Then
            cmb_linea.DataSource = conexion.Llenar_cmb_DIMOSA()
            cmb_linea.ValueMember = "ID"
            cmb_linea.DisplayMember = "PROVEEDOR"
        End If


    End Sub

    Private Sub _btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _btnGenerar.Click
        Try

            If cmbEmpresa.Text = "CONSUMO" Then
                GridGeneral.DataSource = conexion.getDatos_Costos(f1.Value.Date, f2.Value.Date, cmb_linea.SelectedValue)
            ElseIf cmbEmpresa.Text = "SR AGRO" Then
                GridGeneral.DataSource = conexion.getDatos_CostosSrAgro(f1.Value.Date, f2.Value.Date, cmb_linea.SelectedValue)
            ElseIf cmbEmpresa.Text = "DIMOSA" Then
                GridGeneral.DataSource = conexion.getDatos_CostosDimosa(f1.Value.Date, f2.Value.Date, cmb_linea.SelectedValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    Sub exportarTXT(ByVal Ruta As String)
        Dim sFile As String = Ruta & "\Sell_Out_General " & cmbEmpresa.Text.ToString & Now.Day & "-" & Now.Month & "-" & Now.Year & ".xls "
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile, True, System.Text.Encoding.Default)
            With GridGeneral
                For col As Integer = 0 To GridGeneral.Columns.Count - 1
                    _Line += .Columns(col).HeaderText & vbTab
                Next
                swFile.WriteLine(_Line)
                _Line = ""
                For lin As Integer = 0 To GridGeneral.Rows.Count - 1
                    For col As Integer = 0 To GridGeneral.Columns.Count - 1
                        _Line += .Rows(lin).Cells(col).Value & vbTab
                    Next
                    swFile.WriteLine(_Line)
                    _Line = ""
                Next
            End With
            swFile.Close()
            Process.Start(sFile)
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        frmGuardarArchivo.Formulario = "sell_proveedor"
        frmGuardarArchivo.MdiParent = _Inicio
        frmGuardarArchivo.Visible = True
    End Sub

    Private Sub cmbEmpresa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        llenar_cmb()
    End Sub
End Class