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
    public class World : Transformable, ILayer
    {
        public const int CellSize = 50;

        public IntPair WorldSize { get; set; } = new IntPair(1920, 1080);
        public LinkedList<IGameObject>[][] CellMap { get; set; }

        public Player Player { get; set; }
        public LinkedList<Bullet> Bullets { get; set; } = new LinkedList<Bullet>();
        public List<ILayer> Layers { get; set; }

        public IntPair StartPosition;
        public Sprite Background;
        
        public World(string backgroundName)
        {
            StartPosition = new IntPair(WorldSize.X / 2, WorldSize.Y / 2);

            Background = new Sprite(
                Content.Backgrounds[backgroundName], 
                new IntRect(0, 0, WorldSize.X, WorldSize.Y));
            Background.Texture.Repeated = true;

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

        public void Update(Time time)
        {
            Program.Cursor.Move();
            Player.Update(time);

            var currentBullet = Bullets.First;
            while (currentBullet != null)
            {
                currentBullet.Value.Update(time);
                if (!currentBullet.Value.IsInsideMap)
                    Bullets.Remove(currentBullet);
                currentBullet = currentBullet.Next;
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(Background); 
            target.Draw(Player, states);
            foreach (var bullet in Bullets)
                target.Draw(bullet, states);
        }

        public void ShowLayer()
        {
            throw new NotImplementedException();
        }

        public void HideLayer()
        {
            throw new NotImplementedException();
        }
    }
}
