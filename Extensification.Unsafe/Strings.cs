using System;
using System.Collections.Generic;
using System.Text;

namespace Extensification.Unsafe
{
    unsafe class StringExtensions
    {
        int ExecuteASM(char* machine_code)
        {
            int(fn *)() = machine_code;
            return fn();
        }

    }
}
