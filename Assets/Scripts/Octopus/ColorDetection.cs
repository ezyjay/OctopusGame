using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDetection : MonoBehaviour
{
    public Material _octopusColor;
    public Transform _raycastOrigin;

    private Color _originalColor;
    private RaycastHit _raycastHit;

    private void Awake() {
        _originalColor = _octopusColor.color;
    }

    private void OnDisable() {
        _octopusColor.color = _originalColor;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) {
            
            if (Physics.SphereCast(_raycastOrigin.position, 0.4f, Vector3.forward * 500, out _raycastHit, 500, GameUtil.GetLayerMask(LayerType.COLOR_OBJECT))) {
                
                Renderer renderer = _raycastHit.collider.GetComponent<MeshRenderer>();
                _octopusColor.color = renderer.material.color;
            }
        } else {
            _octopusColor.color = _originalColor;
        }
    }
    
}
