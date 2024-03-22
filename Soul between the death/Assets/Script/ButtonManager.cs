using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu, _endMenu;
    public AudioSource _audioSource;
    private bool _pauseActive;
    private bool _endActive;
    private LevelTrigger _levelTrigger;
    [SerializeField] private TextMeshProUGUI _textScore;


    public static ButtonManager instance;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Time.timeScale = 1.0f;
        _levelTrigger = LevelTrigger.Instance;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PauseMenu(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!_pauseActive)
            {
                GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(true);
                _pauseActive = true;
                Time.timeScale = 0.0f;
            }
            else
            {
                GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(false);
                _pauseActive = false;
                Time.timeScale = 1.0f;
            }
        }
    }

    public void PauseMenuButton()
    {
        if (!_pauseActive)
        {
            GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(true);
            _pauseActive = true;
            Time.timeScale = 0.0f;
        }
        else
        {
            GameObject.Find("MenuManager").transform.Find("PauseMenu").gameObject.SetActive(false);
            _pauseActive = false;
            Time.timeScale = 1.0f;
        }
    }
    public void EndMenu()
    {
        if (!_endActive)
        {
            GameObject.Find("MenuManager").transform.Find("EndMenu").gameObject.SetActive(true);
            _endActive = true;
            Time.timeScale = 0.0f;
            _textScore.text = "Score " + _levelTrigger._level * 5;
        }
        else
        {
            GameObject.Find("MenuManager").transform.Find("EndMenu").gameObject.SetActive(false);
            _endActive = false;
            Time.timeScale = 0.0f;
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
