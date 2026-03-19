using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{

    public static MusicManagerScript instance;
    public AudioSource audioSource;
    public AudioClip ljud1;
    public AudioClip ljud2;
    bool isSong2Playing = false;
    PointsTextScript pts;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("MusicManager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        isSong2Playing = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ljud1;
        audioSource.Play();
        pts = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<PointsTextScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pts.score >= 50 && isSong2Playing == false)
        {
            audioSource.clip = ljud2;
            isSong2Playing = true;
            audioSource.Play();
        }
    }
}
