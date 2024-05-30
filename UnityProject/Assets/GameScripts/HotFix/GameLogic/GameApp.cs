using System.Collections.Generic;
using System.Reflection;
using Cysharp.Threading.Tasks;
using GameBase;
using GameLogic;
using TEngine;

/// <summary>
/// 游戏App。
/// </summary>
public partial class GameApp:Singleton<GameApp>
{
    private static List<Assembly> _hotfixAssembly;
    
    /// <summary>
    /// 热更域App主入口。
    /// </summary>
    /// <param name="objects"></param>
    public static void Entrance(object[] objects)
    {
        _hotfixAssembly = (List<Assembly>)objects[0];
        Log.Warning("======= 看到此条日志代表你成功运行了热更新代码 =======");
        Log.Warning("======= Entrance GameApp =======");
        Instance.Active();
        Instance.Start();
        Utility.Unity.AddUpdateListener(Instance.Update);
        Utility.Unity.AddFixedUpdateListener(Instance.FixedUpdate);
        Utility.Unity.AddLateUpdateListener(Instance.LateUpdate);
        Utility.Unity.AddDestroyListener(Instance.OnDestroy);
        Utility.Unity.AddOnDrawGizmosListener(Instance.OnDrawGizmos);
        Utility.Unity.AddOnApplicationPauseListener(Instance.OnApplicationPause);
        GameModule.Procedure.RestartProcedure(new GameLogic.OnEnterGameAppProcedure());
        Instance.StartGameLogic();
    }

    /// <summary>
    /// 开始游戏业务层逻辑。
    /// <remarks>显示UI、加载场景等。</remarks>
    /// </summary>
    private void StartGameLogic()
    {
        // 在这里，.Forget() 是一个用于处理异步任务的特殊方法，通常用于忽略异步任务的结果或异常情况。
        // 在C#中使用UniTask库时，.Forget() 方法可以在不需要等待异步任务完成或者不需要处理其结果时使用。
        // 具体来说，.Forget() 方法用于“忘记”这个异步操作，不捕获它的结果，也不捕获它可能抛出的异常。这通常在以下几种情况下有用：
        // 1,Fire-and-Forget：当你启动一个异步操作但不需要等待它完成或者不关心它的结果时使用。
        // 2,避免编译器警告：如果你启动一个异步任务但没有等待它，编译器可能会给出警告，提醒你未处理任务的结果。使用.Forget()可以消除这些警告。
        StartBattleRoom().Forget();
    }

    private async UniTaskVoid StartBattleRoom()
    {
        // .ToUniTask() 是一种方法，将其他异步类型转换为 UniTask 类型。
        // UniTask 是一个高性能的 C# 异步库，它是 UniRx 的一部分，通常用于 Unity 游戏开发中以替代原生的 Task 和 Coroutine。
        await GameModule.Scene.LoadScene("scene_battle").ToUniTask();
        BattleSystem.Instance.LoadRoom().Forget();
    }

    /// <summary>
    /// 关闭游戏。
    /// </summary>
    /// <param name="shutdownType">关闭游戏框架类型。</param>
    public static void Shutdown(ShutdownType shutdownType)
    {
        Log.Info("GameApp Shutdown");
        if (shutdownType == ShutdownType.None)
        {
            return;
        }

        if (shutdownType == ShutdownType.Restart)
        {
            Utility.Unity.RemoveUpdateListener(Instance.Update);
            Utility.Unity.RemoveFixedUpdateListener(Instance.FixedUpdate);
            Utility.Unity.RemoveLateUpdateListener(Instance.LateUpdate);
            Utility.Unity.RemoveDestroyListener(Instance.OnDestroy);
            Utility.Unity.RemoveOnDrawGizmosListener(Instance.OnDrawGizmos);
            Utility.Unity.RemoveOnApplicationPauseListener(Instance.OnApplicationPause);
        }
        
        SingletonSystem.Release();
    }

    private void Start()
    {
        var listLogic = _listLogicMgr;
        var logicCnt = listLogic.Count;
        for (int i = 0; i < logicCnt; i++)
        {
            var logic = listLogic[i];
            logic.OnStart();
        }
    }

    private void Update()
    {
        TProfiler.BeginFirstSample("Update");
        var listLogic = _listLogicMgr;
        var logicCnt = listLogic.Count;
        for (int i = 0; i < logicCnt; i++)
        {
            var logic = listLogic[i];
            TProfiler.BeginSample(logic.GetType().FullName);
            logic.OnUpdate();
            TProfiler.EndSample();
        }
        TProfiler.EndFirstSample();
    }

    private void FixedUpdate()
    {
        TProfiler.BeginFirstSample("FixedUpdate");
        var listLogic = _listLogicMgr;
        var logicCnt = listLogic.Count;
        for (int i = 0; i < logicCnt; i++)
        {
            var logic = listLogic[i];
            TProfiler.BeginSample(logic.GetType().FullName);
            logic.OnFixedUpdate();
            TProfiler.EndSample();
        }
        TProfiler.EndFirstSample();
    }

    private void LateUpdate()
    {
        TProfiler.BeginFirstSample("LateUpdate");
        var listLogic = _listLogicMgr;
        var logicCnt = listLogic.Count;
        for (int i = 0; i < logicCnt; i++)
        {
            var logic = listLogic[i];
            TProfiler.BeginSample(logic.GetType().FullName);
            logic.OnLateUpdate();
            TProfiler.EndSample();
        }
        TProfiler.EndFirstSample();
    }

    private void OnDestroy()
    {
        var listLogic = _listLogicMgr;
        var logicCnt = listLogic.Count;
        for (int i = 0; i < logicCnt; i++)
        {
            var logic = listLogic[i];
            logic.OnDestroy();
        }
        Shutdown(ShutdownType.Restart);
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        var listLogic = _listLogicMgr;
        var logicCnt = listLogic.Count;
        for (int i = 0; i < logicCnt; i++)
        {
            var logic = listLogic[i];
            logic.OnDrawGizmos();
        }
#endif
    }

    private void OnApplicationPause(bool isPause)
    {
        var listLogic = _listLogicMgr;
        var logicCnt = listLogic.Count;
        for (int i = 0; i < logicCnt; i++)
        {
            var logic = listLogic[i];
            logic.OnApplicationPause(isPause);
        }
    }
}