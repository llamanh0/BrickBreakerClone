using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Scene Names")]
    [SerializeField] private string _mainMenuSceneName = "MainMenu";
    [SerializeField] private string _Level1SceneName = "Level1";
    [SerializeField] private string _Level2SceneName = "Level2";
    [SerializeField] private string _Level3SceneName = "Level3";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        Ball.OnGameOver += Ball_OnGameOver;
        GameUI.OnLevelDone += GameUI_OnLevelDone;
    }

    private void Update()
    {
        SceneController();
    }

    private void OnDestroy()
    {
        Ball.OnGameOver -= Ball_OnGameOver;
    }

    private void SceneController()
    {
        if(Input.GetKeyDown(KeyCode.BackQuote))
        {
            SceneManager.LoadScene(_mainMenuSceneName);
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(_Level1SceneName);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            SceneManager.LoadScene(_Level2SceneName);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene(_Level3SceneName);
        }
    }

    public void StartGame() // For Play Button
    {
        SceneManager.LoadScene(_Level1SceneName);
    }

    private void Ball_OnGameOver(object sender, System.EventArgs e)
    {
        SceneManager.LoadScene(_mainMenuSceneName);
    }

    private void GameUI_OnLevelDone(object sender, System.EventArgs e)
    {
        if(SceneManager.GetActiveScene().name == _Level1SceneName)
        {
            SceneManager.LoadScene(_Level2SceneName);
        }
        if (SceneManager.GetActiveScene().name == _Level2SceneName)
        {
            SceneManager.LoadScene(_Level3SceneName);
        }
        if (SceneManager.GetActiveScene().name == _Level3SceneName)
        {
            SceneManager.LoadScene(_mainMenuSceneName);
        }
    }
}
