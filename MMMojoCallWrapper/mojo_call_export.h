#pragma once

#ifdef MMMojoCall_EXPORTS
#define MMMOJOCALL_API __declspec(dllexport)
#else
#define MMMOJOCALL_API __declspec(dllimport)
#endif

enum MGRTYPE
{
	XPluginManager = 0,
	OCRManager,
	UtilityManager,
	PlayerManager
};

/**
 * @brief �Դ�C�ķ�ʽ����XPluginMgr�� �����������Ե���
 * @param mgr_type 0ΪXPluginManager 1ΪOCRManager 2ΪUtilityManager
 * @return ��ָ�� ʧ�ܷ���NULL
 */
extern "C" MMMOJOCALL_API const void* GetInstanceXPluginMgr(int mgr_type);

/**
 * @brief �����ַ���������Ӧ�ĺ���
 * @param class_ptr ��ָ��
 * @param mgr_type �������
 * @param func_name ������
 * @param ret_ptr	�洢����ֵ��ָ�� �����ʹ�÷���ֵ����NULL
 * @param ... ���� һ��Ҫ��Ӧ��������ȷ���� �ڲ��������
 * @return ִ��״̬ 0ʧ�� 1�ɹ� 2δ֪����
 */
extern "C" MMMOJOCALL_API int CallFuncXPluginMgr(const void* class_ptr, int mgr_type, const char* func_name, void* ret_ptr, ...);

/**
 * @brief ����XPluginMgr��ָ��
 * @param ��ָ��
 */
extern "C" MMMOJOCALL_API void ReleaseInstanceXPluginMgr(const void* mgr_ptr);
