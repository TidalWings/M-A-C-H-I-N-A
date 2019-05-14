using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour {

	public int mobile_framerate = 30;
	public int pc_framerate = 60;

	void Awake() {
		QualitySettings.vSyncCount = 0;
	}

	void Update() {
        if (Application.isMobilePlatform) {
			if (mobile_framerate != Application.targetFrameRate) {
				Application.targetFrameRate = mobile_framerate;
			}
        } else {
			if (pc_framerate != Application.targetFrameRate) {
				Application.targetFrameRate = pc_framerate;
			}
        }
	}
}
