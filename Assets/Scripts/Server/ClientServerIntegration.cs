using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace boc.Server {

	public class ClientServerIntegration : MonoBehaviour {

		public EventData EventData { get { return EventData.CreateFromJSON (eventData); } }

		private const string resetURLPrefix = "_reset";

		[SerializeField, Tooltip ("What is the host name for the server?")]
		private string hostURL;
		[SerializeField, Tooltip ("What is the event 1 url?")]
		private string event1URL = "event-1";
		[SerializeField, Tooltip ("What is the event 2 url?")]
		private string event2URL = "event-2";
		[SerializeField, Tooltip ("What is the event 3 url?")]
		private string event3URL = "event-3";
		[SerializeField, Tooltip ("What is the url for retrieving a JSON obj?")]
		private string retrieveDataURL = "get-data";

		private string eventData;

		private void Start () {
			Assert.IsFalse (string.IsNullOrEmpty (hostURL), "Server URL does not exist!");
			StartCoroutine (RetrieveEventData ());
		}

		private IEnumerator RetrieveEventData () {
			var dataURL = string.Format ("{0}/{1}", hostURL, retrieveDataURL);
			var www = new WWW (dataURL);
			yield return www;
			eventData = www.text;
			Debug.LogFormat ("Event 1: {0}, Event 2: {1}, Event 3: {2}", EventData.Event1, EventData.Event2, EventData.Event3);
		}

	}
}