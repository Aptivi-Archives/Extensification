
'    Extensification  Copyright (C) 2020-2021  EoflaOE
'
'    This file is part of Extensification
'
'    Extensification is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    Extensification is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with this program.  If not, see <https://www.gnu.org/licenses/>.

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
                StrAscii.Add(AsciiCode)
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

        ''' <summary>
        ''' Checks to see if the string contains any of the target strings.
        ''' </summary>
        ''' <param name="Str">Source string</param>
        ''' <param name="Targets">Target strings</param>
        ''' <returns>True if one of them is found; else, false.</returns>
        <Extension>
        Public Function ContainsAnyOf(ByVal Str As String, ByVal Targets() As String) As Boolean
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            For Each Target As String In Targets
                If Str.Contains(Target) Then Return True
            Next
            Return False
        End Function

        ''' <summary>
        ''' Checks to see if the string contains all of the target strings.
        ''' </summary>
        ''' <param name="Str">Source string</param>
        ''' <param name="Targets">Target strings</param>
        ''' <returns>True if all of them are found; else, false.</returns>
        <Extension>
        Public Function ContainsAllOf(ByVal Str As String, ByVal Targets() As String) As Boolean
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
#If NET45 Then
            Dim Done() As String = {}
#Else
            Dim Done() As String = Array.Empty(Of String)
#End If
            For Each Target As String In Targets
                If Str.Contains(Target) Then Done.Add(Target)
            Next
            Return Done.SequenceEqual(Targets)
        End Function

        ''' <summary>
        ''' Converts all of the VT sequence numbers enclosed in &lt; and &gt; marks to their appropriate VT sequence.
        ''' For example, &lt;38;5;5&gt; will be converted to ChrW(&amp;H1B)[38;5;5m. Note that if you write spaces between &lt; and &gt; marks,
        ''' it will not parse it.
        ''' </summary>
        ''' <param name="Str">Target string</param>
        <Extension>
        Public Sub ConvertVTSequences(ByRef Str As String)
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrArrayWords() As String = Str.Split(" ")
            For WordNumber As Integer = 0 To StrArrayWords.Length - 1
                If StrArrayWords(WordNumber).ContainsAllOf({"<", ">"}) Then
ParseSequence:
                    'Get sequence that is enclosed between < and > quotes.
                    Dim StartIndex As Integer = StrArrayWords(WordNumber).IndexOf("<")
                    Dim EndIndex As Integer = StrArrayWords(WordNumber).IndexOf(">") + 1
                    Dim Sequence As String

                    'Replace placeholder sequence with the parsable sequence.
                    If StartIndex <> -1 And EndIndex <> -1 Then
                        Sequence = StrArrayWords(WordNumber).Substring(StartIndex, EndIndex - StartIndex)
                        StrArrayWords(WordNumber) = StrArrayWords(WordNumber).Replace(Sequence, ChrW(&H1B) + "[" + Sequence.ReplaceAll({"<", ">"}, "") + "m")
                    End If

                    'Check if there are any more sequences.
                    If StrArrayWords(WordNumber).ContainsAllOf({"<", ">"}) Then
                        GoTo ParseSequence
                    End If
                End If
            Next
            Str = String.Join(" ", StrArrayWords)
        End Sub

        ''' <summary>
        ''' Reverses the order of characters in a string
        ''' </summary>
        ''' <param name="Str">Target string</param>
        <Extension>
        Public Function Reverse(ByVal Str As String) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Return String.Join("", Str.ToCharArray.Reverse)
        End Function

        ''' <summary>
        ''' Repeats a string 'n' times
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Times">Number of times to be repeated</param>
        <Extension>
        Public Function Repeat(ByVal Str As String, ByVal Times As Long) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If Times <= 0 Then Throw New ArgumentException("Zero or negative times aren't allowed.", NameOf(Str))
            Dim Target As String = ""
            For i As Long = 1 To Times
                Target += Str
            Next
            Return Target
        End Function

        ''' <summary>
        ''' Removes null characters or whitespaces at the end of the string
        ''' </summary>
        ''' <param name="Str">Target string</param>
        <Extension>
        Public Sub RemoveNullsOrWhitespacesAtTheEnd(ByRef Str As String)
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrList As List(Of Char) = Str.ToCharArray.ToList
            Dim CharIndex As Integer = Str.Length - 1
            Do While String.IsNullOrWhiteSpace(StrList(CharIndex))
                StrList.RemoveAt(CharIndex)
                CharIndex -= 1
            Loop
            Str = String.Join("", StrList)
        End Sub

        ''' <summary>
        ''' Removes null characters or whitespaces at the beginning of the string
        ''' </summary>
        ''' <param name="Str">Target string</param>
        <Extension>
        Public Sub RemoveNullsOrWhitespacesAtTheBeginning(ByRef Str As String)
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrList As List(Of Char) = Str.ToCharArray.ToList
            Do While String.IsNullOrWhiteSpace(StrList(0))
                StrList.RemoveAt(0)
            Loop
            Str = String.Join("", StrList)
        End Sub

        ''' <summary>
        ''' Retrieves a substring from this instance. The substring starts at a specified starting position and ends at a specified ending position
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Start">Start position</param>
        ''' <param name="Finish">Finish position</param>
        <Extension>
        Public Function Substring(ByVal Str As String, ByVal Start As Integer, ByVal Finish As Integer) As String
            If Finish < Start Then Throw New ArgumentException("Finish position couldn't be before the start position")
            Dim Length As Integer = Finish - Start
            Return Str.Substring(Start, length:=Length + 1)
        End Function

        ''' <summary>
        ''' Gets how many times does the program need to step n times on the string until it reaches the end of string.
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Steps">Number of characters to step on</param>
        <Extension>
        Public Function LRP(ByVal Str As String, ByVal Steps As Integer) As Integer
            If Steps <= 0 Then Throw New ArgumentException("Can't step zero or negative characters.", NameOf(Steps))
            Dim LastPosition As Integer
            Dim StringLength As Integer = Str.Length
            Dim RepeatTimes As Integer
            Dim LoopStep As Integer
            Dim [Step] As Integer
            While True
                For LoopStep = LastPosition To Steps + LastPosition
                    [Step] = LoopStep
                    While [Step] > StringLength
                        [Step] -= StringLength
                    End While
                Next
                LastPosition = [Step]
                RepeatTimes += 1
                If LastPosition = StringLength Then Return RepeatTimes
            End While
            Return 0
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
