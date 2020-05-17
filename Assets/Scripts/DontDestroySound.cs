using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroySound : MonoBehaviour {
    
    public GameObject objs1;

    void Awake() {
        DontDestroyOnLoad(objs1);
    }
}