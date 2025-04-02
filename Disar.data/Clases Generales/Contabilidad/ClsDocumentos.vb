Imports System.Data.SqlClient
Imports System.Text

Public Class ClsDocumentos

    Dim Conexion As New clsconexion_consumo
    Dim Conexion2 As New clsConexion

    Public Function Facturas()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, dbo.FOLIOSF05.TIP_DOC, dbo.FOLIOSF05.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión', dbo.FOLIOSF05.AUTOANIO AS 'AÑO', dbo.FOLIOSF05.ULT_DOC AS 'ULTIMO DOCUMENTO', dbo.FOLIOSF05.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         dbo.FOLIOSF05 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = dbo.FOLIOSF05.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " dbo.FOLIOSF05.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (dbo.FOLIOSF05.TIP_DOC = 'F') AND (dbo.FOLIOSF05.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'San Rafael')" & _
                      " UNION ALL " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60EMPRE02.dbo.FOLIOSF02.TIP_DOC, SAE60EMPRE02.dbo.FOLIOSF02.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión', SAE60EMPRE02.dbo.FOLIOSF02.AUTOANIO AS 'AÑO', SAE60EMPRE02.dbo.FOLIOSF02.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre02.dbo.FOLIOSF02.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         SAE60EMPRE02.dbo.FOLIOSF02 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60EMPRE02.dbo.FOLIOSF02.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60EMPRE02.dbo.FOLIOSF02.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (SAE60EMPRE02.dbo.FOLIOSF02.TIP_DOC = 'F') AND (SAE60Empre02.dbo.FOLIOSF02.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'SR Agro')" & _
                      " UNION ALL " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60EMPRE06.dbo.FOLIOSF06.TIP_DOC, SAE60EMPRE06.dbo.FOLIOSF06.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión', SAE60EMPRE06.dbo.FOLIOSF06.AUTOANIO AS 'AÑO', SAE60EMPRE06.dbo.FOLIOSF06.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre06.dbo.FOLIOSF06.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         SAE60EMPRE06.dbo.FOLIOSF06 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60EMPRE06.dbo.FOLIOSF06.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60EMPRE06.dbo.FOLIOSF06.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (SAE60EMPRE06.dbo.FOLIOSF06.TIP_DOC = 'F') AND (SAE60Empre06.dbo.FOLIOSF06.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'DIMOSA')" & _
                      "", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function Devoluciones()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, dbo.FOLIOSF05.TIP_DOC, dbo.FOLIOSF05.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión', dbo.FOLIOSF05.AUTOANIO AS 'AÑO', dbo.FOLIOSF05.ULT_DOC AS 'ULTIMO DOCUMENTO', dbo.FOLIOSF05.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         dbo.FOLIOSF05 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = dbo.FOLIOSF05.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " dbo.FOLIOSF05.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (dbo.FOLIOSF05.TIP_DOC = 'D') AND (dbo.FOLIOSF05.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'San Rafael')" & _
                      " UNION ALL " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60EMPRE02.dbo.FOLIOSF02.TIP_DOC, SAE60EMPRE02.dbo.FOLIOSF02.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión', SAE60EMPRE02.dbo.FOLIOSF02.AUTOANIO AS 'AÑO', SAE60EMPRE02.dbo.FOLIOSF02.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre02.dbo.FOLIOSF02.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         SAE60EMPRE02.dbo.FOLIOSF02 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60EMPRE02.dbo.FOLIOSF02.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60EMPRE02.dbo.FOLIOSF02.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE (SAE60EMPRE02.dbo.FOLIOSF02.TIP_DOC = 'D') AND (SAE60EMPRE02.dbo.FOLIOSF02.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'SR AGRO')" & _
                      " UNION ALL " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60EMPRE06.dbo.FOLIOSF06.TIP_DOC, SAE60EMPRE06.dbo.FOLIOSF06.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión', SAE60EMPRE06.dbo.FOLIOSF06.AUTOANIO AS 'AÑO', SAE60EMPRE06.dbo.FOLIOSF06.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre06.dbo.FOLIOSF06.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         SAE60EMPRE06.dbo.FOLIOSF06 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60EMPRE06.dbo.FOLIOSF06.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60EMPRE06.dbo.FOLIOSF06.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE (SAE60EMPRE06.dbo.FOLIOSF06.TIP_DOC = 'D') AND (SAE60EMPRE06.dbo.FOLIOSF06.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'SR AGRO')" & _
"", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function Compras()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, dbo.FOLIOSC05.TIP_DOC, dbo.FOLIOSC05.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión',  dbo.FOLIOSC05.ULT_DOC AS 'ULTIMO DOCUMENTO', dbo.FOLIOSC05.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         dbo.FOLIOSC05 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = dbo.FOLIOSC05.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " dbo.FOLIOSC05.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (dbo.FOLIOSC05.TIP_DOC = 'c') AND (dbo.FOLIOSC05.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'San Rafael')" & _
                      " UNION ALL " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60Empre02.dbo.FOLIOSC02.TIP_DOC, SAE60Empre02.dbo.FOLIOSC02.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión',  SAE60Empre02.dbo.FOLIOSC02.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre02.dbo.FOLIOSC02.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM  SAE60Empre02.dbo.FOLIOSC02 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60Empre02.dbo.FOLIOSC02.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60Empre02.dbo.FOLIOSC02.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (SAE60Empre02.dbo.FOLIOSC02.TIP_DOC = 'c') AND (SAE60Empre02.dbo.FOLIOSC02.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'SR Agro') " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60Empre06.dbo.FOLIOSC06.TIP_DOC, SAE60Empre06.dbo.FOLIOSC06.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión',  SAE60Empre06.dbo.FOLIOSC06.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre06.dbo.FOLIOSC06.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM  SAE60Empre06.dbo.FOLIOSC06 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60Empre06.dbo.FOLIOSC06.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60Empre06.dbo.FOLIOSC06.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (SAE60Empre06.dbo.FOLIOSC06.TIP_DOC = 'c') AND (SAE60Empre06.dbo.FOLIOSC06.STATUS <> 'B') AND (Usuarios.dbo.Documentos.Empresa = 'SR Agro') " & _
                      "", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function DevolucionesCompra()
        Dim ActualizarConexion As New SqlConnection(Conexion.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, dbo.FOLIOSC05.TIP_DOC, dbo.FOLIOSC05.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión',  dbo.FOLIOSC05.ULT_DOC AS 'ULTIMO DOCUMENTO', dbo.FOLIOSC05.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM         dbo.FOLIOSC05 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = dbo.FOLIOSC05.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " dbo.FOLIOSC05.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (dbo.FOLIOSC05.TIP_DOC = 'd') AND (dbo.FOLIOSC05.STATUS <> 'B')" & _
                      " UNION ALL " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60Empre02.dbo.FOLIOSC02.TIP_DOC, SAE60Empre02.dbo.FOLIOSC02.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión',  SAE60Empre02.dbo.FOLIOSC02.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre02.dbo.FOLIOSC02.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM SAE60Empre02.dbo.FOLIOSC02 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60Empre02.dbo.FOLIOSC02.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60Empre02.dbo.FOLIOSC02.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (SAE60Empre02.dbo.FOLIOSC02.TIP_DOC = 'd') AND (SAE60Empre02.dbo.FOLIOSC02.STATUS <> 'B')" & _
                      " UNION ALL " & _
                      " SELECT     Usuarios.dbo.Documentos.Empresa as Empresa, SAE60Empre06.dbo.FOLIOSC06.TIP_DOC, SAE60Empre06.dbo.FOLIOSC06.SERIE, Usuarios.dbo.Documentos.Almacen, Usuarios.dbo.Documentos.CantSolicitada as 'Cantidad Solicitada', Usuarios.dbo.Documentos.CantOtorgada as 'Cantidad Otorgada', " & _
                      " ISNULL(Usuarios.dbo.Documentos.Desde, '') AS DESDE, ISNULL(Usuarios.dbo.Documentos.Hasta, '') AS HASTA, " & _
                      " Usuarios.dbo.Documentos.FechaRecepcion as 'Fecha de Recepción', Usuarios.dbo.Documentos.FechaLimiteEmision as 'Fecha Límite de Emisión',  SAE60Empre06.dbo.FOLIOSC06.ULT_DOC AS 'ULTIMO DOCUMENTO', SAE60Empre06.dbo.FOLIOSC06.FECH_ULT_DOC AS 'FECHA ULTIMO REGISTRO', " & _
                      " ISNULL(Usuarios.dbo.Documentos.CAI, '') AS CAI, ISNULL(Usuarios.dbo.Documentos.Rtn, '') AS RTN, ISNULL(Usuarios.dbo.Documentos.DocumentoFiscal, '') AS 'DOCUMENTO FISCAL',ISNULL(Usuarios.dbo.Documentos.PuntoEmision, '') AS 'PUNTO EMISION' FROM SAE60Empre06.dbo.FOLIOSC06 INNER JOIN " & _
                      " Usuarios.dbo.Documentos ON Usuarios.dbo.Documentos.Serie = SAE60Empre06.dbo.FOLIOSC06.SERIE COLLATE MODERN_SPANISH_CI_AS AND " & _
                      " SAE60Empre06.dbo.FOLIOSC06.TIP_DOC = Usuarios.dbo.Documentos.Tipo COLLATE Latin1_General_BIN WHERE     (SAE60Empre06.dbo.FOLIOSC06.TIP_DOC = 'd') AND (SAE60Empre06.dbo.FOLIOSC06.STATUS <> 'B')" & _
                      "", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function Remisiones()
        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())

        Dim miComando As New SqlCommand(" SELECT  dbo.GUIA_REMISION_SUCURSAL.DESCRIPCION, dbo.GUIA_REMISION_SUCURSAL.EMPRESA, dbo.GUIA_REMISION_SUCURSAL.NUM_ALMA AS ALMACEN, " & _
                      " dbo.GUIA_REMISION_SUCURSAL.CAI, dbo.GUIA_REMISION_SUCURSAL.RANGO, dbo.GUIA_REMISION_SUCURSAL.FECHA_LIMITE AS 'FECHA LIMITE', " & _
                      " dbo.GUIA_REMISION_CORRELATIVOS_SANRAFAEL.SERIE, dbo.GUIA_REMISION_CORRELATIVOS_SANRAFAEL.ULT_DOC AS 'ULTIMO DOCUMENTO', GUIA_REMISION_SUCURSAL.RTN, ISNULL(GUIA_REMISION_SUCURSAL.DOCUMENTOFISCAL, '') AS 'DOCUMENTO FISCAL',ISNULL(GUIA_REMISION_SUCURSAL.PUNTOEMISION, '') AS 'PUNTO EMISION' " & _
                      " FROM         dbo.GUIA_REMISION_CORRELATIVOS_SANRAFAEL INNER JOIN " & _
                      " dbo.GUIA_REMISION_SUCURSAL ON dbo.GUIA_REMISION_CORRELATIVOS_SANRAFAEL.REMITE_ID = dbo.GUIA_REMISION_SUCURSAL.SUCURSAL_ID", ActualizarConexion)
        ActualizarConexion.Open()
        Dim AdaptadorDeDatos As New SqlDataAdapter(miComando)
        Dim dt As New DataTable
        Try
            AdaptadorDeDatos.Fill(dt)
            ActualizarConexion.Close()
        Catch ex As SqlException
            MsgBox("Hay un problema con la conexión a los datos " & ex.Message, MsgBoxStyle.Critical)
            ActualizarConexion.Close()
        End Try
        Return dt
    End Function

    Public Function ModificaDoc(ByVal Tipo As String, ByVal Serie As String, ByVal Desde As String, ByVal Hasta As String, ByVal CAI As String, ByVal CantSol As Integer, ByVal CantRec As Integer, ByVal Almacen As String, ByVal Fecha1 As Date, ByVal fecha2 As Date, ByVal Empresa As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            miComando = New SqlCommand(" UPDATE dbo.Documentos " & _
            " SET Desde = @Desde, Hasta = @Hasta, CAI = @CAI, CantSolicitada = @CantSolicitada, CantOtorgada = @CantOtorgada, FechaRecepcion = @FechaRecepcion, FechaLimiteEmision = @FechaLimiteEmision, Almacen = @Almacen" & _
            " WHERE (Serie = @Serie) AND (Tipo = @Tipo) AND (Empresa = @Empresa)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Desde", Desde)
            miComando.Parameters.AddWithValue("@Hasta", Hasta)
            miComando.Parameters.AddWithValue("@CAI", CAI)
            miComando.Parameters.AddWithValue("@Serie", Serie)
            miComando.Parameters.AddWithValue("@Tipo", Tipo)
            miComando.Parameters.AddWithValue("@CantSolicitada", CantSol)
            miComando.Parameters.AddWithValue("@CantOtorgada", CantRec)

            miComando.Parameters.AddWithValue("@FechaRecepcion", Fecha1.Date)
            miComando.Parameters.AddWithValue("@FechaLimiteEmision", fecha2.Date)
            miComando.Parameters.AddWithValue("@Almacen", Almacen)
            miComando.Parameters.AddWithValue("@Empresa", Empresa)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "s"
        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

    Public Function ModificaRemision(ByVal Rango As String, ByVal CAI As String, ByVal Almacen As String, ByVal Fecha1 As Date, ByVal fecha2 As Date, ByVal Empresa As String)

        Dim ActualizarConexion As New SqlConnection(Conexion2.CadenaSQL())
        Dim transaccion_sql As SqlTransaction

        ActualizarConexion.Open()
        transaccion_sql = ActualizarConexion.BeginTransaction

        Try
            Dim miComando As New SqlCommand
            'Guarda nueva marca
            miComando = New SqlCommand(" UPDATE dbo.GUIA_REMISION_SUCURSAL " & _
            " SET Rango = @Rango, CAI = @CAI, FECHA_LIMITE = @Fecha_Limite, " & _
            " WHERE  (Empresa = @Empresa) AND (NUM_ALMA = @Almacen)", ActualizarConexion)

            miComando.Parameters.AddWithValue("@Rango", Rango)
            miComando.Parameters.AddWithValue("@CAI", CAI)
            miComando.Parameters.AddWithValue("@FECHA_LIMITE", Fecha1)
            miComando.Parameters.AddWithValue("@Empresa", Empresa)
            miComando.Parameters.AddWithValue("@Almacen", Almacen)

            miComando.Transaction = transaccion_sql
            miComando.ExecuteNonQuery()

            transaccion_sql.Commit()
            ActualizarConexion.Close()
            Return "s"
        Catch ex As Exception
            transaccion_sql.Rollback()
            ActualizarConexion.Close()
            Dim tamaño As Integer = Convert.ToString(ex.StackTrace).Length
            Dim posicion As Integer = InStrRev(Convert.ToString(ex.StackTrace), "línea") - 1
            Dim inicial As Integer = tamaño - posicion
            Dim linea_error As String = Convert.ToString(ex.StackTrace).Substring(tamaño - inicial, inicial)
            Return "Error: " & ex.Message & " " & linea_error
        End Try

    End Function

End Class


