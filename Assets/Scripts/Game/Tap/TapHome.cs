using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHome : MonoBehaviour {
    private TapGetter tapGetter;
    public Dictionary<GameObject, checkTiming> toCheckTiming = new Dictionary<GameObject, checkTiming>();
    private void Awake()
    {
        tapGetter = GetComponent<TapGetter>();
    }

    private void Start()
    {
        ///Lineが増えた際に追加の必要がある。
        GameObject.Find("NodeLine1");
        GameObject.Find("NodeLine1/TapPosition").GetComponent<checkTiming>();
        toCheckTiming.Add(GameObject.Find("NodeLine1"), GameObject.Find("NodeLine1/TapPosition").GetComponent<checkTiming>());
        toCheckTiming.Add(GameObject.Find("NodeLine2"), GameObject.Find("NodeLine2/TapPosition").GetComponent<checkTiming>());
        toCheckTiming.Add(GameObject.Find("NodeLine3"), GameObject.Find("NodeLine3/TapPosition").GetComponent<checkTiming>());
    }

    private void Update()
    {
        Dictionary<GameObject, TouchPhase> tapinfo = tapGetter.OnTouchPhase();
        foreach(var key in tapinfo.Keys)
        {
            if(key.name == "TapObject")
            {
                var line = key.transform.parent.gameObject;
                toCheckTiming[line].Tap();
            }
        }
    }

}
