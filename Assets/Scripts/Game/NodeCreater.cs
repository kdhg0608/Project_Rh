using UnityEngine;
using System.Collections.Generic;

public class NodeCreater : MonoBehaviour {
    private List<List<string>> MAP = new List<List<string>>();
    private float time;
    public GameObject Node;
    private GameObject nodeParent;
    private GameObject lostPosition;
    private GameObject destination;
    private int Line = 1;
    public int Selector = 0;
    private AudioSource audioSource;
    private void Awake()
    {
        nodeParent = gameObject.transform.parent.gameObject;
        destination = GameObject.Find(nodeParent.name + "/TapPosition");
        lostPosition = GameObject.Find(nodeParent.name + "/lostPosition");
        Selector = int.Parse(nodeParent.name.Replace("NodeLine",""));
        audioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    private void Start()
    {
        MAP = GameObject.Find("Feeld").GetComponent<NodeLeader>().MAP;
    }


    private void Update()
    {
        time += Time.deltaTime;
        try
        {
            if (time >= float.Parse(MAP[Line][0]))
            {
                if (int.Parse(MAP[Line][Selector]) == 1)
                {
                    NodeCreate();
                }
                Line++;
            }
            if(time <= 3f)
            {
                audioSource.Play();
            }
        }
        catch (System.ArgumentOutOfRangeException e)
        {
            //TODO 曲の状態を取得して、曲が終了していればリザルト画面へ遷移する。
        }
    }

    private void NodeCreate()
    {
        var node = (GameObject)Instantiate(Node,nodeParent.transform);
        node.GetComponent<NodeMove>().destination = destination;
        node.GetComponent<NodeMove>().lostPosition = lostPosition;
        node.transform.localPosition = this.transform.localPosition;
        node.transform.localRotation = this.transform.localRotation;
        node.transform.localScale = new Vector3(1f, 0.01f, -0.01f);
    }
}
