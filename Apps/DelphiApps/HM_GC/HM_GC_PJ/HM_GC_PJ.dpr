program HM_GC_PJ;

uses
  Forms,
  VHMGCPJ082S in 'VHMGCPJ082S.pas' {Form1},
  VHMGCPJ079S in 'VHMGCPJ079S.pas' {Form21},
  VHMGCPJ078S in 'VHMGCPJ078S.pas' {Form22},
  VHMGCPJ077S in 'VHMGCPJ077S.pas' {Form23},
  VHMGCPJ072S in 'VHMGCPJ072S.pas' {Form24},
  VHMGCPJ065S in 'VHMGCPJ065S.pas' {Form25},
  VHMGCPJ063S in 'VHMGCPJ063S.pas' {Form26};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm21, Form21);
  Application.CreateForm(TForm22, Form22);
  Application.CreateForm(TForm23, Form23);
  Application.CreateForm(TForm24, Form24);
  Application.CreateForm(TForm25, Form25);
  Application.CreateForm(TForm26, Form26);
  Application.Run;
end.
