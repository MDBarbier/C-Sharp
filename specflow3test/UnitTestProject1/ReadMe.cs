using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet472
{

    /*
     * Note .Net 4.7.2 required!
     * 
     * To get specflow v3 working with .NET framwork (i.e. not Core) I needed to install the nuget packages:
     * 
     * - SpecFlow (v3+)
     * - SpecFlow.Tools.MsBuild.Generation
     * - SpecRun.SpecFlow (this could be replaced with another test runner https://specflow.org/documentation/Unit-Test-Providers/)
     * 
     * I then needed to add a feature file as normal, but then I needed to select it and in the properties pane 
     * delete the value in the "Custom tool" property completely. When you apply this change the auto-gen feature file should vanish.
     * Then when you build the project, a new code behind will be created by MSBuild, but it will not be added to the project automatically.
     * 
     */
}
