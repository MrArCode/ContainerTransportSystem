namespace ContainerTransportSystem;

public class Container(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    SerialNumber serialNumber,
    float maximumPayload)
{
    protected float cargoWeight = cargoWeight;
    protected float height = height;
    protected float containerWeight = containerWeight;
    protected float depth = depth;
    protected SerialNumber serialNumber = serialNumber ?? new SerialNumber("S");
    protected float maximumPayload = maximumPayload;

    public SerialNumber SerialNumber => serialNumber;
    public float CargoWeight => cargoWeight;
    public float MaximumPayload => maximumPayload;

    public virtual void EmptyContainer()
    {
        cargoWeight = 0;
    }

    public virtual void LoadContainer(float payload)
    {
        if (payload > maximumPayload)
        {
            throw new OverfillException($"Payload is too big for the container {serialNumber}");
        }
            
        cargoWeight = payload;
    }
        
    public override string ToString()
    {
        return $"Container {serialNumber}, Cargo: {cargoWeight}kg, Max Payload: {maximumPayload}kg";
    }
}