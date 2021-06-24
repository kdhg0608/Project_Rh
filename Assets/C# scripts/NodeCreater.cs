using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCreater : MonoBehaviour
{
    private CSVReader csvReader = new CSVReader();
    private List<List<string>> MAP = new List<List<string>>();
    private float time;
    public GameObject Node;
    private GameObject nodeParent;
    private GameObject destination;
    private int Line = 0;
    public int selector = 0;

    private void Awake()
    {
        nodeParent = gameObject.transform.parent.gameObject;
        destination = GameObject.Find(nodeParent.name + "/TapPosition");
        selector = int.Parse(nodeParent.name.Replace("NodeLine", ""));
        MAP = csvReader.readCSV("New");
    }
    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
        if (time >= float.Parse(MAP[Line][0]))
        {
            if (int.Parse(MAP[Line][selector]) == 1)
            {
                NodeCreate();
            }
            Line++;
        }
    }

    private void NodeCreate()
    {
        var node = (GameObject)Instantiate(Node, nodeParent.transform);
        node.GetComponent<NodeMove>().destination = destination;
        node.transform.localPosition = this.transform.localPosition;
        node.transform.localRotation = this.transform.localRotation;
        node.transform.localScale = new Vector3(1f, 0.01f, 0.3f);
    }
}

