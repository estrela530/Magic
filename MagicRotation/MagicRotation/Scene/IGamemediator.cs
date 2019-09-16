using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MagicRotation.Actor;

namespace MagicRotation.Scene
{
    /// <summary>
    /// ゲーム仲介者
    /// </summary>
    interface IGameMediator
    {
        // キャラクターを追加
        void AddActor(Character character);
        // マップ取得
        Map GetMap();
    }
}
