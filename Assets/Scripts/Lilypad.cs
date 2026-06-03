using UnityEngine;

public class Lilypad : MonoBehaviour
{
    [SerializeField] Sprite _updatedSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = _updatedSprite;
            gameObject.GetComponent<SpriteRenderer>().flipY = true;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
