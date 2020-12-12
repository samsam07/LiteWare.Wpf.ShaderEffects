# LiteWare.Wpf.ShaderEffects

**LiteWare.Wpf.ShaderEffects** is a library that provides custom WPF shader effects.

## Install

The library is available as a [Nuget Package](https://www.nuget.org/packages/LiteWare.Wpf.ShaderEffects/).

## Building shader effects

Building the project should automatically trigger the compilation of the shader effect files.
The behaviour is defined in the `ShaderCompiler.target` file.

The shader effect compiler `tools/fxc.exe` is used to compile the shader effect `.fx` files.
