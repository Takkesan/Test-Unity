using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ObjectPoolManagement objectPoolManagement;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            Shoot();
        }
    }
    
    private void Shoot()
    {
        GameObject bullet = objectPoolManagement.ReturnActiveGameObject();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }
}
