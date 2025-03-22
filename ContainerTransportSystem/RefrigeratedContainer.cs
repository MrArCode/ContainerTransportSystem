namespace ContainerTransportSystem;

public class RefrigeratedContainer(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    SerialNumber? serialNumber,
    float maximumPayload,
    ProductType allowedProductType,
    float containerTemperature)
    : Container(cargoWeight, height, containerWeight, depth,
        serialNumber ?? new SerialNumber("C"), maximumPayload)
{
    private readonly List<Product> _products = [];
    private float _currentWeight;

    public void LoadProduct(Product product)
    {
        if (product.ProductType != allowedProductType)
        {
            throw new InvalidOperationException(
                $"Cannot load product of type {product.ProductType}. Container only allows {allowedProductType}");
        }

        if (product.MinimalTemperature < containerTemperature)
        {
            throw new InvalidOperationException(
                $"Container temperature ({containerTemperature}) is higher than required for product {product.ProductName} (requires {product.MinimalTemperature})");
        }

        if (_currentWeight + product.Weight > MaximumPayload)
        {
            throw new OverfillException($"Adding this product would exceed the maximum payload of {MaximumPayload}");
        }

        _products.Add(product);
        _currentWeight += product.Weight;
    }

    public override void Load(float payload)
    {
        throw new InvalidOperationException(
            "Refrigerated containers should be loaded with specific products using LoadProduct method");
    }

    public override void EmptyContainer()
    {
        _products.Clear();
        _currentWeight = 0;
    }

    public override string ToString()
    {
        return
            $"Refrigerated Container {serialNumber}, Product Type: {allowedProductType}, Temperature: {containerTemperature}°C, Products: {_products.Count}, Weight: {_currentWeight}kg/{MaximumPayload}kg";
    }
}