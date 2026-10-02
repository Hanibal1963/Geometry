Friend Class Messages

    Public Shared Sub RadiusIsNegative(ParameterName As String)
        Dim message As String = My.Resources.RadiusIsNegative
        Throw New ArgumentException(message, ParameterName)
    End Sub

End Class
