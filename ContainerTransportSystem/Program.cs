using ContainerTransportSystem;

try
{
    // Create ships
    var ship1 = new ContainerShip("Hobbit", 25.5f, 500, 50000);
    var ship2 = new ContainerShip("Dragon", 28.0f, 750, 75000);

    // Create containers
    var fluidContainer = new FluidContainer(0, 250, 2500, 600, null, 25000, true);
    var gasContainer = new GasContainer(0, 250, 3000, 600, 20000);

    // Create refrigerated container for dairy products
    var dairyContainer = new RefrigeratedContainer(0, 250, 3500, 600, null, 15000, ProductType.Dairy, 4.0f);

    // Create products
    var milk = new Product("Milk", ProductType.Dairy, 6.0, 5000);
    var yogurt = new Product("Yogurt", ProductType.Dairy, 5.0, 4000);
    var banana = new Product("Banana", ProductType.Fruits, 12.0, 3000);

    // Load products into refrigerated container
    Console.WriteLine("Loading dairy products into refrigerated container...");
    dairyContainer.LoadProduct(milk);
    dairyContainer.LoadProduct(yogurt);

    try
    {
        Console.WriteLine("Attempting to load bananas into dairy container...");
        dairyContainer.LoadProduct(banana);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    // Load cargo into other containers
    fluidContainer.Load(10000);
    gasContainer.Load(15000);

    // Load containers onto ships
    Console.WriteLine("\nLoading containers onto ships...");
    ship1.LoadContainer(fluidContainer);
    ship2.LoadContainer(gasContainer);
    ship2.LoadContainer(dairyContainer);

    // Print ship information
    Console.WriteLine("\nShip information:");
    ship1.PrintShipInfo();
    Console.WriteLine();
    ship2.PrintShipInfo();

    // Transfer container between ships
    Console.WriteLine("\nTransferring fluid container from ship1 to ship2...");
    ship1.TransferContainer(ship2, fluidContainer.SerialNumber);

    // Print updated ship information
    Console.WriteLine("\nUpdated ship information:");
    ship1.PrintShipInfo();
    Console.WriteLine();
    ship2.PrintShipInfo();

    // Empty containers
    Console.WriteLine("\nEmptying gas container...");
    gasContainer.EmptyContainer();
    Console.WriteLine($"Gas container after emptying: {gasContainer}");

    Console.WriteLine("\nEmptying refrigerated container...");
    dairyContainer.EmptyContainer();
    Console.WriteLine($"Refrigerated container after emptying: {dairyContainer}");
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}