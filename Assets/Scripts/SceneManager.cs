using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void RestartGame()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
