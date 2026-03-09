using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private void Update()
    {
        CheckInput();
    }

    private void CheckInput()
    {
        float x = transform.position.x;
        float y = transform.position.y;

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            transform.position = new Vector3(x - 2, y, 0);
        }

        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            transform.position = new Vector3(x + 2, y, 0);
        }

        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            transform.position = new Vector3(x, y + 2, 0);
        }

        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            transform.position = new Vector3(x, y - 2, 0);
        }
    }
}
