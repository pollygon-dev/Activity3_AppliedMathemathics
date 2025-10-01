using System.Threading;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public float speed;
    public float rotSpeed;
    public Transform target;
    public GameObject bullet;
    public Transform spawnPoint;
    public bool inTurretRange;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("shoot", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;

        var direction = target.position - transform.position;
        direction.Normalize();
        var targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        var rot = Quaternion.Euler(0, 0, -targetAngle);
        var currentAngle = this.transform.eulerAngles.z;
        var newAngle = Mathf.LerpAngle(currentAngle, targetAngle, speed * Time.deltaTime);
        var newRot = Quaternion.Lerp(this.transform.rotation, rot, speed * Time.deltaTime);
        this.transform.rotation = newRot;

        var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2) + Mathf.Pow(target.position.y - this.transform.position.y, 2));
        var vectorDist = Vector3.Distance(target.position, this.transform.position);
        Debug.Log($"Distance {distance:f2}, Vector {vectorDist:F2}");

        if (9 > distance)
        {
            inTurretRange = true;

        }
        else 
        {
            inTurretRange = false;
        }


    }

    public void shoot()
    {
        if (inTurretRange)
        {
            GameObject projectile = Instantiate(bullet, spawnPoint.transform.position, spawnPoint.rotation);
            projectile.GetComponent<Bullet>().target = target;
        }
    }
}