using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
    public bool _preview { get { return preview; } protected set { preview = value; } }
    public bool _randomTiming { get { return randomTiming; } }

    public TextMesh comment;

    [HideInInspector]
    private int Count = 0;

    [SerializeField]
    private bool preview;

    [SerializeField]
    private bool randomTiming;

    public NodeLeader nodeLeader;


    private void Awake()
    {
        comment.text = "";
        _preview = preview;
        nodeLeader = GetComponent<NodeLeader>();
    }

    /// <summary>
    /// タイミング名をタイミングIDに変換する
    /// </summary>
    /// <param name="key">タイミング名</param>
    /// <returns>タイミングID</returns>
    public int toTimingID(string key)
    {
        var ret = new System.Collections.Generic.Dictionary<string, int>()
        {
            { "bad",0 },
            { "good",1 },
            { "perfect",2 }
        };
        nodeLeader.ScoreUp(key);
        return ret[key];
    }
    
    /// <summary>
    /// カウント表示
    /// </summary>
    /// <param name="com">タイミングID(bad = 0,good = 1,perfect = 2)</param>
    public void Comment(int com)
    {
        switch (com)
        {
            case 1:
                Count++;
                comment.text = "<color=\"#5BFE6F\">Good!</color>\nCombo " + Count;
                comment.gameObject.SetActive(true);
                break;

            case 2:
                Count++;
                comment.text = "<color=\"#FEFB58\">Perfect!!</color>\nCombo "+Count;
                comment.gameObject.SetActive(true);
                break;
            case 0:

            default:
                Count = 0;
                comment.text = "<color=\"red\">Miss</color>";
                comment.gameObject.SetActive(true);
                break;
        }

    }

}
