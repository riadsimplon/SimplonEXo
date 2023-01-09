using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Transform _objectToSpawn;
    [SerializeField] private float distanceToCam = 10f;
    [SerializeField] private int _limitObject;
    [SerializeField] private float radius = 5f;
    [SerializeField] private float spawnSpeed = 1f;
    private int _numberObject;
    private Transform _firstListObject;
    private List<Transform> _myGameObject = new List<Transform>();

    private float time = 0f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnSpeed <= 0f) return;

        time += Time.deltaTime;

        if (time >= 1f/spawnSpeed && _numberObject < _limitObject)
        {

            // On récupère l'objet qu'on fait apparaitre
            Transform spawnedObject = Instantiate(_objectToSpawn);
            Setup(spawnedObject);

            // On l'ajoute à la pool
            _myGameObject.Add(spawnedObject);

            // On augmente le compteur d'objet
            _numberObject++;
            time = 0f;
        }
        else if (time >= 1f / spawnSpeed)
        {
            // Quand on a atteint la limite d'objet
            // On récupère le premier objet de la liste
            _firstListObject = _myGameObject[0];

            Setup(_firstListObject);

            // On met à jour la liste
            _myGameObject.RemoveAt(0);
            _myGameObject.Add(_firstListObject);
            time = 0f;
        }
    }

    private void Setup(Transform transformToSetup)
    {
        // Placer l'objet
        Vector3 worldPosition = ComputePosition();
        transformToSetup.position = worldPosition;
        
        // Changer la couleur de l'objet    
        transformToSetup.GetComponent<Renderer>().material.color = Random.ColorHSV();

    }

    private Vector3 ComputePosition()
    {
        Vector3 localPosition = Random.insideUnitSphere * radius;
        Vector3 worldPosition = transform.TransformPoint(localPosition);
        return worldPosition;
    }
}
