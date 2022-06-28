using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseWorld : MonoBehaviour
{
    public static mouseWorld instant;

    private void Awake()
    {
        instant = this;
    }

    [SerializeField] private LayerMask mousePlane;
    void Update()
    {

        transform.position = mouseWorld.GetMousePosition();
    }


    public static Vector3 GetMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instant.mousePlane);

        return raycastHit.point;
    }
    

}
