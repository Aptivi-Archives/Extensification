
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

Imports System.IO
Imports Extensification.StreamExts
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass>
Public Class StreamTests

#Region "Manipulation"
    ''' <summary>
    ''' Tests trying to seek in a stream
    ''' </summary>
    <TestMethod>
    Public Sub TestTrySeek()
        Dim TargetText As String = "Hello! This is Extensification." + Environment.NewLine +
                                   "You've reached the second line!"
        Dim TextStream As New MemoryStream(Text.Encoding.Default.GetBytes(TargetText))
        Assert.IsTrue(TextStream.TrySeek(4, SeekOrigin.Begin))
        Assert.IsTrue(TextStream.Position = 4)
    End Sub
#End Region

End Class
