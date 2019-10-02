using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform _player;
    public Vector2 _offset;
    public float _moveTime;

    private void FixedUpdate()
    {
        Vector3 newPos = new Vector3(_player.position.x + _offset.x, _player.position.y + _offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, _moveTime * Time.deltaTime);
    }
}
