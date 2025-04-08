#pragma once

#ifdef MMMOJOCALLWRAPPER_EXPORTS
#define MMMOJOCALLWRAPPER_API __declspec(dllexport)
#else
#define MMMOJOCALLWRAPPER_API __declspec(dllimport)
#endif

extern "C"  MMMOJOCALLWRAPPER_API typedef void (*CallbackIpc)(void*, char*, int, char*, int);

// QQIpcParentWrapper

extern "C" MMMOJOCALLWRAPPER_API void* CreateQQIpcParentWrapper();

extern "C" MMMOJOCALLWRAPPER_API void DeleteQQIpcParentWrapper(void* instance);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_OnDefaultReceiveMsg(void* pArg, char* msg, int arg3, char* addition_msg, int addition_msg_size);

extern "C" MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_InitEnv(void* instance, const char* dll_path);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_SetLogLevel(void* instance, int level);

extern "C" MMMOJOCALLWRAPPER_API const char* QQIpcParentWrapper_GetLastErrStr(void* instance);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_InitLog(void* instance, int level, void* callback);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_InitParentIpc(void* instance);

extern "C" MMMOJOCALLWRAPPER_API int QQIpcParentWrapper_LaunchChildProcess(void* instance, const char* file_path, CallbackIpc callback, void* cb_arg, char** cmdlines, int cmd_num);

extern "C" MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_ConnectedToChildProcess(void* instance, int pid);

extern "C" MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_SendIpcMessage(void* instance, int pid, const char* command, const char* addition_msg, int addition_msg_size);

extern "C" MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_TerminateChildProcess(void* instance, int pid, int exit_code, bool wait_);

extern "C" MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_ReLaunchChildProcess(void* instance, int pid);

// QQIpcChildWrapper

extern "C" MMMOJOCALLWRAPPER_API void* CreateQQIpcChildWrapper();

extern "C" MMMOJOCALLWRAPPER_API void DeleteQQIpcChildWrapper(void* instance);

extern "C" MMMOJOCALLWRAPPER_API const char* QQIpcChildWrapper_GetLastErrStr(void* instance);

extern "C" MMMOJOCALLWRAPPER_API bool QQIpcChildWrapper_InitEnv(void* instance, const char* dll_path);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_InitChildIpc(void* instance);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_InitLog(void* instance, int level, void* callback);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_SetChildReceiveCallback(void* instance, CallbackIpc callback);

extern "C" MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_SendIpcMessage(void* instance, const char* command, const char* addition_msg, int addition_msg_size);
