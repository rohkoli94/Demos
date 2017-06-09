#define UNICODE
#include <windows.h>
#pragma comment(lib, "gdi32")
#pragma comment(lib, "user32")

LRESULT CALLBACK MainWindowProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;

	switch(uMsg)
	{
	case WM_PAINT:
		BeginPaint(hWnd, &ps);
		TextOut(ps.hdc, 20, 20, L"Hello World!", 12);
		EndPaint(hWnd, &ps);		
		return 0;
	case WM_DESTROY:
		PostQuitMessage(0);
		return 0;
	}

	return DefWindowProc(hWnd, uMsg, wParam, lParam);
}

int WINAPI wWinMain(HINSTANCE hInstance, HINSTANCE hNotUsed, LPWSTR lpCmdLine, int nCmdShow)
{
	HWND hwndMain;
	MSG msg;

	WNDCLASSEX wcx = {sizeof(WNDCLASSEX)};
	wcx.lpszClassName = L"MainWindowClass";
	wcx.hInstance = hInstance;
	wcx.hIcon = LoadIcon(NULL, IDI_APPLICATION);
	wcx.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcx.hbrBackground = (HBRUSH)(COLOR_WINDOW+1);
	wcx.lpfnWndProc = MainWindowProc;
	RegisterClassEx(&wcx);

	hwndMain = CreateWindowEx(0, L"MainWindowClass", L"WinHello", WS_OVERLAPPEDWINDOW, 100, 100, 400, 400, NULL, NULL, hInstance, NULL);
	ShowWindow(hwndMain, nCmdShow);
	UpdateWindow(hwndMain);

	while(GetMessage(&msg, NULL, 0, 0) > 0)
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	return msg.wParam;
}
