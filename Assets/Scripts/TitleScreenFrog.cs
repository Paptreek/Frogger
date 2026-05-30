using UnityEngine;

public class TitleScreenFrog : MonoBehaviour
{
    [SerializeField] private Sprite _idleSprite;
    [SerializeField] private Sprite _movingSprite;
    [SerializeField] private AnimationClip _moveAnimation;

    private Animator _animator;
    private float _moveTimer = 1.0f;

    void Start()
    {
        _animator = GetComponent<Animator>();

        transform.position = new Vector3(Random.Range(-12.0f, 12.0f), Random.Range(-14.0f, 14.0f));
        transform.eulerAngles = new Vector3(0, 0, SetRandomDirection());
    }

    void Update()
    {
        _moveTimer -= Time.deltaTime;

        if (_moveTimer <= 0)
        {
            Move();
        }

        if (Mathf.Abs(transform.position.x) >= 15 || Mathf.Abs(transform.position.y) >= 18)
        {
            Destroy(gameObject);
        }
    }

    private int SetRandomDirection()
    {
        int[] directions = { 0, 90, 180, 270 };

        int randomDirection = directions[Random.Range(0, directions.Length)];

        return randomDirection;
    }

    private void Move()
    {
        if (transform.eulerAngles.z == 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 1, 0);
        }
        else if (transform.eulerAngles.z == 90)
        {
            transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
        }
        else if (transform.eulerAngles.z == 180)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1, 0);
        }
        else if (transform.eulerAngles.z == 270)
        {
            transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
        }

        _animator.SetTrigger("Move");

        _moveTimer = 1.0f;
    }
}
