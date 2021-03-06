using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 3.0f;

    public int damage = 100;

    private Vector3 target;

    public void SetTarget(Vector3 target)
    {
        this.target = target;
        this.gameObject.SetActive(true);
    }

    private void Update()
    {
        float sqrDis = Vector3.SqrMagnitude(transform.position - target);
        float move = speed * Time.deltaTime;
        if (sqrDis > move * move)
        {
            transform.position += (target - transform.position).normalized * move;
        }
        else
        {
            GameManager.Instance.SendDamage(transform.position, damage);
            this.gameObject.SetActive(false);
            GameManager.Instance.RecycleBullet(this);
        }
    }

}
