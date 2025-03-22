namespace ContainerTransportSystem;

public class RefrigeratedContainer(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    SerialNumber serialNumber,
    float maximumPayload,
    ProductType allowedProductType,
    float containerTemperature)
    : Container(cargoWeight, height, containerWeight, depth,
        serialNumber ?? new SerialNumber("C"), maximumPayload)
{
    private List<Product> products = new List<Product>();
        private float currentWeight = 0;

        public ProductType AllowedProductType => allowedProductType;
        public float ContainerTemperature => containerTemperature;
        public IReadOnlyList<Product> Products => products.AsReadOnly();

        public void LoadProduct(Product product)
        {
            // Check if product type matches container's allowed type
            if (product.ProductType != allowedProductType)
            {
                throw new InvalidOperationException($"Cannot load product of type {product.ProductType}. Container only allows {allowedProductType}");
            }

            // Check temperature requirements
            if (product.MinimalTemperature < containerTemperature)
            {
                throw new InvalidOperationException($"Container temperature ({containerTemperature}) is higher than required for product {product.ProductName} (requires {product.MinimalTemperature})");
            }

            // Check if adding this product would exceed maximum payload
            if (currentWeight + product.Weight > maximumPayload)
            {
                throw new OverfillException($"Adding this product would exceed the maximum payload of {maximumPayload}");
            }

            // Add product to container
            products.Add(product);
            currentWeight += product.Weight;
            cargoWeight = currentWeight;
        }

        public override void LoadContainer(float payload)
        {
            throw new InvalidOperationException("Refrigerated containers should be loaded with specific products using LoadProduct method");
        }

        public override void EmptyContainer()
        {
            products.Clear();
            currentWeight = 0;
            cargoWeight = 0;
        }
        
        public override string ToString()
        {
            return $"Refrigerated Container {serialNumber}, Product Type: {allowedProductType}, Temperature: {containerTemperature}°C, Products: {products.Count}, Weight: {currentWeight}kg/{maximumPayload}kg";
        }
    }