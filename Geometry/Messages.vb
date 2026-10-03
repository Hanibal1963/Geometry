Module Messages

    Public Sub RadiusIsNegative(ParameterName As String)
        Dim message As String = My.Resources.RadiusIsNegative
        Throw New ArgumentException(message, ParameterName)
    End Sub

    Public Sub DiameterIsNegative(ParameterName As String)
        Dim message As String = My.Resources.DiameterIsNegative
        Throw New ArgumentException(message, ParameterName)
    End Sub

    Public Sub RadiusIsZeroOrLess(ParameterName As String)
        Dim message As String = My.Resources.RadiusIfZeroOrLess
        Throw New ArgumentException(message, ParameterName)
    End Sub

End Module
