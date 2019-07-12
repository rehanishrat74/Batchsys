Public Class Common
    Public OutPurCode As Integer
    Public dsDataSet As DataSet
    Public Property GetOutPutCode()
        Get
            Return OutPurCode
        End Get
        Set(ByVal Value)
            OutPurCode = Value
        End Set
    End Property

    Public Property GetDataSet()
        Get
            Return dsDataSet
        End Get
        Set(ByVal Value)
            dsDataSet = Value
        End Set
    End Property

End Class

