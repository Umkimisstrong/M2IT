unit VHMGCCM002S;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, TFlatTabControlUnit, StdCtrls, TFlatMemoUnit, TFlatCheckBoxUnit,
  TFlatRadioButtonUnit, Grids, BaseGrid, AdvGrid, TFlatEditUnit,
  TFlatComboBoxUnit, TFlatButtonUnit, TFlatLabelUnit, ExtCtrls,
  TFlatPanelUnit;

type
  TForm41 = class(TForm)
    FlatPanel1: TFlatPanel;
    FlatPanel2: TFlatPanel;
    FlatLabel5: TFlatLabel;
    FlatLabel2: TFlatLabel;
    Label2: TLabel;
    Label1: TLabel;
    FlatButton7: TFlatButton;
    FlatComboBox3: TFlatComboBox;
    FlatEdit1: TFlatEdit;
    FlatComboBox2: TFlatComboBox;
    FlatEdit3: TFlatEdit;
    FlatPanel20: TFlatPanel;
    AdvStringGrid2: TAdvStringGrid;
    FlatPanel5: TFlatPanel;
    FlatComboBox14: TFlatComboBox;
    FlatPanel7: TFlatPanel;
    FlatLabel7: TFlatLabel;
    FlatPanel9: TFlatPanel;
    FlatLabel4: TFlatLabel;
    FlatPanel11: TFlatPanel;
    Label3: TLabel;
    Label6: TLabel;
    Label7: TLabel;
    Label8: TLabel;
    Label9: TLabel;
    Label10: TLabel;
    Label12: TLabel;
    FlatEdit2: TFlatEdit;
    FlatEdit4: TFlatEdit;
    FlatEdit5: TFlatEdit;
    FlatEdit6: TFlatEdit;
    FlatEdit9: TFlatEdit;
    FlatPanel16: TFlatPanel;
    FlatCheckBox1: TFlatCheckBox;
    FlatCheckBox2: TFlatCheckBox;
    FlatCheckBox3: TFlatCheckBox;
    FlatPanel12: TFlatPanel;
    FlatLabel8: TFlatLabel;
    FlatPanel19: TFlatPanel;
    FlatTabControl2: TFlatTabControl;
    Label26: TLabel;
    FlatEdit17: TFlatEdit;
    FlatLabel6: TFlatLabel;
    FlatComboBox1: TFlatComboBox;
    Label27: TLabel;
    FlatEdit18: TFlatEdit;
    FlatPanel3: TFlatPanel;
    AdvStringGrid1: TAdvStringGrid;
    pn_Panel004: TFlatPanel;
    FlaTFlatPanel83: TLabel;
    FlaTFlatPanel84: TLabel;
    FlaTFlatPanel85: TLabel;
    FlaTFlatPanel86: TLabel;
    FlaTFlatPanel87: TLabel;
    FlaTFlatPanel88: TLabel;
    FlaTFlatPanel89: TLabel;
    FlaTFlatPanel90: TLabel;
    FlaTFlatPanel91: TLabel;
    FlaTFlatPanel92: TLabel;
    FlaTFlatPanel93: TLabel;
    FlaTFlatPanel94: TLabel;
    FlaTFlatPanel95: TLabel;
    FlaTFlatPanel96: TLabel;
    FlatEdit33: TFlatEdit;
    FlatEdit34: TFlatEdit;
    FlatEdit35: TFlatEdit;
    FlatEdit36: TFlatEdit;
    FlatEdit37: TFlatEdit;
    FlatEdit38: TFlatEdit;
    FlatEdit39: TFlatEdit;
    FlatEdit40: TFlatEdit;
    FlatEdit41: TFlatEdit;
    FlatEdit42: TFlatEdit;
    FlatEdit43: TFlatEdit;
    FlatEdit44: TFlatEdit;
    FlatEdit45: TFlatEdit;
    FlatEdit46: TFlatEdit;
    FlatPanel4: TFlatPanel;
    AdvStringGrid3: TAdvStringGrid;
    FlatPanel6: TFlatPanel;
    FlatLabel1: TFlatLabel;
    FlatPanel8: TFlatPanel;
    Label28: TLabel;
    FlatMemo5: TFlatMemo;
    Label29: TLabel;
    FlatMemo6: TFlatMemo;
    Label30: TLabel;
    FlatMemo7: TFlatMemo;
    Label31: TLabel;
    FlatMemo8: TFlatMemo;
    Label32: TLabel;
    FlatMemo9: TFlatMemo;
    Label33: TLabel;
    Label22: TLabel;
    FlatEdit19: TFlatEdit;
    Label23: TLabel;
    FlatEdit20: TFlatEdit;
    FlatEdit21: TFlatEdit;
    Label11: TLabel;
    FlatEdit10: TFlatEdit;
    Label15: TLabel;
    FlatEdit11: TFlatEdit;
    Label13: TLabel;
    FlatEdit12: TFlatEdit;
    Label14: TLabel;
    FlatEdit13: TFlatEdit;
    Label16: TLabel;
    FlatEdit14: TFlatEdit;
    Label17: TLabel;
    FlatEdit15: TFlatEdit;
    Label18: TLabel;
    FlatEdit16: TFlatEdit;
    Label19: TLabel;
    Label21: TLabel;
    FlatEdit24: TFlatEdit;
    Label24: TLabel;
    FlatEdit25: TFlatEdit;
    Label25: TLabel;
    FlatEdit26: TFlatEdit;
    Label34: TLabel;
    FlatEdit27: TFlatEdit;
    Label35: TLabel;
    FlatEdit28: TFlatEdit;
    FlatEdit29: TFlatEdit;
    FlatEdit30: TFlatEdit;
    FlatEdit31: TFlatEdit;
    Label36: TLabel;
    Label37: TLabel;
    Label38: TLabel;
    FlatCheckBox5: TFlatCheckBox;
    FlatCheckBox6: TFlatCheckBox;
    FlatCheckBox4: TFlatCheckBox;
    FlatEdit32: TFlatEdit;
    FlatEdit47: TFlatEdit;
    Label45: TLabel;
    FlatPanel13: TFlatPanel;
    FlatCheckBox7: TFlatCheckBox;
    FlatComboBox35: TFlatComboBox;
    Label41: TLabel;
    Label20: TLabel;
    Label42: TLabel;
    Label43: TLabel;
    FlatPanel10: TFlatPanel;
    FlatCheckBox8: TFlatCheckBox;
    FlatComboBox4: TFlatComboBox;
    FlatPanel14: TFlatPanel;
    FlatCheckBox9: TFlatCheckBox;
    FlatComboBox5: TFlatComboBox;
    FlatPanel15: TFlatPanel;
    FlatCheckBox10: TFlatCheckBox;
    FlatComboBox6: TFlatComboBox;
    FlatPanel17: TFlatPanel;
    FlatCheckBox11: TFlatCheckBox;
    FlatComboBox7: TFlatComboBox;
    FlatPanel18: TFlatPanel;
    FlatCheckBox12: TFlatCheckBox;
    FlatComboBox8: TFlatComboBox;
    Label44: TLabel;
    FlatEdit7: TFlatEdit;
    Label4: TLabel;
    FlatEdit8: TFlatEdit;
    Label5: TLabel;
    FlatEdit22: TFlatEdit;
    Label46: TLabel;
    FlatEdit23: TFlatEdit;
    Label47: TLabel;
    FlatEdit50: TFlatEdit;
    Label48: TLabel;
    FlatEdit51: TFlatEdit;
    Label39: TLabel;
    FlatPanel21: TFlatPanel;
    FlatCheckBox13: TFlatCheckBox;
    FlatComboBox9: TFlatComboBox;
    FlatPanel27: TFlatPanel;
    FlatButton3: TFlatButton;
    FlatButton4: TFlatButton;
    FlatButton5: TFlatButton;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form41: TForm41;

implementation

{$R *.dfm}

end.
