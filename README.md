# KDCLLC Web Project Template
ASP.NET MVC, AngularJS, ASP.NET Identity. Node.js

Custom template project for the enterprise usage.


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
```

### Visual Studio.NET 2013 and 2015 Extensions:


### Global Node.js packages to be installed:

- ```
 - npm install -g bower 
``` 
- ```sh
 - npm install -g grunt-cli 
```
- ``` - npm install -g gulp ```
