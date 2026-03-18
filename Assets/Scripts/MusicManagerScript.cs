using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{

    public static MusicManagerScript instance;
    public AudioSource audioSource;
    public AudioClip ljud1;
    public AudioClip ljud2;
    public bool isSong1Playing = true;


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
        audioSource.clip = ljud1;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (isSong1Playing)
            {
                audioSource.clip = ljud1;
            }
            else
            {
                audioSource.clip = ljud2;
            }

            audioSource.Play();
            isSong1Playing = !isSong1Playing;
        }
    }
}
