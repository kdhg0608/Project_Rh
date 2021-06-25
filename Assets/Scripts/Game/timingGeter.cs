using UnityEngine;

public class timingGeter : MonoBehaviour
{

    const string nodeName = "Node(Clone)";
    private float Speed = 3f;
    private float Position = 0f;
    public GameObject tapPosition;
    public checkTiming checktiming;

    private void Awake()
    {
        var Setting = GameObject.Find("Settings").GetComponent<SoundSettings>().Setting;
        Speed = (float)(Setting["NotsSetting"]);
        Position = (float)(Setting["TapSetting"]);
    }

    private void Start()
    {
        checktiming = tapPosition.GetComponent<checkTiming>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == nodeName)
        {
            checktiming.Timing[this.gameObject.name].Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == nodeName)
        {
            checktiming.Timing[this.gameObject.name].Remove(other.gameObject);
        }
    }
}
