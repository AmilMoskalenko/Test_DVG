using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    [Header("Time")]
    public Text timerText;
    [SerializeField] private int seconds = 31;

    [Header("PlayerCollision")]
    [SerializeField] private PlayerCollision playerCollision;

    [Header("Local")]
    private float timer;
    private const float second = 1;

    private void Awake() => Time.timeScale = 1;

    private void Update()
    {
        if (playerCollision.AccelerationStarted || playerCollision.HighJumpStarted)
        {
            Timer();
        }
    }
    
    private void Timer()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            timer = second;
            seconds--;
            timerText.text = "" + seconds;
            if (seconds == -1)
            {
                timerText.text = "bonus timer";
                seconds = 31;
                playerCollision.AccelerationStarted = false;
                playerCollision.HighJumpStarted = false;
            }
        }
    }

    public void Restart() => SceneManager.LoadScene("Game");
}
