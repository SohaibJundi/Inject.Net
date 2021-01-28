using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using PeNet;

// ReSharper disable LocalizableElement

namespace Inject.Net
{
  public partial class FormMain : Form
  {
    private readonly OpenFileDialog _ofd = new OpenFileDialog { Multiselect = false };

    public FormMain()
    {
      InitializeComponent();
    }

    private void FormMain_Shown(object sender, EventArgs e)
    {
      btn_Refresh.PerformClick();
    }

    private void cmbx_Processes_Format(object sender, ListControlConvertEventArgs e)
    {
      var process = (Process) e.ListItem;
      e.Value = $"{process.ProcessName} ({process.Id})";
    }

    private void btn_Refresh_Click(object sender, EventArgs e)
    {
      var processes = Process.GetProcesses();
      Array.Sort(processes, (p1, p2) => string.Compare(p1.ProcessName, p2.ProcessName, StringComparison.InvariantCultureIgnoreCase));
      cmbx_Processes.DataSource = processes;
    }

    private void rdbtn_Framework_CheckedChanged(object sender, EventArgs e)
    {
      label4.Enabled = txt_RuntimeConfigPath.Enabled = btn_RuntimeConfigPathBrowse.Enabled = !rdbtn_Framework.Checked;
    }

    private void btn_DllPathBrowse_Click(object sender, EventArgs e)
    {
      _ofd.Filter = "Dll Files | *.dll";
      _ofd.DefaultExt = "dll";

      if (_ofd.ShowDialog() == DialogResult.OK)
      {
        txt_DllPath.Text = _ofd.FileName;
      }
    }

    private void btn_RuntimeConfigPathBrowse_Click(object sender, EventArgs e)
    {
      _ofd.Filter = "Json Runtime Config Files | *.runtimeconfig.json";
      _ofd.DefaultExt = "runtimeconfig.json";

      if (_ofd.ShowDialog() == DialogResult.OK)
      {
        txt_RuntimeConfigPath.Text = _ofd.FileName;
      }
    }

    private static IntPtr WriteString(IntPtr processHandle, string arg)
    {
      byte[] buffer = Encoding.Unicode.GetBytes(arg);
      IntPtr address = Native.VirtualAllocEx(processHandle, IntPtr.Zero, buffer.Length, 0x3000, 0x04);
      Native.WriteProcessMemory(processHandle, address, buffer, buffer.Length, out _);

      return address;
    }

    private void btn_Inject_Click(object sender, EventArgs e)
    {
      var process = (Process) cmbx_Processes.SelectedValue;
      var processHandle = process.Handle;
      var characterCount = 256;
      var sb = new StringBuilder(characterCount);
      Native.QueryFullProcessImageName(processHandle, 0, sb, ref characterCount);

      if (Environment.Is64BitProcess != PeFile.Is64BitPeFile(sb.ToString()))
      {
        MessageBox.Show("Use an injector that matches the architecture of the process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        return;
      }

      var isFramework = rdbtn_Framework.Checked;
      var dllName = $"Inject.Net.{(isFramework ? "Framework" : "Core")}.Loader.dll";
      var dllLoaderPath = $"{Directory.GetCurrentDirectory()}\\{dllName}";
      var loaderModule = process.Modules.Cast<ProcessModule>().FirstOrDefault(m => m.ModuleName.Equals(dllName, StringComparison.InvariantCultureIgnoreCase));

      if(loaderModule == null)
      {
        var kernel32Module = process.Modules.Cast<ProcessModule>().First(m => m.ModuleName.Equals("kernel32.dll", StringComparison.InvariantCultureIgnoreCase));
        var LoadLibraryW = new PeFile(kernel32Module.FileName).ExportedFunctions.First(f => f.Name.Equals("LoadLibraryW", StringComparison.InvariantCultureIgnoreCase));
        IntPtr dllPtr = WriteString(processHandle, dllLoaderPath);
        IntPtr threadHandle = Native.CreateRemoteThread(processHandle, IntPtr.Zero, 0, kernel32Module.BaseAddress + (int)LoadLibraryW.Address, dllPtr, 0, out _);
        Native.WaitForSingleObject(threadHandle, uint.MaxValue);
        Native.VirtualFreeEx(processHandle, dllPtr, 0, 0x8000);
        process.Refresh();
        loaderModule = process.Modules.Cast<ProcessModule>().First(m => m.ModuleName.Equals(dllName, StringComparison.InvariantCultureIgnoreCase));
      }

      var loaderPE = new PeFile(dllLoaderPath);
      var LoadDll = loaderPE.ExportedFunctions.First(f => f.Name.Equals("LoadDll", StringComparison.InvariantCultureIgnoreCase));
      var args = new IntPtr[isFramework ? 4 : 5];
      var i = 0;

      args[i++] = WriteString(processHandle, txt_DllPath.Text);
      
      if (!isFramework)
      {
        args[i++] = WriteString(processHandle, txt_RuntimeConfigPath.Text);
      }

      args[i++] = WriteString(processHandle, txt_Type.Text);
      args[i++] = WriteString(processHandle, txt_Method.Text);
      args[i] = WriteString(processHandle, txt_Arguement.Text);
      byte[] buffer = new byte[args.Length * IntPtr.Size];
      GCHandle handle = GCHandle.Alloc(args, GCHandleType.Pinned);
      Marshal.Copy(handle.AddrOfPinnedObject(), buffer, 0, buffer.Length);
      handle.Free();
      IntPtr argsPtr = Native.VirtualAllocEx(processHandle, IntPtr.Zero, buffer.Length, 0x3000, 0x04);
      Native.WriteProcessMemory(processHandle, argsPtr, buffer, buffer.Length, out _);
      Native.CreateRemoteThread(processHandle, IntPtr.Zero, 0, loaderModule.BaseAddress + (int)LoadDll.Address, argsPtr, 0, out _);
    }
  }
}
