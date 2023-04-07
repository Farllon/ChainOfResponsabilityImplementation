using ChainOfResponsabilityImplementation;
using ChainOfResponsabilityImplementation.Middlewares;

var myApp = new MyApplication();

myApp.Use<CheckEnvironmentMiddleware>();

await myApp.Run(args);