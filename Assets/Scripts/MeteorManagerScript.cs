using System.Collections;
using UnityEngine;

public class MeteorManagerScript : MonoBehaviour
{

    public float timeBetweenChecks = 3;
    public int minMeteors = 3;
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
                Instantiate(meteor, Vector3.zero, Quaternion.identity);
            }

            yield return new WaitForSeconds(timeBetweenChecks);
        }
    }
}
