Imports System.CodeDom.Compiler
Imports System.Reflection
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
            If source Is Nothing Then Throw New ArgumentNullException(NameOf(source))
            If searchText Is Nothing Then Throw New ArgumentNullException(NameOf(searchText))
            Dim position = source.LastIndexOf(searchText)
            If position = -1 Then Return source
            Dim result = source.Remove(position, searchText.Length).Insert(position, replace)
            Return result
        End Function

        ''' <summary>
        ''' Get all indexes of a value in string
        ''' </summary>
        ''' <param name="Str">Source string</param>
        ''' <param name="value">A value</param>
        ''' <returns>Indexes of strings</returns>
        <Extension>
        Public Iterator Function AllIndexesOf(ByVal Str As String, ByVal value As String) As IEnumerable(Of Integer)
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If String.IsNullOrEmpty(value) Then
                Throw New ArgumentException("Empty string specified", NameOf(value))
            End If
            Dim index As Integer = 0
            Do
                index = Str.IndexOf(value, index)
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
            If str Is Nothing Then Throw New ArgumentNullException(NameOf(str))
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If Variables Is Nothing Then Throw New ArgumentNullException(NameOf(Variables))
            For v As Integer = 0 To Variables.Length - 1
                If Variables(v) IsNot Nothing Then
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If ToBeReplaced Is Nothing Then Throw New ArgumentNullException(NameOf(ToBeReplaced))
            If ToBeReplaced.Length = 0 Then Throw New ArgumentNullException(NameOf(ToBeReplaced))
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrChars As Char() = Str.ToCharArray
#If NET45 Then
            Dim StrAscii As Byte() = {}
#Else
            Dim StrAscii As Byte() = Array.Empty(Of Byte)
#End If
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrChars As Char() = Str.ToCharArray
            Return AscW(StrChars(CharacterNum))
        End Function

        ''' <summary>
        ''' Removes a letter from a string
        ''' </summary>
        ''' <param name="CharacterNum">A zero-based character number</param>
        <Extension>
        Public Function RemoveLetter(ByVal Str As String, ByVal CharacterNum As Integer) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If Characters Is Nothing Then Throw New ArgumentNullException(NameOf(Characters))
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
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim Letters As New Dictionary(Of String, Integer)
            Dim StrChars() As Char = Str.ToCharArray
            For Each Chr As Char In StrChars
                Letters.IncrementNumber(Chr)
            Next
            Return Letters
        End Function

#If NET45 Then
        ''' <summary>
        ''' Evaluates a string
        ''' </summary>
        ''' <param name="Str">A string</param>
        ''' <returns></returns>
        <Extension>
        Public Function Evaluate(ByVal Str As String) As Object
            Dim EvalP As New VBCodeProvider
            Dim EvalCP As New CompilerParameters With {.GenerateExecutable = False,
                                                       .GenerateInMemory = True}
            EvalCP.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly.Location) 'It should reference itself
            EvalCP.ReferencedAssemblies.Add("System.dll")
            EvalCP.ReferencedAssemblies.Add("System.Core.dll")
            EvalCP.ReferencedAssemblies.Add("System.Data.dll")
            EvalCP.ReferencedAssemblies.Add("System.DirectoryServices.dll")
            EvalCP.ReferencedAssemblies.Add("System.Xml.dll")
            EvalCP.ReferencedAssemblies.Add("System.Xml.Linq.dll")
            Dim EvalCode As String = "Imports System" & Environment.NewLine &
                                     "Public Class Eval" & Environment.NewLine &
                                     "Public Shared Function Evaluate()" & Environment.NewLine &
                                     "Return " & Str & Environment.NewLine &
                                     "End Function" & Environment.NewLine &
                                     "End Class"
            Dim cr As CompilerResults = EvalP.CompileAssemblyFromSource(EvalCP, EvalCode)
            If cr.Errors.Count = 0 Then
                Dim methInfo As MethodInfo = cr.CompiledAssembly.GetType("Eval").GetMethod("Evaluate")
                Return methInfo.Invoke(Nothing, Nothing)
            End If
            Return Nothing
        End Function
#End If

    End Module
End Namespace
