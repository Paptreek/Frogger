using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Sprite _carSpriteOne;
    [SerializeField] private Sprite _carSpriteTwo;

    private Vector2 _carOneCollider = new Vector2(2.82f, 1.42f);
    private Vector2 _carTwoCollider = new Vector2(2.6f, 1.42f);

    public float MoveSpeed { get; set; } = 7.5f;

    private void Update()
    {
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 30)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ReverseLane"))
        {
            MoveSpeed = -MoveSpeed;
            GetComponent<SpriteRenderer>().sprite = _carSpriteOne;
            GetComponent<BoxCollider2D>().size = _carOneCollider;
        }

        if (!collision.CompareTag("ReverseLane"))
        {
            GetComponent<SpriteRenderer>().sprite = _carSpriteTwo;
            GetComponent<BoxCollider2D>().size = _carTwoCollider;
        }
    }
}
