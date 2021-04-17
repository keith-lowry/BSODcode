using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D coll)
    {
        //if the collider's object is named "Player"
        if (coll.gameObject.tag.Equals("Player"))
        {
            FailureHandler.Instance.TriggerFailure();
        }
    }

}
