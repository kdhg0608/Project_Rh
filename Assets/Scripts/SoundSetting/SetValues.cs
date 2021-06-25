using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetValues : MonoBehaviour {

    [System.Runtime.InteropServices.DllImport("Sample.dll")] private static extern String WindowValueSave();
    [System.Runtime.InteropServices.DllImport("Sample.dll")] private static extern String WindowValueGet();
    [System.Runtime.InteropServices.DllImport("Sample.dll")] private static extern String WindowValueClose();

    private void SetValue(string[] data)
    {

    }
}
