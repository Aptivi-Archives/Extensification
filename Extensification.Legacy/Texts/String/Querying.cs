using System.IO;
using System.Text;
using Microsoft.VisualBasic.FileIO;

namespace Extensification.Legacy.StringExts
{
    public static class Querying
    {

        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If Not NETCOREAPP2_1 Then
        */        /// <summary>
        /// Splits the string enclosed in double quotes
        /// </summary>
        /// <param name="Str">Target string</param>
        /// <param name="Delims">Delimiters</param>
        public static string[] SplitEncloseDoubleQuotes(this string Str, params string[] Delims)
        {
            string[] Result;
            var TStream = new MemoryStream(Encoding.Default.GetBytes(Str));
            var Parser = new TextFieldParser(TStream)
            {
                Delimiters = Delims,
                HasFieldsEnclosedInQuotes = true,
                TrimWhiteSpace = false
            };
            Result = Parser.ReadFields();
            if (Result is not null)
            {
                for (int i = 0, loopTo = Result.Length - 1; i <= loopTo; i++)
                    Result[i].Replace("\"", "");
            }
            return Result;
        }
        /* TODO ERROR: Skipped EndIfDirectiveTrivia
        #End If
        */
        /* TODO ERROR: Skipped IfDirectiveTrivia
        #If NET461 Then
        *//* TODO ERROR: Skipped DisabledTextTrivia
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
        *//* TODO ERROR: Skipped EndIfDirectiveTrivia
        #End If
        */
    }
}