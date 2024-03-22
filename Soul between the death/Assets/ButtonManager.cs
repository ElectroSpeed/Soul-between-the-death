using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject _menu, _endMenu;
    public AudioSource _audioSource;
    private bool _pauseActive;
    private bool _endActive;
    private bool _optionActive;
    private bool _isVictory;
    private bool _isDefeat;

    [SerializeField] private Animator _animator;

    public static ButtonManager instance;

    public GameObject AudioSlider;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        Time.timeScale = 1.0f;
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
                GameObject.Find("MenuManager").transform.Find("Option").gameObject.SetActive(false);
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
            GameObject.Find("MenuManager").transform.Find("Option").gameObject.SetActive(false);
        }
    }
    public void EndMenu()
    {
        if (!_endActive)
        {
            GameObject.Find("MenuManager").transform.Find("EndMenu").gameObject.SetActive(true);
            _endActive = true;
            Time.timeScale = 0.0f;
            if (_isVictory)
            {
                GameObject.Find("MenuManager").transform.Find("VictoryTextTop").gameObject.SetActive(true);
                GameObject.Find("MenuManager").transform.Find("VictoryTextDown").gameObject.SetActive(true);
            }
            if (_isDefeat)
            {
                GameObject.Find("MenuManager").transform.Find("DefeatTextTop").gameObject.SetActive(true);
                GameObject.Find("MenuManager").transform.Find("DefeatTextDown").gameObject.SetActive(true);
            }
        }
        else
        {
            GameObject.Find("MenuManager").transform.Find("EndMenu").gameObject.SetActive(false);
            _endActive = false;
            Time.timeScale = 0.0f;
            if (!_isVictory)
            {
                GameObject.Find("MenuManager").transform.Find("VictoryTextTop").gameObject.SetActive(false);
                GameObject.Find("MenuManager").transform.Find("VictoryTextDown").gameObject.SetActive(false);
            }
            if (!_isDefeat)
            {
                GameObject.Find("MenuManager").transform.Find("DefeatTextTop").gameObject.SetActive(false);
                GameObject.Find("MenuManager").transform.Find("DefeatTextDown").gameObject.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
}
