using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class MapSheetData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  int type;
  public int Type { get {return type; } set { this.type = value;} }
  
  [SerializeField]
  int trapstartposition;
  public int Trapstartposition { get {return trapstartposition; } set { this.trapstartposition = value;} }
  
  [SerializeField]
  bool ismovetrap;
  public bool Ismovetrap { get {return ismovetrap; } set { this.ismovetrap = value;} }
  
  [SerializeField]
  bool moveright;
  public bool Moveright { get {return moveright; } set { this.moveright = value;} }
  
  [SerializeField]
  int movespeed;
  public int Movespeed { get {return movespeed; } set { this.movespeed = value;} }
  
  [SerializeField]
  int create;
  public int Create { get {return create; } set { this.create = value;} }
  
  [SerializeField]
  int obstacletype;
  public int Obstacletype { get {return obstacletype; } set { this.obstacletype = value;} }
  
  [SerializeField]
  int checkcount;
  public int Checkcount { get {return checkcount; } set { this.checkcount = value;} }
  
}