using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LayerType {
    COLOR_OBJECT = 8
}

public class GameUtil : MonoBehaviour
{
   
    public static LayerMask GetLayerMask(LayerType layerType) {
        return LayerMask.GetMask(LayerMask.LayerToName((int)layerType));
    }

}
