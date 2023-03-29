string[] menu = { "Get products", "get customers", "Test", "Test", "Test", };

for (int i = 0; i < menu.Length; i++)
{
    Console.WriteLine($"{i + 1}:  {menu[i]}.");
}


switch (InputValidation())
{
    case 1:
        Console.WriteLine("Case 1");
        break;

    case 2:
        Console.WriteLine("Case 2");
        break;

    case 3:
        Console.WriteLine("Case 3");
        break;

    case 4:
        Console.WriteLine("Case 4");
        break;

    case 5:
        Console.WriteLine("Case 5");
        break;

    default:

        break;
}


 int InputValidation()
{
    int input;
    int Rinput;
    bool Sucess = false;
    do
    {
        Console.Write("Input:");
        Sucess = int.TryParse(Console.ReadLine(), out input);
        if (!Sucess)
        {
            Console.WriteLine("Input type wrong. Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    } while (Sucess == false);
    
        Rinput = input;
    

    return Rinput;
}