namespace ContainerTransportSystem;

public class ContainerShip(string name, float maxSpeed, int maxContainers, float maxWeight)
{
    private readonly List<Container> _containers = [];

    public string Name => name;
    public float MaxSpeed => maxSpeed;
    public int MaxContainers => maxContainers;
    public float MaxWeight => maxWeight;
    public IReadOnlyList<Container> Containers => _containers.AsReadOnly();

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= maxContainers)
        {
            throw new InvalidOperationException(
                $"Ship {name} is already at maximum container capacity ({maxContainers})");
        }

        var totalWeight = CalculateTotalWeight();
        if (totalWeight + container.CargoWeight > maxWeight)
        {
            throw new InvalidOperationException(
                $"Loading container would exceed the ship's maximum weight of {maxWeight}");
        }
        
        if (_containers.Exists(c => c.SerialNumber.ToString() == container.SerialNumber.ToString()))
        {
            throw new InvalidOperationException($"Container {container.SerialNumber} is already loaded on the ship");
        }

        _containers.Add(container);
    }

    public void LoadContainers(List<Container> containersToLoad)
    {
        foreach (var container in containersToLoad)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(SerialNumber serialNumber)
    {
        var container = FindContainer(serialNumber);
        if (container != null)
        {
            _containers.Remove(container);
        }
        else
        {
            throw new InvalidOperationException($"Container {serialNumber} is not on the ship");
        }
    }

    public void ReplaceContainer(SerialNumber oldSerialNumber, Container newContainer)
    {
        RemoveContainer(oldSerialNumber);
        LoadContainer(newContainer);
    }

    public void TransferContainer(ContainerShip targetShip, SerialNumber serialNumber)
    {
        var container = FindContainer(serialNumber);
        if (container != null)
        {
            _containers.Remove(container);
            targetShip.LoadContainer(container);
        }
        else
        {
            throw new InvalidOperationException($"Container {serialNumber} is not on the ship");
        }
    }
    
    public override string ToString()
    {
        return
            $"Ship: {name}, Speed: {maxSpeed} knots, Containers: {_containers.Count}/{maxContainers}, Weight: {CalculateTotalWeight()}/{maxWeight} tons";
    }

    public void PrintShipInfo()
    {
        Console.WriteLine(ToString());
        Console.WriteLine("Containers:");
        foreach (var container in _containers)
        {
            Console.WriteLine($"  - {container}");
        }
    }
    
    private Container? FindContainer(SerialNumber serialNumber)
    {
        return _containers.Find(c => c.SerialNumber.ToString() == serialNumber.ToString());
    }

    private float CalculateTotalWeight()
    {
        return _containers.Sum(container => container.CargoWeight);
    }
}