using System;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    
    private float _timeElapsed = 0;
    private float _startingPosX;

    public float TimeRemaining { get; private set; } = 45.0f;
    public int LeftoverTime { get; private set; }

    private void Start()
    {
        _startingPosX = transform.position.x;
    }

    private void Update()
    {
        transform.position = new Vector3(_startingPosX + _timeElapsed / 6, -14);

        if (TimeRemaining >= 0 && _playerObject.activeInHierarchy)
        {
            TimeRemaining -= Time.deltaTime;
            _timeElapsed += Time.deltaTime;
            gameObject.transform.localScale = new Vector3(TimeRemaining / 3, 1);
        }
        else
        {
            gameObject.transform.localScale = Vector3.zero;
        }

        if (TimeRemaining <= 10.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(232, 106, 115, 255);
        }
    }

    public void ResetTimer()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(146, 220, 186, 255);

        TimeRemaining = 45.0f;
        _timeElapsed = 0;
    }

    public void ResetTimerAddPoints()
    {
        LeftoverTime += Convert.ToInt32(TimeRemaining);
        ResetTimer();
    }
}
