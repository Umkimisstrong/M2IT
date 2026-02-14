program HM_GZ_IL;

uses
  Forms,
  VHMGZIL001S in 'VHMGZIL001S.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
