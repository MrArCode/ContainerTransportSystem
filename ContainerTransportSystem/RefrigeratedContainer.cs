namespace ContainerTransportSystem;

public class RefrigeratedContainer : Container
{
    private readonly List<Product> _products = [];
    private float _currentWeight;

    public RefrigeratedContainer(float cargoWeight,
        float height,
        float containerWeight,
        float depth,
        float maximumPayload,
        ProductType allowedProductType,
        float containerTemperature)
        : base(cargoWeight, height, containerWeight, depth, maximumPayload)
    {
        AllowedProductType = allowedProductType;
        ContainerTemperature = containerTemperature;
        SerialNumber = new SerialNumber("C");
    }

    private ProductType AllowedProductType { get; }
    private float ContainerTemperature { get; }


    public void LoadProduct(Product product)
    {
        if (product.ProductType != AllowedProductType)
        {
            throw new InvalidOperationException(
                $"Cannot load product of type {product.ProductType}. Container only allows {AllowedProductType}");
        }

        if (product.MinimalTemperature < ContainerTemperature)
        {
            throw new InvalidOperationException(
                $"Container temperature ({ContainerTemperature}) is higher than required for product {product.ProductName} (requires {product.MinimalTemperature})");
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
            $"Refrigerated Container {SerialNumber}, Product Type: {AllowedProductType}, Temperature: {ContainerTemperature}°C, Products: {_products.Count}, Weight: {_currentWeight}kg/{MaximumPayload}kg";
    }
}