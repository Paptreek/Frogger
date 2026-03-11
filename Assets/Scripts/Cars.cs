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
        float x = 0;
        float y = -10;
        float lowSpeed = 5.0f;
        float highSpeed = 10.0f;

        for (int i = 0; i < 5; i++)
        {
            _carObjects.Add(_carObj);
        }

        for (int i = 0; i < _carObjects.Count; i++)
        {
            x = Random.Range(-16.0f, 16.0f);
            GameObject tempObject = Instantiate(_carObj, new Vector3(x, y, 0), transform.rotation);
            _cars.Add(tempObject.GetComponent<Car>());
            
            x = x == -x ? x : -x;

            y += 2;
        }

        _cars[0].MoveSpeed = Random.Range(lowSpeed, highSpeed);
        _cars[1].MoveSpeed = -Random.Range(lowSpeed, highSpeed);
        _cars[2].MoveSpeed = Random.Range(lowSpeed, highSpeed);
        _cars[3].MoveSpeed = -Random.Range(lowSpeed, highSpeed);
        _cars[4].MoveSpeed = Random.Range(lowSpeed, highSpeed);
    }

    private void Update()
    {
        foreach (Car car in _cars)
        {
            float x = car.transform.position.x;
            float y = car.transform.position.y;

            if (Mathf.Abs(car.transform.position.x) > 16.5)
            {
                car.transform.position = new Vector3(-x, y, 0);
            }
        }
    }
}
