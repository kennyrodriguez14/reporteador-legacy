Imports Disar.data

Public Class FrmDocumentosFiscales

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMostrar.Click
        If ComboDocumento.Text = "Facturas" Then
            Try
                Dim db As New ClsDocumentos
                DataDatos.DataSource = db.Facturas
            Catch ex As Exception
            End Try
        End If
        If ComboDocumento.Text = "Devoluciones" Then
            Try
                Dim db As New ClsDocumentos
                DataDatos.DataSource = db.Devoluciones
            Catch ex As Exception
            End Try
        End If
        If ComboDocumento.Text = "Compras" Then
            Try
                Dim db As New ClsDocumentos
                DataDatos.DataSource = db.Compras
            Catch ex As Exception
            End Try
        End If
        If ComboDocumento.Text = "Devoluciones de Compra" Then
            Try
                Dim db As New ClsDocumentos
                DataDatos.DataSource = db.DevolucionesCompra
            Catch ex As Exception
            End Try
        End If
        If ComboDocumento.Text = "Remisiones" Then
            Try
                Dim db As New ClsDocumentos
                DataDatos.DataSource = db.Remisiones
            Catch ex As Exception
            End Try
        End If

    End Sub

    Private Sub BtnEditar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEditar.Click

        If ComboDocumento.Text <> "Remisiones" Then
            FrmModificacionDocumentos.TextEmpresa.Text = DataDatos.CurrentRow.Cells(0).Value
            FrmModificacionDocumentos.TextTipo.Text = DataDatos.CurrentRow.Cells(1).Value
            FrmModificacionDocumentos.TextSerie.Text = DataDatos.CurrentRow.Cells(2).Value
            If Not IsDBNull(DataDatos.CurrentRow.Cells(6).Value) Then
                FrmModificacionDocumentos.TextDesde.Text = DataDatos.CurrentRow.Cells(6).Value
            End If
            If Not IsDBNull(DataDatos.CurrentRow.Cells(7).Value) Then
                FrmModificacionDocumentos.TextHasta.Text = DataDatos.CurrentRow.Cells(7).Value
            End If
            If Not IsDBNull(DataDatos.CurrentRow.Cells("CAI").Value) Then
                FrmModificacionDocumentos.TextCAI.Text = DataDatos.CurrentRow.Cells("CAI").Value
            End If
            If Not IsDBNull(DataDatos.CurrentRow.Cells("Almacen").Value) Then
                FrmModificacionDocumentos.TextAlmacen.Text = DataDatos.CurrentRow.Cells("Almacen").Value
            End If
            If Not IsDBNull(DataDatos.CurrentRow.Cells("Cantidad Solicitada").Value) Then
                FrmModificacionDocumentos.TextSolicitada.Text = DataDatos.CurrentRow.Cells("Cantidad Solicitada").Value
            End If
            If Not IsDBNull(DataDatos.CurrentRow.Cells("Cantidad Otorgada").Value) Then
                FrmModificacionDocumentos.TextOtorgada.Text = DataDatos.CurrentRow.Cells("Cantidad Otorgada").Value
            End If
            If Not IsDBNull(DataDatos.CurrentRow.Cells("Fecha de Recepción").Value) Then
                FrmModificacionDocumentos.DtRecepcion.Value = DataDatos.CurrentRow.Cells("Fecha de Recepción").Value
            End If
            If Not IsDBNull(DataDatos.CurrentRow.Cells("Fecha Límite de Emisión").Value) Then
                FrmModificacionDocumentos.DtLimiteImpresion.Value = DataDatos.CurrentRow.Cells("Fecha Límite de Emisión").Value
            End If
            FrmModificacionDocumentos.ShowDialog()
        Else
            FrmModificacionDocRemisiones.TextEmpresa.Text = DataDatos.CurrentRow.Cells(1).Value

            If Not IsDBNull(DataDatos.CurrentRow.Cells(4).Value) Then
                FrmModificacionDocRemisiones.TextDesde.Text = DataDatos.CurrentRow.Cells(4).Value
            End If

            If Not IsDBNull(DataDatos.CurrentRow.Cells(3).Value) Then
                FrmModificacionDocRemisiones.TextCAI.Text = DataDatos.CurrentRow.Cells(3).Value
            End If

            If Not IsDBNull(DataDatos.CurrentRow.Cells(2).Value) Then
                FrmModificacionDocRemisiones.TextAlmacen.Text = DataDatos.CurrentRow.Cells(2).Value
            End If

            If Not IsDBNull(DataDatos.CurrentRow.Cells(5).Value) Then
                FrmModificacionDocRemisiones.DtLimiteImpresion.Value = DataDatos.CurrentRow.Cells(5).Value
            End If

            If Not IsDBNull(DataDatos.CurrentRow.Cells(6).Value) Then
                FrmModificacionDocRemisiones.TextSerie.Text = DataDatos.CurrentRow.Cells(6).Value
            End If

            FrmModificacionDocRemisiones.ShowDialog()
        End If
        
    End Sub

  
 
End Class