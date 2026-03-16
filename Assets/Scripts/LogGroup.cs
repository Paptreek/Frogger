using UnityEngine;

public class LogGroup : MonoBehaviour
{
    [SerializeField] private GameObject _logObj;

    private float[] _laneSpeeds = new float[3];
    private float[] _spawnTimers = new float[3];

    private void Awake()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _laneSpeeds[i] = Random.Range(-10.0f, -5.0f);
            _spawnTimers[i] = 2.0f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _spawnTimers[i] -= Time.deltaTime;
        }

        SpawnCars();
    }

    private void SpawnCars()
    {
        int x = 24;
        int y = 4;

        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            if (i == 2)
            {
                y += 2;
            }

            if (_spawnTimers[i] <= 0)
            {
                CreateLog(x, y, _laneSpeeds[i]);
                _spawnTimers[i] = Random.Range(1.0f, 3.0f);
            }

            y += 2;
        }
    }

    private void CreateLog(int x, int y, float moveSpeed)
    {
        GameObject tempObject = Instantiate(_logObj, new Vector3(x, y, 0), transform.rotation);

        tempObject.GetComponent<Log>().MoveSpeed = moveSpeed;
    }
}
