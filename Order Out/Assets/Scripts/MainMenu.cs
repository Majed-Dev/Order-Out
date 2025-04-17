using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI hScoreText;
    void Start()
    {
        hScoreText.text = PlayerPrefs.GetInt("HScore").ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Quit()
    {
        Application.Quit(0);
        print("Quit");
    }
}
