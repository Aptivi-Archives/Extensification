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
        Public Function GetKeyFromValue(Of TKey, TValue)(ByVal Dict As Dictionary(Of TKey, TValue), ByVal Value As TValue) As TKey
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
            For Each DictKey As TKey In Dict.Keys
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
        Public Function GetIndexOfKey(Of TKey, TValue)(ByVal Dict As Dictionary(Of TKey, TValue), ByVal Key As TKey) As Integer
            If Dict Is Nothing Then Throw New ArgumentNullException(NameOf(Dict))
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
        Public Function CountFullEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer
            Dim FullEntries As Integer
            For i As Long = 0 To Dict.Count - 1
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
        Public Function CountEmptyEntries(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue)) As Integer
            Dim EmptyEntries As Integer
            For i As Long = 0 To Dict.Count - 1
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
            For i As Long = 0 To Dict.Count - 1
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
            For i As Long = 0 To Dict.Count - 1
                If Dict.Values(i) Is Nothing Then
                    EmptyIndexes.Add(i)
                ElseIf TypeOf Dict.Values(i) Is String And Dict.Values(i).Equals("") Then
                    EmptyIndexes.Add(i)
                End If
            Next
            Return EmptyIndexes.ToArray
        End Function

        ''' <summary>
        ''' Adds an entry to dictionary if not found
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        <Extension>
        Public Sub AddIfNotFound(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), EntryKey As TKey, EntryValue As TValue)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            End If
        End Sub

        ''' <summary>
        ''' Adds or modifies an entry to dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        <Extension>
        Public Sub AddOrModify(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), EntryKey As TKey, EntryValue As TValue)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then
                Dict.Add(EntryKey, EntryValue)
            Else
                Dict(EntryKey) = EntryValue
            End If
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Integer), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Increments number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be incremented</param>
        <Extension>
        Public Sub IncrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Long), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) += 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Integer), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

        ''' <summary>
        ''' Decrements number value in key. The key will be created if not found.
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be decremented</param>
        <Extension>
        Public Sub DecrementNumber(Of TKey)(Dict As Dictionary(Of TKey, Long), EntryKey As TKey)
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            If Not Dict.ContainsKey(EntryKey) Then Dict.Add(EntryKey, 0)
            Dict(EntryKey) -= 1
        End Sub

#If NET45 Then
        ''' <summary>
        ''' Attempts to add the specified key and value to the dictionary
        ''' </summary>
        ''' <typeparam name="TKey">Key</typeparam>
        ''' <typeparam name="TValue">Value</typeparam>
        ''' <param name="Dict">Target dictionary</param>
        ''' <param name="EntryKey">A key entry to be added</param>
        ''' <param name="EntryValue">A value of entry</param>
        ''' <returns>True if successful; False if unsuccessful</returns>
        <Extension>
        Public Function TryAdd(Of TKey, TValue)(Dict As Dictionary(Of TKey, TValue), EntryKey As TKey, EntryValue As TValue) As Boolean
            If EntryKey Is Nothing Then Throw New ArgumentNullException(NameOf(EntryKey))
            Try
                Dict.Add(EntryKey, EntryValue)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
#End If

    End Module
End Namespace

