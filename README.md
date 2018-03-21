# Ninject Integration in WebApi 2 And Mvc5

**How to integrate Ninject in a WebApi 2 And Mvc5 Project**
<br>Test Mvc in Index page example url: "http://localhost/WebApiAndMvc5/mvctest/Index"
<br>Test Web Api 2 calling the Get Method "IsServiceUp" example url: "http://localhost/WebApiAndMvc5/IsServiceUp"
<br><br>
1. Create an Empty Web Application and select the checkboxes for Mvc and Web Api
2. Install Nuget Package: **Ninject.Web.WebApi.WebHost**, this package will install: Ninject, Ninject.Web.Common, Ninject.Web.Common.WebHost, Ninject.Web.WebApi, Ninject.Web.WebApi.WebHost but with the latest Release it won't create the "NinjectWebCommon" class in "App_Start" anymore, so you'll have to create it manually as explained 
further on.
3. Install Nuget Package: **WebActivatorEx**
4. Install Nuget Package: **Ninject.MVC5**, **this package is required for MVC** not for Web Api.
5. Create a class in **App_Start** named **NinjectWebCommon.cs**

		using Microsoft.Web.Infrastructure.DynamicModuleHelper;
		using Ninject;
		using Ninject.Web.Common;
		using Ninject.Web.Common.WebHost;
		using System;
		using System.Web;
                
        [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
        [assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

        namespace <YOURNAMESPACE>
        {
            public static class NinjectWebCommon
            {
                private static readonly Bootstrapper bootstrapper = new Bootstrapper();

                public static void Start()
                {
                    DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
                    DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
                    bootstrapper.Initialize(CreateKernel);
                }

                public static void Stop()
                {
                    bootstrapper.ShutDown();
                }

                private static IKernel CreateKernel()
                {
                    var kernel = new StandardKernel();
                    kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                    kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                    RegisterServices(kernel);
                    return kernel;
                }
                private static void RegisterServices(IKernel kernel)
                {
                  //kernel.Bind<IRepo>().ToMethod(ctx => new Repo("Ninject Rocks!"));
                }
            }
        }
5. Configure your DI in RegisterServices
6. Add dependency to Mvc or Web Api Controllers constructor parameters
