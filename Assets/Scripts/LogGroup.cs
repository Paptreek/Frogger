using System.Collections.Generic;
using UnityEngine;

public class LogGroup : MonoBehaviour
{
    [SerializeField] private GameObject _logObj;
    [SerializeField] private GameObject _player;

    public List<GameObject> Logs { get; } = new List<GameObject>();

    private float[] _laneSpeeds = new float[3];
    private float[] _spawnTimers = new float[3];

    private void Awake()
    {
        float startingSpeed = Random.Range(7.0f, 9.0f);

        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            //_laneSpeeds[i] = Random.Range(5.0f, 9.0f);

            _laneSpeeds[i] = startingSpeed;
            startingSpeed -= Random.Range(1.0f, 2.0f);

            _spawnTimers[i] = Random.Range(0.25f, 3.0f);
        }

        Debug.Log($"{_laneSpeeds[0]}, {_laneSpeeds[1]}, {_laneSpeeds[2]}");
    }

    private void Update()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _spawnTimers[i] -= Time.deltaTime;
        }

        SpawnLogs();

        for (int i = 0; i < Logs.Count; i++)
        {
            if (Logs[i] == null)
            {
                Logs.Remove(Logs[i]);
            }
        }
    }

    private void SpawnLogs()
    {
        int x = -19;
        int y = 4;

        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            if (i == 2)
            {
                y += 2;
            }

            if (_spawnTimers[i] <= 0)
            {
                Logs.Add(CreateLog(x, y, _laneSpeeds[i]));
                _spawnTimers[i] = Random.Range(2.5f, 3.75f);
            }

            y += 2;
        }
    }

    private GameObject CreateLog(int x, int y, float moveSpeed)
    {
        GameObject tempObject = Instantiate(_logObj, new Vector3(x, y, 0), transform.rotation);
        tempObject.GetComponent<Log>().MoveSpeed = moveSpeed;

        return tempObject;
    }
}
