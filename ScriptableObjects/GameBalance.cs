using UnityEditor.Rendering;
using UnityEngine;

[CreateAssetMenu(fileName = "GameBalance", menuName = "Config/GameBalance")]
public class GameBalance : ScriptableObject
{
    [Header("Size width")]
    public float offsetX = 2.2f; // Width from center to border
    public float offsetY = 0.65f; // Height between platforms

    [Header("Player")]
    public float horizontalVelocity = 80;
    public float maxHorizontalSpeed = 3;
    public float maxVerticalSpeed = 50;

    [Header("Platforms")]
    public float baseForce = 300; // Base force for standart platforms
    public float greatForce = 500; // Great force for forced platforms
    public float speedPlatform = 1; // Speed platform
}
