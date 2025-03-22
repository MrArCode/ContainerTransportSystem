namespace ContainerTransportSystem;

public class Product(string productName, ProductType productType, double minimalTemperature, float weight)
{
    public string ProductName => productName;
    public ProductType ProductType => productType;
    public double MinimalTemperature => minimalTemperature;
    public float Weight => weight;
}