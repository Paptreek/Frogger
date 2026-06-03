using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _playerLivesObj;
    [SerializeField] private GameObject _timerBarObj;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _highScoreText;
    [SerializeField] private TMP_Text _countdownText;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameOverText;
    [SerializeField] private GameObject _victoryText;

    [SerializeField] private GameObject _carGroup;

    private AudioListener _gameAudioListener;
    private AudioListener _playerAudioListener;
    private PlayerController _player;
    private TimeBar _timeBar;

    private int _lilypadsReached;
    private int _remainingLives;
    private int _currentScore;
    private float _initialCountdown = 3;

    private void Start()
    {
        _player = _playerObj.GetComponent<PlayerController>();
        _timeBar = _timerBarObj.GetComponent<TimeBar>();
        _gameAudioListener = GetComponent<AudioListener>();
        _playerAudioListener = _playerObj.GetComponent<AudioListener>();
    }

    private void Update()
    {
        StartInitialCountdown();
        SwitchAudioListener();

        _lilypadsReached = _player.LilypadsReached;
        _remainingLives = _player.RemainingLives;

        UpdateLives();
        CalculateScore();
        CheckForGameOver();

        if (_currentScore > GetHighScore())
        {
            SetHighScore();
        }

        _scoreText.text = $"SCORE: {_currentScore:0000}";
        _highScoreText.text = $"HI-SCORE: {GetHighScore():0000}";
    }

    // felt cute, might delete later
    private void SwitchAudioListener()
    {
        if (_playerObj != null && _playerObj.activeInHierarchy)
        {
            _gameAudioListener.enabled = false;
            _playerAudioListener.enabled = true;
        }
    }

    private void CheckForGameOver()
    {
        if (_lilypadsReached == 5)
        {
            _gameOverPanel.SetActive(true);
            _victoryText.SetActive(true);
        }

        if (_remainingLives < 0)
        {
            _gameOverPanel.SetActive(true);
            _gameOverText.SetActive(true);
        }
    }

    private void UpdateLives()
    {
        Renderer[] lifeIcons = _playerLivesObj.GetComponentsInChildren<Renderer>();

        if (_remainingLives == 2)
        {
            lifeIcons[2].enabled = false;
        }
        else if (_remainingLives == 1)
        {
            lifeIcons[1].enabled = false;
        }
        else if (_remainingLives == 0)
        {
            lifeIcons[0].enabled = false;
        }
    }

    private void StartInitialCountdown()
    {
        if (_initialCountdown > 0)
        {
            _initialCountdown -= Time.deltaTime;
        }

        if (_initialCountdown > 0)
        {
            _countdownText.text = $"{_initialCountdown:0.0}";
        }
        if (_initialCountdown <= 0)
        {
            _countdownText.enabled = false;
        }

        if (_initialCountdown <= 0 && _playerObj != null)
        {
            _playerObj.SetActive(true);
            _timerBarObj.SetActive(true);
        }
    }

    private void CalculateScore()
    {
        _currentScore = _player.Score + _timeBar.LeftoverTime;
    }

    private void SetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", _currentScore);
    }

    private int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore");
    }
}
