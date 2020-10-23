Imports System.Runtime.CompilerServices

Namespace DictionaryExts
    Public Module Extensions

        ''' <summary>
        ''' Gets a key from a value in the dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Value">Value</param>
        ''' <returns>Key from value</returns>
        <Extension>
        Public Function GetKeyFromValue(Of TKey, TValue)(ByVal Dict As Dictionary(Of TKey, TValue), ByVal Value As Object) As Object
            If Dict Is Nothing Then Throw New ArgumentNullException("Dict")
            For Each DictKey As Object In Dict.Keys
                If Dict(DictKey).Equals(Value) Then
                    Return DictKey
                End If
            Next
            Return Nothing
        End Function

        ''' <summary>
        ''' Gets an index from a key in the dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Source dictionary</param>
        ''' <param name="Key">Key</param>
        ''' <returns>Index of key</returns>
        <Extension>
        Public Function GetIndexOfKey(Of TKey, TValue)(ByVal Dict As Dictionary(Of TKey, TValue), ByVal Key As Object) As Integer
            If Dict Is Nothing Then Throw New ArgumentNullException("Dict")
            Dim DetectedIndex As Integer = 0
            For Index As Integer = 0 To Dict.Count - 1
                Dim ListEntry As Object = Dict.Keys(Index)
                If ListEntry = Key Then
                    DetectedIndex = Index
                End If
            Next
            Return DetectedIndex
        End Function

    End Module
End Namespace

