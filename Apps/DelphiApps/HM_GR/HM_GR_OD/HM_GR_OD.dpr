program HM_GR_OD;

uses
  Forms,
  VHMGROD001S in 'VHMGROD001S.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
