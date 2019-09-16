using MagicRotation.Actor;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicRotation.Scene
{
    interface IGameObjectMediator
    {
        //ゲームオブジェクト追加
        void AddGameObject(GameObject gameObject);

        //プレイヤーを取得
        GameObject GetPlayer();

        //プレイヤーが死んでるかどうか
        bool IsPlayerDead();

        //特定のオブジェクトを取得する
        GameObject GetGameObject(GameObjectID id);
        //List<GameObject>GetGameObject(GameObjectID id);//戻り値だけ違うメソッドは定義できない

        //複数のゲームオブジェクトの取得
        //List<GameObject> GetGameObjectList(GameObjectID id);

        //マップ全体のサイズの取得
        Vector2 MapSize();

        //リスポーン位置をセット
        void SetRespawnPos(Vector2 respawnPos);
    }
}
