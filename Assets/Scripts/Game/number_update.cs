using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class number_update : MonoBehaviour {

    public int number = 0;
    private int localNumber = 0;
    private int def = 0;
    private int defCheckUpdate = 0;
    private float onceUpdateNumber = 0;
    public float uplong = 0.5f;
    public TextMesh Score;
    public string after_adder;
    public string befor_adder;
    private enum Mode
    {
        func_update = 0,
        num_update,
    }
    [SerializeField]
    private Mode mode = Mode.num_update;

    private float t=0f;
    

	// Use this for initialization
	void Start ()
    {
        localNumber = number;
        Score.text = befor_adder + localNumber + after_adder;
    }

    /// <summary>
    /// Mode が func_updateの場合この関数が呼び出されるまで数値の変動が起きない
    /// </summary>
    public void NumUpdate()
    {
        NumDefFunc();
        if (number != (int)Mathf.Floor(onceUpdateNumber))
        {
            onceUpdateNumber += (def * Time.deltaTime / uplong);
            localNumber = ((int)Mathf.Floor(onceUpdateNumber));
            Score.text = befor_adder + localNumber+ after_adder;
        }
        else
        {
            t = 0f;
        }
    }

    private void NumDefFunc()
    {
        def = number - localNumber;
    }

    private void debugLogs()
    {
        t += Time.deltaTime;
        Debug.Log("Up " + onceUpdateNumber + " /Lo " + (float)localNumber + " /De " + (float)def+" /Td "+defCheckUpdate+" /num "+ number + " /time "+t);
    }

    private void SelectMode()
    {
        switch (mode)
        {
            case Mode.func_update:

                break;
            case Mode.num_update:
                NumUpdate();
                break;
            default:
                break;
        }
    }

	// Update is called once per frame
	void Update ()
    {
        if (number != localNumber)
        {
            SelectMode();
        }
    }
}
