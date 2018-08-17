using UnityEngine;

namespace UniCraft.Interaction.Kit.Text
{
	public class InteractiveInformation : MonoBehaviour
	{
		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		[SerializeField] private string _sentence;

		///////////////////////////////
		////////// Attribute //////////
		///////////////////////////////

		public void DisplaySentence()
		{
			Debug.Log(_sentence);
		}
	}
}
