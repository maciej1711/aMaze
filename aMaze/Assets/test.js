var target : GameObject;
var eventName1 : String;
var eventName2 : String;
var sound1 : AudioClip;
var doors : crys;
var licznik=0;
function OnTriggerEnter () {
Debug.Log(doors.openDoors+" czy drzwi są otwarte?");
if (doors.openDoors==true){
iTweenEvent.GetEvent(target, eventName1).Play();
audio.clip = sound1;
audio.Play ();
}}


function OnTriggerStay(){
if (doors.openDoors==true){
licznik++;
if(licznik<1)
Precaution();
}
}

function OnTriggerExit () {
if (doors.openDoors==true){
iTweenEvent.GetEvent(target, eventName2).Play();
audio.clip = sound1;
audio.Play ();
}}

function Precaution(){

iTweenEvent.GetEvent(target, eventName1).Play();
audio.clip = sound1;
audio.Play ();

}


function Start(){doors=this.GetComponent("crys");}
//Debug.Log(doors.openDoors+" czy drzwi są otwarte?");}