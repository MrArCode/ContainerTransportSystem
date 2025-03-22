# Container Management System

## Overview
The Container Management System is a software application designed to manage the loading and transportation of containers. Containers can be transported via different vehicles such as ships, trains, and trucks. This system specifically focuses on loading containers onto container ships equipped with special guides for secure transportation.

## Container Types
The system supports different types of containers based on their cargo requirements:

- **Refrigerated Containers (C)**: Used for transporting temperature-sensitive goods such as bananas.
- **Fluid Containers (L)**: Designed to carry liquids, including hazardous (e.g., fuel) and non-hazardous (e.g., milk) substances.
- **Gas Containers (G)**: Used for transporting gases and storing pressure-related information.

### Common Features
All containers share the following characteristics:
- Cargo weight (kg)
- Height (cm)
- Container weight (kg)
- Depth (cm)
- Unique serial number (format: `KON-{Type}-{ID}`)
- Maximum payload (kg)
- Ability to be loaded and unloaded

## Container Rules
- If the load exceeds the container's capacity, an `OverfillException` is thrown.
- Containers with hazardous liquids can only be filled up to 50% of their capacity.
- Non-hazardous liquid containers can be filled up to 90% of their capacity.
- Gas containers retain 5% of their load when emptied.
- Temperature-sensitive products must be stored at an appropriate temperature.
- Containers can only store products of the same type.

## Hazard Notification
Containers handling hazardous materials implement the `IHazardNotifier` interface. This interface allows notification in case of a dangerous situation, including the container’s serial number.

## Container Ship
A container ship stores and transports multiple containers. It has:
- Maximum speed (knots)
- Maximum container capacity
- Maximum transportable weight (tons)
- A list of all carried containers

## Supported Operations
The application allows users to:
1. **Create different types of containers**
2. **Load cargo into containers**
3. **Load containers onto ships**
4. **Unload and replace containers**
5. **Transfer containers between ships**
6. **Retrieve container and ship information**

## Console Interface (Optional Feature)
A console interface can be implemented to simulate system operations. Example flow:
```
List of container ships:
None
List of containers:
None
Available actions:
1. Add a container ship
```
The system prompts for necessary details when adding containers and ships. Once added, users can load, remove, or transfer containers.

## Future Enhancements
- Improve UI for better user experience
- Implement database storage for tracking shipments
- Add simulation for container loading efficiency

