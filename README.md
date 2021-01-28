# Inject.Net
Inject.Net is a dll injector which allows injecting .Net dlls into other processes. It supports injecting both 32-bit and 64-bit .Net Framework and .Net Core dlls.

It have been tested on .Net Framework 4.8 dll, but in theory it should work with all .Net Framework versions.

It have been tested on .Net 5 dll, but in theory it should work with .Net Core 3 and should not work with Net Core 2.

It is currently in an early, yet working, state and it have not been fairly tested.

## Reqiurements
- .Net 5.0
- .Net Framework 4.8
- PeNet 1.6.1

## Limitations
- For .Net Framework dlls, the entrypoint method should have the following signature `public static int Method(string arg)`
- For .Net Core dlls, the entrypoint method should have the following signature `public static int Method(IntPtr argPtr, int argLength)`, but this is an artificial limitation and can be worked around by modifying the `Inject.Net.Core.Loader`.

## Notes
- The Type parameter should be full type (namespace.classname). For .Net Core it should also have the assembly name (namespace.classname, assemblyname).

## Projects
#### Inject.Net
The GUI for the injector.

#### Inject.Net.Core.Loader
A native dll which loads the .Net Core runtime and exports a function `LoadDll` which can be called to load a .Net Core dll.

#### Inject.Net.Framework.Loader
A native dll which loads the .Net Framework runtime and exports a function `LoadDll` which can be called to load a .Net Framework dll.

#### Inject.Net.Core.Dll
A template .Net Core project for an injectable .Net dll.

#### Inject.Net.Framework.Dll
A template .Net Framework project for an injectable .Net dll.

#### Credits
- [Guided Hacking](https://guidedhacking.com/): For being a great source of knowledge.