using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _water;
    [SerializeField] private GameObject _logGroupObj;
    [SerializeField] private GameObject _turtleGroupObj;
    [SerializeField] private GameObject _timeBarObj;

    private LogGroup _logGroup;
    private TurtleGroup _turtleGroup;
    private InputAction _moveAction;
    private TimeBar _timeBar;

    private bool _isOnTurtle;
    private bool _isOnLog;
    private float _waterDeathTimer;
    private int _playerRow = 1;
    private int _highestRowReached = 1;
    private Vector3 _startPos = new Vector3(0, -12, 0);

    public int RemainingLives { get; private set; } = 3;
    public int LilypadsReached { get; private set; }
    public int Score { get; private set; }

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _turtleGroup = _turtleGroupObj.GetComponent<TurtleGroup>();
        _logGroup = _logGroupObj.GetComponent<LogGroup>();
        _timeBar = _timeBarObj.GetComponent<TimeBar>();
    }

    private void Update()
    {
        _waterDeathTimer -= Time.deltaTime;

        if (gameObject != null)
        {
            Move();

            if (transform.position.y > 0)
            {
                CheckIfOnTurtle();
                CheckIfOnLog();
                CheckIfTouchingWater();
            }

            if (Mathf.Abs(transform.position.x) > 12.5f)
            {
                transform.position = _startPos;
            }
        }

        if (_timeBar.TimeRemaining <= 0)
        {
            Kill();
        }

        Debug.Log($"Player Row: {_playerRow} Highest Row: {_highestRowReached}");
    }

    private Vector3 GetNewLocation()
    {
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();

        float x = transform.position.x;
        float y = transform.position.y;

        if (_moveAction.WasPressedThisFrame())
        {
            if (moveValue.x == -1)
            {
                return new Vector3(x - 2, y, 0);
            }
            else if (moveValue.x == 1)
            {
                return new Vector3(x + 2, y, 0);
            }
            else if (moveValue.y == 1)
            {
                _playerRow++;

                if (_playerRow == _highestRowReached + 1)
                {
                    Score += 10;
                    _highestRowReached++;

                    Debug.Log(Score);
                }

                return new Vector3(x, y + 2, 0);
            }
            else if (moveValue.y == -1)
            {
                _playerRow--;

                return new Vector3(x, y - 2, 0);
            }
            else
            {
                return transform.position;
            }
        }
        else
        {
            return transform.position;
        }
    }

    private void Move()
    {
        Vector3 previousLocation = transform.position;
        Vector3 newLocation = GetNewLocation();

        if (Mathf.Abs(newLocation.y) > 12 || Mathf.Abs(newLocation.x) > 13)
        {
            transform.position = previousLocation;
        }
        else
        {
            transform.position = newLocation;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Kill();
            //Debug.Log($"ded from car! lives remaining: {RemainingLives}");
        }

        if (collision.gameObject.CompareTag("Lilypad"))
        {
            ResetPlayer();
            _timeBar.ResetTimerAddPoints();

            LilypadsReached++;
            transform.position = _startPos;
            //Debug.Log($"Scored a Point! Total Points: {LilypadsReached}");
        }
    }

    private void CheckIfOnTurtle()
    {
        for (int i = 0; i < _turtleGroup.Turtles.Count; i++)
        {
            GameObject turtle = _turtleGroup.Turtles[i];
            BoxCollider2D playerCol = gameObject.GetComponent<BoxCollider2D>();

            if (turtle != null)
            {
                BoxCollider2D turtleCol = turtle.GetComponent<BoxCollider2D>();

                if (playerCol.IsTouching(turtleCol))
                {
                    _isOnTurtle = true;

                    if (turtle.gameObject.tag == "Turtle")
                    {
                        transform.Translate(new Vector3(turtle.GetComponent<Turtle>().MoveSpeed, 0, 0) * Time.deltaTime);
                    }
                    else if (turtle.gameObject.tag == "SinkingTurtle")
                    {
                        transform.Translate(new Vector3(turtle.GetComponent<SinkingTurtle>().MoveSpeed, 0, 0) * Time.deltaTime);
                    }

                    break;
                }
                else
                {
                    _isOnTurtle = false;
                }
            }
        }
    }

    private void CheckIfOnLog()
    {
        for (int i = 0; i < _logGroup.Logs.Count; i++)
        {
            GameObject log = _logGroup.Logs[i];
            BoxCollider2D playerCol = gameObject.GetComponent<BoxCollider2D>();

            if (log != null)
            {
                BoxCollider2D logCol = log.GetComponent<BoxCollider2D>();

                if (playerCol.IsTouching(logCol))
                {
                    _isOnLog = true;
                    transform.Translate(new Vector3(log.GetComponent<Log>().MoveSpeed, 0, 0) * Time.deltaTime);
                    break;
                }
                else
                {
                    _isOnLog = false;
                }
            }
        }
    }

    private void CheckIfTouchingWater()
    {
        if (!_isOnTurtle && !_isOnLog)
        {
            if (gameObject.GetComponent<BoxCollider2D>().IsTouching(_water.GetComponent<BoxCollider2D>()) && _waterDeathTimer <= 0)
            {
                _waterDeathTimer = 0.5f;
                //Score -= 10;
                Kill();

                //Debug.Log($"ded from water! lives remaining: {RemainingLives}");
            }
        }
    }

    private void Kill()
    {
        ResetPlayer();
        _timeBar.ResetTimer();

        if (RemainingLives > 0)
        {
            transform.position = _startPos;
            RemainingLives--;
        }
        else
        {
            RemainingLives--;
            Destroy(gameObject);
            _timeBarObj.SetActive(false);
        }
    }
 
    private void ResetPlayer()
    {
        _playerRow = 1;
        _highestRowReached = 1;
    }
}
