package com.foodclicker.game_service.game.social.leader.model;

import com.foodclicker.game_service.game.shop.transactions.entity.PlayerStats;
import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class MoneyLeaderModel {
    private Long userId;
    private String username;
    private int prestigeLevel;
    private int money;
    public MoneyLeaderModel(PlayerStats entity) {
        this.userId = entity.getUser().getId();
        this.prestigeLevel = entity.getPrestigeLevel();
        this.money = entity.getMoney();
        this.username = entity.getUser().getEmail();
    }
}
