using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    int width;
    int heigh;
    float Cellsize;

    private GridObject[,] gridobjectArrays;
   public  GridSystem(int width,int heigh,float Cellsize)
    {
        this.width = width;
        this.heigh = heigh;
        this.Cellsize = Cellsize;

        gridobjectArrays = new GridObject[width, heigh];
        for(int x=0; x<width; x++)
        {
            for(int z=0;z<heigh;z++)
            {
                GridPosition gridposition = new GridPosition(x, z);
               gridobjectArrays[x,z]= new GridObject(this, gridposition);
            }
        }
    }
    
    public Vector3 GetWorldPosition(GridPosition gridposition)
    {
        return new Vector3(gridposition.x, 0, gridposition.z)*Cellsize;
    }

    public GridPosition GetGridPosition(Vector3 position)
    {
        return new GridPosition(Mathf.RoundToInt( position.x / Cellsize),Mathf.RoundToInt( position.z / Cellsize));
    }

    public void createGameDebugObjects(Transform prefetch)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < heigh; z++)
            {
                GridPosition gridposition = new GridPosition(x, z);
               Transform debugTransform= GameObject.Instantiate(prefetch, GetWorldPosition(gridposition), Quaternion.identity);
               GridDebugObject griddebugobject= debugTransform.GetComponent<GridDebugObject>();
                griddebugobject.Setgridobject(getGridObject(gridposition));
            }
        }
    }

    public GridObject getGridObject(GridPosition gridposition)
    {
        return gridobjectArrays[gridposition.x, gridposition.z];
    }
}
