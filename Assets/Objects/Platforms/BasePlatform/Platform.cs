using UnityEngine;

public class Platform : MonoBehaviour, IHardThing
{
    public float GetHardness()
    {
        return 1f;
    }
}
