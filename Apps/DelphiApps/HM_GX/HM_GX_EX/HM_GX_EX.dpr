program HM_GX_EX;

uses
  Forms,
  VHMGXEX006S in 'VHMGXEX006S.pas' {Form1},
  VHMGXEX007S in 'VHMGXEX007S.pas' {Form28},
  VHMGXEX008S in 'VHMGXEX008S.pas' {Form29},
  VHMGXEX009S in 'VHMGXEX009S.pas' {Form30},
  VHMGXEX010S in 'VHMGXEX010S.pas' {Form31},
  VHMGXEX011S in 'VHMGXEX011S.pas' {Form32};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm28, Form28);
  Application.CreateForm(TForm29, Form29);
  Application.CreateForm(TForm30, Form30);
  Application.CreateForm(TForm31, Form31);
  Application.CreateForm(TForm32, Form32);
  Application.Run;
end.
