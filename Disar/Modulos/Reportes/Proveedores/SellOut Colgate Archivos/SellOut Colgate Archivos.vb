Imports Disar.data
Imports System
Imports System.IO
Public Class SellOut_Colgate_Archivos
    Dim CLASE As New clsColgate

    Private Sub SellOut_Colgate_Archivos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        inicializardate()
        Me.MdiParent = _Inicio
    End Sub

    Sub inicializardate()
        _cmbF1.Value = 1 & "/" & Now.Month & "/" & Now.Year
        If Now.Day = 1 Then
            _cmbF2.Value = Today
        Else
            _cmbF2.Value = DateAdd(DateInterval.Day, -1, Now)
        End If
    End Sub

    Sub exportarTXTCHAIN()
        Dim sFile As String = Ruta.Text & "\Chain4.txt"
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)
            With _gridChain4
                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub exportarTXTSALETEAM()
        Dim sFile As String = Ruta.Text & "\SaleTeam4.txt"
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)
            With _gridSalesTeam
                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value 
                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub exportarTXTROUTMAST()
        Dim sFile As String = Ruta.Text & "\RoutMast4.txt"
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)
            With _gridRoutmast4
                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value & vbTab & _
                            .Rows(i).Cells(4).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub exportarTXTCUSTMAST()
        Dim sFile As String = Ruta.Text & "\CustMast4.txt"
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)
            With _gridCustMast
                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value & vbTab & _
                            .Rows(i).Cells(4).Value & vbTab & _
                            .Rows(i).Cells(5).Value & vbTab & _
                            .Rows(i).Cells(6).Value & vbTab & _
                            .Rows(i).Cells(7).Value
                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub exportarTXTSALES()
        Dim sFile As String = Ruta.Text & "\Sales4.txt"
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)
            With _gridSales
                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value & vbTab & _
                            .Rows(i).Cells(4).Value & vbTab & _
                            .Rows(i).Cells(5).Value & vbTab & _
                            .Rows(i).Cells(6).Value & vbTab & _
                            .Rows(i).Cells(7).Value & vbTab & _
                            .Rows(i).Cells(8).Value & vbTab & _
                            .Rows(i).Cells(9).Value & vbTab & _
                            .Rows(i).Cells(10).Value

                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub exportarTXTDISTEFFE()
        Dim sFile As String = Ruta.Text & "\Disteffe4.txt"
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)
            With _gridDisteffe
                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value & vbTab & _
                            .Rows(i).Cells(4).Value & vbTab & _
                            .Rows(i).Cells(5).Value & vbTab & _
                            .Rows(i).Cells(6).Value & vbTab & _
                            .Rows(i).Cells(7).Value & vbTab & _
                            .Rows(i).Cells(8).Value & vbTab & _
                            .Rows(i).Cells(9).Value & vbTab & _
                            .Rows(i).Cells(10).Value & vbTab & _
                            .Rows(i).Cells(11).Value & vbTab & _
                            .Rows(i).Cells(12).Value

                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub exportarTXTINVENTRY()
        Dim sFile As String = Ruta.Text & "\Inventry4.txt"
        Dim _Line As String = Nothing
        Try
            If File.Exists(sFile) = True Then
                My.Computer.FileSystem.DeleteFile(sFile, FileIO.UIOption.OnlyErrorDialogs, _
                                                  FileIO.RecycleOption.DeletePermanently, FileIO.UICancelOption.DoNothing)
            End If
            Dim swFile As StreamWriter = New StreamWriter(sFile)
            With _gridInventry
                For i = 0 To .RowCount - 1
                    _Line = .Rows(i).Cells(0).Value & vbTab & _
                            .Rows(i).Cells(1).Value & vbTab & _
                            .Rows(i).Cells(2).Value & vbTab & _
                            .Rows(i).Cells(3).Value & vbTab & _
                            .Rows(i).Cells(4).Value & vbTab & _
                            .Rows(i).Cells(5).Value & vbTab & _
                            .Rows(i).Cells(6).Value & vbTab & _
                            .Rows(i).Cells(7).Value & vbTab & _
                            .Rows(i).Cells(8).Value & vbTab & _
                            .Rows(i).Cells(9).Value & vbTab & _
                            .Rows(i).Cells(10).Value & vbTab & _
                            .Rows(i).Cells(11).Value & vbTab & _
                            .Rows(i).Cells(12).Value & vbTab & _
                            .Rows(i).Cells(13).Value & vbTab & _
                            .Rows(i).Cells(14).Value & vbTab & _
                            .Rows(i).Cells(15).Value & vbTab & _
                            .Rows(i).Cells(16).Value & vbTab & _
                            .Rows(i).Cells(17).Value & vbTab & _
                            .Rows(i).Cells(18).Value

                    swFile.WriteLine(_Line)
                Next
            End With
            swFile.Close()
        Catch ex As Exception
            MessageBox.Show("Error" + ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDestino_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDestino.Click
        Try
            With BuscarCarpeta
                .Reset()
                .Description = " Seleccionar una carpeta "
                .SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                Dim ret As DialogResult = .ShowDialog
                If ret = Windows.Forms.DialogResult.OK Then
                    Ruta.Text = .SelectedPath
                End If
            End With
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Try
            _gridChain4.DataSource = CLASE.Chain4
            MsgBox("Chain Generado")
            _gridSalesTeam.DataSource = CLASE.SaleTeam
            MsgBox("SaleTeam Generado")
            _gridRoutmast4.DataSource = CLASE.Routmast4
            MsgBox("RoutMast Generado")
            _gridCustMast.DataSource = CLASE.CustMast
            MsgBox("CustMast Generado")
            _gridSales.DataSource = CLASE.Sales(_cmbF1.Value.Date, _cmbF2.Value.Date)
            MsgBox("Sales Generado")
            _gridInventry.DataSource = CLASE.Inventry(_cmbF1.Value.Date, _cmbF2.Value.Date)
            MsgBox("Inventry Generado")
            _gridDisteffe.DataSource = CLASE.Disteffe(_cmbF1.Value.Date, _cmbF2.Value.Date)
            MsgBox("Disteffe Generado")
            exportarTXTSALES()
            exportarTXTCHAIN()
            exportarTXTSALETEAM()
            exportarTXTROUTMAST()
            exportarTXTCUSTMAST()
            exportarTXTINVENTRY()
            exportarTXTDISTEFFE()


            MessageBox.Show("Archivos Generados", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Process.Start("explorer.exe", Ruta.Text)
        Catch ex As Exception
            MsgBox("Error" + ex.ToString, MsgBoxStyle.Critical, AcceptButton)
        End Try
    End Sub

     

End Class