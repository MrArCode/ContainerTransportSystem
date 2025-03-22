namespace ContainerTransportSystem;

public class GasContainer(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    SerialNumber serialNumber,
    float maximumPayload,
    float pressure = 1.0f)
    : Container(cargoWeight, height, containerWeight, depth, serialNumber ?? new SerialNumber("G"), maximumPayload),
        IHazardNotifier
{
    public float Pressure => pressure;

    public override void EmptyContainer()
    {
        // Keep 5% of cargo when emptying gas container
        cargoWeight = cargoWeight * 0.05f;
    }
        
    public void Notify()
    {
        Console.WriteLine($"The gas container {serialNumber} is a part of dangerous situation");
    }
        
    public override string ToString()
    {
        return $"Gas Container {serialNumber}, Cargo: {cargoWeight}kg, Max Payload: {maximumPayload}kg, Pressure: {pressure} atm";
    }
}