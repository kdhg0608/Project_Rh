using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGetter : MonoBehaviour {
    //int a = 0, s = 0, d = 0, f = 0, g = 0;

    public Dictionary<GameObject,TouchPhase> OnTouchPhase()
    {
        Dictionary<GameObject, TouchPhase> ret = new Dictionary<GameObject, TouchPhase>();

        if ( 0 < Input.touchCount)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycast_hit = new RaycastHit();
                if(Physics.Raycast(ray,out raycast_hit))
                {
                    ret.Add(raycast_hit.collider.gameObject, touch.phase);
                }
            }
        }
        return ret;
    }
    

}
////인풋 A~G 입력;
//if (Input.anyKey)
//{
//    Debug.Log("input");
//    if (Input.GetKeyDown("a"))
//    {
//        a = 1;
//        Debug.Log("a 키를 누르고 있는 동안 출력");
//    }
//    if (Input.GetKeyDown("s"))
//    {
//        s = 1;
//        Debug.Log("s 키를 누르고 있는 동안 출력");
//    }
//    if (Input.GetKeyDown("d"))
//    {
//        d = 1;
//        Debug.Log("d 키를 누르고 있는 동안 출력");
//    }
//    if (Input.GetKeyDown("f"))
//    {
//        f = 1;
//        Debug.Log("f 키를 누르고 있는 동안 출력");
//    }
//    if (Input.GetKeyDown("g"))
//    {
//        g = 1;
//        Debug.Log("g 키를 누르고 있는 동안 출력");
//    }
//}