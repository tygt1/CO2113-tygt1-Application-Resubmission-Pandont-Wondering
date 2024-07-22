using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIKickHitbox : MonoBehaviour
{
    EnemyAIController _enemyAIController;
    GameObject playerTarget;
    // Start is called before the first frame update
    void Start()
    {
        _enemyAIController = GetComponentInParent<EnemyAIController>();
    }

    private void OnTriggerEnter(Collider target)
    {
        if (_enemyAIController.isKicking())
        {
            if (target.gameObject.CompareTag("Hurtbox"))
            {
                playerTarget = target.transform.parent.gameObject;
                _enemyAIController.DealDamage(playerTarget);
            }
        }
    }
}
