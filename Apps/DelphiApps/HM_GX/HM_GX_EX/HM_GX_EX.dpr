program HM_GX_EX;

uses
  Forms,
  VHMGXEX006S in 'VHMGXEX006S.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
