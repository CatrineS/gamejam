using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    private Restarter restartGame;
    private int blobsAlive;


    // Use this for initialization
    void Start()
    {
        restartGame = GetComponent<Restarter>();
        blobsAlive = GetComponent<CameraFollow>().BlobsSize();
        DisplayScore();
    }


    public void UpdateScore()
    {
        blobsAlive--;

        if (blobsAlive < 1)
        {
            restartGame.LostGame();
        }

        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = "" + blobsAlive;
    }


}
