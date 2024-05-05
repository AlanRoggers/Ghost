using Unity.Mathematics;
using UnityEngine;
public class OnreActions
{
    public static void Jump()
    {
        Debug.Log("Saltando");
    }

    public static void Walk(float direction, Rigidbody2D physics)
    {
        if (Mathf.Abs(physics.velocity.x) < 10)
            physics.AddForce(5 * direction * new Vector2(1, 0), ForceMode2D.Force);
    }
}
