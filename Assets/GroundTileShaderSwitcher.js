#pragma strict

function Awake() {
	Debug.Log("I am awake!");
	Debug.Log(renderer.material.shader);
	//renderer.material.shader = Shader.Find ("ShroomyTreeGroundShader_5");
	//AssetDatabase.LoadAssetAtPath("Assets/ShroomyTree/Resources/ShroomyTreeGroundShader_5") as Material;
      
      var groundMaterials = [
        'ShroomyTreeGroundShader_1',
        'ShroomyTreeGroundShader_2',
        'ShroomyTreeGroundShader_3',
        'ShroomyTreeGroundShader_4',
        'ShroomyTreeGroundShader_5'
      ];
      var groundMaterial:Material;
      var r = Random.Range(0,groundMaterials.length);
      var rMaterial =  groundMaterials[r];
      Debug.Log("and now is rMaterial: "+ rMaterial);

      groundMaterial = Resources.Load(rMaterial);
      renderer.material = groundMaterial;
}

function Start () {
	
}

function Update () {

}