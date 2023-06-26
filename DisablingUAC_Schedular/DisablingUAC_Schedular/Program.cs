using DisablingUAC_Schedular;
using System.ServiceProcess;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var servicesToRun = new ServiceBase[] { new DisableUACcs() };
ServiceBase.Run(servicesToRun);