using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeMove : MonoBehaviour
{
    
    public float moveTime;
    public GameObject destination;
    private new Transform transform;
    private float time = 0f;
    private Vector3 v_start;
    private Vector3 v_destination;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        v_destination = destination.transform.position;
        v_start = this.transform.position;
    }
       
    // Update is called once per frame
    void Update()
    {
        var v = time / moveTime;
        transform.position = Vector3.Lerp(v_start, v_destination, v);
        time += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(destination == collision.gameObject)
        {
            Debug.Log(time);
        }
    }
}
