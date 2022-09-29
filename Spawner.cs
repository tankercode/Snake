using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    public LandBuilder2 LandBuilder;

    [SerializeField]
    public List<GameObject> SpawnItems;

    [SerializeField]
    public Vector3 _quaternionEuler;

    private bool _isRunning = true;

    public float SpawnTime;

    private Vector3 ItemCoords;

    private List<GameObject> _createdItems = new List<GameObject>();

    public void StartCreatingItems() {
        _isRunning = true;
        StartCoroutine(ItemsSpawn());
    }

    public void StopCreatingItems() {
        _isRunning = false;
    }

    IEnumerator ItemsSpawn()
    {
        while (_isRunning)
        {
            if (_isRunning)
            {
                yield return new WaitForSeconds(SpawnTime);

                ItemCoords = LandBuilder.GetCoordsForFreeSpace();

                _createdItems.Add(
                    Instantiate(
                        SpawnItems[Random.Range(0, SpawnItems.Count)],

                        ItemCoords + new Vector3(
                                            Random.Range(-LandBuilder._landSize / 2, LandBuilder._landSize / 2),
                                            1,
                                            Random.Range(-LandBuilder._landSize / 2, LandBuilder._landSize / 2)),
                        Quaternion.Euler(_quaternionEuler))
                );
            }
        }
    }

    public void KillEVERYONE() {

        if (_createdItems.Count > 0)

            foreach (var v in _createdItems)
            {
                Destroy(v);
            }

        _createdItems.Clear();

    }
}
