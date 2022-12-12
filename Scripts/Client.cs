using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Client : MonoBehaviour
{
    public Transform flyDrpDwn;
    public Transform sizeDrpDwn;
    public Transform fancyDrpDwn;

    public TextMeshProUGUI vehicleText;

    public GameObject scooter;
    public GameObject car;
    public GameObject hummer;
    public GameObject truck;
    public GameObject smallPlane;
    public GameObject helicopter;
    public GameObject airBaloon;
    public GameObject airliner;
    public GameObject fancySmallAir;
    public GameObject fancyMediumAir;
    public GameObject fancyLargeAir;
    public GameObject fancyXLargeAir;
    public GameObject fancySmallCar;
    public GameObject fancyMediumCar;
    public GameObject fancyLargeCar;
    public GameObject fancyXLargeCar;
    public VehicleSpawner spawner;


    private bool doesFly;
    private int vehicleSize;
    private bool isFancy;

    public void SpawnVehicle()
    {
        int temp;
        temp = flyDrpDwn.GetComponent<TMP_Dropdown>().value;
        if (temp == 0)
            doesFly = false;
        else
            doesFly = true;

        vehicleSize = sizeDrpDwn.GetComponent<TMP_Dropdown>().value;

        temp = fancyDrpDwn.GetComponent<TMP_Dropdown>().value;
        if (temp == 0)
            isFancy = true;
        else
            isFancy = false;

        VehicleRequirements requirements = new VehicleRequirements();
        requirements.doesFly = doesFly;
        requirements.vehicleSize = vehicleSize;
        requirements.isFancy = isFancy;

        IVehicle v = GetVehicle(requirements);
        vehicleText.text = v.ToString();

        if (v.ToString() == "Scooter") spawner.SpawnVehicle(scooter);
        else if (v.ToString() == "Car") spawner.SpawnVehicle(car);
        else if (v.ToString() == "Hummer") spawner.SpawnVehicle(hummer);
        else if (v.ToString() == "Truck") spawner.SpawnVehicle(truck);
        else if (v.ToString() == "SmallPlane") spawner.SpawnVehicle(smallPlane);
        else if (v.ToString() == "Helicopter") spawner.SpawnVehicle(helicopter);
        else if (v.ToString() == "AirBalloon") spawner.SpawnVehicle(airBaloon);
        else if (v.ToString() == "Airliner") spawner.SpawnVehicle(airliner);
        else if (v.ToString() == "F1Car") spawner.SpawnVehicle(fancySmallCar);
        else if (v.ToString() == "RacingCar") spawner.SpawnVehicle(fancyMediumCar);
        else if (v.ToString() == "Lambo") spawner.SpawnVehicle(fancyLargeCar);
        else if (v.ToString() == "CyberpunkCar") spawner.SpawnVehicle(fancyXLargeCar);
        else if (v.ToString() == "Scarab") spawner.SpawnVehicle(fancySmallAir);
        else if (v.ToString() == "AdvancedHelicopter") spawner.SpawnVehicle(fancyMediumAir);
        else if (v.ToString() == "FutureFighterPlane") spawner.SpawnVehicle(fancyLargeAir);
        else spawner.SpawnVehicle(fancyXLargeAir);
    }

    private static IVehicle GetVehicle(VehicleRequirements requirments)
    {
        VehicleFactory factory = new VehicleFactory(requirments);
        return factory.Create();
    }

}
