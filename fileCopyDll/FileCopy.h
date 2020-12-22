#pragma once
extern "C"
{
	__declspec(dllexport) char* FileToBytes(const char* pText, int* size);
	__declspec(dllexport) void Release(char* values);
}

