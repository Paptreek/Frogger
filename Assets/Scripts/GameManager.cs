using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerObj;
    
    private PlayerController _player;
    private int _lilypadsReached;
    private int _remainingLives;

    private void Start()
    {
        _player = _playerObj.GetComponent<PlayerController>();
    }

    private void Update()
    {
        _lilypadsReached = _player.LilypadsReached;
        _remainingLives = _player.RemainingLives;

        CheckForGameOver();

        //Debug.Log($"Lilypads Reached: {_lilypadsReached}, Remaining Lives: {_remainingLives}");
    }

    private void CheckForGameOver()
    {
        if (_lilypadsReached == 5)
        {
            Debug.Log("All five lilypads filled. You win!");
        }

        if (_remainingLives <= 0)
        {
            Debug.Log("All out of lives. You lose!");
        }
    }
}
