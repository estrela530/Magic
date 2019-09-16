using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicRotation.Device;
using Microsoft.Xna.Framework;

namespace MagicRotation.Actor
{
    class Space : GameObject
    {
        public Space(Vector2 position, GameDevice gameDevice)
            : base("block", position, 32, 32, gameDevice)
        {

        }

        public Space(Space other)
            : this(other.position, other.gameDevice)
        { }


        public override object Clone()
        {
            throw new NotImplementedException();
        }

        public override void Hit(GameObject gameObject)
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
