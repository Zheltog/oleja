using UnityEngine;

public class CamVerRot : MonoBehaviour
{
    public float sen = 1;
    public float min = -5;
    public float max = 10;
    
    private float _rotX;

    private void Update()
    {
        _rotX -= Input.GetAxis("Mouse Y") * sen;
        _rotX = Mathf.Clamp(_rotX, min, max);
        transform.localEulerAngles = new Vector3(_rotX, 0, 0); 
    }
}
