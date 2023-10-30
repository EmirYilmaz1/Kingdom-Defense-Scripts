using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightLevelManager : MonoBehaviour
{
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private KnightHouseLevelManager knightHouseLevelManager;
    private KnightAttackState knightAttackState;
    private Health health;
    void Start()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        knightHouseLevelManager =  GetComponentInParent<KnightHouseLevelManager>();
        knightAttackState = GetComponent<KnightAttackState>();
        health = GetComponent<Health>();
        knightHouseLevelManager.OnLevelChanged += ChangeKnight;
    }

    private void ChangeKnight()
    {
        ChangeMesh();
        ChangeHealt();
    }

    private void ChangeMesh()
    {
        skinnedMeshRenderer.sharedMesh = knightHouseLevelManager.CurrentKnightHouseType.knightMesh;
    }

    private void ChangeHealt()
    {
        health.MaximumHealth = knightHouseLevelManager.CurrentKnightHouseType.knightMaximumHealth;
        health.CurrentHealth = knightHouseLevelManager.CurrentKnightHouseType.knightMaximumHealth;
    }

    private void ChangeAttackInfos()
    {
        knightAttackState.Damage = knightHouseLevelManager.CurrentKnightHouseType.knightDamage;
    }

}
