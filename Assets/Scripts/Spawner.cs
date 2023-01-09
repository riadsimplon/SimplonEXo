using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _modelToSpawned;
    [SerializeField] private float _radius;
    [SerializeField] private int _limitObject;
    private int _numberObject;
    private Transform _firstListObject;
    private Transform _spawnedObject;
    private List<Transform> _myGameObject = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {




    }

    // Update is called once per frame
    void Update()
    {


        if (_numberObject < _limitObject)
        {
            Vector3 worldPosition = Random.insideUnitCircle * _radius;
            _spawnedObject = Instantiate(_modelToSpawned, worldPosition, Quaternion.identity);
            _myGameObject.Add(_spawnedObject);
            _numberObject++;
        }

        else if (_numberObject == _limitObject)
        {
            _firstListObject = _myGameObject[0];
            Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25));
            _firstListObject.position = newWorldPosition;
            _myGameObject.RemoveAt(0);
            _myGameObject.Add(_firstListObject);







        }

    }



