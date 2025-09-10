using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneScript : MonoBehaviour
{


    public void onPlayClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void onHTPClick()
    {
        SceneManager.LoadScene("How to Play");
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }
}

