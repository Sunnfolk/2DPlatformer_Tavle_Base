using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _lightObject;
    private Light2D _light;

// Start is called before the first frame update
    void Start()
    {
        _light = _lightObject.GetComponent<Light2D>();
    }

// Update is called once per framez
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _light.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _light.color = Color.blue;
        }
    }
}
