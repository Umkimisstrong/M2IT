program HM_GX_RS;

uses
  Forms,
  VHMGXRS004S in 'VHMGXRS004S.pas' {Form1},
  VHMGXRS005S in 'VHMGXRS005S.pas' {Form33},
  VHMGXRS013S in 'VHMGXRS013S.pas' {Form34},
  VHMGXRS016S in 'VHMGXRS016S.pas' {Form35},
  VHMGXRS023S in 'VHMGXRS023S.pas' {Form36},
  VHMGXRS023S01 in 'VHMGXRS023S01.pas' {Form37},
  VHMGXRS023S02 in 'VHMGXRS023S02.pas' {Form38},
  VHMGXRS023S03 in 'VHMGXRS023S03.pas' {Form39},
  VHMGXRS023S04 in 'VHMGXRS023S04.pas' {Form40},
  VHMGXRS007S in 'VHMGXRS007S.pas' {Form173},
  VHMGXRS007S01 in 'VHMGXRS007S01.pas' {Form174},
  VHMGXRS006S in 'VHMGXRS006S.pas' {Form175},
  VHMGXRS006S_bas in 'VHMGXRS006S_bas.pas' {Form176},
  VHMGXRS006_blood in 'VHMGXRS006_blood.pas' {Form177},
  NEW_ALL_RSLT in 'NEW_ALL_RSLT.pas' {Form178},
  VHMGXRS999S in '..\..\SP_SS\SP_SS_ZZ\VHMGXRS999S.pas' {Form191},
  VHMGXRS998S in '..\..\SP_SS\SP_SS_ZZ\VHMGXRS998S.pas' {Form192},
  VHMGXRS007S03 in '..\..\SP_SS\SP_SS_ZZ\VHMGXRS007S03.pas' {Form193};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm33, Form33);
  Application.CreateForm(TForm34, Form34);
  Application.CreateForm(TForm35, Form35);
  Application.CreateForm(TForm36, Form36);
  Application.CreateForm(TForm37, Form37);
  Application.CreateForm(TForm38, Form38);
  Application.CreateForm(TForm39, Form39);
  Application.CreateForm(TForm40, Form40);
  Application.CreateForm(TForm173, Form173);
  Application.CreateForm(TForm174, Form174);
  Application.CreateForm(TForm175, Form175);
  Application.CreateForm(TForm176, Form176);
  Application.CreateForm(TForm177, Form177);
  Application.CreateForm(TForm178, Form178);
  Application.CreateForm(TForm191, Form191);
  Application.CreateForm(TForm192, Form192);
  Application.CreateForm(TForm193, Form193);
  Application.Run;
end.
