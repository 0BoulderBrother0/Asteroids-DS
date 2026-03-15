using UnityEngine;

public class CyclicScreenScript : MonoBehaviour
{

    Camera cam;
    SpriteRenderer sr;
    public float safeBuffer = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 objectPos = transform.position;

        float cameraTop = cam.transform.position.y + cam.orthographicSize;
        float cameraBottom = cam.transform.position.y - cam.orthographicSize;

        float objectHeight = sr.bounds.extents.y;
        float objectWidth = sr.bounds.extents.x;


        if (objectPos.y > cameraTop + objectHeight + safeBuffer)
        {
            objectPos.y = cameraBottom - objectHeight;
        }

        if (objectPos.y < cameraBottom - objectHeight - safeBuffer)
        {
            objectPos.y = cameraTop + objectHeight;
        }


        float cameraWidth = cam.orthographicSize * cam.aspect;
        float cameraRight = cam.transform.position.x + cameraWidth;
        float cameraLeft = cam.transform.position.x - cameraWidth;

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
