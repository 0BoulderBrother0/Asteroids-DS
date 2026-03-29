using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class PointsTextScript : MonoBehaviour
{

    public static PointsTextScript instance;
    public int score;
    public bool isPlayingSong2;

    TextMeshProUGUI textMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        isPlayingSong2 = false;
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMeteorScore()
    {
        score++;
        textMeshPro.text = $"Score:\n{score}";
        if (score >= 50 && isPlayingSong2 == false)
        {
            MusicManagerScript.instance.audioSource.clip = MusicManagerScript.instance.secondSong;
            MusicManagerScript.instance.audioSource.Play();
            isPlayingSong2 = true;
        }
    }
}
