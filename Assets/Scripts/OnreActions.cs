using Unity.Mathematics;
using UnityEngine;
public static class OnreActions
{
    private static readonly float maxWalkSpeed = 10f;
    private static readonly float walkForce = 1000f;
    public static void Jump()
    {
        Debug.Log("Saltando");
    }
    public static void Walk(float direction, Rigidbody2D physics)
    {
        // Debug.Log($"Fuerza para caminar: {walkForce * Time.fixedDeltaTime}");
        // if (direction == 0)
        // {
        //     unity.StartCoroutine(OnrePhysics.StaticFriction(physics));
        //     return;
        // }

        if (Mathf.Abs(physics.velocity.x) < 10 || Mathf.Sign(physics.velocity.x) != Mathf.Sign(direction))
            physics.AddForce(walkForce * direction * Time.fixedDeltaTime * new Vector2(1, 0), ForceMode2D.Force);
        else if (Mathf.Abs(physics.velocity.x) != 10f)
            physics.velocity = new Vector2(Mathf.Sign(physics.velocity.x) * maxWalkSpeed, physics.velocity.y);

    }

    public static void Jump(Rigidbody2D physics)
    {
        physics.AddForce(new Vector2(0, 10f), ForceMode2D.Impulse);
    }
}
