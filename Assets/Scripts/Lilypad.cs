using UnityEngine;

public class Lilypad : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(46, 114, 46, 255);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
