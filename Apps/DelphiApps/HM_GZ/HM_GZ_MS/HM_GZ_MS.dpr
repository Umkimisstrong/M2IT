program HM_GZ_MS;

uses
  Forms,
  VHMGZMS999S in 'VHMGZMS999S.pas' {Form197},
  VHMGZMS998S in 'VHMGZMS998S.pas' {Form198},
  VHMGZMS997S in 'VHMGZMS997S.pas' {Form199},
  VHMGZMS001S01 in 'VHMGZMS001S01.pas' {Form200},
  VHMGZMS001S02 in 'VHMGZMS001S02.pas' {Form201};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm197, Form197);
  Application.CreateForm(TForm198, Form198);
  Application.CreateForm(TForm199, Form199);
  Application.CreateForm(TForm200, Form200);
  Application.CreateForm(TForm201, Form201);
  Application.Run;
end.
