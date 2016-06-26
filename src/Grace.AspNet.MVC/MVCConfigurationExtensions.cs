﻿using Grace.AspNet.MVC.Inspectors;
using Grace.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grace.AspNet.MVC
{


    public class GraceMVCConfiguration
    {
        public GraceMVCConfiguration()
        {
            UseControllerActivator = true;
            UseViewActivator = true;
            SupportHttpInfoInjection = true;
        }

        public bool UseControllerActivator { get; set; }

        public bool UseViewActivator { get; set; }
        
        public bool SupportHttpInfoInjection { get; set; }
        
    }

    public static class MVCConfigurationExtensions
    {
        public static void SetupMvc(this IExportLocator locator, Action<GraceMVCConfiguration> configure = null)
        {
            var configuration = new GraceMVCConfiguration();

            configure?.Invoke(configuration);
            
            if (configuration.SupportHttpInfoInjection)
            {
                locator.AddStrategyInspector(new ExportPropertyInspector());
                locator.AddInjectionValueProviderInspector(new FromAttributeValueProviderInspector());
            }

            locator.Configure(c =>
            {
                if (configuration.UseControllerActivator)
                {
                    c.Export<GraceControllerActivator>().As<IControllerActivator>().WithPriority(10).Lifestyle.Singleton();
                }

                if(configuration.UseViewActivator)
                {
                    c.Export<GraceViewActivator>().As<IViewComponentActivator>().WithPriority(10).Lifestyle.Singleton();
                }                
            });
        }
    }
}
