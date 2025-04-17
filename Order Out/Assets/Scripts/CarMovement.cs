using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveForce = 5f;
    public float turnSpeed = 5f;

    private Rigidbody rb;

    //Input Variables
    float moveInput;
    float turnInput;

    public GameObject pizza;
    public Restaurant restaurant;
    public bool hasOrder = false;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        if(restaurant.GetActiveDestiation()!= null)
        {
            pizza.transform.LookAt(restaurant.GetActiveDestiation().transform);
        }
        
    }
    void FixedUpdate()
    {
        //Move Forward/Backward
        Vector3 move = transform.forward * moveInput * moveForce;
        rb.AddForce(move, ForceMode.Acceleration);

        //Turn
        if (rb.linearVelocity.magnitude > 0.1f)
        {
            float direction;

            if (Vector3.Dot(rb.linearVelocity, transform.forward) >= 0)
            {
                direction = 1f;
            }
            else
            {
                direction = -1f;
            }

            float turn = turnInput * turnSpeed * Time.fixedDeltaTime * direction;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            rb.MoveRotation(rb.rotation * turnRotation);
        }
    }
    public void TakeOrder()
    {
        pizza.SetActive(true);
        hasOrder = true;
    }
    public void OrderDelivered()
    {
        pizza.SetActive(false);
        hasOrder = false;
        SoundManager.Instance.PlaySFX(SoundManager.Instance.complete);
        restaurant.score++;
    }
}
