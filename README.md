# KDCLLCWeb
ASP.NET MVC, AngularJS, Idenity

### KDCLLC.Web project file modificaiton to include TypeScript Compiler 1.0
```sh
Place this in <PropertyGroup> top level
<!-- TypeScript -->
<TypeScriptToolsVersion>1.0</TypeScriptToolsVersion>

include the following script in all of the <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' "> for different enviroments
<!-- TypeScript -->
<TypeScriptTarget>ES5</TypeScriptTarget>
<TypeScriptSourceMap>true</TypeScriptSourceMap>
<TypeScriptModuleKind>AMD</TypeScriptModuleKind>
<TypeScriptOutFile>Scripts/app/app.js</TypeScriptOutFile>
'''
