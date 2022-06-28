using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{

    public static UnitActionSystem Instant { get; private set; }
   [SerializeField] private Unit selectedUnit;
   [SerializeField] private LayerMask mask;

    public event EventHandler OnEventUnitChanged;

    private void Awake()
    {
        if(Instant!=null)
        {
            Destroy(gameObject);
            return;
        }
        Instant = this;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection())
            {
                return;
            }
            selectedUnit.Move(mouseWorld.GetMousePosition());

        }
    }

   private bool TryHandleUnitSelection()
    {
        
       
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, mask))
        {
            
            if( raycastHit.transform.TryGetComponent<Unit>(out Unit unit))
            {
                SetSelectedUnit(unit);
                return true;
            }
        }

        return false;
        
    }

    private void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        OnEventUnitChanged?.Invoke(this, EventArgs.Empty);

    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}
