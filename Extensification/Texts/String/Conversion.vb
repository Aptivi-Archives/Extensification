
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
    ''' Provides the string extensions related to conversion
    ''' </summary>
    Public Module Conversion

        ''' <summary>
        ''' Converts all of the VT sequence numbers enclosed in &lt; and &gt; marks to their appropriate VT sequence.
        ''' For example, &lt;38;5;5&gt; will be converted to ChrW(&amp;H1B)[38;5;5. Note that if you write spaces between &lt; and &gt; marks,
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

                        'Check if the sequence needs special beginning
                        If Sequence.StartsWithAnyOf({"<A", "<B", "<C", "<D", "<M", "<E", "<7", "<8", "<=", "<>", "<H", "<N", "<O", "<5n", "<6n"}) And
                           Not Sequence.EndsWithAnyOf({"F>", "G>", "H>", "d>", "f>", "S>", "T>", "@>", "P>", "X>", "L>", "M>", "J>", "K>", "m>", "I>", "Z>", "r>"}) Then
                            'These sequences don't need any of '[' and ']'.
                            StrArrayWords(WordNumber) = StrArrayWords(WordNumber).Replace(Sequence, ChrW(&H1B) + Sequence.ReplaceAll({"<", ">"}, ""))
                        ElseIf Sequence.StartsWithAnyOf({"<4", "<0", "<2"}) And (Not Sequence.StartsWithAnyOf({"<2~", "<20", "<21", "<23", "<24", "<48"}) And Not Sequence.EndsWith("0m>")) Then
                            'These sequences need ']' as they are OSC sequences.
                            If Sequence.StartsWithAnyOf({"<0", "<2"}) Then
                                'They each need a BELL character &H07
                                StrArrayWords(WordNumber) = StrArrayWords(WordNumber).Replace(Sequence, ChrW(&H1B) + "]" + Sequence.ReplaceAll({"<", ">"}, "") + ChrW(&H7))
                            ElseIf Sequence.StartsWith("<4") Then
                                'This needs an ESC character &H1B
                                StrArrayWords(WordNumber) = StrArrayWords(WordNumber).Replace(Sequence, ChrW(&H1B) + "]" + Sequence.ReplaceAll({"<", ">"}, "") + ChrW(&H1B))
                            Else
                                'No special suffixes needed
                                StrArrayWords(WordNumber) = StrArrayWords(WordNumber).Replace(Sequence, ChrW(&H1B) + "]" + Sequence.ReplaceAll({"<", ">"}, ""))
                            End If
                        Else
                            'These sequences need '[' as they are CSI sequences.
                            StrArrayWords(WordNumber) = StrArrayWords(WordNumber).Replace(Sequence, ChrW(&H1B) + "[" + Sequence.ReplaceAll({"<", ">"}, ""))
                        End If
                    End If

                    'Check if there are any more sequences.
                    If StrArrayWords(WordNumber).ContainsAllOf({"<", ">"}) Then
                        GoTo ParseSequence
                    End If
                End If
            Next
            Str = String.Join(" ", StrArrayWords)
        End Sub

    End Module
End Namespace