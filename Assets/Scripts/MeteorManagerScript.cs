using System.Collections;
using UnityEngine;

public class MeteorManagerScript : MonoBehaviour
{

    public float timeBetweenChecks = 2.5f;
    public int minMeteors = 10;
    public GameObject meteor;


    Camera cam;

    float cameraRight;
    float cameraLeft;
    float cameraTop;
    float cameraBottom;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        StartCoroutine("MeteorCheck");
        cameraTop = cam.transform.position.y + cam.orthographicSize;
        cameraBottom = cam.transform.position.y - cam.orthographicSize;
        float cameraWidth = cam.orthographicSize * cam.aspect;
        cameraRight = cam.transform.position.x + cameraWidth;
        cameraLeft = cam.transform.position.x - cameraWidth;
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
                int meteorScale = Random.Range(1, 5);
                GameObject newMeteor = Instantiate(meteor, new Vector3(cameraLeft, Random.Range(cameraBottom, cameraTop)), Quaternion.identity);

                newMeteor.GetComponent<MeteorScript>().scale = meteorScale;
                newMeteor.transform.position -= new Vector3(newMeteor.GetComponent<SpriteRenderer>().bounds.extents.x * meteorScale, 0);
            }

            yield return new WaitForSeconds(timeBetweenChecks);
        }
    }
}
