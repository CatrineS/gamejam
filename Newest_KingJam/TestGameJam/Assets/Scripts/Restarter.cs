using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class Restarter : MonoBehaviour {

    public Text winningText;
    public Text losingText;
    public Button playAgainButton;
    public Button quitButton;
    private List<Transform> allBlobs;

    private bool gameIsOver = false;

    [SerializeField] private int blobSavedCounter = 0;
    [SerializeField] private int blobDiedCounter = 0;
    [SerializeField] private int totalBlobCounter = 0;
  
    private void CheckGameOver()
    {
        if (gameIsOver)
            return;   
        else if ((blobSavedCounter + blobDiedCounter) == totalBlobCounter)
        {
            if (blobSavedCounter > 0)
            {
                WonGame();
            }             
            else if (blobSavedCounter == 0)
            {
                LostGame();
            }                 
        }
    }

    public void LostGame()
    {
        playAgainButton.gameObject.SetActive(true);
        losingText.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        gameIsOver = true;
    }

    public void WonGame()
    {
        winningText.text = blobSavedCounter + " blobs survived!";
        winningText.gameObject.SetActive(true);
        playAgainButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        SceneChange.instance.WonGame = true;
        gameIsOver = true;
    }

    public void SetBlobList(List<Transform> blobs)
    {
        allBlobs = blobs;

        foreach(Transform blob in allBlobs)
        {
            BlobAgent blobAgent = blob.GetComponent<BlobAgent>();
            blobAgent.blobSaved += BlobSaved;
            blobAgent.blobDied += BlobDied;         
        }

        totalBlobCounter = allBlobs.Count;
    }

    private bool CalculateBlobsAlive()
    {
        foreach(Transform blob in allBlobs)
        {
            if(blob.GetComponent<BlobAgent>().state == BlobAgent.BlobState.Alive)
            {
                return false;
            }
        }
        return true;
    }

    private int CalculateSavedBlobs()
    {
        int counter = 0;

        foreach (Transform blob in allBlobs)
        {
            if (blob.GetComponent<BlobAgent>().state == BlobAgent.BlobState.InGoal)
            {
                counter++;
            }
        }
        return counter;
    }


    public void BlobSaved(BlobAgent blobAgent)
    {
        blobSavedCounter++;
        blobAgent.state = BlobAgent.BlobState.InGoal;
        CheckGameOver();
    }

    public void BlobDied(BlobAgent blobAgent)
    {
        blobDiedCounter++;
        blobAgent.state = BlobAgent.BlobState.Dead;
        CheckGameOver();
    }
}
