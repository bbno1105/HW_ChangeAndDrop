using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class StageSheetData
{
  [SerializeField]
  int id;
  public int ID { get {return id; } set { this.id = value;} }
  
  [SerializeField]
  int startballcount;
  public int Startballcount { get {return startballcount; } set { this.startballcount = value;} }
  
  [SerializeField]
  int[] maplist = new int[0];
  public int[] Maplist { get {return maplist; } set { this.maplist = value;} }
  
  [SerializeField]
  int clearcount;
  public int Clearcount { get {return clearcount; } set { this.clearcount = value;} }
  
}