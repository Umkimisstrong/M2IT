unit VHMGRRV047S;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, TFlatMemoUnit, TFlatRadioButtonUnit,
  TFlatCheckBoxUnit, TFlatGroupBoxUnit, TFlatSpinEditUnit, Grids, BaseGrid,
  AdvGrid, TFlatEditUnit, TFlatComboBoxUnit, TFlatButtonUnit,
  TFlatLabelUnit, ExtCtrls, TFlatPanelUnit;

type
  TForm9 = class(TForm)
    FlatPanel4: TFlatPanel;
    FlatPanel1: TFlatPanel;
    FlatLabel3: TFlatLabel;
    FlatLabel1: TFlatLabel;
    FlatLabel5: TFlatLabel;
    Label1: TLabel;
    FlatButton7: TFlatButton;
    FlatComboBox2: TFlatComboBox;
    FlatComboBox1: TFlatComboBox;
    FlatComboBox3: TFlatComboBox;
    FlatEdit1: TFlatEdit;
    FlatPanel5: TFlatPanel;
    FlatComboBox14: TFlatComboBox;
    FlatPanel2: TFlatPanel;
    FlatPanel21: TFlatPanel;
    FlatLabel16: TFlatLabel;
    FlatPanel22: TFlatPanel;
    AdvStringGrid3: TAdvStringGrid;
    FlatPanel6: TFlatPanel;
    FlatPanel9: TFlatPanel;
    FlatLabel6: TFlatLabel;
    FlatPanel3: TFlatPanel;
    FlatLabel9: TFlatLabel;
    FlatLabel10: TFlatLabel;
    Label6: TLabel;
    FlatLabel13: TFlatLabel;
    FlatLabel11: TFlatLabel;
    Label20: TLabel;
    Label55: TLabel;
    FlatLabel2: TFlatLabel;
    FlatEdit5: TFlatEdit;
    FlatEdit6: TFlatEdit;
    FlatEdit10: TFlatEdit;
    FlatEdit12: TFlatEdit;
    FlatEdit17: TFlatEdit;
    FlatSpinEditInteger3: TFlatSpinEditInteger;
    FlatComboBox11: TFlatComboBox;
    FlatEdit18: TFlatEdit;
    FlatGroupBox3: TFlatGroupBox;
    FlatCheckBox15: TFlatCheckBox;
    FlatCheckBox18: TFlatCheckBox;
    FlatGroupBox4: TFlatGroupBox;
    FlatCheckBox23: TFlatCheckBox;
    FlatCheckBox25: TFlatCheckBox;
    FlatCheckBox29: TFlatCheckBox;
    FlatCheckBox30: TFlatCheckBox;
    FlatEdit8: TFlatEdit;
    FlatLabel17: TFlatLabel;
    FlatComboBox5: TFlatComboBox;
    FlatComboBox7: TFlatComboBox;
    FlatComboBox21: TFlatComboBox;
    FlatSpinEditInteger5: TFlatSpinEditInteger;
    FlatComboBox20: TFlatComboBox;
    Label4: TLabel;
    Label5: TLabel;
    Label8: TLabel;
    FlatComboBox23: TFlatComboBox;
    FlatLabel4: TFlatLabel;
    FlatEdit2: TFlatEdit;
    Label2: TLabel;
    FlatComboBox4: TFlatComboBox;
    Label3: TLabel;
    FlatComboBox6: TFlatComboBox;
    Label7: TLabel;
    FlatComboBox8: TFlatComboBox;
    FlatComboBox9: TFlatComboBox;
    Label9: TLabel;
    Label10: TLabel;
    Label11: TLabel;
    FlatComboBox10: TFlatComboBox;
    FlatComboBox12: TFlatComboBox;
    Label12: TLabel;
    FlatComboBox15: TFlatComboBox;
    FlatEdit19: TFlatEdit;
    FlatEdit11: TFlatEdit;
    Label14: TLabel;
    FlatEdit15: TFlatEdit;
    Label15: TLabel;
    FlatEdit16: TFlatEdit;
    FlatComboBox16: TFlatComboBox;
    Label13: TLabel;
    FlatEdit9: TFlatEdit;
    FlatEdit3: TFlatEdit;
    Label18: TLabel;
    FlatComboBox17: TFlatComboBox;
    Label21: TLabel;
    FlatComboBox18: TFlatComboBox;
    Label22: TLabel;
    FlatComboBox19: TFlatComboBox;
    Label23: TLabel;
    FlatEdit4: TFlatEdit;
    Label24: TLabel;
    FlatEdit7: TFlatEdit;
    Label25: TLabel;
    FlatComboBox24: TFlatComboBox;
    Label26: TLabel;
    FlatComboBox25: TFlatComboBox;
    Label28: TLabel;
    FlatEdit13: TFlatEdit;
    Label29: TLabel;
    FlatEdit14: TFlatEdit;
    Label30: TLabel;
    FlatEdit21: TFlatEdit;
    Label31: TLabel;
    FlatEdit23: TFlatEdit;
    Label34: TLabel;
    FlatComboBox26: TFlatComboBox;
    Label35: TLabel;
    Label36: TLabel;
    FlatComboBox28: TFlatComboBox;
    Label37: TLabel;
    FlatEdit25: TFlatEdit;
    FlatRadioButton1: TFlatRadioButton;
    FlatRadioButton2: TFlatRadioButton;
    FlatRadioButton3: TFlatRadioButton;
    FlatRadioButton4: TFlatRadioButton;
    FlatRadioButton16: TFlatRadioButton;
    FlatRadioButton17: TFlatRadioButton;
    FlatRadioButton18: TFlatRadioButton;
    FlatRadioButton19: TFlatRadioButton;
    FlatRadioButton20: TFlatRadioButton;
    FlatRadioButton21: TFlatRadioButton;
    Label16: TLabel;
    FlatCheckBox1: TFlatCheckBox;
    FlatCheckBox2: TFlatCheckBox;
    FlatEdit20: TFlatEdit;
    FlatCheckBox3: TFlatCheckBox;
    FlatCheckBox4: TFlatCheckBox;
    FlatCheckBox5: TFlatCheckBox;
    FlatCheckBox6: TFlatCheckBox;
    FlatCheckBox7: TFlatCheckBox;
    FlatGroupBox2: TFlatGroupBox;
    FlatCheckBox8: TFlatCheckBox;
    FlatCheckBox9: TFlatCheckBox;
    Label17: TLabel;
    FlatCheckBox10: TFlatCheckBox;
    FlatPanel7: TFlatPanel;
    FlatLabel7: TFlatLabel;
    FlatPanel12: TFlatPanel;
    FlatPanel11: TFlatPanel;
    FlatPanel14: TFlatPanel;
    AdvStringGrid4: TAdvStringGrid;
    FlatPanel13: TFlatPanel;
    FlatLabel12: TFlatLabel;
    Label32: TLabel;
    FlatGroupBox1: TFlatGroupBox;
    Label33: TLabel;
    FlatMemo2: TFlatMemo;
    FlatMemo4: TFlatMemo;
    AdvStringGrid1: TAdvStringGrid;
    FlatPanel8: TFlatPanel;
    FlatLabel8: TFlatLabel;
    FlatPanel10: TFlatPanel;
    FlatLabel14: TFlatLabel;
    FlatPanel15: TFlatPanel;
    FlatPanel16: TFlatPanel;
    FlatLabel15: TFlatLabel;
    FlatPanel17: TFlatPanel;
    AdvStringGrid2: TAdvStringGrid;
    AdvStringGrid5: TAdvStringGrid;
    AdvStringGrid6: TAdvStringGrid;
    FlatPanel27: TFlatPanel;
    FlatButton3: TFlatButton;
    FlatButton4: TFlatButton;
    FlatButton8: TFlatButton;
    FlatButton2: TFlatButton;
    FlatButton10: TFlatButton;
    FlatButton11: TFlatButton;
    FlatButton1: TFlatButton;
    FlatButton6: TFlatButton;
    FlatButton15: TFlatButton;
    FlatButton14: TFlatButton;
    FlatButton16: TFlatButton;
    FlatButton17: TFlatButton;
    FlatButton19: TFlatButton;
    FlatButton5: TFlatButton;
    FlatButton9: TFlatButton;
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form9: TForm9;

implementation

{$R *.dfm}

end.
