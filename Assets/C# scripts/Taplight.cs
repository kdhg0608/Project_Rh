using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taplight : MonoBehaviour
{
    public float speed;
    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
        
    private void OnEnable()
    {
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 1f);
    }
    // Start is called before the first frame update
    private void Start()
    {
        if(speed == 0 || speed == null )
        {
            speed = 1;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if(renderer.material.color.a<=0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            var alfa = renderer.material.color.a - speed * Time.deltaTime;
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, alfa);
        }
    }
}
