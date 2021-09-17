
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
Imports Newtonsoft.Json.Linq

Namespace Newtonsoft.Json.JPropertyExts
    ''' <summary>
    ''' Provides the JProperty extensions related to getting
    ''' </summary>
    Public Module Getting

        ''' <summary>
        ''' Gets a property name that starts with specified string
        ''' </summary>
        ''' <param name="Token">JSON token</param>
        ''' <param name="Containing">String to find at the beginning of string</param>
        ''' <returns>A property name if found; nothing if not found</returns>
        <Extension>
        Public Function GetPropertyNameStartingWith(Token As JToken, Containing As String) As String
            For Each TokenProperty As JProperty In Token
                If TokenProperty.Name.StartsWith(Containing) Then
                    Return TokenProperty.Name
                End If
            Next
            Return ""
        End Function

        ''' <summary>
        ''' Gets a property name that ends with specified string
        ''' </summary>
        ''' <param name="Token">JSON token</param>
        ''' <param name="Containing">String to find at the end of string</param>
        ''' <returns>A property name if found; nothing if not found</returns>
        <Extension>
        Public Function GetPropertyNameEndingWith(Token As JToken, Containing As String) As String
            For Each TokenProperty As JProperty In Token
                If TokenProperty.Name.EndsWith(Containing) Then
                    Return TokenProperty.Name
                End If
            Next
            Return ""
        End Function

        ''' <summary>
        ''' Gets a property name that contains the specified string
        ''' </summary>
        ''' <param name="Token">JSON token</param>
        ''' <param name="Containing">String to find in string</param>
        ''' <returns>A property name if found; nothing if not found</returns>
        <Extension>
        Public Function GetPropertyNameContaining(Token As JToken, Containing As String) As String
            For Each TokenProperty As JProperty In Token
                If TokenProperty.Name.Contains(Containing) Then
                    Return TokenProperty.Name
                End If
            Next
            Return ""
        End Function

        ''' <summary>
        ''' Gets properties that have the specific type in value.
        ''' </summary>
        ''' <param name="Token">JSON token</param>
        ''' <param name="Type">JSON token type to search. If the type is <see cref="JTokenType.None"/>, returns all properties.</param>
        ''' <returns>A property list if properties with specific type is found; empty list if nothing is found</returns>
        <Extension>
        Public Function GetPropertiesTypeInValue(Token As JToken, Type As JTokenType) As List(Of JToken)
            Dim TokenList As New List(Of JToken)
            For Each TokenProperty As JProperty In Token
                If TokenProperty.Value.Type = Type Or Type = JTokenType.None Then
                    TokenList.Add(TokenProperty)
                End If
            Next
            Return TokenList
        End Function

    End Module
End Namespace