using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerOne : Controller
{
    protected override KeyCode upKey => KeyCode.W;
    protected override KeyCode downKey => KeyCode.S;
}
