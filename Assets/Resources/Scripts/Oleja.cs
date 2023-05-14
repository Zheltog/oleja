using UnityEngine;

public class Oleja : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    
    private void Update() {
        var t = transform;
        
        t.Translate(0, 0, speed * Time.deltaTime);
        var ray = new Ray(t.position, t.forward);

        if (!Physics.SphereCast(ray, 0.75f, out var hit)) return;
        if (!(hit.distance < obstacleRange)) return;
        
        float angle = Random.Range(-110, 110);
        transform.Rotate(0, angle, 0);
    }
}