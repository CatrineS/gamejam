using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Restarter restartGame;
    private int score;


    // Use this for initialization
    void Start()
    {
        restartGame = GetComponent<Restarter>();
        score = GetComponent<CameraFollow>().BlobsSize();
        DisplayScore();
    }


    public void UpdateScore()
    {
        score--;
        if (score < 1)
        {
            restartGame.lostGame();

        }
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = "" + score;
    }


}
