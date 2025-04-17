using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restaurant : MonoBehaviour
{
    private float gameTime = 61f;
    public int score = 0;
    private int highestScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI hScoreText;
    public List<Destination> destinations;
    public CarMovement carMovement;
    public Transform pizzaPos;
    public float rotationSpeed;

    void Start()
    {
        highestScore = PlayerPrefs.GetInt("HScore");
        hScoreText.text = highestScore.ToString();

    }
    void Update()
    {
        scoreText.text = score.ToString();
        Counting();

        pizzaPos.Rotate(0f, rotationSpeed * Time.deltaTime , 0f);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !carMovement.hasOrder)
        {
            print("Take Order!!!");
            carMovement.TakeOrder();
            SoundManager.Instance.PlaySFX(SoundManager.Instance.pickup);

            int i = Random.Range(0, destinations.Count);
            print(i);
            destinations[i].SetActive(true);
        }
    }
    public GameObject GetActiveDestiation()
    {
        foreach(Destination destination in destinations)
        {
            if(destination.IsActive())
            {
                return destination.gameObject;
            }    
        }
        return null;
    }
    private void Counting()
    {
        gameTime -= Time.deltaTime;
        int intGameTime = (int) gameTime;
        timerText.text = intGameTime.ToString();

        if(gameTime <=0f)
        {
            TimerEnded();
        }
    }
    private void  TimerEnded()
    {
        if(score > highestScore)
        {
            PlayerPrefs.SetInt("HScore" , score);
        }
        SceneManager.LoadScene("Menu");
    }
}
