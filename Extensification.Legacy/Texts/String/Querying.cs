
// Extensification  Copyright (C) 2020-2021  Aptivi
// 
// This file is part of Extensification
// 
// Extensification is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Extensification is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.

#if NET48
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Reflection;
#endif

namespace Extensification.Legacy.StringExts
{
    public static class Querying
    {
#if NET48
        /// <summary>
        /// Evaluates a string
        /// </summary>
        /// <param name="Str">A string</param>
        /// <returns></returns>
        public static object Evaluate(this string Str)
        {
            var EvalP = new VBCodeProvider();
            var EvalCP = new CompilerParameters()
            {
                GenerateExecutable = false,
                GenerateInMemory = true
            };
            EvalCP.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location); // It should reference itself
            EvalCP.ReferencedAssemblies.Add("System.dll");
            EvalCP.ReferencedAssemblies.Add("System.Core.dll");
            EvalCP.ReferencedAssemblies.Add("System.Data.dll");
            EvalCP.ReferencedAssemblies.Add("System.DirectoryServices.dll");
            EvalCP.ReferencedAssemblies.Add("System.Xml.dll");
            EvalCP.ReferencedAssemblies.Add("System.Xml.Linq.dll");
            string EvalCode = "Imports System" + Environment.NewLine + "Public Class Eval" + Environment.NewLine + "Public Shared Function Evaluate()" + Environment.NewLine + "Return " + Str + Environment.NewLine + "End Function" + Environment.NewLine + "End Class";
            CompilerResults cr = EvalP.CompileAssemblyFromSource(EvalCP, EvalCode);
            if (cr.Errors.Count == 0)
            {
                MethodInfo methInfo = cr.CompiledAssembly.GetType("Eval").GetMethod("Evaluate");
                return methInfo.Invoke(null, null);
            }
            return null;
        }
#endif
    }
}