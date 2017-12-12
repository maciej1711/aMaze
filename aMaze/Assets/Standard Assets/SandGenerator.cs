using UnityEngine;
using System.Collections;

public class SandGenerator : MonoBehaviour {

	public int FloorHeight=41;
	public int FloorWidth=41;
	public GameObject Floor;
	private int[,] floor;

	private int[,] GenerateFloor(int Height, int Width)
	{
				int[,] floor = new int[Height, Width];	
				// Inicjalizacja komorek do walli
				for (int i=0; i<Height; i++)
						for (int j=0; j<Width; j++)
								floor [i, j] = 1;

		return floor;

		}
	void Start () {
		floor = GenerateFloor (FloorHeight,FloorWidth);
		for (int i=0; i<FloorHeight; i++)
			for (int j=0; j<FloorWidth; j++) 
		{
			// Tworzymy cube jesli jest 1 w tablicy

			if(floor[i,j]==1)
			{
				// Pozycja dla bloku/sciany/cube
				Vector3 pozycja=new Vector3(i,(0),j);
				// Utworzenie bloku/sciany
				GameObject flor=Instantiate(Floor) as GameObject;
				// Przesuwamy sciane na odpowiednia pozycje
				if(flor!=null)
					flor.transform.position=pozycja;
				
			}
			
		}

	}

}
