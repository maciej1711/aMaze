var target : GameObject;
var eventName1 : String;
var eventName2 : String;
var sound1 : AudioClip;
var doors : crys;

function OnTriggerEnter () {
target.SetActive(true);

{
if (doors.openDoors==true){
Debug.Log("Co jest");
iTweenEvent.GetEvent(target, eventName1).Play();
audio.clip = sound1;
audio.Play ();}}
}

function OnTriggerExit () {
if (doors.openDoors==true){
iTweenEvent.GetEvent(target, eventName2).Play();
audio.clip = sound1;
audio.Play ();
}}
function Start(){doors=this.GetComponent("crys");
Debug.Log(doors.openDoors+" czy drzwi są otwarte?");}





