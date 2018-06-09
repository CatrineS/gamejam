using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

    public void changeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }
	
}
