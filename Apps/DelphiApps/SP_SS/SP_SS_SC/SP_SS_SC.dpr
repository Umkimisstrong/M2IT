program SP_SS_SC;

uses
  Forms,
  VSPSSSC001S in 'VSPSSSC001S.pas' {Form86},
  VSPSSSC002S in 'VSPSSSC002S.pas' {Form87},
  VSPSSSC999S in '..\SP_SS_SP\VSPSSSC999S.pas' {Form203},
  VSPSSLR003S02 in '..\SP_SS_SP\VSPSSLR003S02.pas' {Form204};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm86, Form86);
  Application.CreateForm(TForm87, Form87);
  Application.CreateForm(TForm203, Form203);
  Application.CreateForm(TForm204, Form204);
  Application.Run;
end.
