using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
       private void OnDrawGizmos()
{
    // Match the same values you use in CheckGrounded()
    Vector2 boxSize = new Vector2(0.9f, 1.4f);
    Vector2 boxPosition = (Vector2)transform.position - new Vector2(0, 0.3f);

    Gizmos.color = Color.red;
    Gizmos.DrawWireCube(boxPosition, boxSize);
}
}
