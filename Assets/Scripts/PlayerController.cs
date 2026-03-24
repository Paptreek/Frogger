using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _log;
    [SerializeField] private GameObject _water;
    [SerializeField] private GameObject _turtleGroupObj;

    private TurtleGroup _turtleGroup;
    private InputAction _moveAction;
    private Rigidbody2D _rb;

    private bool _isTouchingTurtle;

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
        _turtleGroup = _turtleGroupObj.GetComponent<TurtleGroup>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (gameObject != null)
        {
            Move();
            CheckIfTouchingTurtle();
            CheckIfTouchingWater();

            if (Mathf.Abs(transform.position.x) > 12.5f)
            {
                Destroy(gameObject);
            }

            Debug.Log(_isTouchingTurtle);
        }
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
                return new Vector3(x, y + 2, 0);
            }
            else if (moveValue.y == -1)
            {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
            Debug.Log("ded from car");
        }
    }

    private void CheckIfTouchingTurtle()
    {
        for (int i = 0; i < _turtleGroup.Turtles.Count; i++)
        {
            GameObject turtle = _turtleGroup.Turtles[i];
            BoxCollider2D playerCol = gameObject.GetComponent<BoxCollider2D>();
            BoxCollider2D turtleCol = turtle.GetComponent<BoxCollider2D>();

            if (playerCol.IsTouching(turtleCol))
            {
                _isTouchingTurtle = true;
                transform.Translate(new Vector3(turtle.GetComponent<Turtle>().MoveSpeed, 0, 0) * Time.deltaTime);
                break;
            }
            else
            {
                _isTouchingTurtle = false;
            }
        }
    }

    private void CheckIfTouchingWater()
    {
        if (!_isTouchingTurtle)
        {
            if (gameObject.GetComponent<BoxCollider2D>().IsTouching(_water.GetComponent<BoxCollider2D>()))
            {
                Destroy(gameObject);
                Debug.Log($"ded from water");
            }
        }
    }
}
