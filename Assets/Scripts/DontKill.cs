using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontKill : MonoBehaviour {
    private static DontKill _instance = null;
    public static DontKill Instance {
        get { return _instance; }
    }

    void Awake() {
        // PART OF THE SINGLETON PATTERN
        if (_instance == null) {
            _instance = this;
            DontDestroyOnLoad(this);
        } else {
            Destroy(this.gameObject);
        }
    }
}
