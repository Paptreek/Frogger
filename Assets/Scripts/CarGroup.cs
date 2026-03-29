using UnityEngine;

public class CarGroup : MonoBehaviour
{
    [SerializeField] private GameObject _carObj;

    private float[] _laneSpeeds = new float[5];
    private float[] _spawnTimers = new float[5];

    private float _secondCarTimer = 0.5f;

    private void Awake()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _laneSpeeds[i] = Random.Range(5.0f, 10.0f);
            _spawnTimers[i] = 0.25f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _spawnTimers[i] -= Time.deltaTime;
        }

        _secondCarTimer -= Time.deltaTime;

        SpawnCars();
    }

    private void SpawnCars()
    {
        int x = -21;
        int y = -10;

        float coinFlip = Random.Range(0.0f, 1.0f);

        for (int i = 0; i < 5; i++)
        {
            if (_spawnTimers[i] <= 0)
            {
                CreateCar(x, y, _laneSpeeds[i]);
                _spawnTimers[i] = Random.Range(2.5f, 4.0f);

                if (coinFlip > 0.75f && _secondCarTimer <= 0)
                {
                    CreateCar(x - Random.Range(4, 7), y, _laneSpeeds[i]);
                    _secondCarTimer = 0.75f;

                    Debug.Log("Spawn a second car");
                }
            }

            x = x == -x ? x : -x;
            y += 2;
        }
    }

    private void CreateCar(int x, int y, float moveSpeed)
    {
        GameObject tempObject = Instantiate(_carObj, new Vector3(x, y, 0), transform.rotation);

        tempObject.GetComponent<Car>().MoveSpeed = moveSpeed;
    }
}
