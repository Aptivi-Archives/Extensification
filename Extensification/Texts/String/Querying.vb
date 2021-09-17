
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

#If Not NETCOREAPP2_1 Then
Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Text
#End If
#If NET45 Then
Imports System.CodeDom.Compiler
Imports System.Reflection
#End If
Imports System.Runtime.CompilerServices
Imports Extensification.ArrayExts
Imports Extensification.DictionaryExts

Namespace StringExts
    ''' <summary>
    ''' Provides the string extensions related to querying
    ''' </summary>
    Public Module Querying

        ''' <summary>
        ''' Get all indexes of a value in string
        ''' </summary>
        ''' <param name="Str">Source string</param>
        ''' <param name="value">A value</param>
        ''' <returns>Indexes of strings</returns>
        <Extension>
        Public Iterator Function AllIndexesOf(Str As String, value As String) As IEnumerable(Of Integer)
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
        ''' Gets list of ASCII codes from a string
        ''' </summary>
        <Extension>
        Public Function GetAsciiCodes(Str As String) As Byte()
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
        Public Function GetAsciiCode(Str As String, CharacterNum As Integer) As Byte
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrChars As Char() = Str.ToCharArray
            Return AscW(StrChars(CharacterNum))
        End Function

        ''' <summary>
        ''' Gets the list of repeated letters
        ''' </summary>
        ''' <param name="Str">Target string</param>
        <Extension>
        Public Function GetListOfRepeatedLetters(Str As String) As Dictionary(Of String, Integer)
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
        Public Function ContainsAnyOf(Str As String, Targets() As String) As Boolean
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
        Public Function ContainsAllOf(Str As String, Targets() As String) As Boolean
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
        ''' Gets how many times does the program need to step n times on the string until it reaches the end of string.
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Steps">Number of characters to step on</param>
        <Extension>
        Public Function LRP(Str As String, Steps As Integer) As Integer
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

        ''' <summary>
        ''' Checks to see if the string starts with any of the values
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Values">Values</param>
        <Extension>
        Public Function StartsWithAnyOf(Str As String, Values() As String) As Boolean
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim Started As Boolean
            For Each Value As String In Values
                If Str.StartsWith(Value) Then Started = True
            Next
            Return Started
        End Function

        ''' <summary>
        ''' Checks to see if the string starts with all of the values
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Values">Values</param>
        <Extension>
        Public Function StartsWithAllOf(Str As String, Values() As String) As Boolean
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
#If NET45 Then
            Dim Done() As String = {}
#Else
            Dim Done() As String = Array.Empty(Of String)
#End If
            For Each Value As String In Values
                If Str.StartsWith(Value) Then Done.Add(Value)
            Next
            Return Done.SequenceEqual(Values)
        End Function

        ''' <summary>
        ''' Checks to see if the string ends with any of the values
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Values">Values</param>
        <Extension>
        Public Function EndsWithAnyOf(Str As String, Values() As String) As Boolean
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim Started As Boolean
            For Each Value As String In Values
                If Str.EndsWith(Value) Then Started = True
            Next
            Return Started
        End Function

        ''' <summary>
        ''' Checks to see if the string ends with all of the values
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Values">Values</param>
        <Extension>
        Public Function EndsWithAllOf(Str As String, Values() As String) As Boolean
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
#If NET45 Then
            Dim Done() As String = {}
#Else
            Dim Done() As String = Array.Empty(Of String)
#End If
            For Each Value As String In Values
                If Str.EndsWith(Value) Then Done.Add(Value)
            Next
            Return Done.SequenceEqual(Values)
        End Function

        ''' <summary>
        ''' Makes a string array with new line as delimiter
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <returns></returns>
        <Extension>
        Public Function SplitNewLines(Str As String) As String()
            Return Str.Replace(ChrW(13), "").Split(ChrW(10))
        End Function

        ''' <summary>
        ''' Makes a string array with new line (vbCr) as delimiter
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <returns></returns>
        <Extension>
        Public Function SplitNewLinesCr(Str As String) As String()
            Return Str.Replace(ChrW(10), "").Split(ChrW(13))
        End Function

#If Not NETCOREAPP2_1 Then
        ''' <summary>
        ''' Splits the string enclosed in double quotes
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Delims">Delimiters</param>
        <Extension>
        Public Function SplitEncloseDoubleQuotes(Str As String, ParamArray Delims As String()) As String()
            Dim Result() As String
            Dim TStream As New MemoryStream(Encoding.Default.GetBytes(Str))
            Dim Parser As New TextFieldParser(TStream) With {
                .Delimiters = Delims,
                .HasFieldsEnclosedInQuotes = True,
                .TrimWhiteSpace = False
            }
            Result = Parser.ReadFields
            If Result IsNot Nothing Then
                For i As Integer = 0 To Result.Length - 1
                    Result(i).Replace("""", "")
                Next
            End If
            Return Result
        End Function
#End If

#If NET45 Then
        ''' <summary>
        ''' Evaluates a string
        ''' </summary>
        ''' <param name="Str">A string</param>
        ''' <returns></returns>
        <Extension>
        Public Function Evaluate(Str As String) As Object
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
