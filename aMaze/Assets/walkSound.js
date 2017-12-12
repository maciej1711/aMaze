#pragma strict
var Audio : AudioClip;



function Update () {


if(Input.GetKeyDown(KeyCode.W)||Input.GetKeyDown(KeyCode.S)||(Input.GetKeyDown(KeyCode.W)&&Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.A)))
{

audio.clip=Audio;
audio.volume=(0.9f);
audio.pitch = Random.Range(0.8f, 1.5f);
audio.Play();

}


if(Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S)){

audio.clip=Audio;
audio.Stop();
}



}