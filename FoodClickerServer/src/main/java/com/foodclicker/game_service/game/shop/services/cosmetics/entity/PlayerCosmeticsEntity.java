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
@Table(name = "player_cosmetics")
public class PlayerCosmeticsEntity {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    @ManyToOne
    @JoinColumn(name = "user_id")
    private UserEntity user;
    @OneToOne(mappedBy = "cosmetics", orphanRemoval = true, cascade = CascadeType.ALL)
    private PlayerEquippedCosmeticsEntity equippedCosmetics;
    private int groupId;
    private int itemId;
    public PlayerCosmeticsEntity(UserEntity user, int groupId, int documentId) {
        this.user = user;
        this.groupId = groupId;
        this.itemId = documentId;
    }
}
