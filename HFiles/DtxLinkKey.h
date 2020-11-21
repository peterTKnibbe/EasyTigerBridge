enum EnumKeyCode
{
	KEY_SUCCESS = 0,
	KEY_ERROR = -1,
	KEY_BAD_PATID = -2
};

#define LASTNAMELEN 21
#define FIRSTNAMELEN 16
#define MILEN 2
#define TITLELEN 21
#define DATELEN 11
#define CHARTLEN 7
#define STREETLEN 31
#define CITYLEN 26
#define STATELEN 21
#define ZIPLEN 15
#define PHONELEN 17
#define EXTLEN 5
#define EMAIL_ADDRESS_LEN 60
#define GUID_LENGTH 36
#define PRACTITLELEN LASTNAMELEN + FIRSTNAMELEN + MILEN + TITLELEN

typedef struct {
	int		Size;
    long	PatId;
    char	LastName[LASTNAMELEN];
    char	FirstName[FIRSTNAMELEN];
    char	MI[MILEN];
    int		Gender;						// male=1, female=2 
    char	BirthDate[DATELEN];			//mm/dd/year
    char	LastVisitDate[DATELEN];
    char	ChartNum [CHARTLEN];
    char	Street[STREETLEN];
    char	Street2[STREETLEN];
    char	City[CITYLEN];
    char	State[STATELEN];
    char	Zip[ZIPLEN];
    char	HomePhone[PHONELEN];
    char	WorkPhone[PHONELEN];
    char	WorkExt[EXTLEN];
    char	OtherPhone[PHONELEN];
    char	Mobile[PHONELEN];
    char	Fax[PHONELEN];
    char	Email[EMAIL_ADDRESS_LEN];
    char	GuidID[GUID_LENGTH];
}PAT_INFO_STRUCT;

typedef struct {
	int		Size;
	char	PracticeName[PRACTITLELEN];
	char	Street[STREETLEN];
	char	Street2[STREETLEN];
	char	City[CITYLEN];
	char	State[STATELEN];
	char	Zip[ZIPLEN];
	char	Phone[PHONELEN];
}PRAC_INFO_STRUCT;

#define stateSize 20
typedef struct {
	int		size;
	int		patid;
	char	tooth1[stateSize];
	char	tooth2[stateSize];
	char	tooth3[stateSize];
	char	tooth4[stateSize];
	char	tooth5[stateSize];
	char	tooth6[stateSize];
	char	tooth7[stateSize];
	char	tooth8[stateSize];
	char	tooth9[stateSize];
	char	tooth10[stateSize];
	char	tooth11[stateSize];
	char	tooth12[stateSize];
	char	tooth13[stateSize];
	char	tooth14[stateSize];
	char	tooth15[stateSize];
	char	tooth16[stateSize];
	char	tooth17[stateSize];
	char	tooth18[stateSize];
	char	tooth19[stateSize];
	char	tooth20[stateSize];
	char	tooth21[stateSize];
	char	tooth22[stateSize];
	char	tooth23[stateSize];
	char	tooth24[stateSize];
	char	tooth25[stateSize];
	char	tooth26[stateSize];
	char	tooth27[stateSize];
	char	tooth28[stateSize];
	char	tooth29[stateSize];
	char	tooth30[stateSize];
	char	tooth31[stateSize];
	char	tooth32[stateSize];
}TOOTH_STATE_STRUCT;
