namespace ContainerTransportSystem;

public class FluidContainer : Container
{
    private readonly bool _isDangerPayload;
    
    public FluidContainer(float cargoWeight, float height, float containerWeight, float depth, float maximumPayload, bool isDangerPayload)
        : base(cargoWeight, height, containerWeight, depth, maximumPayload)
    {
        SerialNumber = new SerialNumber("L");
        _isDangerPayload = isDangerPayload;
    }

    public void Notify()
    {
        Console.WriteLine($"The fluid container {SerialNumber} is a part of dangerous situation");
    }

    public override void Load(float payload)
    {
        var totalWeight = CargoWeight + payload;
        var levelOfFullFilled = totalWeight / MaximumPayload * 100;

        if ((_isDangerPayload && levelOfFullFilled > 50) ||
            (!_isDangerPayload && levelOfFullFilled > 90))
        {
            Notify();
        }
            
        base.Load(payload);
    }
        
    public override string ToString()
    {
        return $"Fluid Container {SerialNumber}, Cargo: {CargoWeight}kg, Max Payload: {MaximumPayload}kg, Dangerous: {_isDangerPayload}";
    }
}