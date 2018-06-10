using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Restarter : MonoBehaviour {

    public Text winningText;
    public Text losingText;
    public Button playAgainButton;
    private List<Transform> allBlobs;
    // Update is called once per frame
    void Update() {

    }

    public void lostGame() {

        playAgainButton.gameObject.SetActive(true);
        losingText.gameObject.SetActive(true);
    }
    public void wonGame()
    {
        playAgainButton.gameObject.SetActive(true);
        winningText.gameObject.SetActive(true);
    }
    public void saveTheBlobs(List<Transform> blobs)
    {
        allBlobs = blobs;
    }
    private int CalculateBlobs()
    {
        int counter = 0;

        foreach (Transform blob in allBlobs)
        {
            if (blob.GetComponent<BlobAgent>().inGoal)
            {
                counter++;
            }
        }
        return counter;
    }
}
