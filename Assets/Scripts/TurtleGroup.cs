using System.Collections.Generic;
using UnityEngine;

public class TurtleGroup : MonoBehaviour
{
    [SerializeField] private GameObject _turtleObj;
    [SerializeField] private GameObject _sinkingTurtleObj;
    [SerializeField] private GameObject _player;

    public List<GameObject> Turtles { get; } = new List<GameObject>();

    private float[] _laneSpeeds = new float[2];
    private float[] _spawnTimers = new float[2];

    private void Awake()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _laneSpeeds[i] = Random.Range(4.0f, 7.5f);
            _spawnTimers[i] = 0.25f;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            _spawnTimers[i] -= Time.deltaTime;
        }

        SpawnTurtles();

        for (int i = 0; i < Turtles.Count; i++)
        {
            if (Turtles[i] == null)
            {
                Turtles.Remove(Turtles[i]);
            }
        }
    }

    private void SpawnTurtles()
    {
        int x = 17;
        int y = 2;

        for (int i = 0; i < _laneSpeeds.Length; i++)
        {
            if (i == 1)
            {
                y += 4;
            }

            if (_spawnTimers[i] <= 0)
            {
                Turtles.Add(CreateTurtle(x, y, -_laneSpeeds[i]));
                _spawnTimers[i] = Random.Range(2.5f, 4.0f);
            }

            y += 2;
        }
    }

    private GameObject CreateTurtle(int x, int y, float moveSpeed)
    {
        float coinFlip = Random.Range(0.0f, 1.0f);
        GameObject tempObject;

        if (coinFlip <= 0.50)
        {
            tempObject = Instantiate(_turtleObj, new Vector3(x, y, 0), transform.rotation);
            tempObject.GetComponent<Turtle>().MoveSpeed = moveSpeed;
        }
        else
        {
            tempObject = Instantiate(_sinkingTurtleObj, new Vector3(x, y, 0), transform.rotation);
            tempObject.GetComponent<SinkingTurtle>().MoveSpeed = moveSpeed;
        }


        return tempObject;
    }
}
