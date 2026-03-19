using TMPro;
using UnityEngine;

public class PointsTextScript : MonoBehaviour
{


    public int score;

    TextMeshProUGUI textMeshPro;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMeteorScore()
    {
        score++;
        textMeshPro.text = $"Score:\n{score}";
    }
}
