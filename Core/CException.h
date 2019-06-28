//Copyright (C) Maarten 't Hart 2019
#pragma once
#include <exception>
#include <string>

class CException : public std::exception
{
public:
	const char* what() const { return m_strMessage.c_str(); }

	CException(const std::string& strMessage = "") : m_strMessage(strMessage) { }
	virtual ~CException() { }

	std::string m_strMessage;
};