using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform mover; // Assign the mover GameObject here
    public Vector3 offset;

    void Update()
    {
        if (mover != null)
        {
            transform.position = mover.position + offset;
        }
    }
}
