using UnityEngine;
using System.Collections;

/// MouseLook rotates the transform based on the mouse delta.
/// Minimum and Maximum values can be used to constrain the possible rotation

/// To make an FPS style character:
/// - Create a capsule.
/// - Add the MouseLook script to the capsule.
///   -> Set the mouse look to use LookX. (You want to only turn character but not tilt it)
/// - Add FPSInputController script to the capsule
///   -> A CharacterMotor and a CharacterController component will be automatically added.

/// - Create a camera. Make the camera a child of the capsule. Reset it's transform.
/// - Add a MouseLook script to the camera.
///   -> Set the mouse look to use LookY. (You want the camera to tilt up and down like a head. The character already turns.)
[AddComponentMenu("Camera-Control/Mouse Look")]
public class MouseLookJoy : MonoBehaviour {

	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float sensitivityXJoy = 15F;
	public float sensitivityYJoy = 15F;

	public float minimumX = -360F;
	public float maximumX = 360F;

	public float minimumY = -60F;
	public float maximumY = 60F;

	protected float mouseRot = 0.0f;

	protected CharacterController Controller = null;
	protected OVRCameraRig CameraController = null;
	protected Transform DirXform = null;

	private float SimulationRate = 60.0f;
	public float RotationAmount = 1.5f;

	float rotationY = 0F;

	void Awake()
	{
		Controller = gameObject.GetComponent<CharacterController>();
		
		if(Controller == null)
			Debug.LogWarning("OVRPlayerController: No CharacterController attached.");
		
		// We use OVRCameraRig to set rotations to cameras,
		// and to be influenced by rotation
		OVRCameraRig[] CameraControllers;
		CameraControllers = gameObject.GetComponentsInChildren<OVRCameraRig>();
		
		if(CameraControllers.Length == 0)
			Debug.LogWarning("OVRPlayerController: No OVRCameraRig attached.");
		else if (CameraControllers.Length > 1)
			Debug.LogWarning("OVRPlayerController: More then 1 OVRCameraRig attached.");
		else
			CameraController = CameraControllers[0];
		
		DirXform = transform.Find("ForwardDirection");
		
		if(DirXform == null)
			Debug.LogWarning("OVRPlayerController: ForwardDirection game object not found. Do not use.");
		
		#if UNITY_ANDROID && !UNITY_EDITOR
		OVRManager.display.RecenteredPose += ResetOrientation;
		#endif
	}

	void Update ()
	{

		float rotateInfluence = SimulationRate * Time.deltaTime * RotationAmount;



		if (axes == RotationAxes.MouseXAndY)
		{
			float rotationX = transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * sensitivityX) + (Input.GetAxis("JoyLookX") * sensitivityXJoy);
			
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY * rotateInfluence;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
		}
		else if (axes == RotationAxes.MouseX)
		{
			mouseRot += (Input.GetAxis("Mouse X")* sensitivityX) * rotateInfluence + ((Input.GetAxis("JoyLookX") * sensitivityXJoy) * rotateInfluence);
			DirXform.rotation = Quaternion.Euler(0, mouseRot, 0);
			//transform.Rotate(0, ((Input.GetAxis("Mouse X")* sensitivityX) * rotateInfluence) + ((Input.GetAxis("JoyLookX") * sensitivityXJoy) * rotateInfluence), 0);
			//DirXform.rotation = Quaternion.Euler(0.0f, transform.rotation.y, 0.0f);
		}
		else
		{
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);
			
			transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
		}



		transform.rotation = DirXform.rotation;
		float hmdY = CameraController.centerEyeAnchor.localRotation.eulerAngles.y;
		DirXform.rotation *=  Quaternion.Euler(0, hmdY, 0);

	}
	
	void Start ()
	{
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;
	}
}