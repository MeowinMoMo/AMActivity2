using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
/*    [SerializeField] public float _orbitSpeed = 1;
    [SerializeField] public float _rotationSpeed = 1;
    [SerializeField] private Vector3 _orbitAxis = Vector3.forward;
    [SerializeField] private Transform _target;

    void Start()
    {
        _target = _target != null ? _target : FindObjectOfType<Star>().transform;
    }

    void Update()
    {
        transform.RotateAround(_target.position, _orbitAxis, _orbitSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }*/
    [SerializeField] public float _orbitSpeed = 1;
    [SerializeField] public float _rotationSpeed = 1;
    [SerializeField] private Vector3 _orbitAxis = Vector3.forward;
    [SerializeField] private Transform _target;

    void Start()
    {
        if (_target == null)
        {
            GameObject sun = GameObject.Find("Sun");
            if (sun != null)
            {
                _target = sun.transform;
            }
        }
    }

    void Update()
    {
        transform.RotateAround(_target.position, _orbitAxis, _orbitSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
