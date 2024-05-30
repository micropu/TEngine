using Cysharp.Threading.Tasks;
using TEngine;

namespace GameLogic
{
    /// <summary>
    /// ʵ���ҷ���
    /// </summary>
    [Update]
    public class BattleSystem : BehaviourSingleton<BattleSystem>
    {
        private float _startWaitTimer = 1f;

        /// <summary>
        /// ���ط���
        /// </summary>
        public async UniTaskVoid LoadRoom()
        {
            _startWaitTimer = 1f; // ���õȴ�ʱ��
            await UniTask.Yield(); // �ȴ�һ֡
            //// �������������
            //_roomRoot = new GameObject("BattleRoom");

            // ���ر�������
            GameModule.Audio.Play(AudioType.Music, "music_background", true);

            //// �������ʵ�����
            //var handle = PoolManager.Instance.GetGameObject("player_ship", parent: _roomRoot.transform);
            //var entity = handle.GetComponent<EntityPlayer>();

            //// ��ʾս������
            //GameModule.UI.ShowUIAsync<UIBattleWindow>();

            //// ������Ϸ�¼�
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.PlayerDead, OnPlayerDead);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.EnemyDead, OnEnemyDead);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.AsteroidExplosion, OnAsteroidExplosion);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.PlayerFireBullet, OnPlayerFireBullet);
            //GameEvent.AddEventListener<Vector3, Quaternion>(ActorEventDefine.EnemyFireBullet, OnEnemyFireBullet);

            //_steps = ESteps.Ready;
        }

    }
}
