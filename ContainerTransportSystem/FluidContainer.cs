namespace ContainerTransportSystem;

public class FluidContainer(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    SerialNumber? serialNumber,
    float maximumPayload,
    bool isDangerPayload)
    : Container(cargoWeight, height, containerWeight, depth, serialNumber ?? new SerialNumber("L"), maximumPayload),
        IHazardNotifier
{
    public void Notify()
    {
        Console.WriteLine($"The fluid container {serialNumber} is a part of dangerous situation");
    }

    public override void Load(float payload)
    {
        var totalWeight = CargoWeight + payload;
        var levelOfFullFilled = totalWeight / MaximumPayload * 100;

        if ((isDangerPayload && levelOfFullFilled > 50) ||
            (!isDangerPayload && levelOfFullFilled > 90))
        {
            Notify();
        }
            
        base.Load(payload);
    }
        
    public override string ToString()
    {
        return $"Fluid Container {serialNumber}, Cargo: {CargoWeight}kg, Max Payload: {MaximumPayload}kg, Dangerous: {isDangerPayload}";
    }
}