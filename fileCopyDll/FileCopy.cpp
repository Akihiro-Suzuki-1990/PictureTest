#include "stdafx.h"
#include "FileCopy.h"
#include <iostream>
#include <fstream>

// �t�@�C���̓ǂݍ���
char* FileToBytes(const char* pText, int* size)
{
	std::ifstream file;
	char* ret =NULL;

	try 
	{
		// open
		file.open(pText, std::ios::in | std::ios::binary);

		// seekToEnd
		file.seekg(0, std::ios::end);
		unsigned int eofPos = file.tellg();

		// seekToBegin
		file.seekg(0, std::ios::beg);
		unsigned int sofPos = file.tellg();

		// getFileSize
		*size = eofPos - sofPos;
		ret = new char[*size];

		// readAllBytes
		file.read(ret, *size);
	}
	catch (std::exception e)
	{
		free(ret);
		ret = NULL;
		*size = 0;
	}
	
	if (file.is_open() == true)
	{
		file.close();
	}
	return ret;
}

// �z��̃����[�X
void Release(char * values)
{
	free(values);
}
