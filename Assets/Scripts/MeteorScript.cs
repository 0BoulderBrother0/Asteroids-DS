// using Unity.Mathematics;
// using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorScript : MonoBehaviour
{

    public float HP = 2;
    public float scale = 3;
    public float meteorVelocityDecline = 0.1f;
    public float startVelocity = 2;
    public float splitSpeed = 2;
    public AudioClip hitSound;
    public GameObject explosion;



    Vector3 missileVelocity;
    Rigidbody2D rb;
    AudioSource audioSource;
    SpriteRenderer sr;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.localScale = new Vector3(scale, scale);
        HP = scale;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity += Random.insideUnitCircle * startVelocity;
        audioSource = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        sr.sortingOrder = (Mathf.RoundToInt(1 / scale) * 1000) + Random.Range(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            if (scale >= 1.5f)
            {
                GameObject newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
                newExplosion.GetComponent<TraumaInducer>().MaximumStress = scale * 0.15f;
            
                for (int i = 0; i < 2; i++)
                {
                    GameObject newMeteor = Instantiate(gameObject, transform.position, Quaternion.identity);
                    Rigidbody2D newMRB = newMeteor.GetComponent<Rigidbody2D>();
                    MeteorScript newMS = newMeteor.GetComponent<MeteorScript>();
                    newMS.scale = scale - 1;

                    newMRB.linearVelocity += new Vector2(missileVelocity.x * meteorVelocityDecline, missileVelocity.y * meteorVelocityDecline) + new Vector2(rb.linearVelocityX, rb.linearVelocityY);
                    
                    if (i == 0)
                    {
                        newMRB.linearVelocity += new Vector2(-missileVelocity.y, missileVelocity.x).normalized * splitSpeed;
                    }
                    else
                    {
                        newMRB.linearVelocity += new Vector2(missileVelocity.y, -missileVelocity.x).normalized * splitSpeed;
                    }
                }
                Destroy(newExplosion, 2);
            }

            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Missile"))
        {
            missileVelocity = collision.gameObject.GetComponent<Rigidbody2D>().linearVelocity;
            HP--;
            audioSource.PlayOneShot(hitSound);
            Destroy(collision.gameObject);
        }
    }
}
