using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject _trigger;
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private float _speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("OnTriggerStay");
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("GetKeyDown");
            Quaternion rot = Quaternion.AngleAxis(36f, Vector3.right);
            _trigger.transform.position = rot * (_trigger.transform.position - _target.transform.position) + _target.transform.position;
            _trigger.transform.rotation = rot * _trigger.transform.rotation;
        }

    }
}
