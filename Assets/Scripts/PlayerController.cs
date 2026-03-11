using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputAction _moveAction;

    private void Start()
    {
        _moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Move();
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

        if (newLocation.y < -12 || newLocation.y > 12 || newLocation.x < -16 || newLocation.x > 16)
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
            Debug.Log("ded");
        }
    }
}
