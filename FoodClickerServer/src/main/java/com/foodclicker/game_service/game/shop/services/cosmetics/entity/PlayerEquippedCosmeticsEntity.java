package com.foodclicker.game_service.game.shop.services.cosmetics.entity;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Getter
@Setter
@NoArgsConstructor
@Table(name = "player_equipped_cosmetics")
public class PlayerEquippedCosmeticsEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    @OneToOne
    @JoinColumn(name = "cosmetics_id")
    private PlayerCosmeticsEntity cosmetics;
    @ManyToOne
    @JoinColumn(name = "user_id")
    private UserEntity user;
    public PlayerEquippedCosmeticsEntity(PlayerCosmeticsEntity cosmetics) {
        this.cosmetics = cosmetics;
        user = cosmetics.getUser();
    }
}
