using Cysharp.Threading.Tasks;
using TEngine;

namespace GameLogic
{
    /// <summary>
    /// 实验室房间
    /// </summary>
    [Update]
    public class BattleSystem : BehaviourSingleton<BattleSystem>
    {
        private float _startWaitTimer = 1f;

        /// <summary>
        /// 加载房间
        /// </summary>
        public async UniTaskVoid LoadRoom()
        {
            _startWaitTimer = 1f; // 重置等待时间
            await UniTask.Yield(); // 等待一帧
            //// 创建房间根对象
            //_roomRoot = new GameObject("BattleRoom");

            // 加载背景音乐
            GameModule.Audio.Play(AudioType.Music, "music_background", true);

            //// 创建玩家实体对象
            //var handle = PoolManager.Instance.GetGameObject("player_ship", parent: _roomRoot.transform);
            //var entity = handle.GetComponent<EntityPlayer>();

            //// 显示战斗界面
            //GameModule.UI.ShowUIAsync<UIBattleWindow>();

            //// 监听游戏事件
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.PlayerDead, OnPlayerDead);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.EnemyDead, OnEnemyDead);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.AsteroidExplosion, OnAsteroidExplosion);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.PlayerFireBullet, OnPlayerFireBullet);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.EnemyFireBullet, OnEnemyFireBullet);

            //_steps = ESteps.Ready;
        }

    }
}
