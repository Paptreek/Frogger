using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Sprite _carSpriteOne;
    [SerializeField] private Sprite _carSpriteTwo;
    [SerializeField] private Sprite _carSpriteThree;
    [SerializeField] private Sprite _carSpriteFour;
    [SerializeField] private Sprite _carSpriteFive;

    private Vector2 _carOneCollider = new Vector2(2.6f, 1.42f);
    private Vector2 _carTwoCollider = new Vector2(2.82f, 1.42f);
    private Vector2 _carThreeCollider = new Vector2(2.6f, 1.42f);
    private Vector2 _carFourCollider = new Vector2(2.7f, 1.42f);
    private Vector2 _carFiveCollider = new Vector2(3.6f, 1.42f);

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
        }

        if (collision.name == "LaneOne")
        {
            GetComponent<SpriteRenderer>().sprite = _carSpriteOne;
            GetComponent<BoxCollider2D>().size = _carOneCollider;
        }

        if (collision.name == "LaneTwo")
        {
            GetComponent<SpriteRenderer>().sprite = _carSpriteTwo;
            GetComponent<BoxCollider2D>().size = _carTwoCollider;
        }

        if (collision.name == "LaneThree")
        {
            GetComponent<SpriteRenderer>().sprite = _carSpriteThree;
            GetComponent<BoxCollider2D>().size = _carThreeCollider;
        }

        if (collision.name == "LaneFour")
        {
            GetComponent<SpriteRenderer>().sprite = _carSpriteFour;
            GetComponent<BoxCollider2D>().size = _carFourCollider;
        }

        if (collision.name == "LaneFive")
        {
            GetComponent<SpriteRenderer>().sprite = _carSpriteFive;
            GetComponent<BoxCollider2D>().size = _carFiveCollider;
        }
    }
}
