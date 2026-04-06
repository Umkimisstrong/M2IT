program IM_EI_MA;

uses
  Forms,
  VIMEIMA003S in 'VIMEIMA003S.pas' {Form1},
  VIMEIMA002S in 'VIMEIMA002S.pas' {Form2};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.Run;
end.
