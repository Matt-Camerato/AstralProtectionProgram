using System;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    public static event Action Fire;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Fire.Invoke();

        transform.rotation = Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }
}
