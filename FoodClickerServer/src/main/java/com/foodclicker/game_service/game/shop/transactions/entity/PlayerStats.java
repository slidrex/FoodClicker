package com.foodclicker.game_service.game.shop.transactions.entity;

import com.foodclicker.game_service.food_id.identity_service.entity.UserEntity;
import jakarta.persistence.*;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Table(name = "player_stats")
@Getter
@Setter
@NoArgsConstructor
public class PlayerStats {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;
    @OneToOne
    @JoinColumn(name = "user_id")
    private UserEntity user;
    private int money;
    private int prestigeLevel;
    private Integer gps;
    private Integer gpc;

    public PlayerStats(UserEntity user, int money, Integer gps, Integer gpc, int prestigeLevel) {
        this.user = user;
        this.prestigeLevel = prestigeLevel;
        this.money = money;
        this.gps = gps;
        this.gpc = gpc;
    }
}
