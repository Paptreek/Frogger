using UnityEngine;

public class Turtle : MonoBehaviour
{
    public float MoveSpeed { get; set; }
    public float SpawnTimer { get; set; }

    private void Update()
    {
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 19)
        {
            Destroy(gameObject);
        }
    }
}
