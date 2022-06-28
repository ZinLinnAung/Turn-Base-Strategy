using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    private GridSystem gridsystem;
    [SerializeField] private Transform debugobject;
    [SerializeField] private int gridnumber;
    [SerializeField] private float gridsize;

    private void Awake()
    {
        
        gridsystem = new GridSystem(gridnumber,gridnumber,gridsize);

        gridsystem.createGameDebugObjects(debugobject);
    }
    void Start()
    {
        if(gridnumber==0 ||gridsize==0f)
        {
            gridnumber = 10;
            gridsize = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetUnitAtGridPosition(GridPosition gridposition,Unit unit)
    {
       GridObject gridObject= gridsystem.getGridObject(gridposition);
        gridObject.SetUnit(unit);
    }

    public Unit GetUnitAtGridPosition(GridPosition gridposition)
    {
        GridObject gridObject = gridsystem.getGridObject(gridposition);
        return gridObject.GetUnit();
    }

    public void ClearUnitAtGridPosition(GridPosition gridposition)
    {
        GridObject gridObject = gridsystem.getGridObject(gridposition);
        gridObject.SetUnit(null);
    }
}
