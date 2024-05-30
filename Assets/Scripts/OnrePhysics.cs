using System.Collections;
using UnityEngine;

public static class OnrePhysics
{
    private static readonly float frictionForce = 800f;
    public static IEnumerator Friction(Rigidbody2D physics, float direction)
    {
        for (int i = 0; i < 10; i++)
        {
            physics.AddForce(-1 * Mathf.Sign(direction) * Time.fixedDeltaTime * frictionForce * new Vector2(1, 0), ForceMode2D.Force);
            yield return new WaitForFixedUpdate();
        }
    }
    public static IEnumerator StaticFriction(Rigidbody2D physics)
    {
        float velocityStartedSign = Mathf.Sign(physics.velocity.x);

        // Si a este while no entra, el movimiento se buguea al presionar rapido una tecla para caminar
        // Esta arreglado pero me gustaría saber porque pasaba si en teoría forzar la velocidad en cero
        // Con el código del final debería haber evitado ese bug desde un principio
        while (Mathf.Sign(physics.velocity.x) == velocityStartedSign)
        {
            Debug.Log("Static Friction");
            physics.AddForce(-1 * Mathf.Sign(physics.velocity.x) * Time.fixedDeltaTime * 500f * new Vector2(1, 0), ForceMode2D.Force);
            yield return new WaitForFixedUpdate();
        }

        physics.velocity = new Vector2(0, physics.velocity.y);
    }
}
