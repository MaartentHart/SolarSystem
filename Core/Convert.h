//Copyright (C) Maarten 't Hart 2019
#pragma once
#include <string>
#include <Windows.h>

std::wstring s2ws(const std::string& s);
std::string ws2s(const std::wstring& s);
double val(const std::wstring&that);
std::string str(double that);

