using UnityEngine;

namespace UniCraft.Note
{
  [AddComponentMenu("UniCraft/Note")]
  public sealed class Note : MonoBehaviour
  {
    ///////////////////////////////
    ////////// Attribute //////////
    ///////////////////////////////
    
    public string             Author;
    [TextArea] public string  Content;
    public Color              Status;
    public string             Title;
  }
}
