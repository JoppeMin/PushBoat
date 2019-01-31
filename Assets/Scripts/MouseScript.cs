using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseScript : MonoBehaviour
{
    public GameObject Bomb;
    Vector3 mousePosition;

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);

        if (hit.collider.gameObject.tag == "WaterBody" && Input.GetMouseButtonDown(0))
        {
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 2.8f);
            print(hit.collider.gameObject);
            Instantiate(Bomb, hit.point, Quaternion.identity);
        }
    }
}
