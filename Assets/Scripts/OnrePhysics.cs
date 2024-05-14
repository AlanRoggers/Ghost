using System.Collections;
using UnityEngine;

public class OnrePhysics
{
    public static IEnumerator DynamicFriction(PhysicsMaterial2D material)
    {
        while (material.friction > 5f)
        {
            yield return null;
            material.friction -= 1f;
        }
    }

    public static IEnumerator StaticFriction(PhysicsMaterial2D material)
    {
        while (material.friction < 10f)
        {
            yield return null;
            material.friction += 1f;
        }
    }
}
