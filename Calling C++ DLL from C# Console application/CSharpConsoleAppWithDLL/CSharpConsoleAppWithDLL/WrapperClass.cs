using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharpConsoleAppWithDLL
{
    public static class WrapperClass
    {
        #region dllImports
        // Target the cpp dll here -- add project reference to this dll in C# project also
        private const string _dllImportPath = @"Functions.dll";

        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Add(int x, int y);

        [DllImport(_dllImportPath, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Multiply(int x, int y);
        #endregion
    }
}
