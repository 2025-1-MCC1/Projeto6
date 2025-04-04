using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;

    // Começa às 20:00 (20 * 60 = 1200 minutos)
    float currentGameTimeInMinutes = 1200f;

    // 1 hora do jogo = 84 segundos reais
    const float realSecondsPerGameHour = 84f;

    // Variável para armazenar o último minuto exibido
    int lastDisplayedMinute = 0;

    bool sceneLoaded = false;

    void Update()
    {

        // Converte deltaTime para horas do jogo (1h jogo = 84s reais)
        float gameHoursPassed = Time.deltaTime / realSecondsPerGameHour;

        // Adiciona ao tempo (convertendo horas para minutos)
        currentGameTimeInMinutes += gameHoursPassed * 60f;

        // passa das 24 para as 00:00
        if (currentGameTimeInMinutes >= 1440f) // 24h * 60 = 1440
        {
            currentGameTimeInMinutes -= 1440f; // Volta para 00
            sceneLoaded = true;
        }

        // Verifica se atingiu ou passou das 6:00
        if (currentGameTimeInMinutes >= 360f && sceneLoaded)
        {
            SceneManager.LoadScene(3);
        }

        // Calcula horas e minutos atuais
        int hours = Mathf.FloorToInt(currentGameTimeInMinutes / 60f) % 24;
        int minutes = Mathf.FloorToInt(currentGameTimeInMinutes % 60f);

        // Só atualiza se for múltiplo de 5 e diferente do último exibido
        if (minutes % 5 == 0 && minutes != lastDisplayedMinute)
        {
            timerText.text = string.Format("{0:00}:{1:00}", hours, minutes);
            lastDisplayedMinute = minutes;
        }
    }
}