﻿using System;

public class HealthSystem {
    
    public event EventHandler OnHealthChanged;
    
    private int health; 
    private int healthMax;
    
    public HealthSystem (int healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }
    
    public int GetHealth() {
        return health;
    }
    
    public float GetHealthPercent() {
        return (float)health / healthMax;
    }
    
    public void Damage(int damageAmount) 
    {
        // zorgt ervoor dat er minder health komt
        health -= damageAmount;
        if (health < 0) 
        {
            health = 0;
        }
        if (OnHealthChanged != null)
        {
            OnHealthChanged(this, EventArgs.Empty);
        }
    }
}

