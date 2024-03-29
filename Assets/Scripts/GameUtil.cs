﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LayerType {
    COLOR_OBJECT = 8,
    PLAYER = 9,
}

public class GameUtil : MonoBehaviour
{
    private GameObject _playerObject;
    public static GameObject PlayerObject { 
        get => GameObject.FindGameObjectWithTag("Player");
    }

    public static LayerMask GetLayerMask(LayerType layerType) {
        return LayerMask.GetMask(LayerMask.LayerToName((int)layerType));
    }

	public static event Action GameOver;
	public static void ActivateGameOver() {
		GameOver.Invoke();
	}
}
