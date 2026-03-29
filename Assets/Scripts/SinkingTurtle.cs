using UnityEditor;
using UnityEngine;

public class SinkingTurtle : MonoBehaviour
{
    private float _sinkTimer;
    private float _underwaterTimer;
    private bool _isSunk;

    public float MoveSpeed { get; set; }

    private void Awake()
    {
        _sinkTimer = Random.Range(1.0f, 2.5f);
        _underwaterTimer = Random.Range(1.0f, 1.5f);
    }

    private void Update()
    {
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 19)
        {
            Destroy(gameObject);
        }

        if (_isSunk)
        {
            _underwaterTimer -= Time.deltaTime;
        }
        else
        {
            _sinkTimer -= Time.deltaTime;
        }

        Sink();
        Resurface();
    }

    private void Sink()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        if (_sinkTimer <= 0)
        {
            _isSunk = true;

            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = false;
            }

            GetComponent<BoxCollider2D>().enabled = false;

            _sinkTimer = Random.Range(1.0f, 3.0f);
            _underwaterTimer = Random.Range(1.0f, 1.75f);
        }

    }

    private void Resurface()
    {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();

        if (_underwaterTimer <= 0)
        {
            foreach (Renderer renderer in renderers)
            {
                renderer.enabled = true;
            }

            GetComponent<BoxCollider2D>().enabled = true;

            _isSunk = false;
        }

    }
}
