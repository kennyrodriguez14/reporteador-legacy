﻿Imports System.Data
Imports System.Data.SqlClient
Public Class cls_conexion_admon_bienes
#Region "Atributos"
    Private aServidor As String
    Private aBD As String
    Private aUser As String
    Private aPassword As String
#End Region

#Region "Constructor"
    Public Sub New()
        pServidor = "192.168.10.60"
        pBD = "SAE60Empre03"
        pUser = "sa"
        pPassword = "aspel0512"

        'pServidor = "192.168.10.55"
        'pBD = "SAE60Empre01"
        'pUser = "sa"
        'pPassword = "Aspel0512"
    End Sub
#End Region

#Region "Propiedades"
    Public Property pServidor()
        Get
            Return aServidor
        End Get
        Set(ByVal value)
            aServidor = value
        End Set
    End Property

    Public Property pBD()
        Get
            Return aBD
        End Get
        Set(ByVal value)
            aBD = value
        End Set
    End Property

    Public Property pUser()
        Get
            Return aUser
        End Get
        Set(ByVal value)
            aUser = value
        End Set
    End Property

    Public Property pPassword()
        Get
            Return aPassword
        End Get
        Set(ByVal value)
            aPassword = value
        End Set
    End Property
#End Region

#Region "Metodos"
    Public Function CadenaSQL() As String
        Return "data source = " & pServidor & ";" & "initial catalog = " & pBD & ";" & "user = " & pUser & ";" & "password = " & pPassword & ";"
    End Function
#End Region
End Class
