program HM_GR_RV;

uses
  Forms,
  VHMGRRV016S in 'VHMGRRV016S.pas' {Form1},
  VHMGRRV018S in 'VHMGRRV018S.pas' {Form5},
  VHMGRRV020S in 'VHMGRRV020S.pas' {Form6},
  VHMGRRV034S in 'VHMGRRV034S.pas' {Form7},
  VHMGRRV037S in 'VHMGRRV037S.pas' {Form8},
  VHMGRRV047S in 'VHMGRRV047S.pas' {Form9},
  VHMGRRV048S in 'VHMGRRV048S.pas' {Form10};

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
  Application.Run;
end.
