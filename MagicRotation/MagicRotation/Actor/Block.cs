using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicRotation.Device;
using Microsoft.Xna.Framework;

namespace MagicRotation.Actor
{
    class Block : GameObject
    {
        public Block(Vector2 position, GameDevice gameDevice)
            : base("block", position, 32, 32, gameDevice)
        {

        }

        public Block(Block other)
            :this(other.position, other.gameDevice)
        { }


        public override object Clone()
        {
            return new Block(this);
        }

        public override void Hit(GameObject gameObject)
        {

        }

        public override void Update(GameTime gameTime)
        {

        }
    }
}
