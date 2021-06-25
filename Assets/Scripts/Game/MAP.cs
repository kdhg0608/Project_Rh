using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class MAP : MonoBehaviour {
    private CSVWriter csvWriter = new CSVWriter();
    private List<List<string>> csv = new List<List<string>>();
    private Text text;
    int a = 0;
    int s = 0;
    int d = 0;
    int f = 0;
    int g = 0;
    float time = 0;

    private void Awake()
    {
        text = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void LateUpdate () {
        time += Time.deltaTime;
        if (a + s + d + f + g != 0)
        {
            List<string> line = new List<string>();
            line.Add(time.ToString());
            line.Add(a.ToString());
            line.Add(s.ToString());
            line.Add(d.ToString());
            line.Add(f.ToString());
            line.Add(g.ToString());
            csv.Add(line);
            a = s = d = f = g = 0;
            Debug.Log("output");
        }
        if (Input.anyKey)
        {
            Debug.Log("input");
            if (Input.GetKeyDown("a"))
            {
                a = 1;
                text.text = time+" : A";
            }
            if (Input.GetKeyDown("s"))
            {
                s = 1;
                text.text = time+" : S";
            }
            if (Input.GetKeyDown("d"))
            {
                d = 1;
                text.text = time+ ": D";
            }
            if (Input.GetKeyDown("f"))
            {
                f = 1;
                text.text = time + ": F";
            }
            if (Input.GetKeyDown("g"))
            {
                g = 1;
                text.text = time + ": G";
            }

        }
	}

    private void OnApplicationQuit()
    {
        csvWriter.writeCSV(csv, "Turkey");
    }
}
