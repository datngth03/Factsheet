﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Bundling;

namespace Sabeco_Factsheet.Blazor.Client;

/* Add your global styles/scripts here.
 * See https://docs.abp.io/en/abp/latest/UI/Blazor/Global-Scripts-Styles to learn how to use it
 */
public class Sabeco_FactsheetBundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
        context.Add("bootstrap-patch.js");
    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css", true); 
    }
}
