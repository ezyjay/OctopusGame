using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDetection : MonoBehaviour
{
    public Material _octopusColor;
    public Transform _raycastOrigin;
    public float _colorLerpTime = 2f;
    public float _timeToStayNewColorOnLeave = 3f;

    private Color _originalColor;
    private Color _newColor;
    private RaycastHit _raycastHit;
    private bool _doColorLerp, _doInverseColorLerp;
    private bool _isOverColorObject;
    private float _timeChangedColor = 0f;

    private void Awake() {
        _originalColor = _octopusColor.color;
    }

    private void OnDisable() {
        _octopusColor.color = _originalColor;
    }

    void Update()
    {
        //Are we over a color giving object ?
        if (Physics.SphereCast(_raycastOrigin.position, 0.4f, Vector3.forward * 500, out _raycastHit, 500, GameUtil.GetLayerMask(LayerType.COLOR_OBJECT)))
            _isOverColorObject = true;
        else
            _isOverColorObject = false;

        //Have we clicked mouse button
        if (Input.GetMouseButtonDown(0) && _isOverColorObject) 
        {
            Renderer renderer = _raycastHit.collider.GetComponent<MeshRenderer>();
            _newColor = renderer.material.color;
            _doColorLerp = true;
            _timeChangedColor = Time.time;
        } 
        //Have we stopped clicking or left the color object
        else if (Input.GetMouseButtonUp(0) || !_isOverColorObject && Time.time - _timeChangedColor > _timeToStayNewColorOnLeave) 
        {
            _newColor = _originalColor;
        }

        //Do lerp 
        if (_doColorLerp) 
            _octopusColor.color = Color.Lerp(_octopusColor.color, _newColor, _colorLerpTime * Time.deltaTime);
    }
    
}
