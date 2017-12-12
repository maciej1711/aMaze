using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour {
	public int MazeHeight=31;
	public int MazeWidth=31;
	private int[,] maze;
	public static float[] keys;
	private int r1, r2,first,second;
	private int[] wspolrzedne;
	private int ilosc_crystali = 0;
	public GameObject Wall,MoveDoorTrigger, TV;
	public GameObject Crystal,Door,Keyboard,StartingWall;
	static System.Random randomSpawn = new System.Random();
	static System.Random _random = new System.Random();
	// Inicjalizacja
	void Start () {
	// Uruchamianie generatora labiryntu
		maze = GenerateMaze (MazeHeight,MazeWidth);
		Randomize ();
		// Pokazywanie labiryntu - jego reprezentacji w unity
		startingWalling ();
		doorPosition ();
		instantiateDoor ();

		for (int i=0; i<MazeHeight; i++)
						for (int j=0; j<MazeWidth; j++) 
		{

			// Tworzymy cube jesli jest 1 w tablicy
			maze[wspolrzedne[0],wspolrzedne[1]]=2;
			maze[0,0]=0;maze[1,0]=0;maze[0,1]=0;
			maze[29,29]=0;
			if(TV!=null)
				TV.transform.position=new Vector3(29f,1,29.5f);
			if(maze[i,j]==1)
			{

				// Pozycja dla bloku/sciany/cube
				Vector3 pozycja=new Vector3(i,0,j);
				Vector3 pozycja1=new Vector3(i,1,j);
				// Utworzenie bloku/sciany
				GameObject wall=Instantiate(Wall) as GameObject;
				GameObject wall1=Instantiate(Wall) as GameObject;
				// Przesuwamy sciane na odpowiednia pozycje

				if(wall!=null)
					wall.transform.position=pozycja;
				
				wall1.transform.position=pozycja1;

			}
			else if(maze[i,j]==0&&ilosc_crystali<4)
			{

				Debug.Log("wspolrzedne:"+wspolrzedne[0]+" oraz "+wspolrzedne[1]);
				if(wspolrzedne[0]!=first&&wspolrzedne[1]!=second){
				Vector3 pozycja2 = new Vector3 (wspolrzedne[0], 1, wspolrzedne[1]);
				GameObject crystal = Instantiate (Crystal) as GameObject;
				if (crystal != null)
					crystal.transform.position = pozycja2;
				ilosc_crystali++;
				if (ilosc_crystali==4){
					Vector3 pozycja3 = new Vector3(1,1,1);
				GameObject crystal1 = Instantiate (Crystal) as GameObject;
				if (crystal1 != null)
					crystal1.transform.position = pozycja3;
				}
				}
				Randomize ();
				
			}

						}
	
	}

	
	public void instantiateDoor(){
		if (wspolrzedne [0] == 0) {
			maze [wspolrzedne [0]+1, wspolrzedne [1]] = 0;
			maze [wspolrzedne [0]+1, wspolrzedne [1]-1] = 0;
		}
		if(wspolrzedne[0]==MazeHeight-1)
		{
			maze [wspolrzedne [0]-1, wspolrzedne [1]] = 0;
			maze [wspolrzedne [0]-1, wspolrzedne [1]-1] = 0;
			
		}
		if (wspolrzedne [1] == 0) {
			maze [wspolrzedne [0], wspolrzedne [1]+1] = 0;
		}
		if (wspolrzedne [1] == MazeWidth - 1) {
			maze [wspolrzedne [0], wspolrzedne [1]-1] = 0;
		}
		Vector3 PositionOfTheDoor=new Vector3(0,1,0);
		if (wspolrzedne [1] == 0) {
			PositionOfTheDoor = new Vector3 (wspolrzedne [0] - 0.5f, 0.75f, wspolrzedne [1]);
		} else if (wspolrzedne [1] == MazeHeight-1) {
			PositionOfTheDoor = new Vector3 (wspolrzedne [0] + 0.5f, 0.75f, wspolrzedne [1]);
		} else if (wspolrzedne [0] == 0) {
			PositionOfTheDoor = new Vector3 (wspolrzedne [0], 0.75f, wspolrzedne [1] + 0.5f);
		} else if (wspolrzedne [0] == MazeWidth-1) {
			PositionOfTheDoor = new Vector3 (wspolrzedne [0], 0.75f, wspolrzedne [1] - 0.5f);
		} else {
			doorPosition();
			instantiateDoor();
		}
		Vector3 PositionOfThekay = new Vector3 (keys[0], 1, keys[1]);
		first = wspolrzedne [0];
		second=wspolrzedne[1];
		GameObject kayboard = Instantiate (Keyboard) as GameObject;
		if (Door != null)
			Debug.Log("position of the door"+ PositionOfTheDoor);
			Door.transform.position = PositionOfTheDoor;

		if (MoveDoorTrigger != null)
			
			MoveDoorTrigger.transform.position = PositionOfTheDoor;
		if(kayboard!=null)
			kayboard.transform.position = PositionOfThekay;
		if (wspolrzedne [0] == 0) {
			
			Door.transform.Rotate (0, 90, 0);
			kayboard.transform.Rotate (0, 90, 0);
		}
		if (wspolrzedne [0] == 30) 
		{
			Door.transform.Rotate (0, 270, 0);
			kayboard.transform.Rotate (0, 270, 0);
		}
		if (wspolrzedne [1] == 30) {
			Door.transform.Rotate (0, 180, 0);
			kayboard.transform.Rotate (0, 180, 0);
		}
	}
	private void startingWalling(){
		int z;
		int y = 0;
		for  (z=0; z<2; z++) {
						
						Vector3 position = new Vector3 (z, 1, y - 0.5f);
						GameObject stwall = Instantiate (StartingWall) as GameObject;
						if (stwall != null)
								stwall.transform.position = position;

						Vector3 position1 = new Vector3 (z, 0, y - 0.5f);
						GameObject stwall1 = Instantiate (StartingWall) as GameObject;
						if (stwall1 != null)
								stwall1.transform.position = position1;
				
				}
		 z = 0;
		for ( y=0; y<2; y++) {
			
			Vector3 position = new Vector3 (z- 0.5f, 1, y);
			GameObject stwall = Instantiate (StartingWall) as GameObject;
			if (stwall != null)
				stwall.transform.position = position;
			stwall.transform.Rotate (0, 90, 0);
			
			Vector3 position1 = new Vector3 (z- 0.5f, 0, y );
			GameObject stwall1 = Instantiate (StartingWall) as GameObject;
			if (stwall1 != null)
				stwall1.transform.position = position1;
			stwall1.transform.Rotate (0, 90, 0);
			
		}
	}
	
	private int[]doorPosition()
	{
		int coeficient1=2,coeficient2=2;
		float kay1=2, kay2=2;
		int rand=Random.Range (0, 3);
		switch (rand) {
		case 0:
			coeficient1=0;
			break;
		case 1:
			coeficient1=MazeHeight-1;
			break;
		case 2:coeficient2=0;
			break;
		case 3:coeficient2=MazeWidth-1;
			break;
		default:
			coeficient1=0;
			break;
		}
		if (coeficient1 == 0 || coeficient1 == MazeHeight - 1) {
						coeficient2 = Random.Range (4, MazeWidth - 2);
			if(coeficient1==0){
				kay1=coeficient1+0.5f;}
			if(coeficient1==MazeHeight-1){
				kay1=coeficient1-0.5f;}
			kay2=coeficient2-1;
								
		}
		if(coeficient2 == 0 || coeficient2 == MazeWidth - 1)
		{
			coeficient1=Random.Range(4,MazeHeight-2);
			if(coeficient2==0){
				kay2=coeficient2+0.5f;}
			if(coeficient2==MazeHeight-1){
				kay2=coeficient2-0.5f;}

			kay1=coeficient1-1;
		}	
		wspolrzedne = new int[]{coeficient1,coeficient2};
		keys = new float[]{kay1,kay2};
		Debug.Log("wspolrzedne drzwi: " + wspolrzedne[0]+" "+ wspolrzedne[1]);
		return wspolrzedne;

	}

	private int[]Randomize ()
	{

		r1 = Random.Range(2,MazeHeight);
		r2 = Random.Range(2,MazeWidth);

		if (maze [r1, r2] == 0) {
						wspolrzedne = new int[]{r1,r2};
						return wspolrzedne;
				}
		else 
			Randomize();
		return wspolrzedne;
	}

	private int[,] GenerateMaze(int Height, int Width)
	{
		// Tworzymy labirynt - tymczasowy

		int[,] maze = new int[Height, Width];

		// Inicjalizacja komorek do walli

		for (int i=0; i<Height; i++)
						for (int j=0; j<Width; j++)
								maze [i, j] = 1;

			// Generuje zmienna losowa
			System.Random rand = new System.Random();

			// Wyszukujemy losowy punkt poczatkowy

			int r = rand.Next (Height);
			while(r%2==0)
				r=rand.Next(Height);

			
			int c = rand.Next (Width);
			while(c%2==0)
				c=rand.Next(Width);

			// Komorka startowa
			maze[r,c]=0;

			// Tworzymy labirytn uzywajac algorytmu Depth-First Search

		MazeDigger (maze, r, c);
				// Zwracamy utworzony labirytn
				return maze;

		}


	private void MazeDigger(int [,]maze,int r, int c)
		{
		// Musimy wybrac sciezke w kierunku ktotrej bedize poruszal sie algorytm - sciezke "kopania"
		// 1 - polnoc | 2-poludnie | 3 - Wschod | 4 - Zachod
		int[]kierunki = new int[]{1,2,3,4};
		Shuffle(kierunki); //mieszamy kierunki - zeby labirytn byl jeszcze bardziej losowy
		// Sprawdzamy 2 bloki w przod cyz da rade sie przesunac

		for (int i =0; i<kierunki.Length; i++) 
		{
			switch(kierunki[i])
			{
			case 1: //polnoc/gora
				// Sprawdzamy czy 2 pola w gore sa zamalowane - wypelnione
				if(r-2<=0)
					continue;
						if(maze[r-2,c]!=0)
				{
					maze[r-2,c]=0;
					maze[r-1,c]=0;
					MazeDigger(maze,r-2,c);

				}
				break;
			case 2: //poludnie dol
				// Sprawdzamy czy 2 pola w gore sa zamalowane - wypelnione
				if(r+2>=MazeHeight-1)
					continue;
						if(maze[r+2,c]!=0)
				{
					maze[r+2,c]=0;
					maze[r+1,c]=0;
					MazeDigger(maze,r+2,c);
					
				}
				break;
			case 3: //wschod lewo
				// Sprawdzamy czy 2 pola w gore sa zamalowane - wypelnione
				if(c-2<=0)
					continue;
						if(maze[r,c-2]!=0)
				{
					maze[r,c-2]=0;
					maze[r,c-1]=0;
					MazeDigger(maze,r,c-2);
					
				}
				break;
			case 4: //zachod parwo
				// Sprawdzamy czy 2 pola w gore sa zamalowane - wypelnione
				if(c+2>=MazeWidth-1)
					continue;
				if(maze[r,c+2]!=0)
				{
					maze[r,c+2]=0;
					maze[r,c+1]=0;
					MazeDigger(maze,r,c+2);
					
				}
				break;
			}
		}

	}

		public static void Shuffle<T>(T[] array)
		{
			var random = _random;
			for (int i = array.Length; i > 1; i--)
			{
				// Wybieramy losowy element do zamiany.
				int j = random.Next(i); // 0 <= j <= i-1
				// Zamianas.
				T tmp = array[j];
				array[j] = array[i - 1];
				array[i - 1] = tmp;
			}
		}


}
