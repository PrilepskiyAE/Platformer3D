using UnityEngine;

public class Rebbit : MonoBehaviour
{

 [SerializeField ] private RotateTowardsPlayer rotateTowardsPlayer;

    // Update is called once per frame
    void Update()
    {
        rotateTowardsPlayer.Action();
        
    }
}
