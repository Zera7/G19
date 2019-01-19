using G19.Source.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace G19.Source.Event
{
    public class SFEventHandler : ISFEventHandler
    {
        public RenderWindow Window { get; }

        public SFEventHandler(RenderWindow window)
        {
            this.Window = window;
        }

        public void Connect()
        {
            Window.KeyPressed += HandleKeyPressed;
            Window.KeyReleased += HandleKeyReleased;
            Window.MouseButtonPressed += HandleMouseButtonPressed;
            Window.MouseButtonReleased += HandleMouseButtonReleased;
            Window.MouseWheelMoved += HandleMouseWheelMoved;
            Window.MouseMoved += HandleMouseMoved;
        }

        public void Disconnect()
        {
            Window.KeyPressed -= HandleKeyPressed;
            Window.KeyReleased -= HandleKeyReleased;
            Window.MouseButtonPressed -= HandleMouseButtonPressed;
            Window.MouseButtonReleased -= HandleMouseButtonReleased;
            Window.MouseWheelMoved -= HandleMouseWheelMoved;
            Window.MouseMoved -= HandleMouseMoved;
        }

        public virtual void HandleKeyPressed(object sender, KeyEventArgs e)
        {
        }

        public virtual void HandleKeyReleased(object sender, KeyEventArgs e)
        {
        }

        public virtual void HandleMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
        }

        public virtual void HandleMouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
        }

        public virtual void HandleMouseMoved(object sender, MouseMoveEventArgs e)
        {
        }

        public virtual void HandleMouseWheelMoved(object sender, MouseWheelEventArgs e)
        {
        }
    }
}
