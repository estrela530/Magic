using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MagicRotation.Device;
using MagicRotation.Scene;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace MagicRotation.Actor
{
    class Player : Character
    {
        public Player(IGameMediator mediator)
            : base("player", new Vector2(64, 64), new Vector2(0, 0), mediator)
        {

        }



        public void Update()
        {
            PlayerJump();

            PlayerMove();
        }



        public void PlayerJump()
        {
            //if (Input.IsButtonDown(PlayerIndex.One, Buttons.A))
            //{
            //    velocity.Y += 10;
            //}
        }

        public void PlayerMove()
        {
            //if (Input.IsButtonDown(PlayerIndex.One, Buttons.DPadRight))
            //{
            //    velocity.X += 10;
            //}
            //else if (Input.IsButtonDown(PlayerIndex.One, Buttons.DPadLeft))
            //{
            //    velocity.X -= 10;
            //}
        }

        /// <summary>
        /// ここが弾を打つところ
        ///後で弾が完成してからそのクラスを飛ばせるように改造予定
        /// </summary>
        public void PlayerShooting()
        {
            //if (Input.IsButtonDown(PlayerIndex.One, Buttons.RightTrigger))
            //{

            //}
        }








    }
}
