using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
        public string playerTag = "Player";

public void Action()
{
    GameObject player = GameObject.FindWithTag(playerTag);
    if (player == null)
    {
        Debug.LogWarning("Player not found with tag: " + playerTag);
        return;
    }

    Vector3 direction = player.transform.position - transform.position;
    direction.y = 0;

    if (direction != Vector3.zero)
    {
        direction = direction.normalized; // Нормализуем вектор
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = targetRotation;
    }
}
}
