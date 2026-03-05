using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;
    
    public float thrust = 2;
    public float rotationSpeed = 50;
    public float maxSpeed = 15;

    [Header("Missile")]
    public GameObject missile;
    public float shotStrength = 20;
    public float missileLifeTime = 3;

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

        // rb.linearVelocity = Quaternion.Euler(0, 0, rb.rotation) * Vector2.down * rb.linearVelocity.magnitude;

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject newMissile = Instantiate(missile, transform.position + -transform.up * 3, Quaternion.identity);
            Rigidbody2D mrb = newMissile.GetComponent<Rigidbody2D>();
            mrb.rotation = rb.rotation + 180;
            mrb.AddRelativeForceY(shotStrength, ForceMode2D.Impulse);
            Destroy(newMissile, missileLifeTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("SampleScene");
    }
}
