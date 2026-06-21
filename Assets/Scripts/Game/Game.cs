using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerDeath _death;
    [SerializeField] private Score _score;
    [SerializeField] private PlaceAnimator _animatorPlace;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _death.Died += LoseGame;
        _startScreen.PlayButtonPressed += StartGame;
        _gameOverScreen.RestartButtonPressed += RestartGame;
    }

    private void OnDisable()
    {
        _death.Died -= LoseGame;
        _startScreen.PlayButtonPressed -= StartGame;
        _gameOverScreen.RestartButtonPressed -= RestartGame;
    }

    private void Awake()
    {
        Time.timeScale = 0;
        _gameOverScreen.Close();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.enabled = true;
        _spawner.enabled = true;
        _startScreen.Close();
    }

    private void LoseGame()
    {
        _animatorPlace.StopAnimation();
        _player.enabled = false;
        _spawner.enabled = false;
        _gameOverScreen.Open();
    }

    private void RestartGame()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}