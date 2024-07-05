using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    private bool startLoad = false;

    private float timeLeft;
    private float timeLoad = 2f;

    [SerializeField]
    private Slider loadSlider;

    private void Awake()
    {
        StartLoading();
    }

    private void Update()
    {
        if (startLoad)
        {
            timeLeft += Time.deltaTime;
            loadSlider.value = timeLeft;

            if (timeLeft >= timeLoad)
            {
                StartGame();
            }
        }
    }

    public void StartLoading()
    {
        startLoad = true;
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
