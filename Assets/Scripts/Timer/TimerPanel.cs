using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerPanel : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField] 
    private Button pauseButton;

    [SerializeField]
    private TextMeshProUGUI timerText;

    private int minute = 10;
    private float seconds;
    
    private bool startTimer = false;

    private void OnEnable()
    {
        minute = 10;
        seconds = 0;
        startTimer = false;
        startButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        SetTimerText();
        ButtonClickAction();
    }

    private void Update()
    {
        if (startTimer)
        {
            seconds -= Time.deltaTime;
            
            if (seconds <= 0)
            {
                if (minute > 0)
                {
                    minute -= 1;
                    seconds = 60;
                }
                else
                {
                    minute = 0;
                    seconds = 0;
                    startTimer = false;
                }
            }
        }
        
        SetTimerText();
    }

    private void ButtonClickAction()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                startTimer = true;
                startButton.gameObject.SetActive(false);
                pauseButton.gameObject.SetActive(true);
            });
        }

        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(() =>
            {
                startTimer = false;
                startButton.gameObject.SetActive(true);
                pauseButton.gameObject.SetActive(false);
            });
        }
    }

    private void SetTimerText()
    {
        string minuteText = "";
        string secondText = "";
        
        if (minute < 10)
        {
            minuteText = "0" + minute;
        }
        else
        {
            minuteText = minute.ToString();
        }

        if (seconds < 10)
        {
            secondText = "0" + seconds;
        }
        else
        {
            secondText = ((int)seconds).ToString();
        }

        timerText.text = minuteText + ":" + secondText;
    }
}
