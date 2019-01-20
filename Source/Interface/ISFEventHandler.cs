using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source.Interface
{
    public interface ISFEventHandler
    {
        RenderWindow Window { get; }
        Cursor Cursor { get; }

        void HandleKeyPressed(object sender, KeyEventArgs e);
        void HandleKeyReleased(object sender, KeyEventArgs e);
        void HandleMouseWheelMoved(object sender, MouseWheelEventArgs e);
        void HandleMouseMoved(object sender, MouseMoveEventArgs e);
        void HandleMouseButtonPressed(object sender, MouseButtonEventArgs e);
        void HandleMouseButtonReleased(object sender, MouseButtonEventArgs e);
        void Connect();
        void Disconnect();
    }
}
