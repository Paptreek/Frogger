using UnityEngine;

public class Car : MonoBehaviour
{
    public float MoveSpeed { get; set; } = 7.5f;

    private void Update()
    {
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 21)
        {
            Destroy(gameObject);
        }
    }
}
