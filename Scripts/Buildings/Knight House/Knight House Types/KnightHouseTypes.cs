using UnityEngine;

[CreateAssetMenu(fileName ="New Knight House Types", menuName = "Knight House")]
public class KnightHouseTypes : ScriptableObject
{
    public Mesh houseMesh;

    public Mesh knightMesh;
    public int knightDamage;
    public int knightMaximumHealth;
}
