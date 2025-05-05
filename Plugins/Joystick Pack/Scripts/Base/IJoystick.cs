using UnityEngine;

public interface IJoystick
{
    float Horizontal { get; }
    float Vertical { get; }
    Vector3 Direction { get; }
}