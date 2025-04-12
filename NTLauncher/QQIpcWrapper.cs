using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NTLauncher
{
    public class QQIpcWrapper
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void CallbackIpc(IntPtr pArg, string msg, int arg3, string addition_msg, int addition_msg_size);

        // QQIpcParentWrapper

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "CreateQQIpcParentWrapper", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateQQIpcParentWrapper();

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "DeleteQQIpcParentWrapper", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteQQIpcParentWrapper(IntPtr instance);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_OnDefaultReceiveMsg", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcParentWrapper_OnDefaultReceiveMsg(IntPtr pArg, string msg, int arg3, string addition_msg, int addition_msg_size);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_InitEnv", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool QQIpcParentWrapper_InitEnv(IntPtr instance, string dll_path);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_SetLogLevel", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcParentWrapper_SetLogLevel(IntPtr instance, int level);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_GetLastErrStr", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr QQIpcParentWrapper_GetLastErrStr(IntPtr instance);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_InitLog", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcParentWrapper_InitLog(IntPtr instance, int level, IntPtr callback);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_InitParentIpc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcParentWrapper_InitParentIpc(IntPtr instance);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_LaunchChildProcess", CallingConvention = CallingConvention.Cdecl)]
        public static extern int QQIpcParentWrapper_LaunchChildProcess(IntPtr instance, string file_path, CallbackIpc callback, IntPtr cb_arg, string[] cmdlines, int cmd_num);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_ConnectedToChildProcess", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool QQIpcParentWrapper_ConnectedToChildProcess(IntPtr instance, int pid);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_SendIpcMessage", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool QQIpcParentWrapper_SendIpcMessage(IntPtr instance, int pid, string command, string addition_msg, int addition_msg_size);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_TerminateChildProcess", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool QQIpcParentWrapper_TerminateChildProcess(IntPtr instance, int pid, int exit_code, bool wait_);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcParentWrapper_ReLaunchChildProcess", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool QQIpcParentWrapper_ReLaunchChildProcess(IntPtr instance, int pid);

        // QQIpcChildWrapper

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "CreateQQIpcChildWrapper", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr CreateQQIpcChildWrapper();

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "DeleteQQIpcChildWrapper", CallingConvention = CallingConvention.Cdecl)]
        public static extern void DeleteQQIpcChildWrapper(IntPtr instance);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcChildWrapper_GetLastErrStr", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr QQIpcChildWrapper_GetLastErrStr(IntPtr instance);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcChildWrapper_InitEnv", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool QQIpcChildWrapper_InitEnv(IntPtr instance, string dll_path);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcChildWrapper_InitChildIpc", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcChildWrapper_InitChildIpc(IntPtr instance);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcChildWrapper_InitLog", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcChildWrapper_InitLog(IntPtr instance, int level, IntPtr callback);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcChildWrapper_SetChildReceiveCallback", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcChildWrapper_SetChildReceiveCallback(IntPtr instance, CallbackIpc callback);

        [DllImport("MMMojoCallWrapper.dll", EntryPoint = "QQIpcChildWrapper_SendIpcMessage", CallingConvention = CallingConvention.Cdecl)]
        public static extern void QQIpcChildWrapper_SendIpcMessage(IntPtr instance, string command, string addition_msg, int addition_msg_size);
    }
}
