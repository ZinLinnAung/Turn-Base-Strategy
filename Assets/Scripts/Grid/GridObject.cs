using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    public GridSystem gridsystem;
    public GridPosition gridposition;
    public Unit unit;


    public GridObject(GridSystem gridsystem,GridPosition gridposition)
    {
        this.gridsystem = gridsystem;
        this.gridposition = gridposition;
    }

    public void SetUnit(Unit unit)
    {
        this.unit = unit;
    }
    public Unit GetUnit()
    {
        return unit;
    }

    public override string ToString()
    {
        return gridposition.ToString();
    }
}
