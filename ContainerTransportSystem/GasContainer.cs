namespace ContainerTransportSystem;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(float cargoWeight, float height, float containerWeight, float depth, float maximumPayload)
        : base(cargoWeight, height, containerWeight, depth, maximumPayload)
    {
        SerialNumber = new SerialNumber("G");
    }

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