using System;
using Microsoft.Xna.Framework.Input;

namespace Industrio.Engine.UI;

public abstract class UIElement : Entity
{
    public Action<MouseState> OnHover { get; set; } = (state) => { };
    public Action<MouseState> OnClick { get; set; } = (state) => { };

    private MouseState _previousState = Mouse.GetState();

    public UIElement()
    {
        Name = "Unnamed UIElement";
        OnUpdate += Update;
    }

    private void Update(object sender, UpdateEventArgs e)
    {
        var mouseState = Mouse.GetState();

        if (IsHovered())
        {
            OnHover(mouseState);

            var buttonReleasedLeft = _previousState.LeftButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released;
            var buttonReleasedRight = _previousState.RightButton == ButtonState.Pressed && mouseState.RightButton == ButtonState.Released;
            var buttonReleasedMiddle = _previousState.MiddleButton == ButtonState.Pressed && mouseState.MiddleButton == ButtonState.Released;

            if (buttonReleasedLeft || buttonReleasedRight || buttonReleasedMiddle)
            {
                OnClick(_previousState);
            }
        }

        _previousState = mouseState;
    }

    public virtual bool IsHovered()
    {
        return false;
    }
}