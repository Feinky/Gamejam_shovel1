using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stamina : MonoBehaviour
{
    public int player_stamina = 500;
    public int max = 500;
    public Slider staminaSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (staminaSlider != null)
        {
            staminaSlider.maxValue = max;
            staminaSlider.value = player_stamina;
        }
        StartCoroutine(ReduceStaminaRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(staminaSlider != null)
        {
            staminaSlider.value = player_stamina;
        }

    }
    IEnumerator ReduceStaminaRoutine()
    {
        while (player_stamina > 0)
        {
            yield return new WaitForSeconds(1f);
            player_stamina = Mathf.Max(0, player_stamina - 1);
            Debug.Log("Stamina: " + player_stamina);
        }

        if(player_stamina == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        Debug.Log("Stamina ¤w¯ÓºÉ");
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("bo");
        if (collision.gameObject.CompareTag("Buff"))
        {
            Debug.Log("¦Y¤g!");
            player_stamina = Mathf.Clamp(player_stamina +5,0,1000);

        }

        if (collision.gameObject.CompareTag("Debuff"))
        {
            Debug.Log("¦Y«Ë!");
            player_stamina = Mathf.Max(0, player_stamina - 20);
        }
    }
}
