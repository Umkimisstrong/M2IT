program MC_OO_OC;

uses
  Forms,
  VMCOOOC002S in 'VMCOOOC002S.pas' {Form1},
  VMCOOOC001S in 'VMCOOOC001S.pas' {Form2},
  VMCOOOC999S in 'VMCOOOC999S.pas' {Form196};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm2, Form2);
  Application.CreateForm(TForm196, Form196);
  Application.Run;
end.
