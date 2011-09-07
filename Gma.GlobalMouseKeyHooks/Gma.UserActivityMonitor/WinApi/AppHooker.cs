﻿using System;
using System.Runtime.InteropServices;

namespace Gma.UserActivityMonitor.WinApi
{
    public class AppHooker : BaseHooker
    {
        internal override int Subscribe(int hookId, HookCallback hookCallback)
        {
            int hookHandle = SetWindowsHookEx(
                hookId,
                hookCallback,
                IntPtr.Zero,
                GetCurrentThreadId());

            if (hookHandle == 0)
            {
                ThrowLastUnmanagedErrorAsException();
            }

            return hookHandle;
        }

        internal override bool IsGlobal
        {
            get { return false; }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetCurrentThreadId();

        /// <summary>
        /// Installs a hook procedure that monitors mouse messages. For more information, see the MouseProc hook procedure. 
        /// </summary>
        internal const int WH_MOUSE = 7;

        /// <summary>
        /// Installs a hook procedure that monitors keystroke messages. For more information, see the KeyboardProc hook procedure. 
        /// </summary>
        internal const int WH_KEYBOARD = 2;
    }
}
