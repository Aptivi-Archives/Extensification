
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
    ''' Provides the string extensions related to removal
    ''' </summary>
    Public Module Removal

        ''' <summary>
        ''' Removes spaces from the beginning of the string
        ''' </summary>
        ''' <param name="Str">Target string</param>
        ''' <returns>Modified string</returns>
        <Extension>
        Public Function RemoveSpacesFromBeginning(Str As String) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            Dim StrChars() As Char = Str.ToCharArray
            Dim CharNum As Integer = 0
            Do Until StrChars(CharNum) <> " "
                StrChars(CharNum) = ""
                CharNum += 1
            Loop
            Return String.Join("", StrChars).Replace(Convert.ToChar(0), "")
        End Function

        ''' <summary>
        ''' Removes a letter from a string
        ''' </summary>
        ''' <param name="CharacterNum">A zero-based character number</param>
        <Extension>
        Public Function RemoveLetter(Str As String, CharacterNum As Integer) As String
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
        Public Function RemoveLettersRange(Str As String, Characters() As Char) As String
            If Str Is Nothing Then Throw New ArgumentNullException(NameOf(Str))
            If Characters Is Nothing Then Throw New ArgumentNullException(NameOf(Characters))
            Dim StrChars As List(Of Char) = Str.ToCharArray.ToList
            StrChars.RemoveAll(AddressOf Characters.Contains)
            Return String.Join("", StrChars)
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
            If Not StrList.Count = 0 Then
                Do While String.IsNullOrWhiteSpace(StrList(CharIndex))
                    StrList.RemoveAt(CharIndex)
                    CharIndex -= 1
                Loop
            End If
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
            If Not StrList.Count = 0 Then
                Do While String.IsNullOrWhiteSpace(StrList(0))
                    StrList.RemoveAt(0)
                Loop
            End If
            Str = String.Join("", StrList)
        End Sub

    End Module
End Namespace