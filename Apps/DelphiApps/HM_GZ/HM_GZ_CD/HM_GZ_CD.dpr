program HM_GZ_CD;

uses
  Forms,
  VHMGZCD001S in 'VHMGZCD001S.pas' {Form1},
  VHMGZCD001S01 in 'VHMGZCD001S01.pas' {Form2},
  VHMGZCD001S02 in 'VHMGZCD001S02.pas' {Form3},
  VHMGZCD017S in 'VHMGZCD017S.pas' {Form4};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm3, Form3);
  Application.CreateForm(TForm4, Form4);
  Application.Run;
end.
