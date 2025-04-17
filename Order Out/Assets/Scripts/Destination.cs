using UnityEngine;

public class Destination : MonoBehaviour
{
    public CarMovement car;
    private bool isActive = false;
    public GameObject visual;


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && isActive)
        {
            print("Arrived");
            SetActive(false);
            car.OrderDelivered();
        }
    }
    public void SetActive(bool state)
    {
        isActive = state;
        visual.SetActive(state);
    }
    public bool IsActive()
    {
        return isActive;
    }
}
