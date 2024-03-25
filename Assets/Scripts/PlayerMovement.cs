using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardForce = 1000f;
    // Reduced sideways force for better control
    public float sidewaysForce = 300f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply a constant forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            // Applying force with ForceMode.Force for smoother acceleration
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Force);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            // Applying force with ForceMode.Force for smoother acceleration
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.Force);
        }
    }
}
