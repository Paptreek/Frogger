using UnityEditor;
using UnityEngine;

public class SinkingTurtle : MonoBehaviour
{
    [SerializeField] private Sprite _empty;

    public float MoveSpeed { get; set; }

    private void Update()
    {
        transform.Translate(new Vector3(MoveSpeed, 0, 0) * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) > 19)
        {
            Destroy(gameObject);
        }

        Sink();
    }

    private void Sink()
    {
        if (GetComponent<SpriteRenderer>().sprite == _empty)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
