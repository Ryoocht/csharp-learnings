namespace UnitTestCSharp.Tests;

public class SimpleFunctionTests
{
    public static void SimpleFunctionTests_ReturnPikachuIfZero_ReturnString()
    {
        try
        {
            // Arrange - Go get your variables, whatever you need, your classes, go get them.
            int num = 0;
            SimpleFunction simpleFunction = new();

            // Act - Execute the function
            string result = simpleFunction.ReturnPokemonName(num);

            // Assert - Whatever is returned is what you want.
            if (result == "PIKACHU!") Console.WriteLine("PASSED: WorldDumbestFunction_ReturnPikachuIfZero_ReturnString");
            else Console.WriteLine("FAILED: WorldDumbestFunction_ReturnPikachuIfZero_ReturnString");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}