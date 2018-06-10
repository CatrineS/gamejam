using UnityEngine;
using UnityEngine.UI;

public class Restarter : MonoBehaviour {

    public Text winningText;
    public Text losingText;
    public Button playAgainButton;

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
}
