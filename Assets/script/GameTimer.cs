using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;   // UI ���
    public float timeElapsed = 0f;
    public static float finalTime = 0f; // �Ω� GameOver scene

    private bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
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
        isGameOver = true;
        finalTime = timeElapsed;
        SceneManager.LoadScene("GameEnd");
    }

    private void dead(Transform transform)
    {
        if (transform.position.y < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
