#include <metahost.h>
#pragma comment(lib, "mscoree.lib")

DWORD LoadDll(LPCWSTR dll, LPCWSTR type, LPCWSTR method, LPCWSTR arg)
{
    ICLRMetaHost* pMetaHost;
    CLRCreateInstance(CLSID_CLRMetaHost, IID_PPV_ARGS(&pMetaHost));
    ICLRRuntimeInfo* pRuntimeInfo;
    pMetaHost->GetRuntime(L"v4.0.30319", IID_PPV_ARGS(&pRuntimeInfo));
    ICLRRuntimeHost* pClrRuntimeHost;
    pRuntimeInfo->GetInterface(CLSID_CLRRuntimeHost, IID_PPV_ARGS(&pClrRuntimeHost));
    pClrRuntimeHost->Start();
    DWORD return_value;
    pClrRuntimeHost->ExecuteInDefaultAppDomain(dll, type, method, arg, &return_value);
    pMetaHost->Release();
    pRuntimeInfo->Release();
    pClrRuntimeHost->Release();

    return return_value;
}

extern "C" __declspec(dllexport) DWORD LoadDll(LPWSTR args[4])
{
    DWORD result = LoadDll(args[0], args[1], args[2], args[3]);
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
