using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GridDebugObject : MonoBehaviour
{

    [SerializeField] private TextMeshPro tmpro;
    private GridObject gridobject;

    public void Setgridobject(GridObject gridobject)
    {
        this.gridobject = gridobject;
        
        
    }
    private void Update()
    {
        tmpro.text = gridobject.ToString();
    }
}
