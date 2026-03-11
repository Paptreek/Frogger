using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Cars : MonoBehaviour
{
    [SerializeField] private GameObject _carObj;

    private List<GameObject> _carObjects = new List<GameObject>();
    private List<Car> _cars = new List<Car>();

    private void Awake()
    {
        float x = -16;
        float y = -10;

        for (int i = 0; i < 5; i++)
        {
            _carObjects.Add(_carObj);
        }

        for (int i = 0; i < _carObjects.Count; i++)
        {
            GameObject tempObject = Instantiate(_carObj, new Vector3(x, y, 0), transform.rotation);
            _cars.Add(tempObject.GetComponent<Car>());

            x = x == -x ? x : -x;
            y += 2;
        }
    }
}
