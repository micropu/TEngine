using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using TEngine;
using UnityEngine;

namespace GameLogic
{
    /// <summary>
    /// ��¼����
    /// </summary>
    public class LoginService : MonoBehaviour
    {
        GComponent _mainView;

        void Start()
        {
            _mainView = this.GetComponent<UIPanel>().ui;
            _mainView.GetChild("login").onClick.Add(() => { loginClick(); });

        }

        void loginClick()
        {
            Log.Warning("======= ����˵�¼ =======");
        }
    }
}
