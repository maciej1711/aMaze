using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System;

using System.IO;

public class crys : MonoBehaviour {
	//  128bit(16byte)IV and Key
	//	private const string AesIV = @"1234";
	//	private const string AesKey = @"5DRW";
	public GUISkin customSkin;
	public GameObject Trigg;
	public static bool openDoors=false;
	string ResultText="";
	int helper=0;
	int k;
	string[] napisy=new string[]{"I","am","the","best","I","want","to","quit","Coffee","or","tea","?","Destroy","this","maze","please",};

	bool showMessage=false, EonKeyboard=false;
	private const string AesIV = @"!QAZ2WSX#EDC4RFV";
	private const string AesKey = @"5TGB&YHN7UJM(IK<";
	string[] zaszyfrowane=new string[5];
	public GameObject Crys;
	bool boolo,message=true,sentenceLabel=true;
	int j=0;

	float timeofMessage=5;
	public Texture btnTexture;
	bool ePressed = false;
	// Use this for initialization
	static int iteration=0;

		void OnTriggerEnter(Collider Crystal) 
	{

		if (Crystal.name == "Trigg(Clone)") {
						ePressed = true;
						if (Input.GetKeyDown (KeyCode.E)) {
								EonKeyboard = true;
						}
				}
				if (Crystal.name == "crystal(Clone)") {
						if (boolo == false) {
								timeofMessage = 5;
								message = true;

						}
						if (j == 0) {
								j++;
								boolo = true;
						}
		
						Debug.Log ("Congratulations - You Collected " + iteration + " of 4 Artefacts!");

						iteration++;
						Destroy (Crystal.gameObject);
				}
		}








	void Start(){

		losowanko ();
	}
	void Update(){


		if (boolo==true||(boolo==false&&iteration>1)) 
		{

			timeofMessage-=Time.deltaTime;		
		if(timeofMessage<0.0f)
			{
				if(boolo==true)
				boolo=false;
				else{
					message=false;
				}


			}
		}
		if(helper<1){
		GameObject Tr = Instantiate (Trigg) as GameObject;	
		helper++;
		if(Tr!=null){

			Tr.transform.position = new Vector3 (MazeGenerator.keys[0], 1, MazeGenerator.keys[1]);

		//instantiateTriggerKay (MazeGenerator.keys [0], MazeGenerator.keys [1]);
			}
		}
	
	}



	void OnTriggerExit(Collider Tr){

		if (Tr.name == "Trigg(Clone)") 
		ePressed = false;
			EonKeyboard = false;
	}


	void OnTriggerStay(Collider Tr) {
		if (Tr.name == "Trigg(Clone)") 
		ePressed = true;
			EonKeyboard = true;
		//Debug.Log ("ePressed");	
	
		
	}
	
	/*	void OnGUI(){
		if(ePressed==true)
		if(Input.GetKeyDown(KeyCode.E)){
			GUI.Button (new Rect (Screen.width / 3, Screen.height / 2, 400, 80), "You should find more crystals");
			ePressed=false;
			
		}
		//	if(boolo)
		//	GUI.Button (new Rect (Screen.width / 3, Screen.height / 2, 400, 80), "You should find more crystals");
	}*/

	void OnGUI(){
		GUI.skin = customSkin;
	//	guiText.fontSize = 16;

	
						if (ePressed == true) {
		
			if (EonKeyboard==true) {

								if (iteration < 4) {

										GUI.Label (new Rect (Screen.width / 3, Screen.height / 2, 400, 80), "You need to find more crystals");
								}
								if (iteration >= 4) {
					Debug.Log(k);
					if(sentenceLabel==true){
										GUI.Label (new Rect (Screen.width / 3, Screen.height / 2 - 100, 400, 80), "Enter decrypted sentence");
					}
										ResultText = GUI.TextField (new Rect (Screen.width / 3, Screen.height / 2, 400, 80), ResultText, 25);
										//	if (GUI.Button(new Rect(10, 10, 50, 50),"Decypt message"));{
										//              EditableString= Decrypt (EditableString);
										//		GUI.Label (new Rect (Screen.width / 3, Screen.height / 2, 600, 80), EditableString);
					//	}
					sentenceLabel=true;
										if (ResultText == napisy [k] + " " + napisy [k + 1] + " " + napisy [k + 2] + " " + napisy [k + 3]) {
						sentenceLabel=false;	

												openDoors = true;
												GUI.Label (new Rect (Screen.width / 3, Screen.height / 3 -100, 400, 40), "Doors are open. You're good to go...");


										}
										//Debug.Log("jokko "+EditableString);
								}
						}
				}


		if (boolo==true) {

			GUI.Button (new Rect (Screen.width / 3, Screen.height / 2, 400, 80), "You need to find four crystals\nThey store the key to your freedom\n");
				}

				if (boolo == false && iteration > 1&&message==true) {	
			Debug.Log ("zaszyfrowany tekst "+zaszyfrowane[iteration-1]);

						GUI.Button (new Rect (Screen.width / 3, Screen.height / 2, 400, 80), ""+(iteration-1)+" keycode ="+zaszyfrowane[iteration-1]+"\n");

				
				}



	}
	void losowanko(){
		int random = UnityEngine.Random.Range(0,3);
		

			k=random*4;
		//	Debug.Log("Wylosowana wartosc w tabeli "+k);
			for(int j=1;j<=4;j++){
		//	Debug.Log("napis w tabelce "+napisy[k]);
			zaszyfrowane[j]=Encrypt(napisy[k]);
			Debug.Log("zaszyfrowany tekst to: "+zaszyfrowane[j]);

			k++;
			}



	}



	
	/// <summary>
	/// AES Encryption
	/// </summary>
	private string Encrypt(string text)
	{
		// AesCryptoServiceProvider
		AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
		aes.BlockSize = 128;
		aes.KeySize = 128;

		aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
		aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);

		aes.Mode = CipherMode.CBC;
		aes.Padding = PaddingMode.PKCS7;
		
		// Convert string to byte array
		byte[] src = System.Text.Encoding.UTF8.GetBytes(text);
		
		// encryption
		using (ICryptoTransform encrypt = aes.CreateEncryptor())
		{
			byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
			for(int i=0;i<dest.Length;i++){
			//	Debug.Log(dest[i]);
			}
			// Convert byte array to Base64 strings
			//return System.Text.Encoding.UTF8.GetString(dest);

			return Convert.ToBase64String(dest);// poprzednia werja z neta
		}
	}
	
	/// <summary>
	/// AES decryption
	/// </summary>
	public static string Decrypt(string text)
	{
		// AesCryptoServiceProvider
		AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
		aes.BlockSize = 128;
		aes.KeySize = 128;
		aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
		aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
		aes.Mode = CipherMode.CBC;
		aes.Padding = PaddingMode.PKCS7;
		
		// Convert Base64 strings to byte array
		byte[] src = System.Convert.FromBase64String(text);

		// decryption
		using (ICryptoTransform decrypt = aes.CreateDecryptor())
		{
			byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
			Debug.Log(System.Text.Encoding.UTF8.GetString(dest));
			return System.Text.Encoding.UTF8.GetString(dest);
		}
	}
}



