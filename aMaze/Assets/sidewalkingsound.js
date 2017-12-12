#pragma strict
var Audio1:AudioClip;

function Update () {

if((Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.D))){
audio.clip=Audio1;
audio.volume=(0.1f);
audio.pitch = Random.Range(0.8f, 1.5f);
audio.Play();


}

if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D)){

audio.clip=Audio1;
audio.Stop();
if(Input.GetKeyDown(KeyCode.W)){}


}
}