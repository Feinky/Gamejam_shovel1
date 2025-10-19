using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stamina : MonoBehaviour
{
    public int player_stamina = 200;
    public int max = 200;
    public Slider staminaSlider;

    public AudioSource audioSource;
    public AudioClip attackSound;
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
        Debug.Log("Stamina ¤w¯ÓºÉ");
        SceneManager.LoadScene("GameOver");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("bo");
        if (collision.gameObject.CompareTag("Buff"))
        {
            Debug.Log("¦Y¤g!");
            player_stamina = Mathf.Clamp(player_stamina +5,0,200);
            audioSource.PlayOneShot(attackSound);
        }

        if (collision.gameObject.CompareTag("Debuff"))
        {
            Debug.Log("¦Y«Ë!");
            player_stamina = Mathf.Max(0, player_stamina - 3);
            audioSource.PlayOneShot(attackSound);
        }
    }
}
