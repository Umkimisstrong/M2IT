program HM_GS_DL;

uses
  Forms,
  VHMGSDL001S in 'VHMGSDL001S.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
