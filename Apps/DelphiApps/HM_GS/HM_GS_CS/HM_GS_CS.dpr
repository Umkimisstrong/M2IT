program HM_GS_CS;

uses
  Forms,
  VHMGSCS002S in 'VHMGSCS002S.pas' {Form1},
  VHMGSCS005S in 'VHMGSCS005S.pas' {Form2},
  VHMGSCS006S in 'VHMGSCS006S.pas' {Form3};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm3, Form3);
  Application.Run;
end.
