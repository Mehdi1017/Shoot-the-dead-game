using UnityEngine;
using UnityEngine.AI;

public class ZombieCharacterControl : MonoBehaviour
{
    [SerializeField] private Animator m_animator = null;
    [SerializeField] private Rigidbody m_rigidBody = null;

    private Transform target;
    private NavMeshAgent enemy;
    private bool muerto = false;

    private float AttackTime = 0f;
    
    private float AttackRate = 1.45f;

    private float m_currentV = 0;

    private readonly float m_interpolation = 10;
    public float distance = 0;

    public int vidaZombie = 60;

    public GameObject explosionEffect;

    private AudioSource sonidoZombie;

    public AudioClip ataqueSonido;


    private void Awake()
    {
        if (!m_animator) { gameObject.GetComponent<Animator>(); }
        if (!m_rigidBody) { gameObject.GetComponent<Animator>(); }

        target = GameObject.FindWithTag("Player").transform;
        enemy = GetComponent<NavMeshAgent>();

        sonidoZombie = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        m_currentV = Mathf.Lerp(m_currentV, target.transform.position.z, Time.deltaTime * m_interpolation);

        enemy.SetDestination(target.position);
        m_animator.SetFloat("MoveSpeed", m_currentV);
        distance = enemy.remainingDistance;

        if(enemy.pathPending){
            return;
        }
    

        if(distance <= enemy.stoppingDistance){
            m_animator.SetTrigger("Attack");
            if(Time.time > AttackTime){
                PlayerMove.restarvida += 10;
                sonidoZombie.PlayOneShot(ataqueSonido);
                AttackTime = Time.time + AttackRate;
            }
            PlayerMove.atacado = true;
        }
        else if(PlayerMove.atacado && distance <= enemy.stoppingDistance + 3f){
            PlayerMove.atacado = false;
        }
        

        if(muerto){
            Destroy(this);
        }
    }

    void OnTriggerEnter(Collider other){

        if(other == Disparar.colliderBala){
            vidaZombie -= WeaponSwitching.danyo;

            GameObject newEffect;

            newEffect = Instantiate(explosionEffect, Disparar.colliderBala.transform.position, Disparar.colliderBala.transform.rotation);


            if(vidaZombie <= 0){
				muerto = true;
                m_animator.SetTrigger("Dead");
                ControlRondas.restaenemy +=1 ;
                
                Destroy(other.gameObject);
                Destroy(gameObject, 2);
            }
            Destroy(newEffect, 4);
        }
    }

    public static void restaVida(){
        
    }
}
