using UnityEngine;
using TMPro;

public class GameOver_UI : MonoBehaviour
{
    public TMP_Text finalTimeText;

    void Start()
    {
        int minutes = Mathf.FloorToInt(GameTimer.finalTime / 60f);
        int seconds = Mathf.FloorToInt(GameTimer.finalTime % 60f);
        finalTimeText.text = "Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
