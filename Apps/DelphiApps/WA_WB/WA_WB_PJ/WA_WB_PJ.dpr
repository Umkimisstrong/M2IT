program WA_WB_PJ;

uses
  Forms,
  VWAWBPJ002S in 'VWAWBPJ002S.pas' {Form1},
  VWAWBPJ001S in 'VWAWBPJ001S.pas' {Form2};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.Run;
end.
