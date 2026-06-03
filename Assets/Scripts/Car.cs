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

    private GameObject _playerObj;
    private PlayerController _player;
    private float _honkTimer;

    public float MoveSpeed { get; set; } = 7.5f;

    private void Start()
    {
        _honkTimer = 0.5f;
        _player = _playerObj.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (PlayerIsNearby())
        {
            _honkTimer -= Time.deltaTime;
        }

        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 30)
        {
            Destroy(gameObject);
        }

        HonkIfNearPlayer();
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

    private void HonkIfNearPlayer()
    {
        AudioSource honk = GetComponent<AudioSource>();

        if (PlayerIsNearby())
        {
            if (_honkTimer <= 0)
            {
                honk.pitch = Random.Range(0.5f, 2.0f);
                honk.Play();

                _honkTimer = Random.Range(0.5f, 2.0f);
            }
        }
    }

    private bool PlayerIsNearby()
    {
        float playerX = _playerObj.transform.position.x;
        float carX = transform.position.x;

        float playerY = _playerObj.transform.position.y;
        float carY = transform.position.y;

        if (_playerObj != null && !_player.IsDead)
        {
            if (Mathf.Abs(carX - playerX) <= 6 && carY == playerY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void SetPlayerTransform(GameObject playerObj)
    {
        _playerObj = playerObj;
    }
}
