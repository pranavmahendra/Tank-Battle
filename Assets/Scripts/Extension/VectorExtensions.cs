using UnityEngine;

public static class VectorExtensions
{
   public static Vector3 SetZ(this Vector3 vector, float zAxis)
    {
        return new Vector3(vector.x, vector.y, zAxis);
    }

    public static Vector3 removeYZ(this Vector3 vector)
    {
        return new Vector3(vector.x,0f,0f);
    }

   
}

