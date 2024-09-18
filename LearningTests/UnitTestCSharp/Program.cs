using UnitTestCSharp.Tests;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

SimpleFunctionTests.SimpleFunctionTests_ReturnPikachuIfZero_ReturnString();

app.Run();
