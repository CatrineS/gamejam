using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public Button playAgainButton;
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
        if (score < 1)
        {
            playAgainButton.gameObject.SetActive(true);

        }
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreText.text = "" + score;
    }


}
