using UnityEngine;

public class VehicleSpawner : MonoBehaviour
{
    public void SpawnVehicle(GameObject vehicle)
    {
        Instantiate(vehicle, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }
}
