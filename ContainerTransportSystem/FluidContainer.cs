﻿namespace ContainerTransportSystem;

public class FluidContainer(
    float cargoWeight,
    float height,
    float containerWeight,
    float depth,
    SerialNumber serialNumber,
    float maximumPayload,
    bool isDangerPayload)
    : Container(cargoWeight, height, containerWeight, depth, serialNumber ?? new SerialNumber("L"), maximumPayload),
        IHazardNotifier
{
    public void Notify()
    {
        Console.WriteLine($"The fluid container {serialNumber} is a part of dangerous situation");
    }

    public override void LoadContainer(float payload)
    {
        float totalWeight = cargoWeight + payload;
        float levelOfFullFilled = totalWeight / maximumPayload * 100;

        if ((isDangerPayload && levelOfFullFilled > 50) ||
            (!isDangerPayload && levelOfFullFilled > 90))
        {
            Notify();
            throw new OverfillException($"Unsafe fill level for container {serialNumber}");
        }
            
        base.LoadContainer(payload);
    }
        
    public override string ToString()
    {
        return $"Fluid Container {serialNumber}, Cargo: {cargoWeight}kg, Max Payload: {maximumPayload}kg, Dangerous: {isDangerPayload}";
    }
}