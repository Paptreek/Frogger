using System.Collections.Generic;
using UnityEngine;

public class LogGroup : MonoBehaviour
{
    [SerializeField] private GameObject _logObj;
    [SerializeField] private GameObject _player;

    private List<GameObject> _logs = new List<GameObject>();

    private float[] _laneSpeeds = new float[3];
    private float[] _spawnTimers = new float[3];

    private void Awake()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _laneSpeeds[i] = Random.Range(4.0f, 9.0f);
            _spawnTimers[i] = 0.25f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _spawnTimers[i] -= Time.deltaTime;
        }

        SpawnLogs();

        for (int i = 0; i < _logs.Count; i++)
        {
            if (_logs[i] == null)
            {
                _logs.Remove(_logs[i]);
            }

            if (_player != null)
            {
                if (_logs.Contains(_logs[i]) && _logs[i].GetComponent<BoxCollider2D>().IsTouching(_player.GetComponent<BoxCollider2D>()))
                {
                    _player.transform.Translate(new Vector3(_logs[i].GetComponent<Log>().MoveSpeed, 0, 0) * Time.deltaTime);
                }
            }
        }
    }

    private void SpawnLogs()
    {
        int x = -17;
        int y = 4;

        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            if (i == 2)
            {
                y += 2;
            }

            if (_spawnTimers[i] <= 0)
            {
                _logs.Add(CreateLog(x, y, _laneSpeeds[i]));
                _spawnTimers[i] = Random.Range(2.0f, 3.0f);
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
