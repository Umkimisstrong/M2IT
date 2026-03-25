program HM_GR_MJ;

uses
  Forms,
  VHMGRMJ001S in 'VHMGRMJ001S.pas' {Form1},
  VHMGRMJ002S in 'VHMGRMJ002S.pas' {Form2},
  VHMGRMJ003S in 'VHMGRMJ003S.pas' {Form3},
  VHMGRMJ004S in 'VHMGRMJ004S.pas' {Form4};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm3, Form3);
  Application.CreateForm(TForm4, Form4);
  Application.Run;
end.
