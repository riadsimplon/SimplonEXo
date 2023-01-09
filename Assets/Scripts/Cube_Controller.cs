using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{

    [SerializeField] private Transform _spawnedOject;
    [SerializeField] private int _limitObject;
    private int _numberObject;
    private Transform _firstListObject;
    private List<Transform> _myGameObject = new List<Transform>();


    // Start is called before the first frame update
    void Start()
    {
        



    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0) && _numberObject < _limitObject)
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25));
            Instantiate(_spawnedOject, worldPosition, Quaternion.identity);
            _myGameObject.Add(_spawnedOject);
            _numberObject++;
        }

        else if (Input.GetMouseButtonDown(0) && _numberObject == _limitObject)
        {
            _firstListObject = _myGameObject[0];
            Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 25));
            _firstListObject.position = newWorldPosition;
            _myGameObject.Add(_spawnedOject);
            _myGameObject.RemoveAt(0);
            
            


        }
    }
}
