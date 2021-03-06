﻿using UnityEditor;
using UnityEngine;

namespace PW.Core
{
	[System.SerializableAttribute]
	public class PWNodeGraphOutput : PWNode {

		[SerializeField]
		public PWNodeGraphExternal	upperNode = null;

		//allow everything as output type
		[PWMultiple(1, typeof(object))]
		[PWInput]
		[PWOffset(0, 20)]
		public PWValues				inputValues = new PWValues();

		public override void OnNodeCreate()
		{

		}

		public override void OnNodeGUI()
		{
			var names = inputValues.GetNames< object >();
			var values = inputValues.GetValues< object >();

			EditorGUILayout.LabelField("names: [" + names.Count + "]");
			for (int i = 0; i < values.Count; i++)
			{
				if (i < names.Count && names[i] != null)
				{
					if (values[i] != null)
						EditorGUILayout.LabelField(names[i] + " <" + values[i].GetType() + ": " + values[i] + ">");
					else
						EditorGUILayout.LabelField(names[i]);
				}
				else
					EditorGUILayout.LabelField("null");
			}
		}

		public override void OnNodeProcess()
		{
			//if there is no upper graph, datas will be automatically pull-out
			if (upperNode != null)
			{
				while (upperNode.output.Count > inputValues.Count)
					upperNode.output.RemoveAt(0);
				for (int i = 0; i < inputValues.Count; i++)
					upperNode.output.AssignAt(i, inputValues.At(i), inputValues.NameAt(i), true);
			}
		}

		public void InitExternalNode(PWNode ex)
		{
			upperNode = ex as PWNodeGraphExternal;
		}
	}
}
