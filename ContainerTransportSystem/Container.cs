namespace ContainerTransportSystem;

public abstract class Container(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    SerialNumber serialNumber,
    float maximumPayload)
{
    public float CargoWeight { get; protected set; } = cargoWeight;
    public float Height { get; private set; } = height;
    public float ContainerWeight { get; private set; } = containerWeight;
    public float Depth { get; private set; } = depth;
    public readonly SerialNumber SerialNumber = new("S");
    public float MaximumPayload { get; } = maximumPayload;


    public virtual void EmptyContainer()
    {
        CargoWeight = 0;
    }

    public virtual void Load(float payload)
    {
        if (payload > MaximumPayload)
        {
            throw new OverfillException($"Payload is too big for the container {serialNumber}");
        }

        CargoWeight = payload;
    }

    public override string ToString()
    {
        return $"Container {serialNumber}, Cargo: {CargoWeight}kg, Max Payload: {MaximumPayload}kg";
    }
}