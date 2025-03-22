namespace ContainerTransportSystem;

public class GasContainer(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    float maximumPayload)
    : Container(cargoWeight, height, containerWeight, depth, new SerialNumber("G"), maximumPayload),
        IHazardNotifier
{
    public override void EmptyContainer()
    {
        CargoWeight *= 0.05f;
    }

    public void Notify()
    {
        Console.WriteLine($"The gas container {SerialNumber} is a part of dangerous situation");
    }

    public override string ToString()
    {
        return $"Gas Container {SerialNumber}, Cargo: {CargoWeight}kg, Max Payload: {MaximumPayload}kg.";
    }
}