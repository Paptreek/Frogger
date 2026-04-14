using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _playerLivesObj;
    [SerializeField] private GameObject _timerBarObj;
    [SerializeField] private TMP_Text _scoreText;
    
    private PlayerController _player;
    private TimeBar _timeBar;

    private int _lilypadsReached;
    private int _remainingLives;
    private int _playerScore;

    private void Start()
    {
        _player = _playerObj.GetComponent<PlayerController>();
        _timeBar = _timerBarObj.GetComponent<TimeBar>();
    }

    private void Update()
    {
        _lilypadsReached = _player.LilypadsReached;
        _remainingLives = _player.RemainingLives;

        UpdateLives();
        CalculateScore();
        CheckForGameOver();

        _scoreText.text = $"SCORE: {_playerScore:000}";
    }

    private void CheckForGameOver()
    {
        if (_lilypadsReached == 5)
        {
            Debug.Log("All five lilypads filled. You win!");
        }

        if (_remainingLives < 0)
        {
            Debug.Log("All out of lives. You lose!");
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

    private void CalculateScore()
    {
        _playerScore = _player.Score + _timeBar.LeftoverTime;
    }
}
