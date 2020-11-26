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

        ''' <summary>
        ''' Gets how many non-empty values are there (Empty keys are not counted)
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Count of non-empty values</returns>
        <Extension>
        Public Function CountFullEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Long
            Dim FullEntries As Long
            For i As Long = 0 To Dict.LongCount - 1
                If Dict.Values(i) IsNot Nothing Then
                    If TypeOf Dict.Values(i) Is String Then
                        If Not Dict.Values(i).Equals("") Then
                            FullEntries += 1
                        End If
                    Else
                        FullEntries += 1
                    End If
                End If
            Next
            Return FullEntries
        End Function

        ''' <summary>
        ''' Gets how many empty values are there (Empty keys are not counted)
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Count of empty values</returns>
        <Extension>
        Public Function CountEmptyEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Long
            Dim EmptyEntries As Long
            For i As Long = 0 To Dict.LongCount - 1
                If Dict.Values(i) Is Nothing Then
                    EmptyEntries += 1
                ElseIf TypeOf Dict.Values(i) Is String And Dict.Values(i).Equals("") Then
                    EmptyEntries += 1
                End If
            Next
            Return EmptyEntries
        End Function

        ''' <summary>
        ''' Gets indexes of non-empty items
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Indexes of non-empty items</returns>
        <Extension>
        Public Function GetIndexesOfFullEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer()
            Dim FullIndexes As New List(Of Integer)
            For i As Long = 0 To Dict.LongCount - 1
                If Dict.Values(i) IsNot Nothing Then
                    If TypeOf Dict.Values(i) Is String Then
                        If Not Dict.Values(i).Equals("") Then
                            FullIndexes.Add(i)
                        End If
                    Else
                        FullIndexes.Add(i)
                    End If
                End If
            Next
            Return FullIndexes.ToArray
        End Function

        ''' <summary>
        ''' Gets indexes of empty items
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <returns>Indexes of empty items</returns>
        <Extension>
        Public Function GetIndexesOfEmptyEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer()
            Dim EmptyIndexes As New List(Of Integer)
            For i As Long = 0 To Dict.LongCount - 1
                If Dict.Values(i) Is Nothing Then
                    EmptyIndexes.Add(i)
                ElseIf TypeOf Dict.Values(i) Is String And Dict.Values(i).Equals("") Then
                    EmptyIndexes.Add(i)
                End If
            Next
            Return EmptyIndexes.ToArray
        End Function

        ''' <summary>
        ''' Adds an entry to dictionary if not foud
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        <Extension>
        Public Sub AddIfNotFound(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), EntryKey As TKey, EntryValue As TValue)
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            End If
        End Sub

    End Module
End Namespace

