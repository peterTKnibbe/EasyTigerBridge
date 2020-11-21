// DtxSampleLink.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "DtxLinkKey.h"

#pragma comment(linker, "/EXPORT:LaunchTool=_LaunchTool@12")

#include <stdio.h>
#include <stdlib.h>

typedef int (WINAPI* PAT_FUNC)(PAT_INFO_STRUCT *);
typedef int (WINAPI* PROC_FUNC)(PRAC_INFO_STRUCT *);
typedef int (WINAPI* TOOTHSTATE_FUNC)(TOOTH_STATE_STRUCT *);

extern "C" EnumKeyCode WINAPI LaunchTool(HWND hWndParent,LONG lPatientId,LPSTR szExeFile);

static const int B64Index[236] = { 0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,
0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0, 62, 63, 62, 62, 63, 52, 53, 54, 55,
56, 57, 58, 59, 60, 61,  0,  0,  0,  0,  0,  0,  0,  0,  1,  2,  3,  4,  5,  6,
7,  8,  9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25,  0,
0,  0,  0, 63,  0, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40,
41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51 };

EnumKeyCode WINAPI LaunchTool(HWND hWndParent,LONG lPatientId,LPSTR szExeFile)
{
	HINSTANCE hInst;
	EnumKeyCode eRCode;
	DWORD dwFlags=CREATE_NEW_PROCESS_GROUP;
	STARTUPINFOA oStartInfo={sizeof(STARTUPINFO),0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	PROCESS_INFORMATION oProcInfo;
	char* szCmdLine;
	char* szTemp;
	BOOL bStarted;

	szCmdLine = (char*) malloc(2048);
	memset(szCmdLine,0,sizeof(szCmdLine));
	szTemp = (char*) malloc(1024);
	memset(szTemp,0,sizeof(szTemp));

	//MessageBoxA(NULL, "Link", "0", MB_OK);
	if(lPatientId == 0)
		eRCode = KEY_BAD_PATID;
	else
	{
		hInst = LoadLibraryA("DtxLinkApi.dll");
		if(hInst != NULL)
		{
			///Use this section if patient information is desired
			PAT_FUNC patInfo;
			PAT_INFO_STRUCT patient;
			//patient = (PAT_INFO_STRUCT*) malloc(sizeof(PAT_INFO_STRUCT));
			patient.Size = sizeof(PAT_INFO_STRUCT);
			patient.PatId = lPatientId;
			patInfo = (PAT_FUNC) GetProcAddress(hInst, "GetPatientInfo");
			patInfo(&patient);


			//end practice information block

			/////Use this section if practice information is desired
			//PROC_FUNC pracInfo;
			//PRAC_INFO_STRUCT practice;
			////practice = (PRAC_INFO_STRUCT*) malloc(sizeof(PRAC_INFO_STRUCT));
			//practice.Size = sizeof(PRAC_INFO_STRUCT);
			//pracInfo = (PROC_FUNC) GetProcAddress(hInst, "GetPracticeInfo");
			//pracInfo(&practice);
			////end patient information block

			/////Use this section if Tooth State information is desired
			//TOOTH_STATE_STRUCT toothStates;
			//TOOTHSTATE_FUNC toothInfo;
			////toothStates = (TOOTH_STATE_STRUCT*) malloc(sizeof(TOOTH_STATE_STRUCT));
			//toothInfo = (TOOTHSTATE_FUNC)GetProcAddress(hInst, "GetToothStates");
			//toothStates.size = sizeof(TOOTH_STATE_STRUCT);
			//toothStates.patid = lPatientId;
			//toothInfo(&toothStates);
			////end tooth state information block

			///**TODO - Format the data you want to use and get it to your process***/
			//  The example here concatenates all of the values from the three data structures and sends them as
			//  a command line argument to the application.exe

			//guid string from the DB isn't zero terminated, so if using it in your application, you may need to to do something like this
			//char* sz_guidCopy = (char*) malloc(GUID_LENGTH + 1);
			//memcpy(sz_guidCopy, patient.GuidID, GUID_LENGTH);
			//sz_guidCopy[GUID_LENGTH] = 0;
			//end guid fix

			//...concatenate all the pieces into the complete command line...
			//wsprintfA has a max of 1024 chars so do in two steps if you need all data
			wsprintfA(szCmdLine, "Tiger1.exe Slave1 %i %s+%s", patient.PatId, patient.FirstName, patient.LastName);
			//Base64encode(szCmdLine, szTemp, strlen(szTemp));

			//Base64 encode the string



			//wsprintfA(szCmdLine, "\"&id%i\" \"&ln%s\" \"&fn%s\" \"&mi%s\" \"&gn%i\" \"&bd%s\" \"&lv%s\" \"&cn%s\" \"&s1%s\" \"&s2%s\" \"&ct%s\" \"&st%s\" \"&zp%s\" \"&hp%s\" \"&wp%s\" \"&we%s\" \"&op%s\" \"&mb%s\" \"&fx%s\" \"&em%s\" \"&gu%s\" \"&pn%s\" \"&p1%s\" \"&p2%s\" \"&pc%s\" \"&ps%s\" \"&pz%s\" \"&pp%s\" ", patient.PatId, patient.LastName, patient.FirstName, patient.MI, patient.Gender, patient.BirthDate, patient.LastVisitDate, patient.ChartNum, patient.Street, patient.Street2, patient.City, patient.State, patient.Zip, patient.HomePhone, patient.WorkPhone, patient.WorkExt, patient.OtherPhone, patient.Mobile, patient.Fax, patient.Email, sz_guidCopy, practice.PracticeName, practice.Street, practice.Street2, practice.City, practice.State, practice.Zip, practice.Phone);
			//wsprintfA(szTemp, "\"&01%s\" \"&02%s\" \"&03%s\" \"&04%s\" \"&05%s\" \"&06%s\" \"&07%s\" \"&08%s\" \"&09%s\" \"&10%s\" \"&11%s\" \"&12%s\" \"&13%s\" \"&14%s\" \"&15%s\" \"&16%s\" \"&17%s\" \"&18%s\" \"&19%s\" \"&20%s\" \"&21%s\" \"&22%s\" \"&23%s\" \"&24%s\" \"&25%s\" \"&26%s\" \"&27%s\" \"&28%s\" \"&29%s\" \"&30%s\" \"&31%s\" \"&32%s\"", toothStates.tooth1, toothStates.tooth2, toothStates.tooth3, toothStates.tooth4, toothStates.tooth5, toothStates.tooth6, toothStates.tooth7, toothStates.tooth8, toothStates.tooth9, toothStates.tooth10, toothStates.tooth11, toothStates.tooth12, toothStates.tooth13, toothStates.tooth14, toothStates.tooth15, toothStates.tooth16, toothStates.tooth17, toothStates.tooth18, toothStates.tooth19, toothStates.tooth20, toothStates.tooth21, toothStates.tooth22, toothStates.tooth23, toothStates.tooth24, toothStates.tooth25, toothStates.tooth26, toothStates.tooth27, toothStates.tooth28, toothStates.tooth29, toothStates.tooth30, toothStates.tooth31, toothStates.tooth32);
			//strcat(szCmdLine,szTemp);
			bStarted = CreateProcessA(szExeFile,(LPSTR)szCmdLine,0,0,FALSE,dwFlags,0,0,&oStartInfo,&oProcInfo);


			//********************************************************************************/

			//free ( szCmdLine );
			//free ( szTemp );
			//free ( sz_guidCopy );

			eRCode = KEY_SUCCESS;
		}
		else
			eRCode = KEY_ERROR;
	}
	return eRCode;
}


