namespace ContainerTransportSystem;

public abstract class Container(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    float maximumPayload)
{
    public float CargoWeight { get; protected set; } = cargoWeight;
    public float Height { get; private set; } = height;
    public float ContainerWeight { get; private set; } = containerWeight;
    public float Depth { get; private set; } = depth;
    public float MaximumPayload { get; } = maximumPayload;
    
    public SerialNumber SerialNumber { get; protected init; } = null!;

    public virtual void EmptyContainer()
    {
        CargoWeight = 0;
    }

    public virtual void Load(float payload)
    {
        if (payload > MaximumPayload)
        {
            throw new OverfillException($"Payload is too big for the container {SerialNumber}");
        }

        CargoWeight = payload;
    }

    public override string ToString()
    {
        return $"Container {SerialNumber}, Cargo: {CargoWeight}kg, Max Payload: {MaximumPayload}kg";
    }
}