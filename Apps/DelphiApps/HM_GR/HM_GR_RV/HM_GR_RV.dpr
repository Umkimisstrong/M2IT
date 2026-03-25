program HM_GR_RV;

uses
  Forms,
  VHMGRRV016S in 'VHMGRRV016S.pas' {Form1},
  VHMGRRV018S in 'VHMGRRV018S.pas' {Form5},
  VHMGRRV020S in 'VHMGRRV020S.pas' {Form6},
  VHMGRRV034S in 'VHMGRRV034S.pas' {Form7},
  VHMGRRV037S in 'VHMGRRV037S.pas' {Form8},
  VHMGRRV047S in 'VHMGRRV047S.pas' {Form9},
  VHMGRRV048S in 'VHMGRRV048S.pas' {Form10},
  VHMGRRV016S01 in 'VHMGRRV016S01.pas' {Form11},
  VHMGRRV016S05 in 'VHMGRRV016S05.pas' {Form12},
  VHMGRRV016S07 in 'VHMGRRV016S07.pas' {Form13},
  VHMGRRV016S08 in 'VHMGRRV016S08.pas' {Form14},
  VHMGRRV016S09 in 'VHMGRRV016S09.pas' {Form15},
  VHMGRRV016S11 in 'VHMGRRV016S11.pas' {Form16},
  VHMGRRV016S13 in 'VHMGRRV016S13.pas' {Form17},
  VHMGRRV001S in 'VHMGRRV001S.pas' {Form113},
  VHMGRRV002S in 'VHMGRRV002S.pas' {Form114},
  VHMGRRV003S in 'VHMGRRV003S.pas' {Form115},
  VHMGRRV004S in 'VHMGRRV004S.pas' {Form116},
  VHMGRRV006S in 'VHMGRRV006S.pas' {Form117},
  VHMGRRV008S in 'VHMGRRV008S.pas' {Form118};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm5, Form5);
  Application.CreateForm(TForm6, Form6);
  Application.CreateForm(TForm7, Form7);
  Application.CreateForm(TForm8, Form8);
  Application.CreateForm(TForm9, Form9);
  Application.CreateForm(TForm10, Form10);
  Application.CreateForm(TForm11, Form11);
  Application.CreateForm(TForm12, Form12);
  Application.CreateForm(TForm13, Form13);
  Application.CreateForm(TForm14, Form14);
  Application.CreateForm(TForm15, Form15);
  Application.CreateForm(TForm16, Form16);
  Application.CreateForm(TForm17, Form17);
  Application.CreateForm(TForm113, Form113);
  Application.CreateForm(TForm114, Form114);
  Application.CreateForm(TForm115, Form115);
  Application.CreateForm(TForm116, Form116);
  Application.CreateForm(TForm117, Form117);
  Application.CreateForm(TForm118, Form118);
  Application.Run;
end.
