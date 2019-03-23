using G19.Source.Entity;
using G19.Source.Interface;
using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G19.Source
{
    public class World : ParentLayer
    {
        public const int CellSize = 50;
        public const int MaxRemovedBulletsCount = 100;

        public static IntPair WorldSize { get; set; } = new IntPair(1920, 1080);
        public LinkedList<IGameObject>[][] CellMap { get; set; }

        public IntPair StartPosition { get; set; }
        public Player Player { get; set; }

        public override Vector2f Size { get; set; }

        public override Drawable Background { get; set; }

        public World(string backgroundName)
        {
            StartPosition = new IntPair(WorldSize.X / 2, WorldSize.Y / 2);

            Background = new Sprite(
                Content.Backgrounds[backgroundName],
                new IntRect(0, 0, WorldSize.X, WorldSize.Y));
            ((Sprite)Background).Texture.Repeated = true;

            Size = new Vector2f(Program.Width, Program.Height);
            FrontShaderTexture = new RenderTexture((uint)WorldSize.X, (uint)WorldSize.Y);
            BackShaderTexture = new RenderTexture((uint)WorldSize.X, (uint)WorldSize.Y);

            Player = new Player(this, StartPosition);

            var cellCount = new IntPair(
                WorldSize.X / CellSize + WorldSize.X % CellSize == 0 ? 0 : 1,
                WorldSize.Y / CellSize + WorldSize.Y % CellSize == 0 ? 0 : 1);

            CellMap = new LinkedList<IGameObject>[cellCount.X][];
            for (int i = 0; i < cellCount.X; i++)
                CellMap[i] = new LinkedList<IGameObject>[cellCount.Y];

            for (int i = 0; i < cellCount.X; i++)
                for (int j = 0; j < cellCount.Y; j++)
                    CellMap[i][j] = new LinkedList<IGameObject>();
        }

        public override void Update(Time time)
        {
            base.Update(time);
            Player.Update(time); // Позже добавить в лист SubLayers
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            base.Draw(target, states);

            target.Draw(Player, states); // Позже добавить в лист SubLayers
        }

        public override Texture GetBackgroundTexture()
        {
            throw new NotImplementedException();
        }
    }
}