using UnityEngine;
using System.Collections.Generic;

public class checkTiming : MonoBehaviour {
    
    public Settings settings;
    public TapLight tapLight;

    public int perfectCheck;
    public int goodCheck;
    public int badCheck;
    
    public Dictionary<string, List<GameObject>> Timing = new Dictionary<string, List<GameObject>>()
    {
        { "perfect",new List<GameObject>() },
        { "good",new List<GameObject>() },
        { "bad",new List<GameObject>() },
        { "DestoryPoint",new List<GameObject>() }
    };

    private void Awake()
    {
        tapLight = gameObject.transform.Find("NodeLight").GetComponent<TapLight>();
    }

    private void Update()
    {
        if ( (settings._preview && !settings._randomTiming && Timing["perfect"].Count != 0) ||
            ( (settings._randomTiming && settings._preview ) && ( (Timing["perfect"].Count != 0 && Random.Range(0, 100) >= 80) || (Timing["good"].Count != 0 && Random.Range(0, 100) >= 70) || (Timing["bad"].Count != 0 && Random.Range(0, 100) >= 99) ) ))
        {
            Tap();
        }
        if (Timing["DestoryPoint"].Count != 0)
        {
            GameObject obj = Timing["DestoryPoint"][0];
            Destroy(obj);
            Timing["perfect"].Remove(obj);
            Timing["good"].Remove(obj);
            Timing["bad"].Remove(obj);
            Timing["DestoryPoint"].Remove(obj);
            settings.Comment(0);
        }
        Test();
    }

    private void Test()
    {
        perfectCheck = Timing["perfect"].Count;
        goodCheck = Timing["good"].Count;
        badCheck = Timing["bad"].Count;
    }

    
    /// <summary>
    /// タップ時のノーツの状態を確認する
    /// </summary>
    public void Tap()
    {
        if (tapLight.isActiveAndEnabled)
        {
            tapLight.Tap();
        }
        else
        {
            tapLight.enabled = true;
        }

        if (Timing["perfect"].Count != 0)
        {
            notesDelete("perfect");
        }
        else if (Timing["good"].Count != 0)
        {
            notesDelete("good");
        }
        else if (Timing["bad"].Count != 0)
        {
            notesDelete("bad");
        }
    }

    private void notesDelete(string key)
    {
        settings.Comment(settings.toTimingID(key));
        try
        {
            Destroy(Timing[key][0]);
            GameObject obj = Timing[key][0];
            Timing["perfect"].Remove(obj);
            Timing["good"].Remove(obj);
            Timing["bad"].Remove(obj);
            Timing["DestoryPoint"].Remove(obj);
        }
        catch (System.NullReferenceException e)
        {
            Debug.LogError("Null Error"+e);
        }
    }

}
