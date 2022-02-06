using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEditor;
using UnityEngine.InputSystem.Layouts;

#if UNITY_EDITOR
[InitializeOnLoad]
#endif
[DisplayStringFormat("{x}+{y}+{z}")]
public class MouseVector3Composite : InputBindingComposite<Vector3>
{
    [InputControl(layout = "Button")]
    public int x;

    [InputControl(layout = "Button")]
    public int y;
    [InputControl(layout = "Button")]
    public int z;

    public override Vector3 ReadValue(ref InputBindingCompositeContext context)
    {
        var xValue = context.ReadValue<float>(x);
        var yValue = context.ReadValue<float>(y);
        var zValue = context.ReadValue<float>(z);

        return new Vector3(xValue, yValue, zValue);
    }

    static MouseVector3Composite()
    {
        InputSystem.RegisterBindingComposite<MouseVector3Composite>();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init() {}
}