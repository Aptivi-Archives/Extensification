
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

Imports System.Runtime.CompilerServices

Namespace StringExts
    ''' <summary>
    ''' Provides the string extensions related to manipulation
    ''' </summary>
    Public Module Manipulation

        ''' <summary>
        ''' Replaces last occurrence of a text in source string with the replacement
        ''' </summary>
        ''' <param name="source">A string which has the specified text to replace</param>
        ''' <param name="searchText">A string to be replaced</param>
        ''' <param name="replace">A string to replace</param>
        ''' <returns>String that has its last occurrence of text replaced</returns>
        <Extension>
        Public Function ReplaceLastOccurrence(source As String, searchText As String, replace As String) As String
            If source Is Nothing Then Throw New ArgumentNullException(NameOf(source))
            If searchText Is Nothing Then Throw New ArgumentNullException(NameOf(searchText))
            Dim position = source.LastIndexOf(searchText)
            If position = -1 Then Return source
            Dim result = source.Remove(position, searchText.Length).Insert(position, replace)
            Return result
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
        Public Function ReplaceAll(Str As String, ToBeReplaced() As String, ToReplace As String) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If ToBeReplaced Is Nothing Then Throw New ArgumentNullException(NameOf(ToBeReplaced))
            If ToBeReplaced.Length = 0 Then Throw New ArgumentNullException(NameOf(ToBeReplaced))
            For Each ReplaceTarget As String In ToBeReplaced
                Str = Str.Replace(ReplaceTarget, ToReplace)
            Next
            Return Str
        End Function

        ''' <summary>
        ''' Replaces all the instances of strings with a string assigned to each entry
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="ToBeReplaced">Strings to be replaced</param>
        ''' <param name="ToReplace">Strings to replace with</param>
        ''' <returns>Modified string</returns>
        ''' <exception cref="ArgumentNullException"></exception>
        ''' <exception cref="ArgumentException"></exception>
        <Extension>
        Public Function ReplaceAllRange(Str As String, ToBeReplaced() As String, ToReplace() As String) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If ToBeReplaced Is Nothing Then Throw New ArgumentNullException(NameOf(ToBeReplaced))
            If ToBeReplaced.Length = 0 Then Throw New ArgumentNullException(NameOf(ToBeReplaced))
            If ToReplace Is Nothing Then Throw New ArgumentNullException(NameOf(ToReplace))
            If ToReplace.Length = 0 Then Throw New ArgumentNullException(NameOf(ToReplace))
            If ToBeReplaced.Length <> ToBeReplaced.Length Then Throw New ArgumentException("Array length of which strings to be replaced doesn't equal the array length of which strings to replace.")
            For i As Integer = 0 To ToBeReplaced.Length - 1
                Str = Str.Replace(ToBeReplaced(i), ToReplace(i))
            Next
            Return Str
        End Function

        ''' <summary>
        ''' Truncates the string if the string is larger than the threshold, otherwise, returns an unchanged string
        ''' </summary>
        ''' <param name="str">Source string to truncate</param>
        ''' <param name="threshold">Max number of string characters</param>
        ''' <returns>Truncated string</returns>
        <Extension>
        Public Function Truncate(str As String, threshold As Integer) As String
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
        Public Function FormatString(Str As String, ParamArray Variables() As Object) As String
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
        ''' Shifts letters in a string either backwards or forward.
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="ShiftThreshold">How many times to shift. If the threshold is negative, the shifting will go backwards. If the threshold is positive, the shifting will go forward.</param>
        ''' <returns>Shifted string</returns>
        <Extension>
        Public Function ShiftLetters(Str As String, ShiftThreshold As Integer) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrChars As Char() = Str.ToCharArray
            For Character As Integer = 0 To StrChars.Length - 1
                StrChars(Character) = ChrW(AscW(StrChars(Character)) + ShiftThreshold)
            Next
            Return StrChars
        End Function

        ''' <summary>
        ''' Reverses the order of characters in a string
        ''' </summary>
        ''' <param name="Str">Target string</param>
        <Extension>
        Public Function Reverse(Str As String) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Return String.Join("", Str.ToCharArray.Reverse)
        End Function

        ''' <summary>
        ''' Repeats a string 'n' times
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Times">Number of times to be repeated</param>
        <Extension>
        Public Function Repeat(Str As String, Times As Long) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If Times <= 0 Then Throw New ArgumentException("Zero or negative times aren't allowed.", NameOf(Str))
            Dim Target As String = ""
            For i As Long = 1 To Times
                Target += Str
            Next
            Return Target
        End Function

        ''' <summary>
        ''' Retrieves a substring from this instance. The substring starts at a specified starting position and ends at a specified ending position
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <param name="Start">Start position</param>
        ''' <param name="Finish">Finish position</param>
        <Extension>
        Public Function Substring(Str As String, Start As Integer, Finish As Integer) As String
            If Finish < Start Then Throw New ArgumentException("Finish position couldn't be before the start position")
            Dim Length As Integer = Finish - Start
            Return Str.Substring(Start, length:=Length + 1)
        End Function

        ''' <summary>
        ''' Encloses a string by double quotations
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <returns>Enclosed string</returns>
        <Extension>
        Public Function EncloseByDoubleQuotes(Str As String) As String
            Return """" + Str + """"
        End Function

        ''' <summary>
        ''' Releases a string from double quotations
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <returns>Released string</returns>
        <Extension>
        Public Function ReleaseDoubleQuotes(Str As String) As String
            Dim ReleasedString As String = Str
            If Str.StartsWith("""") And Str.EndsWith("""") Then
                ReleasedString = ReleasedString.Remove(0, 1)
                ReleasedString = ReleasedString.Remove(ReleasedString.Length - 1)
            End If
            Return ReleasedString
        End Function

    End Module
End Namespace