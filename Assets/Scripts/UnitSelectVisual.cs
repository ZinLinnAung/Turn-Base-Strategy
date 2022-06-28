using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnitSelectVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    private MeshRenderer mesh;
    

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.enabled = false;
    }
    void Start()
    {
        UnitActionSystem.Instant.OnEventUnitChanged += UnitActionSystem_OnEventUnitChanged;
        VisualUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public MeshRenderer getMesh()
    {
        return mesh;
    }

    void UnitActionSystem_OnEventUnitChanged(object sender, EventArgs empty)
    {
        VisualUpdate();
    }
    private void VisualUpdate()
    {
        if (UnitActionSystem.Instant.GetSelectedUnit() == unit)
        {
            mesh.enabled = true;
        }
        else
        {
            mesh.enabled = false;
        }
    }
}
