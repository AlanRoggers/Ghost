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
            physics.AddForce(25 * direction * new Vector2(1, 0), ForceMode2D.Force);
    }

    public static void Jump(Rigidbody2D physics)
    {
        physics.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
    }
}
