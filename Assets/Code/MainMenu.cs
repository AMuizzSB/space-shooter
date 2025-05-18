using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string sceneName;// Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnClickStart()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickExit()
    {
        Application.Quit();
        print("Exit was clicked");
    }
}
