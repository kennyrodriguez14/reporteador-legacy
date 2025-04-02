Public Class ClassPPtCorreo


    Private aServidor As String
    Private aPara As String
    Private aDe As String
    Private aAsunto As String
    Private aMensaje As String
    Private aPuerto As String
    Private aUsuario As String
    Private aPassword As String
    Private aUseAutentificacion As String
    Private aSSL As String

    ' propiedades
    '''''''''''''''''''''
    Public Property pservidor()
        Get
            Return aServidor
        End Get
        Set(ByVal value)
            aServidor = value
        End Set
    End Property
     
    Public Property pPara()
        Get
            Return aPara
        End Get
        Set(ByVal value)
            aPara = value
        End Set
    End Property

    Public Property pDe()
        Get
            Return aDe
        End Get
        Set(ByVal value)
            aDe = value
        End Set
    End Property

    Public Property pAsunto()
        Get
            Return aAsunto
        End Get
        Set(ByVal value)
            aAsunto = value
        End Set
    End Property

    Public Property pMensaje()
        Get
            Return aMensaje
        End Get
        Set(ByVal value)
            aMensaje = value
        End Set
    End Property

    Public Property pPuerto()
        Get
            Return aPuerto
        End Get
        Set(ByVal value)
            aPuerto = value
        End Set
    End Property

    Public Property pUsuario()
        Get
            Return aUsuario
        End Get
        Set(ByVal value)
            aUsuario = value
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

    Public Property pUseAutentificacion()
        Get
            Return aUseAutentificacion
        End Get
        Set(ByVal value)
            aUseAutentificacion = value
        End Set
    End Property

    Public Property pSSL()
        Get
            Return aSSL
        End Get
        Set(ByVal value)
            aSSL = value
        End Set
    End Property
End Class
