package com.foodclicker.game_service.game.shop.services.production.entity;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "player_production")
@Getter
@Setter
@NoArgsConstructor
public class PlayerProductionEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    private int productionUID;
    private int level = 0;
    @ManyToOne
    @JoinColumn(name = "user_id")
    private UserEntity user;
    
    public PlayerProductionEntity(int productionUID, int level, UserEntity user) {
        this.productionUID = productionUID;
        this.level = level;
        this.user = user;
    }
}
