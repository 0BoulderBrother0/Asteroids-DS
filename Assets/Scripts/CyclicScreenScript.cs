using UnityEngine;

public class CyclicScreenScript : MonoBehaviour
{

    Camera cam;
    SpriteRenderer sr;
    public float safeBuffer = 0.01f;

    float cameraRight;
    float cameraLeft;
    float cameraTop;
    float cameraBottom;

    float objectHeight;
    float objectWidth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();

        cameraTop = cam.transform.position.y + cam.orthographicSize;
        cameraBottom = cam.transform.position.y - cam.orthographicSize;
        float cameraWidth = cam.orthographicSize * cam.aspect;
        cameraRight = cam.transform.position.x + cameraWidth;
        cameraLeft = cam.transform.position.x - cameraWidth;

        objectHeight = sr.bounds.extents.y;
        objectWidth = sr.bounds.extents.x;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 objectPos = transform.position;


        if (objectPos.y > cameraTop + objectHeight + safeBuffer)
        {
            objectPos.y = cameraBottom - objectHeight;
        }

        if (objectPos.y < cameraBottom - objectHeight - safeBuffer)
        {
            objectPos.y = cameraTop + objectHeight;
        }



        if (objectPos.x > cameraRight + objectWidth + safeBuffer)
        {
            objectPos.x = cameraLeft - objectWidth;
        }

        if (objectPos.x < cameraLeft - objectWidth - safeBuffer)
        {
            objectPos.x = cameraRight + objectWidth;
        }

        transform.position = objectPos;

    }
}
