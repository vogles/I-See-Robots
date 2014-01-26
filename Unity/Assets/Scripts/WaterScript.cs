using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour
{
    public float currentStrength = 10f;
    void OnTriggerStay2D(Collider2D other)
    {
        Character character = other.GetComponent<Character>();
        if (character != null && character.State is AquaticState)
            other.attachedRigidbody.AddForce(Vector2.right * -1 * currentStrength);
    }
}