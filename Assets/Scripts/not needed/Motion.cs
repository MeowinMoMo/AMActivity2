using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour

{   /*[Range (1,10)]
    [SerializeField] public float _speed;
    [SerializeField] public float _sineLength = 1;
    [SerializeField] public float _cosineLength = 1;

    [SerializeField] public bool _useSine;
    [SerializeField] public bool _useCosine;

    [SerializeField] private GameObject _targetGameObject;

    private float angle = 0;

    private Vector3 initialposition;
    
    // Start is called before the first frame update
    void Start()
    {
        angle = 0;
        initialposition = _targetGameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * _speed;

        
        
        if (_useSine)
        {
            
            _targetGameObject.transform.position = new Vector3(_targetGameObject.transform.position.x, initialposition.y,
                z: Mathf.Sin(angle) * _sineLength + initialposition.z);
        }

        if (_useCosine)
        {
            
            _targetGameObject.transform.position = new Vector3(x: Mathf.Cos(angle) * _cosineLength +  initialposition.x, initialposition.y,
                 _targetGameObject.transform.position.z);
        }
    }*/
    [Range(1, 10)]
    public float _speed;
    [SerializeField] public float _sineLength = 1;
    [SerializeField] public float _cosineLength = 1;

    [SerializeField] public bool _useSine;
    [SerializeField] public bool _useCosine;

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
    /*    [Range(1, 10)]
        public float _speed;
        [SerializeField] private float _orbitRadius = 1;

        private float angle = 0;

        // Start is called before the first frame update
        void Start()
        {
            angle = Random.Range(0f, 360f); // Start at a random angle to avoid synchronized orbits
        }

        // Update is called once per frame
        void Update()
        {
            angle += Time.deltaTime * _speed;

            float x = Mathf.Cos(angle) * _orbitRadius;
            float z = Mathf.Sin(angle) * _orbitRadius;

            transform.position = new Vector3(x, transform.position.y, z);
        }
    */
}
