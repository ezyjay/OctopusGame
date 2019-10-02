using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LayerType {
    COLOR_OBJECT = 8
}

public class GameUtil : MonoBehaviour
{
    private GameObject _playerObject;
    public GameObject PlayerObject { 
        get => GameObject.FindGameObjectWithTag("Player");
    }

    public static LayerMask GetLayerMask(LayerType layerType) {
        return LayerMask.GetMask(LayerMask.LayerToName((int)layerType));
    }

}
