using System.Runtime.InteropServices;

namespace Inject.Net.Framework.Dll
{
  public static class Class
  {
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int MessageBox(int hWnd, string text, string caption, uint type);

    public static int Method(string arg)
    {
      MessageBox(0, arg, "", 0);
      return 0;
    }
  }
}
