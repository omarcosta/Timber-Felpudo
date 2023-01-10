using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Frost")]
public class FrostEffect : MonoBehaviour
{
    public float FrostAmount = 0f; //0-1 (0=minimum Frost, 1=maximum frost)
    public float EdgeSharpness = 1.4f; //>=1
    public float minFrost = 0f; //0-1
    public float maxFrost = 0f; //0-1
    public float seethroughness = 0f; //blends between 2 ways of applying the frost effect: 0=normal blend mode, 1="overlay" blend mode
    public float distortion = 0f; //how much the original image is distorted through the frost (value depends on normal map)
    public Texture2D Frost; //RGBA
    public Texture2D FrostNormals; //normalmap
    public Shader Shader; //ImageBlendEffect.shader

    private float i; // Init counter
	private Material material;
	
    // Custom value
    public float Limiti = 720f; // 60 = 60sec
    private float LimitFrostAmount = 0.57f;
    private float LimitMaxFrost = 0.8f; 
    private float LimitSeethroughness = 2f; 
    private float LimitDistortion = 0.5f;

	private void Awake()
	{
        material = new Material(Shader);
        material.SetTexture("_BlendTex", Frost);
        material.SetTexture("_BumpMap", FrostNormals);
	}
	
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (!Application.isPlaying)
        {
            material.SetTexture("_BlendTex", Frost);
            material.SetTexture("_BumpMap", FrostNormals);
            EdgeSharpness = Mathf.Max(1, EdgeSharpness);
        }
        material.SetFloat("_BlendAmount", Mathf.Clamp01(Mathf.Clamp01(FrostAmount) * (maxFrost - minFrost) + minFrost));
        material.SetFloat("_EdgeSharpness", EdgeSharpness);
        material.SetFloat("_SeeThroughness", seethroughness);
        material.SetFloat("_Distortion", distortion);
        // Debug.Log("_Distortion: "+ distortion);

		Graphics.Blit(source, destination, material);
	}

    void Update() {
        i += Time.deltaTime;
        if( i < Limiti){
            FrostAmount = LimitFrostAmount / Limiti * i;
            maxFrost = LimitMaxFrost / Limiti * i;
            seethroughness = LimitSeethroughness / Limiti * i;
            distortion = LimitDistortion / Limiti * i;

        }

    }
}