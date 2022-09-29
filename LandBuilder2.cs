using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandBuilder2 : MonoBehaviour
{
    [SerializeField]
    public int MIN_MAP_SIZE = 15;
    [SerializeField]
    public int MAX_MAP_SIZE = 20;

    [SerializeField]
    List<GameObject> Walls;

    [SerializeField]
    List<GameObject> FreeSpace;

    public List<GameObject> Map = new List<GameObject>();

    public float _landSize = 10;

    private int _mapSize;

    public void GetMapSize()
    {
        _mapSize = Random.Range(MIN_MAP_SIZE, MAX_MAP_SIZE);
    }

    public GameObject GetLand(int x, int z, List<GameObject> Lands)
    {
        int randomLand = Random.Range(0, Lands.Count);
        return Instantiate(Lands[randomLand], new Vector3(x * _landSize, 0, z * _landSize), Quaternion.Euler( -90, Random.Range(0, 4) * 90, 0 ));
    }

    public void BuildMap()
    {

        GetMapSize();

        for (int x = 0; x < _mapSize; x++)
        {
            for (int z = 0; z < _mapSize; z++)
            {
                if (x == 0 || z == 0 || x == _mapSize - 1 || z == _mapSize - 1)
                    Map.Add(GetLand(x, z, Walls));
                else
                    Map.Add(GetLand(x, z, FreeSpace));
            }
        }

    }

    public Vector3 GetCoordsForFreeSpace()
    {
        int randomLand;
      
        while (true) {
            randomLand = Random.Range(0, Map.Count);

            if (Map.Count > 0)
                { 
                if (Map[randomLand].tag == "FreeSpace") return Map[randomLand].transform.position;
                }
            else
                { 
                return new Vector3(0, 0, 0);
                }
        }
    }

    public void DeleteMap() {
        if (Map.Count > 0)
        {

            foreach (var v in Map)
            {
                Destroy(v);
            }

            Map.Clear();
        }
    }
}
