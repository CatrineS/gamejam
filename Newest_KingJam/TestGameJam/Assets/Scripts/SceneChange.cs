using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    public static SceneChange instance = null;

    public bool WonGame = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void changeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
    public void reStartScene()
    {
        int currentSceneNumber = SceneManager.GetActiveScene().buildIndex;
        changeScene(currentSceneNumber);
    }

    public void ClickedQuit()
    {
        if (WonGame)
        {
            
            //Text som kommer upp
        }

        changeScene(0);
    }	
}
