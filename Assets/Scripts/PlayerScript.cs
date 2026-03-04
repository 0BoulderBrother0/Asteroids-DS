using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;
    public float thrust = 2;
    public float rotationSpeed = 50;
    public float maxSpeed = 15;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        rb.AddRelativeForceY(-yAxis * thrust);

        rb.rotation += -xAxis * rotationSpeed * Time.deltaTime;

        rb.angularVelocity = 0;

        //rb.linearVelocity = Quaternion.Euler(0, 0, rb.rotation) * Vector2.down * rb.linearVelocity.magnitude;

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}
