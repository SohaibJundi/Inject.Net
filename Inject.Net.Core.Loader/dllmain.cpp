#define STRINGIFY_MACRO(x) STR(x)
#define STR(x) #x
#define EXPAND(x) x
#define COMBINE_PATH(path, file) STRINGIFY_MACRO(EXPAND(path)##file)

#ifdef WIN32
#define ARCH x86
#else
#define ARCH x64
#endif
#define RUNTIME 5.0.2 // Change this value depending on the version(s) available in "C:\Program Files\dotnet\packs\Microsoft.NETCore.App.Host.win-{ARCH}"
#define NETHOST_USE_AS_STATIC
#define LIB_PATH C:\\Program Files\\dotnet\\packs\\Microsoft.NETCore.App.Host.win-ARCH\\RUNTIME\\runtimes\\win-ARCH\\native/
#include COMBINE_PATH(LIB_PATH, nethost.h)
#include COMBINE_PATH(LIB_PATH, coreclr_delegates.h)
#include COMBINE_PATH(LIB_PATH, hostfxr.h)
#pragma comment(lib, COMBINE_PATH(LIB_PATH, libnethost.lib))
#include <Windows.h>

int LoadDll(LPCWSTR dll, LPCWSTR config, LPCWSTR type, LPCWSTR method, LPCWSTR arg)
{
    wchar_t buf[MAX_PATH];
    auto buf_len = sizeof(buf) / sizeof(wchar_t);
    get_hostfxr_path(buf, &buf_len, nullptr);
    const auto lib = LoadLibraryW(buf);
    hostfxr_handle cxt;
    const auto init = reinterpret_cast<hostfxr_initialize_for_runtime_config_fn>(GetProcAddress(lib, "hostfxr_initialize_for_runtime_config"));
    init(config, nullptr, &cxt);
    load_assembly_and_get_function_pointer_fn get_managed_function;
    const auto get_delegate = reinterpret_cast<hostfxr_get_runtime_delegate_fn>(GetProcAddress(lib, "hostfxr_get_runtime_delegate"));
    get_delegate(cxt, hdt_load_assembly_and_get_function_pointer, reinterpret_cast<void**>(&get_managed_function));
    const auto close = reinterpret_cast<hostfxr_close_fn>(GetProcAddress(lib, "hostfxr_close"));
    close(cxt);
    component_entry_point_fn method_fn;
    get_managed_function(dll, type, method, nullptr, nullptr, reinterpret_cast<void**>(&method_fn));

	return method_fn(const_cast<LPWSTR>(arg), wcslen(arg));
}

extern "C" __declspec(dllexport) int LoadDll(LPWSTR args[5])
{
    int result = LoadDll(args[0], args[1], args[2], args[3], args[4]);
    VirtualFree(args[4], 0, 0x8000);
    VirtualFree(args[3], 0, 0x8000);
    VirtualFree(args[2], 0, 0x8000);
    VirtualFree(args[1], 0, 0x8000);
    VirtualFree(args[0], 0, 0x8000);
    VirtualFree(args, 0, 0x8000);

    return result;
}

BOOL APIENTRY DllMain(HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved)
{
    return TRUE;
}
