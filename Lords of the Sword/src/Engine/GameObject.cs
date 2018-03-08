using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace Lords_of_the_Sword.src.Engine
{
    abstract class GameObject
    {
        public Vector2f Position;

        public GameObject(Vector2f position)
        {
            Position = position;
        }

        public abstract void Render();
        public abstract void Update();
    }
}
