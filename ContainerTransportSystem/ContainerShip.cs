namespace ContainerTransportSystem;

public class ContainerShip(string name, float maxSpeed, int maxContainers, float maxWeight)
{
    private List<Container> containers = new List<Container>();

        public string Name => name;
        public float MaxSpeed => maxSpeed;
        public int MaxContainers => maxContainers;
        public float MaxWeight => maxWeight;
        public IReadOnlyList<Container> Containers => containers.AsReadOnly();

        public void LoadContainer(Container container)
        {
            if (containers.Count >= maxContainers)
            {
                throw new InvalidOperationException($"Ship {name} is already at maximum container capacity ({maxContainers})");
            }

            float totalWeight = CalculateTotalWeight();
            if (totalWeight + container.CargoWeight > maxWeight)
            {
                throw new InvalidOperationException($"Loading container would exceed the ship's maximum weight of {maxWeight}");
            }

            // Check if container is already loaded
            if (containers.Exists(c => c.SerialNumber.ToString() == container.SerialNumber.ToString()))
            {
                throw new InvalidOperationException($"Container {container.SerialNumber} is already loaded on the ship");
            }

            containers.Add(container);
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
                containers.Remove(container);
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
                containers.Remove(container);
                targetShip.LoadContainer(container);
            }
            else
            {
                throw new InvalidOperationException($"Container {serialNumber} is not on the ship");
            }
        }

        public Container FindContainer(SerialNumber serialNumber)
        {
            return containers.Find(c => c.SerialNumber.ToString() == serialNumber.ToString());
        }

        private float CalculateTotalWeight()
        {
            float totalWeight = 0;
            foreach (var container in containers)
            {
                totalWeight += container.CargoWeight;
            }
            return totalWeight;
        }
        
        public override string ToString()
        {
            return $"Ship: {name}, Speed: {maxSpeed} knots, Containers: {containers.Count}/{maxContainers}, Weight: {CalculateTotalWeight()}/{maxWeight} tons";
        }

        public void PrintShipInfo()
        {
            Console.WriteLine(ToString());
            Console.WriteLine("Containers:");
            foreach (var container in containers)
            {
                Console.WriteLine($"  - {container}");
            }
        }
    }