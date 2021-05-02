using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skinPos : MonoBehaviour
{
    public Slider slid;
    public GameObject button;
    public float offsetY;
    void Update()
    {
        button.transform.position = Camera.main.WorldToScreenPoint(new Vector3(0, offsetY+slid.value, 0));
    }
}
