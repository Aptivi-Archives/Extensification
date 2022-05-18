
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

Namespace CharExts
    ''' <summary>
    ''' Provides the character extensions related to querying
    ''' </summary>
    Public Module Querying

		''' <summary>
		''' Gets an ASCII code of a character
		''' </summary>
		''' <param name="Character">Character</param>
		''' <returns>ASCII code of a character</returns>
		<Extension>
		Public Function GetAsciiCode(Character As Char) As Integer
			Return Convert.ToInt32(Character)
		End Function

		''' <summary>
		''' Converts the character to the instance of ConsoleKeyInfo
		''' </summary>
		''' <param name="c">The character</param>
		<Extension>
		Public Function ToConsoleKeyInfo(c As Char) As ConsoleKeyInfo
			Return ToConsoleKeyInfo(c, Nothing)
		End Function

		''' <summary>
		''' Converts the character to the instance of ConsoleKeyInfo
		''' </summary>
		''' <param name="c">The character</param>
		''' <param name="KeyCharMap">Key character map</param>
		<Extension>
		Public Function ToConsoleKeyInfo(c As Char, KeyCharMap As Dictionary(Of Char, Tuple(Of ConsoleKey, ConsoleModifiers))) As ConsoleKeyInfo
			'Parse the key information
			Dim ParsedInfo As Tuple(Of ConsoleKey, ConsoleModifiers) = c.ParseKeyInfo(KeyCharMap)

			'Check to see if any modifiers are pressed
			Dim ctrl As Boolean = ParsedInfo.Item2.HasFlag(ConsoleModifiers.Control)
			Dim shift As Boolean = ParsedInfo.Item2.HasFlag(ConsoleModifiers.Shift)
			Dim alt As Boolean = ParsedInfo.Item2.HasFlag(ConsoleModifiers.Alt)

			'Return the new instance
			Return New ConsoleKeyInfo(c, ParsedInfo.Item1, shift, alt, ctrl)
		End Function

		''' <summary>
		''' Parses the key information
		''' </summary>
		''' <param name="c">Character to parse</param>
		<Extension>
		Private Function ParseKeyInfo(c As Char) As Tuple(Of ConsoleKey, ConsoleModifiers)
			Return ParseKeyInfo(c, Nothing)
		End Function

		''' <summary>
		''' Parses the key information
		''' </summary>
		''' <param name="c">Character to parse</param>
		''' <param name="KeyCharMap">Key character map</param>
		<Extension>
		Private Function ParseKeyInfo(c As Char, KeyCharMap As Dictionary(Of Char, Tuple(Of ConsoleKey, ConsoleModifiers))) As Tuple(Of ConsoleKey, ConsoleModifiers)
			'Try to get the ConsoleKey from the character
			If c >= Char.MinValue Then
				Dim result As ConsoleKey
				Dim success As Boolean = [Enum].TryParse(c.ToString().ToUpper(), result)
				If success Then
					Return Tuple.Create(result, CType(0, ConsoleModifiers))
				End If
			End If

			'Try to get the tuple of the special key character from the character map defined
			If KeyCharMap IsNot Nothing Then
				Dim result As New Tuple(Of ConsoleKey, ConsoleModifiers)(0, 0)
				Dim success As Boolean = KeyCharMap.TryGetValue(c, result)
				If success Then
					Return result
				End If
			End If

			'If all else fails, return the default
			Return Tuple.Create(CType(Nothing, ConsoleKey), CType(0, ConsoleModifiers))
		End Function


	End Module
End Namespace