program HM_GC_CM;

uses
  Forms,
  VHMGCCM001S in 'VHMGCCM001S.pas' {Form1},
  VHMGCCM002S in 'VHMGCCM002S.pas' {Form41},
  VHMGCCM003S in 'VHMGCCM003S.pas' {Form42},
  VHMGCCM004S in 'VHMGCCM004S.pas' {Form43},
  VHMGCCM005S in 'VHMGCCM005S.pas' {Form44},
  VHMGCCM006S in 'VHMGCCM006S.pas' {Form45},
  VHMGCCM007S in 'VHMGCCM007S.pas' {Form46},
  VHMGCCM002S02 in 'VHMGCCM002S02.pas' {Form205},
  VHMGCCM002S03 in 'VHMGCCM002S03.pas' {Form206};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm41, Form41);
  Application.CreateForm(TForm42, Form42);
  Application.CreateForm(TForm43, Form43);
  Application.CreateForm(TForm44, Form44);
  Application.CreateForm(TForm45, Form45);
  Application.CreateForm(TForm46, Form46);
  Application.CreateForm(TForm205, Form205);
  Application.CreateForm(TForm206, Form206);
  Application.Run;
end.
