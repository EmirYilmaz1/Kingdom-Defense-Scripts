using UnityEngine;

public class ArrowFollow : MonoBehaviour
{
    private float arrowSpeed = 8f;
    public GameObject EnemyToFollow{get; set;}
    private void Start()
    {
      EnemyToFollow.GetComponent<Health>().OnDied += DestroyArrow;
    }

    private void DestroyArrow()
    {
      EnemyToFollow.GetComponent<Health>().OnDied -= DestroyArrow;
      Destroy(gameObject);
    }

    void Update()
    {
      transform.LookAt(EnemyToFollow.transform);  
      transform.position = Vector3.MoveTowards(transform.position,EnemyToFollow.transform.position,Time.deltaTime*arrowSpeed);
    }
}
