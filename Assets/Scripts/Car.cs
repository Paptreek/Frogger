using UnityEngine;

public class Car : MonoBehaviour
{
    public float MoveSpeed { get; set; } = 2.5f;

    private void Update()
    {
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);
    }
}
