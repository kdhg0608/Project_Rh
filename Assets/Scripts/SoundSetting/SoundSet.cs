using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSet : MonoBehaviour {

    private void Awake()
    {
        test();
        var Setting = GameObject.Find("Settings").GetComponent<SoundSettings>().Setting;
        var Sound = GetComponent<AudioSource>();
        var TapSound = GameObject.Find("TapSound").GetComponent<AudioSource>();

        Sound.volume = (float)(Setting["SoundSetting"]);
        TapSound.volume = (float)(Setting["TapSoundSetting"]);
    }

    void test()
    {
        var Settings = GameObject.Find("Settings").GetComponent<SoundSettings>().Setting;
        
        foreach (var Setting in Settings.Keys)
        {
            Debug.Log(Setting + "" + Settings[Setting]);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
