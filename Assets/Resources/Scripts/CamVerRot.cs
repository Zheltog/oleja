using UnityEngine;

public class CamVerRot : MonoBehaviour
{
    public float sen = 7;
    public float min = -60;
    public float max = 80;
    
    private float _rotX;

    private void Update()
    {
        if (Time.timeScale < 1)
        {
            return;
            // TODO: ?
        }
        
        _rotX -= Input.GetAxis("Mouse Y") * sen;
        _rotX = Mathf.Clamp(_rotX, min, max);
        transform.localEulerAngles = new Vector3(_rotX, 0, 0); 
    }
}
