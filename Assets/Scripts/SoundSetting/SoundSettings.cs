using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour {

    public PlaySettings[] values;
    public enum Object
    {
        Text = 1,
        Slider,
        Image,
        Button
    }
    public Dictionary<string, object> Setting = new Dictionary<string, object>();

    private void Start()
    {
        setValues();
    }

    public void setValues()
    {
        var loop = values.Length;
        for(int i = 0; i < loop; i++)
        {
            switch (values[i].form){
                case Object.Text:
                    Setting[values[i].objects.name] = values[i].objects.GetComponent<Text>().text;
                    break;
                case Object.Slider:
                    Setting[values[i].objects.name] = values[i].objects.GetComponent<Slider>().value;
                    break;
                case Object.Image:
                    Setting[values[i].objects.name] = values[i].objects.GetComponent<Image>().sprite; //動かないかも
                    break;
                case Object.Button:
                    Setting[values[i].objects.name] = values[i].objects.GetComponent<Button>().onClick; //動かないかも
                    break;
            }
        }
    }

    [System.Serializable]
    public class PlaySettings
    {
        [SerializeField]
        internal GameObject objects;
        [SerializeField]
        internal Object form = Object.Text;
    }
}
