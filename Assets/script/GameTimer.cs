using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public TMP_Text timerText;   // UI 顯示
    public float timeElapsed = 0f;
    public static float finalTime = 0f; // 用於 GameOver scene

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

    // 偵測碰到 Finish
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
