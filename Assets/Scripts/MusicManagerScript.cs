using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{

    public static MusicManagerScript instance;
    public AudioSource audioSource;
    public AudioClip firstSong;
    public AudioClip secondSong;


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
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
