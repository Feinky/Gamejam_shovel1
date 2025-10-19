using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Transform target;
    public TMP_Text timerText;   // UI ���
    public float timeElapsed = 0f;
    public static float finalTime = 0f; // �Ω� GameOver scene

    public bool isGameEnd = false;

    void Update()
    {
        if (target.position.y < -50)
        {
            dead();
        }

            if (!isGameEnd)
        {
            timeElapsed += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeElapsed / 60f);
            int seconds = Mathf.FloorToInt(timeElapsed % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

       
    }

    // �����I�� Finish
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
        {
            EndGame();
        }
    }

    void EndGame()
    {
        isGameEnd = true;
        finalTime = timeElapsed;
        SceneManager.LoadScene("GameEnd");
    }

    private void dead()
    {
        
            SceneManager.LoadScene("GameOver");
        
    }
}
