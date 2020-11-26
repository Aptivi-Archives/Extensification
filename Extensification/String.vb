Imports System.Runtime.CompilerServices
Imports Extensification.ArrayExts
Imports Extensification.DictionaryExts

Namespace StringExts
    Public Module Extensions

        ''' <summary>
        ''' Replaces last occurrence of a text in source string with the replacement
        ''' </summary>
        ''' <param name="source">A string which has the specified text to replace</param>
        ''' <param name="searchText">A string to be replaced</param>
        ''' <param name="replace">A string to replace</param>
        ''' <returns>String that has its last occurrence of text replaced</returns>
        <Extension>
        Public Function ReplaceLastOccurrence(ByVal source As String, ByVal searchText As String, ByVal replace As String) As String
            If source Is Nothing Then Throw New ArgumentNullException("source")
            If searchText Is Nothing Then Throw New ArgumentNullException("searchText")
            Dim position = source.LastIndexOf(searchText)
            If position = -1 Then Return source
            Dim result = source.Remove(position, searchText.Length).Insert(position, replace)
            Return result
        End Function

        ''' <summary>
        ''' Get all indexes of a value in string
        ''' </summary>
        ''' <param name="str">Source string</param>
        ''' <param name="value">A value</param>
        ''' <returns>Indexes of strings</returns>
        <Extension>
        Public Iterator Function AllIndexesOf(ByVal str As String, ByVal value As String) As IEnumerable(Of Integer)
            If str Is Nothing Then Throw New ArgumentNullException("Str")
            If String.IsNullOrEmpty(value) Then
                Throw New ArgumentException("Empty string specified", "value")
            End If
            Dim index As Integer = 0
            Do
                index = str.IndexOf(value, index)
                If index = -1 Then
                    Exit Do
                End If
                Yield index
                index += value.Length
            Loop
        End Function

        ''' <summary>
        ''' Truncates the string if the string is larger than the threshold, otherwise, returns an unchanged string
        ''' </summary>
        ''' <param name="str">Source string to truncate</param>
        ''' <param name="threshold">Max number of string characters</param>
        ''' <returns>Truncated string</returns>
        <Extension>
        Public Function Truncate(ByVal str As String, ByVal threshold As Integer) As String
            If str Is Nothing Then Throw New ArgumentNullException("Str")
            Dim result As String
            If str.Length > threshold Then
                result = str.Substring(0, threshold - 1) + "..."
                Return result
            Else
                Return str
            End If
        End Function

        ''' <summary>
        ''' Formats the string
        ''' </summary>
        ''' <param name="Str">Target string that has {0}, {1}, ...</param>
        ''' <param name="Variables">Variables being used</param>
        ''' <returns>Formatted string</returns>
        <Extension>
        Public Function FormatString(ByVal Str As String, ByVal ParamArray Variables() As Object) As String
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            If Variables Is Nothing Then Throw New ArgumentNullException("Variables")
            For v As Integer = 0 To Variables.Length - 1
                If Not Variables(v) Is Nothing Then
                    Str = Str.Replace("{" + CStr(v) + "}", Variables(v).ToString)
                Else
                    Str = Str.Replace("{" + CStr(v) + "}", "((Null))")
                End If
            Next
            Return Str
        End Function

        ''' <summary>
        ''' Removes spaces from the beginning of the string
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <returns>Modified string</returns>
        <Extension>
        Public Function RemoveSpacesFromBeginning(ByVal Str As String) As String
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            Dim StrChars() As Char = Str.ToCharArray
            Dim CharNum As Integer = 0
            Do Until StrChars(CharNum) <> " "
                StrChars(CharNum) = ""
                CharNum += 1
            Loop
            Return String.Join("", StrChars).Replace(vbNullChar, "")
        End Function

        ''' <summary>
        ''' Replaces all the instances of strings with a string
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="ToBeReplaced">Strings to be replaced</param>
        ''' <param name="ToReplace">String to replace with</param>
        ''' <returns>Modified string</returns>
        ''' <exception cref="ArgumentNullException"></exception>
        <Extension>
        Public Function ReplaceAll(ByVal Str As String, ByVal ToBeReplaced() As String, ByVal ToReplace As String) As String
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            If ToBeReplaced Is Nothing Then Throw New ArgumentNullException("ToBeReplaced")
            If ToBeReplaced.Count = 0 Then Throw New ArgumentNullException("ToBeReplaced")
            For Each ReplaceTarget As String In ToBeReplaced
                Str = Str.Replace(ReplaceTarget, ToReplace)
            Next
            Return Str
        End Function

        ''' <summary>
        ''' Shifts letters in a string either backwards or forward.
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="ShiftThreshold">How many times to shift. If the threshold is negative, the shifting will go backwards. If the threshold is positive, the shifting will go forward.</param>
        ''' <returns>Shifted string</returns>
        <Extension>
        Public Function ShiftLetters(ByVal Str As String, ByVal ShiftThreshold As Integer) As String
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            Dim StrChars As Char() = Str.ToCharArray
            For Character As Integer = 0 To StrChars.Length - 1
                StrChars(Character) = ChrW(AscW(StrChars(Character)) + ShiftThreshold)
            Next
            Return StrChars
        End Function

        ''' <summary>
        ''' Gets list of ASCII codes from a string
        ''' </summary>
        <Extension>
        Public Function GetAsciiCodes(ByVal Str As String) As Byte()
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            Dim StrChars As Char() = Str.ToCharArray
            Dim StrAscii As Byte() = {}
            For Character As Integer = 0 To StrChars.Length - 1
                Dim AsciiCode As Integer = AscW(StrChars(Character))
                StrAscii = StrAscii.Add(AsciiCode)
            Next
            Return StrAscii
        End Function

        ''' <summary>
        ''' Gets an ASCII code for a character
        ''' </summary>
        ''' <param name="CharacterNum">A zero-based character number</param>
        <Extension>
        Public Function GetAsciiCode(ByVal Str As String, ByVal CharacterNum As Integer) As Byte
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            Dim StrChars As Char() = Str.ToCharArray
            Return AscW(StrChars(CharacterNum))
        End Function

        ''' <summary>
        ''' Removes a letter from a string
        ''' </summary>
        ''' <param name="CharacterNum">A zero-based character number</param>
        <Extension>
        Public Function RemoveLetter(ByVal Str As String, ByVal CharacterNum As Integer) As String
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            Dim StrChars As List(Of Char) = Str.ToCharArray.ToList
            StrChars.RemoveAt(CharacterNum)
            Return String.Join("", StrChars)
        End Function

        ''' <summary>
        ''' Removes a range of letters from a string
        ''' </summary>
        ''' <param name="Characters">Array of characters to be remove</param>
        <Extension>
        Public Function RemoveLettersRange(ByVal Str As String, ByVal Characters() As Char) As String
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            If Characters Is Nothing Then Throw New ArgumentNullException("Characters")
            Dim StrChars As List(Of Char) = Str.ToCharArray.ToList
            StrChars.RemoveAll(AddressOf Characters.Contains)
            Return String.Join("", StrChars)
        End Function

        ''' <summary>
        ''' Gets the list of repeated letters
        ''' </summary>
        ''' <param name="Str">Target string</param>
        <Extension>
        Public Function GetListOfRepeatedLetters(ByVal Str As String) As Dictionary(Of String, Integer)
            If Str Is Nothing Then Throw New ArgumentNullException("Str")
            Dim Letters As New Dictionary(Of String, Integer)
            Dim StrChars() As Char = Str.ToCharArray
            For Each Chr As Char In StrChars
                Letters.IncrementNumber(Chr)
            Next
            Return Letters
        End Function

    End Module
End Namespace
