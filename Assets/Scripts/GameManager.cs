using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour

{

    private static GM _instance = null;
    public PlayerScript p;
    public GameObject LoseScreen;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GM instance()
    {
        return _instance;
    }

    public void onResetClick()
    {
        p.reset();
    }

    public void onMenuClick()
    {
        SceneManager.LoadScene("Menu");
    }

    public void setLoseScreen(bool value)
    {
        LoseScreen.SetActive(value);


    }
}

