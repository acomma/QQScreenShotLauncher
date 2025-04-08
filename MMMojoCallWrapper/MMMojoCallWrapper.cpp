#include "pch.h"
#include "MMMojoCallWrapper.h"
#include "qq_ipc.h"

#pragma comment(lib, "MMMojoCall.lib")

// QQIpcParentWrapper

MMMOJOCALLWRAPPER_API void* CreateQQIpcParentWrapper()
{
	return new qqimpl::qqipc::QQIpcParentWrapper();
}

MMMOJOCALLWRAPPER_API void DeleteQQIpcParentWrapper(void* instance)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	delete o;
}

MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_OnDefaultReceiveMsg(void* pArg, char* msg, int arg3, char* addition_msg, int addition_msg_size)
{
	return qqimpl::qqipc::QQIpcParentWrapper::OnDefaultReceiveMsg(pArg, msg, arg3, addition_msg, addition_msg_size);
}

MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_InitEnv(void* instance, const char* dll_path)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->InitEnv(dll_path);
}

MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_SetLogLevel(void* instance, int level)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->SetLogLevel(level);
}

MMMOJOCALLWRAPPER_API const char* QQIpcParentWrapper_GetLastErrStr(void* instance)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->GetLastErrStr();
}

MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_InitLog(void* instance, int level, void* callback)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->InitLog(level, callback);
}

MMMOJOCALLWRAPPER_API void QQIpcParentWrapper_InitParentIpc(void* instance)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->InitParentIpc();
}

MMMOJOCALLWRAPPER_API int QQIpcParentWrapper_LaunchChildProcess(void* instance, const char* file_path, CallbackIpc callback, void* cb_arg, char** cmdlines, int cmd_num)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->LaunchChildProcess(file_path, callback, cb_arg, cmdlines, cmd_num);
}

MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_ConnectedToChildProcess(void* instance, int pid)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->ConnectedToChildProcess(pid);
}

MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_SendIpcMessage(void* instance, int pid, const char* command, const char* addition_msg, int addition_msg_size)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->SendIpcMessage(pid, command, addition_msg, addition_msg_size);
}

MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_TerminateChildProcess(void* instance, int pid, int exit_code, bool wait_)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->TerminateChildProcess(pid, exit_code, wait_);
}

MMMOJOCALLWRAPPER_API bool QQIpcParentWrapper_ReLaunchChildProcess(void* instance, int pid)
{
	qqimpl::qqipc::QQIpcParentWrapper* o = static_cast<qqimpl::qqipc::QQIpcParentWrapper*>(instance);
	return o->ReLaunchChildProcess(pid);
}

// QQIpcChildWrapper

MMMOJOCALLWRAPPER_API void* CreateQQIpcChildWrapper()
{
	return new qqimpl::qqipc::QQIpcChildWrapper();
}

MMMOJOCALLWRAPPER_API void DeleteQQIpcChildWrapper(void* instance)
{
	qqimpl::qqipc::QQIpcChildWrapper* o = static_cast<qqimpl::qqipc::QQIpcChildWrapper*>(instance);
	delete o;
}

MMMOJOCALLWRAPPER_API const char* QQIpcChildWrapper_GetLastErrStr(void* instance)
{
	qqimpl::qqipc::QQIpcChildWrapper* o = static_cast<qqimpl::qqipc::QQIpcChildWrapper*>(instance);
	return o->GetLastErrStr();
}

MMMOJOCALLWRAPPER_API bool QQIpcChildWrapper_InitEnv(void* instance, const char* dll_path)
{
	qqimpl::qqipc::QQIpcChildWrapper* o = static_cast<qqimpl::qqipc::QQIpcChildWrapper*>(instance);
	return o->InitEnv(dll_path);
}

MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_InitChildIpc(void* instance)
{
	qqimpl::qqipc::QQIpcChildWrapper* o = static_cast<qqimpl::qqipc::QQIpcChildWrapper*>(instance);
	return o->InitChildIpc();
}

MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_InitLog(void* instance, int level, void* callback)
{
	qqimpl::qqipc::QQIpcChildWrapper* o = static_cast<qqimpl::qqipc::QQIpcChildWrapper*>(instance);
	return o->InitLog(level, callback);
}

MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_SetChildReceiveCallback(void* instance, CallbackIpc callback)
{
	qqimpl::qqipc::QQIpcChildWrapper* o = static_cast<qqimpl::qqipc::QQIpcChildWrapper*>(instance);
	return o->SetChildReceiveCallback(callback);
}

MMMOJOCALLWRAPPER_API void QQIpcChildWrapper_SendIpcMessage(void* instance, const char* command, const char* addition_msg, int addition_msg_size)
{
	qqimpl::qqipc::QQIpcChildWrapper* o = static_cast<qqimpl::qqipc::QQIpcChildWrapper*>(instance);
	return o->SendIpcMessage(command, addition_msg, addition_msg_size);
}
