//This script controls the firing capabilities of the turret. It is responsible for creating the projectiles
//as well as controlling the visual and audio feedback involved in shooting

using UnityEngine;
using UnityEngine.Events;

public class CannonSystem : MonoBehaviour 
{
	[Header("Firing Properties")]
	public float maxProjectileForce = 18000f;   //Maximum force of a projectile
	public float cooldown = 1f;

	[Header("Projectile Properties")]
	public GameObject projectilePrefab;			//The projectile to be shot

	Transform projectileSpawnTransform;         //Location where the projectiles should spawn
	bool canShoot = true;
	Animator anim;								//Reference to the animator component


	void Awake()
	{
		//Get a reference to the projectile spawn point. By providing the path to the object like this, we are making an 
		//inefficient method call more efficient
		projectileSpawnTransform = GameObject.Find("Geometry/Cockpit/Turret Elevation Pivot Point/Projectile Spawn Point").transform;

		//Get a reference to the animator component
		anim = GetComponent<Animator> ();
	}

	public void FireProjectile()
	{
		if (!canShoot)
			return;

		GameObject go = (GameObject)Instantiate(projectilePrefab, projectileSpawnTransform.position, projectileSpawnTransform.rotation);
		Vector3 force = projectileSpawnTransform.transform.forward * maxProjectileForce;
		go.GetComponent<Rigidbody>().AddForce(force) ;
		anim.SetTrigger ("Fire");

		canShoot = false;
		Invoke("CoolDown", cooldown);
	}

	void CoolDown()
	{
		canShoot = true;
	}
}