program IM_EI_EM;

uses
  Forms,
  VIMEIEM001S in 'VIMEIEM001S.pas' {Form1};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.Run;
end.
