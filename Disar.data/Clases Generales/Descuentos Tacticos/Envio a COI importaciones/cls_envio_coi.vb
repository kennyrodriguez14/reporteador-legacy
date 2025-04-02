Imports System.Data.SqlClient
Imports System.Text

Public Class cls_envio_coi
    Dim cadena_conexion As New clsconexion_coi_consumo
    Dim cadena_conexion_dimosa As New clsconexion_coi_dimosa

    Public Function enviar_coi(ByVal dt_cuentas_poliza As DataTable, ByVal nyear As Integer, ByVal nmes As Integer, ByVal fecha As DateTime, _
                               ByVal tipo_poliza As String, ByVal fecha_ini As Date, ByVal fecha_fin As Date, _
                               ByVal concepto As String, ByVal empresa As String, ByVal proveedor As String, _
                               ByVal clave_reporteador As String)

        Dim conexion As New SqlConnection
        conexion = New SqlConnection(cadena_conexion.CadenaSQL)

        conexion.Open()
        Dim transaccion_sql = conexion.BeginTransaction()

        Dim year_short As Integer
        year_short = Convert.ToInt32((DateTime.Now.Year.ToString()).Substring(2, 2))

        Try
            Dim cero As String = ""
            If (nmes.ToString().Length < 2) Then
                cero = "0"
            End If

            'seleccionar el num de poliza
            Dim num_poliz As String = ""
            Dim qx_num_pol = New StringBuilder()
            qx_num_pol.Append("SELECT [FOLIO" + cero + nmes.ToString + "] ")
            qx_num_pol.Append(" FROM FOLIOS" + empresa + " ")
            qx_num_pol.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_num_pol = New SqlCommand(qx_num_pol.ToString(), conexion)
            cmd_num_pol.Transaction = transaccion_sql
            cmd_num_pol.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_num_pol.Parameters.AddWithValue("@EJERCICIO", nyear)
            Dim adaptador_num_pol = New SqlDataAdapter(cmd_num_pol)
            Dim dt_num_pol = New DataTable()
            adaptador_num_pol.Fill(dt_num_pol)

            num_poliz = Convert.ToString(Convert.ToInt32(dt_num_pol.Rows(0)(0)) + 1)

            Dim espacios As String = ""
            For i = 0 To 5 - num_poliz.Length - 1
                espacios += " "
            Next
            num_poliz = espacios + num_poliz

            'encabezado de la poliza
            Dim qx_polizas = New StringBuilder()
            qx_polizas.Append("INSERT INTO [COI70Empre" + empresa + "].[dbo].[POLIZAS" + year_short.ToString + empresa + "] ")
            qx_polizas.Append("([TIPO_POLI],[NUM_POLIZ],[PERIODO],[EJERCICIO],[FECHA_POL],[CONCEP_PO] ")
            qx_polizas.Append(",[NUM_PART],[LOGAUDITA],[CONTABILIZ],[NUMPARCUA],[TIENEDOCUMENTOS] ")
            qx_polizas.Append(",[PROCCONTAB],[ORIGEN],[UUID],[ESPOLIZAPRIVADA]) ")
            qx_polizas.Append("VALUES ")
            qx_polizas.Append("(@TIPO_POLI,@NUM_POLIZ,@PERIODO,@EJERCICIO,@FECHA_POL,@CONCEP_PO,@NUM_PART ")
            qx_polizas.Append(",@LOGAUDITA,@CONTABILIZ,@NUMPARCUA,@TIENEDOCUMENTOS,@PROCCONTAB,@ORIGEN ")
            qx_polizas.Append(",@UUID,@ESPOLIZAPRIVADA) ")
            Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), conexion)
            cmd_polizas.Transaction = transaccion_sql
            cmd_polizas.Parameters.AddWithValue("TIPO_POLI", tipo_poliza)
            cmd_polizas.Parameters.AddWithValue("NUM_POLIZ", num_poliz)
            cmd_polizas.Parameters.AddWithValue("PERIODO", nmes)
            cmd_polizas.Parameters.AddWithValue("EJERCICIO", nyear)
            cmd_polizas.Parameters.AddWithValue("FECHA_POL", fecha.Date)

            cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", concepto + proveedor)

            cmd_polizas.Parameters.AddWithValue("NUM_PART", dt_cuentas_poliza.Rows.Count)
            cmd_polizas.Parameters.AddWithValue("LOGAUDITA", "N")
            cmd_polizas.Parameters.AddWithValue("CONTABILIZ", "S")
            cmd_polizas.Parameters.AddWithValue("NUMPARCUA", 0)
            cmd_polizas.Parameters.AddWithValue("TIENEDOCUMENTOS", 0)
            cmd_polizas.Parameters.AddWithValue("PROCCONTAB", 0)
            cmd_polizas.Parameters.AddWithValue("ORIGEN", "CC COI")
            cmd_polizas.Parameters.AddWithValue("UUID", "")
            cmd_polizas.Parameters.AddWithValue("ESPOLIZAPRIVADA", 0)
            cmd_polizas.ExecuteNonQuery()

            'recorrer todas las cuentas que se agregaran a la poliza
            For index = 0 To dt_cuentas_poliza.Rows.Count - 1

                'seleccionar la cuenta base
                Dim qx_catalogo_cuentas = New StringBuilder()
                qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & empresa & " WHERE NUM_CTA = @CTA ")
                Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), conexion)
                cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_catalogo_cuentas.Transaction = transaccion_sql
                Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                Dim dt_catalogo_cuentas = New DataTable()
                adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                Dim cta_papa As String = ""
                If dt_catalogo_cuentas.Rows.Count > 0 Then
                    cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                    Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                    cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                    cuentas_afectadas(1) = cta_papa

                    'seleccionar la raiz de las cuentas que se afectan
                    For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                        Dim qx_cuenta_rel = New StringBuilder()
                        qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & empresa & " WHERE NUM_CTA = '" + cta_papa + "'")
                        Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), conexion)
                        cmd_cuenta_rel.Transaction = transaccion_sql
                        Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                        Dim dt_cuenta_rel = New DataTable()
                        adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                        Try
                            cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                            cuentas_afectadas(2 + i) = cta_papa
                        Catch ex As Exception

                        End Try
                    Next

                    Try
                        For i = 0 To cuentas_afectadas.Length - 1
                            Dim qx_actualiza_saldos = New StringBuilder()
                            qx_actualiza_saldos.Append(" UPDATE [COI70Empre" + empresa + "].[dbo].[SALDOS" & Convert.ToString(year_short) & empresa & "] ")

                            If dt_cuentas_poliza.Rows(index)(2) = "D" Then
                                qx_actualiza_saldos.Append("   SET [CARGO" + cero + nmes.ToString + "] = [CARGO" + cero + nmes.ToString + "] + @VALOR ")
                            ElseIf dt_cuentas_poliza.Rows(index)(2) = "H" Then
                                qx_actualiza_saldos.Append("   SET [ABONO" + cero + nmes.ToString + "] = [ABONO" + cero + nmes.ToString + "] + @VALOR ")
                            End If
                            qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                            Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), conexion)
                            cmd_actualiza_saldos.Transaction = transaccion_sql
                            cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                            cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
                            cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(dt_cuentas_poliza.Rows(index)(1)))
                            cmd_actualiza_saldos.ExecuteNonQuery()
                        Next
                    Catch ex As Exception

                    End Try
                    'actualizar saldos de las cuentas

                    'fin de catalogo de cuentas a afectar
                    'fin seleccion de cuentas raiz

                End If

                'partidas de la poliza
                Dim qx_auxiliares = New StringBuilder()
                qx_auxiliares.Append("INSERT INTO [COI70Empre" + empresa + "].[dbo].[AUXILIAR" + year_short.ToString + empresa + "] ")
                qx_auxiliares.Append("   ([TIPO_POLI],[NUM_POLIZ],[NUM_PART],[PERIODO],[EJERCICIO] ")
                qx_auxiliares.Append("   ,[NUM_CTA],[FECHA_POL],[CONCEP_PO],[DEBE_HABER],[MONTOMOV] ")
                qx_auxiliares.Append("   ,[NUMDEPTO],[TIPCAMBIO],[CONTRAPAR],[ORDEN],[CCOSTOS] ")
                qx_auxiliares.Append("   ,[CGRUPOS],[IDINFADIPAR],[IDUUID]) ")
                qx_auxiliares.Append("VALUES ")
                qx_auxiliares.Append("   (@TIPO_POLI, @NUM_POLIZ , @NUM_PART, @PERIODO, @EJERCICIO ")
                qx_auxiliares.Append("   , @NUM_CTA , @FECHA_POL, @CONCEP_PO, @DEBE_HABER,@MONTOMOV ")
                qx_auxiliares.Append("   , @NUMDEPTO, @TIPCAMBIO, @CONTRAPAR, @ORDEN, @CCOSTOS ")
                qx_auxiliares.Append("   ,@CGRUPOS,@IDINFADIPAR,@IDUUID)")
                Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), conexion)
                cmd_ins_auxiliares.Transaction = transaccion_sql
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", index + 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", fecha.Date)

                cmd_ins_auxiliares.Parameters.AddWithValue("@CONCEP_PO", concepto + proveedor)

                cmd_ins_auxiliares.Parameters.AddWithValue("@DEBE_HABER", dt_cuentas_poliza.Rows(index)(2))
                cmd_ins_auxiliares.Parameters.AddWithValue("@MONTOMOV", dt_cuentas_poliza.Rows(index)(1))
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUMDEPTO", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPCAMBIO", 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CONTRAPAR", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@ORDEN", 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CCOSTOS", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CGRUPOS", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@IDINFADIPAR", -1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@IDUUID", -1)
                cmd_ins_auxiliares.ExecuteNonQuery()
                ' fin partidas de la poliza
            Next

            Dim qx_upd_folios = New StringBuilder()
            qx_upd_folios.Append("UPDATE [COI70Empre" + empresa + "].[dbo].[FOLIOS" + empresa + "] ")
            qx_upd_folios.Append("SET [FOLIO" + cero + nmes.ToString + "] = [FOLIO" + cero + nmes.ToString + "] + 1 ")
            qx_upd_folios.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_upd_folios = New SqlCommand(qx_upd_folios.ToString(), conexion)
            cmd_upd_folios.Transaction = transaccion_sql
            cmd_upd_folios.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_upd_folios.Parameters.AddWithValue("@EJERCICIO", nyear)
            cmd_upd_folios.Transaction = transaccion_sql
            cmd_upd_folios.ExecuteNonQuery()

            transaccion_sql.Commit()
            conexion.Close()
            Return "correcto"
        Catch ex As Exception
            transaccion_sql.Rollback()
            conexion.Close()
            Return ex.Message
        End Try
    End Function

    Public Function enviar_coi_dimosa(ByVal dt_cuentas_poliza As DataTable, ByVal nyear As Integer, ByVal nmes As Integer, ByVal fecha As DateTime, _
                               ByVal tipo_poliza As String, ByVal fecha_ini As Date, ByVal fecha_fin As Date, _
                               ByVal concepto As String, ByVal empresa As String, ByVal proveedor As String, _
                               ByVal clave_reporteador As String)

        Dim conexion As New SqlConnection
        conexion = New SqlConnection(cadena_conexion_dimosa.CadenaSQL)

        conexion.Open()
        Dim transaccion_sql = conexion.BeginTransaction()

        Dim year_short As Integer
        year_short = Convert.ToInt32((DateTime.Now.Year.ToString()).Substring(2, 2))

        Try
            Dim cero As String = ""
            If (nmes.ToString().Length < 2) Then
                cero = "0"
            End If

            'seleccionar el num de poliza
            Dim num_poliz As String = ""
            Dim qx_num_pol = New StringBuilder()
            qx_num_pol.Append("SELECT [FOLIO" + cero + nmes.ToString + "] ")
            qx_num_pol.Append(" FROM FOLIOS" + empresa + " ")
            qx_num_pol.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_num_pol = New SqlCommand(qx_num_pol.ToString(), conexion)
            cmd_num_pol.Transaction = transaccion_sql
            cmd_num_pol.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_num_pol.Parameters.AddWithValue("@EJERCICIO", nyear)
            Dim adaptador_num_pol = New SqlDataAdapter(cmd_num_pol)
            Dim dt_num_pol = New DataTable()
            adaptador_num_pol.Fill(dt_num_pol)

            num_poliz = Convert.ToString(Convert.ToInt32(dt_num_pol.Rows(0)(0)) + 1)

            Dim espacios As String = ""
            For i = 0 To 5 - num_poliz.Length - 1
                espacios += " "
            Next
            num_poliz = espacios + num_poliz

            'encabezado de la poliza
            Dim qx_polizas = New StringBuilder()
            qx_polizas.Append("INSERT INTO [COI70Empre" + empresa + "].[dbo].[POLIZAS" + year_short.ToString + empresa + "] ")
            qx_polizas.Append("([TIPO_POLI],[NUM_POLIZ],[PERIODO],[EJERCICIO],[FECHA_POL],[CONCEP_PO] ")
            qx_polizas.Append(",[NUM_PART],[LOGAUDITA],[CONTABILIZ],[NUMPARCUA],[TIENEDOCUMENTOS] ")
            qx_polizas.Append(",[PROCCONTAB],[ORIGEN],[UUID],[ESPOLIZAPRIVADA]) ")
            qx_polizas.Append("VALUES ")
            qx_polizas.Append("(@TIPO_POLI,@NUM_POLIZ,@PERIODO,@EJERCICIO,@FECHA_POL,@CONCEP_PO,@NUM_PART ")
            qx_polizas.Append(",@LOGAUDITA,@CONTABILIZ,@NUMPARCUA,@TIENEDOCUMENTOS,@PROCCONTAB,@ORIGEN ")
            qx_polizas.Append(",@UUID,@ESPOLIZAPRIVADA) ")
            Dim cmd_polizas = New SqlCommand(qx_polizas.ToString(), conexion)
            cmd_polizas.Transaction = transaccion_sql
            cmd_polizas.Parameters.AddWithValue("TIPO_POLI", tipo_poliza)
            cmd_polizas.Parameters.AddWithValue("NUM_POLIZ", num_poliz)
            cmd_polizas.Parameters.AddWithValue("PERIODO", nmes)
            cmd_polizas.Parameters.AddWithValue("EJERCICIO", nyear)
            cmd_polizas.Parameters.AddWithValue("FECHA_POL", fecha.Date)

            cmd_polizas.Parameters.AddWithValue("@CONCEP_PO", concepto + proveedor)

            cmd_polizas.Parameters.AddWithValue("NUM_PART", dt_cuentas_poliza.Rows.Count)
            cmd_polizas.Parameters.AddWithValue("LOGAUDITA", "N")
            cmd_polizas.Parameters.AddWithValue("CONTABILIZ", "S")
            cmd_polizas.Parameters.AddWithValue("NUMPARCUA", 0)
            cmd_polizas.Parameters.AddWithValue("TIENEDOCUMENTOS", 0)
            cmd_polizas.Parameters.AddWithValue("PROCCONTAB", 0)
            cmd_polizas.Parameters.AddWithValue("ORIGEN", "CC COI")
            cmd_polizas.Parameters.AddWithValue("UUID", "")
            cmd_polizas.Parameters.AddWithValue("ESPOLIZAPRIVADA", 0)
            cmd_polizas.ExecuteNonQuery()

            'recorrer todas las cuentas que se agregaran a la poliza
            For index = 0 To dt_cuentas_poliza.Rows.Count - 1

                'seleccionar la cuenta base
                Dim qx_catalogo_cuentas = New StringBuilder()
                qx_catalogo_cuentas.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & empresa & " WHERE NUM_CTA = @CTA ")
                Dim cmd_catalogo_cuentas = New SqlCommand(qx_catalogo_cuentas.ToString(), conexion)
                cmd_catalogo_cuentas.Parameters.AddWithValue("@CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_catalogo_cuentas.Transaction = transaccion_sql
                Dim adaptador_catalogo_cuentas = New SqlDataAdapter(cmd_catalogo_cuentas)
                Dim dt_catalogo_cuentas = New DataTable()
                adaptador_catalogo_cuentas.Fill(dt_catalogo_cuentas)

                Dim cta_papa As String = ""
                If dt_catalogo_cuentas.Rows.Count > 0 Then
                    cta_papa = Convert.ToString(dt_catalogo_cuentas.Rows(0)(1))

                    Dim cuentas_afectadas(Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))) As String
                    cuentas_afectadas(0) = Convert.ToString(dt_catalogo_cuentas.Rows(0)(0))
                    cuentas_afectadas(1) = cta_papa

                    'seleccionar la raiz de las cuentas que se afectan
                    For i = 0 To Convert.ToInt32(dt_catalogo_cuentas.Rows(0)(2))
                        Dim qx_cuenta_rel = New StringBuilder()
                        qx_cuenta_rel.Append("SELECT NUM_CTA, CTA_PAPA, NIVEL FROM CUENTAS" & Convert.ToString(year_short) & empresa & " WHERE NUM_CTA = '" + cta_papa + "'")
                        Dim cmd_cuenta_rel = New SqlCommand(qx_cuenta_rel.ToString(), conexion)
                        cmd_cuenta_rel.Transaction = transaccion_sql
                        Dim adaptador_cuenta_rel = New SqlDataAdapter(cmd_cuenta_rel)
                        Dim dt_cuenta_rel = New DataTable()
                        adaptador_cuenta_rel.Fill(dt_cuenta_rel)
                        Try
                            cta_papa = Convert.ToString(dt_cuenta_rel.Rows(0)(1))
                            cuentas_afectadas(2 + i) = cta_papa
                        Catch ex As Exception

                        End Try
                    Next

                    Try
                        For i = 0 To cuentas_afectadas.Length - 1
                            Dim qx_actualiza_saldos = New StringBuilder()
                            qx_actualiza_saldos.Append(" UPDATE [COI70Empre" + empresa + "].[dbo].[SALDOS" & Convert.ToString(year_short) & empresa & "] ")

                            If dt_cuentas_poliza.Rows(index)(2) = "D" Then
                                qx_actualiza_saldos.Append("   SET [CARGO" + cero + nmes.ToString + "] = [CARGO" + cero + nmes.ToString + "] + @VALOR ")
                            ElseIf dt_cuentas_poliza.Rows(index)(2) = "H" Then
                                qx_actualiza_saldos.Append("   SET [ABONO" + cero + nmes.ToString + "] = [ABONO" + cero + nmes.ToString + "] + @VALOR ")
                            End If
                            qx_actualiza_saldos.Append(" WHERE [NUM_CTA] = @NUM_CTA AND [EJERCICIO] = @EJERCICIO ")
                            Dim cmd_actualiza_saldos = New SqlCommand(qx_actualiza_saldos.ToString(), conexion)
                            cmd_actualiza_saldos.Transaction = transaccion_sql
                            cmd_actualiza_saldos.Parameters.AddWithValue("@NUM_CTA", cuentas_afectadas(i))
                            cmd_actualiza_saldos.Parameters.AddWithValue("@EJERCICIO", nyear)
                            cmd_actualiza_saldos.Parameters.AddWithValue("@VALOR", Convert.ToDouble(dt_cuentas_poliza.Rows(index)(1)))
                            cmd_actualiza_saldos.ExecuteNonQuery()
                        Next
                    Catch ex As Exception

                    End Try
                    'actualizar saldos de las cuentas

                    'fin de catalogo de cuentas a afectar
                    'fin seleccion de cuentas raiz

                End If

                'partidas de la poliza
                Dim qx_auxiliares = New StringBuilder()
                qx_auxiliares.Append("INSERT INTO [COI70Empre" + empresa + "].[dbo].[AUXILIAR" + year_short.ToString + empresa + "] ")
                qx_auxiliares.Append("   ([TIPO_POLI],[NUM_POLIZ],[NUM_PART],[PERIODO],[EJERCICIO] ")
                qx_auxiliares.Append("   ,[NUM_CTA],[FECHA_POL],[CONCEP_PO],[DEBE_HABER],[MONTOMOV] ")
                qx_auxiliares.Append("   ,[NUMDEPTO],[TIPCAMBIO],[CONTRAPAR],[ORDEN],[CCOSTOS] ")
                qx_auxiliares.Append("   ,[CGRUPOS],[IDINFADIPAR],[IDUUID]) ")
                qx_auxiliares.Append("VALUES ")
                qx_auxiliares.Append("   (@TIPO_POLI, @NUM_POLIZ , @NUM_PART, @PERIODO, @EJERCICIO ")
                qx_auxiliares.Append("   , @NUM_CTA , @FECHA_POL, @CONCEP_PO, @DEBE_HABER,@MONTOMOV ")
                qx_auxiliares.Append("   , @NUMDEPTO, @TIPCAMBIO, @CONTRAPAR, @ORDEN, @CCOSTOS ")
                qx_auxiliares.Append("   ,@CGRUPOS,@IDINFADIPAR,@IDUUID)")
                Dim cmd_ins_auxiliares = New SqlCommand(qx_auxiliares.ToString(), conexion)
                cmd_ins_auxiliares.Transaction = transaccion_sql
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_POLIZ", num_poliz)
                cmd_ins_auxiliares.Parameters.AddWithValue("@EJERCICIO", nyear)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_PART", index + 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@PERIODO", nmes)
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUM_CTA", dt_cuentas_poliza.Rows(index)(0))
                cmd_ins_auxiliares.Parameters.AddWithValue("@FECHA_POL", fecha.Date)

                cmd_ins_auxiliares.Parameters.AddWithValue("@CONCEP_PO", concepto + proveedor)

                cmd_ins_auxiliares.Parameters.AddWithValue("@DEBE_HABER", dt_cuentas_poliza.Rows(index)(2))
                cmd_ins_auxiliares.Parameters.AddWithValue("@MONTOMOV", dt_cuentas_poliza.Rows(index)(1))
                cmd_ins_auxiliares.Parameters.AddWithValue("@NUMDEPTO", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@TIPCAMBIO", 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CONTRAPAR", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@ORDEN", 1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CCOSTOS", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@CGRUPOS", 0)
                cmd_ins_auxiliares.Parameters.AddWithValue("@IDINFADIPAR", -1)
                cmd_ins_auxiliares.Parameters.AddWithValue("@IDUUID", -1)
                cmd_ins_auxiliares.ExecuteNonQuery()
                ' fin partidas de la poliza
            Next

            Dim qx_upd_folios = New StringBuilder()
            qx_upd_folios.Append("UPDATE [COI70Empre" + empresa + "].[dbo].[FOLIOS" + empresa + "] ")
            qx_upd_folios.Append("SET [FOLIO" + cero + nmes.ToString + "] = [FOLIO" + cero + nmes.ToString + "] + 1 ")
            qx_upd_folios.Append(" WHERE (TIPPOL = @TIPO_POLI) AND (EJERCICIO = @EJERCICIO) ")
            Dim cmd_upd_folios = New SqlCommand(qx_upd_folios.ToString(), conexion)
            cmd_upd_folios.Transaction = transaccion_sql
            cmd_upd_folios.Parameters.AddWithValue("@TIPO_POLI", tipo_poliza)
            cmd_upd_folios.Parameters.AddWithValue("@EJERCICIO", nyear)
            cmd_upd_folios.Transaction = transaccion_sql
            cmd_upd_folios.ExecuteNonQuery()

            transaccion_sql.Commit()
            conexion.Close()
            Return "correcto"
        Catch ex As Exception
            transaccion_sql.Rollback()
            conexion.Close()
            Return ex.Message
        End Try
    End Function

End Class


