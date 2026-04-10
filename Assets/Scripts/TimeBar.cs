using UnityEngine;

public class TimeBar : MonoBehaviour
{
    private float _timeRemaining = 45.0f;
    private float _timeElapsed = 0;
    private float _startingPosX;

    private void Start()
    {
        _startingPosX = transform.position.x;
    }

    private void Update()
    {
        transform.position = new Vector3(_startingPosX + _timeElapsed / 6, -14);

        if (_timeRemaining >= 0)
        {
            _timeRemaining -= Time.deltaTime;
            _timeElapsed += Time.deltaTime;
            gameObject.transform.localScale = new Vector3(_timeRemaining / 3, 1);

            //Debug.Log(_timeRemaining);
        }
        else
        {
            gameObject.transform.localScale = Vector3.zero;
        }

        if (_timeRemaining <= 10.0f)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.softRed;
        }
    }

    public void ResetAll()
    {
        _timeRemaining = 45.0f;
        _timeElapsed = 0;
    }
}
