using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionObject : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] public float _speed;
    [SerializeField] public float _sineLength = 1;
    [SerializeField] public float _cosineLength = 1;
    [SerializeField] public bool _useSine;
    [SerializeField] public bool _useCosine;

    [SerializeField] public GameObject _targetGameObject;

    private float angle = 0;
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        angle = Random.Range(0f, 360f); // Random initial angle
        initialPosition = _targetGameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime * _speed;

        Vector3 offset = Vector3.zero;

        if (_useSine)
        {
            offset.z = Mathf.Sin(Mathf.Deg2Rad * angle) * _sineLength;
        }

        if (_useCosine)
        {
            offset.x = Mathf.Cos(Mathf.Deg2Rad * angle) * _cosineLength;
        }

        Vector3 position = _targetGameObject.transform.position + offset;
        transform.position = position;
    }
}
