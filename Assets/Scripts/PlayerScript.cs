// using Unity.Mathematics;
//using System.Numerics;
// using Unity.Mathematics;
using UnityEngine;
// using UnityEngine.Rendering.RenderGraphModule;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

    Rigidbody2D rb;
    
    public float thrust = 2;
    public float rotationSpeed = 50;
    public float maxSpeed = 15;
    public float recoil = 0.001f;

    ParticleSystem ps;

    [Header("Missile")]
    public GameObject missile;
    public float shotStrength = 20;
    public float missileLifeTime = 3;
    public AudioClip[] missileSounds;

    AudioSource audioSource;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (yAxis != 0)
        {
            if (ps.isStopped)
            {
                ps.Play();
            }
        }
        else
        {
            ps.Stop();
        }

        rb.AddRelativeForceY(-yAxis * thrust);

        rb.rotation += -xAxis * rotationSpeed * Time.deltaTime;

        rb.angularVelocity = 0;

        // rb.linearVelocity = Quaternion.Euler(0, 0, rb.rotation) * Vector2.down * rb.linearVelocity.magnitude;

        //Kontrollerar max hastighet
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.X))
        {
            audioSource.PlayOneShot(missileSounds[Random.Range(0, missileSounds.Length)]);
            GameObject newMissile = Instantiate(missile, transform.position + -transform.up * 3, Quaternion.Euler(0, 0, rb.rotation + 180));
            // Rigidbody2D mrb = newMissile.GetComponent<Rigidbody2D>();
            // mrb.rotation = rb.rotation + 180;
            newMissile.GetComponent<Rigidbody2D>().AddRelativeForceY(shotStrength, ForceMode2D.Impulse);
            Destroy(newMissile, missileLifeTime);

            rb.AddRelativeForceY(shotStrength * recoil, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene("MainGame");
        if (PointsTextScript.instance.isPlayingSong2)
        {
            MusicManagerScript.instance.audioSource.clip = MusicManagerScript.instance.firstSong;
            MusicManagerScript.instance.audioSource.Play();
        }
    }
}
