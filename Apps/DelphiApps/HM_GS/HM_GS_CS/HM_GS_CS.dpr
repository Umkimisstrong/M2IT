program HM_GS_CS;

uses
  Forms,
  VHMGSCS002S in 'VHMGSCS002S.pas' {Form1},
  VHMGSCS005S in 'VHMGSCS005S.pas' {Form2},
  VHMGSCS006S in 'VHMGSCS006S.pas' {Form3},
  VHMGSCS007S in 'VHMGSCS007S.pas' {Form148},
  VHMGSCS008S in 'VHMGSCS008S.pas' {Form149},
  VHMGSCS010S in 'VHMGSCS010S.pas' {Form150},
  VHMGSCS011S in 'VHMGSCS011S.pas' {Form151},
  VHMGSCS012S in 'VHMGSCS012S.pas' {Form152};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm3, Form3);
  Application.CreateForm(TForm148, Form148);
  Application.CreateForm(TForm149, Form149);
  Application.CreateForm(TForm150, Form150);
  Application.CreateForm(TForm151, Form151);
  Application.CreateForm(TForm152, Form152);
  Application.Run;
end.
