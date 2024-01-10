using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motionsolar : MonoBehaviour
{
    [Range(1, 10)]
    public float _speed;
    [SerializeField] private float _sineLength = 1;
    [SerializeField] private float _cosineLength = 1;

    [SerializeField] private bool _useSine;
    [SerializeField] private bool _useCosine;

    private float angle = 0;

    private Vector3 initialposition;

    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        initialposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * _speed;

        if (_useSine)
        {
            transform.position = new Vector3(transform.position.x, initialposition.y,
                Mathf.Sin(angle) * _sineLength + initialposition.z);
        }

        if (_useCosine)
        {
            transform.position = new Vector3(Mathf.Cos(angle) * _cosineLength + initialposition.x, initialposition.y,
                transform.position.z);
        }
    }
}