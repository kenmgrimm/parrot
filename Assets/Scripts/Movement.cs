using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class Movement {
	public List<OpponentAction> Actions { get; set; }

	private static char[] FIELD_TERMINATORS = {':', ',', '|'};

  public Movement(string name) {
    StreamReader streamReader = new StreamReader(name + ".txt");
		Actions = new List<OpponentAction>();

		while(!streamReader.EndOfStream) {
			TransformOrientation head = ProcessLine(streamReader.ReadLine());
			TransformOrientation leftHand = ProcessLine(streamReader.ReadLine());
			TransformOrientation rightHand = ProcessLine(streamReader.ReadLine());

		 	Actions.Add(new OpponentAction(head, leftHand, rightHand));
		}
		
		streamReader.Close();
  }

	private TransformOrientation ProcessLine(string line) {
		string[] values = line.Split(FIELD_TERMINATORS);

		Vector3 position = new Vector3(float.Parse(values[1]), float.Parse(values[2]), float.Parse(values[3]));
		Quaternion rotation = new Quaternion(float.Parse(values[4]), float.Parse(values[5]), float.Parse(values[6]), float.Parse(values[7]));

		return new TransformOrientation(position, rotation);
	}
}


public class OpponentAction {
	public TransformOrientation head;
	public TransformOrientation leftHand;
	public TransformOrientation rightHand;

	public OpponentAction(TransformOrientation head, TransformOrientation leftHand, TransformOrientation rightHand) {
		this.head = head;
		this.leftHand = leftHand;
		this.rightHand = rightHand;
	}
}
