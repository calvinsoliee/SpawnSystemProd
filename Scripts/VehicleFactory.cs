using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVehicleFactory
{
    IVehicle Create(VehicleRequirements requirements);
}

public class SmallVehicleFactory : MonoBehaviour, IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        if (requirements.doesFly)
        {
            if (requirements.isFancy)
            {
                return new Scarab();
            }
            else return new SmallPlane();
        }
        else
        {
            if (requirements.isFancy)
                return new F1Car();
            else
                return new Scooter();
        }
    }
}

public class MediumVehicleFactory : MonoBehaviour, IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        if (requirements.doesFly)
        {
            if (requirements.isFancy)
            {
                return new AdvancedHelicopter();
            }
            else return new Helicopter();
        }
        else
        {
            if (requirements.isFancy)
                return new RacingCar();
            else
                return new Car();
        }
    }
}

public class LargeVehicleFactory : MonoBehaviour, IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        if (requirements.doesFly)
        {
            if (requirements.isFancy)
            {
                return new FutureFighterPlane();
            }
            else return new AirBalloon();
        }
        else
        {
            if (requirements.isFancy)
                return new Lambo();
            else
                return new Hummer();
        }
    }
}

public class XLargeVehicleFactory : MonoBehaviour, IVehicleFactory
{
    public IVehicle Create(VehicleRequirements requirements)
    {
        if (requirements.doesFly)
        {
            if (requirements.isFancy)
            {
                return new StealthBomber();
            }
            else return new Airliner();
        }
        else
        {
            if (requirements.isFancy)
                return new CyberpunkCar();
            else
                return new Truck();
        }
    }
}

public abstract class AbstractVehicleFactory
{
    public abstract IVehicle Create();
}

public class VehicleFactory : AbstractVehicleFactory
{
    private readonly IVehicleFactory _factory;
    private readonly VehicleRequirements _requirements;

    public VehicleFactory(VehicleRequirements requirements)
    {
        if (requirements.vehicleSize == 0) _factory = (IVehicleFactory) new SmallVehicleFactory();
        if (requirements.vehicleSize == 1) _factory = (IVehicleFactory) new MediumVehicleFactory();
        if (requirements.vehicleSize == 2) _factory = (IVehicleFactory) new LargeVehicleFactory();
        else _factory = (IVehicleFactory) new XLargeVehicleFactory();
        _requirements = requirements;
    }

    public override IVehicle Create()
    {
        return _factory.Create(_requirements);
    }
}