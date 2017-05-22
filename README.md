# Extensions for using Grace in ASP.Net Core

Using Grace in an ASP.Net Core application is really simple, add the [Grace.AspNetCore.Hosting](https://www.nuget.org/packages/Grace.AspNetCore.Hosting) package. Then add the following to your project

Program.cs
```
var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseGrace()  // add grace
                .UseStartup<Startup>()
                .Build();
```

Startup.cs
```
public void ConfigureServices(IServiceCollection services)
{
  services.AddMvc();
}

// add this method
public void ConfigureContainer(IInjectionScope scope)
{
  
}
```

Grace provides custom controller and view activators providing better performance some custom features. 

Add the [Grace.AspNetCore.MVC](https://www.nuget.org/packages/Grace.AspNetCore.MVC) nuget package.

Startup.cs
```
public void ConfigureContainer(IInjectionScope scope)
{
  scope.SetupMvc();
}
```
[![Build status](https://ci.appveyor.com/api/projects/status/r8oneht7oenf2p5a?svg=true)](https://ci.appveyor.com/project/ipjohnson/grace-dependencyinjection-extensions) [![Build Status](https://travis-ci.org/ipjohnson/Grace.DependencyInjection.Extensions.svg?branch=master)](https://travis-ci.org/ipjohnson/Grace.DependencyInjection.Extensions)
