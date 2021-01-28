using System;
using System.Runtime.InteropServices;

namespace Inject.Net.Core.Dll
{
  public static class Class
  {
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int MessageBox(int hWnd, string text, string caption, uint type);

    public static int Method(IntPtr argPtr, int argLength)
    {
      string arg = Marshal.PtrToStringUni(argPtr);
      MessageBox(0, arg, "", 0);

      return 0;
    }
  }
}
