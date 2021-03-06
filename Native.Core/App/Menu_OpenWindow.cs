﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Native.Sdk.Cqp.EventArgs;
using Native.Sdk.Cqp.Interface;

namespace Native.Core.App
{
    public class Menu_OpenWindow : IMenuCall
    {
        private Main _mainWindow = null;
        public void MenuCall(object sender, CQMenuCallEventArgs e)
        {
            if (this._mainWindow == null)
            {
                this._mainWindow = new Main();
                this._mainWindow.Closing += MainWindow_Closing;
                this._mainWindow.Show();	// 显示窗体
            }
            else
            {
                this._mainWindow.Activate();	// 将窗体调制到前台激活
            }
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 对变量置 null, 因为被关闭的窗口无法重复显示
            this._mainWindow = null;
        }
    }
}
