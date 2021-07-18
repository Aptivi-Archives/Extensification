
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

Namespace DictionaryExts
    ''' <summary>
    ''' Provides the dictionary extensions related to counting
    ''' </summary>
    Public Module Counts

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

    End Module
End Namespace