using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody ridigbody_;
    private void Start()
    {
        ridigbody_ = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ridigbody_.velocity = transform.forward * 10;
    }

    private void OnBecameInvisible()
    {
        // 画面外に出たら弾をPoolに戻す
        ridigbody_.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
}
