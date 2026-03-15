using System.Collections;
using UnityEngine;

public class MeteorManagerScript : MonoBehaviour
{

    public float timeBetweenChecks = 3;
    public int minMeteors = 5;
    public GameObject meteor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("MeteorCheck");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        
    IEnumerator MeteorCheck()
    {
        while (true)
        {
            GameObject[] meteors = GameObject.FindGameObjectsWithTag("Meteor");

            if (meteors.Length < minMeteors)
            { 
                GameObject newMeteor = Instantiate(meteor, new Vector3(Random.Range(0, 1920), Random.Range(0, 1080)), Quaternion.identity);

                newMeteor.GetComponent<MeteorScript>().scale = Random.Range(1, 4);
                newMeteor.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-5, 5), Random.Range(-5, 5)), ForceMode2D.Impulse);
            }

            yield return new WaitForSeconds(timeBetweenChecks);
        }
    }
}
