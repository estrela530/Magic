using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicRotation.Scene;

using Microsoft.Xna.Framework;

namespace MagicRotation.Actor
{
    class Character
    {        
        // 位置
        protected Vector2 position;
        // 速度
        protected Vector2 velocity;
        // 画像の名前
        protected string name;
        // 画像サイズ
        protected Vector2 imageSize;
        //仲介者
        protected IGameMediator mediator;


        public Character(string name, Vector2 imageSize, Vector2 position ,IGameMediator mediator)
        {
            // 引数の受け取り
            this.name = name;
            this.imageSize = imageSize;
            this.mediator = mediator;
            
            // 位置初期化
            position = Vector2.Zero;
        }

    }
}
