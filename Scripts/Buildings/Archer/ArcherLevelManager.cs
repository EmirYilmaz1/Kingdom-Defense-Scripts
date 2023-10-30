using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherLevelManager : MonoBehaviour
{
    ArcherTowerLevelManager archerTowerLevelManager;
    void Start()
    {
        archerTowerLevelManager = GetComponentInParent<ArcherTowerLevelManager>();
        archerTowerLevelManager.OnLevelChanged += SetArcherSkin;
    }

    private void SetArcherSkin()
    {
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().sharedMesh = archerTowerLevelManager.CurrentArcherHouseTypes.archerMesh;
    }
}
