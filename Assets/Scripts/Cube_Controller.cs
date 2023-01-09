using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube_Controller : MonoBehaviour
{

    [SerializeField] private Transform _objectToSpawn;
    [SerializeField] private float distanceToCam = 10f;
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
            // Récupérer les coords x,y de la souris sur l'écran
            Vector2 mousePosition = Input.mousePosition;

            // Transformer le point de l'écran en un point du monde 3d
            Vector3 mouseVec = new Vector3(mousePosition.x, mousePosition.y, distanceToCam);
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mouseVec);

            // On récupère l'objet qu'on fait apparaitre
            Transform spawnedObject = Instantiate(_objectToSpawn, worldPosition, Quaternion.identity);
            // On l'ajoute à la pool
            _myGameObject.Add(spawnedObject);

            // On augmente le compteur d'objet
            _numberObject++;
        }

        else if (Input.GetMouseButtonDown(0))
        {
            // Quand on a atteint la limite d'objet
            // On récupère le premier objet de la liste
            _firstListObject = _myGameObject[0];

            // On le déplace à la nouvelle position du clic
            Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distanceToCam));
            _firstListObject.position = newWorldPosition;

            // On met à jour la liste
            _myGameObject.RemoveAt(0);
            _myGameObject.Add(_firstListObject);
        }
    }
}
