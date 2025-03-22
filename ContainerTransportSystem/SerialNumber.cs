using System.Numerics;

namespace ContainerTransportSystem;

public class SerialNumber
{
    private static BigInteger _number = 1;
    private const string ContainerName = "KON";
        
    private readonly string _serialNumber;
    private string _containerType;

    public SerialNumber(string containerType)
    {
        _serialNumber = ContainerName + "-" + containerType + "-" + _number;
        _containerType = containerType;
        _number += 1;
    }

    public override string ToString()
    {
        return _serialNumber;
    }
}