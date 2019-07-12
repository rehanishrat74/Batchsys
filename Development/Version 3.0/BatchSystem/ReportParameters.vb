Public Class ReportParameters
    Public sParameterName As String
    Public sParameterValue As String
    Public sParameterType As Object
    'Public Property ReportParameter()
    Public Property ParameterName() As String
        Get
            Return sParameterName
        End Get
        Set(ByVal value As String)
            sParameterName = value
        End Set
    End Property
    Public Property ParameterValue() As String
        Get
            Return sParameterValue
        End Get
        Set(ByVal value As String)
            sParameterValue = value
        End Set
    End Property
    Public Property ParameterType() As String
        Get
            Return sParameterType
        End Get
        Set(ByVal value As String)
            sParameterType = value
        End Set
    End Property
End Class
