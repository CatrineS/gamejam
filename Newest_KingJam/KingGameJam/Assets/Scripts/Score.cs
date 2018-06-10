using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private int score;

    // Use this for initialization
    void Start()
    {
        score = GetComponent<CameraFollow>().BlobsSize();
        DisplayScore();
    }


    public void UpdateScore()
    {
        score--;
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = "" + score;
    }


}
