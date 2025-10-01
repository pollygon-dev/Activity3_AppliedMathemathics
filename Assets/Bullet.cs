using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (target != null) {
            var distance = Mathf.Sqrt(Mathf.Pow(target.position.x - this.transform.position.x, 2) + Mathf.Pow(target.position.y - this.transform.position.y, 2));
            var vectorDist = Vector3.Distance(target.position, this.transform.position);
            Debug.Log($"Distance {distance:f2}, Vector {vectorDist:F2}");

            if (1 >= distance)
            {
                target.transform.position = new Vector3(-7.9f, -0.06f, 0);
            }
        }

    }
}
