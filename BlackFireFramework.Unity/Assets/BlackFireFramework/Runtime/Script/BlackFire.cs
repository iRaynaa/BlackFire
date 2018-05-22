﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework;
using BlackFireFramework.Unity;
using UnityEngine;

/// <summary>
/// BlackFireFramework主要程序入口类。
/// </summary>
[GameObjectIcon("BlackFire")]
public sealed partial class BlackFire : MonoBehaviour
{
    #region LifeCircle

    /// <summary>
    /// 框架所有者。
    /// </summary>
    private static readonly object s_Unity = new object();

    /// <summary>
    /// BlackFire行为类唯一实例。
    /// </summary>
    private static object s_Instance = null;

    /// <summary>
    /// 场景加载之前事件。
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void OnBeforeSceneLoad()
    {
        Log.SetLogCallback(LogCallback);
        Framework.Born(s_Unity, Time.unscaledDeltaTime, Time.deltaTime);
    }

    private void Awake()
    {
        DontDestroyOnLoad();
        InitAssembly(this);
        InitModule(this);
        InitManager(this);
    }

    /// <summary>
    /// 轮询事件。
    /// </summary>
    private void Update()
    {
        Framework.Act(s_Unity, Time.unscaledDeltaTime, Time.deltaTime);
    }

    /// <summary>
    /// 被销毁事件。
    /// </summary>
    private void OnDestroy()
    {
        ExportedAssemblyDestroy();
        Framework.Die(s_Unity, Time.unscaledDeltaTime, Time.deltaTime);

        if (this.Equals(s_Instance))
        {
            s_Instance = null;
        }
    }

    private void DontDestroyOnLoad()
    {
        if (null == s_Instance)
        {
            s_Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }


    #endregion







}

