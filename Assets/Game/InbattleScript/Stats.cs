[System.Serializable]
public class Stats
{
    public PlayerPoints PlayerController;
    public EnemyPoints EnimeController;
 
    public bool Player;
    public float speed;
    public float health;
    public float maxHealth;
    public float Defence;
    public float damage;
    public float critchance;
    public float luck;
    public float magic;
    public float speedBuff;
    public float DefenceBuff;
    public float damageBuff;
    public float critchanceBuff;
    public float magicBuff;

    public Stats(float sp, float hl, float maxhl, float def, float dm, float crt, float lk, float mg, float spb, float defb, float dmb, float crtb, float mb)
    {
        speed = sp;
        health = hl;
        maxHealth = maxhl;
        Defence = def;
        damage = dm;
        critchance = crt;
        luck = lk;
        magic = mg;
        speedBuff = spb;
        DefenceBuff = defb;
        damageBuff = dmb;
        critchanceBuff = crtb;
        magicBuff = mb;
    }
}
