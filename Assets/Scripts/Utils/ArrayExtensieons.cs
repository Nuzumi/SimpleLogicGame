using UnityEngine;

public static class ArrayExtensieons
{
    public static bool FitInBounds<T>(this T[,] array, Vector2Int position)
    {
        if (position.x < 0 || position.y < 0)
            return false;

        if (position.x >= array.GetLength(0) || position.y >= array.GetLength(1))
            return false;

        return true;
    }
}
