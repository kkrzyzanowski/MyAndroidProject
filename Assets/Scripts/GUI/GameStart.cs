﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {

	public void OnStart()
    {
        Debug.Log("Load Scene");
        Application.LoadLevel("scene");
    }
}
