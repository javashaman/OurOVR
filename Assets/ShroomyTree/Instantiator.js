#pragma strict

var prefab : GameObject;
var gridX = 5;
var gridY = 5;
var spacing = 20.0;

function Start () {

    for (var y = 0; y < gridY; y++) {
        for (var x=0;x<gridX;x++) {
            var pos = Vector3 (x, 0, y) * spacing;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}


function Update () {

}