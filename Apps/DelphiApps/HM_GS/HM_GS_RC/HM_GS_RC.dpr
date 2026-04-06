program HM_GS_RC;

uses
  Forms,
  VHMGSRC015S in 'VHMGSRC015S.pas' {Form1},
  VHMGSRC016S in 'VHMGSRC016S.pas' {Form18},
  VHMGSRC047S in 'VHMGSRC047S.pas' {Form19},
  VHMGSRC048S in 'VHMGSRC048S.pas' {Form20},
  VHMGSRC001S in 'VHMGSRC001S.pas' {Form153},
  VHMGSRC002S in 'VHMGSRC002S.pas' {Form154},
  VHMGSRC003S in 'VHMGSRC003S.pas' {Form155},
  VHMGSRC004S in 'VHMGSRC004S.pas' {Form156},
  VHMGSRC009S in 'VHMGSRC009S.pas' {Form157},
  VHMGSRC010S in 'VHMGSRC010S.pas' {Form158},
  VHMGSRC011S in 'VHMGSRC011S.pas' {Form159},
  VHMGSRC012S in 'VHMGSRC012S.pas' {Form160},
  VHMGSRC013S in 'VHMGSRC013S.pas' {Form161},
  VHMGSRC014S in 'VHMGSRC014S.pas' {Form162},
  VHMGSRC017S in 'VHMGSRC017S.pas' {Form163},
  VHMGSRC018S in 'VHMGSRC018S.pas' {Form164},
  VHMGSRC019S in 'VHMGSRC019S.pas' {Form165},
  VHMGSRC020S in 'VHMGSRC020S.pas' {Form166},
  VHMGSRC021S in 'VHMGSRC021S.pas' {Form167},
  VHMGSRC022S in 'VHMGSRC022S.pas' {Form168},
  VHMGSRC023S in 'VHMGSRC023S.pas' {Form169},
  VHMGSRC024S in 'VHMGSRC024S.pas' {Form170},
  VHMGSRC025S in 'VHMGSRC025S.pas' {Form171},
  VHMGSRC026S in 'VHMGSRC026S.pas' {Form172};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TForm1, Form1);
  Application.CreateForm(TForm18, Form18);
  Application.CreateForm(TForm19, Form19);
  Application.CreateForm(TForm20, Form20);
  Application.CreateForm(TForm153, Form153);
  Application.CreateForm(TForm154, Form154);
  Application.CreateForm(TForm155, Form155);
  Application.CreateForm(TForm156, Form156);
  Application.CreateForm(TForm157, Form157);
  Application.CreateForm(TForm158, Form158);
  Application.CreateForm(TForm159, Form159);
  Application.CreateForm(TForm160, Form160);
  Application.CreateForm(TForm161, Form161);
  Application.CreateForm(TForm162, Form162);
  Application.CreateForm(TForm163, Form163);
  Application.CreateForm(TForm164, Form164);
  Application.CreateForm(TForm165, Form165);
  Application.CreateForm(TForm166, Form166);
  Application.CreateForm(TForm167, Form167);
  Application.CreateForm(TForm168, Form168);
  Application.CreateForm(TForm169, Form169);
  Application.CreateForm(TForm170, Form170);
  Application.CreateForm(TForm171, Form171);
  Application.CreateForm(TForm172, Form172);
  Application.Run;
end.
